using SaveMyMoney.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaveMyMoney.Models
{
    [Serializable]
    public class Note
    {
        public string ImagePath { get; set; } = "plus_removebg.png";
        public string Text { get; set; }
        public int Amount { get; set; }
        public string TextAmount { get { return LangSettings.InstanceOf.AMOUNT + ": " + Amount.ToString(); } }
        public DateTime Date { get; set; }
        public bool isCost { get; set; }
        public Group MoneyGroup { get; set; }
        public string Details { get { return MoneyGroup.ToString() + " - " + Text; } }

        public Note()
        {
        }

        public Note(bool cost)
        {
            isCost = cost;
            Amount = 0;
            Text = "";
            Date = DateTime.Now;
        }

        public Note(string text, int amount, Group group, bool cost)
        {
            Amount = amount;
            Text = text;
            Date = DateTime.Now;
            MoneyGroup = group;
            isCost = cost;
            if (isCost)
            {
                ImagePath = "minus_removebg.png";
            }
        }
    }
}
