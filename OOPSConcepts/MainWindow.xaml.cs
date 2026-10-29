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

namespace OOPSConcepts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   

    
        // Abstraction
        public abstract class Employee
        {
            public int EmployeeId { get; set; }

            public string Name { get; set; }

            // Encapsulation
            private decimal salary;

            public decimal Salary
            {
                get { return salary; }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentException(
                            "Salary cannot be negative.");
                    }

                    salary = value;
                }
            }

            protected Employee(int id, string name, decimal salary)
            {
                EmployeeId = id;
                Name = name;
                Salary = salary;
            }

            public abstract string GetDetails();

            public virtual string GetRole()
            {
                return "Employee";
            }
        }

        // Inheritance
        public class Developer : Employee
        {
            public Developer(int id, string name, decimal salary)
                : base(id, name, salary)
            {
            }

            // Polymorphism
            public override string GetDetails()
            {
                return "Employee Type: Developer\n" +
                       "Employee ID: " + EmployeeId + "\n" +
                       "Name: " + Name + "\n" +
                       "Monthly Salary: " + Salary.ToString("N2");
            }

            public override string GetRole()
            {
                return "Software Developer";
            }
        }

        public class Manager : Employee
        {
            public Manager(int id, string name, decimal salary)
                : base(id, name, salary)
            {
            }

            public override string GetDetails()
            {
                return "Employee Type: Manager\n" +
                       "Employee ID: " + EmployeeId + "\n" +
                       "Name: " + Name + "\n" +
                       "Monthly Salary: " + Salary.ToString("N2");
            }

            public override string GetRole()
            {
                return "Team Manager";
            }
        }

        public partial class MainWindow : Window
        {
            
            // Button Click Event
            private void ShowDetails_Click(
                object sender, RoutedEventArgs e)
            {
                string name = NameTextBox.Text.Trim();

                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show(
                        "Please enter employee name.",
                        "Validation",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    return;
                }

                int id;

                if (!int.TryParse(IdTextBox.Text, out id) || id <= 0)
                {
                    MessageBox.Show(
                        "Please enter a valid Employee ID.",
                        "Validation",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    return;
                }

                decimal salary;

                if (!decimal.TryParse(
                        SalaryTextBox.Text, out salary) || salary < 0)
                {
                    MessageBox.Show(
                        "Please enter a valid salary.",
                        "Validation",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    return;
                }

                ComboBoxItem selectedItem =
                    EmployeeTypeComboBox.SelectedItem as ComboBoxItem;

                if (selectedItem == null)
                {
                    MessageBox.Show("Please select an employee type.");
                    return;
                }

                string employeeType =
                    Convert.ToString(selectedItem.Content) ?? "";

                Employee employee;

                if (employeeType == "Manager")
                {
                    employee = new Manager(id, name, salary);
                }
                else if (employeeType == "Developer")
                {
                    employee = new Developer(id, name, salary);
                }
                else
                {
                    MessageBox.Show("Invalid employee type.");
                    return;
                }

                StringBuilder output = new StringBuilder();

                output.AppendLine(employee.GetDetails());
                output.AppendLine();
                output.AppendLine(
                    "Role Description: " + employee.GetRole());

                output.AppendLine();
                output.AppendLine("OOP Concepts Demonstrated:");
                output.AppendLine(
                    "1. Encapsulation - Salary property");
                output.AppendLine(
                    "2. Inheritance - Developer and Manager inherit Employee");
                output.AppendLine(
                    "3. Polymorphism - Overridden methods");
                output.AppendLine(
                    "4. Abstraction - Abstract Employee class");

                OutputTextBlock.Text = output.ToString();
            }
        }
}
