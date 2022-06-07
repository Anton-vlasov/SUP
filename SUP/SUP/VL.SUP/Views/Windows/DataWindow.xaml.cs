using System;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using SUP.Repository;

namespace SUP.Views
{
    /// <summary>
    /// Interaction logic for DataWindow.xaml
    /// </summary>
    public partial class DataWindow : Window
    {
        public Action ReturnAction { get; set; }

        public DataWindow()
        {
            InitializeComponent();
            App.ChangeToProjectsPage();
            App.Current.DispatcherUnhandledException += UnhandledException;
        }

        public void UnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e) // необработанное исключение
        {
            MessageBox.Show("Произошла непредвиденная ошибка, попробуйте снова!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)// вывод сообщения при закрытие приложения
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите закрыть приложение?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                App.Current.Shutdown();
            }
        }

        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) => this.DragMove(); // позволяет двигать окно

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            if (ReturnAction == null) return; // кнопка "назад"

            ReturnAction();
        }

        public void SetReturnAction(Action action)
        {
            ReturnAction = action;
            returnButton.Visibility = Visibility.Visible;

        }

        public void ResetReturnAction()
        {
            ReturnAction = null;
            returnButton.Visibility = Visibility.Hidden;
        }
    }
}
