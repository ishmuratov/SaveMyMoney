using System;
using System.Collections.Generic;
using System.Text;

namespace SaveMyMoney.Models
{
    [Serializable]
    public class Group
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool isCost { get; set; }

        public override string ToString()
        {
            if (Name != null)
                return Name;
            else
                return "NULL";
        }
    }
}
