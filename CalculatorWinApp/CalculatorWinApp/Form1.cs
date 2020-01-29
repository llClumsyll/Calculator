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

        double firstNumber = 0.0; //ค่าแรก
        double secondNumber = 0.0; //ค่าที่สอง
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
            if (!textBox1.Text.Contains(".") && checkNumber != "0") //เช็คว่าในtextBox1มี . หรือไม่ และเช็คเลขว่าต้องไม่เท่ากับ 0 ถึงจะโชว์ .
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
            setOperator("x");
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            setOperator("÷");
        }

        private void buttonPercent_Click(object sender, EventArgs e)
        {
            if (checkNumber != "0") //เช็คว่าเลขต้องไม่เท่ากับ 0 ถึงจะกดปุ่ม % ได้
            {
                if (boolOperator)
                {
                    checkPercent = "%";
                }
                else
                {
                    var sum = Convert.ToDouble(textBox1.Text) / 100; //เมื่อกดปุ่ม % แล้ว จะทำสูตรนี้
                    showSum(sum.ToString(), sum.ToString());
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        //เซ็ตค่าให้ปุ่ม
        private void setTextBoxShow(string number)
        {
            if (checkNumber == "0" && textBox1.Text != null) //เช็คเลขว่าเท่ากับ 0 หรือไม่ และtextBox1ต้องไม่เท่ากับค่าว่าง ถึงจะโชว์ตัวเลข
            {
                textBox1.Text = number;
            }
            else
            {
                if (textBox1.Text.Length < 16) //กำหนดให้มีตัวเลขได้ไม่เกิน 16 ตัว
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

        //เซ็ตค่าให้ปุ่ม + - * /
        private void setOperator(string opr)
        {
            boolOperator = true;
            textBox3.Text = textBox1.Text;
            checkNumber = "0";
            oPerator = opr;
            showView(opr);
        }

        //โชว์ตัวเลขที่กำลังคำนวณ
        private void showView(String value)
        {
            textBox3.Text = textBox3.Text + value;
        }

        //เงื่อนไขเมื่อกดปุ่ม =
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
                case "x":
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
                case "÷":
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

        //โชว์ประวัติที่คำนวณ
        private void showSum(String show,String number)
        {
            firstNumber = Convert.ToDouble(show); //เก็บค่าผลรวมที่ได้ แล้วนำผลรวมกลับไปเป็นค่าแรกเพื่อคำนวณต่อ
            string FormattedPrice = firstNumber.ToString("N"); //ผลรวมที่ได้มาจะใส่ , กับ .00 ให้
            secondNumber = 0.0; //เซ็ตค่าที่สองกลับไปเป็นค่าเริ่มต้น คือ 0.0 แล้วใส่ค่าใหม่เพื่อคำนวณต่อ
            textBox1.Text = FormattedPrice;
            textBox2.AppendText(number + " = " + FormattedPrice + "\r\n");
        }

        //ลบทั้งหมด
        private void Cancle_btn_Click(object sender, EventArgs e)
        {
            //กำหนดให้เป็นค่าเริ่มต้น
            firstNumber = 0.0;
            secondNumber = 0.0;
            checkNumber = "0";
            oPerator = "";
            boolOperator = false;
            textBox1.Text = checkNumber;
            textBox3.Text = "";
        }

        //ลบทีละตัว
        private void CancleOne_btn_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 1) //ถ้าจำนวนตัวเลขมากกว่า 1 ตัว จะถูกลบไปเรื่อยๆจนหมด เมื่อลบหมดแล้วค่าจะเป็นเลข 0
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                textBox3.Text = "";
            }
            else
            {
                //กำหนดให้เป็นค่าเริ่มต้น
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
