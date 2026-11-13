using System;
using System.Windows.Forms;
using CalculatorPrivateAssembly; 

namespace BasicCalculatorr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            
            cbOperation.Items.Clear(); 
            cbOperation.Items.Add("+");
            cbOperation.Items.Add("-");
            cbOperation.Items.Add("*");
            cbOperation.Items.Add("/");

            
            cbOperation.DropDownStyle = ComboBoxStyle.DropDownList;

            
            if (cbOperation.Items.Count > 0)
            {
                cbOperation.SelectedIndex = 0;
            }
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            try
            {
                
                float num1 = Convert.ToSingle(txtNum1.Text);
                float num2 = Convert.ToSingle(txtNum2.Text);
                float result = 0;

                
                if (cbOperation.SelectedItem == null)
                {
                    MessageBox.Show("Please select an operation (+, -, *, /) first.");
                    return;
                }

                string operation = cbOperation.SelectedItem.ToString();

                
                if (operation == "+")
                {
                    result = BasicComputation.Addition(num1, num2);
                }
                else if (operation == "-")
                {
                    result = BasicComputation.Subtraction(num1, num2);
                }
                else if (operation == "*")
                {
                    result = BasicComputation.Multiplication(num1, num2);
                }
                else if (operation == "/")
                {
                    if (num2 == 0)
                    {
                        MessageBox.Show("Cannot divide by zero.");
                        return;
                    }
                    result = BasicComputation.Division(num1, num2);
                }

                
                lblTotal.Text = result.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers only.");
            }
        }
    }
}