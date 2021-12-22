using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace TipsApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        #endregion

        #region DisplayAlert
        public async Task<bool> DisplayAlert(string title, string message, string accept, string cancel, FlowDirection flowDirection)
        {
            return await Application.Current.MainPage.DisplayAlert(title,message,accept,cancel,flowDirection);
        }
        public async Task DisplayAlert(string title, string message, string cancel, FlowDirection flowDirection)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, null, cancel, flowDirection);
        }
        public Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            return DisplayAlert(title, message, accept, cancel, FlowDirection.MatchParent);
        }
        public async Task<bool> DisplayAlert(string title, string message, string cancel)
        {
            return await DisplayAlert(title, message, null, cancel, FlowDirection.MatchParent);
        }
        #endregion
    }
}
