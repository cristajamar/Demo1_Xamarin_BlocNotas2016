using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo1_Xamarin_BlocNotas2016.Model;

namespace Demo1_Xamarin_BlocNotas2016.Util
{
    /*Esta clase la creamos para almacenar datos sensibles de para la aplicación,
    que no queremos que en caso de pirateo tengan un facil acceso a ella. Como por ejemplo si lo incluyeramos en un XML*/
    /*Es una especie de web.config, pero que no es legible si la aplicación esta compilada*/
    public static class Cadenas
    {
        public static String UrlServicio = "https://blocnotas2016.azure-mobile.net/";
        public static String TokenServicio = "etRjpbWBPhpGQTmyamljFYheMNOmUS50";


    /*Para sacar la url y el valor del token, en el Mobile Service de Azure
    Panel: url de la derecha
    Clave token: el la parte inferior, administrar claves*/
    }
}
