using System;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using SUP.Repository;
using SUP.Views;
using SUP.Views.Pages;
using WpfApp1.Views.Pages;

namespace SUP
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static readonly Guid BacklogTaskState = Guid.Parse("8d201511-f74a-448a-9b04-3177fb3156c7");
        public static readonly Guid InWorkTaskState = Guid.Parse("de054313-51a5-4215-8ba0-a10bac9f0ff0");
        public static readonly Guid CompletedTaskState = Guid.Parse("375afdb1-9cbc-428d-848d-75f52f066414");

        public static SUPEntities db = new SUPEntities();

        public static ProjectsPage ProjectsPage;
        public static EmployeesPage EmployeesPage;
        public static VacationsPage VacationsPage;
        public static TasksPage TasksPage;
        public static ReportsPage ReportsPage;
        public static ArchivePage ArchivePage;
        private static DataWindow _window => App.Current?.MainWindow as DataWindow;


        public static void ChangeToProjectsPage()
        {
            if (ProjectsPage is null) ProjectsPage = new ProjectsPage();
            else ProjectsPage.LoadData();

            _window.mainFrame.Content = ProjectsPage;
            _window.ResetReturnAction();
            _window.frameTitle.Text = "Проекты";
            RenderInfo("ProjectsPage");
        }

        public static void RenderInfo(String typePage, Guid? ProjectId = null)
        {
            if (typePage == "ProjectsPage")
            {
                Int32 projectsCount = db.Projects.Where(p => !p.IsRemoved).Count();
                _window.infoBlock.Text = $"Активных проектов: {projectsCount}"; //Выводит количество активных проектов
            }

            if (typePage == "ArchivesPage")
            {
                Int32 archiveCount = db.Projects.Where(p => p.IsRemoved).Count();
                _window.infoBlock.Text = $"Проектов в архиве: {archiveCount}";
            }

            if (typePage == "EmployeesPage")
            {
                Int32 employeeCount = db.Employees.Where(e => !e.IsRemoved).Count();
                _window.infoBlock.Text = $"Сотрудников: {employeeCount}";// выводит количество всех сотрудников
            }

            if (typePage == "TasksPage")
            {
                Int32 tasksCount = db.Tasks.Where(t => t.ProjectId == ProjectId && t.State == CompletedTaskState && !t.IsRemoved).Count();
                _window.infoBlock.Text = $"Завершено задач: {tasksCount}"; // выводит количество завершенных задач
            }

            if (typePage == "ReportsPage")
            {
                _window.infoBlock.Text = "";
            }

            if (typePage == "VacationsPage")
            {
                Int32 vacationsCount = db.Vacations.Where(v => !v.IsRemoved && v.DateStart.Year == DateTime.Now.Year).Count();
                _window.infoBlock.Text = $"Отпусков за {DateTime.Now.Year} год: {vacationsCount}"; // выводит количество отпусков за год
            }
        }

        public static void ChangeToTasksPage(Project project)
        {
            TasksPage = new TasksPage(project);
            _window.mainFrame.Content = TasksPage;
            _window.SetReturnAction(ChangeToProjectsPage);
            _window.frameTitle.Text = $"{project.Name}";
            RenderInfo("TasksPage", project.Id);
        }

        public static void ChangeToReportsPage()
        {
            ReportsPage = new ReportsPage();
            _window.mainFrame.Content = ReportsPage;
            _window.SetReturnAction(ChangeToProjectsPage);
            _window.frameTitle.Text = "";
            RenderInfo("ReportsPage");

        }

        public static void ChangeToEmployeesPage()
        {
            EmployeesPage = new EmployeesPage();

            _window.mainFrame.Content = EmployeesPage;
            _window.SetReturnAction(ChangeToProjectsPage);
            _window.frameTitle.Text = "Сотрудники";
            RenderInfo("EmployeesPage");
        }

        public static void ChangeToVacationsPage()
        {
            VacationsPage = new VacationsPage();
            _window.mainFrame.Content = VacationsPage;
            _window.SetReturnAction(ChangeToEmployeesPage);
            _window.frameTitle.Text = "Отпуска";
            RenderInfo("VacationsPage");
        }

        public static void ChangeToArchivePage()
        {
            ArchivePage = new ArchivePage();
            _window.mainFrame.Content = ArchivePage;
            _window.SetReturnAction(ChangeToProjectsPage);
            _window.frameTitle.Text = "Архив";
            RenderInfo("ArchivesPage");
        }
    }
}
