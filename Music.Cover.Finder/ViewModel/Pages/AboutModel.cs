using Music.Cover.Finder.ViewModel.Library;
using Neutronium.MVVMComponents;

namespace Music.Cover.Finder.ViewModel.Pages
{
    public class AboutViewModel
    {
        public ApplicationInformation Information { get; } = new ApplicationInformation();

        public ISimpleCommand GoToProduct { get; } = LinkCommand.GoToProduct;
        public ISimpleCommand GoToNeutronium { get; } = LinkCommand.GoToNeutronium;
        public ISimpleCommand GoToDiscogs { get; } = LinkCommand.GoToDiscogs;

        public string[] Descriptions { get; } =
        {
            Resource.About
        };
    }
}
