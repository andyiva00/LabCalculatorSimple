using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
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
            { "buttonSqr",              MathFunctions.Sqr },
            { "buttonSqrt",             MathFunctions.Sqrt }
        };

        private Rectangle original_labelExpressionRect;
        private Rectangle original_TextBoxOperandRect;
        private Rectangle original_buttonMCRect;
        private Rectangle original_buttonMRRect;
        private Rectangle original_buttonMPlusRect;
        private Rectangle original_buttonMMinusRect;
        private Rectangle original_buttonPercentRect;
        private Rectangle original_buttonCERect;
        private Rectangle original_buttonCRect;
        private Rectangle original_buttonBackspaceRect;
        private Rectangle original_buttonOverXRect;
        private Rectangle original_buttonSqrRect;
        private Rectangle original_buttonSqrtRect;
        private Rectangle original_buttonDivisionRect;
        private Rectangle original_buttonSevenRect;
        private Rectangle original_buttonEightRect;
        private Rectangle original_buttonNineRect;
        private Rectangle original_buttonMultiplicationRect;
        private Rectangle original_buttonFourRect;
        private Rectangle original_buttonFiveRect;
        private Rectangle original_buttonSixRect;
        private Rectangle original_buttonSubstractionRect;
        private Rectangle original_buttonOneRect;
        private Rectangle original_buttonTwoRect;
        private Rectangle original_buttonThreeRect;
        private Rectangle original_buttonAdditionRect;
        private Rectangle original_buttonSignRect;
        private Rectangle original_buttonZeroRect;
        private Rectangle original_buttonPeriodRect;
        private Rectangle original_buttonEqualsRect;
        private Rectangle original_listBoxOperationHistoryRect;

        private float original_labelExpressionSize;
        private float original_TextBoxOperandSize;
        private float original_buttonMCSize;
        private float original_buttonMRSize;
        private float original_buttonMPlusSize;
        private float original_buttonMMinusSize;
        private float original_buttonPercentSize;
        private float original_buttonCESize;
        private float original_buttonCSize;
        private float original_buttonBackspaceSize;
        private float original_buttonOverXSize;
        private float original_buttonSqrSize;
        private float original_buttonSqrtSize;
        private float original_buttonDivisionSize;
        private float original_buttonSevenSize;
        private float original_buttonEightSize;
        private float original_buttonNineSize;
        private float original_buttonMultiplicationSize;
        private float original_buttonFourSize;
        private float original_buttonFiveSize;
        private float original_buttonSixSize;
        private float original_buttonSubstractionSize;
        private float original_buttonOneSize;
        private float original_buttonTwoSize;
        private float original_buttonThreeSize;
        private float original_buttonAdditionSize;
        private float original_buttonSignSize;
        private float original_buttonZeroSize;
        private float original_buttonPeriodSize;
        private float original_buttonEqualsSize;
        private float original_listBoxOperationHistorySize;

        class Calc
        {
            private float leftOperand = 0f;
            private bool leftOperandReady = false;
            private float rightOperand = 0f;
            private bool rightOperandReady = false;
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

            public void SetMemory(float memory)
            {
                memorySum = memory;
            }

            public float GetMemory()
            {
                return memorySum;
            }

            public MathFunctions GetMathFunction()
            { 
                return mathFunction; 
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
                            throw new DivideByZeroException("Cannot divide by zero");
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
                        if (leftOperand < 0f)
                        {
                            throw new ArgumentException("Invalid input");
                        }
                        result = (float)Math.Sqrt(leftOperand);
                        resultReady = true;
                        result_string = result.ToString();
                        break;

                    case MathFunctions.OverX:
                        if (leftOperand == 0f)
                        {
                            throw new DivideByZeroException("Cannot divide by zero");
                        }
                        else
                        {
                            result = 1 / leftOperand;
                            resultReady = true;
                            result_string = result.ToString();
                        }
                        break;

                    case MathFunctions.Percent:
                        rightOperand = leftOperand * rightOperand / 100;
                        result_string = rightOperand.ToString();
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
            else if (Name == "buttonPercent")
            {
                MathFunctions tmpMathFunction = arithmometer.GetMathFunction();
                arithmometer.SetMathFunction(MathFunctions.Percent);
                arithmometer.SetRightOperand(float.Parse(currentOperand, CultureInfo.InvariantCulture.NumberFormat));
                try
                {
                    currentOperand = arithmometer.Calculate().ToString();
                    arithmometer.SetMathFunction(tmpMathFunction);
                }
                catch (ArgumentException e)
                {
                    MessageBox.Show(e.Message);
                    arithmometer.ClearAll();
                }
                catch (DivideByZeroException e)
                {
                    MessageBox.Show(e.Message);
                    arithmometer.ClearAll();
                }
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
            else if (Name == "buttonSign")
            {
                SwitchOperandSign();
            }
            else if (Name == "buttonMC")
            {
                arithmometer.SetMemory(0);
            }
            else if (Name == "buttonMR")
            {
                currentOperand = arithmometer.GetMemory().ToString();
                if (currentOperand == "")
                {
                    currentOperand = "0";
                }
            }
            else if (Name == "buttonMPlus")
            {
                if (currentOperand.Length > 0)
                {
                    arithmometer.SetMemory(arithmometer.GetMemory()
                        + float.Parse(currentOperand, CultureInfo.InvariantCulture.NumberFormat));
                }
            }
            else if (Name == "buttonMMinus")
            {
                if (currentOperand.Length > 0)
                {
                    arithmometer.SetMemory(arithmometer.GetMemory()
                        - float.Parse(currentOperand, CultureInfo.InvariantCulture.NumberFormat));
                }
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

        private void SwitchOperandSign()
        {
            if (currentOperand.StartsWith("-"))
            {
                currentOperand = currentOperand.Substring(1);
            }
            else
            {
                currentOperand = "-" + currentOperand;
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
                try
                {
                    currentOperand = arithmometer.Calculate().ToString();
                    AddHistoryRecord();
                }
                catch (ArgumentException e)
                {
                    MessageBox.Show(e.Message);
                    arithmometer.ClearAll();
                }
                catch (DivideByZeroException e)
                {
                    MessageBox.Show(e.Message);
                    arithmometer.ClearAll();
                }
            }
        }

        private void Equals()
        {
            arithmometer.SetRightOperand(float.Parse(currentOperand, CultureInfo.InvariantCulture.NumberFormat));

            try
            {
                currentOperand = arithmometer.Calculate().ToString();
                AddHistoryRecord();
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message);
                arithmometer.ClearAll();
            }
            catch (DivideByZeroException e)
            {
                MessageBox.Show(e.Message);
                arithmometer.ClearAll();
            }
        }

        private void AddHistoryRecord()
        {
            historyListIterator++;
            

            string expression = historyListIterator.ToString() + ") ";
            expression += arithmometer.GetExpression();

            if (arithmometer.GetMemory() > 0)
            {
                expression += " [M: " + arithmometer.GetMemory().ToString() + "]";
            }

            listBoxOperationHistory.Items.Insert(0, expression);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            original_labelExpressionRect = new Rectangle(labelExpression.Location, labelExpression.Size);
            original_TextBoxOperandRect = new Rectangle(textBoxOperand.Location, textBoxOperand.Size);
            original_buttonMCRect = new Rectangle(buttonMC.Location, buttonMC.Size);
            original_buttonMRRect = new Rectangle(buttonMR.Location, buttonMR.Size);
            original_buttonMPlusRect = new Rectangle(buttonMPlus.Location, buttonMPlus.Size);
            original_buttonMMinusRect = new Rectangle(buttonMMinus.Location, buttonMMinus.Size);
            original_buttonPercentRect = new Rectangle(buttonPercent.Location, buttonPercent.Size);
            original_buttonCERect = new Rectangle(buttonCE.Location, buttonCE.Size);
            original_buttonCRect = new Rectangle(buttonC.Location, buttonC.Size);
            original_buttonBackspaceRect = new Rectangle(buttonBackspace.Location, buttonBackspace.Size);
            original_buttonOverXRect = new Rectangle(buttonOverX.Location, buttonOverX.Size);
            original_buttonSqrRect = new Rectangle(buttonSqr.Location, buttonSqr.Size);
            original_buttonSqrtRect = new Rectangle(buttonSqrt.Location, buttonSqrt.Size);
            original_buttonDivisionRect = new Rectangle(buttonDivision.Location, buttonDivision.Size);
            original_buttonSevenRect = new Rectangle(buttonSeven.Location, buttonSeven.Size);
            original_buttonEightRect = new Rectangle(buttonEight.Location, buttonEight.Size);
            original_buttonNineRect = new Rectangle(buttonNine.Location, buttonNine.Size);
            original_buttonMultiplicationRect = new Rectangle(buttonMultiplication.Location, buttonMultiplication.Size);
            original_buttonFourRect = new Rectangle(buttonFour.Location, buttonFour.Size);
            original_buttonFiveRect = new Rectangle(buttonFive.Location, buttonFive.Size);
            original_buttonSixRect = new Rectangle(buttonSix.Location, buttonSix.Size);
            original_buttonSubstractionRect = new Rectangle(buttonSubstraction.Location, buttonSubstraction.Size);
            original_buttonOneRect = new Rectangle(buttonOne.Location, buttonOne.Size);
            original_buttonTwoRect = new Rectangle(buttonTwo.Location, buttonTwo.Size);
            original_buttonThreeRect = new Rectangle(buttonThree.Location, buttonThree.Size);
            original_buttonAdditionRect = new Rectangle(buttonAddition.Location, buttonAddition.Size);
            original_buttonSignRect = new Rectangle(buttonSign.Location, buttonSign.Size);
            original_buttonZeroRect = new Rectangle(buttonZero.Location, buttonZero.Size);
            original_buttonPeriodRect = new Rectangle(buttonPeriod.Location, buttonPeriod.Size);
            original_buttonEqualsRect = new Rectangle(buttonEquals.Location, buttonEquals.Size);
            original_listBoxOperationHistoryRect = new Rectangle(listBoxOperationHistory.Location, listBoxOperationHistory.Size);

            original_labelExpressionSize = labelExpression.Font.Size;
            original_TextBoxOperandSize = textBoxOperand.Font.Size;
            original_buttonMCSize = buttonMC.Font.Size;
            original_buttonMRSize = buttonMR.Font.Size;
            original_buttonMPlusSize = buttonMPlus.Font.Size;
            original_buttonMMinusSize = buttonMMinus.Font.Size;
            original_buttonPercentSize = buttonPercent.Font.Size;
            original_buttonCESize = buttonCE.Font.Size;
            original_buttonCSize = buttonC.Font.Size;
            original_buttonBackspaceSize = buttonBackspace.Font.Size;
            original_buttonOverXSize = buttonOverX.Font.Size;
            original_buttonSqrSize = buttonSqr.Font.Size;
            original_buttonSqrtSize = buttonSqrt.Font.Size;
            original_buttonDivisionSize = buttonDivision.Font.Size;
            original_buttonSevenSize = buttonSeven.Font.Size;
            original_buttonEightSize = buttonEight.Font.Size;
            original_buttonNineSize = buttonNine.Font.Size;
            original_buttonMultiplicationSize = buttonMultiplication.Font.Size;
            original_buttonFourSize = buttonFour.Font.Size;
            original_buttonFiveSize = buttonFive.Font.Size;
            original_buttonSixSize = buttonSix.Font.Size;
            original_buttonSubstractionSize = buttonSubstraction.Font.Size;
            original_buttonOneSize = buttonOne.Font.Size;
            original_buttonTwoSize = buttonTwo.Font.Size;
            original_buttonThreeSize = buttonThree.Font.Size;
            original_buttonAdditionSize = buttonAddition.Font.Size;
            original_buttonSignSize = buttonSign.Font.Size;
            original_buttonZeroSize = buttonZero.Font.Size;
            original_buttonPeriodSize = buttonPeriod.Font.Size;
            original_buttonEqualsSize = buttonEquals.Font.Size;
            original_listBoxOperationHistorySize = listBoxOperationHistory.Font.Size;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            ResizeControl(labelExpression, original_labelExpressionRect, original_labelExpressionSize);
            ResizeControl(textBoxOperand, original_TextBoxOperandRect, original_TextBoxOperandSize);
            ResizeControl(buttonMC, original_buttonMCRect, original_buttonMCSize);
            ResizeControl(buttonMR, original_buttonMRRect, original_buttonMRSize);
            ResizeControl(buttonMPlus, original_buttonMPlusRect, original_buttonMPlusSize);
            ResizeControl(buttonMMinus, original_buttonMMinusRect, original_buttonMMinusSize);
            ResizeControl(buttonPercent, original_buttonPercentRect, original_buttonPercentSize);
            ResizeControl(buttonCE, original_buttonCERect, original_buttonCESize);
            ResizeControl(buttonC, original_buttonCRect, original_buttonCSize);
            ResizeControl(buttonBackspace, original_buttonBackspaceRect, original_buttonBackspaceSize);
            ResizeControl(buttonOverX, original_buttonOverXRect, original_buttonOverXSize);
            ResizeControl(buttonSqr, original_buttonSqrRect, original_buttonSqrSize);
            ResizeControl(buttonSqrt, original_buttonSqrtRect, original_buttonSqrtSize);
            ResizeControl(buttonDivision, original_buttonDivisionRect, original_buttonDivisionSize);
            ResizeControl(buttonSeven, original_buttonSevenRect, original_buttonSevenSize);
            ResizeControl(buttonEight, original_buttonEightRect, original_buttonEightSize);
            ResizeControl(buttonNine, original_buttonNineRect, original_buttonNineSize);
            ResizeControl(buttonMultiplication, original_buttonMultiplicationRect, original_buttonMultiplicationSize);
            ResizeControl(buttonFour, original_buttonFourRect, original_buttonFourSize);
            ResizeControl(buttonFive, original_buttonFiveRect, original_buttonFiveSize);
            ResizeControl(buttonSix, original_buttonSixRect, original_buttonSixSize);
            ResizeControl(buttonSubstraction, original_buttonSubstractionRect, original_buttonSubstractionSize);
            ResizeControl(buttonOne, original_buttonOneRect, original_buttonOneSize);
            ResizeControl(buttonTwo, original_buttonTwoRect, original_buttonTwoSize);
            ResizeControl(buttonThree, original_buttonThreeRect, original_buttonThreeSize);
            ResizeControl(buttonAddition, original_buttonAdditionRect, original_buttonAdditionSize);
            ResizeControl(buttonSign, original_buttonSignRect, original_buttonSignSize);
            ResizeControl(buttonZero, original_buttonZeroRect, original_buttonZeroSize);
            ResizeControl(buttonPeriod, original_buttonPeriodRect, original_buttonPeriodSize);
            ResizeControl(buttonEquals, original_buttonEqualsRect, original_buttonEqualsSize);
            ResizeControl(listBoxOperationHistory, original_listBoxOperationHistoryRect, original_listBoxOperationHistorySize);
        }

        private void ResizeControl(Control control, Rectangle originalRect, float originalFontSize)
        {
            if (originalRect.Width > 0 && originalRect.Height > 0)
            {
                float xRatio = control.Width / (float)originalRect.Width;
                float yRatio = control.Height / (float)originalRect.Height;

                float ratio = (xRatio >= yRatio) ? xRatio : yRatio;


                float newFontSize = originalFontSize * ratio;
                Font newFont = new Font(control.Font.FontFamily, newFontSize);
                control.Font = newFont;
            }
        }
    }
}
