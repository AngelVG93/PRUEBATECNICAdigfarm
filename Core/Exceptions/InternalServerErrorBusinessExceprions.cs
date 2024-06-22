
namespace Core.Exceptions
{
    public class InternalServerErrorBusinessExceprions : BaseException
    {
        public InternalServerErrorBusinessExceprions(LogException logException) : base(logException)
        {
        }
    }
}
