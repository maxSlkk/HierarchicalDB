using EfUniversityHierarchical;
using Shared.Models;
using Shared.Models.Db;
using System;
using System.Linq;
using System.Windows.Forms;

namespace UniversityHierarchicalDB
{
    public partial class NewItemForm : Form
    {
        private UniversityRepository _repository;

        public NewItemResult Result { get; set; }

        public NewItemForm(string parentNodeName)
        {
            InitializeComponent();

            _repository = new UniversityRepository();

            tbParentNodeName.Text = parentNodeName;

            FillNodeTypesComboBox();
        }

        private void FillNodeTypesComboBox()
        {
            var nodeTypes = _repository.GetNodeTypes();

            comboBoxNodeType.Items.AddRange(nodeTypes.ToArray());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBoxNodeType.Text))
            {
                MessageBox.Show("You need to select type of node! Please, try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(tbNewNodeName.Text))
            {
                MessageBox.Show("Name can not be empty! Please, try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Result = new NewItemResult { NodeName = tbNewNodeName.Text, NodeType = (comboBoxNodeType.SelectedItem as NodeType).Id };

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
