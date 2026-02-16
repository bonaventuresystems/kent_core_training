
namespace AttributesLIB
{
    [AttributeUsage(AttributeTargets.Class)]
    public class Table : Attribute
    {
        public string TableName { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class Column :Attribute
    {
        public string ColumnName { get; set; }
        public string ColumnType { get; set; }
    }


}
