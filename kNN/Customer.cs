using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kNN
{
    class Customer
    {
        private string name;
        private int age;
        private int gender;
        private int incoming;
        private int numCard;
        private int response;

        public Customer()
        {
            //do nothing
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public string getName()
        {
            return this.name;
        }

        public void setAge(int age)
        {
            this.age = age;
        }

        public int getAge()
        {
            return this.age;
        }


        public void setGender(int gender)
        {
            this.gender = gender;
        }

        public int getGender()
        {
            return this.gender;
        }


        public void setIncoming(int income)
        {
            this.incoming = income;
        }

        public int getIncoming()
        {
            return this.incoming;
        }

        public void setNumcard(int numCard)
        {
            this.numCard = numCard;
        }

        public int getNumcard()
        {
            return this.numCard;
        }

        public void setResponse(int res)
        {
            this.response = res;
        }

        public int getResponse()
        {
            return this.response;
        }
    }
}
