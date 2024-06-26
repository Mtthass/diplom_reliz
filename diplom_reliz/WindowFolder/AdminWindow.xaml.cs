﻿using System;
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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private Button _lastClickedButton;
        string login2;
        string roleName2;


            public AdminWindow(string login, string roleName)
            {
                InitializeComponent();
                LoginLabel.Text = login;
                RoleLabel.Text = roleName;
                login2 = login;
                roleName2 = roleName;
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
            new AdminWindow2(login2, roleName2).Show();

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

        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            var clickedButton = sender as Button;

            if (_lastClickedButton != null)
            {
                _lastClickedButton.Style = (Style)FindResource("NormalButtonStyle");
            }

            clickedButton.Style = (Style)FindResource("ActiveButtonStyle");

            _lastClickedButton = clickedButton;

            MainFrame.Navigate(new OrdersPage());
        }

        private void Payments_Click(object sender, RoutedEventArgs e)
        {
            var clickedButton = sender as Button;

            if (_lastClickedButton != null)
            {
                _lastClickedButton.Style = (Style)FindResource("NormalButtonStyle");
            }

            clickedButton.Style = (Style)FindResource("ActiveButtonStyle");

            _lastClickedButton = clickedButton;

            MainFrame.Navigate(new PaymentsPage());
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

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            var clickedButton = sender as Button;

            if (_lastClickedButton != null)
            {
                _lastClickedButton.Style = (Style)FindResource("NormalButtonStyle");
            }

            clickedButton.Style = (Style)FindResource("ActiveButtonStyle");

            _lastClickedButton = clickedButton;

            MainFrame.Navigate(new UsersPage());

        }
    }
}
