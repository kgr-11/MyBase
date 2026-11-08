namespace MyBaseOnCSharp
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.treeView_book = new System.Windows.Forms.TreeView();
            this.contextMenuStrip_Tree_selectNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddTopicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteTopicToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox_info = new System.Windows.Forms.RichTextBox();
            this.button_add_record = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_clear_record = new System.Windows.Forms.Button();
            this.button_edit_record = new System.Windows.Forms.Button();
            this.textBox_nameRecord = new System.Windows.Forms.TextBox();
            this.imageList_Icon = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip_Tree_notSelectNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddTopicToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox_record = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_SearchCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_search = new System.Windows.Forms.Button();
            this.textBox_addressRecordForSearch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_textRecordForSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_nameRecordForSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip_Tree_selectNode.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip_Tree_notSelectNode.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView_book
            // 
            this.treeView_book.AllowDrop = true;
            this.treeView_book.LabelEdit = true;
            this.treeView_book.Location = new System.Drawing.Point(12, 12);
            this.treeView_book.Name = "treeView_book";
            this.treeView_book.Size = new System.Drawing.Size(234, 407);
            this.treeView_book.TabIndex = 0;
            this.treeView_book.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView_book_ItemDrag);
            this.treeView_book.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView_book_DragDrop);
            this.treeView_book.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView_book_DragEnter);
            this.treeView_book.DragOver += new System.Windows.Forms.DragEventHandler(this.treeView_book_DragOver);
            this.treeView_book.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView_book_MouseDown);
            // 
            // contextMenuStrip_Tree_selectNode
            // 
            this.contextMenuStrip_Tree_selectNode.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip_Tree_selectNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddTopicToolStripMenuItem,
            this.DeleteTopicToolStripMenuItem1});
            this.contextMenuStrip_Tree_selectNode.Name = "contextMenuStrip_Tree_selectNode";
            this.contextMenuStrip_Tree_selectNode.Size = new System.Drawing.Size(182, 52);
            // 
            // AddTopicToolStripMenuItem
            // 
            this.AddTopicToolStripMenuItem.Name = "AddTopicToolStripMenuItem";
            this.AddTopicToolStripMenuItem.Size = new System.Drawing.Size(181, 24);
            this.AddTopicToolStripMenuItem.Text = "Добавить тему";
            this.AddTopicToolStripMenuItem.Click += new System.EventHandler(this.AddTopicToolStripMenuItem_Click);
            // 
            // DeleteTopicToolStripMenuItem1
            // 
            this.DeleteTopicToolStripMenuItem1.Name = "DeleteTopicToolStripMenuItem1";
            this.DeleteTopicToolStripMenuItem1.Size = new System.Drawing.Size(181, 24);
            this.DeleteTopicToolStripMenuItem1.Text = "Удалить";
            this.DeleteTopicToolStripMenuItem1.Click += new System.EventHandler(this.DeleteTopicToolStripMenuItem1_Click);
            // 
            // richTextBox_info
            // 
            this.richTextBox_info.Location = new System.Drawing.Point(252, 12);
            this.richTextBox_info.Name = "richTextBox_info";
            this.richTextBox_info.Size = new System.Drawing.Size(780, 407);
            this.richTextBox_info.TabIndex = 2;
            this.richTextBox_info.Text = "";
            this.richTextBox_info.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox_info_LinkClicked);
            // 
            // button_add_record
            // 
            this.button_add_record.Location = new System.Drawing.Point(261, 21);
            this.button_add_record.Name = "button_add_record";
            this.button_add_record.Size = new System.Drawing.Size(225, 51);
            this.button_add_record.TabIndex = 4;
            this.button_add_record.Text = "Добавить новую запись";
            this.button_add_record.UseVisualStyleBackColor = true;
            this.button_add_record.Click += new System.EventHandler(this.button_add_record_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Выбрана тема:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_clear_record);
            this.groupBox1.Controls.Add(this.button_edit_record);
            this.groupBox1.Controls.Add(this.textBox_nameRecord);
            this.groupBox1.Controls.Add(this.button_add_record);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 425);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(505, 267);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавление/редактирование/удаление записей";
            // 
            // button_clear_record
            // 
            this.button_clear_record.Location = new System.Drawing.Point(261, 135);
            this.button_clear_record.Name = "button_clear_record";
            this.button_clear_record.Size = new System.Drawing.Size(225, 51);
            this.button_clear_record.TabIndex = 7;
            this.button_clear_record.Text = "Очистить запись";
            this.button_clear_record.UseVisualStyleBackColor = true;
            this.button_clear_record.Click += new System.EventHandler(this.button_clear_record_Click);
            // 
            // button_edit_record
            // 
            this.button_edit_record.Location = new System.Drawing.Point(261, 78);
            this.button_edit_record.Name = "button_edit_record";
            this.button_edit_record.Size = new System.Drawing.Size(225, 51);
            this.button_edit_record.TabIndex = 7;
            this.button_edit_record.Text = "Редактировать запись";
            this.button_edit_record.UseVisualStyleBackColor = true;
            this.button_edit_record.Click += new System.EventHandler(this.button_edit_record_Click);
            // 
            // textBox_nameRecord
            // 
            this.textBox_nameRecord.Location = new System.Drawing.Point(115, 25);
            this.textBox_nameRecord.Name = "textBox_nameRecord";
            this.textBox_nameRecord.Size = new System.Drawing.Size(131, 22);
            this.textBox_nameRecord.TabIndex = 6;
            // 
            // imageList_Icon
            // 
            this.imageList_Icon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_Icon.ImageStream")));
            this.imageList_Icon.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_Icon.Images.SetKeyName(0, "pink-xopixel-folder_99392.ico");
            this.imageList_Icon.Images.SetKeyName(1, "fileinterfacesymboloftextpapersheet_79740.ico");
            this.imageList_Icon.Images.SetKeyName(2, "stickynotes.ico");
            // 
            // contextMenuStrip_Tree_notSelectNode
            // 
            this.contextMenuStrip_Tree_notSelectNode.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip_Tree_notSelectNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddTopicToolStripMenuItem1});
            this.contextMenuStrip_Tree_notSelectNode.Name = "contextMenuStrip_Tree_notSelectNode";
            this.contextMenuStrip_Tree_notSelectNode.Size = new System.Drawing.Size(182, 28);
            // 
            // AddTopicToolStripMenuItem1
            // 
            this.AddTopicToolStripMenuItem1.Name = "AddTopicToolStripMenuItem1";
            this.AddTopicToolStripMenuItem1.Size = new System.Drawing.Size(181, 24);
            this.AddTopicToolStripMenuItem1.Text = "Добавить тему";
            this.AddTopicToolStripMenuItem1.Click += new System.EventHandler(this.AddTopicToolStripMenuItem1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox_record);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBox_SearchCount);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.button_search);
            this.groupBox2.Controls.Add(this.textBox_addressRecordForSearch);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox_textRecordForSearch);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox_nameRecordForSearch);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(523, 425);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(509, 267);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Поиск темы";
            // 
            // comboBox_record
            // 
            this.comboBox_record.FormattingEnabled = true;
            this.comboBox_record.Location = new System.Drawing.Point(294, 212);
            this.comboBox_record.Name = "comboBox_record";
            this.comboBox_record.Size = new System.Drawing.Size(209, 24);
            this.comboBox_record.TabIndex = 10;
            this.comboBox_record.SelectedIndexChanged += new System.EventHandler(this.comboBox_record_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(227, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Темы: ";
            // 
            // textBox_SearchCount
            // 
            this.textBox_SearchCount.Location = new System.Drawing.Point(141, 212);
            this.textBox_SearchCount.Name = "textBox_SearchCount";
            this.textBox_SearchCount.ReadOnly = true;
            this.textBox_SearchCount.Size = new System.Drawing.Size(80, 22);
            this.textBox_SearchCount.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Найденно тем: ";
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(302, 143);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(201, 51);
            this.button_search.TabIndex = 6;
            this.button_search.Text = "Искать";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // textBox_addressRecordForSearch
            // 
            this.textBox_addressRecordForSearch.Location = new System.Drawing.Point(141, 160);
            this.textBox_addressRecordForSearch.Name = "textBox_addressRecordForSearch";
            this.textBox_addressRecordForSearch.Size = new System.Drawing.Size(136, 22);
            this.textBox_addressRecordForSearch.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Адреса сайтов: ";
            // 
            // textBox_textRecordForSearch
            // 
            this.textBox_textRecordForSearch.Location = new System.Drawing.Point(141, 64);
            this.textBox_textRecordForSearch.Multiline = true;
            this.textBox_textRecordForSearch.Name = "textBox_textRecordForSearch";
            this.textBox_textRecordForSearch.Size = new System.Drawing.Size(362, 65);
            this.textBox_textRecordForSearch.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Текст темы: ";
            // 
            // textBox_nameRecordForSearch
            // 
            this.textBox_nameRecordForSearch.Location = new System.Drawing.Point(141, 25);
            this.textBox_nameRecordForSearch.Name = "textBox_nameRecordForSearch";
            this.textBox_nameRecordForSearch.Size = new System.Drawing.Size(136, 22);
            this.textBox_nameRecordForSearch.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Название темы: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 704);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.richTextBox_info);
            this.Controls.Add(this.treeView_book);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Иерархичесакя записная книжка";
            this.contextMenuStrip_Tree_selectNode.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip_Tree_notSelectNode.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView_book;
        private System.Windows.Forms.RichTextBox richTextBox_info;
        private System.Windows.Forms.Button button_add_record;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_clear_record;
        private System.Windows.Forms.Button button_edit_record;
        private System.Windows.Forms.TextBox textBox_nameRecord;
        private System.Windows.Forms.ImageList imageList_Icon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Tree_selectNode;
        private System.Windows.Forms.ToolStripMenuItem AddTopicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteTopicToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Tree_notSelectNode;
        private System.Windows.Forms.ToolStripMenuItem AddTopicToolStripMenuItem1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_textRecordForSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_nameRecordForSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.TextBox textBox_addressRecordForSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_SearchCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_record;
    }
}

