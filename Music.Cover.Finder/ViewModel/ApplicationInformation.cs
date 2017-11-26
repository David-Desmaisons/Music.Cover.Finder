using System.Reflection;

namespace Music.Cover.Finder.ViewModel
{
    public class ApplicationInformation
    {
        public string Name => "Music Cover Finder";

        public string Version => Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public string MadeBy => "David Desmaisons";

        public int Year => 2017;
    }
}
