using System;
using Shared.Models.NodeTypes;
using System.Windows.Forms;
using EfUniversityHierarchical;
using System.Collections.Generic;
using System.Reflection;

namespace UniversityHierarchicalDB
{
    public partial class ViewAndEditPropertiesForm : Form
    {
        private bool _isEditModeEnabled = false;
        private UniversityRepository _repository;
        public object Result;

        public ViewAndEditPropertiesForm(object obj, int objType)
        {
            InitializeComponent();

            _repository = new UniversityRepository();

            ShowNeededFields(obj, objType);
        }

        private void ShowNeededFields(object obj, int objType)
        {
            var typeName = _repository.GetNodeTypeById(objType).Type;

            if (typeName == "Student")
            {
                var properties = typeof(Student).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            }
            else if (typeName == "Person")
            {
                var properties = typeof(Person).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            }
        }

        private void btnEnableEditing_Click(object sender, EventArgs e)
        {
            if (_isEditModeEnabled == false)
            {
                _isEditModeEnabled = true;
                btnSave.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_isEditModeEnabled == true)
            {
                var result = MessageBox.Show("Your changes will be lost. \nAre you sure?",
                    "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    return;
                }
            }

            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Name can not be empty! Please, try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Result = null;

            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
