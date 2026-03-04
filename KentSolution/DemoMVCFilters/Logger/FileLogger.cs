namespace DemoMVCFilters.Logger
{
    public class FileLogger
    {
        private static FileLogger fileLogger =
            new FileLogger();
        private FileLogger()
        {
        }


        public static FileLogger CurrentLogger
        {
            get { return fileLogger; }
        }

        public void Log(string message)
        {
            string path = "D:\\Kent Training\\kent_core_training\\KentSolution\\Log\\log.txt";

            FileStream fileStream = null;

            if (File.Exists(path))
            {
                fileStream = new FileStream(path, FileMode.Append, FileAccess.Write);   
            }
            else
            {
                fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            }

            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine("Logged at : " + DateTime.Now.ToString() + " - " +  message);
            streamWriter.Close();
            fileStream.Close();
        }

    }
}
