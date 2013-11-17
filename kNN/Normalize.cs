using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kNN
{
    class Normalize
    {
        public float age;
        public float incoming;
        public float numCard;

        public Normalize(  Customer cus, int maxAge, int maxIncome, int maxNumCard )
        {
            age = (float) cus.getAge() / (float)maxAge;
            incoming = (float) cus.getIncoming() / (float)maxIncome;
            numCard = (float) cus.getNumcard() / (float)maxNumCard;
        }
    }
}
