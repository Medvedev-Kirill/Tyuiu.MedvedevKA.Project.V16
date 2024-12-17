using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tyuiu.MedvedevKA.Project.V16.Data.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string NameProduct { get; set; } = ""; // Указываем значение по умолчанию
        public string Description { get; set; } = "";
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; } = ""; //  Единица измерения (шт., кг., и т.д.)
        public string Category { get; set; } = ""; //  Категория товара
    }

    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string MiddleName { get; set; } = "";
        public string Position { get; set; } = "";
    }

    public enum OperationType
    {
        Принесли,
        Унесли,
        Перенесли
    }


    public class Operation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public OperationType OperationType { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Количество должно быть больше 0")]
        public int Quantity { get; set; }
        public virtual Product NameProduct { get; set; } = null!;
        public virtual Employee Employee { get; set; } = null!;
    }

    public class Sale
    {
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime SaleDate { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; } 

        public Product Product { get; set; } = null!;
        public Employee Employee { get; set; } = null!;
    }
}
