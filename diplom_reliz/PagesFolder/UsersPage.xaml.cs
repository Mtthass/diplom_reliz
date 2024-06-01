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
    }
}
