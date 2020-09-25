using System;
using System.Collections.Generic;
using System.Text;

namespace SaveMyMoney.Models
{
    [Serializable]
    public class Note
    {
        public string ImagePath { get; set; } = "plus_removebg.png";
        public string Filename { get; set; }
        public string Text { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public bool isCost { get; set; }
        public Group MoneyGroup { get; set; }

        public Note()
        {
        }

        public Note(bool cost)
        {
            isCost = cost;
            Amount = 0;
            Filename = "";
            Text = "";
            Date = DateTime.Now;
        }

        public Note(string text, int amount, Group group, bool cost)
        {
            Amount = amount;
            Filename = "";
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
