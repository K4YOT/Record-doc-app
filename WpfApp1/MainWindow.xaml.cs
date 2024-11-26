using System.Data;
using System.Data.SqlClient;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static MaterialDesignThemes.Wpf.Theme;
using System.Windows.Forms;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        DataBase dataBase = new DataBase();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            var login = TextBoxLogin.Text.Trim();
            var pass = PassBox.Password.Trim();
            var pass_2 = PassBox_2.Password.Trim();
            var polic = TextBoxPolic.Text.Trim();
            int i;

            if (login.Length < 8)
            {
                TextBoxLogin.ToolTip = "Некорректный ввод!";
                TextBoxLogin.Background = Brushes.DarkRed;
            }
            else if (pass.Length < 5) 
            {
                PassBox.ToolTip = "Введите пароль от 5 символов";
                PassBox.Background = Brushes.DarkRed;
            }
            else if (pass != pass_2) 
            {
                PassBox_2.ToolTip = "Пароли не совпадают!";
                PassBox_2.Background = Brushes.DarkRed;
            }
            else if (polic.Length != 10 || !int.TryParse(TextBoxPolic.Text, out i))
            {
                TextBoxPolic.ToolTip = "Полис должен содержать 10 чисел и не иметь символов";
                TextBoxPolic.Background = Brushes.DarkRed;
            }
            else
            {
                TextBoxLogin.ToolTip = "";
                TextBoxLogin.Background = Brushes.Transparent;
                PassBox.ToolTip = "";
                PassBox.Background = Brushes.Transparent;
                PassBox_2.ToolTip = "";
                PassBox_2.Background = Brushes.Transparent;
                TextBoxPolic.ToolTip = "";
                TextBoxPolic.Background = Brushes.Transparent;

                
            }


            string qwerystring = $"insert into Pacient(Full_name, Num_police, Login, Password) values('{login}', '{polic}', '{login}', '{pass}')";

            SqlCommand command = new SqlCommand(qwerystring, dataBase.GetConnection());

            dataBase.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                System.Windows.MessageBox.Show("Аккаунт успешно создан!", "Успех!");
            }
            else
            {
                System.Windows.MessageBox.Show("Аккаунт не удалось зарегестрировать!", "Ошибка!");
            }
            dataBase.closeConnection();
        }

    private Boolean checkuser()
        {
            var polic = TextBoxPolic;
            var pass = PassBox;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string qwerysting = $"select ID, Full_name, Num_police, Login, Password where Num_police = '{polic}', Password = '{pass}'";

            SqlCommand command = new SqlCommand(qwerysting, dataBase.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count > 0)
            {
                System.Windows.MessageBox.Show("Пользователь уже существует!");
                return true;
            }
            else
            {
                return false;
            }
        }
        private void Button_Window_Auth_Click(object sender, RoutedEventArgs e)
        {
            Window1 authwin = new Window1();
            authwin.Show();
            Close();
        }
    }
}