using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    public interface PaymentMethod
    {
        void Connect();
        void Disconnect();
        int BeginTransaction(float amount);
    }
    
}
