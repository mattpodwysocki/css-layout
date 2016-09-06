using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSLayoutApp
{
    public interface ICSSNode : IList<ICSSNode>, IDisposable
    {
        bool IsDirty { get; }

        void MarkDirty();

        CSSMeasureFunc Measure { get; set; }

        CSSPrintFunc Print { get; set; }

        bool IsTextNode { get; set; }

        bool HasNewLayout { get; set; }

        
    }
}
