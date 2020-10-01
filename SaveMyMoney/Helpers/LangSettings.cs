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
            }
            if (Language.Equals("Russian"))
            {
                SALARY = "Зарплата";
                PRIZE = "Премия";
                ENTER_NAME_OF_NEW_GROPE = "Введите название новой группы...";
                ADD_GROPE = "Добавить группу";
                DELETE_GROUP = "Удалить группу";
            }
        }
    }
}
