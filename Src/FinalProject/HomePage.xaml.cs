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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            Person currentPerson = MainWindow.main.currentUser;
            InitializeComponent();
            if(currentPerson != null )
            {
                switch( currentPerson.Role )
                {
                    case Roles.ADMIN:
                        setUpAdminHome(currentPerson);
                        break;
                    case Roles.PROFESSOR:
                        setUpProfessorHome(currentPerson);
                        break;
                    case Roles.STUDENT:
                        setUpStudentHome(currentPerson);
                        break;
                    default:
                        break;
                }
            }
        }

        public void setHomeForRole(Roles r){
            StudentHome.Visibility = Visibility.Hidden;
            ProfessorHome.Visibility = Visibility.Hidden;
            AdminHome.Visibility = Visibility.Hidden;
            switch (r){
                case Roles.STUDENT:
                    StudentHome.Visibility = Visibility.Visible;
                    break;
                case Roles.PROFESSOR:
                    ProfessorHome.Visibility = Visibility.Visible;
                    break;
                case Roles.ADMIN:
                    AdminHome.Visibility = Visibility.Visible;
                    break;
            }
        }
        private void usersRectangle_Click( object sender, RoutedEventArgs e ) {
            MainWindow.main.setPage( null );
        }
        private void coursesButton_Click( object sender, RoutedEventArgs e ) {
            MainWindow.main.setPage(null);
        }
        private void enrollmentButton_Click( object sender, RoutedEventArgs e ) {
            MainWindow.main.setPage( null );
        }
        private void degreesButton_Click( object sender, RoutedEventArgs e ) {
            MainWindow.main.setPage( null );
        }
        private void logoutButton_Click( object sender, RoutedEventArgs e ) {
            Person.doLogout();
        }


        private void setUpStudentHome(Person p) {

        }

        private void setUpAdminHome( Person p ) {

        }

        private void setUpProfessorHome( Person p ) {
            professorActiveClasses.Items.Clear();
            professorActiveClasses.ItemsSource = p.getCourses();
        }

    }
}
