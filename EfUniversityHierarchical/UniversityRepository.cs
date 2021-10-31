using Shared.Models;
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


        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
