using System;
using System.Windows;

namespace Conv {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow {
        public MainWindow() {
            InitializeComponent();
        }

        private void Here(object sender, EventArgs e) {
            var allowed = new[] {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
                'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                'u', 'v', 'w', 'x', 'y', 'z'
            };
            var inputNumber = Input.Text;
            inputNumber = inputNumber.ToLower();

            if (inputNumber == "" || From.Text == "" || To.Text == "") {
                MessageBox.Show("Something's missing...");
                return;
            }

            foreach (var t in From.Text) {
                if (t is < '0' or > '9') {
                    MessageBox.Show("Only numbers in Old base!");
                    return;
                }
            }
            
            foreach (var t in To.Text) {
                if (t is < '0' or > '9') {
                    MessageBox.Show("Only numbers in New base!");
                    return;
                }
            }
            
            var first = Convert.ToInt32(From.Text);
            var second = Convert.ToInt32(To.Text);
            
            if (first < 1 || second < 1) {
                MessageBox.Show("One of the bases of the numeric system is too low \n " +
                                "Can I please have more? \n :3");
                return;
            }
            if (first > 36 || second > 36) {
                MessageBox.Show("I have a very cool and big Artificial Intelligence " +
                                "to calculate this for you \n But I can't comprehend such a big number \n " +
                                "Lower the bases so they're below 37, okay?");
                return;
            }

            var ok = false;
            foreach (var t in inputNumber) {
                for (var j = 0; j < 36; j++) {
                    if (t == allowed[j]) {
                        if (j > first - 1) {
                            MessageBox.Show("This number can't be in this numeric system :/");
                            return;
                        }
                        ok = true;
                        break;
                    }
                }

                if (!ok) {
                    MessageBox.Show("Some characters you've got in your input >:3");
                    return;
                }
            }

            var inputTo10 = 0;
            if (first != 10) {
                var prower = 0;
                for (var i = inputNumber.Length - 1; i > -1; i--) {
                    for (var j = 0; j < 36; j++) {
                        if (inputNumber[i] == allowed[j]) {
                            inputTo10 += (int) (j * Math.Pow(first, prower));
                            prower++;
                            break;
                        }
                    }
                }
            }
            else inputTo10 = Convert.ToInt32(inputNumber);

            if (second == 1) {
                Dialog.Text = "Why would you even need this?..";
                string fence = "";
                for (int i = 0; i < inputTo10; i++) {
                    fence += "|";
                }

                Output.Text = fence;
                return;
            }
            
            var outputNumber = "";
            while (inputTo10 != 0) {
                outputNumber = allowed[inputTo10 % second] + outputNumber;
                inputTo10 /= second;
            }

            var bonk = new Random();
            var some = bonk.Next();
            if (some % 2 == 0) Dialog.Text = "Here you go!";
            else if (some % 3 == 0) Dialog.Text = "And the answer is...";
            else if (some % 5 == 0) Dialog.Text = "One more:";
            else if (some % 7 == 0) Dialog.Text = ":3";
            else if (some % 11 == 0) Dialog.Text = "It's Morbin time";
            else Dialog.Text = "ඞ";
            
            Output.Text = outputNumber.ToUpper();
        }
    }
}
