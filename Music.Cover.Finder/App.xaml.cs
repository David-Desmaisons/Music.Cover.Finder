using Neutronium.Core.JavascriptFramework;
using Neutronium.JavascriptFramework.Vue;
using Neutronium.WebBrowserEngine.ChromiumFx;
using Neutronium.WPF;

namespace Music.Cover.Finder
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : ChromiumFxWebBrowserApp
    {
        protected override IJavascriptFrameworkManager GetJavascriptUIFrameworkManager()
        {
            return new VueSessionInjector();
        }

        protected override void OnStartUp(IHTMLEngineFactory factory)
        {
            factory.RegisterJavaScriptFrameworkAsDefault(new VueSessionInjectorV2());
            base.OnStartUp(factory);
        }
    }
}
