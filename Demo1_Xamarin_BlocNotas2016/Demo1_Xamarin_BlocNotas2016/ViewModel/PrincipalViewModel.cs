using System.Collections.ObjectModel;
using System.Windows.Input;
using Demo1_Xamarin_BlocNotas2016.Factorias;
using Demo1_Xamarin_BlocNotas2016.Model;
using Demo1_Xamarin_BlocNotas2016.Service;
using Demo1_Xamarin_BlocNotas2016.Util;

namespace Demo1_Xamarin_BlocNotas2016.ViewModel
{
    public class PrincipalViewModel:GeneralViewModel
    {

        //Cada vez que añadimos un elemento nuevo a la lista, lo resfreca de forma inmediata.
        //Implementa el SetPropertyChange

        private ObservableCollection<Bloc> _blocs;
        public ICommand CmdNuevo { get; set; }

        public ObservableCollection<Bloc> Blocs
        {
            get { return _blocs; }
            set { SetProperty(ref _blocs, value); }
        } 
        public PrincipalViewModel(INavigator navigator, IServicioDatos servicio, Session session) : base(navigator, servicio, session)
        {
        }

        private async void NuevoBloc()
        {
            await _navigator.PushAsync<NuevoBlocViewModel>(viewModel =>
            {
                viewModel.Titulo = "Nuevo Bloc";
                viewModel.Blocs = Blocs;

            });
        }
    }
}