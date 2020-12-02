using System;
using System.Collections.Generic;
using System.Text;

namespace SaveMyMoney.Helpers
{
    class LangSettings
    {
        public static LangSettings InstanceOf = new LangSettings();
        public string SALARY;
        public string PRIZE;
        public string ENTER_NAME_OF_NEW_GROPE;
        public string ADD_GROPE;
        public string DELETE_GROUP;
        public string GROUP_IS_EMPTY;
        public string WARNING;
        public string SAVE;
        public string DELETE;
        public string AMOUNT;
        public string GROUP;
        public string ENTER_YOUR_COMMENT;
        public string TOTAL_BALANCE;
        public string REPORT;
        public string ALL_COSTS;
        public string TOTAL_INCOME_COST;
        public string TOTAL_COST;
        public string TOTAL_INCOME;
        public string TOTAL;
        public string DETAILS;
        public string CHOOSE_MONTH;
        public string CHOOSE_MODE;
        public string CHOOSE_GROUPE;
        public string BAD_AMOUNT;
        // MONTHES
        public string JENUARY;
        public string FEBRUARY;
        public string MARCH;
        public string APRIL;
        public string MAY;
        public string JUNE;
        public string JULY;
        public string AUGUST;
        public string SEPTEMBER;
        public string OCTOBER;
        public string NOVEMBER;
        public string DECEMBER;

        public void SetLanguage()
        {
            // TODO: Change language.
            if (App.Language.Equals("English"))
            {
                InstanceOf.SALARY = "Salary";
                InstanceOf.PRIZE = "Prize";
                InstanceOf.ENTER_NAME_OF_NEW_GROPE = "Enter name of new group...";
                InstanceOf.ADD_GROPE = "Add Grope";
                InstanceOf.DELETE_GROUP = "Delete Grope";
                InstanceOf.GROUP_IS_EMPTY = "Group is empty!";
                InstanceOf.WARNING = "Warning";
                InstanceOf.SAVE = "Save";
                InstanceOf.DELETE = "Delete";
                InstanceOf.AMOUNT = "Amount";
                InstanceOf.GROUP = "Group";
                InstanceOf.ENTER_YOUR_COMMENT = "Enter your comment";
                InstanceOf.TOTAL_BALANCE = "Total Balance";
                InstanceOf.REPORT = "Report";
                InstanceOf.ALL_COSTS = "All costs";
                InstanceOf.TOTAL_INCOME_COST = "Total income/cost";
                InstanceOf.TOTAL_COST = "Total cost";
                InstanceOf.TOTAL_INCOME = "Total income";
                InstanceOf.TOTAL = "Total";
                InstanceOf.DETAILS = "Details";
                InstanceOf.CHOOSE_MONTH = "Choose a month";
                InstanceOf.CHOOSE_MODE = "Choose a mode";
                InstanceOf.CHOOSE_GROUPE = "Choose a groupe";
                InstanceOf.BAD_AMOUNT = "Bad amount!";
                // MONTHES
                InstanceOf.JENUARY = "January";
                InstanceOf.FEBRUARY = "February";
                InstanceOf.MARCH = "March";
                InstanceOf.MAY = "May";
                InstanceOf.APRIL = "April";
                InstanceOf.JUNE = "June";
                InstanceOf.JULY = "July";
                InstanceOf.AUGUST = "August";
                InstanceOf.SEPTEMBER = "September";
                InstanceOf.OCTOBER = "October";
                InstanceOf.NOVEMBER = "November";
                InstanceOf.DECEMBER = "December";
            }
            if (App.Language.Equals("Russian"))
            {
                InstanceOf.SALARY = "Зарплата";
                InstanceOf.PRIZE = "Премия";
                InstanceOf.ENTER_NAME_OF_NEW_GROPE = "Введите название новой группы...";
                InstanceOf.ADD_GROPE = "Добавить группу";
                InstanceOf.DELETE_GROUP = "Удалить группу";
                InstanceOf.GROUP_IS_EMPTY = "Не заполнено имя группы!";
                InstanceOf.WARNING = "Внимание";
                InstanceOf.SAVE = "Сохранить";
                InstanceOf.DELETE = "Удалить";
                InstanceOf.AMOUNT = "Сумма";
                InstanceOf.GROUP = "Группа";
                InstanceOf.ENTER_YOUR_COMMENT = "Добавить комментарий";
                InstanceOf.TOTAL_BALANCE = "Суммарный баланс";
                InstanceOf.REPORT = "Отчёт";
                InstanceOf.ALL_COSTS = "Все расходы";
                InstanceOf.TOTAL_INCOME_COST = "Общий доход/расход";
                InstanceOf.TOTAL_COST = "Общий расход";
                InstanceOf.TOTAL_INCOME = "Общий доход";
                InstanceOf.TOTAL = "Итого";
                InstanceOf.DETAILS = "Детали";
                InstanceOf.CHOOSE_MONTH = "Выберите месяц";
                InstanceOf.CHOOSE_MODE = "Выберите режим";
                InstanceOf.CHOOSE_GROUPE = "Выберите группу";
                InstanceOf.BAD_AMOUNT = "Сумма введена не верно!";
                // MONTHES
                InstanceOf.JENUARY = "Январь";
                InstanceOf.FEBRUARY = "Февраль";
                InstanceOf.MARCH = "Март";
                InstanceOf.MAY = "Май";
                InstanceOf.APRIL = "Апрель";
                InstanceOf.JUNE = "Июнь";
                InstanceOf.JULY = "Июль";
                InstanceOf.AUGUST = "Август";
                InstanceOf.SEPTEMBER = "Сентябрь";
                InstanceOf.OCTOBER = "Октябрь";
                InstanceOf.NOVEMBER = "Ноябрь";
                InstanceOf.DECEMBER = "Декабрь";
            }
        }
    }
}
