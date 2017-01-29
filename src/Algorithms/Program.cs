using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Algorithms
{
    public delegate bool StartEngine(string transmissionType);
    public class Program
    {

        public static bool StartElectricIgnition(string transmissionType)
        {
            Console.WriteLine("Started using electric ignition, using " + transmissionType + " transmission.");
            return true;
        }

        public static bool StartFaultyIgnition(string transmissionType)
        {
            Console.WriteLine("Started using classic ignition, using " + transmissionType + " transmission.");
            return false;
        }
        


        public static void Main(string[] args)
        {
            var camaro = new Car("manual");

            camaro.ProcessStartEngine(new StartEngine(StartFaultyIgnition));

            if (camaro.EngineStarted)
            {
                Console.WriteLine("Engine Started.");
            }
            else
            {
                Console.WriteLine("Engine failed to start.");
            }

            GenerateFibonacciSequence(10);
            FizzFuzz(100);
            var isPalindrome = Palindrome("eallai");
            Console.WriteLine("Is Palindrome? " + isPalindrome);

            var listOfNumbers = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var set = TwoSum(listOfNumbers, 12);

            if (set != null)
            {
                Console.WriteLine("First: " + set.Item1 + " Second:" + set.Item2);
            }
            else
            {
                Console.WriteLine("No suitable pair of numbers.");
            }

            Console.ReadKey();
        }

        public static void GenerateFibonacciSequence(int number)
        {
            var a = 0;
            var b = 1;

            for (var i = 0; i < number; i++)
            {
                var temp = a;
                a = b;
                b = temp + a;
                Console.WriteLine(b);
                
            }
        }

        public static Tuple<int, int> TwoSum(int[] list, int sum)
        {
            List<int> usedIndexes = new List<int>();

            while (true)
            {
                var randomIndex = new Random().Next(list.GetLowerBound(0), list.GetUpperBound(0));

                if (usedIndexes.Contains(randomIndex))
                {
                    continue;
                }
                
                usedIndexes.Add(randomIndex);

                var diff = sum - list[randomIndex];

                for (var i = 0; i < list.Length; i++)
                {
                    if (list[i] == diff && list[i] != list[randomIndex])
                    {
                        var first = list[randomIndex];
                        var second = list[i];
                        return new Tuple<int, int>(first, second);
                    }
                }

                if (usedIndexes.Count == list.Length - 1)
                {
                    return null;
                }
            }
        }

        public static void FizzFuzz(int number)
        {
            for (var i = 1; i <= number; i++)
            {
                if (i % 5 == 0)
                {
                    Console.WriteLine(i + " fizzes");
                }
                else
                {
                    Console.WriteLine(i + " fuzzes");
                }
            }
        }

        public static bool Palindrome(string text)
        {
            var x = 0;
            var y = text.Length - 1;

            if (text.Length % 2 != 0)
            {
                return false;
            }

            var charArray = text.ToCharArray();

            for (var i = 0; i < text.Length / 2; i++)
            {
                if (charArray[x] != charArray[y])
                {
                    return false;
                }

                x++;
                y--;
            }

            return true;

        }
    }

    

    public abstract class Vehicle
    {
        public abstract void Accelerate(int speed);

        public virtual void Brake()
        {

        }

        public void Park()
        {
            
        }
    }

    public class Car : Vehicle
    {
        public string TransmissionType { get; set; }
        public int CurrentSpeed { get; set; }
        public bool EngineStarted { get; set; }
        public Car(string transmissionType)
        {
            EngineStarted = false;
            TransmissionType = transmissionType;

        }
        
        public override void Accelerate(int speed)
        {
            CurrentSpeed = speed;
        }

        public void ProcessStartEngine(StartEngine startEngine)
        {
            EngineStarted = startEngine(TransmissionType);
           
        }
    }
}
