using SaveMyMoney.Helpers;
using SaveMyMoney.Models;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveMyMoney
{
    public partial class App : Application
    {
        public static string FolderPath { get; private set; }
        public static Notes DataBase { get; private set; }

        public static Groups MoneyGroups { get; private set; }
        public static string Language {get; set;}

        public App()
        {
            InitializeComponent();
            FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            var filename = Path.Combine(FolderPath, AppSettings.DATABASE_FILENAME);
            DataBase = (Notes)FileWorker.LoadDataFromFile(filename);
            filename = Path.Combine(FolderPath, AppSettings.GROUPS_FILENAME);
            MoneyGroups = (Groups)FileWorker.LoadDataFromFile(filename);
            filename = Path.Combine(FolderPath, AppSettings.LANGUAGE_FILENAME);
            if (DataBase == null)
            {
                DataBase = new Notes();
            }
            if (MoneyGroups == null)
            {
                MoneyGroups = new Groups();
            }

            filename = Path.Combine(App.FolderPath, AppSettings.LANGUAGE_FILENAME);
            if (File.Exists(filename))
            {
                Language = FileWorker.ReadTextFromFile(filename);
                LangSettings.InstanceOf.SetLanguage();
            }
            else
            {
                Language = "English";
                LangSettings.InstanceOf.SetLanguage();
                FileWorker.WriteTextToFile("English",filename);
            }
            MainPage = new NavigationPage(new NotesPage());
        }
    }
}
