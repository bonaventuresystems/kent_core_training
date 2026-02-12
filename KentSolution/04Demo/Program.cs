namespace _04Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //StreamWriter streamWriter = new StreamWriter(new FileStream())
            Bike bike = new Bike();

            Console.WriteLine("1: Bajaj , 2 : Cheap in Cost");
            int choice = Convert.ToInt32(Console.ReadLine());
            IGearBox gearBox = GearFactory.GetGearBox(choice);

            bike.GetPart(gearBox);


        }
    }
    public class GearFactory //IOC = Inversion of Control : Unity, Ninject, Autofac, Castle Windsor
    {
        public static IGearBox GetGearBox(int type)
        {
            if (type == 1)
            {
                return new BajajGearBox() { SubPart = "Bajaj GearBox" };
            }
            else if (type == 2)
            {
                return new ABCGearBox() { SubPart = "Cheap in Cost GearBox" };
            }
            else
            {
                throw new ArgumentException("Invalid type");
            }
        }   
    }


    public interface IGearBox
    {
        string SubPart { get; set; }
    }

    public class BajajGearBox: IGearBox
    {
        public string SubPart { get; set; }
    }

    public class ABCGearBox : IGearBox
    {
        public string SubPart { get; set; }
    }

    public class Bike
    {
        //public Bike(IGearBox IGearBox) //Constructor level dependency injection
        //{

        //}

        //public IGearBox IGearBox { get; set; }//Property level dependency injection
        public void GetPart(IGearBox gearBox)
        {
            Console.WriteLine(gearBox.SubPart + " is being used!");
        }
    }

}
