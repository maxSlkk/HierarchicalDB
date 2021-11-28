using Shared.Models.Db;
using Shared.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models.NodeTypes
{
    public class Person
    {
        [Key]
        public Guid UniversityItemId { get; set; }
        public DateTime BirthDate { get; set; }
        public Sex Sex { get; set; }

        private Person(Guid id, DateTime birthDate, Sex sex)
        {
            UniversityItemId = id;
            BirthDate = birthDate;
            Sex = sex;
        }

        public static (Person, UniversityItem) CreatePerson(Guid id, string name, int nodeType, Guid? parentId, DateTime birthDate, Sex sex)
        {
            return (new Person(id, birthDate, sex), UniversityItem.CreateUniversityItem(id, name, nodeType, parentId));
        }
    }
}
