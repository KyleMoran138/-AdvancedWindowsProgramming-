using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            resetControls();
        }

        private void calculateButton_Click(object sender, EventArgs e) {
            decimal prin;
            double rate;
            double year;
            decimal ammount;
            string output;

            try {
                prin = Convert.ToDecimal(txtPrincipalAmount.Text);
                if(prin <= 0) {
                    throw new FormatException("Princapal amount must be grater");
                }
                rate = Convert.ToDouble(nudIntrest.Value);
                if (rate < 0) throw new ApplicationException("Intrest rate must be grater than or equal to 0");

                year = Convert.ToDouble(nudYear.Value);

                output = "Year\tAmount on deposit\r\n";
                double yearCounter = 0.5;

                for(yearCounter = 0.5; yearCounter <= year; yearCounter += 0.5) {
                    ammount = prin * ((decimal)Math.Pow((1 + rate / 100), yearCounter));
                    output += (yearCounter + "\t" + String.Format("{0:C2}", ammount) + "\r\n");
                }

                txtPrincipalAmount.Text = prin.ToString("C");
                textDisplay.Text = output;

            }catch(Exception exp) {
                MessageBox.Show("There is an invalid value in an input feild\nError: " + exp.Message +"\nThrownBy: " + exp.StackTrace, "Intrest calculator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resetControls() {
            txtPrincipalAmount.Text = String.Empty;
            textDisplay.Text = string.Empty;
            nudIntrest.Value = 0.1M;
            nudIntrest.Increment = 0.05M;
            nudIntrest.DecimalPlaces = 2;
            nudYear.Value = 0.50M;
            nudYear.Increment = 0.5M;
            nudYear.DecimalPlaces = 3;
            txtPrincipalAmount.Focus();
        }

        private void btnClear_click(object sender, EventArgs e) {
            resetControls();
        }

    }
}
