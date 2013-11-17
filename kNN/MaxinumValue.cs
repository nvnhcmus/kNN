using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kNN
{
    class MaxinumValue
    {
        int maxAge = 0;
        int maxIncome = 0;
        int maxnumCard = 0;

        List<Customer> lCustomer = new List<Customer>();

        public MaxinumValue(  List <Customer> lc )
        {
            this.lCustomer = lc;
        }

        public void findAllMax()
        {
            for (int i = 0; i < this.lCustomer.Count; i++)
            {
                //find maxAge
                if (this.lCustomer[i].getAge() > maxAge)
                {
                    maxAge = this.lCustomer[i].getAge();
                }

                //find maxIncome
                if (this.lCustomer[i].getIncoming() > maxIncome)
                {
                    maxIncome = this.lCustomer[i].getIncoming();
                }


                //find maxNumcard
                if (this.lCustomer[i].getNumcard() > maxnumCard)
                {
                    maxnumCard = this.lCustomer[i].getNumcard();
                }

            }//end loop
        }


        public int getMaxAge()
        {
            return this.maxAge;
        }

        public int getMaxIncome()
        {
            return this.maxIncome;
        }

        public int getMaxNumCard()
        {
            return this.maxnumCard;
        }
    }
}
