using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDemo
{
    /// <summary>
    /// Lớp mô tả con mèo
    /// </summary>
    public class Cat
    {

        #region Constructor

        public Cat()
        {
            this._name = "Tom";
            this._owner = "Tung";
        }

        //public Cat(): this("Tom", "Tung") //Reuse constructor
        //{
        //}

        /// <summary>
        /// Create Cat with name
        /// </summary>
        /// <param name="name">Cat name to initialize</param>
        /// <param name="owner">Cat owner to initialize</param>
        public Cat(string name, string owner)
        {
            _name = name;
            _owner = owner;
        }

        #endregion

        #region Properties

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _owner;
        public string Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        public int Age { get; set; }


        private string _original = "Viet Nam";
        public string OriginalGet { get { return _original; } }
        public string OriginalSet { set { _original = value; } }
        #endregion

        #region Function

        /// <summary>
        /// Hàm kêu 
        /// </summary>
        internal void Say()
        {
            Console.WriteLine("Meooooo!");
        }

        public void SayWithName()
        {
            Console.WriteLine(String.Format("{0} say: My owner is {1}!", _name, _owner));
        }

        public string GetName()
        {
            string fullName = "My name is: " + _name;
            return fullName;
        }

        public int GetAge()
        {
            Age = 3;
            return Age;
        }

        #endregion
    }
}
