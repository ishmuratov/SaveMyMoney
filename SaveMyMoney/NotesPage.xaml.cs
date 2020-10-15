using SaveMyMoney.Helpers;
using SaveMyMoney.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveMyMoney
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesPage : ContentPage
    {
        public static int TotalBalance { get; private set; }
        public NotesPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DisplayNotes();
            DisplayTotalBalance();
            DisplayLanguageIcon();
        }

        private void DisplayNotes()
        {
            var notes = GetWeekNotes();
            listView.ItemsSource = notes
                .OrderByDescending(d => d.Date)
                .ToList();
        }
        private List<Note> GetWeekNotes()
        {
            List<Note> result = new List<Note>();
            DateTime lastDate = DateTime.Now.AddDays(-7);
            foreach (Note anyNote in App.DataBase.NotesList)
            {
                if (anyNote.Date > lastDate)
                {
                    result.Add(anyNote);
                }
            }
            return result;
        }

        private void DisplayTotalBalance()
        {
            TotalBalance = CalculateTotalBalance();
            LbTotalBalance.Text = LangSettings.InstanceOf.TOTAL_BALANCE + ":";
            LbTotalBalanceAmount.Text = TotalBalance.ToString();
        }
        private int CalculateTotalBalance()
        {
            int result = 0;
            foreach (Note anyNote in App.DataBase.NotesList)
            {
                if (anyNote.isCost)
                    result -= anyNote.Amount;
                else
                    result += anyNote.Amount;
            }
            return result;
        }

        private void DisplayLanguageIcon()
        {
            tbReport.Text = LangSettings.InstanceOf.REPORT;

            if (App.Language.Equals("English"))
            {
                imageLang.Source = "english_small.png";
            }
            else
            {
                imageLang.Source = "russian_small.png";
            }
        }
        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NoteEntryPage
            {
                BindingContext = new Note(),
                BackgroundColor = Color.AliceBlue
            });
        }

        async void OnCostNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NoteEntryPage
            {
                BindingContext = new Note(true),
                BackgroundColor = Color.AliceBlue
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new NoteEntryPage
                {
                    BindingContext = e.SelectedItem as Note
                });
            }
        }

        async void OnReportClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReportPage());
        }

        private void AboutClicked(object sender, EventArgs e)
        {
            DisplayAlert("Information", "Version: 1.0.0.", "OK");
        }

        private void SetLanguageClicked(object sender, EventArgs e)
        {
            var filename = Path.Combine(App.FolderPath, AppSettings.LANGUAGE_FILENAME);
            if (App.Language.Equals("Russian"))
            {
                App.Language = "English";
                LangSettings.InstanceOf.SetLanguage();
                imageLang.Source = "english_small.png";
                FileWorker.WriteTextToFile("English",filename);
            }
            else
            {
                App.Language = "Russian";
                LangSettings.InstanceOf.SetLanguage();
                imageLang.Source = "russian_small.png";
                FileWorker.WriteTextToFile("Russian", filename);
            }
            SetTextFromNewLanguage();
        }

        private void SetTextFromNewLanguage()
        {
            LbTotalBalance.Text = LangSettings.InstanceOf.TOTAL_BALANCE + ":";
            tbReport.Text = LangSettings.InstanceOf.REPORT;
        }
    }
}