using System;

namespace Tumakov7
{
    internal class Song
    {
        #region Fields
        private string _Name;
        private string _Author;
        private Song _Previous;
        #endregion

        #region Properties
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
        #endregion

        #region Methods
        /// <summary>
        /// Сравнивает 2 песни, если это возможно.
        /// </summary>
        /// <returns>Значение типа bool</returns>
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
        #endregion
    }
}
