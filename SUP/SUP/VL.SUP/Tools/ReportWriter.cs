using System;
using System.Diagnostics;
using System.Linq;
using SUP.Repository;
using Excel = Microsoft.Office.Interop.Excel;
using ThTask = System.Threading.Tasks.Task;
using Word = Microsoft.Office.Interop.Word;

namespace SUP.Tools
{
    public static class ReportWriter
    {
        public static async ThTask RenderPdfReport(Project project, String filePath) //визуализация отчет в формате pdf
        {
            await ThTask.Run(() =>
            {
                Word.Application wordApp = new Word.Application();
                Word.Document wordDoc = wordApp.Documents.Add();
                wordDoc.Activate();

                Word.Paragraph paragraphTitle = wordDoc.Paragraphs.Add();
                Word.Range titleRange = paragraphTitle.Range;

                #region Title

                titleRange.Text = $"АО «ВНИКТИ»\nОтчёт по проекту {project.Name}";
                titleRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                titleRange.Font.Size = 20;
                titleRange.Font.Bold = 1;
                titleRange.InsertParagraphAfter();

                #endregion

                Word.Paragraph descriptionParagraph = wordDoc.Paragraphs.Add();
                Word.Range descriptionRange = descriptionParagraph.Range;
                descriptionRange.Text = $"Описание проекта: {project.Description}";
                descriptionRange.InsertParagraphAfter();

                Employee[] employees = App.db.ProjectWorks.Where(pw => pw.DateEnd == null && pw.ProjectId == project.Id).Select(pw => pw.Employee).ToArray();
                Task[] tasks = App.db.Tasks.Where(t => t.ProjectId == project.Id && !t.IsRemoved).ToArray();

                Word.Paragraph employeesTitleParagraph = wordDoc.Paragraphs.Add();
                Word.Range employeesTitleRange = employeesTitleParagraph.Range;
                employeesTitleRange.Text = "Сотрудники проекта";
                employeesTitleRange.InsertParagraphAfter();

                Word.Paragraph tableParagraph = wordDoc.Paragraphs.Add();
                Word.Range tableRange = tableParagraph.Range;
                tableRange.Text = "Сотрудники проекта";
                Word.Table table = tableRange.Tables.Add(tableRange, employees.Length + 1, 3);

                String[] titles = { "ФИО", "Тип сотрудника", "Зарплата, р." };
                for (int i = 0; i < titles.Length; i++)
                {
                    table.Cell(1, i + 1).Range.Text = titles[i];
                }

                for (int i = 0; i < employees.Length; i++)
                {
                    Employee emp = employees[i];
                    table.Cell(i + 2, 1).Range.Text = emp.FullName;
                    table.Cell(i + 2, 2).Range.Text = emp.EmployeeType.Title;
                    table.Cell(i + 2, 3).Range.Text = emp.EmployeeType.Salary.ToString();
                }
                tableRange.InsertParagraphAfter();

                Word.Paragraph tasksTitleParagraph = wordDoc.Paragraphs.Add();
                Word.Range tasksTitleRange = tasksTitleParagraph.Range;
                tasksTitleRange.Text = "Задачи проекта";
                tasksTitleRange.InsertParagraphAfter();

                Word.Paragraph tableTasksParagraph = wordDoc.Paragraphs.Add();
                tableTasksParagraph.TabHangingIndent(1);
                Word.Range tableTasksRange = tableTasksParagraph.Range;
                tableTasksRange.Text = "Задачи проекта";
                Word.Table tableTasks = tableTasksRange.Tables.Add(tableTasksRange, tasks.Length + 1, 3);

                String[] tasksTitles = { "Название", "Описание", "Состояние" };
                for (int i = 0; i < tasksTitles.Length; i++)
                {
                    tableTasks.Cell(1, i + 1).Range.Text = tasksTitles[i];
                }

                for (int i = 0; i < tasks.Length; i++)
                {
                    Task task = tasks[i];
                    tableTasks.Cell(i + 2, 1).Range.Text = task.Title;
                    tableTasks.Cell(i + 2, 2).Range.Text = task.Description;
                    tableTasks.Cell(i + 2, 3).Range.Text = task.TaskState.State;
                }

                #region Table Borders

                Word.WdBorderType[] borders = new[]
                {
                Word.WdBorderType.wdBorderBottom,
                Word.WdBorderType.wdBorderLeft,
                Word.WdBorderType.wdBorderRight,
                Word.WdBorderType.wdBorderTop,
                Word.WdBorderType.wdBorderVertical,
                Word.WdBorderType.wdBorderHorizontal
                };

                foreach (Word.WdBorderType border in borders)
                {
                    tableTasks.Borders[border].LineStyle = table.Borders[border].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
                    tableTasks.Borders[border].LineWidth = table.Borders[border].LineWidth = Word.WdLineWidth.wdLineWidth050pt;
                    tableTasks.Borders[border].Color = table.Borders[border].Color = Word.WdColor.wdColorBlack;

                }

                #endregion

                tableTasks.Range.ParagraphFormat.Alignment = table.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                tableTasks.Rows.First.Range.Bold = table.Rows.First.Range.Bold = 1;

                wordDoc.SaveAs(filePath, Word.WdExportFormat.wdExportFormatPDF);
                Object saveNotSaveChanges = (Object)Word.WdSaveOptions.wdDoNotSaveChanges;
                wordDoc.Close(saveNotSaveChanges);
                wordApp.Quit();

                wordDoc = null;
                wordApp = null;

                Process.Start(filePath);
            });
        }

        public static async ThTask RenderExcelReport(String filePath) //визуализация отчета в формате excel
        {
            await ThTask.Run(() =>
            {
                Excel.Application xlApp = new Excel.Application();
                xlApp.Visible = false;
                xlApp.DisplayAlerts = false;
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Add();
                Excel.Worksheet sheet = xlWorkbook.Worksheets[1];
                sheet.Name = "Отчет отпусков";
                Excel.Range range = sheet.Range["A1", "D1"].Cells;
                sheet.Cells[1, 1] = "Отпуска сотрудников";
                Excel.Range titleRange = sheet.Cells[1, 1];
                titleRange.HorizontalAlignment = Excel.Constants.xlCenter;
                range.Merge();

                Vacation[] vacations = App.db.Vacations.OrderBy(v => v.DateStart).ToArray();
                for (int i = 2; i <= vacations.Length + 1; i++)
                {
                    Vacation vacation = vacations[i - 2];
                    sheet.Cells[i, 1] = vacation.EmployeeName;
                    sheet.Cells[i, 2] = vacation.DateStartOnlyDate;
                    sheet.Cells[i, 3] = vacation.DateEndOnlyDate;
                    sheet.Cells[i, 4] = String.IsNullOrWhiteSpace(vacation.Comment) ? "Комментарий отсутсвует" : vacation.Comment;
                }
                Excel.Range sheetRange = sheet.Columns;
                sheetRange.AutoFit();
                sheet.SaveAs(filePath);
                xlApp.Quit();
                sheet = null;
                xlApp = null;

                Process.Start(filePath);
            });
        }
    }
}
