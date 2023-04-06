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
using ВКР_общежитие.Add;
using Excel = Microsoft.Office.Interop.Excel;


namespace ВКР_общежитие.PapkaAdmin
{
    /// <summary>
    /// Логика взаимодействия для Supply1.xaml
    /// </summary>
    public partial class Supply1 : Page
    {
        int rowcount;
        public Supply1()
        {
            InitializeComponent();
            DG.ItemsSource = AppConnect.model0db.Supply.ToList(); //Товарная и возвратная в одну таблицу,фильтрация, нарушения
            rowcount = AppConnect.model0db.Supply.Count(x => x.ID == x.ID);

            CmbFiltr.SelectedValuePath = "ID";
            CmbFiltr.DisplayMemberPath = "Номер_документа";

            CmbFiltr.ItemsSource = AppConnect.model0db.TowarNakl.ToList();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AccountHelpClass.Id = 1;
            AppFrame.frameMain.Navigate(new AddSupply(null));
        }

        private void BtnRed_Click(object sender, RoutedEventArgs e)
        {
            //AppFrame.frameMain.Navigate(new AddSupply((sender as Button).DataContext as Supply));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var ForDel = DG.SelectedItems.Cast<Supply>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие элементы ({ForDel.Count()})", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AppConnect.model0db.Supply.RemoveRange(ForDel);
                    AppConnect.model0db.SaveChanges();

                    MessageBox.Show("Данные удалены!");
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message.ToString());
                }
                DG.ItemsSource = AppConnect.model0db.Supply.ToList();
            }
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            var Spisok = AppConnect.model0db.Supply.ToList();
            var application = new Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = application.Worksheets.Item[1];
            int RowIndex = 3;
            Excel.Range header = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 3]];
            header.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            header.ColumnWidth = 20;
            header.Font.Bold = true;
            worksheet.Cells[1][1] = "Товарная накладная";
            worksheet.Cells[2][1] = "Дата";
            worksheet.Cells[3][1] = "Поставщик";
           

            for (int i = 0; i < Spisok.Count; i++)
            {
                worksheet.Cells[1][RowIndex] = Spisok[i].TowarNakl.Номер_документа;
                worksheet.Cells[2][RowIndex] = Spisok[i].Дата;
                worksheet.Cells[3][RowIndex] = Spisok[i].Поставщик;
               


                RowIndex++;
            }

            application.Visible = true;
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Sklad());

        }

        

        private void Poisk_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            var Serachlist = AppConnect.model0db.Supply.ToList();
            if (Poisk.Text != "")
            {
                Serachlist = Serachlist.Where(x => x.Дата.ToString().ToLower().Contains(Poisk.Text.ToLower())).ToList();

                DG.ItemsSource = Serachlist.ToList();

            }
            DG.ItemsSource = Serachlist.ToList();
        }

        

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                AppConnect.model0db.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DG.ItemsSource = AppConnect.model0db.Supply.ToList();
            }
        }

        private void Button_Click_Sklad(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Sklad());
        }
        private void Button_Click_Post(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Provider11());

        }

        private void Button_Click_Supply(object sender, RoutedEventArgs e)
        {
            

        }

        private void Button_Click_Zakaz(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Zakaz());

        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Login());

        }

        private void CmbFiltr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int k = Convert.ToInt32(CmbFiltr.SelectedValue);
            DG.ItemsSource = AppConnect.model0db.Supply.Where(x => x.ID_Товарной_накладной == k).ToList();
        }
    }
}
