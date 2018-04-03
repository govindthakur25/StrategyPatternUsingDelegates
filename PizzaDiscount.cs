using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public delegate decimal DiscountPoilcy(PizzaOrder order);

    public static class Policies
    {
        public static decimal BuyOneGetOneFree(PizzaOrder order)
        {
            var pizzas = order.Pizzas;
            if (pizzas.Count < 2) return 0m;

            return pizzas.Min(p => p.Price);
        }

        public static decimal FivePercentOffMoreThanFiftyDollars(PizzaOrder order)
        {
            decimal nonDiscounted = order.Pizzas.Sum(p => p.Price);
            return nonDiscounted > 50 ? nonDiscounted * 0.05m : 0m;
        }

        public static decimal FiveDollarsOffStuffedCrust(PizzaOrder order)
        {
            return order.Pizzas.Sum(p => p.Crust == Crust.STUFFED ? 5m : 0m);
        }

        public static DiscountPoilcy CreateBest(params DiscountPoilcy[] discountPoilcies)
        {
            return order => discountPoilcies.Max(policy => policy.Invoke(order));
        }

        public static DiscountPoilcy DiscountAllPizza()
        {
            return CreateBest(BuyOneGetOneFree, FiveDollarsOffStuffedCrust, FivePercentOffMoreThanFiftyDollars);
        }
    }

    public class BestOffer
    {
        private IEnumerable<DiscountPoilcy> _discountPoilcies;

        public BestOffer(IEnumerable<DiscountPoilcy> discountPoilcies)
        {
            _discountPoilcies = discountPoilcies;
        }

        public decimal ComputePolicy(PizzaOrder order)
        {
            return _discountPoilcies.Max(policy => policy.Invoke(order));
        }
    }
}
