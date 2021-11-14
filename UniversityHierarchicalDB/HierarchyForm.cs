using System;
using System.Windows.Forms;
using EfUniversityHierarchical;
using Shared.Models.Db;
using System.Linq;

namespace UniversityHierarchicalDB
{
    public partial class HierarchyForm : Form
    {
        private UniversityRepository _repository;

        public HierarchyForm()
        {
            InitializeComponent();

            hierarchyTreeView.NodeMouseClick += (sender, args)
                => hierarchyTreeView.SelectedNode = args.Node;

            _repository = new UniversityRepository();

            RefreshTree();
        }

        private void RefreshTree()
        {
            hierarchyTreeView.Nodes.Clear();

            var rootItems = _repository.GetItemsByParentId((Guid?)null);

            foreach (var item in rootItems)
            {
                var node = new TreeNode(item.Name)
                {
                    Tag = item
                };

                if (_repository.GetItemsByParentId(item.Id).Any())
                {
                    node.Nodes.Add(new TreeNode("TO_DELETE"));
                }

                node.ContextMenuStrip = nodeContextMenu;

                hierarchyTreeView.Nodes.Add(node);
            }
        }

        private void addRootItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new NewItemForm(""))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    var newUniversityItem = new UniversityItem(form.Result.NodeName, form.Result.NodeType, Guid.NewGuid());

                    var node = new TreeNode(newUniversityItem.Name)
                    {
                        Tag = newUniversityItem,
                        ContextMenuStrip = nodeContextMenu
                    };

                    _repository.AddItem(newUniversityItem);
                    _repository.SaveChanges();

                    hierarchyTreeView.Nodes.Add(node);
                }
            }
        }

        private void addNewItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new NewItemForm(hierarchyTreeView.SelectedNode.Text))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    var newUniversityItem = new UniversityItem(form.Result.NodeName, form.Result.NodeType, Guid.NewGuid(),
                        (hierarchyTreeView.SelectedNode.Tag as UniversityItem).Id);

                    var node = new TreeNode(newUniversityItem.Name)
                    {
                        Tag = newUniversityItem,
                        ContextMenuStrip = nodeContextMenu
                    };

                    _repository.AddItem(newUniversityItem);
                    _repository.SaveChanges();

                    hierarchyTreeView.SelectedNode.Nodes.Add(node);
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = hierarchyTreeView.SelectedNode;

            if (_repository.GetItemsByParentId((node.Tag as UniversityItem).Id).Count() > 0)
            {
                MessageBox.Show("You can not delete node that contains another nodes!", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show($"You are about to delete item \"{node.Text}\".\nAre you sure?",
            "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                _repository.RemoveItemById((node.Tag as UniversityItem).Id);
                _repository.SaveChanges();

                node.Parent.Nodes.Remove(node);
            }
        }


        private void hierarchyTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count != 1 && e.Node.Nodes[0].Text != "TO_DELETE")
            {
                return;
            }

            e.Node.Nodes.Clear();

            var childrenItems = _repository.GetItemsByParentId((e.Node.Tag as UniversityItem).Id);

            foreach (var item in childrenItems)
            {
                var node = new TreeNode(item.Name)
                {
                    Tag = item
                };

                if (_repository.GetItemsByParentId(item.Id).Any())
                {
                    node.Nodes.Add(new TreeNode("TO_DELETE"));
                }

                node.ContextMenuStrip = nodeContextMenu;
                e.Node.Nodes.Add(node);
            }
        }
    }
}
