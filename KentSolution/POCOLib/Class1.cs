using AttributesLIB;

namespace POCOLib
{
    [Table(TableName = "Employee")]
    public class Emp
    {
        [Column(ColumnName ="No", ColumnType = "int")]
        public int No { get; set; }

        [Column(ColumnName = "Name", ColumnType = "varchar(50)")]
        public string Name { get; set; }

        [Column(ColumnName = "Address", ColumnType = "varchar(50)")]
        public string Address { get; set; }
    }

    [Table(TableName = "Customer")]
    public class Customer
    {
        [Column(ColumnName = "No", ColumnType = "int")]
        public int No { get; set; }

        [Column(ColumnName = "Name", ColumnType = "varchar(50)")]
        public string Name { get; set; }

        [Column(ColumnName = "Address", ColumnType = "varchar(50)")]
        public string Address { get; set; }
    }
}
