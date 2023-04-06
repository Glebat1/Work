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
    /// Логика взаимодействия для Sklad.xaml
    /// </summary>
    public partial class Sklad : Page
    {
        int rowcount;
        public Sklad()
        {
            InitializeComponent();
            DG.ItemsSource = AppConnect.model0db.Storage.ToList();
            rowcount = AppConnect.model0db.Storage.Count(x => x.ID == x.ID);

            CmbFiltr.SelectedValuePath = "ID";
            CmbFiltr.DisplayMemberPath = "Название";
            
            CmbFiltr.ItemsSource =AppConnect.model0db.StorageType.ToList();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AccountHelpClass.Id = 1;
            AppFrame.frameMain.Navigate(new AddSklad(null));
        }

        private void BtnRed_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new AddSklad((sender as Button).DataContext as Storage));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //if (DG.SelectedItems.Count > 0)
            //{
            //    for (int i = 0; i < DG.SelectedItems.Count; i++)
            //    {
            //        Storage studentObj = (DG.SelectedItems[i] as Storage);
            //        AppConnect.model0db.Storage.Remove(studentObj);
            //    }
            //    AppConnect.model0db.SaveChanges();
            //    MessageBox.Show("Продукт успешно удален!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
            //else
            //{
            //    MessageBox.Show("В таблице нет данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
            //AppConnect.model0db.Storage.ToList();
            var ForDel = DG.SelectedItems.Cast<Storage>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие элементы ({ForDel.Count()})", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AppConnect.model0db.Storage.RemoveRange(ForDel);
                    AppConnect.model0db.SaveChanges();
                    
                    MessageBox.Show("Данные удалены!");
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message.ToString());
                }
                DG.ItemsSource = AppConnect.model0db.Storage.ToList();// yvolnenie sdelat ! ! !
            }

        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            int k = Convert.ToInt32(CmbFiltr.SelectedValue);
            var Spisok = AppConnect.model0db.Storage.ToList();
            if (k > 0)
            {
                Spisok = AppConnect.model0db.Storage.Where(x => x.id_Типа == k).ToList();
            }
            else
            {
                Spisok = AppConnect.model0db.Storage.ToList();
            }
            //var Spisok2 = PraktikaEntities2.GetContext().Анализ_ВТД.Select(x => x.ОстатокПоВТД).ToList();
            var application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = application.Worksheets.Item[1];
            int RowIndex = 3;
            worksheet.Cells[1][1] = "Минусинский колледж культуры и искусства";
            worksheet.Cells[1][2] = "г. Минусинск, ул. Красных Партизан, д. 3, 662603";

            worksheet.Cells[1][3] = "Поставщик";
            worksheet.Cells[3][3] = "Тип";
            worksheet.Cells[4][3] = "Товар. Накладная";
            worksheet.Cells[5][3] = "Наименование";
            worksheet.Cells[6][3] = "Ед.Измерения";
            worksheet.Cells[7][3] = "На складе";
            worksheet.Cells[8][3] = "Минимальный запас";
            Excel.Range header = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 9]];
            header.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            header.Font.Bold = true;
            header.Interior.ColorIndex = 0;
            for (int i = 0; i < Spisok.Count(); i++)
            {
                RowIndex++;
                Excel.Range categ2 = worksheet.Range[worksheet.Cells[RowIndex, 1], worksheet.Cells[RowIndex, 9]];


                worksheet.Cells[1][RowIndex] = Spisok[i].Артикул;
                worksheet.Cells[2][RowIndex] = Spisok[i].Provider.Название_Организации;
                worksheet.Cells[3][RowIndex] = Spisok[i].StorageType.Название;
                worksheet.Cells[4][RowIndex] = Spisok[i].TowarNakl.Номер_документа;
                worksheet.Cells[5][RowIndex] = Spisok[i].Наименование;
                worksheet.Cells[6][RowIndex] = Spisok[i].Unit.Название;
                worksheet.Cells[7][RowIndex] = Spisok[i].На_Складе;
                worksheet.Cells[8][RowIndex] = Spisok[i].Минимальный_запас;
                categ2.BorderAround2();
                categ2.Borders.Value = 1;


            }
            RowIndex += 2;
            worksheet.Cells[5][RowIndex] = "_________/Лютинго Е.Ю.";
            application.Visible = true;
            //var Spisok = AppConnect.model0db.Storage.ToList();
            //var application = new Excel.Application();
            //Microsoft.Office.Interop.Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
            //Excel.Worksheet worksheet = application.Worksheets.Item[1];
            //int RowIndex = 3;
            //Excel.Range header = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 8]];
            //header.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            //header.ColumnWidth = 20;
            //header.Font.Bold = true;
            //worksheet.Cells[1][1] = "Артикул";
            //worksheet.Cells[2][1] = "Поставщик";
            //worksheet.Cells[3][1] = "Тип";
            //worksheet.Cells[4][1] = "Товар. Накладная";
            //worksheet.Cells[5][1] = "Наименование";
            //worksheet.Cells[6][1] = "Ед.Измерения";
            //worksheet.Cells[7][1] = "На складе";
            //worksheet.Cells[8][1] = "Минимальный запас";
            //for (int i = 0; i < Spisok.Count; i++)
            //{
            //    worksheet.Cells[1][RowIndex] = Spisok[i].Артикул;
            //    worksheet.Cells[2][RowIndex] = Spisok[i].Provider.Название_Организации;
            //    worksheet.Cells[3][RowIndex] = Spisok[i].StorageType.Название;
            //    worksheet.Cells[4][RowIndex] = Spisok[i].TowarNakl.Номер_документа;
            //    worksheet.Cells[5][RowIndex] = Spisok[i].Наименование;
            //    worksheet.Cells[6][RowIndex] = Spisok[i].Unit.Название;
            //    worksheet.Cells[7][RowIndex] = Spisok[i].На_Складе;
            //    worksheet.Cells[8][RowIndex] = Spisok[i].Минимальный_запас;

            //    RowIndex++;
            //}

            //application.Visible = true;
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Perehod());

        }

        

        private void Poisk_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            var Serachlist = AppConnect.model0db.Storage.ToList();
            if (Poisk.Text != "")
            {
                Serachlist = Serachlist.Where(x => x.Наименование.ToString().ToLower().Contains(Poisk.Text.ToLower())).ToList();

                DG.ItemsSource = Serachlist.ToList();

            }
            DG.ItemsSource = Serachlist.ToList();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            DG.ItemsSource = AppConnect.model0db.Storage.ToList();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                AppConnect.model0db.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DG.ItemsSource = AppConnect.model0db.Storage.ToList();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

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
            AppFrame.frameMain.Navigate(new Zakaz());

        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Login());

        }

        private void CmbFiltr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int k = Convert.ToInt32(CmbFiltr.SelectedValue);
            DG.ItemsSource = AppConnect.model0db.Storage.Where(x => x.id_Типа == k).ToList();
            //var n = AppConnect.model0db.Storage.ToList().Distinct();
            //switch (CmbFiltr.SelectedIndex)
            //{
            //    case 0:
            //        n = n.Where(x => x.id_Типа == 1).ToList();
            //        break;
            //    case 1:
            //        n = n.Where(x => x.id_Типа == 2).ToList();
            //        break;
            //    case 2:
            //        n = n.Where(x => x.id_Типа == 3).ToList();
            //        break;
            //    case 3:
            //    n = n.Where(x => x.Id_Месяц == 4).ToList();
            //    break;
            //case 4:
            //    n = n.Where(x => x.Id_Месяц == 5).ToList();
            //    break;
            //case 5:
            //    n = n.Where(x => x.Id_Месяц == 6).ToList();
            //    break;
            //case 6:
            //    n = n.Where(x => x.Id_Месяц == 7).ToList();
            //    break;
            //case 7:
            //    n = n.Where(x => x.Id_Месяц == 8).ToList();
            //    break;
            //case 8:
            //    n = n.Where(x => x.Id_Месяц == 9).ToList();
            //    break;
            //case 9:
            //    n = n.Where(x => x.Id_Месяц == 10).ToList();
            //    break;
            //case 10:
            //    n = n.Where(x => x.Id_Месяц == 11).ToList();
            //    break;
            //case 11:
            //    n = n.Where(x => x.Id_Месяц == 12).ToList();
            //    break;
            //default:
            //        break;
            //}
            //DG.ItemsSource = n.ToList();
        }

        private void Button_Click_Sklad(object sender, RoutedEventArgs e)
        {

        }
    }
}
