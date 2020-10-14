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
        int Year = DateTime.Now.Year;
        List<Note> monthlyNotes = new List<Note>();
        public ReportPage()
        {
            InitializeComponent();
            LoadDefaultValues();
            
        }

        private void LoadDefaultValues()
        {
            AddMonthesToPicker();
            AddModeToPicker();
            AddYearsToPicker();
            pickerMonth.Title = LangSettings.InstanceOf.CHOOSE_MONTH;
            pickerMode.Title = LangSettings.InstanceOf.CHOOSE_MODE;
            pickerYear.Title = DateTime.Now.Year.ToString();
            lbTotalCost.Text = LangSettings.InstanceOf.TOTAL_COST + ": 0";
            lbTotalIncome.Text = LangSettings.InstanceOf.TOTAL_INCOME + ": 0";
            btDatails.IsVisible = false;
        }

        private void AddMonthesToPicker()
        {
            pickerMonth.Items.Add(LangSettings.InstanceOf.JENUARY);
            pickerMonth.Items.Add(LangSettings.InstanceOf.FEBRUARY);
            pickerMonth.Items.Add(LangSettings.InstanceOf.MARCH);
            pickerMonth.Items.Add(LangSettings.InstanceOf.APRIL);
            pickerMonth.Items.Add(LangSettings.InstanceOf.MAY);
            pickerMonth.Items.Add(LangSettings.InstanceOf.JUNE);
            pickerMonth.Items.Add(LangSettings.InstanceOf.JULY);
            pickerMonth.Items.Add(LangSettings.InstanceOf.AUGUST);
            pickerMonth.Items.Add(LangSettings.InstanceOf.SEPTEMBER);
            pickerMonth.Items.Add(LangSettings.InstanceOf.OCTOBER);
            pickerMonth.Items.Add(LangSettings.InstanceOf.NOVEMBER);
            pickerMonth.Items.Add(LangSettings.InstanceOf.DECEMBER);
        }

        private void AddModeToPicker()
        {
            pickerMode.Items.Add(LangSettings.InstanceOf.ALL_COSTS);
            pickerMode.Items.Add(LangSettings.InstanceOf.TOTAL_INCOME_COST);
        }

        private void AddYearsToPicker()
        {
            pickerYear.Items.Add((DateTime.Now.Year - 3).ToString());
            pickerYear.Items.Add((DateTime.Now.Year - 2).ToString());
            pickerYear.Items.Add((DateTime.Now.Year - 1).ToString());
            pickerYear.Items.Add(DateTime.Now.Year.ToString());
            pickerYear.Items.Add((DateTime.Now.Year + 1).ToString());
            pickerYear.Items.Add((DateTime.Now.Year + 2).ToString());
            pickerYear.Items.Add((DateTime.Now.Year + 3).ToString());
        }

        private void OnMonthChanged(object sender, EventArgs e)
        {
            int selectedMonth = pickerMonth.SelectedIndex + 1;
            int totalCost = GetTotalCost(selectedMonth);
            int totalIncome = GetTotalIncome(selectedMonth);
            if (totalCost > totalIncome)
            {
                frTotal.BackgroundColor = Color.FromHex("#f6d2ce");
            }
            else
            {
                frTotal.BackgroundColor = Color.FromHex("#d0f6ce");
            }
            lbTotalCost.Text = $"{LangSettings.InstanceOf.TOTAL_COST}: {totalCost}";
            lbTotalIncome.Text = $"{LangSettings.InstanceOf.TOTAL_INCOME}: {totalIncome}";
            btDatails.Text = LangSettings.InstanceOf.DETAILS;

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

            ChartBar.Chart = new BarChart() { Entries = costEnties};
            pickerMode.SelectedIndex = 0;
            btDatails.IsVisible = true;
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
                if (anyNote.Date.Year == Year && anyNote.Date.Month == month && anyNote.isCost)
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
                if (anyNote.Date.Year == Year && anyNote.Date.Month == month && !anyNote.isCost)
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
                if (anyNote.Date.Year == Year && anyNote.Date.Month == monthNumber)
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

            if (pickerMode.Items[selectedGroupIndex].Equals(LangSettings.InstanceOf.TOTAL_INCOME_COST))
            {
                GetTotalIncomeCostGraph(totalIncome, totalCost);
            }
            if (pickerMode.Items[selectedGroupIndex].Equals(LangSettings.InstanceOf.ALL_COSTS))
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
                            Label =LangSettings.InstanceOf.TOTAL_COST,
                            ValueLabel =  totalCost.ToString()
                        },

                    new Entry(totalIncome)
                        {
                            Color = SKColor.Parse("#36D746"),
                            Label = LangSettings.InstanceOf.TOTAL_INCOME,
                            ValueLabel = totalIncome.ToString()
                        }
                };
            ChartBar.Chart = new BarChart() { Entries = entries };
        }

        private void OnYearChanged(object sender, EventArgs e)
        {
            bool resultParse = int.TryParse(pickerYear.Items[pickerYear.SelectedIndex], out int tempYear);
            if (resultParse)
            {
                Year = tempYear;
                OnMonthChanged(sender, e);
            }
        }
    }
}