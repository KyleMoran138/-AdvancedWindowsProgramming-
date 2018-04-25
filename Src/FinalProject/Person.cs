using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace FinalProject
{
    public enum Roles {
        STUDENT,
        PROFESSOR,
        ADMIN
    }

    public class Person
    {
        public String firstName { get; set; }
        public String lastName { get; set; }
        [Key]
        public Guid id { get; set; }
        public String username { get; set; }
        public String pass { get; set; }
        public String Title { get; set; }
        public Roles Role { get; set; }
        

        public Person() {
            this.id = Guid.NewGuid();
            this.Role = Roles.STUDENT;
        }

        public Person(String fname, String lname, String uname, String password, Roles r) {

            this.id = Guid.NewGuid();
            this.firstName = fname;
            this.lastName = lname;
            this.username = uname;
            this.pass = password;
            this.Role = r;
        }

        public static Person attemptLogin(String uname, String pword) {
            using(var db = new SchoolContext()) {
                var query = from b in db.USERS
                            where b.username == uname
                            select b;
                foreach(var users in query) {
                    if(users.pass == pword) {
                        users.pass = string.Empty;
                        return users;
                    }
                }
                return null;
            }
        }
        public static void doLogout() {
            MainWindow.main.setCurrentUser( null );
        }
        public static void defaultTestData() {
            using( var db = new SchoolContext() )
            {
                Person defaultAdmin = new Person( "default", "admin", "Admin", "password121", Roles.ADMIN ) {
                    id = new Guid( "3193EBE0-709F-4086-AAE5-EE45F23A4668" )
                };
                Person defaultProfessor = new Person( "default", "professor", "Professor", "password121", Roles.PROFESSOR ) {
                    id = new Guid("A0A0D401-1085-4FE3-989C-6E300C5A61DE")
                };
                Person defaultStudent = new Person( "default", "student", "Student", "password121", Roles.STUDENT ) {
                    id = new Guid("55DD5006-6005-4099-AC1C-56AB6099C667") 
                };

                db.addUser( defaultAdmin );
                db.addUser( defaultProfessor );
                db.addUser( defaultStudent );

            }
        }
        public Student toStudent() {
            if( this.Role != Roles.STUDENT ) return null;
            Student returnValue = new Student() {
                id = this.id,
                firstName = this.firstName,
                lastName = this.lastName,
                Role = this.Role,
                Title = this.Title,
                username = this.username
            };
            return returnValue;
        }
        public Professor toProfessor() {
            if( this.Role != Roles.PROFESSOR ) return null;
            Professor returnValue = new Professor() {
                id = this.id,
                firstName = this.firstName,
                lastName = this.lastName,
                Role = this.Role,
                Title = this.Title,
                username = this.username
            };
            return returnValue;
        }
        public List<Course> getCourses() {
            return MainWindow.main._context.getCoursesByUserId( this.id );
        }
    }

    public class Professor : Person{
        public Professor() {
            this.Role = Roles.PROFESSOR;
        }
        public Professor(String title) {
            this.Role = Roles.PROFESSOR;
            this.Title = title;
        }
        public Professor(String fname, String lname, String uname, String password)
            :base(fname, lname, uname, password, Roles.PROFESSOR) {
        }
    }

    public class Student : Person {
        public Student() {
            this.Role = Roles.STUDENT;
        }
        public Student(String fname, String lname, String uname, String password)
            : base(fname, lname, uname, password, Roles.STUDENT) {
        }
    }

}
