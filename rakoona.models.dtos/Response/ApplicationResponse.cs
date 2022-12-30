namespace rakoona.models.dtos.Response
{
    public class ApplicationResponse
    {
        public ApplicationResponse(string message)
        {
            IsWorking = false;
            Message = message;
        }

        public ApplicationResponse(IResponse respuesta)
        {
            Respuesta = respuesta;
            IsWorking = true;
            Message = string.Empty;
        }

        public IResponse? Respuesta { get; }
        public bool IsWorking { get; }
        public string Message { get; }
    }
}
