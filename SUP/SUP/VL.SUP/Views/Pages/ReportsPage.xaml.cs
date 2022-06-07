using Microsoft.Win32;
using System;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using SUP.Repository;
using SUP.Tools;

namespace SUP.Views.Pages
{
    /// <summary>
    /// Interaction logic for ReportsPage.xaml
    /// </summary>
    public partial class ReportsPage : Page
    {
        public ReportsPage()
        {
            InitializeComponent();
            Project[] projects = App.db.Projects.Where(p => !p.IsRemoved).ToArray(); // отображение существующих проектов для отчета
            projectBox.ItemsSource = projects;
        }

        private async void pdfButton_Click(object sender, RoutedEventArgs e) // формирования отчета в формате pdf
        {
            Project project = projectBox.SelectedItem as Project;
            if (project is null)
            {
                MessageBox.Show("Выберите проект для отчета", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Файл формата PDF | *.pdf";
            if(sfd.ShowDialog() == true)
            {
                progressPdf.Visibility = Visibility.Visible;
                for (int i = 0; i < 30; i++)
                {
                    progressPdf.Value += 1;
                }
                await ReportWriter.RenderPdfReport(project, sfd.FileName);

                for (int i = 50; i <= 100; i++)
                {
                    progressPdf.Value += 1;
                    Thread.Sleep(1);
                }
                progressPdf.Visibility = Visibility.Hidden;
            }
        }

        private async void excelButton_Click(object sender, RoutedEventArgs e) // формирование отчета в формате excel
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Файл формата Excel | *.xlsx";
            if (sfd.ShowDialog() == true)
            {
                progressExcel.Visibility = Visibility.Visible;
                for (int i = 0; i < 30; i++)
                {
                    progressExcel.Value += 1;
                }
                await ReportWriter.RenderExcelReport(sfd.FileName);

                for (int i = 50; i <= 100; i++)
                {
                    progressExcel.Value += 1;
                    Thread.Sleep(1);
                }
                progressExcel.Visibility = Visibility.Hidden;
            }
        }
    }
}
