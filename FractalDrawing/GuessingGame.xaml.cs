using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FractalDrawing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random random;
        private int numberToGuess;

        public MainWindow()
        {
            InitializeComponent();
            random = new Random();
            numberToGuess = random.Next(1, 101);
            GuessingBox.KeyDown += GuessingBox_KeyDown;
        }

        private void GuessingBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                SubmitButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }

        private void SubmitButton_Click(object sender, object e)
        {
            int number = int.Parse(GuessingBox.Text);
            GuessingLabel.Content = number;

            if (number == numberToGuess)
                HintingLabel.Content = $"You got it. The number was {numberToGuess}!";

            else if (number < numberToGuess)
                HintingLabel.Content = "Too low. Try guessing higher.";

            else if (number > numberToGuess)
                HintingLabel.Content = "Too high. Try guessing lower.";

            else
                HintingLabel.Content = "You messed up somehow.";
        }

        private void GuessingBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = int.TryParse(e.Text, out int num);
        }
    }
}
