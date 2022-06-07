using System;
using System.Data;
using System.Linq;
using System.Windows;
using SUP.Validator;
using SUP.Validator.Models;
using SUP.Repository;

namespace SUP.Views.Windows
{
    /// <summary>
    /// Interaction logic for EmployeeEditor.xaml
    /// </summary>
    public partial class EmployeeEditor : Window
    {
        SUPEntities db = new SUPEntities();
        public Employee Employee { get; set; }
        private Action SaveAction { get; set; }
        public EmployeeEditor(Action saveAction, Employee employee = null) // вывод должности сотрудника
        {
            InitializeComponent();
            EmployeeType[] types = db.EmployeeTypes.OrderBy(e => e.Salary).ToArray();
            typeBox.ItemsSource = types;

            if (employee != null)
            {
                Employee = employee;
                typeBox.SelectedItem = types.FirstOrDefault(t => t.Id == employee.EmployeeType.Id);
            }
            else
            {
                deleteButton.Visibility = Visibility.Collapsed;
                Employee = new Employee();
            }
            SaveAction = saveAction;
            this.DataContext = Employee;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e) => this.Close(); // закрытие окна
        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) => this.DragMove(); // позволяет двигать окно

        private void saveButton_Click(object sender, RoutedEventArgs e) // добавление/редактирование сотрудника
        {
            EmployeeType type = (typeBox.SelectedItem as EmployeeType);

            Result result = Validator.Validator.ValidateEmployee(Employee.FirstName, Employee.LastName, type);
            if (!result.IsSuccess)
            {
                MessageBox.Show(result.Errors[0], "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Employee.Type = type.Id;
            if (Employee.Id == Guid.Empty)
            {
                Employee.Id = Guid.NewGuid();
                db.Employees.Add(Employee);
                db.Entry(Employee).State = System.Data.EntityState.Added;
            }
            else
            {
                Employee oldEmployee = db.Employees.FirstOrDefault(emp => emp.Id == Employee.Id);
                oldEmployee.FirstName = Employee.FirstName;
                oldEmployee.LastName = Employee.LastName;
                oldEmployee.SecondName = Employee.SecondName;
                oldEmployee.Type = Employee.Type;
                db.Entry(oldEmployee).State = EntityState.Modified;
            }
            db.SaveChanges();
            SaveAction();
            this.Close();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e) // удалить сотрудника
        {
            MessageBoxResult result = MessageBox.Show($"Вы уверены, что хотите удалить сотрудника {Employee.FullName}?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                Employee employee = db.Employees.FirstOrDefault(emp => emp.Id == Employee.Id);
                if (employee is null) return;
                if (employee.ProjectWorks.Count != 0)
                {
                    MessageBox.Show("Нельзя удалить сотрудника с активными проектами", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                employee.IsRemoved = true;
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                SaveAction();
                this.Close();
            }
        }
    }
}
