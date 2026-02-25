using System.Data;

namespace _11DemoLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var emps = new List<Emp>() { 
             new Emp(){  No = 1 , Name = "ABC11", DNo = 100},
             new Emp(){  No = 2 , Name = "ABC12", DNo = 100},
             new Emp(){  No = 3 , Name = "ABC13", DNo = 200},
             new Emp(){  No = 4 , Name = "ABC14", DNo = 300},
             new Emp(){  No = 5 , Name = "ABC15", DNo = 300}
            };
            var depts = new List<Dept> { 
             new Dept (){ DeptNo = 100, DName = "IT" },
            new Dept (){ DeptNo = 200, DName = "HR" },
            new Dept (){ DeptNo = 300, DName = "Admin" }
            };

            //var result = from emp in emps
            //             from dept in depts
            //             where emp.DNo == dept.DeptNo
            //             select new ResultHolder() { ENo = emp.No, EName = emp.Name, DName = dept.DName };


            //var result = (from emp in emps
            //              from dept in depts
            //              where emp.DNo == dept.DeptNo
            //              select new { ENo = emp.No, EName = emp.Name, DName = dept.DName })
            //             ;// .Where(e => { return e.ENo > 2; });

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.ENo + " - " + item.EName + " - " + item.DName);
            //}

            // var result = emps.Where(emp => { return emp.DNo > 100; }).Select(emp => emp.Name);

            //var v = new { No = 10, Name = "abc" };
            //v.Name = "xyz";

            //DataSet ds = new DataSet();
            //DataTable tab = new DataTable();
            //ds.Tables.Add(tab)

        }

        //public static Emp CallThisInWhere(dynamic)???
        //{
        //    return null
        //}

    }

    //public class ResultHolder
    //{
    //    public int ENo { get; set; }
    //    public string EName { get; set; }
    //    public string DName { get; set; }
    //}

    public class Emp
    {
        public int No { get; set; }
        public string Name { get; set; }

        public int DNo { get; set; }
    }

    public class Dept
    {
        public int DeptNo { get; set; }
        public string DName { get; set; }
    }
}
