using Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public void RemoveItemById(int itemId)
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

        public UniversityItem GetItemById(int itemId)
        {
            return _context.UniversityItems.Find(itemId);
        }

        public IEnumerable<UniversityItem> GetRootItems()
        {
            return _context.UniversityItems.Where(x => x.ParentId == (int?)null);
        }

        public IEnumerable<UniversityItem> GetChildrenItems(int itemId)
        {
            return _context.UniversityItems.Where(x => x.ParentId == itemId);
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
