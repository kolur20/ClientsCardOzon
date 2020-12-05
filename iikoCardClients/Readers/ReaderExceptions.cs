using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reader
{
    class ReaderExceptions : Exception
    {
        
    }
    class OpenReaderException : ReaderExceptions { }
    class ReadReaderException : ReaderExceptions { }
    
}
