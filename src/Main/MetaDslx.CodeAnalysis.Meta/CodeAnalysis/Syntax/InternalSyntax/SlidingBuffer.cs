using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public class SlidingBuffer<T> : IDisposable
    {
        private static readonly ObjectPool<T[]> s_itemsPool = new ObjectPool<T[]>(() => new T[32], 2);

        private T[] _items;
        private int _firstIndex; // The position of _items[0].
        private int _offset; // The index of the current token within _items.
        private int _count;
        private int _resetCount;
        private int _resetStart;
        private bool _hasCurrentItem;
        private T _currentItem;
        private IEnumerator<T> _itemSource;

        public SlidingBuffer(IEnumerable<T> itemsSource)
        {
            _itemSource = itemsSource.GetEnumerator();
            _items = s_itemsPool.Allocate();
            _hasCurrentItem = false;
            _currentItem = default;
        }

        public void Dispose()
        {
            var items = _items;
            if (items != null)
            {
                _items = null;
                if (items.Length < 4096)
                {
                    Array.Clear(items, 0, items.Length);
                    s_itemsPool.Free(items);
                }
                else
                {
                    s_itemsPool.ForgetTrackedObject(items);
                }
            }
        }

        public int Index => _firstIndex + _offset;
        public int Count => _count;
        public T CurrentItem => _hasCurrentItem ? _currentItem : (_currentItem = FetchCurrentItem());

        public void Reset()
        {
            _firstIndex = 0;
            _offset = 0;
            _count = 0;
            _hasCurrentItem = false;
            _currentItem = default;
        }

        public SlidingBufferResetPoint GetResetPoint()
        {
            var pos = Index;
            if (_resetCount == 0)
            {
                _resetStart = pos; // low water mark
            }
            _resetCount++;
            return new SlidingBufferResetPoint(_resetCount, pos);
        }

        public void Reset(ref SlidingBufferResetPoint point)
        {
            var offset = point.Position - _firstIndex;
            Debug.Assert(offset >= 0 && offset < _count);
            _offset = offset;
            _hasCurrentItem = false;
            _currentItem = default;
            // look forward for slots not holding a token
            for (int i = _offset; i < _count; i++)
            {
                if (_items[i] == null)
                {
                    // forget anything after and including any slot not holding a token
                    _count = i;
                    if (_count == _offset)
                    {
                        _currentItem = FetchCurrentItem();
                    }
                    break;
                }
            }
        }

        public void Release(ref SlidingBufferResetPoint point)
        {
            Debug.Assert(_resetCount == point.ResetCount);
            _resetCount--;
            if (_resetCount == 0)
            {
                _resetStart = -1;
            }
        }

        //this method is called very frequently
        //we should keep it simple so that it can be inlined.
        public T EatItem()
        {
            var ct = this.CurrentItem;
            MoveToNextItem();
            return ct;
        }

        private void MoveToNextItem()
        {
            _hasCurrentItem = false;
            _currentItem = default;
            _offset++;
        }

        public T PeekItem(int n)
        {
            int index = _offset + n;
            Debug.Assert(index >= 0);
            while (index >= _count && _itemSource.MoveNext())
            {
                this.AddItem(_itemSource.Current);
            }
            if (index >= _count) return default;
            return _items[index];
        }

        private T FetchCurrentItem()
        {
            if (_offset >= _count && _itemSource.MoveNext())
            {
                this.AddItem(_itemSource.Current);
            }
            return _items[_offset];
        }

        public void AddItem(in T item)
        {
            Debug.Assert(item != null);
            if (_count >= _items.Length)
            {
                this.AddSlot();
            }
            _items[_count] = item;
            _count++;
        }

        public void InsertItem(in T item)
        {
            Debug.Assert(item != null);
            if (_count >= _items.Length)
            {
                this.AddSlot();
            }
            _count++;
            for (int i = _count; i > _offset; i--)
            {
                _items[i] = _items[i - 1];
            }
            _items[_offset] = item;
        }

        private void AddSlot()
        {
            // shift tokens to left if we are far to the right
            // don't shift if reset points have fixed locked tge starting point at the token in the window
            if (_offset > (_items.Length >> 1)
                && (_resetStart == -1 || _resetStart > _firstIndex))
            {
                int shiftOffset = (_resetStart == -1) ? _offset : _resetStart - _firstIndex;
                int shiftCount = _count - shiftOffset;
                Debug.Assert(shiftOffset > 0);
                if (shiftCount > 0)
                {
                    Array.Copy(_items, shiftOffset, _items, 0, shiftCount);
                }

                _firstIndex += shiftOffset;
                _count -= shiftOffset;
                _offset -= shiftOffset;
            }
            else
            {
                var old = _items;
                Array.Resize(ref _items, _items.Length * 2);
                s_itemsPool.ForgetTrackedObject(old, replacement: _items);
            }
        }

        public T this[int index]
        {
            get
            {
                Debug.Assert(index >= _firstIndex && index < _firstIndex + _count);
                return _items[index];
            }
        }
    }
}
