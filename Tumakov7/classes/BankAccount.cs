using System;
using System.Security.Principal;


namespace Tumakov7
{
    internal class BankAccount
    {
        #region Fields
        private static Guid _Id;
        private decimal _Balance;
        private Account _account;
        #endregion

        #region Properties
        public Guid Id
        { 
            get { return Guid.NewGuid(); } 
        }

        public decimal balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }
        public Account account
        {
            get { return _account; }
            set { _account = value; }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Выводит информацию о банковском счёте
        /// </summary>
        /// <returns>-</returns>
        public void PrintInfo()
        {
            Console.WriteLine($"Номер счёта: {Id}, баланс: {balance}, тип: {account}");
        }

        /// <summary>
        /// Добавляет введённую сумму к сумме на счету. 
        /// </summary>
        /// <returns>-</returns>
        public void Put(decimal moneyy)
        {
            _Balance += moneyy;
        }

        /// <summary>
        /// Проверяет, можно ли снять введённую сумму.
        /// Если да, то вычитает её со счёта, 
        /// в противном случае уведомляет пользователя о невозможности операции.
        /// </summary>
        /// <returns>Значение типа bool</returns>
        public bool Remove(decimal moneyy)
        {
            if (moneyy <= _Balance)
            {
                _Balance -= moneyy;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool moneyTransfer(BankAccount bankAccount, decimal moneyy)
        {
            if (Remove(moneyy))
            {
                bankAccount.Put(moneyy);
                return(true);
            }
            return false;
        }

        #endregion

        public enum Account
        {
            Текущий, Сберегательный
        }
    }
}
