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

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
            badinputLabel.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            if (passwordTextInput.Password == String.Empty || usernameTextInput.Text == String.Empty){
                badinputLabel.Visibility = Visibility.Visible;
            }
            else {
                Person p = Person.attemptLogin(usernameTextInput.Text, passwordTextInput.Password);
                if (p != null) {
                    MainWindow.main.setCurrentUser(p);
                    Console.WriteLine("LOGIN GOOD");
                }
                else {
                    badinputLabel.Visibility = Visibility.Visible;
                    Console.WriteLine("LOGIN BAD");
                }
            }
        }
    }
}
