using System.Globalization;

namespace CalculatorWinformsApp
{
    public partial class formCalculator : Form
    {
        private string? OperatorToExecute { get; set; }
        private bool SwitchToSecondOperand { get; set; } = false;
        private float? FirstOperand { get; set; }
        private float? SecondOperand { get; set; }

        public formCalculator()
        {
            InitializeComponent();
        }

        private void Pad(string PadType, string input)
        {
            if (calculatorDisplay.Text == "Error")
                return;
            switch (PadType)
            {
                case "num":
                    numPad(input);
                    break;

                case "op":
                    operatorPad(input);
                    break;
            }   
        }

        private void numPad(string number)
        // function that handles number-like buttons
        {
            if (this.FirstOperand != null && this.SwitchToSecondOperand == true) 
            {
                calculatorDisplay.Text = "";
                this.SwitchToSecondOperand = false;
            }
            calculatorDisplay.Text += number;
        }

        private void operatorPad(string operatorValue)
        // function that handles operator buttons
        {   
            this.OperatorToExecute = operatorValue;
            this.SwitchToSecondOperand = true;
            this.FirstOperand = float.Parse(calculatorDisplay.Text, CultureInfo.InvariantCulture.NumberFormat);
        }

        // Numpad inputs
        private void num1Button_Click(object sender, EventArgs e)
        {
            Pad("num", "1");
        }

        private void num2Button_Click(object sender, EventArgs e)
        {
            Pad("num", "2");
        }

        private void num3Button_Click(object sender, EventArgs e)
        {
            Pad("num", "3");
        }

        private void num4Button_Click(object sender, EventArgs e)
        {
            Pad("num", "4");
        }

        private void num5Button_Click(object sender, EventArgs e)
        {
            Pad("num", "5");
        }

        private void num6Button_Click(object sender, EventArgs e)
        {
            Pad("num", "6");
        }

        private void num7Button_Click(object sender, EventArgs e)
        {
            Pad("num", "7");
        }

        private void num8Button_Click(object sender, EventArgs e)
        {
            Pad("num", "8");
        }

        private void num9Button_Click(object sender, EventArgs e)
        {
            Pad("num", "9");
        }

        private void num0Button_Click(object sender, EventArgs e)
        {
            Pad("num", "0");
        }

        private void dotButton_Click(object sender, EventArgs e)
        {
            Pad("num", ".");
        }

        private void negativeButton_Click(object sender, EventArgs e)
        {
            Pad("num", "-");
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.OperatorToExecute = null;
            calculatorDisplay.Text = "";
        }

        
        // Operations
        private void addButton_Click(object sender, EventArgs e)
        {
            Pad("op", "+");
        }

        private void substractButton_Click(object sender, EventArgs e)
        {
            Pad("op", "-");
        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            Pad("op", "*");
        }

        private void divideButton_Click(object sender, EventArgs e)
        {
            Pad("op", "/");
        }

        private void equalButton_Click(object sender, EventArgs e)
        {
            if (calculatorDisplay.Text == "Error")
                return;
            this.SecondOperand = float.Parse(calculatorDisplay.Text, CultureInfo.InvariantCulture.NumberFormat);
            float? result = null;
            switch (this.OperatorToExecute)
            {
                case "-":
                    result = this.FirstOperand - this.SecondOperand;
                    break;

                case "+":
                    result = this.FirstOperand + this.SecondOperand;
                    break;

                case "*":
                    result = this.FirstOperand * this.SecondOperand;
                    break;

                case "/":
                    if (this.SecondOperand == 0)
                    {
                        calculatorDisplay.Text = "Error";
                        return;
                    }
                    else
                        result = this.FirstOperand / this.SecondOperand;
                    break;
            }
            calculatorDisplay.Text = result.ToString();
        }
    }
}