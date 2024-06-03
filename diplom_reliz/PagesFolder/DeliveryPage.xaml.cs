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

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            int searchNumber;
            bool isNumber = int.TryParse(SearchTb.Text, out searchNumber);

            // Выполнение LINQ-запроса с учетом результата преобразования
            ListDeliveryDG.ItemsSource = DBEntities.GetContext()
                .Delivery.Where(p => p.MethodDelivery.NameMethod.Contains(SearchTb.Text)
                    || p.DateDelivery.Contains(SearchTb.Text)
                    || p.StatusDelivery.NameStatus.Contains(SearchTb.Text)
                    || (isNumber && p.IdDelivery == searchNumber)
                    || (isNumber && p.IdOrder == searchNumber)) // добавлен поиск по целочисленному полю
                .OrderBy(p => p.IdDelivery)
                .ToList();
        }

        private void Deleted_Delivery_Click(object sender, RoutedEventArgs e)
        {
            var selectedDelivery = ListDeliveryDG.SelectedItem as Delivery;

            if (selectedDelivery == null)
            {
                new MaterialDesignMessageBox("Выберите доставку для удаления!", MessageType.Error, MessageButtons.Ok).ShowDialog();
                return;
            }

            var result = new MaterialDesignMessageBox($"Вы уверены что хотите удалить доставку под ID: {selectedDelivery.IdDelivery}?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

            if (result == true)
            {
                try
                {
                    var context = DBEntities.GetContext();
                    context.Delivery.Remove(selectedDelivery);
                    context.SaveChanges();
                    new MaterialDesignMessageBox("Доставка успешно удалена", MessageType.Success, MessageButtons.Ok).ShowDialog();
                    ListDeliveryDG.Items.Refresh();
                }
                catch (Exception ex)
                {
                    new MaterialDesignMessageBox($"{ex}", MessageType.Error, MessageButtons.Ok).ShowDialog();
                }
            }
        }
    }
}
