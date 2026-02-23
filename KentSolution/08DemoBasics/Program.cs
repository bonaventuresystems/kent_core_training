using System;
using System.Collections;
using System.Diagnostics;
using System.Linq.Expressions;

namespace _08DemoBasics
{
    //public delegate bool MyDelegate(int i);

    public delegate Q MyDelegate<P,Q>(P i);
    internal class Program
    {
        static void Main(string[] args)
        {
            //ArrayList arr = new ArrayList();
            //  foreach (var item in arr)
            //  {

            //  }

            //Week week = new Week();

            //  foreach (string day in week)
            //  {
            //      Console.WriteLine(day);
            //  }


            //MyDelegate pointer = new MyDelegate(Check);
            //bool result = Check(30);

            //MyDelegate pointer = delegate (int i)
            //                    {
            //                        return i > 20;
            //                    };

            //MyDelegate pointer =  (i)=>
            //                        {
            //                            return i > 20;
            //                        };

            //bool result = pointer(30);
            //Console.WriteLine(result);


            //string str = "abc";

            ////  bool result =     MyString.CheckForValidEmailAddress(str, 100);

            //bool result = str.CheckForValidEmailAddress<string>(100);

            //int i = 100;

            //Console.WriteLine(result);


            //MyDelegate pointer = new MyDelegate(Check);
            //MyDelegate pointer = delegate (int i)
            //                    {
            //                        return i > 20;
            //                    };

            //MyDelegate pointer = (i)=>
            //                        {
            //                            return i > 20;
            //                        };

            //Func<int,bool> pointer = (i) =>
            //                            {
            //                                return i > 20;
            //                            };

            Expression<Func<int, bool>> tree = (i) => i > 20; //Create a tree

            Func<int, bool> pointer = tree.Compile(); //Compile a tree




            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            //bool result = Check(30);
            //bool result = pointer(30); //Create + Compile + Execute Expression Tree

            bool result = pointer(30); //Execute Expression Tree
            stopwatch.Stop();


            Console.WriteLine(result);
            Console.WriteLine("Time Taken = {0}", stopwatch.ElapsedTicks);

            Console.ReadLine();
        }



        //public static bool Check(int i)
        //{
        //    return i > 20;
        //}
    }


    public static class MyString
    {
        public static bool CheckForValidEmailAddress<T>(this T str, int i)
        {
            //return str.Contains("@");
            return true;
        }
    }

    //public static class MyString 
    //{
    //    public static bool CheckForValidEmailAddress(this string str, int i)
    //    {
    //        //return str.Contains("@");
    //        return true;
    //    }
    //}

    public class Week: IEnumerable
    {
        private string[] days = new string[] { "Mon", "Tue", "Wed","Thur", "Fri" };

        public IEnumerator GetEnumerator()
        {
           for (int i = 0; i < days.Length; i++)
            {
               yield return days[i];
            }
        }
    }


}
