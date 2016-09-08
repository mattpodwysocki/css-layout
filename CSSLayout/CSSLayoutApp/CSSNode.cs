using System;
using System.Runtime.InteropServices;

namespace CSSLayoutApp
{
    public class CSSNode : IDisposable, ICSSNode
    {
        private enum LayoutState
        {
            DIRTY,

            HAS_NEW_LAYOUT,

            UP_TO_DATE
        }

        private readonly CSSStyle _style = new CSSStyle();
        private CSSLayout _layout = new CSSLayout();


        private bool _isDisposed;
        private readonly IntPtr _cssNode;
        private readonly IntPtr _context;

        public int LineIndex { get; set; }

        public bool IsDirty
        {
            get
            {
                CheckDisposed();
                return Native.CSSNodeIsDirty(_cssNode);
            }
        }

        public void MarkDirty()
        {
            CheckDisposed();
            Native.CSSNodeMarkDirty(_cssNode);
        }

        public bool IsTextNode
        {
            get
            {
                CheckDisposed();
                return Native.CSSNodeGetIsTextnode(_cssNode);
            }

            set
            {
                CheckDisposed();
                Native.CSSNodeSetIsTextnode(_cssNode, value);
            }
        }

        public bool HasNewLayout
        {
            get
            {
                CheckDisposed();
                return Native.CSSNodeGetHasNewLayout(_cssNode);
            }

            set
            {
                CheckDisposed();
                Native.CSSNodeSetHasNewLayout(_cssNode, value);
            }
        }

        public ICSSNode Parent
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsMeasureDefined
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public CSSDirection StyleDirection
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public CSSFlexDirection FlexDirection
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public CSSJustify JustifyContent
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public CSSAlign AlignItems
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public CSSAlign AlignSelf
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public CSSAlign AlignContent
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public CSSPositionType PositionType
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public CSSWrapType Wrap
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public float Flex
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public float FlexGrow
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public float FlexShrink
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public float FlexBasis
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Spacing Margin
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Spacing Padding
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Spacing Border
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Spacing Position
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public float StyleWidth
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public float StyleHeight
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public float StyleMaxWidth
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public float StyleMaxHeight
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public float StyleMinWidth
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public float StyleMinHeight
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public float LayoutX
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public float LayoutY
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public float LayoutWidth
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public float LayoutHeight
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public CSSDirection LayoutDirection
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public CSSOverflow Overflow
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public object Data
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public ICSSNode this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

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
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing)
            {
                _isDisposed = true;
                Native.CSSNodeFree(_cssNode);
                GCHandle.FromIntPtr(_context).Free();
            }
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void MarkLayoutSeen()
        {
            throw new NotImplementedException();
        }

        public bool ValuesEqual(float f1, float f2)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, ICSSNode node)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(ICSSNode node)
        {
            throw new NotImplementedException();
        }

        public void SetMeasureFunction(MeasureFunction measureFunction)
        {
            throw new NotImplementedException();
        }

        public void CalculateLayout(CSSLayoutContext layoutContext)
        {
            throw new NotImplementedException();
        }
    }
}
