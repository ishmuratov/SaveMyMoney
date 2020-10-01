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
            EdNewGroupName.Placeholder = LangSettings.ENTER_NAME_OF_NEW_GROPE;
            btCreate.Text = LangSettings.ADD_GROPE;
            btDelete.Text = LangSettings.DELETE_GROUP;
            pickerGroups.Items.Clear();
            foreach (Group anyGroup in App.MoneyGroups.GroupList)
            {
                if (isCost && anyGroup.isCost && anyGroup.Name != null)
                    pickerGroups.Items.Add(anyGroup.Name);
                if (!isCost && !anyGroup.isCost && anyGroup.Name != null)
                    pickerGroups.Items.Add(anyGroup.Name);
            }
            if (pickerGroups.Items.Count > 0)
            {
                pickerGroups.Title = pickerGroups.Items[0];
            }
        }

        async public void OnAddGroupClicked(object sender, EventArgs e)
        {
            if (EdNewGroupName.Text == null)
            {
                await DisplayAlert("Warning", "Group name is empty!", "OK");
                return;
            }
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