using System;
using Xamarin.Forms;

namespace MvvmLibrary.Factorias
{
    public class PageProxy:IPage
    {
        /*Recibe una funcion que lo que hara será devolvernos de la pagina actual, el contexto de navegación*/
        private readonly Func<Page> _page;


        public PageProxy(Func<Page> page)
        {
            _page = page;
        }
        public INavigation Navigation {get { return _page().Navigation; } }


    }
}