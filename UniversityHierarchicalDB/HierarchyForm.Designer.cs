
namespace UniversityHierarchicalDB
{
    partial class HierarchyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.hierarchyTreeView = new System.Windows.Forms.TreeView();
            this.hierarchyTreeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addRootItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.nodeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.specialtyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cathedraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.professorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hierarchyTreeContextMenu.SuspendLayout();
            this.nodeContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // hierarchyTreeView
            // 
            this.hierarchyTreeView.ContextMenuStrip = this.hierarchyTreeContextMenu;
            this.hierarchyTreeView.Location = new System.Drawing.Point(12, 25);
            this.hierarchyTreeView.Name = "hierarchyTreeView";
            this.hierarchyTreeView.Size = new System.Drawing.Size(306, 413);
            this.hierarchyTreeView.TabIndex = 0;
            this.hierarchyTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.hierarchyTreeView_BeforeExpand);
            // 
            // hierarchyTreeContextMenu
            // 
            this.hierarchyTreeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRootItemToolStripMenuItem});
            this.hierarchyTreeContextMenu.Name = "hierarchyTreeContextMenu";
            this.hierarchyTreeContextMenu.ShowImageMargin = false;
            this.hierarchyTreeContextMenu.Size = new System.Drawing.Size(124, 26);
            // 
            // addRootItemToolStripMenuItem
            // 
            this.addRootItemToolStripMenuItem.Name = "addRootItemToolStripMenuItem";
            this.addRootItemToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.addRootItemToolStripMenuItem.Text = "Add root item";
            this.addRootItemToolStripMenuItem.Click += new System.EventHandler(this.addRootItemToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "University hierarchy:";
            // 
            // nodeContextMenu
            // 
            this.nodeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewItemToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.propertiesToolStripMenuItem});
            this.nodeContextMenu.Name = "nodeContextMenu";
            this.nodeContextMenu.ShowImageMargin = false;
            this.nodeContextMenu.Size = new System.Drawing.Size(156, 92);
            // 
            // addNewItemToolStripMenuItem
            // 
            this.addNewItemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentToolStripMenuItem,
            this.specialtyToolStripMenuItem,
            this.cathedraToolStripMenuItem,
            this.groupToolStripMenuItem,
            this.studentToolStripMenuItem1,
            this.professorToolStripMenuItem});
            this.addNewItemToolStripMenuItem.Name = "addNewItemToolStripMenuItem";
            this.addNewItemToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.addNewItemToolStripMenuItem.Text = "Add new item";
            this.addNewItemToolStripMenuItem.Click += new System.EventHandler(this.addNewItemToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
            // 
            // studentToolStripMenuItem
            // 
            this.studentToolStripMenuItem.Name = "studentToolStripMenuItem";
            this.studentToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.studentToolStripMenuItem.Text = "Faculty";
            // 
            // specialtyToolStripMenuItem
            // 
            this.specialtyToolStripMenuItem.Name = "specialtyToolStripMenuItem";
            this.specialtyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.specialtyToolStripMenuItem.Text = "Specialty";
            // 
            // cathedraToolStripMenuItem
            // 
            this.cathedraToolStripMenuItem.Name = "cathedraToolStripMenuItem";
            this.cathedraToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cathedraToolStripMenuItem.Text = "Cathedra";
            // 
            // groupToolStripMenuItem
            // 
            this.groupToolStripMenuItem.Name = "groupToolStripMenuItem";
            this.groupToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.groupToolStripMenuItem.Text = "Group";
            // 
            // studentToolStripMenuItem1
            // 
            this.studentToolStripMenuItem1.Name = "studentToolStripMenuItem1";
            this.studentToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.studentToolStripMenuItem1.Text = "Student";
            this.studentToolStripMenuItem1.Click += new System.EventHandler(this.studentToolStripMenuItem1_Click);
            // 
            // professorToolStripMenuItem
            // 
            this.professorToolStripMenuItem.Name = "professorToolStripMenuItem";
            this.professorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.professorToolStripMenuItem.Text = "Professor";
            // 
            // HierarchyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hierarchyTreeView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "HierarchyForm";
            this.Text = "HierarchicalDB";
            this.hierarchyTreeContextMenu.ResumeLayout(false);
            this.nodeContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView hierarchyTreeView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip hierarchyTreeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem addRootItemToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip nodeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem addNewItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem specialtyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cathedraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem professorToolStripMenuItem;
    }
}

