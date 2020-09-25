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

            var notes = GetWeekNotes();
            listView.ItemsSource = notes
                .OrderByDescending(d => d.Date)
                .ToList();

            TotalBalance = CalculateTotalBalance();
            LbTotalBalance.Text = "Total Balance:";
            LbTotalBalanceAmount.Text = TotalBalance.ToString();
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

        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NoteEntryPage
            {
                BindingContext = new Note()
            });
        }

        async void OnCostNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NoteEntryPage
            {
                BindingContext = new Note(true)
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
            await Navigation.PushAsync(new ReportPage
            {
                //BindingContext = new Note()
            });
        }
    }
}