using System;
using System.Windows.Forms;

namespace Lab3
{
    class CoinMachine : PaymentMethod
    {
        private IKEAMyntAtare2000 machine = new IKEAMyntAtare2000();
        public void Connect()
        {
            machine.starta();
        }

        public void Disconnect()
        {
            machine.stoppa();
        }

        public int BeginTransaction(float amount)
        {
            int priceInt = (int)Math.Round(amount, 2) * 100;
            machine.betala(priceInt);
            return 1;
        }
        
    }

	public class IKEAMyntAtare2000
	{
		public void starta()
		{
			MessageBox.Show ("Välkommen till IKEA Mynt Ätare 2000");
		}

		public void stoppa()
		{
			MessageBox.Show ("Hejdå!");
		}

		public void betala(int pris)
		{
			MessageBox.Show (pris + " cent");
		}
	}
}
