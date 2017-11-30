using Music.Cover.Finder.Application.Navigation;
using Music.Cover.Finder.Model;
using Music.Cover.Finder.ViewModel.Library;
using Neutronium.MVVMComponents;
using Neutronium.MVVMComponents.Relay;

namespace Music.Cover.Finder.ViewModel.Pages
{
    public class AuthenticationViewModel : Vm.Tools.ViewModel
    {
        private string _Token;
        public string Token
        {
            get { return _Token; }
            set
            {
                if (!Set(ref _Token, value))
                    return;

                _ApplicationConfiguration.Token = value;
                GoToSearch.ShouldExecute = !string.IsNullOrEmpty(_Token);
            }
        }

        public ISimpleCommand GoToDiscogs { get; } = LinkCommand.GoToDiscogs;
        public ISimpleCommand GoToToken { get; } = LinkCommand.GoToLDiscogsForToken;
        public RelayToogleCommand GoToSearch { get; }

        private readonly IApplicationConfiguration _ApplicationConfiguration;
        private readonly INavigator _Navigator;

        public AuthenticationViewModel(IApplicationConfiguration applicationConfiguration, INavigator navigator)
        {
            _ApplicationConfiguration = applicationConfiguration;
            _Navigator = navigator;
            _Token = _ApplicationConfiguration.Token;
            GoToSearch = new RelayToogleCommand(ToSearch)
            {
                ShouldExecute = !string.IsNullOrEmpty(_Token)
            };
        }

        private void ToSearch()
        {
            _Navigator.Navigate<SearchViewModel>();
        }
    }
}
