using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InClass_Random
{
    public class Driver
    {
        public static void Main()
        {
            //Creating an object of the Random class which we can then use to
            //generate random numbers
            Random random = new Random();

            //generate a random integer between 0 and 2,147,483,647
            int rand = random.Next(); 
            Console.WriteLine(rand);

            //generates a random integer between 0 (inclusive) and the number
            //specified (exclusive)
            int rand2 = random.Next(5); //0, 1, 2, 3, 4
            Console.WriteLine(rand2);

            //generates a random integer between lower bound (inclusive) and
            //upper bound (exclusive)
            int rand3 = random.Next(3, 10); //3, 4, 5, 6, 7, 8, 9
            Console.WriteLine(rand3);

            //generates a random number between 0.0 (inclusive) and 1.0 (exclusive)
            double rand4 = random.NextDouble();
            Console.WriteLine(rand4);

            //multiplying extends the range, adding shifts the starting point
            double rand5 = (random.NextDouble() * 5) + 3; //between 3.0 and 8.0 (exclusive)
            Console.WriteLine(rand5);

            //BadRandomExample();
            //GoodRandomExample();

            for(int i = 0; i < 10; i++)
            {
                string result = CoinToss(random);
                Console.WriteLine(result);
            }

            int countHeads = 0;
            int countTails = 0;

            for (int i = 0; i < 1000000; i++)
            {
                string result = CoinToss(random);
                if(result == "heads")
                {
                    countHeads++;
                }
                else
                {
                    countTails++;
                }
            }

            Console.WriteLine($"Heads: {countHeads}");
            Console.WriteLine($"Tails: {countTails}");
        }

        private static void BadRandomExample()
        {
            for(int i = 0; i < 100; i++)
            {
                //Don't create a random object over and over; it can result in
                //using the same seed leading to the same numbers instead of
                //random ones
                Random random = new Random();
                Console.WriteLine(random.Next(1, 101)); // 1 - 100
            }
        }

        private static void GoodRandomExample()
        {
            //Always make one Random object at the beginning, and use its methods
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(random.Next(1, 101)); // 1 - 100
            }
        }

        private static string CoinToss(Random r)
        {
            int rand = r.Next();
            if(rand % 2 == 0) //even number
            {
                return "heads";
            }
            else //odd number
            {
                return "tails";
            }
        }
    }
}
