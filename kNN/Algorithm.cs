using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kNN
{
    class Algorithm
    {
        int kNN;
        int totalTrainset;
        List<Customer> trainset;
        List<Customer> customerset;

        Distance [] distances;

        int maxAge;
        int maxIncome;
        int maxNumCard;


        public Algorithm(  int k, List <Customer> train, List <Customer> customer )
        {
            this.kNN = k;//k neighbor
           
            this.trainset = train;//trainset
            this.customerset = customer;//customer
            this.totalTrainset = train.Count;//total of customer

            distances = new Distance [this.totalTrainset];

            //get max value of each column need to normalize
            MaxinumValue maximum = new MaxinumValue(train);
            maximum.findAllMax();

            maxAge = maximum.getMaxAge();
            maxIncome = maximum.getMaxIncome();
            maxNumCard = maximum.getMaxNumCard();


        }

        public void setResponse( Customer cus )
        {
            //normalize cus
            Normalize ncus = new Normalize(cus, maxAge, maxIncome, maxNumCard);


            //calculate all distances
            for (int i = 0; i < this.totalTrainset; i++)
            {
                distances[i] = new Distance();
                distances[i].distance = 0;
                distances[i].index = i;

                //normalize element
                Normalize tmp = new Normalize(this.trainset[i], maxAge, maxIncome, maxNumCard);


                //distance between two age normalized
                distances[i].distance = distances[i].distance + getDistance( ncus.age , tmp.age);

                //distance between two gender
                distances[i].distance = distances[i].distance + getDistance(cus.getGender(), this.trainset[i].getGender());

                //distance between two incoming normalized
                distances[i].distance = distances[i].distance + getDistance(ncus.incoming, tmp.incoming);

                //distance between two number of card normalized
                distances[i].distance = distances[i].distance + getDistance( ncus.numCard, tmp.numCard);

            }// end loop


            //sort
            for (int i = 0; i < totalTrainset - 1; i++)
            {
                for (int j = i + 1; j < totalTrainset; j++)
                {
                    if (distances[i].distance > distances[j].distance)
                    {
                        Distance tmp = distances[i];
                        distances[i] = distances[j];
                        distances[j] = tmp;
                    }//swap
                }//end j loop

            }//end i loop



            //select k nearest neighbor
            int yesCount = 0;
            int noCount = 0;

            for (int i = 0; i < kNN; i++)
            {
                Customer tmp = trainset[ distances[i].index ];
                if (tmp.getResponse() == 0)
                {
                    noCount = noCount + 1;
                }
                else if ( tmp.getResponse() == 1 )
                {
                    yesCount = yesCount + 1;
                }
            }



            //set response value for unknown customer
            if (yesCount > noCount)
            {
                cus.setResponse(1);
            }
            else if (yesCount < noCount)
            {
                cus.setResponse(0);
            }


            
        }
        
        public float getDistance(float a, float b)
        {
            return (a - b) * (a - b);
        }

        public void runkNN()
        {
            for (int i = 0; i < this.customerset.Count; i++)
            {
                setResponse(this.customerset[i]);
            }
        }

        public List<Customer> getCustomerList()
        {
            return this.customerset;
        }


    }
}
