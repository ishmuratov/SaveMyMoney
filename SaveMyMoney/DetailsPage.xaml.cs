using SaveMyMoney.Helpers;
using SaveMyMoney.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveMyMoney
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        List<Note> monthlyNotes;
        public DetailsPage(List<Note> monthlyNotes)
        {
            InitializeComponent();
            this.monthlyNotes = monthlyNotes;
        }

        protected override void OnAppearing()
        {
            pickerGroups.Title = LangSettings.InstanceOf.CHOOSE_GROUPE;

            listView.ItemsSource = monthlyNotes
                .OrderByDescending(d => d.Date)
                .ToList();

            foreach (Group anyGroup in App.MoneyGroups.GroupList)
            {
                pickerGroups.Items.Add(anyGroup.Name);
            }

            int totalCost = 0;
            foreach (Note anyNote in monthlyNotes)
            {
                if (anyNote.isCost)
                {
                    totalCost += anyNote.Amount;
                }
            }
            tbTotal.Text = $"{LangSettings.InstanceOf.TOTAL_COST}: {totalCost}";
        }

        void OnGroupChanged(object sender, EventArgs e)
        {
            pickerGroups.Title = pickerGroups.Items[pickerGroups.SelectedIndex];
            int totalAmount = 0;
            List<Note> monthlyNotesInGroup = new List<Note>();
            foreach (Note anyNote in monthlyNotes)
            {
                if (anyNote.MoneyGroup != null && anyNote.MoneyGroup.Name.Equals(pickerGroups.Title))
                {
                    monthlyNotesInGroup.Add(anyNote);
                    totalAmount += anyNote.Amount;
                }
            }
            tbTotal.Text = $"{LangSettings.InstanceOf.TOTAL}: {totalAmount}";
            listView.ItemsSource = monthlyNotesInGroup.OrderByDescending(d => d.Date).ToList();
        }
    }
}