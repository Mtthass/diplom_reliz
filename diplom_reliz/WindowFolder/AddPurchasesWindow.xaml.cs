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
using System.Windows.Shapes;
using diplom_reliz.ClassFolder;
using diplom_reliz.DataFolder;
using diplom_reliz.CustomMessageBox;

namespace diplom_reliz.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для AddPurchasesWindow.xaml
    /// </summary>
    public partial class AddPurchasesWindow : Window
    {
        public AddPurchasesWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ElementsToolsClass.AllFieldsFilled(this))
            {
                var context = DBEntities.GetContext();
                Purchase purchases = new Purchase();
                purchases.DatePurchase = Tb1.Text;
                purchases.DescriptionProduct = Tb2.Text;
                purchases.Price = Tb3.Text;
                purchases.Supplier.SupplierName = Cb1.Text;


                context.Purchase.Add(purchases);
                context.SaveChanges();
                new MaterialDesignMessageBox("Закупка создана", MessageType.Success, MessageButtons.Ok).ShowDialog();
                ElementsToolsClass.ClearAllControls(this);


            }
            else
            {
                new MaterialDesignMessageBox("Заполнены не все поля!", MessageType.Error, MessageButtons.Ok).ShowDialog();
            }
        }
    }
}
