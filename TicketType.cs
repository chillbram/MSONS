using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    public abstract class TicketType
    {
        protected abstract string ticketName();
        public virtual string getTicketName()
        { return ticketName(); }
        protected abstract decimal ticketMultiplier();
        public virtual decimal getTicketMultiplier()
        {
            return ticketMultiplier();
        }
    }
    
    public class OneWay : TicketType
    {
        protected override string ticketName()
        { return "One way"; }
        protected override decimal ticketMultiplier()
        { return 1; }
    }
    public class Return : TicketType
    {
        protected override string ticketName()
        { return "Return"; }
        protected override decimal ticketMultiplier()
        { return 2; }
    }
}
