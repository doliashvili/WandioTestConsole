using System;
using System.Collections.Generic;
using System.Linq;

namespace WandioTestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] source;
            char continueProces = Constants.no;
            do
            {
                Console.WriteLine("Please input array numbers ForExmpl: 12, 123, 14, 23, 17, 16");
                var input = Console.ReadLine();
                var splitedArray = input.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
                source = splitedArray.Length > 0 ? new int[splitedArray.Length] : new int[] { 12, 123, 14, 23, 17, 16 };

                for (int i = 0; i < splitedArray.Length; i++)
                {
                    var isNumber = int.TryParse(splitedArray[i], out int number);

                    if (isNumber)
                    {
                        source[i] = number;
                    }
                    else
                    {
                        Console.WriteLine("incorrect syntax please try again if you want continue enter: y");
                        source = null;
                        char.TryParse(Console.ReadLine(), out char enterResult);
                        if (enterResult == Constants.yes)
                        {
                            continueProces = Constants.yes;
                        }
                        break;
                    }
                }

            } while (continueProces == Constants.yes);


            foreach (var item in source)
            {
                Console.Write($"{item} ");
            }

            /*1.გამოძახება რომელიც აჩვენებს რომ საწყისი მასივის რომელიმე ელემენტის პრედიკატთან
              შესაბამისობის შემთხვევაში პროგრამა აბრუნებს default მნიშვნელობას */
            var minNumber = source.Min();
            var newNumber = minNumber - 1;

            var defaultResult = source.ThisDoesntMakeAnySense(x => x == minNumber, () => newNumber);
            Console.WriteLine($"1. Default result is: {defaultResult}");
            /*2.გამოძახება რომელიც აჩვენებს რომ საწყისი მასივის პრედიკატთან სრული შეუსაბამობის
             * შემთხვევაში აბრუნებს ახალ ჩანაწერს */

            var newRecord = source.ThisDoesntMakeAnySense(x => x == newNumber, () => newNumber);
            Console.WriteLine($"2. New record is: {newRecord} ");

            /*3.გამოძახება რომელიც აჩვენებს რომ ნულოვანი(null) საწყისი მასივის შემთხვევაში
                მეთოდი ისვრის ექსეფშენს */
            // For demonstration we need throw exception

            source = null;
            Console.WriteLine("3. If we have source null we will get exception");
            source.ThisDoesntMakeAnySense(x => x == minNumber, () => newNumber);

            /* For real project we need handle exceptions for exmple:->>
             try
            {
                source = null;
                source.ThisDoesntMakeAnySense(x => x == minNumber, () => newNumber);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }*/

        }
    }
}
