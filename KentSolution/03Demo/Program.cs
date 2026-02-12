namespace _03Demo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1: SQL, 2: Oracle");
            int choice = int.Parse(Console.ReadLine());
            Database db = DBFactory.GetDatabase(choice);

            //db.OnInsert += mail_OnDBInsert;
            db.OnInsert += Logger.CurrentLogger.Log;

            db.PerformInsert();
            Console.ReadLine();
        }

        private static void mail_OnDBInsert(string message)
        {
            Console.WriteLine("Mailed " + message);
        }
    }

    public class DBFactory
    {
        public static Database GetDatabase(int dbType)
        {
            if (dbType ==1 )
                return new SQLServer();
            else if (dbType == 2)
                return new Oracle();
            else
                throw new Exception("Invalid database type");
        }
    }


    public abstract class Database
    {
        public event LogHandler OnInsert;
        public event LogHandler OnUpdate;
        public event LogHandler OnDelete;
        protected abstract void Insert();
        protected abstract void Update();
        protected abstract void Delete();
        protected abstract string GetDBName();

        private string _DbName = "DB";

        public Database()
        {
            _DbName = GetDBName();
        }
        public void PerformInsert()
        {
            Insert();
            OnInsert("Logged " + _DbName +  "Insert");
        }
        public void PerformUpdate()
        {
            Update();
            OnInsert("Logged " + _DbName + "Update");
        }
        public void PerformDelete()
        {
            Delete();
            OnInsert("Logged " + _DbName + "Delete");
        }
    }

    public delegate void LogHandler(string message);

    public class SQLServer: Database
    {

        protected override string GetDBName()
        {
            return "SQL";
        }
        protected override void Insert()
        {
            Console.WriteLine("SQL Server Insert");
        }
        protected override void Update() 
        { 
            Console.WriteLine("SQL Server Update");
        }

        protected override void Delete() 
        {
            Console.WriteLine("SQL Server Delete");
        }
    }


    public class Oracle : Database
    {
        protected override string GetDBName()
        {
            return "Oracle";
        }
        protected override void Insert()
        {
            Console.WriteLine("Oracle Server Insert");
        }
        protected override void Update()
        {
            Console.WriteLine("Oracle Server Update");
        }

        protected override void Delete()
        {
            Console.WriteLine("Oracle Server Delete");
        }
    }

    public class Logger
    {
        private static Logger logger = new Logger();
        private Logger()
        {
        }
        public static Logger CurrentLogger
        {
            get { return logger; }
        }

        public void Log(string message)
        {
            Console.WriteLine("Loggged at " + DateTime.Now.ToString() + ": " + message);
        }
    }

}
