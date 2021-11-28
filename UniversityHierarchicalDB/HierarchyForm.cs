using System;
using System.Windows.Forms;
using EfUniversityHierarchical;
using Shared.Models.Db;
using System.Linq;
using UniversityHierarchicalDB.CreatingNodesForms;
using Shared.Models.NodeTypes;

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

            var rootItems = _repository.GetItemsByParentId((Guid?)null).ToList();

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
                    var newUniversityItem = new UniversityItem(form.Result.NodeName, form.Result.NodeType, Guid.NewGuid(), null);

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

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = hierarchyTreeView.SelectedNode;

            using (var form = new ViewAndEditPropertiesForm(node.Tag, (node.Tag as UniversityItem).NodeTypeId))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    var item = (UniversityItem)form.Result.Obj;

                    _repository.EditItem(item);
                    _repository.SaveChanges();

                    hierarchyTreeView.SelectedNode.Text = item.Name;
                }
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

        #region Creating typed nodes
        private void studentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (var form = new CreateStudentForm(hierarchyTreeView.SelectedNode.Text))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    var nodeTypeId = _repository.GetNodeTypes().First(x => x.Type.Equals("Student")).Id;

                    var (student, person, universityItem) =
                        Student.CreateStudent(form.Result.Id, form.Result.Name, nodeTypeId, (hierarchyTreeView.SelectedNode.Tag as UniversityItem).Id,
                            form.Result.BirthDate, form.Result.Sex, form.Result.GradebookNumber);

                    var node = new TreeNode(universityItem.Name)
                    {
                        Tag = universityItem,
                        ContextMenuStrip = nodeContextMenu
                    };

                    _repository.AddItem(universityItem);
                    _repository.AddPerson(person);
                    _repository.AddStudent(student);
                    _repository.SaveChanges();

                    hierarchyTreeView.SelectedNode.Nodes.Add(node);
                }
            }
        }
        #endregion
    }
}
