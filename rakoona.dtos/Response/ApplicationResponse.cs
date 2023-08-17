namespace rakoona.dtos.Response
{
    public class ApplicationResponse<T>
    {
        private T? _respuesta { get; set; }

        public ApplicationResponse(int code, T? respuesta)
        {
            IsSuccess = true;
            Code = code;
            _respuesta = respuesta;
        }

        public ApplicationResponse(Response error)
        {
            IsSuccess = false;
            Code = Convert.ToInt32(error.Status);
            Error = new { message = error.Message };
        }

        public bool IsSuccess { get; }
        public int Code { get; }
        public T? Respuesta { get; }
        public object? Error { get; }
    }
}
