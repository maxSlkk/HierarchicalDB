using Shared.Models.Db;
using Shared.Models.NodeTypes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EfUniversityHierarchical
{
    public class UniversityRepository
    {
        private UniversityContext _context;

        public UniversityRepository()
        {
            _context = new UniversityContext();
        }

        #region UniversityItems table
        public void AddItem(UniversityItem item)
        {
            _context.UniversityItems.Add(item);
        }

        public void RemoveItemById(Guid itemId)
        {
            var item = _context.UniversityItems.Find(itemId);
            if (item != null)
            {
                _context.UniversityItems.Remove(item);
            }
        }

        public void EditItem(UniversityItem item)
        {
            _context.UniversityItems.Find(item.Id).Name = item.Name;
        }


        public IEnumerable<UniversityItem> GetItems()
        {
            return _context.UniversityItems;
        }

        public UniversityItem GetItemById(Guid itemId)
        {
            return _context.UniversityItems.Find(itemId);
        }

        public IEnumerable<UniversityItem> GetItemsByParentId(Guid? itemId)
        {
            return _context.UniversityItems.Where(x => x.ParentId == itemId);
        }
        #endregion

        #region NodeTypes table
        public IEnumerable<NodeType> GetNodeTypes()
        {
            return _context.NodeTypes;
        }

        public NodeType GetNodeTypeById(int nodeTypeId)
        {
            return _context.NodeTypes.Find(nodeTypeId);
        }
        #endregion

        #region Students table
        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
        }
        #endregion

        #region People table
        public void AddPerson(Person person)
        {
            _context.Persons.Add(person);
        }
        #endregion


        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
