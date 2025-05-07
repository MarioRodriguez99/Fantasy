using System.Net;

namespace Fantasy.Frontend.Repositories
{
    public class HttpResponseWrapper<T>//Generico tipo T para envolver cualquier tipo de respuesta
    {
        public HttpResponseWrapper(T? response, bool error, HttpResponseMessage httpResponseMessage)//Constructor de la clase
        {
            Response = response;
            Error = error;
            HttpResponseMessage = httpResponseMessage;
        }

        public T? Response { get; }
        public bool Error { get; }
        public HttpResponseMessage HttpResponseMessage { get; }//Propiedades

        public async Task<string?> GetErrorMessageAsync() //Metodo async devuelve string
        {
            if (!Error)//Si no hay error devuelve null
            {
                return null;
            }

            var statusCode = HttpResponseMessage.StatusCode;//Si hay error se crea variable y se iguala a HttpResponseMessage.StatusCode

            //Preguntas a statusCode
            if (statusCode == HttpStatusCode.NotFound)//Si no lo encuentra
            {
                return "Recurso no encontrado.";
            }
            if (statusCode == HttpStatusCode.BadRequest)//Si devuelve en BadRequest
            {
                return await HttpResponseMessage.Content.ReadAsStringAsync();//Devolver el mensaje del BadRequest
            }
            if (statusCode == HttpStatusCode.Unauthorized)//Si es un Unauthorize, en caso de necesitar estar logueado para realizar la operacion
            {
                return "Tienes que estar logueado para ejecutar esta operación.";
            }
            if (statusCode == HttpStatusCode.Forbidden)//Forbidden en caso de necesitar permisos para realizar la operacion
            {
                return "No tienes permisos para hacer esta operación.";
            }

            return "Ha ocurrido un error inesperado.";
        }
    }
}