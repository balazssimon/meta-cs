// Incremental token stream for incremental ANTLR4 parsing
// Based on:
//     https://github.com/dberlin/antlr4ts/blob/incremental/src/IncrementalTokenStream.ts

using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Antlr4Intellisense
{
	public class IncrementalTokenStream : CommonTokenStream
	{
		// ANTLR looks at the same tokens alot, and this avoids recalculating the
		// interval when the position and lookahead number doesn't move.
		private int lastP = -1;
		private int lastK = -1;

		/// <summary>
		/// This tracks the min/max token index looked at since the value was reset.
		/// This is used to track how far ahead the grammar looked, since it may be
		/// outside the rule context's start/stop tokens.
		/// We need to maintain a stack of such indices.
		/// </summary>
		private Stack<Interval> minMaxStack = new Stack<Interval>();

		public IncrementalTokenStream([NotNull] ITokenSource tokenSource) 
			: base(tokenSource)
		{
		}

		public IncrementalTokenStream([NotNull] ITokenSource tokenSource, int channel) 
			: base(tokenSource, channel)
		{
		}


		/// <summary>
		/// Push a new minimum/maximum token state.
		/// </summary>
		/// <param name="min">Minimum token index</param>
		/// <param name="max">Maximum token index</param>
		public void PushMinMax(int min, int max)
		{
			this.minMaxStack.Push(Interval.Of(min, max));
		}

		/// <summary>
		/// Pop the current minimum/maximum token state and return it.
		/// </summary>
		/// <returns></returns>
		public Interval PopMinMax() {
			if (this.minMaxStack.Count == 0) {
				throw new IndexOutOfRangeException("Can't pop the min max state when there are 0 states");
			}
			return this.minMaxStack.Pop();
		}

		/// <summary>
		/// Return the number of items on the minimum/maximum token state stack.
		/// </summary>
		public int MinMaxSize => this.minMaxStack.Count;

		/// <summary>
		/// This is an override of the base LT function that tracks the minimum/maximum token index looked at.
		/// </summary>
		/// <param name="k"></param>
		/// <returns></returns>
		public override IToken Lt(int k) {
			var result = base.Lt(k);
			// Adjust the top of the minimum maximum stack if the position/lookahead amount changed.
			if (this.minMaxStack.Count > 0 && (this.lastP != this.p || this.lastK != k)) {
				var stackItem = this.minMaxStack.Pop();
				this.minMaxStack.Push(stackItem.Union(Interval.Of(result.TokenIndex, result.TokenIndex)));
				this.lastP = this.p;
				this.lastK = k;
			}
			return result;
		}
	}
}
