using MetaDslx.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Roslyn.Utilities
{
    public class SlidingBuffer<T> : IDisposable
    {
        private static readonly ObjectPool<T[]> s_itemsPool = new ObjectPool<T[]>(() => new T[32], 2);

        private T[] _items;
        private int _firstIndex; // The position of _items[0].
        private int _offset; // The index of the current token within _items.
        private int _count;
        private bool _hasResetPoint;
        private int _resetPoint;
        private bool _hasCurrentItem;
        private bool _hasMoreItems;
        private T _currentItem;
        private T _lastUnbufferedItem;
        private T _previousItem;
        private T _lastCreatedItem;
        private Func<bool> _readNewItem;

        public SlidingBuffer(Func<bool> readNewItem, T previousItem)
        {
            _readNewItem = readNewItem;
            _lastUnbufferedItem = previousItem;
            _previousItem = previousItem;
            _lastCreatedItem = previousItem;
            _items = s_itemsPool.Allocate();
            _hasCurrentItem = false;
            _currentItem = default;
            _hasMoreItems = true;
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

        internal int FirstIndex => _firstIndex;
        internal int Offset => _offset;
        public int Index => _firstIndex + _offset;
        public int Count => _firstIndex + _count;
        public T LastCreatedItem => _lastCreatedItem;
        public T PreviousItem => _previousItem;
        public T CurrentItem => _hasMoreItems ? (_hasCurrentItem ? _currentItem : (_currentItem = FetchCurrentItem())) : default;

        internal void Reset(T previousItem)
        {
            _firstIndex = 0;
            _offset = 0;
            _count = 0;
            _hasMoreItems = true;
            _hasCurrentItem = false;
            _currentItem = default;
            _hasResetPoint = false;
            _resetPoint = 0;
            _lastUnbufferedItem = previousItem;
            _previousItem = previousItem;
            _lastCreatedItem = previousItem;
        }

        internal void ResetTo(int index)
        {
            var offset = index - _firstIndex;
            Debug.Assert(offset >= 0 && offset < _count);
            _offset = offset;
        }

        internal void MarkResetPoint()
        {
            _hasResetPoint = true;
            _resetPoint = Math.Min(Index, _resetPoint);
        }

        internal void ReleaseResetPoint()
        {
            _hasResetPoint = false;
        }

        internal void ForgetFollowingItems()
        {
            _hasMoreItems = true;
            _hasCurrentItem = false;
            _currentItem = default;
            _count = _offset;
            if (_count > 0 && _offset > 0) _previousItem = _items[_offset - 1];
            else _previousItem = _lastUnbufferedItem;
            _lastCreatedItem = _previousItem;
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
            if (_hasMoreItems)
            {
                _previousItem = _currentItem;
                _hasCurrentItem = false;
                _currentItem = default;
                _offset++;
            }
        }

        public T PeekItem(int n)
        {
            int index = _offset + n;
            if (!_hasResetPoint && index < 0) return default;
            if (_hasResetPoint && index < _resetPoint) return default;
            //Debug.Assert(_hasResetPoint || index >= 0, "index must be at least 0");
            //Debug.Assert(!_hasResetPoint || index >= _resetPoint, $"index must be at least at the reset point {_resetPoint}");
            while (_hasMoreItems && index >= _count) 
            {
                _hasMoreItems = _readNewItem();
            }
            if (index >= _count)
            {
                if (_count > 0) return _items[_count - 1];
                else return default;
            }
            else
            {
                return _items[index];
            }
        }

        private T FetchCurrentItem()
        {
            return PeekItem(0);
        }

        public void AddItem(in T item)
        {
            Debug.Assert(item != null);
            if (_count >= _items.Length)
            {
                this.AddSlot();
            }
            _items[_count] = item;
            _lastCreatedItem = item;
            _count++;
        }

        private void AddSlot()
        {
            // shift tokens to left if we are far to the right
            // don't shift if reset points have fixed locked tge starting point at the token in the window
            if (_offset > (_items.Length >> 1)
                && (_resetPoint == -1 || _resetPoint > _firstIndex))
            {
                int shiftOffset = (_resetPoint == -1) ? _offset : _resetPoint - _firstIndex;
                int shiftCount = _count - shiftOffset;
                Debug.Assert(shiftOffset > 0);
                _lastUnbufferedItem = _items[shiftOffset - 1];
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
