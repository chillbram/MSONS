using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    public abstract class Discount
    {
        // The name that should be displayed on screen
        protected abstract string discountName();
        public virtual string getDiscountName()
        { return discountName(); }
        protected abstract decimal discountPercentage();
        public virtual decimal getDiscountPercentage()
        { return discountPercentage(); }
    }
    public class NoDiscount : Discount
    {
        protected override string discountName() { return "No discount"; }
        protected override decimal discountPercentage()
        { return 0; }
    }
    public class TwentyDiscount : Discount
    {
        protected override string discountName() { return "20% discount"; }
        protected override decimal discountPercentage()
        { return 20m; }
    }
    public class FortyDiscount : Discount
    {
        protected override string discountName() { return "40% discount"; }
        protected override decimal discountPercentage()
        { return 40m; }
    }
}
