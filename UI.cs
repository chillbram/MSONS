using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace Lab3
{
	public class UI : Form
	{
		ComboBox fromBox;
		ComboBox toBox;
		RadioButton firstClass;
		RadioButton secondClass;
		RadioButton oneWay;
		RadioButton returnWay;
		RadioButton noDiscount;
		RadioButton twentyDiscount;
		RadioButton fortyDiscount;
		ComboBox payment;
		Button pay;
        GroupBox discountGroup;
        GroupBox wayGroup;
        GroupBox classGroup;

        public UI ()
		{
            initializeControls ();
		}

        private void handlePrice(UIInfo info)
        {
            // Handle calculation of the price
            decimal price = PricingCalculator.calculatePrice(info);

            // Handle payment of the user
            handlePayment(info, (float)price);
        }

        private void handlePayment(UIInfo info, float price)
        {
            info.Payment.Connect();
            info.Payment.BeginTransaction(price);
            info.Payment.Disconnect();
        }

#region Set-up -- don't look at it
		private void initializeControls()
		{
			// Set label
			this.Text = "MSO Lab Exercise III";
			// this.FormBorderStyle = FormBorderStyle.FixedSingle;
			this.Width = 500;
			this.Height = 210;
			// Set layout
			var grid = new TableLayoutPanel ();
			grid.Dock = DockStyle.Fill;
			grid.Padding = new Padding (5);
			this.Controls.Add (grid);
			grid.RowCount = 4;
			grid.RowStyles.Add (new RowStyle (SizeType.Absolute, 20));
			grid.RowStyles.Add (new RowStyle (SizeType.Percent, 100));
			grid.RowStyles.Add (new RowStyle (SizeType.Absolute, 20));
			grid.RowStyles.Add (new RowStyle (SizeType.Absolute, 40));
			grid.ColumnCount = 6;
			for (int i = 0; i < 6; i++)
			{
				ColumnStyle c = new ColumnStyle (SizeType.Percent, 16.66666f);
				grid.ColumnStyles.Add (c);
			}
			// Create From and To
			var fromLabel = new Label ();
			fromLabel.Text = "From:";
			fromLabel.TextAlign = ContentAlignment.MiddleRight;
			grid.Controls.Add (fromLabel, 0, 0);
			fromLabel.Dock = DockStyle.Fill;
			fromBox = new ComboBox ();
			fromBox.DropDownStyle = ComboBoxStyle.DropDownList;
			fromBox.Items.AddRange (Station.getStationNames());
			fromBox.SelectedIndex = 0;
			grid.Controls.Add (fromBox, 1, 0);
			grid.SetColumnSpan (fromBox, 2);
			fromBox.Dock = DockStyle.Fill;
			var toLabel = new Label ();
			toLabel.Text = "To:";
			toLabel.TextAlign = ContentAlignment.MiddleRight;
			grid.Controls.Add (toLabel, 3, 0);
			toLabel.Dock = DockStyle.Fill;
			toBox = new ComboBox ();
			toBox.DropDownStyle = ComboBoxStyle.DropDownList;
			toBox.Items.AddRange (Station.getStationNames());
			toBox.SelectedIndex = 0;
			grid.Controls.Add (toBox, 4, 0);
			grid.SetColumnSpan (toBox, 2);
			toBox.Dock = DockStyle.Fill;
			// Create groups
			classGroup = new GroupBox ();
			classGroup.Text = "Class";
			classGroup.Dock = DockStyle.Fill;
			grid.Controls.Add (classGroup, 0, 1);
			grid.SetColumnSpan (classGroup, 2);
			var classGrid = new TableLayoutPanel ();
			classGrid.RowStyles.Add (new RowStyle (SizeType.Percent, 50));
			classGrid.RowStyles.Add (new RowStyle (SizeType.Percent, 50));
			classGrid.Dock = DockStyle.Fill;
			classGroup.Controls.Add (classGrid);
			wayGroup = new GroupBox ();
			wayGroup.Text = "Amount";
			wayGroup.Dock = DockStyle.Fill;
			grid.Controls.Add (wayGroup, 2, 1);
			grid.SetColumnSpan (wayGroup, 2);
			var wayGrid = new TableLayoutPanel ();
			wayGrid.RowStyles.Add (new RowStyle (SizeType.Percent, 50));
			wayGrid.RowStyles.Add (new RowStyle (SizeType.Percent, 50));
			wayGrid.Dock = DockStyle.Fill;
			wayGroup.Controls.Add (wayGrid);
			discountGroup = new GroupBox ();
			discountGroup.Text = "Discount";
			discountGroup.Dock = DockStyle.Fill;
			grid.Controls.Add (discountGroup, 4, 1);
			grid.SetColumnSpan (discountGroup, 2);
			var discountGrid = new TableLayoutPanel ();
			discountGrid.RowStyles.Add (new RowStyle (SizeType.Percent, 33.33333f));
			discountGrid.RowStyles.Add (new RowStyle (SizeType.Percent, 33.33333f));
			discountGrid.RowStyles.Add (new RowStyle (SizeType.Percent, 33.33333f));
			discountGrid.Dock = DockStyle.Fill;
			discountGroup.Controls.Add (discountGrid);
			// Create radio buttons
			firstClass = new RadioButton ();
			firstClass.Text = "First class";
			firstClass.Checked = true;
			classGrid.Controls.Add (firstClass);
			secondClass = new RadioButton ();
			secondClass.Text = "Second class";
			classGrid.Controls.Add (secondClass);
			oneWay = new RadioButton ();
			oneWay.Text = "One way";
			oneWay.Checked = true;
			wayGrid.Controls.Add (oneWay);
			returnWay = new RadioButton ();
			returnWay.Text = "Return";
			wayGrid.Controls.Add (returnWay);
			noDiscount = new RadioButton ();
			noDiscount.Text = "No discount";
			noDiscount.Checked = true;
			discountGrid.Controls.Add (noDiscount);
			twentyDiscount = new RadioButton ();
			twentyDiscount.Text = "20% discount";
			discountGrid.Controls.Add (twentyDiscount);
			fortyDiscount = new RadioButton ();
			fortyDiscount.Text = "40% discount";
			discountGrid.Controls.Add (fortyDiscount);
			// Payment option
			Label paymentLabel = new Label ();
			paymentLabel.Text = "Payment by:";
			paymentLabel.Dock = DockStyle.Fill;
			paymentLabel.TextAlign = ContentAlignment.MiddleRight;
			grid.Controls.Add (paymentLabel, 0, 2);
			payment = new ComboBox ();
			payment.DropDownStyle = ComboBoxStyle.DropDownList;
			payment.Items.AddRange (new String[] { "Credit card", "Debit card", "Cash" });
			payment.SelectedIndex = 0;
			payment.Dock = DockStyle.Fill;
			grid.Controls.Add (payment, 1, 2);
			grid.SetColumnSpan (payment, 5);
			// Pay button
			pay = new Button ();
			pay.Text = "Pay";
			pay.Dock = DockStyle.Fill;
			grid.Controls.Add (pay, 0, 3);
			grid.SetColumnSpan (pay, 6);
			// Set up event
			pay.Click += (object sender, EventArgs e) => handlePrice(getUIInfo());
		}

		private UIInfo getUIInfo()
		{
            Class cls;
            if (firstClass.Checked)
            {
                cls = new FirstClass();
            }
            else
            {
                cls = new SecondClass();
            }

			TicketType way;
			if (oneWay.Checked)
				way = new OneWay();
			else
				way = new Return();

			Discount dis;
			if (twentyDiscount.Checked)
            {
                dis = new TwentyDiscount();
            }				
			else if (fortyDiscount.Checked)
            {
                dis = new FortyDiscount();
            }
            else
            {
                dis = new NoDiscount();
            }

            PaymentMethod pment;
			switch ((string)payment.SelectedItem) {
			case "Credit card":
				pment = new CreditCard();
				break;
			case "Debit card":
				pment = new DebitCard();
				break;
			default:
				pment = new CoinMachine();
				break;
			}

            var x = discountGroup.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked);
            return new UIInfo(Station.findStation(fromBox.SelectedItem.ToString()), Station.findStation(toBox.SelectedItem.ToString()), cls, way, dis, pment);
		}
#endregion
	}
}

