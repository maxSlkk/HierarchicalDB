using System;

namespace Shared.Models.Db
{
    public class UniversityItem
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public string Name { get; set; }

        public int NodeTypeId { get; set; }
        public NodeType NodeType { get; set; }

        public UniversityItem() { }

        public UniversityItem(string name, int nodeType, Guid id, Guid? parentId) 
        {
            Name = name;
            NodeTypeId = nodeType;
            Id = id;
            ParentId = parentId;
        }

        public static UniversityItem CreateUniversityItem(Guid id, string name, int nodeType, Guid? parentId)
        {
            return new UniversityItem(name, nodeType, id, parentId);
        }
    }
}
