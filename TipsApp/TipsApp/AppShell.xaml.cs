using System;
using System.Collections.Generic;
using TipsApp.ViewModels;
using TipsApp.Views;
using Xamarin.Forms;

namespace TipsApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TipsListPage), typeof(TipsListPage));
            Routing.RegisterRoute(nameof(TipsDetailPage), typeof(TipsDetailPage));
            Routing.RegisterRoute(nameof(TipsSavePage), typeof(TipsSavePage));
        }

    }
}
