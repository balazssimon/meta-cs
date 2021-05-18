using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public abstract partial class SyntaxParser
    {
        protected class SlidingBuffer<T> : IDisposable
        {
            private static readonly ObjectPool<T[]> s_itemsPool = new ObjectPool<T[]>(() => new T[32], 2);

            private SyntaxParser _parser;
            private T[] _items;
            private int _firstIndex; // The position of _items[0].
            private int _offset; // The index of the current token within _items.
            private int _count;
            private bool _hasResetPoint;
            private int _resetPoint;
            private bool _hasCurrentItem;
            private T _currentItem;
            private T _lastUnbufferedItem;
            private T _previousItem;
            private T _lastCreatedItem;
            private bool _hasMoreItems;

            public SlidingBuffer(SyntaxParser parser, T previousItem)
            {
                _parser = parser;
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
            public T GetCurrentItem() => _hasCurrentItem ? _currentItem : (_currentItem = FetchCurrentItem());

            internal void Reset()
            {
                _firstIndex = 0;
                _offset = 0;
                _count = 0;
                _hasCurrentItem = false;
                _currentItem = default;
                _hasResetPoint = false;
                _resetPoint = 0;
                _previousItem = default;
                _lastUnbufferedItem = default;
                _hasMoreItems = true;
            }

            internal void ResetTo(int index)
            {
                var offset = index - _firstIndex;
                Debug.Assert(offset >= 0 && offset <= _count);
                _offset = offset;
                _hasCurrentItem = false;
                _currentItem = default;
                _hasMoreItems = true;
                if (_count > 0 && _offset > 0) _previousItem = _items[_offset - 1];
                else _previousItem = _lastUnbufferedItem;
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
                if (_count > 0 && _offset > 0)
                {
                    _previousItem = _items[_offset - 1];
                }
                else
                {
                    _previousItem = _lastUnbufferedItem;
                }
                _lastCreatedItem = _previousItem;
            }

            //this method is called very frequently
            //we should keep it simple so that it can be inlined.
            public T EatItem()
            {
                var ct = this.GetCurrentItem();
                MoveToNextItem();
                return ct;
            }

            private void MoveToNextItem()
            {
                _previousItem = _currentItem;
                _hasCurrentItem = false;
                _currentItem = default;
                if (_offset < _count || _hasMoreItems) _offset++;
            }

            public void UpdateCurrentItem(T item)
            {
                Debug.Assert(_hasCurrentItem);
                _items[_offset] = item;
                _currentItem = item;
            }

            public T PeekItem(int n)
            {
                int index = _offset + n;
                /*Debug.Assert(_hasResetPoint || index >= 0, "index must be at least 0");
                Debug.Assert(!_hasResetPoint || index >= _resetPoint, $"index must be at least at the reset point {_resetPoint}");*/
                if (!_hasResetPoint && index < 0) return default;
                if (_hasResetPoint && index < _resetPoint) return default;
                while (_hasMoreItems && index >= _count) 
                {
                    _hasMoreItems = _parser.ReadNewToken();
                }
                if (index >= _count)
                {
                    /*if (_count > 0) return _items[_count - 1];
                    else return default;*/
                    return default;
                }
                else
                {
                    if (n >= 0 && !_hasCurrentItem)
                    {
                        _currentItem = _items[_offset];
                        _hasCurrentItem = true;
                    }
                    return _items[index];
                }
            }

            private T FetchCurrentItem()
            {
                var result = PeekItem(0);
                Debug.Assert(_hasCurrentItem);
                return result;
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

            public void InsertItem(in T item)
            {
                Debug.Assert(item != null);
                if (_count >= _items.Length)
                {
                    this.AddSlot();
                }
                for (int i = _count; i > _offset; i--)
                {
                    _items[i] = _items[i - 1];
                }
                _count++;
                _items[_offset] = item;
                if (_offset == _count) _lastCreatedItem = item;
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
                internal set
                {
                    Debug.Assert(index >= _firstIndex && index < _firstIndex + _count);
                    _items[index] = value;
                }
            }
        }
    }
}
