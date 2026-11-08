namespace MyBaseOnCSharp
{
    partial class NewRecord
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox_record = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_saveRecord = new System.Windows.Forms.Button();
            this.button_add_giperRef = new System.Windows.Forms.Button();
            this.button_add_image = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox_record);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(735, 384);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Запись";
            // 
            // richTextBox_record
            // 
            this.richTextBox_record.Location = new System.Drawing.Point(6, 21);
            this.richTextBox_record.Name = "richTextBox_record";
            this.richTextBox_record.Size = new System.Drawing.Size(723, 357);
            this.richTextBox_record.TabIndex = 0;
            this.richTextBox_record.Text = "";
            this.richTextBox_record.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox_record_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_saveRecord);
            this.groupBox2.Controls.Add(this.button_add_giperRef);
            this.groupBox2.Controls.Add(this.button_add_image);
            this.groupBox2.Location = new System.Drawing.Point(12, 402);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(735, 102);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Элементы управления";
            // 
            // button_saveRecord
            // 
            this.button_saveRecord.Location = new System.Drawing.Point(506, 31);
            this.button_saveRecord.Name = "button_saveRecord";
            this.button_saveRecord.Size = new System.Drawing.Size(220, 60);
            this.button_saveRecord.TabIndex = 2;
            this.button_saveRecord.Text = "Сохранить запись";
            this.button_saveRecord.UseVisualStyleBackColor = true;
            this.button_saveRecord.Click += new System.EventHandler(this.button_saveRecord_Click);
            // 
            // button_add_giperRef
            // 
            this.button_add_giperRef.Location = new System.Drawing.Point(256, 31);
            this.button_add_giperRef.Name = "button_add_giperRef";
            this.button_add_giperRef.Size = new System.Drawing.Size(220, 60);
            this.button_add_giperRef.TabIndex = 1;
            this.button_add_giperRef.Text = "Добавить гиперссылку";
            this.button_add_giperRef.UseVisualStyleBackColor = true;
            this.button_add_giperRef.Click += new System.EventHandler(this.button_add_giperRef_Click);
            // 
            // button_add_image
            // 
            this.button_add_image.Location = new System.Drawing.Point(3, 31);
            this.button_add_image.Name = "button_add_image";
            this.button_add_image.Size = new System.Drawing.Size(220, 60);
            this.button_add_image.TabIndex = 0;
            this.button_add_image.Text = "Добавить изображение";
            this.button_add_image.UseVisualStyleBackColor = true;
            this.button_add_image.Click += new System.EventHandler(this.button_add_image_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // NewRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 514);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "NewRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewRecord";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextBox_record;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_saveRecord;
        private System.Windows.Forms.Button button_add_giperRef;
        private System.Windows.Forms.Button button_add_image;
        private System.Windows.Forms.ImageList imageList1;
    }
}