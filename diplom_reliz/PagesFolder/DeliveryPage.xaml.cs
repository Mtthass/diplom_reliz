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
    /// Логика взаимодействия для DeliveryPage.xaml
    /// </summary>
    public partial class DeliveryPage : Page
    {
        Delivery employee = new Delivery();

        public DeliveryPage()
        {
            InitializeComponent();
            ListDeliveryDG.ItemsSource = DBEntities.GetContext()
            .Delivery.ToList().OrderBy(s => s.IdDelivery);
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddDeliveryWindow().Show();
        }
    }
}
