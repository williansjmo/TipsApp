

using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Tips.Domain.Entities;
using Tips.Domain.Interfaces;
using TipsApp.Views;
using Xamarin.Forms;

namespace TipsApp.ViewModels
{
    
    public class TipsListViewModel : BaseViewModel
    {
        #region Campos
        private Tip _selectedItem;
        private IGenericRepository<Tip> service = DependencyService.Get<IGenericRepository<Tip>>();
        #endregion

        #region Propiedades
        public ObservableCollection<Tip> Items { get; }
        public Command LoadTipsCommand { get; }
        public Command AddTipsCommand { get; }
        public Command DeleteTipsCommand { get; }
        public Command DetailTipsCommand { get; }
        public Tip SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }
        #endregion


        public TipsListViewModel()
        {
            OnAppearing();
            Items = new ObservableCollection<Tip>();
            AddTipsCommand = new Command(OnAddTips);
            LoadTipsCommand = new Command(async () => await ExecuteLoadTipsCommand());
            DeleteTipsCommand = new Command<Tip>(OnDeleteSelected);
            DetailTipsCommand = new Command<Tip>(OnItemSelected);
        }

        #region Funciones
        async Task ExecuteLoadTipsCommand()
        {
            OnAppearing();
            try
            {
                Items.Clear();
                var entities = await service.GetAllAsync();
                entities.OrderBy(o=> o.CreationDate.Date).ToList().ForEach(f =>
                {
                    Items.Add(f);
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void OnAddTips(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(TipsSavePage)}?{nameof(SaveTipsViewModel.ItemId)}={0}");
        }

        async void OnDeleteSelected(Tip item)
        {
            if (item == null)
                return;
            bool answer = await DisplayAlert("Eliminar.", $"¿Esta seguro de eliminar {item.Title}?", "Si", "No");

            if (answer)
                await service.DeleteAsync(item.TipId);

            OnAppearing();
        }
        async void OnItemSelected(Tip item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(TipsDetailPage)}?{nameof(TipsDetailViewModel.ItemId)}={item.TipId}");
        }
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }
        #endregion
    }
}
