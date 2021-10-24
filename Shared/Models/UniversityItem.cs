using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    public class UniversityItem
    {
        public int Id { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string Name { get; set; }

        public UniversityItem() { }

        public UniversityItem(string name) => Name = name;

        public UniversityItem(string name, int parentId) : this(name) => ParentId = parentId;
    }
}
