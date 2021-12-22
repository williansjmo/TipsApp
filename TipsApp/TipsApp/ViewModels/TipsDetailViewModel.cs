using System;
using Tips.Domain.Entities;
using Tips.Domain.Interfaces;
using TipsApp.Views;
using Xamarin.Forms;

namespace TipsApp.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class TipsDetailViewModel : BaseViewModel
    {
        #region Campos
        private IGenericRepository<Tip> service = DependencyService.Get<IGenericRepository<Tip>>();
        private int itemId;
        private Tip tip;
        #endregion

        #region Propiedades
        public Command EditTipsCommand { get; }
        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                OnDetail(value);
            }
        }
        public Tip Tips
        {
            get => tip;
            set => SetProperty(ref tip, value);
        }
        #endregion

        public TipsDetailViewModel()
        {
            EditTipsCommand = new Command(OnEdit);
        }

        #region Funciones
        async void OnEdit()
        {
            await Shell.Current.GoToAsync($"{nameof(TipsSavePage)}?{nameof(SaveTipsViewModel.ItemId)}={Tips.TipId}");
        }

        async void OnDetail(int id)
        {
            Tips = await service.GetAsync(id);
        }
        #endregion
    }
}
