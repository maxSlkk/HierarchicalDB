using Shared.Models.Db;
using System;

namespace Shared.Models.NodeTypes
{
    //[NotMapped]
    public class Person //: UniversityItem
    {
        public DateTime BirthDate { get; set; }
        public int Age => new DateTime(1, 1, 1).Date.Add(DateTime.Now.Date.Subtract(BirthDate.Date)).Year - 1;
    }
}
