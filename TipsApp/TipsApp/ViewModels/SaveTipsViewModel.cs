using System;
using System.Threading.Tasks;
using Tips.Domain.Entities;
using Tips.Domain.Interfaces;
using TipsApp.Views;
using Xamarin.Forms;

namespace TipsApp.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class SaveTipsViewModel : BaseViewModel
    {
        private IGenericRepository<Tip> service = DependencyService.Get<IGenericRepository<Tip>>();
        #region Campos
        private Tip tip;
        private int itemId;
        #endregion

        #region Propiedades
        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                if (itemId > 0)
                {
                    Title = "Editar Tips";
                    OnGetTips(itemId); 
                }
                else
                    Title = "Crear Tips";
            }
        }
        
        public Tip Tips
        {
            get=> tip;
            set=> SetProperty(ref tip,value);
        }
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        #endregion

        public SaveTipsViewModel()
        {
            
            Tips = new Tip();
            Tips.CreationDate = DateTime.Now;
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
        }

        #region Funciones
        private async Task<bool> ValidateSave()
        {
            bool _return = false;
            if(string.IsNullOrEmpty(Tips.Title))
            {
                await DisplayAlert("Obligatorio!","El campo titulo es obligatorio.","Ok");
                _return = true;
            }
            if (string.IsNullOrEmpty(Tips.Description))
            {
                await DisplayAlert("Obligatorio!", "El campo descripción es obligatorio.", "Ok");
                _return = true;
            }
            return _return;
        }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            bool result;
            if (await ValidateSave())
                return;

            if (ItemId > 0 )
            {
                result = await service.UpdateAsync(Tips);
                await Shell.Current.GoToAsync("../..");
            }
            else
            {
                result = await service.AddAsync(Tips);
                await Shell.Current.GoToAsync("..");
            }
            
        }

        async void OnGetTips(int id)
        {
            Tips = await service.GetAsync(id);
        }
        #endregion
    }
}
