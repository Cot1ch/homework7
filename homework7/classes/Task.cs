namespace homework7
{
    internal class Task
    {
        private string _Name;
        private Person _FromWho;
        private Person _ToWho;
        private string _Discription;
        private string _Status;

        public Task(string name, Person fromWho, Person toWho, string discription)
        {
            _Name = name;
            _FromWho = fromWho;
            _ToWho = toWho;
            _Discription = discription;
        }
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

        public override string ToString()
        {
            string result = $"Задача {_Name}\nОт кого: {_FromWho.Name}\nКому: {_ToWho.Name}\nОписание задачи: {_Discription}\nСтатус: {Status}";

            return result;
        }
    }
}
