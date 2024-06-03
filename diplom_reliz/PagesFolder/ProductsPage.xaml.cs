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
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        Product employee = new Product();

        public ProductsPage()
        {
            InitializeComponent();
            ListProductDG.ItemsSource = DBEntities.GetContext()
            .Product.ToList().OrderBy(s => s.IdProduct);
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            int searchNumber;
            bool isNumber = int.TryParse(SearchTb.Text, out searchNumber);

            // Выполнение LINQ-запроса с учетом результата преобразования
            ListProductDG.ItemsSource = DBEntities.GetContext()
                .Product.Where(p => p.NameProduct.Contains(SearchTb.Text)
                    || p.Category.NameCategory.Contains(SearchTb.Text)
                    || p.DescriptionProduct.Contains(SearchTb.Text)
                    || p.Quantity.Contains(SearchTb.Text)
                    || p.Price.Contains(SearchTb.Text)
                    || (isNumber && p.IdProduct == searchNumber)) // добавлен поиск по целочисленному полю
                .OrderBy(p => p.IdProduct)
                .ToList();
        }

        private void Deleted_Product_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = ListProductDG.SelectedItem as Product;

            if (selectedProduct == null)
            {
                new MaterialDesignMessageBox("Выберите товар для удаления!", MessageType.Error, MessageButtons.Ok).ShowDialog();
                return;
            }

            var result = new MaterialDesignMessageBox($"Вы уверены что хотите удалить товар под ID: {selectedProduct.IdProduct}?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

            if (result == true)
            {
                try
                {
                    var context = DBEntities.GetContext();
                    context.Product.Remove(selectedProduct);
                    context.SaveChanges();
                    new MaterialDesignMessageBox("Товар успешно удалён", MessageType.Success, MessageButtons.Ok).ShowDialog();
                    ListProductDG.Items.Refresh();
                }
                catch (Exception ex)
                {
                    new MaterialDesignMessageBox($"{ex}", MessageType.Error, MessageButtons.Ok).ShowDialog();
                }
            }
        }

        private void Add_Product_Click(object sender, RoutedEventArgs e)
        {
            new AddProductWindow().Show();
        }
    }
}
