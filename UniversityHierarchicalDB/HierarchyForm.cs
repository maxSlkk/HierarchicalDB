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

            var rootItems = _repository.GetItemsByParentId((Guid?)null);

            foreach (var item in rootItems)
            {
                var node = new TreeNode(item.Name)
                {
                    Tag = item.Id
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
                    var node = new TreeNode(form.Result)
                    {
                        Tag = Guid.NewGuid()
                    };
                    node.ContextMenuStrip = nodeContextMenu;

                    _repository.AddItem(new UniversityItem(node.Text, (Guid)node.Tag));
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
                    var node = new TreeNode(form.Result)
                    {
                        Tag = Guid.NewGuid()
                    };
                    node.ContextMenuStrip = nodeContextMenu;

                    _repository.AddItem(new UniversityItem(node.Text, (Guid)node.Tag,
                        (Guid)hierarchyTreeView.SelectedNode.Tag));
                    _repository.SaveChanges();

                    hierarchyTreeView.SelectedNode.Nodes.Add(node);
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
                if (_repository.GetItemsByParentId((Guid)node.Tag).Count() == 0)
                {
                    _repository.RemoveItemById((Guid)node.Tag);
                    _repository.SaveChanges();

                    node.Parent.Nodes.Remove(node);

                    return;
                }

                MessageBox.Show("You can not delete node that contains another nodes!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void hierarchyTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Text == "TO_DELETE")
            {
                e.Node.Nodes.Clear();

                var childrenItems = _repository.GetItemsByParentId((Guid)e.Node.Tag);

                foreach (var item in childrenItems)
                {
                    var node = new TreeNode(item.Name)
                    {
                        Tag = item.Id
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
}
