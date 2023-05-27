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
        int historyListIterator = 0;
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
            private bool resultReady = false;

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
                result = 0f;
                resultReady = false;
            }

            public void Clear()
            {
                if (leftOperandReady)
                {
                    rightOperandReady = false;
                    rightOperand = 0f;
                    result = 0f;
                    resultReady = false;
                }
                else
                {
                    ClearAll();
                }

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
                        resultReady = true;
                        result_string = result.ToString();
                        break;

                    case MathFunctions.Subtract:
                        result = leftOperand - rightOperand;
                        resultReady = true;
                        result_string = result.ToString();
                        break;

                    case MathFunctions.Multiply:
                        result = leftOperand * rightOperand;
                        resultReady = true;
                        result_string = result.ToString();
                        break;

                    case MathFunctions.Divide:
                        if (rightOperand == 0f)
                        {
                            result = 0;
                            // TODO: Error message
                            //result_string = "Cannot divide by zero";
                            result_string = "0";
                        }
                        else
                        {
                            result = leftOperand / rightOperand;
                            resultReady = true;
                            result_string = result.ToString();
                        }
                        break;

                    case MathFunctions.Sqr:
                        result = leftOperand * leftOperand;
                        resultReady = true;
                        result_string = result.ToString();
                        break;

                    case MathFunctions.Sqrt:
                        result = (float)Math.Sqrt(leftOperand);
                        resultReady = true;
                        result_string = result.ToString();
                        break;

                    case MathFunctions.OverX:
                        if (leftOperand == 0f)
                        {
                            result = 0;
                            // TODO: Error message
                            //result_string = "Cannot divide by zero";
                            result_string = "0";
                        }
                        else
                        {
                            result = 1 / leftOperand;
                            resultReady = true;
                            result_string = result.ToString();
                        }
                        break;
                }
                return result_string;
            }

            public void ContinueCalculation()
            {
                if (resultReady)
                {
                    resultReady = false;
                    result = 0f;

                    leftOperandReady = false;
                    rightOperandReady = false;
                    rightOperand = 0f;

                    mathFunction = MathFunctions.None;
                }
            }

            public string GetExpression()
            {

                string expression = "";

                if (mathFunction == MathFunctions.Sqr)
                {
                    if (leftOperandReady)
                    {
                        expression += leftOperand.ToString() + "²";
                    }
                }
                else if (mathFunction == MathFunctions.Sqrt)
                {
                    if (leftOperandReady)
                    {
                        expression += "√" + leftOperand.ToString();
                    }
                }
                else if (mathFunction == MathFunctions.OverX)
                {
                    if (leftOperandReady)
                    {
                        expression += "1/" + leftOperand.ToString();
                    }
                }
                else if (!(mathFunction == MathFunctions.None))
                {
                    if (leftOperandReady)
                    {
                        expression += leftOperand.ToString();
                    }
                    switch (mathFunction)
                    {
                        case MathFunctions.Add:
                            expression += " + ";
                            break;
                        case MathFunctions.Subtract:
                            expression += " - ";
                            break;
                        case MathFunctions.Multiply:
                            expression += " × ";
                            break;
                        case MathFunctions.Divide:
                            expression += " ÷ ";
                            break;
                    }
                    if (rightOperandReady)
                    {
                        expression += rightOperand.ToString();
                    }
                }

                if (resultReady)
                {
                    expression += " = " + result.ToString();
                }
                
                return expression;
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
            arithmometer.ContinueCalculation();


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
            else if (Name == "buttonC")
            {
                arithmometer.ClearAll();
                currentOperand = "0";
            }
            else if (Name == "buttonCE")
            {
                arithmometer.Clear();
                currentOperand = "0";
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

            if (mathFunction == MathFunctions.Sqr || mathFunction == MathFunctions.Sqrt || mathFunction == MathFunctions.OverX)
            {
                currentOperand = arithmometer.Calculate().ToString();
                AddHistoryRecord();
            }
        }

        private void Equals()
        {
            arithmometer.SetRightOperand(float.Parse(currentOperand, CultureInfo.InvariantCulture.NumberFormat));
            currentOperand = arithmometer.Calculate().ToString();
            AddHistoryRecord();
        }

        private void AddHistoryRecord()
        {
            historyListIterator++;
            listBoxOperationHistory.Items.Insert(0, historyListIterator.ToString() + ") " 
                + arithmometer.GetExpression());
        }
    }
}
