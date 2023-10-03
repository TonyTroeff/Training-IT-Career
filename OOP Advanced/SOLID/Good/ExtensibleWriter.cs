using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Good
{
    public class ExtensibleWriter
    {
        private Func<string, string> _formatMessage;
    }
}
