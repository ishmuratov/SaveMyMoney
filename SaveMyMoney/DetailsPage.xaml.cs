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
        }

        void OnGroupChanged(object sender, EventArgs e)
        {
            pickerGroups.Title = pickerGroups.Items[pickerGroups.SelectedIndex];
            List<Note> monthlyNotesInGroup = new List<Note>();
            foreach (Note anyNote in monthlyNotes)
            {
                if (anyNote.MoneyGroup != null && anyNote.MoneyGroup.Name.Equals(pickerGroups.Title))
                {
                    monthlyNotesInGroup.Add(anyNote);
                }
            }
            listView.ItemsSource = monthlyNotesInGroup.OrderByDescending(d => d.Date).ToList();
        }
    }
}