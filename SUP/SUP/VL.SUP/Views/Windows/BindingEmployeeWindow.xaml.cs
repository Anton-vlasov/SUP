using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SUP.Repository;

namespace SUP.Views.Windows
{
    /// <summary>
    /// Interaction logic for BindingEmployeeWindow.xaml
    /// </summary>
    public partial class BindingEmployeeWindow : Window
    {
        public Project Project { get; set; }
        public Action ReturnAction { get; set; }
        public BindingEmployeeWindow(Project project, Action action) // вывод сотрудников в combobox
        {
            InitializeComponent();
            Project = project;
            ReturnAction = action;
            Employee[] employees = App.db.Employees.Where(e => !e.IsRemoved).ToArray();
            employeeBox.ItemsSource = employees;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e) => this.Close(); // закрытие окна
        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) => this.DragMove(); // позволяет двигать форму

        private void removeButton_Click(object sender, RoutedEventArgs e) // отвязкасотрудника от проекта
        {
            Employee selectedEmployee = employeeBox.SelectedItem as Employee;
            if (selectedEmployee is null) return;
            MessageBoxResult result =
                MessageBox.Show($"Вы уверены, что хотите отвязать сотрудника {selectedEmployee.FullName} от проекта {Project.Name}", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                ProjectWork projectWork = App.db.ProjectWorks.FirstOrDefault(pw => pw.ProjectId == Project.Id && pw.EmployeeId == selectedEmployee.Id);
                if (projectWork != null)
                {
                    projectWork.DateEnd = DateTime.Now;
                    App.db.Entry(projectWork).State = EntityState.Modified;
                    App.db.SaveChanges();
                }

                Task[] employeeTasks = App.db.Tasks.Where(t =>
                t.ProjectId == Project.Id && (t.PerformerId == selectedEmployee.Id || t.TesterId == selectedEmployee.Id)).ToArray();
                if (employeeTasks.Length != 0)
                {
                    foreach (Task task in employeeTasks)
                    {
                        task.PerformerId = task.PerformerId == selectedEmployee.Id ? null : task.PerformerId;
                        task.TesterId = task.TesterId == selectedEmployee.Id ? null : task.TesterId;
                        App.db.Entry(task).State = EntityState.Modified;
                    }
                    App.db.SaveChanges();
                }
                ReturnAction();
                this.Close();
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e) // привязка сотрудника к проекту
        {
            Employee selectedEmployee = employeeBox.SelectedItem as Employee;
            if (selectedEmployee is null) return;

            MessageBoxResult result =
               MessageBox.Show($"Вы уверены, что хотите привязать сотрудника {selectedEmployee.FullName} к проекту {Project.Name}", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                ProjectWork projectWork = new ProjectWork();
                projectWork.Id = Guid.NewGuid();
                projectWork.ProjectId = Project.Id;
                projectWork.EmployeeId = selectedEmployee.Id;
                projectWork.DateStart = DateTime.Now;

                App.db.ProjectWorks.Add(projectWork);
                App.db.Entry(projectWork).State = EntityState.Added;
                App.db.SaveChanges();
 
                ReturnAction();
                this.Close();
            }
        }

        private void employeeBox_SelectionChanged(object sender, SelectionChangedEventArgs e) // выбор сотрудника для привязки к проекту
        {
            Employee selectedEmployee = employeeBox.SelectedItem as Employee;
            ProjectWork work = App.db.ProjectWorks.FirstOrDefault(pw => pw.ProjectId == Project.Id && pw.EmployeeId == selectedEmployee.Id && pw.DateEnd == null);
            if (work == null)
            {
                removeButton.Visibility = Visibility.Collapsed;
                addButton.Visibility = Visibility.Visible;
                return;
            }
            removeButton.Visibility = Visibility.Visible;
            addButton.Visibility = Visibility.Collapsed;
        }
    }
}
