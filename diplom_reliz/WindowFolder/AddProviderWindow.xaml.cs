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
    /// Логика взаимодействия для AddProviderWindow.xaml
    /// </summary>
    public partial class AddProviderWindow : Window
    {
        public AddProviderWindow()
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
                Supplier provider = new Supplier();
                provider.SupplierName = Tb1.Text;
                provider.Address = Tb2.Text;
                provider.Phone = Tb3.Text;
                provider.Email = Cb1.Text;
                provider.Website = Cb2.Text;


                context.Supplier.Add(provider);
                context.SaveChanges();
                new MaterialDesignMessageBox("Поставщик создан", MessageType.Success, MessageButtons.Ok).ShowDialog();
                ElementsToolsClass.ClearAllControls(this);
                

            }            
            else
            {
                new MaterialDesignMessageBox("Заполнены не все поля!", MessageType.Error, MessageButtons.Ok).ShowDialog();
            }
        }
    }
}
