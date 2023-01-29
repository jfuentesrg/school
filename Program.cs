// Create a system in which Students can register for Courses
// A student may only take one Course, where a Course can have many students

// Student Class
// Course Class

// one-to-many relationship
using School;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

HashSet<Enrolment> _enrolments = new HashSet<Enrolment>();

Course Software = new Course(200, "Software Developer", 5);
Course Calculus = new Course(2000, "Calculus", 3);

Student Jimmy = new Student(1000, "Jimmy", "Smith");
Student Carlos = new Student(2000, "Carlos", "ap1");
Student Pablo = new Student(3000, "Pablo", "ap2");
Student Pepe = new Student(4000, "Pepe", "ap3");



// a course can have many students in it
// and a student can take one course
// one-to-many relationship (one course, many students)

// "one" component needs a collection of the many (course needs a collection of students)
// "many" component needs a property for the "one" (student needs a property of Course)

// something outside of the objects creating the relationship between them

try
{

    RegisterStudent(Jimmy, Software);
    RegisterStudent(Carlos,Software);
    RegisterStudent(Pablo, Software);
    RegisterStudent(Pepe, Software);

    AddGrade(Jimmy, 60);
    AddGrade(Carlos, 70);
    AddGrade(Pablo, 80);
    AddGrade(Pepe, 60);

    RegisterEnrollment(1, Jimmy, Software);
    RegisterEnrollment(2, Carlos, Software);
    RegisterEnrollment(3, Pablo, Software);
    RegisterEnrollment(4, Pepe, Software);

    Console.WriteLine(Jimmy.DateRegistered);
    Console.WriteLine(Carlos.DateRegistered);


    //
    Console.WriteLine(String.Join(",", _enrolments));
    //
    

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message.ToString());
}


void RegisterStudent(Student student, Course course)
{
    // look to see if a student is already registered in a course
    // search for the student in the course's student list
    if (course.GetStudentInCourse(student.StudentId) == null)
    {
        // if not, add that student to the course's student list
        course.AddStudentToCourse(student);

        // set the course as the student's currently registered course
        student.Course = course;
        student.DateRegistered = DateTime.Now;

    }
    else
    {
        throw new Exception($"Student with id {student.StudentId} already registered in Course {course.Title}");
    }
}
void DeregisterStudent(Student student, Course course)
{
    // ensure the student is registered in the course
    if (student.Course.CourseId == course.CourseId
        && course.GetStudentInCourse(student.StudentId) == student)
    {

        // remove student from course
        course.RemoveStudentFromCourse(student);
        // remove course from student
        student.Course = null;
        student.RemoveGrade();
        student.DateRegistered = null;

    }
    else
    {
        throw new Exception($"Student with ID {student.StudentId} not registered in Course {course.Title}");
    }

}
void AddGrade(Student student,int grade) {
    student.SetCourseGrade(grade);
}

void RegisterEnrollment(int id,Student student,Course course) {
    
    Enrolment newenrol = new Enrolment(id, course, student); 

    _enrolments.Add(newenrol);
    
}
