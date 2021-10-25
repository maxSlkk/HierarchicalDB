using System;
using System.Windows.Forms;
using EfUniversityHierarchical;
using Shared.Models;
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

            var rootItems = _repository.GetItemsByParentId((int?)null);

            foreach (var item in rootItems)
            {
                var node = new TreeNode(item.Name, item.Id, 0);
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
                    var newNodeName = form.Result;

                    _repository.AddItem(new UniversityItem(newNodeName));
                    _repository.SaveChanges();

                    RefreshTree();
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
                    var newNodeName = form.Result;

                    _repository.AddItem(new UniversityItem(newNodeName, 
                        hierarchyTreeView.SelectedNode.ImageIndex));
                    _repository.SaveChanges();

                    RefreshTree();
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = hierarchyTreeView.SelectedNode;

            var result = MessageBox.Show($"You are about to delete item \"{node.Text}\".\nAre you sure?",
                "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (_repository.GetItemsByParentId(node.ImageIndex).Count() == 0)
                {
                    _repository.RemoveItemById(hierarchyTreeView.SelectedNode.ImageIndex);
                    _repository.SaveChanges();

                    RefreshTree();

                    return;
                }

                MessageBox.Show("You can not delete node that contains another nodes!", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void hierarchyTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.Nodes.Clear();

            var childrenItems = _repository.GetItemsByParentId(e.Node.ImageIndex);

            foreach(var item in childrenItems)
            {
                var node = new TreeNode(item.Name, item.Id, 0);
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
