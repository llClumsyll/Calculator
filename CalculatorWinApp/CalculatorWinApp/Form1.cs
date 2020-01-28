using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorWinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double resultValue;
        string num1, num2, result;
        bool boolOperator = false;
        string charOperator = "";

        private void btn_Num_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || boolOperator)
            {
                textBox1.Clear();
            }

            boolOperator = false;
            Button button = (Button)sender;

            if (textBox1.Text == ".")
            {
                if (textBox1.Text.Contains("."))
                {
                    textBox1.Text += button.Text;
                }
            }
            else
            {
                textBox1.Text += button.Text;
            }

        }

        private void btn_Operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue != 0)
            {
                charOperator = button.Text;
                resultValue = double.Parse(textBox1.Text);
                charOperator = button.Text;
                textBox3.Text = resultValue + "  "+ charOperator;
                boolOperator = true;
                num1 = textBox3.Text;
            }
            else
            {
                charOperator = button.Text;
                resultValue = double.Parse(textBox1.Text);
                charOperator = button.Text;
                textBox3.Text = resultValue + "  " + charOperator;
                boolOperator = true;
                num1 = textBox3.Text;
            }
        }

        private void btn_Percent_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_Equal_Click(object sender, EventArgs e)
        {
            string number;
            switch (charOperator)
            {

                case "+":
                    textBox3.Text = double.Parse(textBox1.Text).ToString();
                    textBox1.Text = (resultValue + double.Parse(textBox1.Text)).ToString();
                    num2 = textBox3.Text;
                    result = textBox1.Text;
                    break;

                case "-":
                    textBox3.Text = double.Parse(textBox1.Text).ToString();
                    textBox1.Text = (resultValue - double.Parse(textBox1.Text)).ToString();
                    num2 = textBox3.Text;
                    result = textBox1.Text;
                    break;

                case "x":
                    textBox3.Text = double.Parse(textBox1.Text).ToString();
                    textBox1.Text = (resultValue * double.Parse(textBox1.Text)).ToString();
                    num2 = textBox3.Text;
                    result = textBox1.Text;
                    break;

                case "÷":
                    textBox3.Text = double.Parse(textBox1.Text).ToString();
                    textBox1.Text = (resultValue / double.Parse(textBox1.Text)).ToString();
                    num2 = textBox3.Text;
                    result = textBox1.Text;
                    break;
                    
            }
            number = num1 + " " + num2;
            textBox2.AppendText(number+ " = " + result + "\r\n"); //โชว์ประวัติที่คิด
        }


        private void Cancle_btn_Click(object sender, EventArgs e) //ลบทั้งหมด
        {
            textBox1.Text = "0";
            resultValue = 0;
            //label1.Text = "";
            //label2.Text = "";
        }

        private void CancleOne_btn_Click(object sender, EventArgs e) //ลบทีละตัว
        {
            if (textBox1.TextLength != 0)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
            }
        }
    }
}
