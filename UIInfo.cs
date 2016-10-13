using System;

namespace Lab3
{
	public enum UIPayment
	{
		DebitCard,
		CreditCard,
		Cash
	}

	public struct UIInfo
	{
		Station from, to;
		Class cls;
		TicketType way;
		Discount discount;
		PaymentMethod payment;

		public UIInfo (Station from, Station to, Class cls, TicketType way, Discount discount, PaymentMethod payment)
		{
			this.from = from;
			this.to = to;
			this.cls = cls;
			this.way = way;
			this.discount = discount;
			this.payment = payment;
		}

		public Station From {
			get {
				return from;
			}
		}

		public Station To {
			get {
				return to;
			}
		}

		public Class Class {
			get {
				return cls;
			}
		}

		public TicketType Way {
			get {
				return way;
			}
		}

		public Discount Discount {
			get {
				return discount;
			}
		}

		public PaymentMethod Payment {
			get {
				return payment;
			}
		}
	}
}

