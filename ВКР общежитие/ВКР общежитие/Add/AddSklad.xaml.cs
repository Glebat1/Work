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
    /// Логика взаимодействия для AddSklad.xaml
    /// </summary>
    public partial class AddSklad : Page
    {
        public Storage po = new Storage();
        private Storage productfield = new Storage();
        int ip = 0;
        public AddSklad(Storage selectedStorage)
        {
            InitializeComponent();
           
            CmbPost.SelectedValuePath = "ID";
            CmbPost.DisplayMemberPath = "Название_Организации";
            CmbPost.ItemsSource = AppConnect.model0db.Provider.ToList();
            
            CmbType.SelectedValuePath = "ID";
            CmbType.DisplayMemberPath = "Название";
            CmbType.ItemsSource = AppConnect.model0db.StorageType.ToList();
           
            CmbNakl.SelectedValuePath = "ID";
            CmbNakl.DisplayMemberPath = "Номер_документа";
            CmbNakl.ItemsSource = AppConnect.model0db.TowarNakl.ToList();
            
            CmbEdIzm.SelectedValuePath = "ID";
            CmbEdIzm.DisplayMemberPath = "Название";
            CmbEdIzm.ItemsSource = AppConnect.model0db.Unit.ToList();
            
            if (selectedStorage != null)
            {
                productfield = selectedStorage;
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
            if (string.IsNullOrWhiteSpace(productfield.Артикул))
            {
                errors.AppendLine("Укажите артикул");
            }
            if (productfield.id_Поставщика <= 0)
            {
                errors.AppendLine("Укажите поставщика");
            }
            if (productfield.id_Типа <= 0)
            {
                errors.AppendLine("Укажите тип");
            }
            if (productfield.id_Товарной_накладной <= 0)
            {
                errors.AppendLine("Укажите № товарной накладной");
            }
            if (string.IsNullOrWhiteSpace(productfield.Наименование))
            {
                errors.AppendLine("Укажите наименование");
            }
            if (productfield.id_Ед_измерения <= 0)
            {
                errors.AppendLine("Укажите ед. измерения");
            }

            if (productfield.На_Складе <= 0)
            {
                errors.AppendLine("Укажите количество");
            }
            if (string.IsNullOrWhiteSpace(productfield.Минимальный_запас))
            {
                errors.AppendLine("Укажите минимальный запас");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            try
            {
                if (AccountHelpClass.Id == 1)
                {
                    Storage PrObj = new Storage()
                    {      
                        Артикул = TxbArt.Text,
                        Provider = CmbPost.SelectedItem as Provider,
                        StorageType =CmbType.SelectedItem as StorageType,
                        TowarNakl = CmbNakl.SelectedItem as TowarNakl,
                        Unit = CmbEdIzm.SelectedItem as Unit,
                        Наименование = TxbNaim.Text,
                        На_Складе = Convert.ToInt32(TxbColvo.Text),
                        Минимальный_запас = TxbMinZ.Text
                        
                    };
                    AppConnect.model0db.Storage.Add(PrObj);
                    
                }
                AppConnect.model0db.SaveChanges();
                AppFrame.frameMain.GoBack();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Ошибка:" + ex.Message.ToString(), "Критическая ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void CmbEdIzm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TxbNaim_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Sklad());

        }
    }
}
