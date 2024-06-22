using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(LogException logException) : base(logException)
        {
        }
    }
}
