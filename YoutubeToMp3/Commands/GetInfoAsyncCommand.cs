using System.Threading.Tasks;

namespace YoutubeToMp3
{
    public class GetInfoAsyncCommand : CommandBaseAsync
    {
        private readonly MainViewModel mainViewModel;

        public GetInfoAsyncCommand(MainViewModel vm)
        {
            mainViewModel = vm;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            await mainViewModel.GetInfoAsync();
        }
    }
}
