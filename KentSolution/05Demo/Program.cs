using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace _05Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Simple Reflection
            //string path = "D:\\Kent Training\\kent_core_training\\KentSolution\\MathsLib\\bin\\Debug\\net8.0\\MathsLib.dll";

            //Assembly assembly = Assembly.LoadFrom(path);
            //Type[] types = assembly.GetTypes();

            //foreach (Type t in types)
            //{
            //    Console.WriteLine(t.FullName);

            //    MethodInfo[] methods = t.GetMethods();

            //    foreach (MethodInfo m in methods)
            //    {
            //       Console.Write( " - " + m.Name + " (");

            //       ParameterInfo[] allParams =   m.GetParameters();

            //        foreach (var para in allParams)
            //        {
            //            Console.Write(para.ParameterType.ToString() + " "  + para.Name + " ");
            //        }

            //        Console.Write(" ) ");

            //        Console.WriteLine(  );
            //    }


            //} 
            #endregion

            #region Reflection - II

            string path = "D:\\Kent Training\\kent_core_training\\KentSolution\\MathsLib\\bin\\Debug\\net8.0\\MathsLib.dll";

            Assembly assembly = Assembly.LoadFrom(path);
            Type[] types = assembly.GetTypes();

            foreach (Type t in types)
            {

                var attributes = t.GetCustomAttributes();
                bool isSerializable = false;
                foreach (var attribute in attributes)
                {
                    if (attribute is SerializableAttribute)
                    {
                        isSerializable = true;
                        break;
                    }
                }

                if (isSerializable) {
                    Console.WriteLine(t.FullName + " is serializable");
                }
                else
                {
                    Console.WriteLine(t.FullName + " is - NOT - serializable");
                }

                object dynamicObjectOfSomeType = assembly.CreateInstance(t.FullName);
                Console.WriteLine(t.FullName + " type object is created.");

                MethodInfo[] methods = t.GetMethods();

                foreach (MethodInfo m in methods)
                {
                    Console.WriteLine(" - calling method " + m.Name);


                    ParameterInfo[] allParams = m.GetParameters();
                    object[] parameters = new object[allParams.Length];

                    for (int i = 0; i < allParams.Length; i++)
                    {
                        ParameterInfo parameter = allParams[i];
                        
                        Console.WriteLine("Please enter value for {0} of type {1}", parameter.Name, parameter.ParameterType.ToString());

                        parameters[i] =
                        Convert.ChangeType(Console.ReadLine(), parameter.ParameterType);
                    }

                    object output =  t.InvokeMember(m.Name,BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod,null,dynamicObjectOfSomeType,parameters);

                    Console.WriteLine("Result of {0} method is = {1}", m.Name, output);

                    Console.WriteLine();
                    Console.ReadLine();
                }


            }

            #endregion

            Console.ReadLine();
        }
    }
}
