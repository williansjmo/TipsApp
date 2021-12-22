using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Tips.Infrastructure.Persistence;
using System.IO;
using Tips.Domain.Interfaces;
using Tips.Domain.Services;
using Tips.Domain.Entities;

namespace TipsApp
{
    public partial class App : Application
    {
        //private static DatabaseContext context;

        //public static DatabaseContext Context
        //{
        //    get
        //    {
        //        if (context == null)
        //        {
        //            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TipsDB.db3");
        //            context = new DatabaseContext(dbPath);
        //        }

        //        return context;
        //    }
        //}
        public App()
        {
            InitializeComponent();
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TipsDB.db3");
            var databaseContext = new DatabaseContext(dbPath);
            DependencyService.RegisterSingleton<IDatabaseContext>(databaseContext);
            DependencyService.RegisterSingleton <IGenericRepository<Tip>> (new TipsService(databaseContext));
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
