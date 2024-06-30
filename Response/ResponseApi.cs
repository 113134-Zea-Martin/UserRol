using System.Net;

namespace UsuariosConRoles.Response
{
    public class ResponseApi<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public ResponseApi()
        {
            Success = true;
            StatusCode = HttpStatusCode.OK;
            ErrorMessage = "";

        }

        public void SetError(string errorMessage, HttpStatusCode statusCode)
        {
            Success = false;
            ErrorMessage = errorMessage;
            StatusCode = statusCode;
        }
    }
}
