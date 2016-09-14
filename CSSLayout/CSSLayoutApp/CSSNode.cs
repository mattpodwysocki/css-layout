﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CSSLayoutApp
{
    public class CSSNode : IDisposable, ICSSNode
    {
        private bool _isDisposed;
        private IntPtr _cssNode;
        private IntPtr _context;

        private CSSNode _parent;
        private List<CSSNode> _children;
        private MeasureFunction _measureFunction;
        public object _data;

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
            _cssNode = Native.CSSNodeNew();
            _context = (IntPtr)GCHandle.Alloc(this);
            Native.CSSNodeSetContext(_cssNode, _context);
            _children = new List<CSSNode>(4);
        }

        public void Reset()
        {
            Native.CSSNodeFree(_cssNode);
            GCHandle.FromIntPtr(_context).Free();
            _children = null;
            _parent = null;
            _measureFunction = null;
        }

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
                CheckDisposed();
                return _parent;
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
                CheckDisposed();
                return Native.CSSNodeStyleGetDirection(_cssNode);
            }
            set
            {
                CheckDisposed();
                Native.CSSNodeStyleSetDirection(_cssNode, value);
            }
        }

        public CSSFlexDirection FlexDirection
        {
            get
            {
                CheckDisposed();
                return Native.CSSNodeStyleGetFlexDirection(_cssNode);
            }

            set
            {
                CheckDisposed();
                Native.CSSNodeStyleSetFlexDirection(_cssNode, value);
            }
        }

        public CSSJustify JustifyContent
        {
            get
            {
                CheckDisposed();
                return Native.CSSNodeStyleGetJustifyContent(_cssNode);
            }

            set
            {
                CheckDisposed();
                Native.CSSNodeStyleSetJustifyContent(_cssNode, value);
            }
        }

        public CSSAlign AlignItems
        {
            get
            {
                CheckDisposed();
                return Native.CSSNodeStyleGetAlignItems(_cssNode);
            }

            set
            {
                CheckDisposed();
                Native.CSSNodeStyleSetAlignItems(_cssNode, value);
            }
        }

        public CSSAlign AlignSelf
        {
            get
            {
                CheckDisposed();
                return Native.CSSNodeStyleGetAlignSelf(_cssNode);
            }

            set
            {
                CheckDisposed();
                Native.CSSNodeStyleSetAlignSelf(_cssNode, value);
            }
        }

        public CSSAlign AlignContent
        {
            get
            {
                CheckDisposed();
                return Native.CSSNodeStyleGetAlignContent(_cssNode);
            }

            set
            {
                CheckDisposed();
                Native.CSSNodeStyleSetAlignContent(_cssNode, value);
            }
        }

        public CSSPositionType PositionType
        {
            get
            {
                CheckDisposed();
                return Native.CSSNodeStyleGetPositionType(_cssNode);
            }

            set
            {
                CheckDisposed();
                Native.CSSNodeStyleSetPositionType(_cssNode, value);
            }
        }

        public CSSWrapType Wrap
        {
            get
            {
                CheckDisposed();
                return Native.CSSNodeStyleGetFlexWrap(_cssNode);
            }

            set
            {
                CheckDisposed();
                Native.CSSNodeStyleSetFlexWrap(_cssNode, value);
            }
        }

        public float Flex
        {
            get
            {
                CheckDisposed();
                return Native.CSSNodeStyleGetFlex(_cssNode);
            }

            set
            {
                CheckDisposed();
                Native.CSSNodeStyleSetFlex(_cssNode, value);
            }
        }

        public float FlexGrow
        {
            get
            {
                CheckDisposed();
                return Native.CSSNodeStyleGetFlexGrow(_cssNode);
            }

            set
            {
                CheckDisposed();
                Native.CSSNodeStyleSetFlexGrow(_cssNode, value);
            }
        }

        public float FlexShrink
        {
            get
            {
                CheckDisposed();
                return Native.CSSNodeStyleGetFlexShrink(_cssNode);
            }

            set
            {
                CheckDisposed();
                Native.CSSNodeStyleSetFlexShrink(_cssNode, value);
            }
        }

        public float FlexBasis
        {
            get
            {
                CheckDisposed();
                return Native.CSSNodeStyleGetFlexBasis(_cssNode);
            }

            set
            {
                CheckDisposed();
                Native.CSSNodeStyleSetFlexBasis(_cssNode, value);
            }
        }

        public Spacing GetMargin()
        {
            CheckDisposed();

            var margin = new Spacing();
            margin.Set(Spacing.LEFT, Native.CSSNodeStyleGetMargin(_cssNode, CSSEdge.Left));
            margin.Set(Spacing.TOP, Native.CSSNodeStyleGetMargin(_cssNode, CSSEdge.Top));
            margin.Set(Spacing.RIGHT, Native.CSSNodeStyleGetMargin(_cssNode, CSSEdge.Right));
            margin.Set(Spacing.BOTTOM, Native.CSSNodeStyleGetMargin(_cssNode, CSSEdge.Bottom));
            margin.Set(Spacing.START, Native.CSSNodeStyleGetMargin(_cssNode, CSSEdge.Start));
            margin.Set(Spacing.END, Native.CSSNodeStyleGetMargin(_cssNode, CSSEdge.End));

            return margin;
        }

        public void SetMargin(CSSEdge edge, float value)
        {
            CheckDisposed();
            Native.CSSNodeStyleSetMargin(_cssNode, edge, value);
        }

        public Spacing GetPadding()
        {
            CheckDisposed();

            var padding = new Spacing();
            padding.Set(Spacing.LEFT, Native.CSSNodeStyleGetPadding(_cssNode, CSSEdge.Left));
            padding.Set(Spacing.TOP, Native.CSSNodeStyleGetPadding(_cssNode, CSSEdge.Top));
            padding.Set(Spacing.RIGHT, Native.CSSNodeStyleGetPadding(_cssNode, CSSEdge.Right));
            padding.Set(Spacing.BOTTOM, Native.CSSNodeStyleGetPadding(_cssNode, CSSEdge.Bottom));
            padding.Set(Spacing.START, Native.CSSNodeStyleGetPadding(_cssNode, CSSEdge.Start));
            padding.Set(Spacing.END, Native.CSSNodeStyleGetPadding(_cssNode, CSSEdge.End));

            return padding;
        }

        public void SetPadding(CSSEdge edge, float padding)
        {
            CheckDisposed();
            Native.CSSNodeStyleSetPadding(_cssNode, edge, padding);
        }

        public Spacing GetBorder()
        {
            CheckDisposed();

            var border = new Spacing();
            border.Set(Spacing.LEFT, Native.CSSNodeStyleGetBorder(_cssNode, CSSEdge.Left));
            border.Set(Spacing.TOP, Native.CSSNodeStyleGetBorder(_cssNode, CSSEdge.Top));
            border.Set(Spacing.RIGHT, Native.CSSNodeStyleGetBorder(_cssNode, CSSEdge.Right));
            border.Set(Spacing.BOTTOM, Native.CSSNodeStyleGetBorder(_cssNode, CSSEdge.Bottom));
            border.Set(Spacing.START, Native.CSSNodeStyleGetBorder(_cssNode, CSSEdge.Start));
            border.Set(Spacing.END, Native.CSSNodeStyleGetBorder(_cssNode, CSSEdge.End));

            return border;
        }

        public void SetBorder(CSSEdge edge, float border)
        {
            CheckDisposed();
            Native.CSSNodeStyleSetBorder(_cssNode, edge, border);
        }

        public Spacing GetPosition()
        {
            CheckDisposed();

            var position = new Spacing();
            position.Set(Spacing.LEFT, Native.CSSNodeStyleGetPosition(_cssNode, CSSEdge.Left));
            position.Set(Spacing.TOP, Native.CSSNodeStyleGetPosition(_cssNode, CSSEdge.Top));
            position.Set(Spacing.RIGHT, Native.CSSNodeStyleGetPosition(_cssNode, CSSEdge.Right));
            position.Set(Spacing.BOTTOM, Native.CSSNodeStyleGetPosition(_cssNode, CSSEdge.Bottom));
            position.Set(Spacing.START, Native.CSSNodeStyleGetPosition(_cssNode, CSSEdge.Start));
            position.Set(Spacing.END, Native.CSSNodeStyleGetPosition(_cssNode, CSSEdge.End));

            return position;
        }

        public void SetPosition(CSSEdge edge, float position)
        {
            CheckDisposed();
        }

        public float StyleWidth
        {
            get
            {
                CheckDisposed();
                return Native.CSSNodeStyleGetWidth(_cssNode);
            }

            set
            {
                CheckDisposed();
                Native.CSSNodeStyleSetWidth(_cssNode, value);
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
                CheckDisposed();
                return Native.CSSNodeLayoutGetDirection(_cssNode);
            }
        }

        public CSSOverflow Overflow
        {
            get
            {
                CheckDisposed();
                return Native.CSSNodeStyleGetOverflow(_cssNode);
            }

            set
            {
                CheckDisposed();
                Native.CSSNodeStyleSetOverflow(_cssNode, value);
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
                CheckDisposed();
                return _children[index];
            }
        }

        public int Count
        {
            get
            {
                CheckDisposed();
                return _children.Count;
            }
        }

        public void MarkLayoutSeen()
        {
            CheckDisposed();
            Native.CSSNodeSetHasNewLayout(_cssNode, false);
        }

        public bool ValuesEqual(float f1, float f2)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, CSSNode node)
        {
            CheckDisposed();
            _children.Insert(index, node);
            node._parent = this;
            Native.CSSNodeInsertChild(_cssNode, node._cssNode, (uint)index);
        }

        public void RemoveAt(int index)
        {
            CheckDisposed();
            var child = _children[index];
            child._parent = null;
            _children.RemoveAt(index);
            Native.CSSNodeRemoveChild(_cssNode, child._cssNode);
        }

        public int IndexOf(CSSNode node)
        {
            CheckDisposed();
            return _children.IndexOf(node);
        }

        void ICSSNode.Insert(int index, ICSSNode node)
        {
            Insert(index, (CSSNode)node);

        }

        int ICSSNode.IndexOf(ICSSNode node)
        {
            return IndexOf((CSSNode)node);
        }

        public void SetMeasureFunction(MeasureFunction measureFunction)
        {
            throw new NotImplementedException();
        }

        public void CalculateLayout(CSSLayoutContext layoutContext)
        {
            CheckDisposed();
            Native.CSSNodeCalculateLayout(_cssNode, CSSConstants.UNDEFINED, CSSConstants.UNDEFINED, Native.CSSNodeStyleGetDirection(_cssNode));
        }
    }
}
