using Shared.Models.Enums;
using System;

namespace Shared.Models.FormResults
{
    public class CreateStudentResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Sex Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public string GradebookNumber { get; set; }
    }
}
