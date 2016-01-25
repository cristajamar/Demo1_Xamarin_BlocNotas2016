using Demo1_Xamarin_BlocNotas2016.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1_Xamarin_BlocNotas2016.Service
{
    /*Lo utilizamos para el manejo de toda la parte Mobile Service*/
    public interface IServicioDatos
    {
        /*Cuando son tareas asincronas no se utiliza la clase Primitiva y siembre devuelven un Task,
        el el caso del Validar,Add y Update devuelve los campos de Usuario, en el caso de Delete un Void y el result de la operacion*/
        
        Task<Usuario> ValidarUsuario(Usuario us);
        Task<Usuario> AddUsuario(Usuario us);
        Task<Usuario> UpdateUsuario(Usuario us);
        Task DeleteUsuario(String us);

        #region Bloc

        Task AddBloc(Bloc bloc);
        Task<List<Bloc>> GetBloc(String usuario); //Recuperas todos los blocks de un usuario
        Task DeleteBloc(Bloc bloc);
        Task UpdateBloc(Bloc bloc);

        #endregion


    }
}
