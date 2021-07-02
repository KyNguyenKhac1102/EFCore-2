using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EFCore4.Models
{
    [Table("Products")]
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int ProductId { get; set; }
        
        public string ProductName { get; set; }
        
        public string Manifacture {get; set;}
        public int CategoryId {get; set;}
        public Category Category {get; set;}
    }
}