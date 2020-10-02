using System;
using System.Collections.Generic;
using System.Text;

namespace SaveMyMoney.Helpers
{
    static class LangSettings
    {
        public static string Language;
        public static string SALARY;
        public static string PRIZE;
        public static string ENTER_NAME_OF_NEW_GROPE;
        public static string ADD_GROPE;
        public static string DELETE_GROUP;
        public static string GROUP_IS_EMPTY;
        public static string WARNING;
        public static string SAVE;
        public static string DELETE;
        public static string AMOUNT;
        public static string GROUP;
        public static string ENTER_YOUR_COMMENT;

        static LangSettings()
        {
            Language = "Russian";
            // TODO: Change language.
            if (Language.Equals("English"))
            {
                SALARY = "Salary";
                PRIZE = "Prize";
                ENTER_NAME_OF_NEW_GROPE = "Enter name of new group...";
                ADD_GROPE = "Add Grope";
                DELETE_GROUP = "Delete Grope";
                GROUP_IS_EMPTY = "Group is empty!";
                WARNING = "Warning";
                SAVE = "Save";
                DELETE = "Delete";
                AMOUNT = "Amount";
                GROUP = "Group";
                ENTER_YOUR_COMMENT = "Enter your comment";
    }
            if (Language.Equals("Russian"))
            {
                SALARY = "Зарплата";
                PRIZE = "Премия";
                ENTER_NAME_OF_NEW_GROPE = "Введите название новой группы...";
                ADD_GROPE = "Добавить группу";
                DELETE_GROUP = "Удалить группу";
                GROUP_IS_EMPTY = "Не заполнено имя группы!";
                WARNING = "Внимание";
                SAVE = "Сохранить";
                DELETE = "Удалить";
                AMOUNT = "Сумма";
                GROUP = "Группа";
                ENTER_YOUR_COMMENT = "Добавить комментарий";
            }
        }
    }
}
