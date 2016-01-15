using System;
using System.Windows.Input;
using Demo1_Xamarin_BlocNotas2016.Factorias;
using Demo1_Xamarin_BlocNotas2016.Model;
using Demo1_Xamarin_BlocNotas2016.Service;
using Xamarin.Forms;

namespace Demo1_Xamarin_BlocNotas2016.ViewModel
{
    public class LoginViewModel:GeneralViewModel
    {
        /*Manejamos la referencia al navegador y al servicio de datos*/

        private ICommand cmdLogin;
        private ICommand cmdAlta;

        public LoginViewModel(INavigator navigator, IServicioDatos servicio) : base(navigator, servicio)
        {
            cmdLogin = new Command(IniciarSesion);
            cmdAlta = new Command(NuevoUsuario);
        }

        public string TituloIniciar { get { return "Iniciar sesión:"; } }
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
                    await _navigator.PopToRootAsync();
                    await _navigator.PushAsync<PrincipalViewModel>(viewModel =>
                    {
                        Titulo = "Pantalla principal"; //le fija propiedades a la vista antes de que cargue, esto lo hace atraves del action
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
            //await _navigator.PopToRootAsync();
            await _navigator.PushModalAsync<RegistroViewModel>(viewModel =>
            {
                Titulo = "Nuevo usuario"; //le fija propiedades a la vista antes de que cargue, esto lo hace atraves del action
            });
        }
    }
}