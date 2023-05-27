using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabCalculatorSimple
{
    public partial class MainForm : Form
    {
        string currentOperand = "0";
        private enum MathFunctions
        {
            None, Add, Subtract, Multiply, Divide, Sqr, Sqrt, OverX, Percent
        }

        class Calc
        {
            private float leftOperand = 0f;
            private float rightOperand = 0f;
            private bool leftOperandNegativeSign = false;
            private bool righOperandNegativeSign = false;
            private float memorySum = 0f;
            private MathFunctions mathFunctions = MathFunctions.None;

            public Calc() { }

            public void ClearAll()
            {
                leftOperand = 0f;
                rightOperand = 0f;
                leftOperandNegativeSign = false;
                righOperandNegativeSign = false;
                memorySum = 0f;
                mathFunctions = MathFunctions.None;
            }

            public void SetLeftOperand(float operand)
            {
                leftOperand = operand;
            }

            public void SetRightOperand(float operand)
            {
                rightOperand = operand;
            }
        }

        Calc arithmometer = new Calc();

        public MainForm()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            handler_keypress(((System.Windows.Forms.Control)sender).Name);
        }

        private void handler_keypress(string Name)
        {
            switch (Name)
            {
                case "buttonZero":
                    AddDigit('0');
                    break;
                case "buttonOne":
                    AddDigit('1');
                    break;
                case "buttonTwo":
                    AddDigit('2');
                    break;
                case "buttonThree":
                    AddDigit('3');
                    break;
                case "buttonFour":
                    AddDigit('4');
                    break;
                case "buttonFive":
                    AddDigit('5');
                    break;
                case "buttonSix":
                    AddDigit('6');
                    break;
                case "buttonSeven":
                    AddDigit('7');
                    break;
                case "buttonEight":
                    AddDigit('8');
                    break;
                case "buttonNine":
                    AddDigit('9');
                    break;
                case "buttonPeriod":
                    AddPeriod();
                    break;
                case "buttonBackspace":
                    Backspace();
                    break;

            }

            // DEBUG
            textBoxOperand.Text = currentOperand;
        }

        private void AddDigit(char digit)
        {
            if (currentOperand == "0")
            {
                currentOperand = "";
            }
                
            currentOperand += digit;
        }

        private void AddPeriod()
        {
            if (!currentOperand.Contains(".")) 
            {
                currentOperand += '.';
            }
        }

        private void Backspace()
        {

            if (currentOperand.Length > 0)
            {
                currentOperand = currentOperand.Remove(currentOperand.Length - 1, 1);
            }

            if (currentOperand.Length == 0)
            {
                currentOperand = "0";
            }
            
        }


    }
}
