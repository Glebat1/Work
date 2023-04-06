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
    /// Логика взаимодействия для AddZakaz.xaml
    /// </summary>
    public partial class AddZakaz : Page
    {
        public Order1 po = new Order1();
        private Order1 productfield = new Order1();
        int ip = 0;
        public AddZakaz(Order1 selectedOrder)
        {
            InitializeComponent();

            CmbClient.SelectedValuePath = "ID";
            CmbClient.DisplayMemberPath = "Номер_общежития";
            CmbClient.ItemsSource = AppConnect.model0db.Client.ToList();  

            CmbType.SelectedValuePath = "ID";
            CmbType.DisplayMemberPath = "Название";
            CmbType.ItemsSource = AppConnect.model0db.StorageType.ToList();

            CmbNaim.SelectedValuePath = "ID";
            CmbNaim.DisplayMemberPath = "Наименование";
            CmbNaim.ItemsSource = AppConnect.model0db.Storage.ToList();


            CmbUnit.SelectedValuePath = "ID";
            CmbUnit.DisplayMemberPath = "Название";
            CmbUnit.ItemsSource = AppConnect.model0db.Unit.ToList();
            
            if (selectedOrder != null)
            {
                productfield = selectedOrder;
            }
            DataContext = productfield;
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.GoBack();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            //if (productfield.id_Заказчик <= 0)
            //{
            //    errors.AppendLine("Укажите заказчика");
            //}
            //if (productfield.id_Типа <= 0)
            //{
            //    errors.AppendLine("Укажите тип");
            //}
            ////if (productfield.Наименование <= 0)
            ////{
            ////    errors.AppendLine("Укажите наименование");
            ////}
            //if (productfield.id_Единица_Измерения <= 0)
            //{
            //    errors.AppendLine("Укажите ед.измерения");
            //}
            //if (productfield.Кол_во <= 0)
            //{
            //    errors.AppendLine("Укажите количество");
            //}

            //if (errors.Length > 0)
            //{
            //    MessageBox.Show(errors.ToString());
            //    return;
            //}
            try
            {
                if (AccountHelpClass.Id == 1)
                {
                    Order1 PrObj = new Order1()
                    {

                        Client = CmbClient.SelectedItem as Client,
                        StorageType = CmbType.SelectedItem as StorageType,
                        Наименование = CmbNaim.Text,
                        Unit = CmbUnit.SelectedItem as Unit,
                        Кол_во = Convert.ToInt32(TxbKolvo.Text),
                    };
                    AppConnect.model0db.Order1.Add(PrObj);
                    
                   
                }
                //string S = Convert.ToString(CmbNaim.SelectedItem);
                //var G = AppConnect.model0db.Storage.Where(x => x.Наименование == S);
                //var J = G.First().На_Складе;
                //MessageBox.Show(Convert.ToString(J));
                //int F = Convert.ToInt32(TxbKolvo.Text);
                //int H = Convert.ToInt32(J);
                //J = H - F;
                AppConnect.model0db.SaveChanges();
                AppFrame.frameMain.GoBack();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Ошибка:" + ex.Message.ToString(), "Критическая ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Zakaz());

        }
    }
}