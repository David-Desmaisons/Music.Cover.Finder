using System.Threading.Tasks;

namespace Music.Cover.Finder.Application.WindowServices
{
    public interface IMessageBox
    {
        Task<bool> ShowMessage(ConfirmationMessage confirmationMessage);

        void ShowInformation(MessageInformation messageInformation);
    }
}