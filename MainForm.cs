using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        };

        Dictionary<string, char> digitDict = new Dictionary<string, char>()
        {
            { "buttonZero",     '0' },
            { "buttonOne",      '1' },
            { "buttonTwo",      '2' },
            { "buttonThree",    '3' },
            { "buttonFour",     '4' },
            { "buttonFive",     '5' },
            { "buttonSix",      '6' },
            { "buttonSeven",    '7' },
            { "buttonEight",    '8' },
            { "buttonNine",     '9' }
        };

        Dictionary<string, MathFunctions> mathDict = new Dictionary<string, MathFunctions>()
        {
            { "buttonAddition",         MathFunctions.Add },
            { "buttonSubstraction",     MathFunctions.Subtract },
            { "buttonMultiplication",   MathFunctions.Multiply },
            { "buttonDivision",         MathFunctions.Divide },
            { "buttonOverX",            MathFunctions.OverX },
            { "buttonPercent",          MathFunctions.Percent },
            { "buttonSqr",              MathFunctions.Sqr },
            { "buttonSqrt",             MathFunctions.Sqrt }
        };

        class Calc
        {
            private float leftOperand = 0f;
            private bool leftOperandReady = false;
            private float rightOperand = 0f;
            private bool rightOperandReady = false;
            private bool leftOperandNegativeSign = false;
            private bool righOperandNegativeSign = false;
            private float memorySum = 0f;
            private MathFunctions mathFunction = MathFunctions.None;
            private float result = 0f;

            public Calc() { }

            public void ClearAll()
            {
                leftOperand = 0f;
                leftOperandReady = false;
                rightOperand = 0f;
                rightOperandReady = false;
                leftOperandNegativeSign = false;
                righOperandNegativeSign = false;
                memorySum = 0f;
                mathFunction = MathFunctions.None;
            }

            public void SetLeftOperand(float operand)
            {
                if (!leftOperandReady)
                {
                    leftOperand = operand;
                    leftOperandReady = true;
                }
            }

            public void SetRightOperand(float operand)
            {
                if (!rightOperandReady)
                {
                    rightOperand = operand;
                    rightOperandReady = true;
                }
            }

            public void SetMathFunction(MathFunctions function)
            {
                mathFunction = function;
            }

            public string Calculate()
            {
                string result_string = "";

                switch (mathFunction)
                {
                    case MathFunctions.Add:
                        result = leftOperand + rightOperand;
                        result_string = result.ToString();
                        break;

                    case MathFunctions.Subtract:
                        result = leftOperand - rightOperand;
                        result_string = result.ToString();
                        break;

                    case MathFunctions.Multiply:
                        result = leftOperand * rightOperand;
                        result_string = result.ToString();
                        break;

                    case MathFunctions.Divide:
                        if (rightOperand == 0f)
                        {
                            result = 0;
                            result_string = "Cannot divide by zero";
                        }
                        else
                        {
                            result = leftOperand / rightOperand;
                            result_string = result.ToString();
                        }
                        break;

                    case MathFunctions.Sqr:
                        result = leftOperand * leftOperand;
                        result_string = result.ToString();
                        break;

                    case MathFunctions.Sqrt:
                        result = (float)Math.Sqrt(leftOperand);
                        result_string = result.ToString();
                        break;

                    case MathFunctions.OverX:
                        if (rightOperand == 0f)
                        {
                            result = 0;
                            result_string = "Cannot divide by zero";
                        }
                        else
                        {
                            result = 1 / leftOperand;
                            result_string = result.ToString();
                        }
                        break;

                    // TODO:
                    case MathFunctions.Percent:
                        result = 0;
                        result_string = result.ToString();
                        break;
                }

                return result_string;
            }

            public string GetExpression()
            {
                return leftOperand.ToString() + " " + mathFunction.ToString() + " " + rightOperand.ToString() + " = " + result.ToString();
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
            if (digitDict.ContainsKey(Name))
            {
                AddDigit(digitDict[Name]);
            }
            else if (mathDict.ContainsKey(Name))
            {
                AddMathFunction(mathDict[Name]);
            }
            else if (Name == "buttonPeriod")
            {
                AddPeriod();
            }
            else if (Name == "buttonBackspace")
            {
                Backspace();
            }
            else if (Name == "buttonEquals")
            {
                Equals();
            }

            // DEBUG
            textBoxOperand.Text = currentOperand;
            labelExpression.Text = arithmometer.GetExpression();
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

        private void AddMathFunction(MathFunctions mathFunction)
        {
            arithmometer.SetLeftOperand(float.Parse(currentOperand, CultureInfo.InvariantCulture.NumberFormat));
            arithmometer.SetMathFunction(mathFunction);
            currentOperand = "0";
        }

        private void Equals()
        {
            arithmometer.SetRightOperand(float.Parse(currentOperand, CultureInfo.InvariantCulture.NumberFormat));
            currentOperand = arithmometer.Calculate().ToString();
        }
    }
}
