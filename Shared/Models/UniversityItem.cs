using System;

namespace Shared.Models
{
    public class UniversityItem
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public string Name { get; set; }

        public UniversityItem() { }

        public UniversityItem(string name, Guid id)
        {
            Name = name;
            Id = id;
        }

        public UniversityItem(string name, Guid id, Guid parentId) : this(name, id) => ParentId = parentId;
    }
}
