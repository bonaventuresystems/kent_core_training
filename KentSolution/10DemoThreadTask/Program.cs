using System.Diagnostics;

namespace _10DemoThreadTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Explicit Parallel Programming 
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();

            ////List<Thread> threads = new List<Thread>();  

            ////for (int i = 0; i < 100; i++)
            ////{
            ////    Thread thread = new Thread(Complex);
            ////    threads.Add(thread);
            ////    thread.Start();
            ////}

            ////foreach (var thread in threads)
            ////{
            ////    thread.Join();
            ////}


            //List<Task> tasks = new List<Task>();

            //for (int i = 0; i < 100; i++)
            //{
            //    Task task = new Task(Complex);
            //    tasks.Add(task);
            //    task.Start();
            //}

            //Task.WaitAll(tasks.ToArray());

            //stopwatch.Stop();
            //Console.WriteLine("Time taken = {0}", stopwatch.ElapsedMilliseconds);


            //Console.WriteLine("Done");
            #endregion

            #region Implicit Parallel Programming

            #region Parallel For / ForEach

            string path = "C:\\Windows\\System32";
            string[] allFiles = Directory.GetFiles(path);

            //Parallel.ForEach(allFiles, file => {
            //    if (file.Contains(".msc"))
            //    {
            //        Console.WriteLine(file);
            //    }
            //});

            //foreach (string file in allFiles)
            //{
            //    if (file.Contains(".msc"))
            //    {
            //        Console.WriteLine(file);
            //    }
            //}

            //var result = (from file in allFiles
            //             where file.Contains(".msc")
            //             select file).ToList();

            //Console.WriteLine(result.Count);



            //var result = (from file in allFiles.AsParallel()
            //              where file.Contains(".msc")
            //              select file).ToList();

            //Console.WriteLine(result.Count);



            #endregion
            #endregion
            
            Console.ReadLine();
        }

        public static void Complex()
        {
          // Console.WriteLine("Thread ID = {0}", Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 10000; i++) { 
                for (int j = 0; j < 10000; j++) { 
                    
                }
            }
        }
    }
}
