using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_Harsh_Pathak
{
    public partial class calcmain : Form
    {
        Double Result_Value = 0;
        String Operator_Performed = " ";
        bool PerformedOp = false;
        private decimal MemoryStore = 0;
        double EndResult;
        public calcmain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_digit_one_Click(object sender, EventArgs e)
        {
            // numbers button and point
            if (textBox_Result.Text == "0" || PerformedOp)
                textBox_Result.Clear();

            PerformedOp = false;
            Button button = (Button)sender;
            if(button.Text == ".")
            {
                if(!textBox_Result.Text.Contains("."))
                    textBox_Result.Text += button.Text;
            }

            else
            textBox_Result.Text += button.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Operator_click_Event(object sender, EventArgs e)
        {
            // +, -, *, / , % , MC, MR etc operators
            Button button = (Button)sender;

            if (Result_Value != 0)
            {
                btn_equals.PerformClick();
                Operator_Performed = button.Text;
                label_Show_Op.Text = Result_Value + " " + Operator_Performed;
                PerformedOp = true;
            }
            else
            {

                Operator_Performed = button.Text;
                Result_Value = Double.Parse(textBox_Result.Text);
                label_Show_Op.Text = Result_Value + " " + Operator_Performed;
                PerformedOp = true;
            }
        }

        private void btn_clear_entry_Click(object sender, EventArgs e)
        {
            //CLEAR ENTRY BUTTON
            textBox_Result.Text = "0";
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            //CLEAR BUTTON
            textBox_Result.Text = "0";
            Result_Value = 0;
            label_Show_Op.Text = " ";
        }

        private void btn_equals_Click(object sender, EventArgs e)
        {
            // EQUALS BUTTON
            switch (Operator_Performed)
            {
                case "+":
                    textBox_Result.Text = (Result_Value + Double.Parse(textBox_Result.Text)).ToString();
                    break;

                case "-":
                    textBox_Result.Text = (Result_Value - Double.Parse(textBox_Result.Text)).ToString();
                    break;

                case "X":
                    textBox_Result.Text = (Result_Value * Double.Parse(textBox_Result.Text)).ToString();
                    break;

                case "/":
                    textBox_Result.Text = (Result_Value / Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "%":
                    textBox_Result.Text = (Result_Value / Double.Parse(textBox_Result.Text) * 100).ToString();
                    break;
                
                case "MC":
                   this.MemoryStore = 0;
                    break;
                case "MR":

                    //Memory Recall
                    textBox_Result.Text = this.MemoryStore.ToString();
                    break;
                 case "MS":
                    
                        // Memory subtract
                        this.MemoryStore -= Convert.ToDecimal(this.EndResult);
                        return;
                   

                    case "M+":
                  
                        // Memory add 

                        //this.MemoryStore += decimal.Parse(this.Result);
                        this.MemoryStore += Convert.ToDecimal(this.EndResult);
                    break;

                   


                default:
                    break;

            }
            Result_Value = Double.Parse(textBox_Result.Text);
            label_Show_Op.Text = " ";
        }

        private void button_help_Click(object sender, EventArgs e)
        {
            calchelp f2 = new calchelp();
            f2.ShowDialog();
        }

       

        private void btn_plusminus_Click(object sender, EventArgs e)
        {
            if (textBox_Result.Text != string.Empty)
            {
                double chk = Convert.ToDouble(this.textBox_Result.Text);
                chk = -chk;
                textBox_Result.Text = chk.ToString();
            }
        }

        private void btn_backspace_Click_1(object sender, EventArgs e)
        {
            if (textBox_Result.Text != string.Empty)
            {
                int txtlength = textBox_Result.Text.Length;
                if (txtlength != 1)
                {
                    textBox_Result.Text = textBox_Result.Text.Remove(txtlength - 1);
                }
                else
                {
                    textBox_Result.Text = 0.ToString();
                }

            }

        }

       

        private void btn_sqrt_Click(object sender, EventArgs e)
        {
            //To find the Square root
            if (textBox_Result.Text != string.Empty)
            {
                double SqrRoot = Math.Sqrt(Convert.ToDouble(this.textBox_Result.Text));
                textBox_Result.Text = SqrRoot.ToString();
            }

        }

        
    }
}
