using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SUP.Repository;
using SUP.Repository.Extensions;
using SUP.Views.Windows;

namespace SUP.Views
{
    /// <summary>
    /// Interaction logic for EmployeePage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        SUPEntities db = new SUPEntities();
        FilterEmployeeType Type { get; set; }
        public EmployeesPage()
        {
            InitializeComponent();
            EmployeeType[] types = db.EmployeeTypes.ToArray();
            types = types.OrderBy(t => t.Salary).Prepend(new EmployeeType() { Id = Guid.Empty, Title = "Все должности"}).ToArray(); // сортировка по должностям
            employeeTypeBox.ItemsSource = types;
            employeeTypeBox.SelectedIndex = 0;
            LoadData();
        }

        public void LoadData()
        {
            Employee[] employees = db.Employees.Where(e => !e.IsRemoved).OrderBy(e => e.LastName).ToArray();
            EmployeeType[] types = db.EmployeeTypes.ToArray();
            switch (Type) // вывод должностей сотрудников для сортировки
            {
                case FilterEmployeeType.All: break;
                case FilterEmployeeType.Juniors: employees = employees.Where(e => e.EmployeeType.Title.ToLower().Contains("junior")).ToArray(); break;
                case FilterEmployeeType.Middles: employees = employees.Where(e => e.EmployeeType.Title.ToLower().Contains("middle")).ToArray(); break;
                case FilterEmployeeType.Seniors: employees = employees.Where(e => e.EmployeeType.Title.ToLower().Contains("senior")).ToArray(); break;
            }
            mainList.ItemsSource = employees;
            App.RenderInfo("EmployeesPage");
        }

        private void addButton_Click(object sender, RoutedEventArgs e) //открытие окна добавления сотрудника
        {
            EmployeeEditor editor = new EmployeeEditor(this.LoadData);
            editor.Owner = App.Current.MainWindow;
            editor.ShowDialog();
        }

        private void vacationsButton_Click(object sender, RoutedEventArgs e) => App.ChangeToVacationsPage(); // переход на страницу с отпусками сотрудников
       
        private void mainList_SelectionChanged(object sender, SelectionChangedEventArgs e)// открытие окна редактирования сотрудника
        {
            ListView list = sender as ListView;
            if (list is null) return;

            Employee employee = list.SelectedItem as Employee;
            if (employee is null) return;

            EmployeeEditor editor = new EmployeeEditor(this.LoadData, employee);
            editor.ShowDialog();
            list.SelectedItem = null;
        }

        private void employeeTypeBox_SelectionChanged(object sender, SelectionChangedEventArgs e) // сортировка сотрудников по должностям
        {
            ComboBox combo = sender as ComboBox;
            Guid.TryParse(combo.SelectedValue.ToString(), out Guid selectedId);
            if (selectedId == Guid.Empty)
            {
                Type = FilterEmployeeType.All;
                LoadData();
                return;
            }
            EmployeeType type = db.EmployeeTypes.FirstOrDefault(et => et.Id == selectedId);
            Type = type.ToFilterEmployeeType();
            LoadData();

        }

        private void nameBox_TextChanged(object sender, TextChangedEventArgs e) // поиск сотрудников
        {
            TextBox box = sender as TextBox;
            Employee[] employees = mainList.ItemsSource as Employee[];
            if (String.IsNullOrWhiteSpace(box.Text))
            {
                foreach (Employee employee in employees)
                {
                    employee.Border = false;
                }
            }
            else
            {
                foreach(Employee employee in employees)
                {
                    employee.Border = employee.FullName.ToLower().Contains(box.Text.ToLower());
                }
            }
            mainList.ItemsSource = null;
            mainList.ItemsSource = employees;
        } 
        public enum FilterEmployeeType
        {
            All = 1,
            Juniors,
            Middles,
            Seniors
        }   
    }   
}
