using System.Collections.Generic;

namespace Shared.Models.Db
{
    public class NodeType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public ICollection<UniversityItem> UniversityItems { get; set; }

        public override string ToString()
        {
            return Type;
        }
    }
}
