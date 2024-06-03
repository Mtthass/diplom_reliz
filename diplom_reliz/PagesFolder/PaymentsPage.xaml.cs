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
using diplom_reliz.CustomMessageBox;

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

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            int searchNumber;
            bool isNumber = int.TryParse(SearchTb.Text, out searchNumber);

            // Выполнение LINQ-запроса с учетом результата преобразования
            ListPaymentDG.ItemsSource = DBEntities.GetContext()
                .Payment.Where(p => p.DatePayment.Contains(SearchTb.Text)
                    || p.MethodPayment.NameMethod.Contains(SearchTb.Text)
                    || p.AmountPayment.Contains(SearchTb.Text)
                    || p.StatusPayment.NameStatus.Contains(SearchTb.Text)
                    || (isNumber && p.IdPayment == searchNumber)
                    || (isNumber && p.IdOrder == searchNumber))// добавлен поиск по целочисленному полю
                .OrderBy(p => p.IdPayment)
                .ToList();
        }

        private void Deleted_Payment_Click(object sender, RoutedEventArgs e)
        {
            var selectedPayment = ListPaymentDG.SelectedItem as Payment;

            if (selectedPayment == null)
            {
                new MaterialDesignMessageBox("Выберите платёж для удаления!", MessageType.Error, MessageButtons.Ok).ShowDialog();
                return;
            }

            var result = new MaterialDesignMessageBox($"Вы уверены что хотите удалить платёж под ID: {selectedPayment.IdPayment}?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

            if (result == true)
            {
                try
                {
                    var context = DBEntities.GetContext();
                    context.Payment.Remove(selectedPayment);
                    context.SaveChanges();
                    new MaterialDesignMessageBox("Платёж успешно удалён", MessageType.Success, MessageButtons.Ok).ShowDialog();
                    ListPaymentDG.Items.Refresh();
                }
                catch (Exception ex)
                {
                    new MaterialDesignMessageBox($"{ex}", MessageType.Error, MessageButtons.Ok).ShowDialog();
                }
            }
        }
    }
}
