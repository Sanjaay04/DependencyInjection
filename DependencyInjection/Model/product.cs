using System.ComponentModel.DataAnnotations;

namespace DependencyInjection.Model
{
    public class product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
