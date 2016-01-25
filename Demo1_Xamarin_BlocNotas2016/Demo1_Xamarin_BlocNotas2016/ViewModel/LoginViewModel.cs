using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Demo1_Xamarin_BlocNotas2016.Factorias;
using Demo1_Xamarin_BlocNotas2016.Model;
using Demo1_Xamarin_BlocNotas2016.Service;
using Demo1_Xamarin_BlocNotas2016.Util;
using Xamarin.Forms;

namespace Demo1_Xamarin_BlocNotas2016.ViewModel
{
    public class LoginViewModel:GeneralViewModel
    {
        /*Manejamos la referencia al navegador y al servicio de datos*/

        public ICommand cmdLogin { get; set; }
        public ICommand cmdAlta { get; set; }

        public LoginViewModel(INavigator navigator, IServicioDatos servicio, Session session) : base(navigator, servicio, session)
        {
            cmdLogin = new Command(IniciarSesion);
            cmdAlta = new Command(NuevoUsuario);
            Titulo = "Login";
        }

        public string TituloIniciar { get { return "Iniciar sesión"; } }
        public string TituloRegistro { get { return "Nuevo usuario"; } }
        public string TituloLogin { get { return "Nombre de usuario"; } }
        public string TituloPassword { get { return "Contraseña"; } }

        public Usuario _usuario=new Usuario();

        public Usuario Usuario
        {
            get { return _usuario; }
            set { SetProperty(ref _usuario, value); }
        }

        private async void IniciarSesion()
        {
     
            try
            {
                IsBusy = true;
                var us = await _servicio.ValidarUsuario(_usuario);

                if (us != null)
                {
                    Session["usuario"] = us; //En el campo usuario de la sesión guarda el valor de us
                    var blocs = await _servicio.GetBloc(us.Id);
                    

                    await _navigator.PopToRootAsync();
                    await _navigator.PushAsync<PrincipalViewModel>(viewModel =>
                    {
                        viewModel.Titulo = "Principal"; //le fija propiedades a la vista antes de que cargue, esto lo hace atraves del action
                        viewModel.Blocs = new ObservableCollection<Bloc>(blocs); //Tenemos que inicializarlo con el conjunto de datos
                    });
                }
                else
                {
                    var xxx = "";
                }

                //TODO: Aqui navegariamos a la pantalla principal o dariamos error
            }
            finally
            {

                IsBusy = false;

            }
        }

        private async void NuevoUsuario()
        {
            await _navigator.PopToRootAsync();
            await _navigator.PushModalAsync<RegistroViewModel>(viewModel =>
            {
                viewModel.Titulo = "Nuevo usuario"; //le fija propiedades a la vista antes de que cargue, esto lo hace atraves del action
            });
        }
    }
}