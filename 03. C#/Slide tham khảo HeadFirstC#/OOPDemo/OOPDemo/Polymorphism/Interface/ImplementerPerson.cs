using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo.Interface
{
    public class Person:IPerson
    {
        string IPerson.Name
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        DateTime IPerson.DateOfBirth
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        int IPerson.Age
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }

    public class Trainer : IPerson
    {
        public int Age
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }

    public class Student : IPerson
    {
        public int Age
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }

}
