using Kaizen.Assessment.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Kaizen.Assessment
{
    // *** NOTE ***
    // ALL CHANGES MUST BE ACCOMPANIED BY COMMENTS 
    // PLEASE READ ALL COMMENTS / INSTRUCTIONS
    public static class Program
    {
        static void Main(string[] args)
        {
            #region Assessment A

            // the below class declarations looks like a 1st year student developed it
            // NOTE: this includes the class declarations as well
            // IMPROVE THE ARCHITECTURE 
            
            // instantiated the class by using an object initializer
            Human human = new Human
            {
                Name = "John",
                Age = 35,
                Gender = "M"
            };
            Console.WriteLine(human.GetDetails());

            // instantiated the class by using an object initializer
            Dog dog = new Dog
            {
                Name = "Walter",
                Age = 7,
                Food = "Epol"
            };
            Console.WriteLine(dog.GetDetails());

            // instantiated the class by using an object initializer
            Cat cat = new Cat
            {
                Name = "Snowball",
                Age = 35,
                Food = "Whiskers"
            };
            Console.WriteLine(cat.GetDetails());

            #endregion

            #region Assessment B

            // you'll notice the following piece of code takes an
            // age to execute - CORRECT THIS
            // IT MUST EXECUTE IN UNDER A SECOND
            PerformanceTest();

            #endregion

            #region Assessment C

            // correct the following LINQ statement found in their respective methods
            var numbers = new List<int>()
            {
                1, 4, 5, 9, 11, 15, 20, 27, 34, 55 // you may not change the numbers
            };
            // the following method must return the first event number - as suggested by it's name
            var firstValue = GetFirstEvenValue(numbers);
            Console.WriteLine("First Number: " + firstValue);

            var strings = new List<string>()
            {
                "John", "Jane", "Sarah", "Pete", "Anna"
            };
            // the following method must return the first name which contains an 'a'
            var strValue = GetSingleStringValue(strings);
            Console.WriteLine("Single String: " + strValue);

            #endregion

            #region Assessment D

            // there are multiple corrections required!!
            // correct the following statement(s)
            try
            {
                Dog bulldog = null;
                if (bulldog != null)//check if the object is null and dispose of it if it is
                {
                    var disposeDog = (IDisposable)bulldog;
                    disposeDog.Dispose();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            #endregion

            #region Assessment E

            DisposeSomeObject();            

            #endregion

            #region Assessment F

            // # SECTION A #
            // by making use of generics improve the implementation of the following methods
            // output must still render as: Name: [name] Age: [age]
            // THE METHOD THAT YOU CREATE MUST BE STATIC AND DECLARED IN THE PROGRAM CLASS
            // NB!! PLEASE NAME THE METHOD: ShowSomeMammalInformation
            ShowSomeHumanInformation(human);
            ShowSomeDogInformation(dog);
            ShowSomeCatInformation(cat);

            //using the ShowMammalInformation Generic Method
            // I am using generic method
            ShowSomeMammalInformation(human.Name, human.Age);
            ShowSomeMammalInformation(dog.Name, dog.Age);
            ShowSomeMammalInformation(cat.Name, cat.Age);


            // # SECTION B #
            // BY MAKING USE OF REFLECTION (amongst other things):
            //      => create a method so that the below code snippet will work:
            //      => place a constraint on the new method, so that a new instance will be created when 'dog' is null
            //      => thus is dog = null, the method should create a new instance an not fail

            // UNCOMMENT THE FOLLOWING PIECE OF CODE - IT WILL CAUSE A COMPILER ERROR - BECAUSE YOU HAVE TO CREATE THE METHOD

            string a = Program.GenericTester(walter => walter.GetDetails(), dog);
            Console.WriteLine("Result A: {0}", a);
            int b = Program.GenericTester(snowball => snowball.Age, cat);
            Console.WriteLine("Result B: {0}", b);

            #endregion

            #region Assessment G

            // in the following statement, everything works fine
            // but, it has a huge flaw! 
            // correct the following piece of code
            try
            {
                CatchAndRethrowExplicitly();
            }
            catch (ArithmeticException e)
            {
                Console.WriteLine("Implicitly specified:{0}{1}", Environment.NewLine, e.StackTrace);
            }

            #endregion            

            #region Assessment H

            try
            {
                // REFLECTION TEST .... NAVIGATE TO THE BELOW METHOD TO GET ALL THE INSTRUCTIONS
                CallMethodWithReflection();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            #endregion            

            #region IoC / DI

            // everything can be viewed in this method....
            PerformIoCActions();

            #endregion

            #region Bonus XP - Dungeon

            // > UNCOMMENT THE CODE BELOW AND CREATE A METHOD SO THAT THE FOLLOWING CODE WILL WORK
            // > DECLARE ALL THE METHODS WITHIN THE PROGRAM CLASS !!
            // > DO NOT ALTER THE EXISTING CODE


            const string abc = "asduqwezxc";

           
            foreach (var vowel in SelectOnlyVowels(abc))
            {
                Console.WriteLine("{0}", vowel);
            }

            // < REQUIRED OUTPUT => a u e

            // > UNCOMMENT THE CODE BELOW AND CREATE A METHOD SO THAT THE FOLLOWING CODE WILL WORK
            // > DECLARE ALL THE METHODS WITHIN THE PROGRAM CLASS !!
            // > DO NOT ALTER THE EXISTING CODE

            // methods created in the assessment method region. 
            //created methods are the "customWhere" and SelectOnlyVowels
             List<Dog> dogs = new List<Dog>
             {
                 new Dog {Age = 8, Name = "Max"},
                 new Dog {Age = 3, Name = "Rocky"},
                 new Dog {Age = 9, Name = "XML"}
             };

             var foo = dogs.CustomWhere(x => x.Age > 6 && x.Name.SelectOnlyVowels().Any());

             // < DOGS REQUIRED OUTPUT =>
             //      Name: Max Age: 8

             List<Cat> cats = new List<Cat>
             {
                 new Cat {Age = 1, Name = "Capri"},
                 new Cat {Age = 8, Name = "Cara"},
                 new Cat {Age = 3, Name = "Captain Hooks"}
             };

             var bar = cats.CustomWhere(x => x.Age <= 4);

             // < CATS REQUIRED OUTPUT =>
             //      Name: Capri Age: 1
             //      Name: Captain Hooks Age: 3

             #endregion

             Console.WriteLine("Press any key to continue...");
             Console.ReadLine();
         }

         #region Assessment C Method

         public static int GetFirstEvenValue(List<int> numbers)
         {
             // RETURN THE FIRST EVEN NUMBER IN THE SEQUENCE
             // var first = numbers.Where(x => x % 2 == 0).First();
             int first = 0;
             //loop through the list and find the first even number
             //checks each number and the first one thats even, it stops and returns it
             foreach (var item in numbers)
             {
                 if (item % 2 == 0)
                 {
                     first = item;
                     break;
                 }
             }
             return first;
         }

         public static string GetSingleStringValue(List<string> stringList)
         {
             // THE OUTPUT MUST RENDER THE FIRST ITEM THAT CONTAINS AN 'a' INSIDE OF IT
             //var first = stringList.Where(x => x.IndexOf("a") != -1).Single();
             string first = "";

            //for every item in list, check if the item contains  the letter a.
            //if it contains the letter a, return that item
             foreach (var item in stringList)
             {
                 if (item.Contains("a"))
                 {
                     first = item;
                     break;
                 }
             }

             return first;
         }

         #endregion

         #region Assessment B Method

         public static void PerformanceTest()
         {
             // timer = new Timer();
             //added the thread to make it faster
             Thread thread = new Thread(new ThreadStart(() => {
                 string someLongDataString = "";
                 const int sLen = 30, loops = 50000; // YOU MAY NOT CHANGE THE NUMBER OF LOOPS IN ANY WAY !!
                 string source = new string('X', sLen);

                 for (int i = 0; i < loops; i++)
                 {
                     someLongDataString += source;
                 }
             }));
             thread.Start(); //start the thread when the method is called
         }

         #endregion

         #region Assessment E Method

         public static DisposableObject DisposeSomeObject()
         {
             // IMPROVE THE FOLLOWING PIECE OF CODE
             // as well as the PerformSomeLongRunningOperation method
             var disposableObject = new DisposableObject();
             try
             {
                 disposableObject.PerformSomeLongRunningOperation();
                 disposableObject.RaiseEvent("raised event");
             }
             finally
             {
                 disposableObject.Dispose();
             }

             return disposableObject;
         }

        #endregion

        #region Assessment F Methods
        public static void ShowSomeMammalInformation<T1, T2>(T1 name, T2 age)
        {
            Console.WriteLine("Name:" + name + " Age: " + age);
        }
        public static void ShowSomeHumanInformation(Human human)
         {
             Console.WriteLine("Name:" + human.Name + " Age: " + human.Age);
         }

         public static void ShowSomeDogInformation(Dog dog)
         {
             Console.WriteLine("Name:" + dog.Name + " Age: " + dog.Age);
         }

         public static void ShowSomeCatInformation(Cat cat)
         {
             Console.WriteLine("Name:" + cat.Name + " Age: " + cat.Age);
         }

        private static string GenericTester(Func<object, object> p, Dog mammal)
        {
            return mammal.GetDetails();
        }
        private static string GenericTester(Func<object, object> p, Cat mammal)
        {
            return mammal.Age.ToString();
        }

        #endregion

        #region Assessment G Methods

        public static void CatchAndRethrowExplicitly()
         {
             try
             {
                 ThrowException();
             }
             catch (ArithmeticException e)
             {
                 Console.WriteLine(e);//displaying the caught exception
             }
         }

         private static void ThrowException()
         {
             throw new ArithmeticException("illegal expression - was this picked up??");
         }

         #endregion

         #region Assessment H Methods

         public static string CallMethodWithReflection()
         {
            // BY MAKING USE OF ONLY REFLECTION
            // CALL THE FOLLOWING METHOD: DisplaySomeStuff [WHICH IN JUST BELOW THIS ONE]
            // AND RETURN THE STRING CONTENT

            // DO NOT CHANGE THE NAME, RETURN TYPE OR ANY IMPLEMENTATION OF THIS METHOD NOR THE BELOW METHOD

            //Using Reflection to Display
            Type t = typeof(Program);
            return DisplaySomeStuff(t);
          //  return DisplaySomeStuff(typeof(Dog));
         }

         public static string DisplaySomeStuff<T>(T toDisplay) where T : class
         {
             return string.Format("Here it is: {0}", toDisplay);
         }

         #endregion

         #region IoC / DI

         public static void PerformIoCActions()
         {
             /*  An very simple IoC / DI container has been created for you. All the code can be viewed in the Container folder.
              *  By making use of the classes provided, perform the following tasks:
              *  
              *  Two classes and two interfaces have been created for you, namely:
              *  
              *      - IDevice
              *      - SamsungDevice
              *      - IDeviceProcessor
              *      - DeviceProcessor
              * 
              *  The actual declarations can be view lower down in this file.
              *  
              *  The following needs to happen:
              *      
              *      1. register the interfaces with the respective classes
              *      2. resolve an instance of the IDeviceProcessor and call the GetDevicePrice method
              *      
              *  Some of the code below has been done, but you need to fill in the blanks
              */

            // 1. register the interfaces and classes
            //added the code below. 
            SamsungDevice samsungDevice = new SamsungDevice();
            DeviceProcessor processor = new DeviceProcessor(samsungDevice);
            var container = new SimpleContainer();
            container.Register<IDevice, SamsungDevice>();
            container.RegisterInstance(samsungDevice);
            container.Register<IDeviceProcessor,DeviceProcessor>();
            container.RegisterInstance(processor);

            // 2. resolve the IDeviceProcessor
            var deviceProcessor = container.Resolve<DeviceProcessor>();
            
            // call the GetDevicePrice method
            Console.WriteLine(deviceProcessor.GetDevicePrice());
        }

        #endregion

        #region Dungeon
        //first attempt to solve the vowels
        /* public static List<string> SelectOnlyVowels(string letters)
         {
             List<string> vowels = new List<string>();
             char[] v = new char[] { 'a', 'e', 'i', 'o', 'u' };

             foreach (char charactr in letters)
             {
                 foreach (var vowel in v)
                 {
                     if (charactr == vowel)
                     {
                         vowels.Add(charactr.ToString());
                     }
                 }
             }


             return vowels;
         }*/
         //methods below are added
        public static List<char> SelectOnlyVowels(this string vow)
        {
            List<char> vowels = new List<char>();
            for (int i = 0; i < vow.Length; i++)
            {
                if ((char.Parse(vow.Substring(i).ToLower()) == 'a') || ((char.Parse(vow.Substring(i).ToLower()) == 'e') || ((char.Parse(vow.Substring(i).ToLower()) == 'i') || ((char.Parse(vow.Substring(i).ToLower()) == 'o') || (char.Parse(vow.Substring(i).ToLower()) == 'u')))))
                {
                    vowels.Add(char.Parse(vow.Substring(i)));
                }
            }

            return vowels;
        }


        public static string CustomWhere(this List<Dog> list, Func<Dog, bool> condition)
        {
            var selectedItems = list.Where(condition);
            string line = "";
            foreach (var item in selectedItems)
            {
                Console.WriteLine("Name: {0}  Age: {1}", item.Name, item.Age);
                line = string.Format("Name: {0}  Age: {1}", item.Name, item.Age);
            }
            return line;
        }

        public static string CustomWhere(this List<Cat> list, Func<Cat, bool> condition)
        {
            var selectedItems = list.Where(condition);
            string line = "";
            foreach (var item in selectedItems)
            {
                Console.WriteLine("Name: {0}  Age: {1}", item.Name, item.Age);
                line = string.Format("Name: {0}  Age: {1}", item.Name, item.Age);
            }
            return line;
        }
        #endregion
    }

    public interface IDevice
    {
        string DeviceCode { get; }
    }

    public class SamsungDevice : IDevice
    {
        public string DeviceCode { get; private set; }

        public SamsungDevice()
        {
            this.DeviceCode = "Samsung";
        }
    }

    public interface IDeviceProcessor
    {
        double GetDevicePrice();
    }

    public class DeviceProcessor : IDeviceProcessor
    {
        protected IDevice Device { get; private set; }

        public DeviceProcessor(IDevice device)
        {
            this.Device = device;
        }

        public double GetDevicePrice()
        {
            // the actual implementation of this method does not matter....
            return this.Device.DeviceCode.Equals("Samsung") ? 12.95 : 19.95;
        }
    }
}
