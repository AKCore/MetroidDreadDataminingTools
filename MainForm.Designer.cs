
namespace MetroidDreadDatamine
{
    partial class MainForm
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
            this.btnLoad = new DarkUI.Controls.DarkButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.className = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Damage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Checked = false;
            this.btnLoad.Location = new System.Drawing.Point(12, 55);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(110, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load Tunables";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.className,
            this.ClassType,
            this.Damage});
            this.dataGridView1.Location = new System.Drawing.Point(13, 85);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(775, 353);
            this.dataGridView1.TabIndex = 2;
            // 
            // className
            // 
            this.className.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.className.Frozen = true;
            this.className.HeaderText = "Class Name";
            this.className.Name = "className";
            this.className.Width = 88;
            // 
            // ClassType
            // 
            this.ClassType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ClassType.Frozen = true;
            this.ClassType.HeaderText = "Class Type";
            this.ClassType.Name = "ClassType";
            this.ClassType.Width = 84;
            // 
            // Damage
            // 
            this.Damage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Damage.Frozen = true;
            this.Damage.HeaderText = "Damage";
            this.Damage.Name = "Damage";
            this.Damage.Width = 72;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnLoad);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DarkUI.Controls.DarkButton btnLoad;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn className;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Damage;
    }
}

