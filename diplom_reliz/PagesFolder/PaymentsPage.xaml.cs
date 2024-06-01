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
    /// Логика взаимодействия для PaymentsPage.xaml
    /// </summary>
    public partial class PaymentsPage : Page
    {
        Payment employee = new Payment();

        public PaymentsPage()
        {
            InitializeComponent();
            ListPaymentDG.ItemsSource = DBEntities.GetContext()
            .Payment.ToList().OrderBy(s => s.IdPayment);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new AddPaymentsWindow().Show();
        }
    }
}
