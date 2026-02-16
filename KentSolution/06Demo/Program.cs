using System.Runtime.Serialization.Formatters.Binary;

namespace _06Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string file = "D:\\Kent Training\\kent_core_training\\KentSolution\\data.txt";
            //FileStream fileStream = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write);

            //StreamWriter streamWriter = new StreamWriter(fileStream);

            //streamWriter.WriteLine("Hi");
            //streamWriter.Close();
            //fileStream.Close();
            //Console.WriteLine("Done");


            string file = "D:\\Kent Training\\kent_core_training\\KentSolution\\data.txt";
            FileStream fileStream = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write);

            //StreamWriter streamWriter = new StreamWriter(fileStream);

            BinaryFormatter formatter = new BinaryFormatter();

            Emp emp = new Emp();
            emp.No = 11;
            emp.Name = "abc";
            emp.Address = "Pune";

            formatter.Serialize(fileStream, emp);
            fileStream.Close();
            Console.WriteLine("Done");
        }
    }

    [Serializable]
    [CLSCompliant(true)]
    public class Emp
    {
        private int _No;
        private string _Name;
       
        private string _Address;

        [NonSerialized]
        private string _Password = "xyz@123";

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public int No
        {
            get { return _No; }
            set { _No = value; }
        }

    }
}
