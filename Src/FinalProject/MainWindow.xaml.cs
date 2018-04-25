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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow:Window
    {

        public Person currentUser = null;
        public static MainWindow main;
        public SchoolContext _context;

        public MainWindow()
        {
            _context = new SchoolContext();
            Person.defaultTestData();
            Course.defaultTestData();
            main = this;
            InitializeComponent();
            disableAllButtons();
        }

        private void Label_MouseLeftButtonDown( object sender, MouseButtonEventArgs e )
        {
            this.Close();
        }

        private void Label_MouseLeftButtonDown_1( object sender, MouseButtonEventArgs e )
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Rectangle_MouseDown( object sender, MouseButtonEventArgs e )
        {
            this.DragMove();
        }

        private void Label_MouseLeftButtonDown_2( object sender, MouseButtonEventArgs e )
        {
            Label minWindowLabel = (Label)minWindow;
            Label maxWindowLabel = (Label)maxWindow;
            if( this.WindowState != WindowState.Maximized )
            {
                this.WindowState = WindowState.Maximized;
                maxWindow.Visibility = Visibility.Hidden;
                minWindow.Visibility = Visibility.Visible;
            } else
            {
                this.WindowState = WindowState.Normal;
                maxWindow.Visibility = Visibility.Visible;
                minWindow.Visibility = Visibility.Hidden;
            }

        }

        private void Button_MouseLeftButtonDown( object sender, RoutedEventArgs e )
        {
            mainFrame.Navigate( new AdminPage() );
        }

        public void enableButtonsForRole( Person r )
        {
            Button[] btnForAll = { HomeButton, };
            Button[] btnForStudent = { CoursesButton, AssignmentsButton, ProfessorsButton };
            Button[] btnForProfessor = { CoursesButton, AssignmentsButton };
            Button[] btnForAdmin = { AdminButton };
            disableAllButtons();
            if( r == null ) return;
            foreach( var button in btnForAll )
            {
                button.Visibility = Visibility.Visible;
            }
            switch( r.Role )
            {
                case Roles.ADMIN:
                    foreach( var button in btnForAdmin )
                    {
                        button.Visibility = Visibility.Visible;
                    }
                    break;
                case Roles.PROFESSOR:
                    foreach( var button in btnForProfessor )
                    {
                        button.Visibility = Visibility.Visible;
                    }
                    break;
                case Roles.STUDENT:
                    foreach( var button in btnForStudent )
                    {
                        button.Visibility = Visibility.Visible;
                    }
                    break;
                default:
                    break;
            }

        }

        public void disableAllButtons()
        {
            Button[] btnForAll = { HomeButton, CoursesButton, AssignmentsButton, ProfessorsButton, AdminButton };
            foreach( var button in btnForAll )
            {
                button.Visibility = Visibility.Collapsed;
            }
        }

        public void setCurrentUser( Person p )
        {
            currentUser = p;
            enableButtonsForRole( p );
            if(p != null ){
                goToHomePage( p );
            } else
            {
                setPage( new Login() );
            }
            
        }

        public void setPage( Page p )
        {
            mainFrame.Content = p;
        }

        private void HomeButton_Click( object sender, RoutedEventArgs e )
        {
            goToHomePage( currentUser );
        }

        public void goToHomePage( Person p )
        {
            if( p != null )
            {
                HomePage home = new HomePage();
                home.setHomeForRole( p.Role );
                setPage( home );
            }
        }
    }
}
