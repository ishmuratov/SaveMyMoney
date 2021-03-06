﻿using SaveMyMoney.Helpers;
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
    public partial class NoteEntryPage : ContentPage
    {
        public NoteEntryPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            tbAddGroup.Text = LangSettings.InstanceOf.ADD_GROPE;
            btSave.Text = LangSettings.InstanceOf.SAVE;
            btDelete.Text = LangSettings.InstanceOf.DELETE;
            LbAmount.Text = LangSettings.InstanceOf.AMOUNT + ":";
            LbGroups.Text = LangSettings.InstanceOf.GROUP + ":";
            editComment.Placeholder = LangSettings.InstanceOf.ENTER_YOUR_COMMENT + "...";
            editComment.FontSize = 15;
            var note = (Note)BindingContext;
            if (note.isCost)
            {
                num_amount.BackgroundColor = Color.FromHex("#EBA9A9");
            }
            else
            {
                num_amount.BackgroundColor = Color.FromHex("#ABF2B0");
            }

            if (note.Amount == 0)
            {
                num_amount.Text = "";
            }

            if (note.MoneyGroup != null)
            {
                pickerGroups.Title = note.MoneyGroup.Name;
            }
            pickerGroups.Items.Clear();
            foreach (Group anyGroup in App.MoneyGroups.GroupList)
            {
                if (note.isCost && anyGroup.isCost && anyGroup.Name != null)
                    pickerGroups.Items.Add(anyGroup.Name);
                if (!note.isCost && !anyGroup.isCost && anyGroup.Name != null)
                    pickerGroups.Items.Add(anyGroup.Name);
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (pickerGroups.Title == "")
            {
                await DisplayAlert(LangSettings.InstanceOf.WARNING, LangSettings.InstanceOf.GROUP_IS_EMPTY, "OK");
                return;
            }
            var note = (Note)BindingContext;
            Note newOrModifiedNote = App.DataBase.FindNoteOrReturnNULL(note);
            if (num_amount.Text == "")
            {
                num_amount.Text = 0.ToString();
            }
            if (newOrModifiedNote == null)
            {
                // Add in DB
                bool TextToIntResult = int.TryParse(num_amount.Text, out int amount);
                if (TextToIntResult)
                {
                    Note newNote = new Note(note.Text, amount, App.MoneyGroups.FindGroupOrReturnNULL(pickerGroups.Items[pickerGroups.SelectedIndex]), note.isCost);
                    App.DataBase.AddNote(newNote);
                }
                else
                {
                    await DisplayAlert(LangSettings.InstanceOf.WARNING, LangSettings.InstanceOf.BAD_AMOUNT, "OK");
                    return;
                }
            }
            else
            {
                // Update in DB
                newOrModifiedNote.Text = note.Text;
                newOrModifiedNote.Amount = int.Parse(num_amount.Text);
                newOrModifiedNote.MoneyGroup = App.MoneyGroups.FindGroupOrReturnNULL(pickerGroups.Title);
                App.DataBase.SaveData();
            }

            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            // Delete from DB
            App.DataBase.DeleteNote(note);
            await Navigation.PopAsync();
        }

        async void OnAddNewGroup(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            await Navigation.PushAsync(new AddNewGroupPage(note.isCost));
        }

        void OnEntryFocused(object sender, EventArgs e)
        {
            num_amount.Text = "";
        }

        void OnGroupChanged(object sender, EventArgs e)
        {
            pickerGroups.Title = pickerGroups.Items[pickerGroups.SelectedIndex];
        }
    }
}