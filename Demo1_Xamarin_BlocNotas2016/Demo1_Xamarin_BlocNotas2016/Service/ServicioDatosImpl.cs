using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo1_Xamarin_BlocNotas2016.Model;
using Microsoft.WindowsAzure.MobileServices;
using Demo1_Xamarin_BlocNotas2016.Util;

namespace Demo1_Xamarin_BlocNotas2016.Service
{
    public class ServicioDatosImpl : IServicioDatos
    {
        private MobileServiceClient cliente;

        public ServicioDatosImpl()
        {
            /* MobileServiceClient: Es la clase que da Microsfoct para que podamos implemntar Azure*/
            cliente = new MobileServiceClient(Cadenas.UrlServicio, Cadenas.TokenServicio);
        }

        public async Task<Usuario> AddUsuario(Usuario us)
        {
            var tabla = cliente.GetTable<Usuario>();
            var data = await tabla.CreateQuery().Where(o => o.Login == us.Login).ToListAsync();
            if (data.Count > 0)
                throw new Exception("Usuario ya registrado");

            /*InsertAsync devuelve un void, es un Task vacio, por eso incluimos el try-catch*/
            try 
            {
                await tabla.InsertAsync(us);
            }
            catch (Exception e)
            {
                throw new Exception("Error al registrar usuario");
            }

            return us;
        }

        public Task DeleteUsuario(string us)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> UpdateUsuario(Usuario us)
        {
            throw new NotImplementedException();
        }

        /*Para utlizar el await hay que incluir en la clase ASYNC*/
        public async Task<Usuario> ValidarUsuario(Usuario us)
        {
            /* cliente.GetTable: Devuelve la referencia de la tabla Usuario*/
            var tabla = cliente.GetTable<Usuario>();
            /* tabla.CreateQuery nos deja utilizar cualquier expresión de LINQ
            ToListAsync devuelve un Task de la Consulta, pero al hacerle el await ya nos devuelve los datos
            como un objeto Usuario, nos devuelve los datos deserializados*/
            var data = await tabla.CreateQuery().Where(o => o.Login == us.Login && o.Password == us.Password).ToListAsync();
            if (data.Count == 0)
            {
                return null;
            }
                return data[0];
        }
    }
}
