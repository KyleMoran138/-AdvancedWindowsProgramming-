using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FinalProject {
    public class SchoolContext : DbContext {

        public SchoolContext() : base("name=SchoolContext") {}

        public DbSet<Person> USERS { get; set; }
        public DbSet<Course> COURSES { get; set; }
        public DbSet<Cirriclium> CIRRICLIUMS { get; set; }
        public DbSet<Degree> DEGREES { get; set; }
        

        public bool addUser(Person p) {
            var users = USERS.Where( x => x.id == p.id || x.username == p.username).ToList();
            if( users.Count != 0 ) return false;
            USERS.Add( p );
            var result = this.SaveChanges();
            return result == 1;
        }
        public Person getUserByUsername(String username) {
            var results = USERS.Where( x => x.username == username ).ToList();
            if( results.Count == 0 ) return null;
            return results.First();
        }
        public bool addCourse(Course c) {
            var courses = COURSES.Where( x => x.id == c.id ).ToList();
            if( courses.Count != 0 ) return false;
            COURSES.Add( c );
            var result = SaveChanges();
            return result == 1;
        }
        public List<Course> getCoursesByUserId(Guid id) {
            var results = COURSES.ToList();
            results.Where( x => x.Professors.Contains( id ) );
            if( results.Count == 0 ) return null;
            return results;
        }
    }
}
