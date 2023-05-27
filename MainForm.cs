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
            // DEBUG:
            arithmometer.SetLeftOperand(1.0f);
            arithmometer.SetRightOperand(2.0f);
        }
        
    }
}
