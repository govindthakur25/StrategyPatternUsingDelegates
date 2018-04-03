using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            PizzaOrder order = new PizzaOrder();
            order.Pizzas = new List<Pizza> {
                                                new Pizza { Size = Size.LARGE, Crust = Crust.STUFFED, Price = 18.25m },
                                                new Pizza { Size = Size.MEDIUM, Crust = Crust.THIN, Price = 18.25m }
                                           };
            PizzaOrderingSystem prepareOrder = new PizzaOrderingSystem(Policies.BuyOneGetOneFree);
            Console.WriteLine(prepareOrder.CalculatePrice(order).ToString());
            Console.Read();
        }
    }
}
