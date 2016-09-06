using System.Runtime.InteropServices;

namespace CSSLayoutApp
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CSSLayout
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] position;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public float[] dimensions;
        public CSSDirection direction;

        public float computedFlexBasis;

        // Instead of recomputing the entire layout every single time, we
        // cache some information to break early when nothing changed
        public uint generationCount;
        public CSSDirection lastParentDirection;

        public uint nextCachedMeasurementsIndex;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public CSSCachedMeasurement[] cachedMeasurements;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public float[] measuredDimensions;

        public CSSCachedMeasurement cached_layout;
    }
}
