namespace Burtu_spele
{
    partial class Form_settings
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
            this.bt_save = new System.Windows.Forms.Button();
            this.lb_nick = new System.Windows.Forms.Label();
            this.lb_level = new System.Windows.Forms.Label();
            this.lv_sound = new System.Windows.Forms.Label();
            this.tb_nick = new System.Windows.Forms.TextBox();
            this.cb_sound = new System.Windows.Forms.CheckBox();
            this.cb_level = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // bt_save
            // 
            this.bt_save.Location = new System.Drawing.Point(209, 87);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(57, 24);
            this.bt_save.TabIndex = 0;
            this.bt_save.Text = "Save";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // lb_nick
            // 
            this.lb_nick.AutoSize = true;
            this.lb_nick.Location = new System.Drawing.Point(23, 21);
            this.lb_nick.Name = "lb_nick";
            this.lb_nick.Size = new System.Drawing.Size(91, 15);
            this.lb_nick.TabIndex = 1;
            this.lb_nick.Text = "Type Your Nick:";
            // 
            // lb_level
            // 
            this.lb_level.AutoSize = true;
            this.lb_level.Location = new System.Drawing.Point(23, 59);
            this.lb_level.Name = "lb_level";
            this.lb_level.Size = new System.Drawing.Size(104, 30);
            this.lb_level.TabIndex = 2;
            this.lb_level.Text = "Select Your Level:\r\n\r\n";
            // 
            // lv_sound
            // 
            this.lv_sound.AutoSize = true;
            this.lv_sound.Location = new System.Drawing.Point(23, 89);
            this.lv_sound.Name = "lv_sound";
            this.lv_sound.Size = new System.Drawing.Size(46, 15);
            this.lv_sound.TabIndex = 3;
            this.lv_sound.Text = "Sound:";
            // 
            // tb_nick
            // 
            this.tb_nick.Location = new System.Drawing.Point(131, 19);
            this.tb_nick.Name = "tb_nick";
            this.tb_nick.Size = new System.Drawing.Size(135, 20);
            this.tb_nick.TabIndex = 4;
            // 
            // cb_sound
            // 
            this.cb_sound.AutoSize = true;
            this.cb_sound.Location = new System.Drawing.Point(131, 87);
            this.cb_sound.Name = "cb_sound";
            this.cb_sound.Size = new System.Drawing.Size(42, 19);
            this.cb_sound.TabIndex = 6;
            this.cb_sound.Text = "On";
            this.cb_sound.UseVisualStyleBackColor = true;
            // 
            // cb_level
            // 
            this.cb_level.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_level.FormattingEnabled = true;
            this.cb_level.Location = new System.Drawing.Point(131, 57);
            this.cb_level.Name = "cb_level";
            this.cb_level.Size = new System.Drawing.Size(135, 21);
            this.cb_level.TabIndex = 7;
            // 
            // Form_settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 121);
            this.Controls.Add(this.cb_level);
            this.Controls.Add(this.cb_sound);
            this.Controls.Add(this.tb_nick);
            this.Controls.Add(this.lv_sound);
            this.Controls.Add(this.lb_level);
            this.Controls.Add(this.lb_nick);
            this.Controls.Add(this.bt_save);
            this.Name = "Form_settings";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_settings_FormClosing);
            this.Load += new System.EventHandler(this.Form_settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.Label lb_nick;
        private System.Windows.Forms.Label lb_level;
        private System.Windows.Forms.Label lv_sound;
        private System.Windows.Forms.TextBox tb_nick;
        private System.Windows.Forms.CheckBox cb_sound;
        private System.Windows.Forms.ComboBox cb_level;
    }
}