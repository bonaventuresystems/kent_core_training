using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoEFMVC.Models
{
    [Table("Trainer")]
    public class Trainer
    {
        [Key]
        //[Column("TrainerID", TypeName = "int")]
        public int TrainerID { get; set; }

        [Column("Name", TypeName = "varchar")]
        [StringLength(50)]
        public string Name { get; set; }

        public List<Subject> Subjects { get; set; }

    }

    [Table("Subject")]
    public class Subject
    {
        [Key]
        [Column("SubjecID", TypeName = "int")]
        public int SubjecID { get; set; }

        [Column("Title", TypeName = "varchar")]
        [StringLength(50)]
        public string Title { get; set; }

        public List<Trainer> Trainers { get; set; }
    }

    [Table("Emp")]
    [MetadataType(typeof(PocoValidation))]
    public partial class Emp
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("No", TypeName = "int")]
        public int No { get; set; }

        [Column("Name", TypeName = "varchar")]
        [StringLength(50)]
        //[Required(ErrorMessage = "Name is requied!")]
        public string Name { get; set; }

        [Column("Age", TypeName = "int")]
        public int Age { get; set; }

        [Column("Address", TypeName = "varchar")]
        [StringLength(50)]
       // [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
    }

    public partial class KentContext
    {
        public DbSet<Emp> Emps { get; set; }

        public DbSet<Trainer> Trainers { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Kent;Integrated Security=True;");
        }
    }

    public class KentValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value!=null && value.ToString() == "1234")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
