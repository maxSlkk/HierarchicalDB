using Shared.Models.Db;
using Shared.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models.NodeTypes
{
    public class Student
    {
        [Key]
        public Guid UniversityItemId { get; set; }
        public string GradebookNumber { get; set; }

        private Student(Guid id, string gradebookNumber)
        {
            UniversityItemId = id;
            GradebookNumber = gradebookNumber;
        }

        public static (Student, Person, UniversityItem) CreateStudent(Guid id, string name, int nodeType, Guid? parentId, DateTime birthDate, Sex sex, string gradebookNumber)
        {
            var res = Person.CreatePerson(id, name, nodeType, parentId, birthDate, sex);
            return (new Student(id, gradebookNumber), res.Item1, res.Item2);
        }
    }
}
