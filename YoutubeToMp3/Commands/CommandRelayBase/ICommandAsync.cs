using System.Threading.Tasks;
using System.Windows.Input;

namespace YoutubeToMp3
{
    public interface ICommandAsync : ICommand
    {
        Task ExecuteAsync();
        bool CanExecute();
    }
}
