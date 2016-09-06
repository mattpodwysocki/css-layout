using System;
using System.Runtime.InteropServices;

namespace CSSLayoutApp
{
    public class CSSNode : IDisposable
    {
        private bool _isDisposed;
        private readonly IntPtr _cssNode;
        private readonly IntPtr _context;

        public CSSNode()
        {
            _cssNode = Native.CSSNodeNew();
            _context = (IntPtr)GCHandle.Alloc(this);
            Native.CSSNodeSetContext(_cssNode, _context);
        }

        public CSSNode(IntPtr cssNode)
        {
            _cssNode = cssNode;
        }

        private void CheckDisposed()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException("CSSNode");
            }
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _isDisposed = true;
                Native.CSSNodeFree(_cssNode);
                GCHandle.FromIntPtr(_context).Free();
            }
        }

        public CSSNode this[int index]
        {
            get
            {
                CheckDisposed();
                var ptr = Native.CSSNodeGetChild(_cssNode, (uint)index);
                return new CSSNode(ptr);
            }
        }

        public int Count
        {
            get
            {
                CheckDisposed();
                return (int)Native.CSSNodeChildCount(_cssNode);
            }
        }

        public void Add(CSSNode node)
        {
            CheckDisposed();
            var index = Native.CSSNodeChildCount(_cssNode);
            Native.CSSNodeInsertChild(_cssNode, node._cssNode, (uint)index);
        }

        public void Insert(int index, CSSNode node)
        {
            CheckDisposed();
            Native.CSSNodeInsertChild(_cssNode, node._cssNode, (uint)index);
        }

        public void Remove(CSSNode node)
        {
            CheckDisposed();
            Native.CSSNodeRemoveChild(_cssNode, node._cssNode);
        }

        public bool IsDirty
        {
            get
            {
                CheckDisposed();
                return Native.CSSNodeIsDirty(_cssNode);
            }
        }

        protected void MarkDirty()
        {
            CheckDisposed();
            Native.CSSNodeMarkDirty(_cssNode);
        }

        public bool IsTextNode
        {
            get
            {
                return Native.CSSNodeGetIsTextnode(_cssNode);
            }
            set
            {
                Native.CSSNodeSetIsTextnode(_cssNode, value);
            }
        }

        public bool HasNewLayout
        {
            get
            {
                return Native.CSSNodeGetHasNewLayout(_cssNode);
            }
            set
            {
                Native.CSSNodeSetHasNewLayout(_cssNode, true);
            }
        }

        public CSSDirection Direction
        {
            get
            {
                return Native.CSSNodeStyleGetDirection(_cssNode);
            }
            set
            {
                Native.CSSNodeStyleSetDirection(_cssNode, value);
            }
        }

        public CSSFlexDirection FlexDirection
        {
            get
            {
                return Native.CSSNodeStyleGetFlexDirection(_cssNode);
            }
            set
            {
                Native.CSSNodeStyleSetFlexDirection(_cssNode, value);
            }
        }

        public CSSJustify JustifyContent
        {
            get
            {
                return Native.CSSNodeStyleGetJustifyContent(_cssNode);
            }
            set
            {
                Native.CSSNodeStyleSetJustifyContent(_cssNode, value);
            }
        }

        public CSSAlign AlignContent
        {
            get
            {
                return Native.CSSNodeStyleGetAlignContent(_cssNode);
            }
            set
            {
                Native.CSSNodeStyleSetAlignContent(_cssNode, value);
            }
        }

        public CSSAlign AlignItems
        {
            get
            {
                return Native.CSSNodeStyleGetAlignItems(_cssNode);
            }
            set
            {
                Native.CSSNodeStyleSetAlignItems(_cssNode, value);
            }
        }

        public CSSAlign AlignSelf
        {
            get
            {
                return Native.CSSNodeStyleGetAlignSelf(_cssNode);
            }
            set
            {
                Native.CSSNodeStyleSetAlignSelf(_cssNode, value);
            }
        }

        public CSSPositionType PositionType
        {
            get
            {
                return Native.CSSNodeStyleGetPositionType(_cssNode);
            }
            set
            {
                Native.CSSNodeStyleSetPositionType(_cssNode, value);
            }
        }

        public CSSWrapType FlexWrap
        {
            get
            {
                return Native.CSSNodeStyleGetFlexWrap(_cssNode);
            }
            set
            {
                Native.CSSNodeStyleSetFlexWrap(_cssNode, value);
            }
        }
    }
}
