using System.Collections.Generic;

namespace Law_Connect.Common.Utilities
{
    public class Result
    {
        public bool IsSuccess { get; private set; }
        public List<string> Errors { get; private set; }

        private Result(bool isSuccess, List<string> errors = null)
        {
            IsSuccess = isSuccess;
            Errors = errors ?? new List<string>();
        }

        public static Result Success() => new Result(true);
        public static Result Failure(List<string> errors) => new Result(false, errors);
        public static Result Failure(string error) => new Result(false, new List<string> { error });
    }
}
