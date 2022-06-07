using System;
using System.Data;
using System.Linq;
using System.Windows;
using SUP.Repository;
using SUP.Validator.Models;
using SUP.Validator;
namespace SUP.Views.Windows
{
    /// <summary>
    /// Interaction logic for ProjectEditor.xaml
    /// </summary>
    public partial class ProjectEditor : Window
    {
        public Action ReturnAction { get; set; }
        public Project Project { get; set; }
        public ProjectEditor(Action action, Project project = null)
        {
            InitializeComponent();
            if (project is null)
            {
                Project = new Project();
                deleteButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                Project = project;
            }
            ReturnAction = action;
            this.DataContext = Project;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e) => this.Close(); // закрывает окно
        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) => this.DragMove(); // позволяет двигать окно

        private void saveButton_Click(object sender, RoutedEventArgs e) // редактирование проекта
        {
            Result result = Validator.Validator.ValidateProject(Project.Name, Project.Description);
            if (!result.IsSuccess)
            {
                MessageBox.Show(result.Errors[0], "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (Project.Id == Guid.Empty)
            {
                Project.Id = Guid.NewGuid();
                App.db.Projects.Add(Project);
                App.db.Entry(Project).State = EntityState.Added;
            }
            else
            {
                Project project = App.db.Projects.FirstOrDefault(p => p.Id == Project.Id && !p.IsRemoved);
                if (project == null) return;

                project.Name = Project.Name;
                project.Description = Project.Description;
            }
            App.db.SaveChanges();
            ReturnAction();
            this.Close();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e) // удаление проекта
        {
            MessageBoxResult result = MessageBox.Show($"Вы уверены, что хотите убрать проект {Project.Name} в архив?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                Project project = App.db.Projects.FirstOrDefault(p => p.Id == Project.Id);
                if (project is null)
                {
                    MessageBox.Show("Не удалось идентифицировать проект", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                project.IsRemoved = true;
                App.db.Entry(project).State = EntityState.Modified;

                ProjectWork[] works = App.db.ProjectWorks.Where(pw => pw.ProjectId == Project.Id && pw.DateEnd == null).ToArray();
                foreach (ProjectWork work in works)
                {
                    work.DateEnd = DateTime.Now;
                    App.db.Entry(work).State = EntityState.Modified;
                }

                Task[] tasks = App.db.Tasks.Where(t => t.ProjectId == Project.Id && !t.IsRemoved).ToArray();
                foreach (Task task in tasks)
                {
                    task.IsRemoved = true;
                    App.db.Entry(task).State = EntityState.Modified;
                }
                App.db.SaveChanges();
                ReturnAction();
                this.Close();
            }
        }
    }
}
