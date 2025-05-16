using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasy.Shared.Responses
{
    public class ActionResponse<T> //Clase generica
    {
        public bool WasSuccess { get; set; }//Accion ejecutada exitosa o no
        public string? Message { get; set; }// Si da error me lanza el mensaje de error
        public T? Result { get; set; }// ME devuelve el resultado cuando sea exitoso
    }
}