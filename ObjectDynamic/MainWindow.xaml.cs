using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ObjectDynamic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

            // Object Example
            private void ObjectButton_Click(object sender, RoutedEventArgs e)
            {
                object value = ObjectInput.Text;

                ObjectResult.Text =
                    "Object Value: " + value +
                    "\nData Type: " + value.GetType().Name;
            }

            // Dynamic Example
            private void DynamicButton_Click(object sender, RoutedEventArgs e)
            {
                dynamic value = DynamicInput.Text;

                if (string.IsNullOrWhiteSpace((string)value))
                {
                    DynamicResult.Text = "Please enter a value.";
                    return;
                }

                DynamicResult.Text =
                    "Dynamic Value: " + value +
                    "\nData Type: " + value.GetType().Name;
            }
    }
}

