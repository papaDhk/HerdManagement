using System.Collections.Generic;

namespace Applicattion.Data.Messages
{
    public class Response<T>
    {
        public bool IsOperationSuccessfull { get; set; }

        public T Core { get; set; }

        public List<string> Errors { get; } = new List<string>();

        public Response<T> ToSuccessfull(T core)
        {
            Core = core;
            IsOperationSuccessfull = true;
            return this;
        }
    }
}
