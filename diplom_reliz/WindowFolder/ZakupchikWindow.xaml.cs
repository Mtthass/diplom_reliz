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
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;
using diplom_reliz.PagesFolder;

namespace diplom_reliz.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для ZakupchikWindow.xaml
    /// </summary>
    public partial class ZakupchikWindow : Window
    {
        private Button _lastClickedButton;
        public ZakupchikWindow(string login, string roleName)
        {
            InitializeComponent();
            LoginLabel.Text = login;
            RoleLabel.Text = roleName;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
                (MaximazeOrMinimizeBtn.Content as PackIcon).Kind = PackIconKind.WindowRestore;
            }
            else
            {
                WindowState = WindowState.Normal;
                (MaximazeOrMinimizeBtn.Content as PackIcon).Kind = PackIconKind.CropSquare;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Purchases_Click(object sender, RoutedEventArgs e)
        {
            var clickedButton = sender as Button;

            if (_lastClickedButton != null)
            {
                _lastClickedButton.Style = (Style)FindResource("NormalButtonStyle");
            }

            clickedButton.Style = (Style)FindResource("ActiveButtonStyle");

            _lastClickedButton = clickedButton;

            MainFrame.Navigate(new PurchasesPage());
        }

        private void Products_Click(object sender, RoutedEventArgs e)
        {
            var clickedButton = sender as Button;

            if (_lastClickedButton != null)
            {
                _lastClickedButton.Style = (Style)FindResource("NormalButtonStyle");
            }

            clickedButton.Style = (Style)FindResource("ActiveButtonStyle");

            _lastClickedButton = clickedButton;

            MainFrame.Navigate(new ProductsPage());
        }

        private void Delivery_Click(object sender, RoutedEventArgs e)
        {
            var clickedButton = sender as Button;

            if (_lastClickedButton != null)
            {
                _lastClickedButton.Style = (Style)FindResource("NormalButtonStyle");
            }

            clickedButton.Style = (Style)FindResource("ActiveButtonStyle");

            _lastClickedButton = clickedButton;

            MainFrame.Navigate(new DeliveryPage());
        }

        private void Provider_Click(object sender, RoutedEventArgs e)
        {
            var clickedButton = sender as Button;

            if (_lastClickedButton != null)
            {
                _lastClickedButton.Style = (Style)FindResource("NormalButtonStyle");
            }

            clickedButton.Style = (Style)FindResource("ActiveButtonStyle");

            _lastClickedButton = clickedButton;

            MainFrame.Navigate(new ProviderPage());
        }
    }
}
