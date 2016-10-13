using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 P3 If's, Switch 
 Adrian Beloqui
 2/9/2015
 * This programs allows the user to enter a number from 0 to 10,000 and get the proper signature
 * for a check. This program uses several controls over the user possible actions so the user
 * gets a good experience using the program. It also displays the signature in a formate that is
 * legibile and the amount is converted into a currency. All the data is displayed in a Data Grid View
 * which is updated everytime the user hits the button "Sign". 
 
 */

namespace P3
{
    public partial class mainForm : Form
    {
        public static string thousandsText = "";

        public mainForm()
        {
            InitializeComponent();
        }

        private void signButton_Click(object sender, EventArgs e)
        {
            double amountEntered = 0;
            if (amountTextBox.Text.ToString() != "")
            {
                if (double.TryParse(amountTextBox.Text, out amountEntered))
                {
                    if (amountEntered > 10000)
                    {
                        MessageBox.Show("This program only allows values till 10,000", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    if (amountEntered < 0)
                    {
                        MessageBox.Show("Please enter a positive number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    Tuple<string, string> amount = writtenAmount(amountEntered);
                    if (amount.Item1 != "" && amount.Item2 != "")
                    {
                        int row = valuesSignedDataGridView.Rows.Add();
                        valuesSignedDataGridView.Rows[row].Cells["amountColumn"].Value = amount.Item1;
                        valuesSignedDataGridView.Rows[row].Cells["signatureColumn"].Value = amount.Item2;
                    }

                }
                else
                {
                    MessageBox.Show("Only numbers are accepted!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("You are missing some data!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            thousandsText = "";
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            valuesSignedDataGridView.Rows.Clear();
            amountTextBox.Text = "";
        }

        static Tuple<string, string> writtenAmount(double amount)
        {
            string result = "";
            string text = "";
            double amountNotDecimal = Math.Truncate(amount);
            string pennies = getPennis(amount, amountNotDecimal);
            switch (int.Parse(amountNotDecimal.ToString()))
            {
                case 0:
                    text = setText("Zero dollar", pennies);
                    break;
                case 1:
                    text = setText("One dollar", pennies);
                    break;
                case 2:
                    text = setText("Two dollars", pennies);
                    break;
                case 3:
                    text = setText("Three dollars", pennies);
                    break;
                case 4:
                    text = setText("Four dollars", pennies);
                    break;
                case 5:
                    text = setText("Five dollars", pennies);
                    break;
                case 6:
                    text = setText("Six dollars", pennies);
                    break;
                case 7:
                    text = setText("Seven dollars", pennies);
                    break;
                case 8:
                    text = setText("Eight dollars", pennies);
                    break;
                case 9:
                    text = setText("Nine dollars", pennies);
                    break;
                case 10:
                    text = setText("Ten dollars", pennies);
                    break;
                default:
                    Tuple<string, string> results = largeWrittenAmounts(amount, amountNotDecimal, pennies);
                    result = results.Item1;
                    text = results.Item2;
                    break;

            }
            result = string.Format("{0:C2}", amount);
            //add code here using if and switch statements for logic
            return new Tuple<string, string>(result,text);
        }

        static Tuple<string, string> largeWrittenAmounts(double amount, double amountNotDecimal, string pennies)
        {
            string result = "";
            string text = "";
            string partialText = "";
            Dictionary<int, string> dictionary = CreateDictonary();
            if (amount < 100)
            {
                if (dictionary.TryGetValue(int.Parse(amountNotDecimal.ToString()), out partialText))
                {
                    partialText = thousandsText + partialText;
                    text = setText(partialText, pennies);
                }

            }
            else if (amount == 100)
            {
                if (dictionary.TryGetValue(int.Parse(amountNotDecimal.ToString()), out partialText))
                {
                    partialText = thousandsText + partialText;
                    text = setText(partialText + " dollars", pennies);
                }
            }
            else if (amount > 100 && amount < 200)
            {
                if (dictionary.TryGetValue(int.Parse("100"), out text))
                {
                    partialText = thousandsText + text;
                }
                amountNotDecimal -= 100;
                if (dictionary.TryGetValue(int.Parse(amountNotDecimal.ToString()), out text))
                {
                    partialText = thousandsText + partialText;
                    text = setText(partialText + ", " + text, pennies);
                }
            }
                //If it is 200
            else if (amount == 200)
            {
                if (dictionary.TryGetValue(int.Parse(amountNotDecimal.ToString()), out partialText))
                {
                    partialText = thousandsText + partialText;
                    text = setText(partialText + " dollars", pennies);
                }
            }
            else if (amount > 200 && amount < 300)
            {
                if (dictionary.TryGetValue(int.Parse("200"), out text))
                {
                    partialText = thousandsText + text;
                }
                amountNotDecimal -= 200;
                if (dictionary.TryGetValue(int.Parse(amountNotDecimal.ToString()), out text))
                {
                    partialText = thousandsText + partialText;
                    text = setText(partialText + ", " + text, pennies);
                }
            }
                //If it is 300
            else if (amount == 300)
            {
                if (dictionary.TryGetValue(int.Parse(amountNotDecimal.ToString()), out partialText))
                {
                    partialText = thousandsText + partialText;
                    text = setText(partialText + " dollars", pennies);
                }
            }
            else if (amount > 300 && amount < 400)
            {
                if (dictionary.TryGetValue(int.Parse("300"), out text))
                {
                    partialText = thousandsText + text;
                }
                amountNotDecimal -= 300;
                if (dictionary.TryGetValue(int.Parse(amountNotDecimal.ToString()), out text))
                {
                    partialText = thousandsText + partialText;
                    text = setText(partialText + ", " + text, pennies);
                }
            }
            //if it is 400
            else if (amount == 400)
            {
                if (dictionary.TryGetValue(int.Parse(amountNotDecimal.ToString()), out partialText))
                {
                    partialText = thousandsText + partialText;
                    text = setText(partialText + " dollars", pennies);
                }
            }
            else if (amount > 400 && amount < 500)
            {
                if (dictionary.TryGetValue(int.Parse("400"), out text))
                {
                    partialText = thousandsText + text;
                }
                amountNotDecimal -= 400;
                if (dictionary.TryGetValue(int.Parse(amountNotDecimal.ToString()), out text))
                {
                    text = setText(partialText + ", " + text, pennies);
                }
            }
                //if it is 500
            else if (amount == 500)
            {
                if (dictionary.TryGetValue(int.Parse(amountNotDecimal.ToString()), out partialText))
                {
                    partialText = thousandsText + partialText;
                    text = setText(partialText + " dollars", pennies);
                }
            }
            else if (amount > 500 && amount < 600)
            {
                if (dictionary.TryGetValue(int.Parse("500"), out text))
                {
                    partialText = thousandsText + text;
                }
                amountNotDecimal -= 500;
                if (dictionary.TryGetValue(int.Parse(amountNotDecimal.ToString()), out text))
                {
                    text = setText(partialText + ", " + text, pennies);
                }
            }
            //if it is 600
            else if (amount == 600)
            {
                if (dictionary.TryGetValue(int.Parse(amountNotDecimal.ToString()), out partialText))
                {
                    partialText = thousandsText + partialText;
                    text = setText(partialText + " dollars", pennies);
                }
            }
            else if (amount > 600 && amount < 700)
            {
                if (dictionary.TryGetValue(int.Parse("600"), out text))
                {
                    partialText = thousandsText + text;
                }
                amountNotDecimal -= 600;
                if (dictionary.TryGetValue(int.Parse(amountNotDecimal.ToString()), out text))
                {
                    text = setText(partialText + ", " + text, pennies);
                }
            }
            //if it is 700
            else if (amount == 700)
            {
                if (dictionary.TryGetValue(int.Parse(amountNotDecimal.ToString()), out partialText))
                {
                    partialText = thousandsText + partialText;
                    text = setText(partialText + " dollars", pennies);
                }
            }
            else if (amount > 700 && amount < 800)
            {
                if (dictionary.TryGetValue(int.Parse("700"), out text))
                {
                    partialText = thousandsText + text;
                }
                amountNotDecimal -= 700;
                if (dictionary.TryGetValue(int.Parse(amountNotDecimal.ToString()), out text))
                {
                    text = setText(partialText + ", " + text, pennies);
                }
            }
            //if it is 800
            else if (amount == 800)
            {
                if (dictionary.TryGetValue(int.Parse(amountNotDecimal.ToString()), out partialText))
                {
                    partialText = thousandsText + partialText;
                    text = setText(partialText + " dollars", pennies);
                }
            }
            else if (amount > 800 && amount < 900)
            {
                if (dictionary.TryGetValue(int.Parse("800"), out text))
                {
                    partialText = thousandsText + text;
                }
                amountNotDecimal -= 800;
                if (dictionary.TryGetValue(int.Parse(amountNotDecimal.ToString()), out text))
                {
                    text = setText(partialText + ", " + text, pennies);
                }
            }
            //if it is 900
            else if (amount == 900)
            {
                if (dictionary.TryGetValue(int.Parse(amountNotDecimal.ToString()), out partialText))
                {
                    partialText = thousandsText + partialText;
                    text = setText(partialText + " dollars", pennies);
                }
            }
            else if (amount > 900 && amount < 1000)
            {
                if (dictionary.TryGetValue(int.Parse("900"), out text))
                {
                    partialText = thousandsText + text;
                }
                amountNotDecimal -= 900;
                if (dictionary.TryGetValue(int.Parse(amountNotDecimal.ToString()), out text))
                {
                    text = setText(partialText + ", " + text, pennies);
                }
            }
            //if it is 1000
            else if (amount == 1000)
            {
                if (dictionary.TryGetValue(int.Parse(amountNotDecimal.ToString()), out partialText))
                {
                    partialText = thousandsText + partialText;
                    text = setText(partialText + " dollars", pennies);
                }
            }
            else if (amount > 1000 && amount < 2000)
            {
                if (dictionary.TryGetValue(int.Parse("1000"), out text))
                {
                    thousandsText = text+", ";
                }
                amountNotDecimal -= 1000;
                amount -= 1000;
                return largeWrittenAmounts(amount, amountNotDecimal, pennies);
            }
            //if it is 2000
            else if (amount == 2000)
            {
                if (dictionary.TryGetValue(int.Parse(amountNotDecimal.ToString()), out partialText))
                {
                    partialText = thousandsText + partialText;
                    text = setText(partialText + " dollars", pennies);
                }
            }
            else if (amount > 2000 && amount < 3000)
            {
                if (dictionary.TryGetValue(int.Parse("2000"), out text))
                {
                    thousandsText = text + ", ";
                }
                amountNotDecimal -= 2000;
                amount -= 2000;
                return largeWrittenAmounts(amount, amountNotDecimal, pennies);
            }
            //if it is 3000
            else if (amount == 3000)
            {
                if (dictionary.TryGetValue(int.Parse(amountNotDecimal.ToString()), out partialText))
                {
                    partialText = thousandsText + partialText;
                    text = setText(partialText + " dollars", pennies);
                }
            }
            else if (amount > 3000 && amount < 4000)
            {
                if (dictionary.TryGetValue(int.Parse("3000"), out text))
                {
                    thousandsText = text + ", ";
                }
                amountNotDecimal -= 3000;
                amount -= 3000;
                return largeWrittenAmounts(amount, amountNotDecimal, pennies);
            }
            //if it is 4000
            else if (amount == 4000)
            {
                if (dictionary.TryGetValue(int.Parse(amountNotDecimal.ToString()), out partialText))
                {
                    partialText = thousandsText + partialText;
                    text = setText(partialText + " dollars", pennies);
                }
            }
            else if (amount > 4000 && amount < 5000)
            {
                if (dictionary.TryGetValue(int.Parse("4000"), out text))
                {
                    thousandsText = text + ", ";
                }
                amountNotDecimal -= 4000;
                amount -= 4000;
                return largeWrittenAmounts(amount, amountNotDecimal, pennies);
            }
            //if it is 5000
            else if (amount == 5000)
            {
                if (dictionary.TryGetValue(int.Parse(amountNotDecimal.ToString()), out partialText))
                {
                    partialText = thousandsText + partialText;
                    text = setText(partialText + " dollars", pennies);
                }
            }
            else if (amount > 5000 && amount < 6000)
            {
                if (dictionary.TryGetValue(int.Parse("5000"), out text))
                {
                    thousandsText = text + ", ";
                }
                amountNotDecimal -= 5000;
                amount -= 5000;
                return largeWrittenAmounts(amount, amountNotDecimal, pennies);
            }
            //if it is 6000
            else if (amount == 6000)
            {
                if (dictionary.TryGetValue(int.Parse(amountNotDecimal.ToString()), out partialText))
                {
                    partialText = thousandsText + partialText;
                    text = setText(partialText + " dollars", pennies);
                }
            }
            else if (amount > 6000 && amount < 7000)
            {
                if (dictionary.TryGetValue(int.Parse("6000"), out text))
                {
                    thousandsText = text + ", ";
                }
                amountNotDecimal -= 6000;
                amount -= 6000;
                return largeWrittenAmounts(amount, amountNotDecimal, pennies);
            }
            //if it is 7000
            else if (amount == 7000)
            {
                if (dictionary.TryGetValue(int.Parse(amountNotDecimal.ToString()), out partialText))
                {
                    partialText = thousandsText + partialText;
                    text = setText(partialText + " dollars", pennies);
                }
            }
            else if (amount > 7000 && amount < 8000)
            {
                if (dictionary.TryGetValue(int.Parse("7000"), out text))
                {
                    thousandsText = text + ", ";
                }
                amountNotDecimal -= 7000;
                amount -= 7000;
                return largeWrittenAmounts(amount, amountNotDecimal, pennies);
            }
            //if it is 8000
            else if (amount == 8000)
            {
                if (dictionary.TryGetValue(int.Parse(amountNotDecimal.ToString()), out partialText))
                {
                    partialText = thousandsText + partialText;
                    text = setText(partialText + " dollars", pennies);
                }
            }
            else if (amount > 8000 && amount < 9000)
            {
                if (dictionary.TryGetValue(int.Parse("8000"), out text))
                {
                    thousandsText = text + ", ";
                }
                amountNotDecimal -= 8000;
                amount -= 8000;
                return largeWrittenAmounts(amount, amountNotDecimal, pennies);
            }
            //if it is 9000
            else if (amount == 9000)
            {
                if (dictionary.TryGetValue(int.Parse(amountNotDecimal.ToString()), out partialText))
                {
                    partialText = thousandsText + partialText;
                    text = setText(partialText + " dollars", pennies);
                }
            }
            else if (amount > 9000 && amount < 10000)
            {
                if (dictionary.TryGetValue(int.Parse("9000"), out text))
                {
                    thousandsText = text + ", ";
                }
                amountNotDecimal -= 9000;
                amount -= 9000;
                return largeWrittenAmounts(amount, amountNotDecimal, pennies);
            }
            //if it is 10000
            else if (amount == 10000)
            {
                if (dictionary.TryGetValue(int.Parse(amountNotDecimal.ToString()), out partialText))
                {
                    partialText = thousandsText + partialText;
                    text = setText(partialText + " dollars", pennies);
                }
            }
            return new Tuple<string, string>(result, text);
        }

        static string setText(string dollars, string pennies )
        {
            int fixedLengthOfResultString = 180;
            string text = string.Format("{0} and ", dollars);
            text = text.PadRight(fixedLengthOfResultString, '.');
            text += string.Format("{0:00}/100",pennies);
            return text; 
        }

        static string getPennis(double amount, double decimalAmount)
        {
            amount -= decimalAmount;
            amount = amount * 100;
            amount = Math.Round(amount);
            return amount.ToString();
        }

        static Dictionary<int, string> CreateDictonary()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(0, "Zero dollar");
            dictionary.Add(1, "One dollar");
            dictionary.Add(2, "Two dollars");
            dictionary.Add(3, "Three dollars");
            dictionary.Add(4, "Four dollars");
            dictionary.Add(5, "Five dollars");
            dictionary.Add(6, "Six dollars");
            dictionary.Add(7, "Seven dollars");
            dictionary.Add(8, "Eight dollars");
            dictionary.Add(9, "Nine dollars");
            dictionary.Add(10, "Ten dollars");
            dictionary.Add(11,"Eleven dollars");
            dictionary.Add(12, "Twelve dollars");
            dictionary.Add(13, "Thirteen dollars");
            dictionary.Add(14, "Fourteen dollars");
            dictionary.Add(15, "Fifteen dollars");
            dictionary.Add(16, "Sixteen dollars");
            dictionary.Add(17, "Seventeen dollars");
            dictionary.Add(18, "Eighteen dollars");
            dictionary.Add(19, "Nineteen dollars");
            dictionary.Add(20, "Twenty dollars");
            dictionary.Add(21, "Twenty-one dollars");
            dictionary.Add(22, "Twenty-two dollars");
            dictionary.Add(23, "Twenty-three dollars");
            dictionary.Add(24, "Twenty-four dollars");
            dictionary.Add(25, "Twenty-five dollars");
            dictionary.Add(26, "Twenty-six dollars");
            dictionary.Add(27, "Twenty-seven dollars");
            dictionary.Add(28, "Twenty-eight dollars");
            dictionary.Add(29, "Twenty-nine dollars");
            dictionary.Add(30, "Thirty dollars");
            dictionary.Add(31, "Thrity-one dollars");
            dictionary.Add(32, "Thrity-two dollars");
            dictionary.Add(33, "Thrity-three dollars");
            dictionary.Add(34, "Thrity-four dollars");
            dictionary.Add(35, "Thrity-five dollars");
            dictionary.Add(36, "Thrity-six dollars");
            dictionary.Add(37, "Thrity-seven dollars");
            dictionary.Add(38, "Thrity-eight dollars");
            dictionary.Add(39, "Thrity-nine dollars");
            dictionary.Add(40, "Forty dollars");
            dictionary.Add(41, "Fourty-one dollars");
            dictionary.Add(42, "Fourty-two dollars");
            dictionary.Add(43, "Fourty-three dollars");
            dictionary.Add(44, "Fourty-four dollars");
            dictionary.Add(45, "Fourty-five dollars");
            dictionary.Add(46, "Fourty-six dollars");
            dictionary.Add(47, "Fourty-seven dollars");
            dictionary.Add(48, "Fourty-eight dollars");
            dictionary.Add(49, "Fourty-nine dollars");
            dictionary.Add(50, "Fifty dollars");
            dictionary.Add(51, "Fifty-one dollars");
            dictionary.Add(52, "Fifty-two dollars");
            dictionary.Add(53, "Fifty-three dollars");
            dictionary.Add(54, "Fifty-four dollars");
            dictionary.Add(55, "Fifty-five dollars");
            dictionary.Add(56, "Fifty-six dollars");
            dictionary.Add(57, "Fifty-seven dollars");
            dictionary.Add(58, "Fifty-eight dollars");
            dictionary.Add(59, "Fifty-nine dollars");
            dictionary.Add(60, "Sixty dollars");
            dictionary.Add(61, "Sixty-one dollars");
            dictionary.Add(62, "Sixty-two dollars");
            dictionary.Add(63, "Sixty-three dollars");
            dictionary.Add(64, "Sixty-four dollars");
            dictionary.Add(65, "Sixty-five dollars");
            dictionary.Add(66, "Sixty-six dollars");
            dictionary.Add(67, "Sixty-seven dollars");
            dictionary.Add(68, "Sixty-eight dollars");
            dictionary.Add(69, "Sixty-nine dollars");
            dictionary.Add(70, "Seventy dollars");
            dictionary.Add(71, "Seventy-one dollars");
            dictionary.Add(72, "Seventy-two dollars");
            dictionary.Add(73, "Seventy-three dollars");
            dictionary.Add(74, "Seventy-four dollars");
            dictionary.Add(75, "Seventy-five dollars");
            dictionary.Add(76, "Seventy-six dollars");
            dictionary.Add(77, "Seventy-seven dollars");
            dictionary.Add(78, "Seventy-eight dollars");
            dictionary.Add(79, "Seventy-nine dollars");
            dictionary.Add(80, "Eighty dollars");
            dictionary.Add(81, "Eighty-one dollars");
            dictionary.Add(82, "Eighty-two dollars");
            dictionary.Add(83, "Eighty-three dollars");
            dictionary.Add(84, "Eighty-four dollars");
            dictionary.Add(85, "Eighty-five dollars");
            dictionary.Add(86, "Eighty-six dollars");
            dictionary.Add(87, "Eighty-seven dollars");
            dictionary.Add(88, "Eighty-eight dollars");
            dictionary.Add(89, "Eighty-nine dollars");
            dictionary.Add(90, "Ninety dollars");
            dictionary.Add(91, "Ninety-one dollars");
            dictionary.Add(92, "Ninety-two dollars");
            dictionary.Add(93, "Ninety-three dollars");
            dictionary.Add(94, "Ninety-four dollars");
            dictionary.Add(95, "Ninety-five dollars");
            dictionary.Add(96, "Ninety-six dollars");
            dictionary.Add(97, "Ninety-seven dollars");
            dictionary.Add(98, "Ninety-eight dollars");
            dictionary.Add(99, "Ninety-nine dollars");
            dictionary.Add(100, "One hundred");
            dictionary.Add(200, "Two hundred");
            dictionary.Add(300, "Three hundred");
            dictionary.Add(400, "Four hundred");
            dictionary.Add(500, "Five hundred");
            dictionary.Add(600, "Six hundred");
            dictionary.Add(700, "Seven hundred");
            dictionary.Add(800, "Eight hundred");
            dictionary.Add(900, "Nine hundred");
            dictionary.Add(1000, "One thousand");
            dictionary.Add(2000, "Two thousand");
            dictionary.Add(3000, "Three thousand");
            dictionary.Add(4000, "Four thousand");
            dictionary.Add(5000, "Five thousand");
            dictionary.Add(6000, "Six thousand");
            dictionary.Add(7000, "Seven thousand");
            dictionary.Add(8000, "Eight thousand");
            dictionary.Add(9000, "Nine thousand");
            dictionary.Add(10000, "Ten thousand");
            return dictionary;
        }
    }
}
