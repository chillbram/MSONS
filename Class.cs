using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    public abstract class Class
    {
        public abstract string className();
        public virtual string getClassName()
        { return className(); }
        protected abstract decimal classPrice(); // Price that needs to be added to the ticket price depending on the chosen class (in Euros ∴ 1.5m = €1,50)
        public virtual decimal getClassPrice()
        { return classPrice(); }
    }

    public class FirstClass : Class
    {
        public override string className()
        { return "First class"; }
        protected override decimal classPrice()
        { return 3.6m; }
    }

    public class SecondClass : Class
    {
        public override string className()
        { return "Second class"; }

        protected override decimal classPrice()
        { return 2.1m; }
    }
}
