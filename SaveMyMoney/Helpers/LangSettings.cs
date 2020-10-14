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
        public static string TOTAL_BALANCE;
        public static string REPORT;
        public static string ALL_COSTS;
        public static string TOTAL_INCOME_COST;
        public static string TOTAL_COST;
        public static string TOTAL_INCOME;
        public static string DETAILS;
        public static string CHOOSE_MONTH;
        public static string CHOOSE_MODE;
        public static string CHOOSE_GROUPE;
        // MONTHES
        public static string JENUARY;
        public static string FEBRUARY;
        public static string MARCH;
        public static string APRIL;
        public static string MAY;
        public static string JUNE;
        public static string JULY;
        public static string AUGUST;
        public static string SEPTEMBER;
        public static string OCTOBER;
        public static string NOVEMBER;
        public static string DECEMBER;

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
                TOTAL_BALANCE = "Total Balance";
                REPORT = "Report";
                ALL_COSTS = "All costs";
                TOTAL_INCOME_COST = "Total income/cost";
                TOTAL_COST = "Total cost";
                TOTAL_INCOME = "Total income";
                DETAILS = "Details";
                CHOOSE_MONTH = "Choose a month";
                CHOOSE_MODE = "Choose a mode";
                CHOOSE_GROUPE = "Choose a groupe";
                // MONTHES
                JENUARY = "January";
                FEBRUARY = "February";
                MARCH = "March";
                MAY = "May";
                APRIL = "April";
                JUNE = "June";
                JULY = "July";
                AUGUST = "August";
                SEPTEMBER = "September";
                OCTOBER = "October";
                NOVEMBER = "November";
                DECEMBER = "December";
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
                TOTAL_BALANCE = "Суммарный баланс";
                REPORT = "Отчёт";
                ALL_COSTS = "Все расходы";
                TOTAL_INCOME_COST = "Общий доход/расход";
                TOTAL_COST = "Общий расход";
                TOTAL_INCOME = "Общий доход";
                DETAILS = "Детали";
                CHOOSE_MONTH = "Выберете месяц";
                CHOOSE_MODE = "Выберете режим";
                CHOOSE_GROUPE = "Выберете группу";
                // MONTHES
                JENUARY = "Январь";
                FEBRUARY = "Февраль";
                MARCH = "Март";
                MAY = "Май";
                APRIL = "Апрель";
                JUNE = "Июнь";
                JULY = "Июль";
                AUGUST = "Август";
                SEPTEMBER = "Сентябрь";
                OCTOBER = "Октябрь";
                NOVEMBER = "Ноябрь";
                DECEMBER = "Декабрь";
            }
        }
    }
}
