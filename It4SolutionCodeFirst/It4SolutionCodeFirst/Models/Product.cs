using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace It4SolutionCodeFirst.Models
{
    public class Product
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter name of a product")]
        [StringLength(50)]
        public string Name { get; set; }

        public decimal price { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        //foriegn key
        [DisplayName("Category")]
        public int CategoryId { get; set; }

        //load products with teir category
        public Category Category { get; set; }
    }
}