using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TollStations.Commands
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync();
        bool CanExecute();
    }
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}