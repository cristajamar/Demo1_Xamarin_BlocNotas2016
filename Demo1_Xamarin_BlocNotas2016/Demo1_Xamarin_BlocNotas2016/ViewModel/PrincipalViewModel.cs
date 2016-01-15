using Demo1_Xamarin_BlocNotas2016.Factorias;
using Demo1_Xamarin_BlocNotas2016.Service;

namespace Demo1_Xamarin_BlocNotas2016.ViewModel
{
    public class PrincipalViewModel:GeneralViewModel
    {
        public PrincipalViewModel(INavigator navigator, IServicioDatos servicio) : base(navigator, servicio)
        {
        }
    }
}