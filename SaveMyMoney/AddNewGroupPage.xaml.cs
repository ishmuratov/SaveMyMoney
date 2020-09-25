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
    public partial class AddNewGroupPage : ContentPage
    {
        bool isCost;
        public AddNewGroupPage(bool cost)
        {
            InitializeComponent();
            isCost = cost;
        }

        protected override void OnAppearing()
        {
            pickerGroups.Items.Clear();
            foreach (Group anyGroup in App.MoneyGroups.GroupList)
            {
                if (isCost && anyGroup.isCost)
                    pickerGroups.Items.Add(anyGroup.Name);
                if (!isCost && !anyGroup.isCost)
                    pickerGroups.Items.Add(anyGroup.Name);
            }
            if (pickerGroups.Items.Count > 0)
            {
                pickerGroups.Title = pickerGroups.Items[0];
            }
        }

        async public void OnAddGroupClicked(object sender, EventArgs e)
        {
            Group newGroup = new Group { ID = 0, Name = EdNewGroupName.Text, isCost = this.isCost};
            App.MoneyGroups.AddGroup(newGroup);
            await Navigation.PopAsync();
        }

        async public void OnDeleteGroupClicked(object sender, EventArgs e)
        {
            App.MoneyGroups.DeleteGroup(pickerGroups.Title);
            await Navigation.PopAsync();
        }

        void OnGroupChanged(object sender, EventArgs e)
        {
            pickerGroups.Title = pickerGroups.Items[pickerGroups.SelectedIndex];
        }
    }
}