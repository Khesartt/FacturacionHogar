namespace FacturacionHogar.models
{
    public class Response<T>
    {
        public const string stillAlive = "I'm Still Alive...";
        public const string defaultError = "No Exception Error";

        public string Message { get; set; }
        public string Error { get; set; }
        public bool ExistError { get; set; }
        public List<T>? Results { get; set; }
        public T? Result { get; set; }

        public Response(T obj)
        {
            Error = defaultError;
            Message = stillAlive;
            ExistError = false;
            Results = null;
            Result = obj;
        }

        public Response(List<T> obj)
        {
            Error = defaultError;
            Message = stillAlive;
            ExistError = false;
            Results = obj;
            Result = default;
        }

        public Response(Exception ex)
        {
            Error = ex.Message;
            ExistError = true;
            Results = null;
            Result = default;
            Message = string.Empty;
        }
    }
}
