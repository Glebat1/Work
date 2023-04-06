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
    /// Логика взаимодействия для Zakaz.xaml
    /// </summary>
    public partial class Zakaz : Page
    {
        int rowcount;
        public Zakaz()
        {
            InitializeComponent();
            DG.ItemsSource = AppConnect.model0db.Supply.ToList(); //Формирование собственной товарной накладной
            rowcount = AppConnect.model0db.Supply.Count(x => x.ID == x.ID);

            CmbFiltr.SelectedValuePath = "ID";
            CmbFiltr.DisplayMemberPath = "Номер_общежития";

            CmbFiltr.ItemsSource = AppConnect.model0db.Client.ToList();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) 
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e) 
        {
            AccountHelpClass.Id = 1;
            AppFrame.frameMain.Navigate(new AddZakaz(null));
        }

        private void BtnRed_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new AddZakaz((sender as Button).DataContext as Order1));
        }

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    if (DG.SelectedItems.Count > 0)
        //    {
        //        for (int i = 0; i < List.Count; i++)
        //        {
        //            Storage studentObj = (ListView.SelectedItems[i] as Storage);
        //            AppConnect.model0db.Storage.Remove(studentObj);
        //        }
        //        AppConnect.model0db.SaveChanges();
        //        MessageBox.Show("Продукт успешно удален!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
        //    }
        //    else
        //    {
        //        MessageBox.Show("В таблице нет данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}
        //private void Button_Click2(object sender, RoutedEventArgs e)
        //{
        //    var cat1 = AppConnect.model0db.Product.Where(x => x.ProductCategory == "Амуниция и снаряжение").Count();
        //    cat1 = cat1 + 6;
        //    var cat2 = AppConnect.model0db.Product.Where(x => x.ProductCategory == "Катушки").Count();
        //    cat2 = cat2 + 1 + cat1;
        //    var cat3 = AppConnect.model0db.Product.Where(x => x.ProductCategory == "Леска").Count();
        //    cat3 = cat3 + 1 + cat2;
        //    var cat4 = AppConnect.model0db.Product.Where(x => x.ProductCategory == "Оснастка").Count();
        //    cat4 = cat4 + 1 + cat3;
        //    var cat5 = AppConnect.model0db.Product.Where(x => x.ProductCategory == "Приманки").Count();
        //    cat5 = cat5 + 1 + cat4;
        //    var Spisok = AppConnect.model0db.Product.OrderBy(x => x.ProductCategory).ToList();
        //    var application = new Microsoft.Office.Interop.Excel.Application();
        //    Microsoft.Office.Interop.Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
        //    Microsoft.Office.Interop.Excel.Worksheet worksheet = application.Worksheets.Item[1];
        //    int RowIndex = 5;
        //    Microsoft.Office.Interop.Excel.Range header = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[4, 5]];
        //    header.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        //    header.Font.Bold = true;
        //    header.ColumnWidth = 30;
        //    worksheet.Cells[2][1] = "ПРАЙС-лист";
        //    worksheet.Cells[3][1] = "ООО \"РЫБАЛКА\" ";
        //    worksheet.Cells[4][2] = DateTime.Now;

        //    worksheet.Cells[1][4] = "Артикул";
        //    worksheet.Cells[2][4] = "Наименование";
        //    worksheet.Cells[3][4] = "Категория";
        //    worksheet.Cells[4][4] = "Производитель";
        //    worksheet.Cells[5][4] = "Стоимость(руб.)";
        //    int a = RowIndex;
        //    RowIndex = RowIndex + 1;
        //    for (int i = 0; i < rowcount; i++)
        //    {
        //        if (RowIndex == cat1)
        //        {
        //            RowIndex = RowIndex + 1;
        //        }
        //        if (RowIndex == cat2)
        //        {
        //            RowIndex = RowIndex + 1;
        //        }
        //        if (RowIndex == cat3)
        //        {
        //            RowIndex = RowIndex + 1;
        //        }
        //        if (RowIndex == cat4)
        //        {
        //            RowIndex = RowIndex + 1;
        //        }
        //        Microsoft.Office.Interop.Excel.Range h1 = worksheet.Range[worksheet.Cells[a, 1], worksheet.Cells[a, 5]];
        //        h1.Merge();
        //        h1.Font.Italic = true;
        //        h1.BorderAround2();
        //        h1.Borders.Value = 0;
        //        h1.Font.Bold = true;


        //        Microsoft.Office.Interop.Excel.Range h2 = worksheet.Range[worksheet.Cells[cat1, 1], worksheet.Cells[cat1, 5]];
        //        h2.Merge();
        //        h2.Font.Italic = true;
        //        h2.BorderAround2();
        //        h2.Borders.Value = 0;
        //        h2.Font.Bold = true;


        //        Microsoft.Office.Interop.Excel.Range h3 = worksheet.Range[worksheet.Cells[cat2, 1], worksheet.Cells[cat2, 5]];
        //        h3.Merge();
        //        h3.Font.Italic = true;
        //        h3.Font.Bold = true;
        //        h3.BorderAround2();
        //        h3.Borders.Value = 0;


        //        Microsoft.Office.Interop.Excel.Range h4 = worksheet.Range[worksheet.Cells[cat3, 1], worksheet.Cells[cat3, 5]];
        //        h4.Merge();
        //        h4.Font.Italic = true;
        //        h4.Font.Bold = true;
        //        h4.BorderAround2();
        //        h4.Borders.Value = 0;

        //        Microsoft.Office.Interop.Excel.Range h5 = worksheet.Range[worksheet.Cells[cat4, 1], worksheet.Cells[cat4, 5]];
        //        h5.Merge();
        //        h5.Font.Italic = true;
        //        h5.Font.Bold = true;
        //        h5.BorderAround2();
        //        h5.Borders.Value = 0;

        //        worksheet.Cells[1][RowIndex] = Spisok[i].ProductArticleNumber;
        //        worksheet.Cells[2][RowIndex] = Spisok[i].ProductName;
        //        worksheet.Cells[3][RowIndex] = Spisok[i].ProductCategory;
        //        worksheet.Cells[4][RowIndex] = Spisok[i].ProductManufacturer;
        //        worksheet.Cells[5][RowIndex] = Spisok[i].ProductCost;
        //        RowIndex++;
        //    }
        //    Microsoft.Office.Interop.Excel.Range all = worksheet.Range[worksheet.Cells[a, 1], worksheet.Cells[RowIndex, 5]];
        //    all.BorderAround2();
        //    all.Cells.Borders.Value = 1;
        //    application.Visible = true;
        //}

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Sklad());

        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {

        }

        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var ForDel = DG.SelectedItems.Cast<Order1>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие элементы ({ForDel.Count()})", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AppConnect.model0db.Order1.RemoveRange(ForDel);
                    AppConnect.model0db.SaveChanges();

                    MessageBox.Show("Данные удалены!");
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message.ToString());
                }
                DG.ItemsSource = AppConnect.model0db.Order1.ToList();// yvolnenie sdelat ! ! !
            }
        }

        private void Poisk_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            
                var Serachlist = AppConnect.model0db.Order1.ToList();
                if (Poisk.Text != "")
                {
                    Serachlist = Serachlist.Where(x => x.id_Заказчик.ToString().ToLower().Contains(Poisk.Text.ToLower())).ToList();

                    DG.ItemsSource = Serachlist.ToList();

                }
                DG.ItemsSource = Serachlist.ToList();
            
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                AppConnect.model0db.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DG.ItemsSource = AppConnect.model0db.Order1.ToList();
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

            AppFrame.frameMain.Navigate(new Supply1());

        }

        private void Button_Click_Zakaz(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Login());

        }

        private void CmbFiltr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int k = Convert.ToInt32(CmbFiltr.SelectedValue);
            DG.ItemsSource = AppConnect.model0db.Order1.Where(x => x.id_Заказчик == k).ToList();
        }

        //private void CmbFiltr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var n = AppConnect.model0db.Storage.ToList().Distinct();
        //    switch (CmbFiltr.SelectedIndex)
        //    {
        //        case 0:
        //            n = n.Where(x => x.Id_Месяц == 1).ToList();
        //            break;
        //        case 1:
        //            n = n.Where(x => x.Id_Месяц == 2).ToList();
        //            break;
        //        case 2:
        //            n = n.Where(x => x.Id_Месяц == 3).ToList();
        //            break;
        //        case 3:
        //            n = n.Where(x => x.Id_Месяц == 4).ToList();
        //            break;
        //        case 4:
        //            n = n.Where(x => x.Id_Месяц == 5).ToList();
        //            break;
        //        case 5:
        //            n = n.Where(x => x.Id_Месяц == 6).ToList();
        //            break;
        //        case 6:
        //            n = n.Where(x => x.Id_Месяц == 7).ToList();
        //            break;
        //        case 7:
        //            n = n.Where(x => x.Id_Месяц == 8).ToList();
        //            break;
        //        case 8:
        //            n = n.Where(x => x.Id_Месяц == 9).ToList();
        //            break;
        //        case 9:
        //            n = n.Where(x => x.Id_Месяц == 10).ToList();
        //            break;
        //        case 10:
        //            n = n.Where(x => x.Id_Месяц == 11).ToList();
        //            break;
        //        case 11:
        //            n = n.Where(x => x.Id_Месяц == 12).ToList();
        //            break;
        //        default:
        //            break;
        //    }
        //    AAA.ItemsSource = n.ToList();
        //}
    }
}

