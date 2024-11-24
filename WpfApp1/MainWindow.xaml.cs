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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    DataBase dataBase = new DataBase();

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = TextBoxLogin.Text.Trim();
            string pass = PassBox.Password.Trim();
            string pass_2 = PassBox_2.Password.Trim();
            string polic = TextBoxPolic.Text.Trim();
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

                MessageBox.Show("Всё хорошо!");
            }
        }
    }
}