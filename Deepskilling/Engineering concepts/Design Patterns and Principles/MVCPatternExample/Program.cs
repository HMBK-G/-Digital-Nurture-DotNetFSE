using System;

namespace MVCPatternExample
{
    class Student
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Grade { get; set; }

        public Student(string name, int id, string grade)
        {
            Name = name;
            Id = id;
            Grade = grade;
        }
    }

    class StudentView
    {
        public void DisplayStudentDetails(string name, int id, string grade)
        {
            Console.WriteLine("Student Details");
            Console.WriteLine("Name: " + name);
            Console.WriteLine("ID: " + id);
            Console.WriteLine("Grade: " + grade);
        }
    }

    class StudentController
    {
        private Student model;
        private StudentView view;

        public StudentController(Student model, StudentView view)
        {
            this.model = model;
            this.view = view;
        }

        public void SetStudentName(string name)
        {
            model.Name = name;
        }

        public void SetStudentId(int id)
        {
            model.Id = id;
        }

        public void SetStudentGrade(string grade)
        {
            model.Grade = grade;
        }

        public void UpdateView()
        {
            view.DisplayStudentDetails(
                model.Name,
                model.Id,
                model.Grade
            );
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("Hemambika", 109, "A");

            StudentView view = new StudentView();

            StudentController controller = new StudentController(student, view);

            controller.UpdateView();

            Console.WriteLine();

            controller.SetStudentName("Hema");
            controller.SetStudentGrade("A+");

            controller.UpdateView();

            Console.ReadKey();
        }
    }
}

/*
MVC Pattern:
The MVC (Model-View-Controller) Pattern separates an application into
three components. The Model stores data, the View displays data, and
the Controller manages communication between them. This separation
makes the application easier to maintain and modify.
*/