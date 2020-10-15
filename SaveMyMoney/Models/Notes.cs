using SaveMyMoney.Helpers;
using SaveMyMoney.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SaveMyMoney.Models
{
    [Serializable]
    public class Notes : IData
    {
        public List<Note> NotesList { get; private set; }

        public Notes()
        {
            NotesList = new List<Note>();
        }

        public void AddNote(Note newNote)
        {
            if (newNote != null)
            {
                NotesList.Add(newNote);
                SaveData();
            }
        }

        public void DeleteNote(Note noteForDeleting)
        {
            for (int i = 0; i < NotesList.Count; i++)
            {
                if (NotesList[i].Date == noteForDeleting.Date && NotesList[i].Amount == noteForDeleting.Amount)
                {
                    NotesList.Remove(NotesList[i]);
                }
            }
            SaveData();
        }

        public Note FindNoteOrReturnNULL(Note noteForSerching)
        {
            foreach (Note anyNote in NotesList)
            {
                if (anyNote.Date == noteForSerching.Date)
                    return anyNote;
            }
            return null;
        }

        public void SaveData()
        {
            FileWorker.SaveDataToFile(App.DataBase, Path.Combine(App.FolderPath, AppSettings.DATABASE_FILENAME));
        }
    }
}
