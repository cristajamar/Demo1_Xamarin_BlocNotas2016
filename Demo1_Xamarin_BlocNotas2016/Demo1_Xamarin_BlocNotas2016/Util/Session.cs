using System;
using System.Collections.Generic;

namespace Demo1_Xamarin_BlocNotas2016.Util
{
    public class Session
    {

        //Simula la cookie de una web, aqui se almacenarán los datos de sesión del usuario.
        private Dictionary<String, Object> _session = new Dictionary<String, Object>();
        //Se crea un indice para el diccionario, con un indexer
        public object this[String index]
        {
            get { return _session[index]; }

            set { _session[index] = value; }

        }
    }
}