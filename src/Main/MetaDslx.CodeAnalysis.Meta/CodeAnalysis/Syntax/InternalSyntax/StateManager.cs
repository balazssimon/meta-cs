using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public abstract class StateManager<TState>
        where TState : State
    {
        private readonly Dictionary<int, object?> _stateCache;
        private bool _dirty;
        private TState? _state;

        public StateManager()
        {
            _stateCache = new Dictionary<int, object?>();
            _dirty = true;
        }

        internal void InternalChanged()
        {
            _dirty = true;
        }

        internal void InternalRestoreState(TState? state)
        {
            this.RestoreState(state);
            _state = state;
            _dirty = false;
        }

        protected abstract TState? SaveState(int hashCode);
        protected abstract int ComputeStateHash();
        protected abstract bool IsInState(TState? state);
        protected abstract void RestoreState(TState? state);

        public TState? State
        {
            get
            {
                if (!_dirty) return _state;
                _dirty = false;
                if (_state == null && IsInState(_state))
                {
                    return _state;
                }
                else
                {
                    var hashCode = this.ComputeStateHash();
                    if (_state != null && _state.GetHashCode() == hashCode && IsInState(_state)) return _state;
                    else return LookupCurrentState(hashCode);
                }
            }
        }

        private TState? LookupCurrentState(int hashCode)
        {
            if (!_stateCache.TryGetValue(hashCode, out var potentialState))
            {
                var currentState = this.SaveState(hashCode);
                _stateCache.Add(hashCode, currentState);
                return currentState;
            }
            if (potentialState is null || potentialState is TState)
            {
                var state = potentialState as TState;
                if (IsInState(state)) return state;
                var potentialStates = new List<TState?>();
                potentialStates.Add(state);
                var currentState = this.SaveState(hashCode);
                potentialStates.Add(currentState);
                _stateCache[hashCode] = potentialStates;
                return currentState;
            }
            else
            {
                var potentialStates = (List<TState?>)potentialState;
                foreach (var ps in potentialStates)
                {
                    if (IsInState(ps)) return ps;
                }
                var currentState = this.SaveState(hashCode);
                potentialStates.Add(currentState);
                return currentState;
            }
        }

    }
}
