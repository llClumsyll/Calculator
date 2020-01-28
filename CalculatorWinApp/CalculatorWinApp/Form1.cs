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

        double firstNumber = 0.0;
        double secondNumber = 0.0;
        bool boolOperator = false;
        string checkNumber = "0";
        string oPerator = "";
        string checkPercent = "";

        private void button0_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.IndexOf("0") != 0)
            {
                setTextBoxShow("0");
            }
        }

        private void button01_Click(object sender, EventArgs e)
        {
            setTextBoxShow("1");
        }

        private void button02_Click(object sender, EventArgs e)
        {
            setTextBoxShow("2");
        }

        private void button03_Click(object sender, EventArgs e)
        {
            setTextBoxShow("3");
        }

        private void button04_Click(object sender, EventArgs e)
        {
            setTextBoxShow("4");
        }

        private void button05_Click(object sender, EventArgs e)
        {
            setTextBoxShow("5");
        }

        private void button06_Click(object sender, EventArgs e)
        {
            setTextBoxShow("6");
        }

        private void button07_Click(object sender, EventArgs e)
        {
            setTextBoxShow("7");
        }

        private void button08_Click(object sender, EventArgs e)
        {
            setTextBoxShow("8");
        }

        private void button09_Click(object sender, EventArgs e)
        {
            setTextBoxShow("9");
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains(".") && checkNumber != "0")
            {
                setTextBoxShow(".");
            }
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            setOperator("+");
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            setOperator("-");
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            setOperator("*");
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            setOperator("/");
        }

        private void buttonPercent_Click(object sender, EventArgs e)
        {
            if (checkNumber != "0")
            {
                if (boolOperator)
                {
                    checkPercent = "%";
                }
                else
                {
                    var sum = Convert.ToDouble(textBox1.Text) / 100;
                    showSum(sum.ToString(), sum.ToString());
                }
            }
        }

        private void setTextBoxShow(string number)
        {
            if (checkNumber == "0" && textBox1.Text != null)
            {
                textBox1.Text = number;
            }
            else
            {
                if (textBox1.Text.Length < 16)
                {
                    textBox1.Text += number;
                }
            }
            if (boolOperator)
            {
                secondNumber = Convert.ToDouble(textBox1.Text);
            }
            else
            {
                firstNumber = Convert.ToDouble(textBox1.Text);
            }
            checkNumber = textBox1.Text;
            showView(number);
        }

        private void setOperator(string opr)
        {
            boolOperator = true;
            textBox3.Text = textBox1.Text;
            checkNumber = "0";
            oPerator = opr;
            showView(opr);
        }

        private void showView(String value)
        {
            textBox3.Text = textBox3.Text + value;
        }

        private void btn_Percent_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_Equal_Click(object sender, EventArgs e)
        {
            String show = "";
            string number = "";
            switch (oPerator)
            {

                case "+":
                    if(checkPercent == "")
                    {
                        show = (firstNumber + secondNumber).ToString();
                        number = textBox3.Text;    
                    }
                    else if (checkPercent == "%")
                    {
                        var sumper = (firstNumber * secondNumber / 100);
                        show = (firstNumber + sumper).ToString();
                        number = textBox3.Text;
                    }
                    break;
                case "-":
                    if (checkPercent == "")
                    {
                        show = (firstNumber - secondNumber).ToString();
                        number = textBox3.Text;
                    }
                    else if (checkPercent == "%")
                    {
                        var sumper = (firstNumber * secondNumber / 100);
                        show = (firstNumber - sumper).ToString();
                        number = textBox3.Text;
                    }
                    break;
                case "*":
                    if (checkPercent == "")
                    {
                        show = (firstNumber * secondNumber).ToString();
                        number = textBox3.Text;
                    }
                    else if (checkPercent == "%")
                    {
                        var sumper = (firstNumber * secondNumber / 100);
                        show = (firstNumber * sumper).ToString();
                        number = textBox3.Text;
                    }
                    break;
                case "/":
                    if (checkPercent == "")
                    {
                        show = (firstNumber / secondNumber).ToString();
                        number = textBox3.Text;
                    }
                    else if (checkPercent == "%")
                    {
                        var sumper = (firstNumber * secondNumber / 100);
                        show = (firstNumber / sumper).ToString();
                        number = textBox3.Text;
                    }
                    break;

            }
            showSum(show, number);
        }

        private void showSum(String show,String number)
        {
            firstNumber = Convert.ToDouble(show);
            string FormattedPrice = firstNumber.ToString("N");
            secondNumber = 0.0;
            textBox1.Text = FormattedPrice;
            textBox2.AppendText(number + " = " + FormattedPrice + "\r\n"); //โชว์ประวัติที่คิด
        }

        private void Cancle_btn_Click(object sender, EventArgs e) //ลบทั้งหมด
        {
            firstNumber = 0.0;
            secondNumber = 0.0;
            checkNumber = "0";
            oPerator = "";
            boolOperator = false;
            textBox1.Text = checkNumber;
            textBox3.Text = "";
        }

        private void CancleOne_btn_Click(object sender, EventArgs e) //ลบทีละตัว
        {
            if (textBox1.TextLength > 1)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                textBox3.Text = "";
            }
            else
            {
                firstNumber = 0.0;
                secondNumber = 0.0;
                checkNumber = "0";
                oPerator = "";
                boolOperator = false;
                textBox1.Text = checkNumber;
                textBox3.Text = "";
            }
        }
    }
}
