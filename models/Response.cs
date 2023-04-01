namespace FacturacionHogar.models
{
    public class Response<T>
    {
        public Response()
        {
            error = "no Exception Error";
            message = "I'm Still Alive...";//portal refrences :)
            existError = false;
            results = null;
            result = default(T);
        }
        public Response(Exception ex)
        {
            error = ex.Message;
            existError = true;
            results = null;
            result = default(T);
            message = "";
        }
        public string message { get; set; }
        public string error { get; set; }
        public bool existError { get; set; }
        public List<T>? results { get; set; }
        public T? result { get; set; }
    }
}
