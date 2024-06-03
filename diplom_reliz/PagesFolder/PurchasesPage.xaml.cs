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
using diplom_reliz.ClassFolder;
using diplom_reliz.CustomMessageBox;

namespace diplom_reliz.PagesFolder
{
    /// <summary>
    /// Логика взаимодействия для PurchasesPage.xaml
    /// </summary>
    public partial class PurchasesPage : Page
    {

        Purchase purchase = new Purchase();

        public PurchasesPage()
        {
            InitializeComponent();
            ListPurchaseDG.ItemsSource = DBEntities.GetContext()
            .Purchase.ToList().OrderBy(s => s.IdPurchase);
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            int searchNumber;
            bool isNumber = int.TryParse(SearchTb.Text, out searchNumber);

            // Выполнение LINQ-запроса с учетом результата преобразования
            ListPurchaseDG.ItemsSource = DBEntities.GetContext()
                .Purchase.Where(p => p.DatePurchase.Contains(SearchTb.Text)
                    || p.DescriptionProduct.Contains(SearchTb.Text)
                    || p.Supplier.SupplierName.Contains(SearchTb.Text)
                    || p.Price.Contains(SearchTb.Text)
                    || p.StatusPurchase.NameStatus.Contains(SearchTb.Text)
                    || (isNumber && p.IdPurchase == searchNumber)) // добавлен поиск по целочисленному полю
                .OrderBy(p => p.IdPurchase)
                .ToList();
        }

        private void Deleted_Purchases_Click(object sender, RoutedEventArgs e)
        {
            var selectedManufacturer = ListPurchaseDG.SelectedItem as Purchase;

            if (selectedManufacturer == null)
            {
                new MaterialDesignMessageBox("Выберите закупку для удаления!", MessageType.Error, MessageButtons.Ok).ShowDialog();
                return;
            }

            var result = new MaterialDesignMessageBox($"Вы уверены что хотите удалить закупку под ID:{selectedManufacturer.IdPurchase}?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

            if (result == true)
            {
                try
                {
                    var context = DBEntities.GetContext();
                    context.Purchase.Remove(selectedManufacturer);
                    context.SaveChanges();
                    new MaterialDesignMessageBox("Закупка успешно удалена", MessageType.Success, MessageButtons.Ok).ShowDialog();
                    ListPurchaseDG.Items.Refresh();
                }
                catch (Exception ex)
                {
                    new MaterialDesignMessageBox($"{ex}", MessageType.Error, MessageButtons.Ok).ShowDialog();
                }
            }

        }

        private void Add_Purchases_Click(object sender, RoutedEventArgs e)
        {
            new AddPurchasesWindow().Show();
        }
    }
}
