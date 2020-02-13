using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HashCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = args.Length > 0 ? args[0] : "a_example.in";

            var lines = File.ReadAllLines(fileName);

            var line1 = lines[0];
            var line2 = lines[1];

            var line1Values = line1.Split(" ");
            var amountOfPizzaToOrder = int.Parse(line1Values[0]);
            var amountOfTypesOfPizza = int.Parse(line1Values[1]);

            Console.WriteLine($"amountOfPizzaToOrder: {amountOfPizzaToOrder}");
            Console.WriteLine($"amountOfTypesOfPizza: {amountOfTypesOfPizza}");

            var pizzaValuesAsStrings = line2.Split(" ");
            var pizzaValues = new int[pizzaValuesAsStrings.Length];

            for (int i = 0; i < pizzaValuesAsStrings.Length; i++)
            {
                pizzaValues[i] = int.Parse(pizzaValuesAsStrings[i]);
            }

            var amountOfPizzaLeftToOrder = amountOfPizzaToOrder;
            var pizzasBeingOrdered = new List<int>();

            for (int i = amountOfTypesOfPizza - 1; i >= 0; i--)
            {
                var nextPizzaWithHighestSliceCount = pizzaValues[i];

                if (nextPizzaWithHighestSliceCount > amountOfPizzaLeftToOrder)
                {
                    continue;
                }

                pizzasBeingOrdered.Add(i);

                amountOfPizzaLeftToOrder -= nextPizzaWithHighestSliceCount;
            }

            var pizzasBeingOrderedAsString = ArrayToString(pizzasBeingOrdered.ToArray());

            string[] resultLines = { pizzasBeingOrdered.Count.ToString(), pizzasBeingOrderedAsString };

            File.WriteAllLines($"{fileName.Split('.')[0]}.out", resultLines);
        }

        private static string ArrayToString<T>(T[] arr)
        {
            var sb = new StringBuilder();

            foreach (var item in arr)
            {
                sb.Append(item);
                sb.Append(' ');    
            }

            return sb.ToString().TrimEnd(' ');
        }
    }
}