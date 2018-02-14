using System;

namespace CityMap.Services
{
    public interface IDialogService
    {
        void ShowAlert(string title, string message);
    }

    public class DialogService : IDialogService
    {
        private readonly Action<string, string> _alertDelegate;

        public DialogService(Action<string, string> alertDelegate)
        {
            _alertDelegate = alertDelegate;
        }

        public void ShowAlert(string title, string message)
        {
            _alertDelegate(title, message);
        }
    }
}
