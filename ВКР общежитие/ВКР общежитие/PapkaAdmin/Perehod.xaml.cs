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

namespace ВКР_общежитие.PapkaAdmin
{
    /// <summary>
    /// Логика взаимодействия для Perehod.xaml
    /// </summary>
    public partial class Perehod : Page
    {
        public Perehod()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AccountHelpClass.Id = 1;
            AppFrame.frameMain.Navigate(new Sklad());
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Supply1());
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Zakaz());
        }

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    AppFrame.frameMain.Navigate(new Post());
        //}

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Login());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AccountHelpClass.Id = 1;

            AppFrame.frameMain.Navigate(new Provider11());

        }
    }
}
