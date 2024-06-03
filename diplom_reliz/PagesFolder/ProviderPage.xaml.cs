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
using diplom_reliz.CustomMessageBox;

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

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            int searchNumber;
            bool isNumber = int.TryParse(SearchTb.Text, out searchNumber);

            // Выполнение LINQ-запроса с учетом результата преобразования
            ListSupplierDG.ItemsSource = DBEntities.GetContext()
                .Supplier.Where(p => p.SupplierName.Contains(SearchTb.Text)
                    || p.Address.Contains(SearchTb.Text)
                    || p.Phone.Contains(SearchTb.Text)
                    || p.Email.Contains(SearchTb.Text)
                    || p.Website.Contains(SearchTb.Text)
                    || p.StatusSupplier.NameStatus.Contains(SearchTb.Text)
                    || (isNumber && p.IdSupplier == searchNumber)) // добавлен поиск по целочисленному полю
                .OrderBy(p => p.SupplierName)
                .ToList();
        }

        private void Deleted_Provider_Click(object sender, RoutedEventArgs e)
        {
            var selectedSupplier = ListSupplierDG.SelectedItem as Supplier;

            if (selectedSupplier == null)
            {
                new MaterialDesignMessageBox("Выберите поставщика для удаления!", MessageType.Error, MessageButtons.Ok).ShowDialog();
                return;
            }

            var result = new MaterialDesignMessageBox($"Вы уверены что хотите удалить поставщика под ID: {selectedSupplier.IdSupplier}?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

            if (result == true)
            {
                try
                {
                    var context = DBEntities.GetContext();
                    context.Supplier.Remove(selectedSupplier);
                    context.SaveChanges();
                    new MaterialDesignMessageBox("Поставщик успешно удалён", MessageType.Success, MessageButtons.Ok).ShowDialog();
                    ListSupplierDG.Items.Refresh();
                }
                catch (Exception ex)
                {
                    new MaterialDesignMessageBox($"{ex}", MessageType.Error, MessageButtons.Ok).ShowDialog();
                }
            }
        }

        private void Add_Provider_Click(object sender, RoutedEventArgs e)
        {
            new AddProviderWindow().Show();
            ListSupplierDG.Items.Refresh();
        }
    }
}
