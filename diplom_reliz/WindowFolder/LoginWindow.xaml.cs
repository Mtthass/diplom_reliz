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
using diplom_reliz.ClassFolder;
using diplom_reliz.WindowFolder;
using diplom_reliz.DataFolder;
using diplom_reliz.CustomMessageBox;

namespace diplom_reliz.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void MinimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void MaximazeOrMinimizeBtn_Click(object sender, RoutedEventArgs e)
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

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTb.Text))
            {
                new MaterialDesignMessageBox("Введите логин", MessageType.Error, MessageButtons.Ok).ShowDialog();
                LoginTb.Focus();
            }
            else if (string.IsNullOrWhiteSpace(PassswordPb.Password))
            {
                new MaterialDesignMessageBox("Введите пароль", MessageType.Error, MessageButtons.Ok).ShowDialog();
                PassswordPb.Focus();
            }
            else
            {
                try
                {
                    var user = DBEntities.GetContext()
                        .User
                        .FirstOrDefault(u => u.Login == LoginTb.Text);
                    if (user == null || user.Password != PassswordPb.Password)
                    {
                        
                        new MaterialDesignMessageBox("Неверные данные", MessageType.Error, MessageButtons.Ok).ShowDialog();
                        return;
                    }
                    else
                    {
                        string roleName = string.Empty;
                        switch (user.IdRole)
                        {
                            case 1:
                                roleName = "Администратор";
                                new MaterialDesignMessageBox($"{roleName}, добро пожаловать", MessageType.Info, MessageButtons.Ok).ShowDialog();
                                new AdminWindow(user.Login, roleName).Show();
                                break;
                            case 2:
                                roleName = "Менеджер";
                                new MaterialDesignMessageBox($"{roleName}, добро пожаловать", MessageType.Info, MessageButtons.Ok).ShowDialog();
                                new ManagerWindow(user.Login, roleName).Show();
                                break;
                            case 3:
                                roleName = "Закупщик";
                                new MaterialDesignMessageBox($"{roleName}, добро пожаловать", MessageType.Info, MessageButtons.Ok).ShowDialog();
                                new ZakupchikWindow(user.Login, roleName).Show();
                                break;
                        }
                        this.Close(); // Закрытие окна логина после успешного входа
                    }
                }
                catch (Exception ex)
                {
                    new MaterialDesignMessageBox($"{ex}", MessageType.Error, MessageButtons.Ok).ShowDialog();
                }
            }
        }
    }
}
