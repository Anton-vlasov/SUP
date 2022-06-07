using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SUP.Repository;
using SUP.Views.Windows;
using SUP.Tools;


namespace SUP.Views
{
    /// <summary>
    /// Interaction logic for TasksPages.xaml
    /// </summary>
    public partial class TasksPage : Page
    {
        public Project Project { get; set; }
        public List<Task> BacklogTasks { get; set; } = new List<Task>();
        public List<Task> InWorkTasks { get; set; } = new List<Task>();
        public List<Task> CompletedTasks { get; set; } = new List<Task>();

        public TasksPage(Project project)
        {
            InitializeComponent();

            Project = project;

            LoadData();
            this.DataContext = Project;
        }

        #region Backlog

        public void AddToBackLog(Task task)
        {
            Task taskDb = App.db.Tasks.FirstOrDefault(t => t.Id == task.Id);
            taskDb.State = App.BacklogTaskState;
            App.db.Entry(taskDb).State = EntityState.Modified;
            App.db.SaveChanges();
            LoadData();
        }

        public void RemoveFromBackLog(Task task)
        {
            BacklogTasks.Remove(task);
        }

        #endregion

        #region InWork

        public void AddToInWork(Task task)
        {
            Task taskDb = App.db.Tasks.FirstOrDefault(t => t.Id == task.Id);
            taskDb.State = App.InWorkTaskState;
            App.db.Entry(taskDb).State = EntityState.Modified;
            App.db.SaveChanges();
            LoadData();
        }

        public void RemoveFromInWork(Task task)
        {
            InWorkTasks.Remove(task);
        }

        #endregion

        #region Completed

        public void AddToCompleted(Task task)
        {
            Task taskDb = App.db.Tasks.FirstOrDefault(t => t.Id == task.Id);
            taskDb.State = App.CompletedTaskState;
            App.db.Entry(taskDb).State = EntityState.Modified;
            App.db.SaveChanges();
            LoadData();
        }

        public void RemoveFromCompleted(Task task)
        {
            CompletedTasks.Remove(task);
        }

        #endregion

        public void LoadData() // вывод задач из бд
        {
            Task[] backlogTasks = App.db.Tasks.Where(t => t.State == App.BacklogTaskState && t.ProjectId == Project.Id && !t.IsRemoved).OrderByDescending(t => t.NumberTask).ToArray();
            BacklogTasks.Clear();
            BacklogTasks.AddRange(backlogTasks);
            backlogTasksBox.ItemsSource = null;
            backlogTasksBox.ItemsSource = BacklogTasks;


            Task[] inWorkTask = App.db.Tasks.Where(t => t.State == App.InWorkTaskState && t.ProjectId == Project.Id && !t.IsRemoved).OrderByDescending(t => t.NumberTask).ToArray();
            InWorkTasks.Clear();
            InWorkTasks.AddRange(inWorkTask);
            inWorkTasksBox.ItemsSource = null;
            inWorkTasksBox.ItemsSource = InWorkTasks;

            Task[] completedTasks = App.db.Tasks.Where(t => t.State == App.CompletedTaskState && t.ProjectId == Project.Id && !t.IsRemoved).OrderByDescending(t => t.NumberTask).ToArray();
            CompletedTasks.Clear();
            CompletedTasks.AddRange(completedTasks);
            completedTasksBox.ItemsSource = null;
            completedTasksBox.ItemsSource = CompletedTasks;

            App.RenderInfo("TasksPage", Project.Id);
        }

        private void addButton_Click(object sender, System.Windows.RoutedEventArgs e) // переход в окно добавления задачи
        {
            TaskEditor editor = new TaskEditor(Project.Id, LoadData);
            editor.Owner = App.Current.MainWindow;
            editor.ShowDialog();
        }

        private void editButton_Click(object sender, System.Windows.RoutedEventArgs e) // переход в окно редактирования задачи
        {
            Button button = sender as Button;
            if (button is null) return;

            Guid id = Guid.Parse(button.Tag.ToString());
            Task task = App.db.Tasks.FirstOrDefault(t => t.Id == id);
            TaskEditor editor = new TaskEditor(Project.Id, LoadData, task);
            editor.Owner = App.Current.MainWindow;
            editor.ShowDialog();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            Guid id = Guid.Parse(button.Tag.ToString());
            Task task = App.db.Tasks.FirstOrDefault(t => t.Id == id);
            if (task is null) return;

            if (task.State == App.BacklogTaskState) backlogTasksBox.PreviewMouseLeftButtonDown -= new MouseButtonEventHandler(DragAndDrop.listbox_PreviewMouseLeftButtonDown);
            if (task.State == App.InWorkTaskState) inWorkTasksBox.PreviewMouseLeftButtonDown -= new MouseButtonEventHandler(DragAndDrop.listbox_PreviewMouseLeftButtonDown);
            if (task.State == App.CompletedTaskState) completedTasksBox.PreviewMouseLeftButtonDown -= new MouseButtonEventHandler(DragAndDrop.listbox_PreviewMouseLeftButtonDown);
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            Guid id = Guid.Parse(button.Tag.ToString());
            Task task = App.db.Tasks.FirstOrDefault(t => t.Id == id);
            if (task is null) return;

            if (task.State == App.BacklogTaskState) backlogTasksBox.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(DragAndDrop.listbox_PreviewMouseLeftButtonDown);
            if (task.State == App.InWorkTaskState) inWorkTasksBox.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(DragAndDrop.listbox_PreviewMouseLeftButtonDown);
            if (task.State == App.CompletedTaskState) completedTasksBox.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(DragAndDrop.listbox_PreviewMouseLeftButtonDown);

        }

        private void employeeButton_Click(object sender, RoutedEventArgs e) // переход в окно привязки сотрудника к проекту
        {
            BindingEmployeeWindow window = new BindingEmployeeWindow(Project, LoadData);
            window.Owner = App.Current.MainWindow;
            window.ShowDialog();
        }

        private void editProjectButton_Click(object sender, RoutedEventArgs e) // переход в окно редактирования проекта
        {
            ProjectEditor editor = new ProjectEditor(App.ChangeToProjectsPage, Project);
            editor.Owner = App.Current.MainWindow;
            editor.ShowDialog();
        }
    }
}
