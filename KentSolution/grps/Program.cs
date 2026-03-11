
using Employees;
using Google.Protobuf;

var emp = new Employee();
emp.Id = 10;
emp.Name = "ABC";
emp.Position = "HR";
emp.Salary = 10000;



// Serialize to byte array
byte[] serializedEmp = emp.ToByteArray();
// File.Create("employee.bin").Write(serializedEmp, 0, serializedEmp.Length);




// Deserialize from byte array
var deserializedEmp = Employee.Parser.ParseFrom(serializedEmp);

Console.WriteLine($"ID: {deserializedEmp.Id}");
Console.WriteLine($"Name: {deserializedEmp.Name}");
Console.WriteLine($"Position: {deserializedEmp.Position}");
Console.WriteLine($"Salary: {deserializedEmp.Salary}");



