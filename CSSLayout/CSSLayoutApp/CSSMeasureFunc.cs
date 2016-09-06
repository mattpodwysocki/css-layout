using System;

namespace CSSLayoutApp
{
    public delegate CSSSize CSSMeasureFunc(
        IntPtr context, 
        float width,
        CSSMeasureMode widthMode,
        float height,
        CSSMeasureMode heightMode);
}
