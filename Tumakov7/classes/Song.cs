using System;

namespace Tumakov7
{
    internal class Song
    {
        private string _Name;
        private string _Author;
        private Song _Previous;

        public string Name 
        { 
            get { return _Name; } 
            set { _Name = value; }
        }

        public string Author
        {
            get { return _Author; }
            set { _Author = value; }
        }

        public Song Previous
        { 
            get { return _Previous; } 
            set { _Previous = value; } 
        }

        public string Title()
        {
            return Name + " - " + Author;
        }

        public override bool Equals(object d)
        {
            try
            {
                Song song2 = d as Song;
                if (song2 != null)
                {
                    return song2.Name == Name && song2.Author == Author;
                }
                else
                {
                    throw new Exception("Невозможно привести к типу Song");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
