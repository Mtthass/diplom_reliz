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
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        Orders employee = new Orders();

        public OrdersPage()
        {
            InitializeComponent();
            ListOrderDG.ItemsSource = DBEntities.GetContext()
            .Orders.ToList().OrderBy(s => s.IdOrder);
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            int searchNumber;
            bool isNumber = int.TryParse(SearchTb.Text, out searchNumber);

            // Выполнение LINQ-запроса с учетом результата преобразования
            ListOrderDG.ItemsSource = DBEntities.GetContext()
                .Orders.Where(p => p.Supplier.SupplierName.Contains(SearchTb.Text)
                    || p.OrderDate.Contains(SearchTb.Text)
                    || p.Supplier.SupplierName.Contains(SearchTb.Text)
                    || p.StatusOrder.NameStatus.Contains(SearchTb.Text)
                    || (isNumber && p.IdOrder == searchNumber)
                    || (isNumber && p.QuantityProduct == searchNumber)
                    || (isNumber && p.IdPurchase == searchNumber)) // добавлен поиск по целочисленному полю
                .OrderBy(p => p.IdOrder)
                .ToList();
        }

        private void Deleted_Order_Click(object sender, RoutedEventArgs e)
        {
            var selectedOrder = ListOrderDG.SelectedItem as Orders;

            if (selectedOrder == null)
            {
                new MaterialDesignMessageBox("Выберите заказ для удаления!", MessageType.Error, MessageButtons.Ok).ShowDialog();
                return;
            }

            var result = new MaterialDesignMessageBox($"Вы уверены что хотите удалить заказ под ID: {selectedOrder.IdOrder}?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

            if (result == true)
            {
                try
                {
                    var context = DBEntities.GetContext();
                    context.Orders.Remove(selectedOrder);
                    context.SaveChanges();
                    new MaterialDesignMessageBox("Заказ успешно удалён", MessageType.Success, MessageButtons.Ok).ShowDialog();
                    ListOrderDG.Items.Refresh();
                }
                catch (Exception ex)
                {
                    new MaterialDesignMessageBox($"{ex}", MessageType.Error, MessageButtons.Ok).ShowDialog();
                }
            }
        }
    }
}
