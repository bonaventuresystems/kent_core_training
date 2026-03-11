using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;

using Hr.Entities;

var emp = new Employee
{
    Id = 1,
    Name = "John Doe",
    Position = "Software Engineer",
    Salary = 75000.00
};

// Serialize to byte array
byte[] serializedEmp = emp.ToByteArray();
// File.Create("employee.bin").Write(serializedEmp, 0, serializedEmp.Length);




// Deserialize from byte array
var deserializedEmp = Employee.Parser.ParseFrom(serializedEmp);

Console.WriteLine($"ID: {deserializedEmp.Id}");
Console.WriteLine($"Name: {deserializedEmp.Name}");
Console.WriteLine($"Position: {deserializedEmp.Position}");
Console.WriteLine($"Salary: {deserializedEmp.Salary}");

