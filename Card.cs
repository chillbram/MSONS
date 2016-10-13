using System;
using System.Windows.Forms;

namespace Lab3
{
	public interface ICard : PaymentMethod
	{
        bool EndTransaction(int id);
        void CancelTransaction(int id);
    }

	// Mock CreditCard implementation
	public class CreditCard : ICard
	{
		public void Connect ()
		{
			MessageBox.Show ("Connecting to credit card reader");
		}

		public void Disconnect ()
		{
			MessageBox.Show ("Disconnecting from credit card reader");
		}

		public int BeginTransaction (float amount)
		{
            // Add the CreditCard fee of €0.50 to the total price
            float totalPrice = amount + 0.5f;
			MessageBox.Show ("Begin transaction 1 of " + totalPrice + " EUR");
			return 1;
		}

		public bool EndTransaction (int id)
		{
			if (id != 1)
				return false;

			MessageBox.Show("End transaction 1");
			return true;
		}

		public void CancelTransaction (int id)
		{
			if (id != 1)
				throw new Exception ("Incorrect transaction id");

			MessageBox.Show("Cancel transaction 1");
		}
	}

	// Mock CreditCard implementation
	public class DebitCard : ICard
	{
		public void Connect ()
		{
			MessageBox.Show ("Connecting to debit card reader");
		}

		public void Disconnect ()
		{
			MessageBox.Show ("Disconnecting from debit card reader");
		}

		public int BeginTransaction (float amount)
		{
			MessageBox.Show ("Begin transaction 1 of " + amount + " EUR");
			return 1;
		}

		public bool EndTransaction (int id)
		{
			if (id != 1)
				return false;

			MessageBox.Show("End transaction 1");
			return true;
		}

		public void CancelTransaction (int id)
		{
			if (id != 1)
				throw new Exception ("Incorrect transaction id");

			MessageBox.Show("Cancel transaction 1");
		}
	}
}

