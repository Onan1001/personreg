using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonRegistry
{

    public abstract class Person : IComparable<Person>
    {
        
        protected string _firstName;
        protected string _lastName;
        protected string _prefix;
        

        public Person( string prefix, string firstname , string lastname )
        {
            _firstName = firstname;
            _lastName = lastname;
            _prefix = prefix;
        }

        public virtual string GetFullNames()
        {
            return _prefix + " " + _firstName + " " + _lastName;
        }

        int IComparable<Person>.CompareTo(Person other)
        {
            if(this._lastName == other._lastName)
            {
                return this._firstName.CompareTo(other._firstName);
            }
            return this._lastName.CompareTo(other._lastName);
        }

        public override string ToString()
        {
            return this._lastName.ToString()+ "," + this._lastName;
        }

        public static Person operator +(Person f, Person m)
        {
            if (m is Male && f is Female)
            {
                return new Child("Child", f._firstName, m._lastName);
            }
            else if (f is Male && m is Female)
            {
                return new Child("Child", m._firstName, f._lastName);
            }
            else
            {
                return null;
            }
        }

    }     
}
