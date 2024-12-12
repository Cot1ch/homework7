namespace homework7
{
    internal class Task
    {
        #region Fields
        private string _Name;
        private Person _FromWho;
        private Person _ToWho;
        private string _Discription;
        private string _Status;
        #endregion

        public Task(string name, Person fromWho, Person toWho, string discription)
        {
            _Name = name;
            _FromWho = fromWho;
            _ToWho = toWho;
            _Discription = discription;
        }

        #region Properties
        public Person FromWho
        {
            get { return _FromWho; }
            set { _FromWho = value; }
        }
        public Person ToWho
        {
            get { return _ToWho; }
            set { _ToWho = value; }
        }
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        #endregion

        #region Method
        /// <summary>
        /// Возвращает информацию о задаче
        /// </summary>
        /// <returns>Строка string</returns>
        public override string ToString()
        {
            string result = $"==>\nЗадача {_Name}\nОт кого: {_FromWho.Name}\nКому: {_ToWho.Name}\nОписание задачи: {_Discription}\nСтатус: {Status}\n<==";

            return result;
        }
        #endregion
    }
}
