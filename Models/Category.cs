using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore4.Models
{
    [Table("Category")]
    public class Category{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int CategoryId {get; set;}
        public string CategoryName {get; set;}

        public List<Product> Product {get; set;}
    }
}