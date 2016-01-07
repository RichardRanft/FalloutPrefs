namespace FalloutPrefs
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.tbxSourceINI = new System.Windows.Forms.TextBox();
            this.ofdOpen = new System.Windows.Forms.OpenFileDialog();
            this.tctrlSettings = new System.Windows.Forms.TabControl();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source INI file:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(376, 23);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // tbxSourceINI
            // 
            this.tbxSourceINI.Location = new System.Drawing.Point(12, 25);
            this.tbxSourceINI.Name = "tbxSourceINI";
            this.tbxSourceINI.Size = new System.Drawing.Size(358, 20);
            this.tbxSourceINI.TabIndex = 2;
            // 
            // ofdOpen
            // 
            this.ofdOpen.Filter = "INI files|*.ini";
            // 
            // tctrlSettings
            // 
            this.tctrlSettings.Location = new System.Drawing.Point(12, 51);
            this.tctrlSettings.Name = "tctrlSettings";
            this.tctrlSettings.SelectedIndex = 0;
            this.tctrlSettings.Size = new System.Drawing.Size(726, 476);
            this.tctrlSettings.TabIndex = 3;
            this.tctrlSettings.SelectedIndexChanged += new System.EventHandler(this.tctrlSettings_SelectedIndexChanged);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(457, 23);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(98, 23);
            this.btnRestore.TabIndex = 4;
            this.btnRestore.Text = "Restore Backup";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(663, 23);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 537);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.tctrlSettings);
            this.Controls.Add(this.tbxSourceINI);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(765, 576);
            this.Name = "Form1";
            this.Text = "Fallout 4 Preferences";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox tbxSourceINI;
        private System.Windows.Forms.OpenFileDialog ofdOpen;
        private System.Windows.Forms.TabControl tctrlSettings;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnSave;
    }
}

