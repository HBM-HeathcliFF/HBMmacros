
namespace HBMmacros
{
    partial class EditHotKeys
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditHotKeys));
            this.label1 = new System.Windows.Forms.Label();
            this.tbw1 = new System.Windows.Forms.TextBox();
            this.tbw2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbw3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbhm = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.applyBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Weapon 1:";
            // 
            // tbw1
            // 
            this.tbw1.Location = new System.Drawing.Point(69, 6);
            this.tbw1.Name = "tbw1";
            this.tbw1.ReadOnly = true;
            this.tbw1.Size = new System.Drawing.Size(73, 20);
            this.tbw1.TabIndex = 1;
            this.tbw1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbw2
            // 
            this.tbw2.Location = new System.Drawing.Point(69, 27);
            this.tbw2.Name = "tbw2";
            this.tbw2.ReadOnly = true;
            this.tbw2.Size = new System.Drawing.Size(73, 20);
            this.tbw2.TabIndex = 3;
            this.tbw2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Weapon 2:";
            // 
            // tbw3
            // 
            this.tbw3.Location = new System.Drawing.Point(69, 47);
            this.tbw3.Name = "tbw3";
            this.tbw3.ReadOnly = true;
            this.tbw3.Size = new System.Drawing.Size(73, 20);
            this.tbw3.TabIndex = 5;
            this.tbw3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Weapon 3:";
            // 
            // tbhm
            // 
            this.tbhm.Location = new System.Drawing.Point(69, 68);
            this.tbhm.Name = "tbhm";
            this.tbhm.ReadOnly = true;
            this.tbhm.Size = new System.Drawing.Size(73, 20);
            this.tbhm.TabIndex = 7;
            this.tbhm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Heal/Mask:";
            // 
            // applyBtn
            // 
            this.applyBtn.Location = new System.Drawing.Point(9, 94);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(133, 23);
            this.applyBtn.TabIndex = 8;
            this.applyBtn.Text = "Apply changed";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // EditHotKeys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(151, 125);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.tbhm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbw3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbw2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbw1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(167, 163);
            this.MinimumSize = new System.Drawing.Size(167, 163);
            this.Name = "EditHotKeys";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbw1;
        private System.Windows.Forms.TextBox tbw2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbw3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbhm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button applyBtn;
    }
}