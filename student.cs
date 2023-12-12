using System;
using System.Collections.Generic;

namespace student
{
    class Person
    {
        private int age;
        private string name;

        public Person()
        {
            Name = "no name";
            Age = 1;
        }

        public Person(string name, int age)
        {
            Age = age;
            Name = name;
        }

        public int Age
        {
            get { return age; }
            set { if (value < 0) value = 0; age = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual void Print()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            string str = $"Имя Фамилия: {Name}; Возраст: {age} ";
            return str;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Person);
        }

        public bool Equals(Person other) 
        {
            return other != null &&
                   Name == other.Name &&
                   Age == other.Age;
        }

        public override int GetHashCode() 
        {
            return HashCode.Combine(Name, Age);
        }

        public virtual Person Clone()
        {
            Person person = new Person();
            person.Name = Name;
            person.Age = Age;
            return person;
        }

        internal static string[] names = { "Анна Соколова", "Саша Сергеев", "Максим Кашин", "Ваня Мухин", "Ксюша Иванова", "Маша Смирнова", "Катя Мухина" };
        internal static int[] ages = { 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };
        public void RandomPerson()
        {
            Random rnd = new Random();
            name = names[rnd.Next(names.Length)];
            age = ages[rnd.Next(names.Length)];
        }
    }

    class Student : Person
    {
        private int kurs;

        public Student() : base()
        {
            kurs = 1;
        }

        public Student(string name, int age, int kurs) : base(name, age)
        {
            Kurs = kurs;
        }

        public int Kurs
        {
            get { return kurs; }
            set { if (value < 1) value = 1; kurs = value; }
        }

        public override string ToString()
        {
            string str = $"Имя Фамилия: {Name}; Возраст: {Age}; Курс: {kurs}";
            return str;
        }

        public override void Print()
        {
            Console.WriteLine(ToString());
        }

        public Student Clone()
        {
            Student student = new Student();
            student.Name = Name;
            student.Age = Age;
            student.Kurs = Kurs;
            return student;
        }

        static int[] kurses = { 1, 2, 3, 4, 5 };
        public void RandomStudent()
        {
            RandomPerson();
            Random rnd = new Random();
            kurs = kurses[rnd.Next(kurses.Length)];
        }

    }

    class Teacher : Person
    {
        private string post;

        public Teacher() : base()
        {
            Post = "Нет должности";
        }
        public Teacher(string name, int age, string post) : base(name, age)
        {
            Post = post;
        }

        public string Post
        {
            get { return post; }
            set { post = value; }
        }

        public List<Student> Students = new List<Student>();
        public void AddStudents(Student student)
        {
            Students.Add(student);
        }

        public override string ToString()
        {
            string str1 = "Студенты: ";
            foreach (var student in Students)
            {
                str1 += student.Name + ", ";
            }
            string str2 = $"Имя Фамилия: {Name}; Возраст: {Age}; Должность: {post};\n{str1}";
            return str2;
        }

        public override void Print()
        {
            Console.WriteLine(ToString());
        }

        public Teacher Clone()
        {
            Teacher teatcher = new Teacher();
            teatcher.Name = Name;
            teatcher.Age = Age;
            teatcher.Students = Students;
            teatcher.Post = Post;
            return teatcher;
        }

        static string[] positions = { "Ассистент", "Преподаватель", "Старший преподаватель", "Доцент", "Профессор"};
        public void RandomTeather()
        {
            RandomPerson();
            Random rnd = new Random();
            post = positions[rnd.Next(positions.Length)];
        }
    }

    internal class StudentWithAdvisor : Student
    {
        public Teacher Teacher { get; set; }

        public StudentWithAdvisor(string name, int age, int kurs, Teacher teacher) : base(name, age, kurs)
        {
            Teacher = teacher;
        }

        public override string ToString()
        {
            return $"Имя Фамилия: {Name}; Возраст: {Age}; Курс: {Kurs}; Преподаватель: {Teacher.Name}";
        }

        public override void Print()
        {
            Console.WriteLine(ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количнество студентов: ");
            int countStudent = Int32.Parse(Console.ReadLine());

            List<Person> listPerson = new List<Person>();
            Person person = new Person ("Варя Кошкина", 18);
            listPerson.Add(person);

            List<Teacher> listTeacher = new List<Teacher>();
            Teacher teatcher = new Teacher("Виктор Варанцов", 25, "Доцент");
            listPerson.Add(teatcher);
            listTeacher.Add(teatcher);

            Student student1 = new Student("Ольга Иванова", 21, 3);
            teatcher.AddStudents(student1);
            StudentWithAdvisor advisor = new StudentWithAdvisor("Ольга Иванова", 21, 3, teatcher);
            listPerson.Add(advisor);

            Teacher teatcher2 = new Teacher();
            teatcher2.RandomTeather();
            listPerson.Add(teatcher2);
            listTeacher.Add(teatcher2);

            Teacher teatcher3 = new Teacher();
            Student student2 = new Student();
            Random rnd = new Random();
            for (int i = 0; i < countStudent; i++)
            {
                teatcher3 = listTeacher[rnd.Next(2)];
                student2 = new Student();
                student2.RandomStudent();
                advisor = new StudentWithAdvisor(student2.Name, student2.Age, student2.Kurs, teatcher3);
                teatcher3.AddStudents(student2);
                listPerson.Add(advisor);
            }

            foreach (Person person1 in listPerson)
            {
                person1.Print();
                Console.WriteLine();
            }
            

            int countTeatcher = 0, countPerson = 0;
            countStudent = 0;

            foreach (Person person1 in listPerson)
            {
                if (person1 is Person)
                    countPerson++;

                if (person1.GetType() == typeof(Teacher))
                    countTeatcher++;

                if (person1 is Student)
                {
                    countStudent++;
                    student2 = (Student)person1;
                    student2.Kurs++;
                }
            }

            Console.WriteLine("\nВсего: " + countPerson);
            Console.WriteLine("Количество учителей: " + countTeatcher);
            Console.WriteLine("Количество студентов: " + countStudent);

            Console.WriteLine("\nПеревели студентов на следующий курс:");
            foreach (Person person1 in listPerson)
            {
                if (person1 is Student)
                {
                    person1.Print();
                    Console.WriteLine();
                }
            }


            for (int i = 0; i < countPerson; i++)
                listPerson.Add(listPerson[i].Clone());

            Console.WriteLine(listPerson[2].Name + " " + listPerson[2].Equals(listPerson[listPerson.Count - 1]) + " " + listPerson[listPerson.Count - 1].Name);
            Console.WriteLine(listPerson[3].Name + " " + listPerson[3].Equals(listPerson[listPerson.Count / 2 + 3]) + " " + listPerson[listPerson.Count / 2 + 3].Name);

            Type type = typeof(Student);
            Console.WriteLine("{0} наследуется от {1}.", type, type.BaseType);
        }
    }
}

