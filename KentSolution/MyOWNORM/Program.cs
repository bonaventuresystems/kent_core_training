using System.Reflection;
using AttributesLIB;
namespace MyOWNORM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileStream fileStream = new FileStream("D:\\Kent Training\\kent_core_training\\KentSolution\\queries.sql", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);

            string path = "D:\\Kent Training\\kent_core_training\\KentSolution\\POCOLib\\bin\\Debug\\net8.0\\POCOLib.dll";

            Assembly assembly = Assembly.LoadFrom(path);

            Type[] types = assembly.GetTypes();
            string query = "";

            foreach (Type type in types)
            {
                //Console.WriteLine(type.FullName);

                var attributesOnType = type.GetCustomAttributes();
                foreach (var attributeOnType in attributesOnType)
                {
                    if (attributeOnType is Table)
                    {
                        Table tableDetails = (Table)attributeOnType;
                        query = query + " create table " + tableDetails.TableName + "(";
                        //Console.WriteLine(query);
                        break;
                    }   
                }

                PropertyInfo[] allProps = type.GetProperties();

                foreach (var property in allProps)
                {
                    var attributesOnProperty = property.GetCustomAttributes();

                    foreach (var attributeOnProperty in attributesOnProperty)
                    {
                        if (attributeOnProperty is Column)
                        {
                            Column columnDetail =   (Column)attributeOnProperty;
                            query = query + " " + columnDetail.ColumnName + " " + 
                                    columnDetail.ColumnType + ",";
                            break;
                        }
                    }
                }

                query = query.TrimEnd(',');
                query = query + " )";



            }
    
            streamWriter.WriteLine(query);
            streamWriter.Close();
            fileStream.Close();
            Console.ReadLine();
        }
    }
}
