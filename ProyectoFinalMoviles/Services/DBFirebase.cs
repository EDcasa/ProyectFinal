using Firebase.Database;
using Firebase.Database.Query;
using ProyectoFinalMoviles.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalMoviles.Services
{
    public class DBFirebase
    {
        FirebaseClient client;
        public DBFirebase()
        {
            client = new FirebaseClient("https://lostpeopleui-default-rtdb.firebaseio.com/");
        }
        public ObservableCollection<Student> getStudent()
        {
            var studentData = client.Child("Students").AsObservable<Student>().AsObservableCollection();
            return studentData;
        }
        public async Task AddStudent(string numberDocument, string firstName, string lastname, int age, DateTime lastView, string description, string observations)
        {
            Student s = new Student() {NumberDocument= numberDocument,  FirstName = firstName, LastName = lastname, Age = age, LastView=lastView, Description= description, Observation=observations };
            await client.Child("Students").PostAsync(s);
        }
        public async Task UpdateStudent(string firstName, string lastName, int age)
        {
            var toUpdateStudent = (await client.Child("Students").OnceAsync<Student>()).FirstOrDefault
                (a => a.Object.FirstName == firstName);
            Student s = new Student() { FirstName = firstName, LastName = lastName, Age = age };
            await client.Child("Students").Child(toUpdateStudent.Key).PutAsync(s);
        }
        public async Task DeleteStudent(string firstName, string lastName, int age)
        {
            var toDeleteStudent = (await client.Child("Students"
                ).OnceAsync<Student>()).FirstOrDefault
                (a => a.Object.FirstName == firstName || a.Object.LastName == lastName);
            await client.Child("Students").Child(toDeleteStudent.Key).DeleteAsync();
        }

        public  async Task FindStudent(string numberDocument)
        {
            var student = (await client
                .Child("Students")
                .OnceAsync<Student>()).FirstOrDefault
                (a => a.Object.NumberDocument == numberDocument);

            // and here you bind the student to the view 
            //fitstName.Text = student.firstName.ToString();
            //lastName.Text = student.lastName.ToString();
        }

    }
}
