using System;
using System.Data;
using System.Linq;
using System.Windows;
using SUP.Repository;

namespace SUP.Views.Windows
{
    /// <summary>
    /// Interaction logic for TaskEditor.xaml
    /// </summary>
    public partial class TaskEditor : Window
    {
        public Task Task { get; set; }
        public Action ReturnAction { get; set; }
        public Guid ProjectId { get; set; }

        public TaskEditor(Guid projectId, Action action, Task task = null) // вывод привязанных сотрудников в combobox
        {
            InitializeComponent();

            ProjectId = projectId;
            ReturnAction = action;

            ProjectWork[] works = App.db.ProjectWorks.Where(pw => pw.ProjectId == ProjectId && pw.DateEnd == null).ToArray();
            Employee[] employees = works.Select(w => w.Employee).ToArray();
            performerBox.ItemsSource = testerBox.ItemsSource = employees;

            if(task is null)
            {
                Task = new Task() { ProjectId = projectId, State = App.BacklogTaskState };
                deleteButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                Task = task;
                if (task.PerformerId != null) performerBox.SelectedItem = employees.FirstOrDefault(e => e.Id == task.PerformerId);
                if (task.TesterId != null) testerBox.SelectedItem = employees.FirstOrDefault(e => e.Id == Task.TesterId);
            }
            this.DataContext = Task;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e) => this.Close(); // закрывает окно
        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) => this.DragMove(); // позволяет двигать окно

        private void saveButton_Click(object sender, RoutedEventArgs e) // добавление/редактирование задачи проекта
        {
            if (String.IsNullOrWhiteSpace(Task.Title))
            {
                MessageBox.Show("Вы не ввели название задачи", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (String.IsNullOrWhiteSpace(Task.Description))
            {
                MessageBox.Show("Вы не ввели описание задачи", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Task.PerformerId = Task.Performer?.Id;
            Task.TesterId = Task.Tester?.Id;

            Int32 number = App.db.Tasks.Where(t => t.ProjectId == ProjectId).Count() + 1;

            if (Task.Id == Guid.Empty)
            {
                Task.Id = Guid.NewGuid();
                Task.NumberTask = number;
                App.db.Tasks.Add(Task);
                App.db.Entry(Task).State = EntityState.Added;
            }
            else
            {
                Task taskDb = App.db.Tasks.FirstOrDefault(t => t.Id == Task.Id);
                taskDb.Title = Task.Title;
                taskDb.Description = Task.Description;
                if (taskDb.NumberTask == null) taskDb.NumberTask = number;
                taskDb.PerformerId = Task.PerformerId;
                taskDb.TesterId = Task.TesterId;
                App.db.Entry(taskDb).State = EntityState.Modified;
            }
            App.db.SaveChanges();
            ReturnAction();
            this.Close();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e) // удаление задачи проекта
        {
            MessageBoxResult result = MessageBox.Show($"Вы уверены, что хотите удалить задачу у сотрудника {Task.Title}?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if(result == MessageBoxResult.Yes)
            {
                Task taskDb = App.db.Tasks.FirstOrDefault(t => t.Id == Task.Id);
                taskDb.IsRemoved = true;
                App.db.Entry(taskDb).State = EntityState.Modified;
                App.db.SaveChanges();
                ReturnAction();
                this.Close();
            }
        }
    }
}
