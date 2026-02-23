namespace _09DemoBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Emp> emps = new List<Emp>() 
            {
                new Emp(){ No = 11, Name = "Sachin1", Address = "Pune1"  },
                 new Emp(){ No = 12, Name = "Sachin2", Address = "Pune2"  },
                  new Emp(){ No = 13, Name = "Sachin3", Address = "Pune3"  },
                   new Emp(){ No = 14, Name = "Sachin4", Address = "Pune4"  },
                    new Emp(){ No = 15, Name = "Sachin5", Address = "Pune5"  },
                     new Emp(){ No = 16, Name = "Sachin6", Address = "Pune6"  },
                      new Emp(){ No = 17, Name = "Sachin7", Address = "Pune7"  },
                       new Emp(){ No = 18, Name = "Sachin8", Address = "Pune8"  },
            };

            //List<Emp> result = new List<Emp>();
            //foreach (var emp in emps)
            //{
            //    if (emp.No > 15)
            //    {
            //        result.Add(emp);
            //    }
            //}

            //var result = (from emp in emps
            //              where emp.No > 15
            //              select emp);//.ToList();

            var result = emps.Where((emp) => { return emp.No > 15; })
                             .Select(emp => emp.Name)
                             .ToList();

            Console.WriteLine("Result is ");

            emps.Add(new Emp() { No = 30, Name = "abc", Address = "Chennai" });
            
            foreach (var item in result)
            {
                Console.WriteLine( item);
                //Console.WriteLine(item.No + item.Name);
            }

            Console.ReadLine();

        }
    }

    public class Emp
    {
        public int No { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
