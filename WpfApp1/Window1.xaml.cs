using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        DataBase dataBase = new DataBase();
        public Window1()
        {
            InitializeComponent();
        }
        private void Button_Window_reg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow regwin = new MainWindow();
            regwin.Show();
            Close();
        }
        private void Button_Vhod_Click(object sender, RoutedEventArgs e)
        {
            var polic = TextBoxPolic2.Text;
            var pass = PassBox2;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string qwerystring = $"select ID, Full_name, Password, Num_police from Pacient where Password = '{pass}' and Num_police = '{polic}'";

            SqlCommand command = new SqlCommand(qwerystring, dataBase.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count == 1)
            {
                System.Windows.MessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);

                mainmenu menu = new mainmenu();
                menu.Show();
                Close();
            }
            else
            {
                System.Windows.MessageBox.Show("Такого аккаунта не существет!", "Аккаунта не существует!", MessageBoxButton.OK, MessageBoxImage.Warning);

                    mainmenu menu = new mainmenu();
                    menu.Show();
                    Close();
            }
        }
    }
}
