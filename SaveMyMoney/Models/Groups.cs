using SaveMyMoney.Helpers;
using SaveMyMoney.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SaveMyMoney.Models
{
    [Serializable]
    public class Groups : IData
    {
        public List<Group> GroupList { get; private set; }

        public Groups()
        {
            GroupList = new List<Group>();
            GroupList.Add(new Group { ID = 0, Name = LangSettings.InstanceOf.SALARY, isCost = false });
            GroupList.Add(new Group { ID = 0, Name = LangSettings.InstanceOf.PRIZE , isCost = false});
        }

        public void AddGroup(Group newGroup)
        {
            GroupList.Add(newGroup);
            SaveData();
        }

        public void DeleteGroup(string text)
        {
            Group groupForDeleting = FindGroupOrReturnNULL(text);
            if (groupForDeleting != null)
            {
                GroupList.Remove(groupForDeleting);
            }
        }

        public Group FindGroupOrReturnNULL(string text)
        {
            foreach (Group anyGroup in GroupList)
            {
                if (anyGroup.Name.Equals(text))
                {
                    return anyGroup;
                }
            }
            return null;
        }

        private void SaveData()
        {
            FileWorker.SaveDataToFile(App.MoneyGroups, Path.Combine(App.FolderPath, AppSettings.GROUPS_FILENAME));
        }
    }
}
