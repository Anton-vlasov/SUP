using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using SUP.Repository;
using SUP.Views.Windows;

namespace SUP.Views
{
    /// <summary>
    /// Interaction logic for VacationsPage.xaml
    /// </summary>
    public partial class VacationsPage : Page
    {
        SUPEntities db = new SUPEntities();
        public VacationsPage()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            Vacation[] vacations = db.Vacations.Where(v => !v.IsRemoved).OrderBy(v => v.DateStart).ToArray(); // вывод отпусков сотрудников
            mainList.ItemsSource = vacations;
            App.RenderInfo("VacationsPage");
        }

        private void addButton_Click(object sender, RoutedEventArgs e) // добавление отпуска сотруднику
        {
            VacationEditor editor = new VacationEditor(LoadData);
            editor.Owner = App.Current.MainWindow;
            editor.ShowDialog();
        }

        private void mainList_SelectionChanged(object sender, SelectionChangedEventArgs e) // редактирование отпуска сотрудника
        {
            ListView list = sender as ListView;
            if (list is null) return;

            Vacation vacation = list.SelectedItem as Vacation;
            if (vacation is null) return;

            VacationEditor editor = new VacationEditor(LoadData, vacation);
            editor.Owner = App.Current.MainWindow;
            editor.ShowDialog();
            list.SelectedItem = null;
        }
    }
}
