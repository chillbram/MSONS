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

            // Calculate the discount multiplier 
            decimal discountMultiplier = (100 - info.Discount.getDiscountPercentage()) / 100;

            // Calculate the class price with the discount rounded to ten cents 
            decimal price = info.Class.getClassPrice() * discountMultiplier;
            price = Math.Round(price, 1);

            // Multiply with the Route distance (tariefeenheden) with the constant multiplier of 0.02
            price = pc.calcTariefeenheden(info) * .02m * price;

            // Get price of the travel
            price = price * info.Way.getTicketMultiplier();

            // Add a supplementary charge for international travel
            if(info.To.isInternational() == true || info.From.isInternational() == true)
            {
                price = price + 2;
            }

            // Round the total price, so it will return with 2 digits, and return the output
            price = Math.Round(price, 2);
            return price;
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
