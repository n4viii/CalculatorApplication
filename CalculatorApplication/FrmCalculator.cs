using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApplication
{
    public partial class FrmCalculator : Form
    {
        private CalculatorClass cal;

        private double num1, num2;

        public FrmCalculator()
        {
            InitializeComponent();

            cal = new CalculatorClass();

            if (cbOperator.Items.Count > 0)
            {
                cbOperator.SelectedIndex = 0;
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            try
            {
                num1 = Convert.ToDouble(txtBoxInput1.Text);
                num2 = Convert.ToDouble(txtBoxInput2.Text);

                if (cbOperator.SelectedItem == null)
                {
                    MessageBox.Show("Please select an arithmetic operator.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string selectedOperator = cbOperator.SelectedItem.ToString().Trim();

                switch (selectedOperator)
                {
                    case "+":
                        cal.CalculateEvent += cal.GetSum;
                        break;
                    case "-":
                        cal.CalculateEvent += cal.GetDifference;
                        break;
                    case "*":
                        cal.CalculateEvent += cal.GetProduct;
                        break;
                    case "/":
                        cal.CalculateEvent += cal.GetQuotient;
                        break;
                    default:
                        MessageBox.Show("Invalid operator selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }

                double total = cal.ExecuteCalculation(num1, num2);
                lblDisplayTotal.Text = total.ToString();

                switch (selectedOperator)
                {
                    case "+":
                        cal.CalculateEvent -= cal.GetSum;
                        break;
                    case "-":
                        cal.CalculateEvent -= cal.GetDifference;
                        break;
                    case "*":
                        cal.CalculateEvent -= cal.GetProduct;
                        break;
                    case "/":
                        cal.CalculateEvent -= cal.GetQuotient;
                        break;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values in both input boxes.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message, "Math Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
private void FrmCalculator_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
