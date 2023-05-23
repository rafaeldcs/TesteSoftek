namespace Questao5.Application.Commands.Responses
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public T Data { get; }
        public string ErrorMessage { get; }
        public string ErrorCode { get; }

        protected Result(bool isSuccess, T data, string errorMessage, string errorCode)
        {
            IsSuccess = isSuccess;
            Data = data;
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
        }

        public static Result<T> Success(T data)
        {
            return new Result<T>(true, data, null, null);
        }

        public static Result<T> Failure(string errorMessage, string errorCode)
        {
            return new Result<T>(false, default(T), errorMessage, errorCode);
        }
    }
}
