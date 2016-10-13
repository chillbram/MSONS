using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    class PricingCalculator
    {
        
        public static decimal calculatePrice(UIInfo info)
        {
            PricingCalculator pc = new PricingCalculator();

            decimal routePrice = pc.calcTariefeenheden(info) * .02m * info.Class.getClassPrice();

            decimal discountMultiplier = (100 - info.Discount.getDiscountPercentage()) / 100;
            decimal priceMultipliers = discountMultiplier * info.Way.getTicketMultiplier();

            // Get price of the travel
            decimal totalPrice = routePrice * priceMultipliers;

            // Round the total price and return the output
            totalPrice = Math.Round(totalPrice, 2);
            return totalPrice;
        }
        private int calcTariefeenheden(UIInfo info)
        {
            int tariefeenheden = new int();
            if (info.From.stationID() < info.To.stationID())
            {
                tariefeenheden = Station.getTariefeenheden(info.To, info.From);
            }
            else
            {
                tariefeenheden = Station.getTariefeenheden(info.From, info.To);
            }
            return tariefeenheden;
        }
    }
}
