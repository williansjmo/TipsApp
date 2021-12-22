using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TipsApp.Views
{
    public partial class TipsListPage : ContentPage
    {
        ViewModels.TipsListViewModel viewModel;
        public TipsListPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ViewModels.TipsListViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
}
