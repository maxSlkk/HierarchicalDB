using System;
using Shared.Models.NodeTypes;
using System.Windows.Forms;
using EfUniversityHierarchical;
using System.Collections.Generic;
using System.Reflection;
using Shared.Models.Db;
using Shared.Models;

namespace UniversityHierarchicalDB
{
    public partial class ViewAndEditPropertiesForm : Form
    {
        private bool _isEditModeEnabled = false;
        private UniversityRepository _repository;
        public EditPropertiesResult Result;

        private object _obj;
        private int _objType;

        public ViewAndEditPropertiesForm(object obj, int objType)
        {
            InitializeComponent();

            _repository = new UniversityRepository();
            _obj = obj;
            _objType = objType;

            ShowNeededFields();
        }

        private void ShowNeededFields()
        {
            var item = (UniversityItem)_obj;

            tbID.Text = item.Id.ToString();
            tbName.Text = item.Name;

            //var typeName = _repository.GetNodeTypeById(objType).Type;

            //if (typeName == "Student")
            //{
            //    var student = (Student)obj;

            //    var properties = typeof(Student).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            //    var tbBirthDate = new TextBox
            //    {
            //        Text = student.BirthDate.ToString()
            //    };

            //    var tbGradebookNumber = new TextBox
            //    {
            //        Text = student.GradebookNumber.ToString()
            //    };

            //    Controls.Add(tbBirthDate);
            //    Controls.Add(tbGradebookNumber);
            //}
            //else if (typeName == "Person")
            //{
            //    var properties = typeof(Person).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            //}
        }

        private void btnEnableEditing_Click(object sender, EventArgs e)
        {
            if (_isEditModeEnabled == false)
            {
                _isEditModeEnabled = true;
                btnSave.Enabled = true;
                tbName.ReadOnly = false;
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

            var item = (UniversityItem)_obj;
            item.Name = tbName.Text;

            Result = new EditPropertiesResult { ObjType = _objType, Obj = item };

            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
