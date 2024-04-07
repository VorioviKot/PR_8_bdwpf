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
using MySql.Data.MySqlClient;
using Mysqlx.Cursor;
using System.Data;
namespace PR_8_bd
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        public MySqlConnection MSC;
        public MySqlCommand MSCom;
        public string SqlConector = "Server=localhost;Database=test;Uid=root;pwd='';charset=utf8;";
    
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                MSC = new MySqlConnection(SqlConector);
                MSC.Open();
                MessageBox.Show("u connect to database");
                MSC.Close();
            }
            catch
            {
                MessageBox.Show("connection lost");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string Script = "SELECT * FROM `testtable1`";
            MSC = new MySqlConnection(SqlConector);
            MSC.Open();
            System.Data.DataTable dt = new System.Data.DataTable();
            MySqlDataAdapter ms_data = new MySqlDataAdapter(Script, SqlConector);
            ms_data.Fill(dt);
            dataGrid1.DataContext = ms_data;
            MSC.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void dataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            string Script = "SELECT * FROM `testtable1`";
            MSC = new MySqlConnection(SqlConector);
            MSC.Open();
            System.Data.DataTable dt = new System.Data.DataTable();
            MySqlDataAdapter ms_data = new MySqlDataAdapter(Script, SqlConector);
            ms_data.Fill(dt);
            dataGrid1.ItemsSource = dt.DefaultView;
            MSC.Close();



            
        }
    }
}
