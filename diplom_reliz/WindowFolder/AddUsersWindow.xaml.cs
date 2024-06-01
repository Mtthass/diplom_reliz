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
using System.Data.SqlClient;
using diplom_reliz.ClassFolder;
using diplom_reliz.DataFolder;
using diplom_reliz.CustomMessageBox;

namespace diplom_reliz.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для AddUsersWindow.xaml
    /// </summary>
    public partial class AddUsersWindow : Window
    {
        public AddUsersWindow()
        {
            InitializeComponent();
            Cb1.ItemsSource = DBEntities.GetContext().Role.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FormBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Tb1.Text))
            {
                new MaterialDesignMessageBox("Введите логин", MessageType.Error, MessageButtons.Ok).ShowDialog();
            }
            else if (string.IsNullOrEmpty(Tb2.Text))
            {
                new MaterialDesignMessageBox("Введите пароль", MessageType.Error, MessageButtons.Ok).ShowDialog();
            }
            else if (Cb1.SelectedIndex == -1)
            {
                new MaterialDesignMessageBox("Вы не выбрали роль", MessageType.Error, MessageButtons.Ok).ShowDialog();
            }           
            else if (DBEntities.GetContext()
                        .User
                        .FirstOrDefault(
                u => u.Login == Tb1.Text) != null)
            {
                new MaterialDesignMessageBox("Пользователь с таким логином уже существует", MessageType.Error, MessageButtons.Ok).ShowDialog();

                Tb1.Focus();

            }
            else
            {
                var context = DBEntities.GetContext();
                User user = new User();
                user.Login = Tb1.Text;
                user.Password = Tb2.Text;
                user.IdRole = Int32.Parse
                    (Cb1.SelectedValue.ToString());              
                context.User.Add(user);
                context.SaveChanges();
                new MaterialDesignMessageBox("Пользователь создан", MessageType.Success, MessageButtons.Ok).ShowDialog();
                ElementsToolsClass.ClearAllControls(this);
                Cb1.ItemsSource = DBEntities.GetContext()
                .User.ToList().OrderBy(u => u.Login);
            }
        }
    }
}
