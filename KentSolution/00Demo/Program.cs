using Microsoft.Data.SqlClient;
namespace _00Demo
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Basics - 1
            //int i = Convert.ToInt32(Console.ReadLine());
            //int j = Convert.ToInt32(Console.ReadLine());

            //int result = i + j;
            //Console.WriteLine(result);
            //Console.ReadLine();
            #endregion

            Console.WriteLine("1. PDF, 2: DOCX");
            Report report = ReportFactory.GetReport(Convert.ToInt32(Console.ReadLine()));
            report.GenerateReport();



            Console.ReadLine();
        }


    }

    public class ReportFactory
    {
        public static Report GetReport(int reportType)
        {
            if (reportType == 1)
            {
                return new PDF();
            }
            else if (reportType == 2)
            {
                return new Docx();
            }
            else if (reportType == 3)
            {
                return new XML();
            }   
            else
            {
                throw new Exception("Invalid Report Type");
            }
        }
    }

    public abstract class Report
    {
        protected abstract void Create();
        protected abstract void Parse();
        protected abstract void Validate();
        protected abstract void Save();
        public virtual void GenerateReport()
        {
            Create();
            Parse();
            Validate();
            Save();
        }
    }


    public abstract class SpecialReport : Report
    {
        protected abstract void ReValidate();
        public override void GenerateReport()
        {
            Create();
            Parse();
            Validate();
            ReValidate();
            Save();
        }
    }

    public class XML : SpecialReport
    {
        protected override void Create()
        {
            Console.WriteLine("XML Created ");
        }
        protected override void Parse()
        {
            Console.WriteLine("XML Parsed ");
        }
        protected override void Validate()
        {
            Console.WriteLine("XML Validated ");
        }

        protected override void ReValidate()
        {
            Console.WriteLine("XML Revalidated");
        }
        protected override void Save()
        {
            Console.WriteLine("XML Saved ");
        }


    }

    public class PDF : Report
    {
        protected override void Create()
        {
            Console.WriteLine("PDF Created ");
        }
        protected override void Parse()
        {
            Console.WriteLine("PDF Parsed ");
        }
        protected override void Validate()
        {
            Console.WriteLine("PDF Validated ");
        }
        protected override void Save()
        {
            Console.WriteLine("PDF Saved ");
        }

     
    }

    public class Docx : Report
    {
        protected override void Create()
        {
            Console.WriteLine("Docx Created ");
        }
        protected override void Parse()
        {
            Console.WriteLine("Docx Parsed ");
        }
        protected override void Validate()
        {
            Console.WriteLine("Docx Validated ");
        }
        protected override void Save()
        {
            Console.WriteLine("Docx Saved ");
        }

    }
}
