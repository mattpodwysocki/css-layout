using System;
using System.Runtime.InteropServices;

namespace CSSLayoutApp
{
    public static class Native
    {
        [DllImport("CSSLayout.dll")]
        public static extern IntPtr CSSNodeNew();

        [DllImport("CSSLayout.dll")]
        public static extern void CSSNodeInit(IntPtr cssNode);

        [DllImport("CSSLayout.dll")]
        public static extern void CSSNodeFree(IntPtr cssNode);

        [DllImport("CSSLayout.dll")]
        public static extern void CSSNodeInsertChild(IntPtr node, IntPtr child, uint index);

        [DllImport("CSSLayout.dll")]
        public static extern void CSSNodeRemoveChild(IntPtr node, IntPtr child);

        [DllImport("CSSLayout.dll")]
        public static extern IntPtr CSSNodeGetChild(IntPtr node, uint index);

        [DllImport("CSSLayout.dll")]
        public static extern uint CSSNodeChildCount(IntPtr node);

        [DllImport("CSSLayout.dll")]
        public static extern void CSSNodeCalculateLayout(IntPtr node,
                            float availableWidth,
                            float availableHeight,
                           CSSDirection parentDirection);
    }
}
