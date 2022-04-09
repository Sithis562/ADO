using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
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

namespace _1
{
    /// <summary>
    /// Логика взаимодействия для DataGrid.xaml
    /// </summary>
    public partial class DataGrid : Window
    {
        ConnectionSQL SQL = new ConnectionSQL();
        ClientsTable table1 = new ClientsTable();
        ItemsTable table2 = new ItemsTable();
        
        DataTable dt1;
        DataTable dt2;
        DataRowView row;


        public DataGrid()
        {
            InitializeComponent();

            SqlConnection conSQL = new SqlConnection(SQL.SQLConnect());
            dt1 = new DataTable();
            dt2 = new DataTable();

            #region select
            
            table1.SELECT();

            table2.SELECT();

            #endregion

            #region insert

            table1.INSERT();

            table2.INSERT();

            #endregion

            #region update

            table1.UPDATE();

            table2.UPDATE();

            #endregion

            #region delete

            table1.DELETE();

            table2.DELETE();

            #endregion


            dt1 = table1.Fill();
            dt2 = table2.Fill();

            gridView1.DataContext = dt1.DefaultView;
            gridView2.DataContext = dt2.DefaultView;
        }

        /// <summary>
        /// Начало редактирования таблицы клиентов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GVCellEditEnding1(object sender, DataGridCellEditEndingEventArgs e)
        {

            row = (DataRowView)gridView1.SelectedItem;
            row.BeginEdit();
            
        }

        /// <summary>
        /// Начало редактирования таблицы товаров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GVCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

            row = (DataRowView)gridView2.SelectedItem;
            row.BeginEdit();
            
        }

        /// <summary>
        /// Редактирование таблицы клиентов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GVCurrentCellChanged1(object sender, EventArgs e)
        {
            if (row == null) return;
            row.EndEdit();
            dt1 = table1.Update();
        }

        /// <summary>
        /// Редактирование таблицы товаров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GVCurrentCellChanged(object sender, EventArgs e)
        {
            if (row == null) return;
            row.EndEdit();
            dt2 = table2.Update();
        }

        /// <summary>
        /// Удаление из списка клиентов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemDeleteClick(object sender, RoutedEventArgs e)
        {
            row = (DataRowView)gridView1.SelectedItem;
            row.Row.Delete();
            dt1 = table1.Update();
        }

        /// <summary>
        /// Удаление из списка товаров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemDeleteClick2(object sender, RoutedEventArgs e)
        {
            row = (DataRowView)gridView2.SelectedItem;
            row.Row.Delete();
            dt2 = table2.Update();
        }

        /// <summary>
        /// Добавление клиента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemAddClick(object sender, RoutedEventArgs e)
        {
            DataRow r = dt1.NewRow();
            AddWindow1 add = new AddWindow1(r);
            add.ShowDialog();


            if (add.DialogResult.Value)
            {
                dt1.Rows.Add(r);
                dt1 = table1.Update();
            }
        }

        /// <summary>
        /// Добавление товара
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemAddClick2(object sender, RoutedEventArgs e)
        {
            DataRow r = dt2.NewRow();
            AddWnidow2 add = new AddWnidow2(r);
            add.ShowDialog();


            if (add.DialogResult.Value)
            {
                dt2.Rows.Add(r);
                dt2 = table2.Update();
            }
        }

    }
}
