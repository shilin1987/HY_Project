namespace Learun.Application.Web.Areas.HR_Code.Controllers
{
    internal class OperationResult<T>
    {
        private object error;
        private string v;
        private string message;
        private object success;

        public OperationResult(object success, string v)
        {
            this.success = success;
            this.v = v;
        }

        public OperationResult(object error, string v, string message)
        {
            this.error = error;
            this.v = v;
            this.message = message;
        }
    }
}