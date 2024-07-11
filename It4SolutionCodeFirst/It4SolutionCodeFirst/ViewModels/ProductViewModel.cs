using It4SolutionCodeFirst.Models;
using System.Collections.Generic;

namespace It4SolutionCodeFirst.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}