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
using ВКР_общежитие.PapkaAdmin;

namespace ВКР_общежитие.Add
{
    /// <summary>
    /// Логика взаимодействия для AddSupply.xaml
    /// </summary>
    public partial class AddSupply : Page
    {
        public Supply po = new Supply();
        private Supply productfield = new Supply();
        int ip = 0;
        public AddSupply(Supply selectedSupply)
        {
            InitializeComponent();

            CmbTowNakl.SelectedValuePath = "ID";
            CmbTowNakl.DisplayMemberPath = "Номер_документа";
            CmbTowNakl.ItemsSource = AppConnect.model0db.TowarNakl.ToList();
            if (selectedSupply != null)
            {
                productfield = selectedSupply;
            }
            DataContext = productfield;
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.GoBack();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            //StringBuilder errors = new StringBuilder();
            //if (productfield.ID_Товарной_накладной <= 0)
            //{
            //    errors.AppendLine("Укажите товарную накладную");
            //}
            ////if (string.IsNullOrWhiteSpace(productfield.Дата))
            ////{
            ////    errors.AppendLine("Укажите название организации!");
            ////}

            //if (productfield.Поставщик <= 0)
            //{
            //    errors.AppendLine("Укажите поставщика");
            //}


            //if (errors.Length > 0)
            //{
            //    MessageBox.Show(errors.ToString());
            //    return;
            //}
            //try
            //{
            //    if (AccountHelpClass.Id == 1)
            //    {
            //        Supply PrObj = new Supply()
            //        {
            //            ID_Товарной_накладной = CmbTowNakl.SelectedItem as TowarNakl,
            //            Provider = CmbPost.SelectedItem as Provider,
            //            Дата = TxbData.Text,


            //        };
            //        AppConnect.model0db.Supply.Add(PrObj);

            //    }
            //    AppConnect.model0db.SaveChanges();
            //    AppFrame.frameMain.GoBack();

            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show("Ошибка:" + ex.Message.ToString(), "Критическая ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
        }
        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Supply1());

        }
    }
    }
