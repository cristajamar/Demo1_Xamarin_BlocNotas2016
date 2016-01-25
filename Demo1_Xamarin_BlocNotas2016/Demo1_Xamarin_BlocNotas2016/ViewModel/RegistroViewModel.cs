using System.Collections.ObjectModel;
using System.Windows.Input;
using Demo1_Xamarin_BlocNotas2016.Factorias;
using Demo1_Xamarin_BlocNotas2016.Model;
using Demo1_Xamarin_BlocNotas2016.Service;
using Demo1_Xamarin_BlocNotas2016.Util;
using Demo1_Xamarin_BlocNotas2016.ViewModel.Base;
using Xamarin.Forms;

namespace Demo1_Xamarin_BlocNotas2016.ViewModel
{
    public class RegistroViewModel:GeneralViewModel
    {
        public ICommand cmdAlta { get; set; }
        
        public Usuario Usuario
        {
            get { return _usuario; }
            set { SetProperty(ref _usuario, value); }
        }
        private Usuario _usuario = new Usuario();
        public RegistroViewModel(INavigator navigator, IServicioDatos servicio,Session session) : base(navigator, servicio, session)
        {
            cmdAlta = new Command(GuardarUsuario);
        }

        private async void GuardarUsuario()
        {
            try
            {
                IsBusy = true;
                var r = await _servicio.AddUsuario(_usuario);

                if (r != null)
                {
                    Session["usuario"] = r;
                    await _navigator.PushModalAsync<PrincipalViewModel>(viewModel =>
                    {

                        viewModel.Titulo = "Principal";
                        viewModel.Blocs = new ObservableCollection<Bloc>();
                    });
                    
                }
                else
                {
                    var a = "";
                }
            }
            finally
            {

                IsBusy = false;

            }
        }
    }
}