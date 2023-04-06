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
    /// Логика взаимодействия для AddProvider.xaml
    /// </summary>
    public partial class AddProvider : Page
    {
        public Provider po = new Provider();
        private Provider productfield = new Provider();
        int ip = 0;
        public AddProvider(Provider selectedProvider)
        {
            InitializeComponent();
            

            if (selectedProvider != null)
            {
                productfield = selectedProvider;
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
            if (string.IsNullOrWhiteSpace(productfield.Название_Организации))
            {
                errors.AppendLine("Укажите название организации!");
            }
            
            if (string.IsNullOrWhiteSpace(productfield.Адрес))
            {
                errors.AppendLine("Укажите Адрес");
            }
            if (string.IsNullOrWhiteSpace(productfield.Индекс))
            {
                errors.AppendLine("Укажите индекс");
            }
            if (string.IsNullOrWhiteSpace(productfield.Телефон))
            {
                errors.AppendLine("Укажите контактный номер!");
            }
            if (string.IsNullOrWhiteSpace(productfield.Эл_Почта))
            {
                errors.AppendLine("Укажите контактный номер!");
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
                    Provider PrObj = new Provider()
                    {
                        Название_Организации = TxbNazv.Text,
                        Адрес= TxbAdres.Text,
                        Индекс = TxbInd.Text,
                        Телефон = TxbTel.Text,
                        Эл_Почта = TxbMail.Text

                    };
                    AppConnect.model0db.Provider.Add(PrObj);

                }
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
            AppFrame.frameMain.Navigate(new Provider11());

        }
    }
}
