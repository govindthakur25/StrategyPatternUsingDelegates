using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class PizzaOrderingSystem
    {
        private readonly DiscountPoilcy _discountPoilcy;

        public PizzaOrderingSystem(DiscountPoilcy discountPoilcy)
        {
            _discountPoilcy = discountPoilcy;
        }

        public decimal CalculatePrice(PizzaOrder order)
        {
            decimal actualPrice = order.Pizzas.Sum(p => p.Price);
            decimal discountedPrice = _discountPoilcy(order);

            return actualPrice - discountedPrice;
        }
    }
}
