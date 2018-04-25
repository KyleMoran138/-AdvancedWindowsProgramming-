using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FinalProject
{
    public enum types {
        GEN,
        ART,
        SCI,
        SOC,
        MATH
    }

    public class Course{
        [Key]
        public Guid id { get; set; }
        public virtual List<Guid> Professors { get; set; }
        public virtual List<Guid> EnrolledStudents { get; set; }
        public String Name { get; set; }
        public String Code { get; set; }
        //Going to have a list of assignments later
        //public Dictionary<>
        public virtual IDictionary<Int32, List<DateTime>> Schedule { get; set; }
        public types Type { get; set; }

        public Course() {
            this.Professors = new List<Guid>();
            this.EnrolledStudents = new List<Guid>();
            this.Name = "";
            this.Code = "";
            this.id = Guid.NewGuid();
        }
        public static void defaultTestData() {
            using(var db = new SchoolContext() )
            {
                Course c = new Course() {
                    id = new Guid( "FFD251A8-1C51-49DD-96AD-B77DDA0DF074" ),
                    Name = "Finite mathmatics",
                    Type = types.MATH
                };
                Person p = db.getUserByUsername( "Professor" );
                if( p == null ) return;
                Professor prof = p.toProfessor();
                if( prof == null ) return;
                Console.WriteLine( $"{prof.username}" );
                c.Professors.Add( prof.id );
                db.addCourse( c );
                db.SaveChangesAsync();
            }
        }
    }

    public class Cirriclium {
        [Key]
        public Guid id { get; set; }
        public String Name { get; set; }
        public virtual IDictionary<types, List<Guid>> ReqClas { get; set; }
        public virtual IDictionary<types, List<Guid>> OptClas { get; set; }
        public virtual IDictionary<types, Int32> NumReqOptClass { get; set; }

        public Cirriclium() {
            this.Name = "";
            this.ReqClas = new Dictionary<types, List<Guid>>();
            this.OptClas = new Dictionary<types, List<Guid>>();
            this.NumReqOptClass = new Dictionary<types, int>();
        }

    }

    public class Degree {
        [Key]
        public Guid id { get; set; }
        public String Name { get; set; }
        public Cirriclium cirq { get; set; }
        public Int32 MinYears { get; set; }

        public Degree(String Name, Cirriclium cirq, Int32 years) {
            this.Name = Name;
            this.cirq = cirq;
            MinYears = years;
        }
    }
}
