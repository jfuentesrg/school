using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{

    public class Enrolment
    {
        /*It should have properties for an ID, a Course, a Student, a Grade, and an EnrolmentDate.*/
        
        private int _EnrolmentId { get; set; }
        private string? _Course { get; set; }
        private string? _Student { get; set; }

        private int? _Grade { get; set; }

        private DateTime? _EnrollentDate;
        

        /*Replace the properties on Student and Course that track each other, 
          as well as the student's Enrolment Date and Grade properties, with references to Enrolment objects.*/

        /* A student still can have only one Enrolment object tracked at a time, whereas a Course still has a Hashset of them.*/


        /*When a student enrolls in a course, a new Enrollment object should be created that relates to the Student and Course(and is tracked by them).*/

        /*
        A new HashSet should be created in Program.cs that collects all Enrollments
        When a student deregisters from a course, the student and course should both remove their references to the Enrollment.
        The Enrollment should keep its data and remain stored in the Program.cs HashSet.
        */
        //public void AddStudentToCoursebyEnrolment() { 

        //}

        public Enrolment(int EnrolmentId, Course course,Student student)
        {
            _EnrolmentId=EnrolmentId;
            _Course=course.Title;
            _Student=student.FirstName+" "+student.LastName;
            _Grade=student.CourseGrade;
            _EnrollentDate =DateTime.Now;
           
                
                
        }

    }
}
