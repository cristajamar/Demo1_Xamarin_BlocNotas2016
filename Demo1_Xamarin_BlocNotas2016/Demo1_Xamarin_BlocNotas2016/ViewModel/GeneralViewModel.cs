using Demo1_Xamarin_BlocNotas2016.Factorias;
using Demo1_Xamarin_BlocNotas2016.Service;
using Demo1_Xamarin_BlocNotas2016.ViewModel.Base;
using Xamarin.Forms;

namespace Demo1_Xamarin_BlocNotas2016.ViewModel
{
    public class GeneralViewModel :ViewModelBase
    {
        protected INavigator _navigator;
        protected IServicioDatos _servicio;

        public GeneralViewModel(INavigator navigator, IServicioDatos servicio)
        {
            _navigator = navigator;
            _servicio = servicio;
        }
    }
}