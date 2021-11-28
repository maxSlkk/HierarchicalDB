using Shared.Models.Enums;
using Shared.Models.FormResults;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityHierarchicalDB.CreatingNodesForms
{
    public partial class CreateStudentForm : Form
    {
        public CreateStudentResult Result { get; private set; }

        public CreateStudentForm(string parentNodeName)
        {
            InitializeComponent();

            tbParentNodeName.Text = parentNodeName;
            tbID.Text = Guid.NewGuid().ToString();
            cbSex.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Name can not be empty! Please, try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(tbGradebookNumber.Text))
            {
                MessageBox.Show("Gradebook number can not be empty! Please, try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Result = new CreateStudentResult
            {
                Id = Guid.Parse(tbID.Text),
                Name = tbName.Text,
                BirthDate = dateTimePickerBirth.Value.Date,
                Sex = (Sex)Enum.Parse(typeof(Sex), cbSex.Text),
                GradebookNumber = tbGradebookNumber.Text
            };

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
