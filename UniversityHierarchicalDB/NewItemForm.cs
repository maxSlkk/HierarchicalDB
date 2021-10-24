using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityHierarchicalDB
{
    public partial class NewItemForm : Form
    {
        public string Result { get; set; }

        public NewItemForm(string parentNodeName)
        {
            InitializeComponent();

            tbParentNodeName.Text = parentNodeName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNewNodeName.Text))
            {
                MessageBox.Show("Name can not be empty! Please, try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Result = tbNewNodeName.Text;

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
