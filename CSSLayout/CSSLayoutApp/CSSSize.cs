using System.Runtime.InteropServices;

namespace CSSLayoutApp
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CSSSize
    {
        public float width;
        public float height;
    }
}
