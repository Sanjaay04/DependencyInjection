using DependencyInjection.Interface;

namespace DependencyInjection.Service
{
    public class discountservice:Idiscount
    {
        private readonly Guid _instantid;
        public discountservice()
        {
            _instantid = Guid.NewGuid(); 
        }
        public decimal ApplyDiscount(decimal price)
        {
            Console.WriteLine($"DiscountService Instance: {_instantid}");
            return price * 0.9m; // 10% discount
        }
    }
}
