using System.ComponentModel;

namespace It4SolutionCodeFirst.Models
{
    public class Category
    {
        public int Id { get; set; }

        [DisplayName("Category")]
        public string Name { get; set; }
    }
}