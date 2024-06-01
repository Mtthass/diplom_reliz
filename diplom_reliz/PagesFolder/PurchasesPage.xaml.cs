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
using diplom_reliz.PagesFolder;

namespace diplom_reliz.PagesFolder
{
    /// <summary>
    /// Логика взаимодействия для PurchasesPage.xaml
    /// </summary>
    public partial class PurchasesPage : Page
    {

        Purchase employee = new Purchase();

        public PurchasesPage()
        {
            InitializeComponent();
            ListPurchaseDG.ItemsSource = DBEntities.GetContext()
            .Purchase.ToList().OrderBy(s => s.IdPurchase);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new AddPurchasesWindow().Show();
        }
    }
}
