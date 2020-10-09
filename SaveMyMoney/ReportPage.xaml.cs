using SaveMyMoney.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entry = Microcharts.Entry;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp;
using Microcharts;
using Microcharts.Forms;
using SaveMyMoney.Helpers;

namespace SaveMyMoney
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportPage : ContentPage
    {
        List<Note> monthlyNotes = new List<Note>();
        public ReportPage()
        {
            InitializeComponent();
            btDatails.IsEnabled = false;
        }

        protected override void OnAppearing()
        {
            AddMonthesToPicker();
            AddModeToPicker();
        }

        private void AddMonthesToPicker()
        {
            pickerMonth.Items.Add("January");
            pickerMonth.Items.Add("February");
            pickerMonth.Items.Add("March");
            pickerMonth.Items.Add("Aprel");
            pickerMonth.Items.Add("May");
            pickerMonth.Items.Add("June");
            pickerMonth.Items.Add("July");
            pickerMonth.Items.Add("August");
            pickerMonth.Items.Add("September");
            pickerMonth.Items.Add("October");
            pickerMonth.Items.Add("November");
            pickerMonth.Items.Add("December");
        }

        private void AddModeToPicker()
        {
            pickerMode.Items.Add("All costs");
            pickerMode.Items.Add("Total Income/Cost");
        }

        private void OnMonthChanged(object sender, EventArgs e)
        {
            int selectedMonth = pickerMonth.SelectedIndex + 1;
            int totalCost = GetTotalCost(selectedMonth);
            int totalIncome = GetTotalIncome(selectedMonth);
            lbTotalCost.Text = $"Total cost: {totalCost}";
            lbTotalIncome.Text = $"Total income: {totalIncome}";
            btDatails.Text = "Details ->";

            // Cost Entries

            var costEnties = new List<Entry>();
            monthlyNotes = GetNotesPerMonth(selectedMonth);

            foreach (Group anyGroup in App.MoneyGroups.GroupList)
            {
                if (anyGroup.isCost)
                {
                    int totalAmount = 0;
                    foreach (Note anyNote in monthlyNotes)
                    {
                        if (anyNote.MoneyGroup != null && anyNote.MoneyGroup.Name.Equals(anyGroup.Name))
                        {
                            totalAmount += anyNote.Amount;
                        }
                    }
                    Entry newEntry = new Entry(totalAmount)
                    {
                        Color = SKColor.Parse("#FF1943"),
                        Label = anyGroup.Name,
                        ValueLabel = totalAmount.ToString()
                    };
                    costEnties.Add(newEntry);
                }
            }

            Chart4.Chart = new BarChart() { Entries = costEnties };
            pickerMode.SelectedIndex = 0;
            btDatails.IsEnabled = true;
        }

        async private void OnDatailsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetailsPage(monthlyNotes));
        }

        private int GetTotalCost(int month)
        {
            int result = 0;
            foreach (Note anyNote in App.DataBase.NotesList)
            {
                if (anyNote.Date.Month == month && anyNote.isCost)
                {
                    result += anyNote.Amount;
                }
            }
            return result;
        }

        private int GetTotalIncome(int month)
        {
            int result = 0;
            foreach (Note anyNote in App.DataBase.NotesList)
            {
                if (anyNote.Date.Month == month && !anyNote.isCost)
                {
                    result += anyNote.Amount;
                }
            }
            return result;
        }

        private List<Note> GetNotesPerMonth(int monthNumber)
        {
            List<Note> notes = new List<Note>();
            foreach (Note anyNote in App.DataBase.NotesList)
            {
                if (anyNote.Date.Month == monthNumber)
                {
                    notes.Add(anyNote);
                }
            }
            return notes;
        }

        private void OnModeChanged(object sender, EventArgs e)
        {
            // TODO
            int selectedMonth = pickerMonth.SelectedIndex + 1;
            int selectedGroupIndex = pickerMode.SelectedIndex;
            int totalCost = GetTotalCost(selectedMonth);
            int totalIncome = GetTotalIncome(selectedMonth);

            if (pickerMode.Items[selectedGroupIndex] == "Total Income/Cost")
            {
                GetTotalIncomeCostGraph(totalIncome, totalCost);
            }
            if (pickerMode.Items[selectedGroupIndex] == "All costs")
            {
                OnMonthChanged(sender, e);
            }
        }

        private void GetTotalIncomeCostGraph(int totalIncome, int totalCost)
        {
            var entries = new List<Entry>
                {
                    new Entry(totalCost)
                        {
                            Color=SKColor.Parse("#FF1943"),
                            Label ="TotalCost",
                            ValueLabel =  totalCost.ToString()
                        },

                    new Entry(totalIncome)
                        {
                            Color = SKColor.Parse("#36D746"),
                            Label = "TotalIncome",
                            ValueLabel = totalIncome.ToString()
                        }
                };
            Chart4.Chart = new BarChart() { Entries = entries };
        }
    }
}