using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public class BaseException : Exception
    {
        public LogException? exception { get; set; }

        public BaseException(LogException logException)
        {
                this.exception = logException;
        }
    }
}
