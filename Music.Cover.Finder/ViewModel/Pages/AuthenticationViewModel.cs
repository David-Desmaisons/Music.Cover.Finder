using System;
using System.Diagnostics;
using Music.Cover.Finder.Application.Navigation;
using Music.Cover.Finder.Application.WindowServices;
using Music.Cover.Finder.Model;
using Neutronium.MVVMComponents;
using Neutronium.MVVMComponents.Relay;

namespace Music.Cover.Finder.ViewModel.Pages
{
    public class AuthenticationViewModel : Vm.Tools.ViewModel
    {
        private const string LinkForToken = "https://www.discogs.com/settings/developers";
        private const string LinkDiscogs = "https://www.discogs.com/";

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

        public ISimpleCommand GoToDiscogs { get; }
        public ISimpleCommand GoToToken { get; }
        public RelayToogleCommand GoToSearch { get; }

        private readonly IApplicationConfiguration _ApplicationConfiguration;
        private readonly INavigator _Navigator;

        public AuthenticationViewModel(IApplicationConfiguration applicationConfiguration, INavigator navigator)
        {
            _ApplicationConfiguration = applicationConfiguration;
            _Navigator = navigator;
            _Token = _ApplicationConfiguration.Token;
            GoToDiscogs = new RelaySimpleCommand(ToDiscogs);
            GoToToken = new RelaySimpleCommand(ToToken);
            GoToSearch = new RelayToogleCommand(ToSearch)
            {
                ShouldExecute = !string.IsNullOrEmpty(_Token)
            };
        }

        private void ToSearch()
        {
            _Navigator.Navigate<SearchViewModel>();
        }

        private static void ToToken()
        {
            Process.Start(LinkForToken);
        }

        private static void ToDiscogs()
        {
            Process.Start(LinkDiscogs);
        }
    }
}
