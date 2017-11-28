using System.Diagnostics;
using Neutronium.MVVMComponents;
using Neutronium.MVVMComponents.Relay;

namespace Music.Cover.Finder.ViewModel.Pages
{
    public class AboutViewModel
    {
        private const string LinkForNeutronium = "https://github.com/NeutroniumCore/Neutronium";
        private const string LinkForProduct = "https://github.com/David-Desmaisons/Music.Cover.Finder";

        public ApplicationInformation Information { get; } = new ApplicationInformation();

        public ISimpleCommand GoToProduct { get; }
        public ISimpleCommand GoToNeutronium { get; }

        public string[] Descriptions { get; } =
        {
            Resource.About
        };

        public AboutViewModel() 
        {
            GoToProduct = new RelaySimpleCommand(ToProduct);
            GoToNeutronium = new RelaySimpleCommand(ToNeutronium);
        }

        private static void ToProduct() 
        {
            Process.Start(LinkForProduct);
        }

        private static void ToNeutronium() 
        {
            Process.Start(LinkForNeutronium);
        }
    }
}
