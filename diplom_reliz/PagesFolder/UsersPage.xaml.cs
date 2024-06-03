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
using System.Windows.Navigation;
using System.Windows.Shapes;
using diplom_reliz.WindowFolder;
using diplom_reliz.DataFolder;
using diplom_reliz.ClassFolder;
using diplom_reliz.PagesFolder;


namespace diplom_reliz.PagesFolder
{
    /// <summary>
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        User employee = new User();

        public UsersPage()
        {
            InitializeComponent();
            ListUserDG.ItemsSource = DBEntities.GetContext()
            .User.ToList().OrderBy(s => s.IdUser);
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddUsersWindow().Show();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int searchNumber;
            bool isNumber = int.TryParse(SearchTb.Text, out searchNumber);

            // Выполнение LINQ-запроса с учетом результата преобразования
            ListUserDG.ItemsSource = DBEntities.GetContext()
                .User.Where(p => p.Login.Contains(SearchTb.Text)
                    || p.Password.Contains(SearchTb.Text)
                    || p.Role.NameRole.Contains(SearchTb.Text)
                    || (isNumber && p.IdUser == searchNumber)) // добавлен поиск по целочисленному полю
                .OrderBy(p => p.Login)
                .ToList();
        }
        private void DeletedClick_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedUser = ListUserDG.SelectedItem as User;

                if (selectedUser == null)
                {
                    MessageBox.Show("Выберите работника для удаления");
                }

                var user = DBEntities.GetContext().User.FirstOrDefault(u => u.IdUser == selectedUser.IdUser);

                if (user == null)
                {
                    MessageBox.Show("Работник не найден");
                }

                bool result = MBClass.QuestionMB("Вы действительно хотите удалить сотрудника?");
                if (result == true)
                {
                    DBEntities.GetContext().User.Remove(user);
                    DBEntities.GetContext().SaveChanges();
                    MessageBox.Show("Работник удален");
                    ListUserDG.Items.Refresh();
                }

            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
    
}
