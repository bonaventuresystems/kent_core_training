using System.ComponentModel;
using System.Reflection;

namespace _07DemoVarVsDynamic
{
    internal class Program
    {
        static void Main(string[] args)
        {


            //Maths maths = new Maths();
            //int result = maths.Add(10, 20);
            //Console.WriteLine(result);


            //int p = 100;
            //int q = 200;
            //Console.WriteLine("Before Swap : P = {0}, Q = {1}", p, q);
            //maths.Swap<int>(ref p, ref q);
            //Console.WriteLine("After Swap : P = {0}, Q = {1}", p, q);


            //Maths<string> maths1 = new Maths<string>();


            //var v1 = new  { No = 10, Name = "abc", Address = "pune" };
            //var v2 = new { No = 10, Address = "pune", Name = "abc" };

            //Console.WriteLine(v1.GetType()) ;
            //Console.WriteLine(v2.GetType());

            //Special<int, bool, string, short> obj = new Special<int, bool, string, short>();

            //Special<string, int, string> obj = new Special<int, string, string>();

            //dynamic obj = Factory.GetMeSomething(20);
            //Console.WriteLine(obj.GetBookDetailsJKHKHKHHHKJHKHHHHKJHKH());
            Console.ReadLine();
        }
    }

    public class Factory
    {
        public static object GetMeSomething(int i)
        {
            if (i == 10)
            {
                return new Emp();
            }
            else
            {
                return new Book();
            }
        }
    }
    public class Maths
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public void Swap<T>(ref T x,ref T y)
        {
            T z = x;
            x = y;
            y = z;
        }

        //public void Swap(ref string x, ref string y)
        //{
        //    string z = x;
        //    x = y;
        //    y = z;
        //}
    }

    public class Special<No, Name, Address>
    {
        //public S NonsenseMethod(P p, Q q, R r, S s)
        //{
        //    return s;
        //}

        public No MyProperty1 { get; set; }
        public Name MyProperty2 { get; set; }
        public Address MyProperty3 { get; set; }

        //Logic to manipulat MyProperty1, MyProperty2
    }

    public class Emp
    {
        public int No { get; set; }
        public string Name { get; set; }

        public string GetEmpDetails()
        {
            return "EMP Details";
        }
    }


    public class Book
    {
        public string GetBookDetails() { return "some book details"; }
    }



    public class Anonymous0<No, Name, Address>
    {

    }
}
