using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Threading;
using DiscogsClient.Data.Query;
using DiscogsClient.Data.Result;
using Music.Cover.Finder.Model.Discogs;
using Neutronium.MVVMComponents.Relay;

namespace Music.Cover.Finder.ViewModel.Pages
{
    public class SearchViewModel : Vm.Tools.ViewModel
    {
        private bool _Running;
        public bool Running
        {
            get { return _Running; }
            set
            {
                if (Set(ref _Running, value))
                    CheckSearch();
            }
        }

        private bool _NothingFound;
        public bool NothingFound
        {
            get { return _NothingFound; }
            set { Set(ref _NothingFound, value); }
        }

        private string _Album;
        public string Album
        {
            get { return _Album; }
            set
            {
                if (Set(ref _Album, value))
                    CheckSearch();
            }
        }

        private string _Artist;
        public string Artist
        {
            get { return _Artist; }
            set
            {
                if (Set(ref _Artist, value))
                    CheckSearch();
            }
        }

        public ObservableCollection<DiscogsSearchResult> Results { get; } = new ObservableCollection<DiscogsSearchResult>();

        public RelayToogleCommand Search { get; }
        public RelayToogleCommand Cancel { get; }

        private readonly IDiscogsClientProvider _DiscogsClientProvider;

        public SearchViewModel(IDiscogsClientProvider discogsClientProvider)
        {
            _DiscogsClientProvider = discogsClientProvider;
            Search = new RelayToogleCommand(DoSearch)
            {
                ShouldExecute = false
            };
            Cancel = new RelayToogleCommand(DoCancel);
        }

        private void DoCancel()
        {
            _CancellationTokenSource?.Cancel();
            _CancellationTokenSource = null;
        }

        private void CheckSearch()
        {
            Search.ShouldExecute = !String.IsNullOrEmpty(Album) && !String.IsNullOrEmpty(Artist) && !Running;
            Cancel.ShouldExecute = Running;
        } 

        private CancellationTokenSource _CancellationTokenSource;
        private void DoSearch()
        {
            Running = true;
            NothingFound = false;
            Results.Clear();
            _CancellationTokenSource = new CancellationTokenSource();
            var client = _DiscogsClientProvider.GetDiscogsClient();
            var search = new DiscogsSearch
            {
                artist = Artist,
                release_title = Album
            };
            client.Search(search).ObserveOn(SynchronizationContext.Current).Subscribe(OnResult, OnEnd, _CancellationTokenSource.Token);
        }

        private void OnResult(DiscogsSearchResult result)
        {
            Results.Add(result);
        }

        public void OnEnd()
        {
            Running = false;
            NothingFound = Results.Count == 0;
        }
    }
}
