using System;
using System.Linq;
using System.Windows.Controls;
using SUP.Repository;
using System.Data;
using System.Windows;
using SUP;

namespace WpfApp1.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ArchivePage.xaml
    /// </summary>
    public partial class ArchivePage : Page
    {
        private readonly SUPEntities db = new SUPEntities();


        public ArchivePage(Project project = null)
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData() // вывод проектов, которые находятся в архиве
        {
            Project[] projects = db.Projects.Where(p => p.IsRemoved).ToArray();
            archivebox.ItemsSource = null;
            archivebox.ItemsSource = projects;
        }


        private void archivebox_SelectionChanged(object sender, SelectionChangedEventArgs e) // вывод проекта из архива
        {
            ListView list = sender as ListView;
            if (list is null) return;

            Project projects = list.SelectedItem as Project;
            if (projects is null) return;

            MessageBoxResult result = MessageBox.Show($"Вы уверены, что хотите убрать проект из архива?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                Project project = App.db.Projects.FirstOrDefault(p => p.Id == projects.Id);
                if (project is null)
                {
                    MessageBox.Show("Не удалось идентифицировать проект", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                project.IsRemoved = false;
                App.db.Entry(project).State = EntityState.Modified;

                ProjectWork[] works = App.db.ProjectWorks.Where(pw => pw.ProjectId == projects.Id && pw.DateEnd == null).ToArray();
                foreach (ProjectWork work in works)
                {
                    work.DateEnd = DateTime.Now;
                    App.db.Entry(work).State = EntityState.Modified;
                }

                Task[] tasks = App.db.Tasks.Where(t => t.ProjectId == projects.Id && !t.IsRemoved).ToArray();
                foreach (Task task in tasks)
                {
                    task.IsRemoved = false;
                    App.db.Entry(task).State = EntityState.Modified;
                }
                App.db.SaveChanges();

                LoadData();
            }
        }
    }
}
