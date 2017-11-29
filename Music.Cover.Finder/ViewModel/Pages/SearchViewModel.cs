using System;
using Neutronium.MVVMComponents.Relay;

namespace Music.Cover.Finder.ViewModel.Pages
{
    public class SearchViewModel : Vm.Tools.ViewModel
    {
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

        public RelayToogleCommand Search { get; }

        public SearchViewModel()
        {
            Search = new RelayToogleCommand(DoSearch)
            {
                ShouldExecute = false
            };
        }

        private void CheckSearch()
        {
            Search.ShouldExecute = !String.IsNullOrEmpty(Album) && !String.IsNullOrEmpty(Artist);
        }

        private void DoSearch()
        {
            
        }
    }
}
