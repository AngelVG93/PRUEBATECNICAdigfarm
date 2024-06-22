using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public class BadRequestBusinessException : BaseException
    {
        public BadRequestBusinessException(LogException logException) : base(logException)
        {
        }
    }
}
