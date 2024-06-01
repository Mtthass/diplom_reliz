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

namespace diplom_reliz.PagesFolder
{
    /// <summary>
    /// Логика взаимодействия для ProviderPage.xaml
    /// </summary>
    public partial class ProviderPage : Page
    {

        Supplier employee = new Supplier();

        public ProviderPage()
        {
            InitializeComponent();
            ListSupplierDG.ItemsSource = DBEntities.GetContext()
            .Supplier.ToList().OrderBy(s => s.IdSupplier);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new AddProviderWindow().Show();
        }
    }
}
