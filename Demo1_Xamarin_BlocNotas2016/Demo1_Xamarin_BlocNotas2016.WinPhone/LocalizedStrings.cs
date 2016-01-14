using Demo1_Xamarin_BlocNotas2016.WinPhone.Resources;

namespace Demo1_Xamarin_BlocNotas2016.WinPhone
{
    /// <summary>
    /// Provides access to string resources.
    /// </summary>
    public class LocalizedStrings
    {
        private static AppResources _localizedResources = new AppResources();

        public AppResources LocalizedResources { get { return _localizedResources; } }
    }
}
