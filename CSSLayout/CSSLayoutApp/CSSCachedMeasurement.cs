using System.Runtime.InteropServices;

namespace CSSLayoutApp
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CSSCachedMeasurement
    {
        public float availableWidth;
        public float availableHeight;
        public CSSMeasureMode widthMeasureMode;
        public CSSMeasureMode heightMeasureMode;

        public float computedWidth;
        public float computedHeight;
    }
}
