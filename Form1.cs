using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// в программе форма для создания новой записи используется сразу, и для добавление, и для редактирования записи
namespace MyBaseOnCSharp
{
    public partial class Form1 : Form
    {

        DB_MyBase db;
        private void numberInCollection(string number, TreeNode node,ref bool flag)//flag TRUE, ЕСЛИ ТАКОЙ НОМЕР УЖЕ ЕСТЬ, ИНАЧЕ FALSE
        {
            if (node.Name == number)
            {
                flag = true;
                return;
            }
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                numberInCollection(number, node.Nodes[i], ref flag);
            }
            flag = false;   
        }
        private string GenerationNumberNode(TreeView tree)
        { 
            Random random = new Random();
            bool flag=false;
            string number;
            do 
            {
                number="num-"+random.Next(1,10000).ToString();
                foreach (TreeNode node in tree.Nodes)
                {
                    numberInCollection(number, node, ref flag);
                }
            } while (flag);
            return number;
        }
        public Form1()
        {
            InitializeComponent();
           
            treeView_book.ImageList = imageList_Icon;
            treeView_book.AllowDrop = true;

            richTextBox_info.ReadOnly = true;
            //здесь функция выгрузка узлов из базы
            db = new DB_MyBase();
            Dictionary<string, int> indexIconForUnLoadNode=new Dictionary<string, int>();
            indexIconForUnLoadNode.Add("folder", 0);
            indexIconForUnLoadNode.Add("file", 1);
            indexIconForUnLoadNode.Add("note", 2);
            db.UnLoadNodeInTree(treeView_book, indexIconForUnLoadNode);

        }
        


        //переменные за выбор заметки для добавления, будем запоминать сразу узел
        private TreeNode node;
        //левый клик-отображение название выьранного элемента из дерева
        //правый клик-контексное меню
        private void treeView_book_MouseDown(object sender, MouseEventArgs e)
        {
            // Получаем узел под курсором (или null, если кликнули на пустом месте)
            TreeNode selectNode = treeView_book.GetNodeAt(e.Location);
            if (e.Button == MouseButtons.Left)//если кликнули левой кнопкой, то просмотр текста
            {
                if(selectNode != null)
                {
                    //здесь выбор заметки или файла в который считываем/записываем информацию
                    if (selectNode.Tag.ToString() !="folder")
                    {
                        textBox_nameRecord.Text = selectNode.Text;
                        node=selectNode;
                        richTextBox_info.ReadOnly = false;
                        //считываем данные из файла на форму
                        string data= db.GetDataFromNode(node.Name);
                        richTextBox_info.Rtf = db.GetDataFromNode(node.Name);
                        richTextBox_info.ReadOnly = true;
                        if (data != "")
                        {
                            button_add_record.Enabled = false;
                            button_edit_record.Enabled = true;
                        }
                        else
                        {
                            button_add_record.Enabled = true;
                            button_edit_record.Enabled = false;
                        }

                    }
                    treeView_book.SelectedNode = null;
                    label1.Focus();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (selectNode == null)
                {
                    // Показываем контекстное меню для добавления в корень
                    contextMenuStrip_Tree_notSelectNode.Show(treeView_book, e.Location);//Покажи моё контекстное меню на дереве, прямо в том месте, где пользователь кликнул мышкой
                }
                else
                {
                    //проверка, для кого показываем, если это заметка или файл, им вложенность дальнейшая запрещена
                    if (selectNode.Tag.ToString() == "folder")
                    {
                        AddTopicToolStripMenuItem.Visible = true;
                        AddTopicToolStripMenuItem.Enabled = true;
                        // Показываем контекстное меню для созданного узла
                        contextMenuStrip_Tree_selectNode.Show(treeView_book, e.Location);//Покажи моё контекстное меню на дереве, прямо в том месте, где пользователь кликнул мышкой
                    }
                    else //должны отобразить для элеметов не folder, что их можно удалить
                    {
                        // Показываем контекстное меню для созданного узла
                        AddTopicToolStripMenuItem.Visible = false;
                        AddTopicToolStripMenuItem.Enabled = false;
                        contextMenuStrip_Tree_selectNode.Show(treeView_book, e.Location);//Покажи моё контекстное меню на дереве, прямо в том месте, где пользователь кликнул мышкой
                    }
                }

            }
        }
        //добавить в узел
        private void AddTopicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddRoot form = new AddRoot(imageList_Icon);
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                //создание объекта узла
                TreeNode topicRecord = new TreeNode() { Text = form.NameNode, ImageIndex = form.IndexIcon, SelectedImageIndex = form.IndexIcon,Tag=form.TagNode, Name=GenerationNumberNode(treeView_book) };
                TreeNode SelectNode = treeView_book.SelectedNode;//выбранный узел
                SelectNode.Nodes.Add(topicRecord);

                //добавление записи в базу
                if (topicRecord.Parent == null)
                {
                    db.Add_Node_in_Base(topicRecord.Name, topicRecord.Tag.ToString(), topicRecord.Text, topicRecord.Level, null);
                }
                else
                {
                    db.Add_Node_in_Base(topicRecord.Name, topicRecord.Tag.ToString(), topicRecord.Text, topicRecord.Level, topicRecord.Parent.Name);
                }
                treeView_book.SelectedNode = null;
                label1.Focus();//передаем фокус на неважный элемент, чтобы при повторном
            }
            form.Dispose();
        }

        //удалить узел
        private void DeleteTopicToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TreeNode SelectNode = treeView_book.SelectedNode;
            if (SelectNode == null)
            {
                MessageBox.Show("Не выбрана тема, которую следует удалить", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                db.Delete_Node_From_Base(SelectNode);
                SelectNode.Remove();
            }
            treeView_book.SelectedNode = null;
            label1.Focus();
        }
        //добавление в корень
        private void AddTopicToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddRoot form = new AddRoot(imageList_Icon);
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                //создание объекта узла
                TreeNode topicRecord = new TreeNode() { Text = form.NameNode, ImageIndex = form.IndexIcon, SelectedImageIndex = form.IndexIcon, Tag = form.TagNode, Name = GenerationNumberNode(treeView_book) };
                //добавление узла в корень
                treeView_book.Nodes.Add(topicRecord);
                //добавление записи в базу
                if (topicRecord.Parent == null)
                {
                    db.Add_Node_in_Base(topicRecord.Name, topicRecord.Tag.ToString(), topicRecord.Text, topicRecord.Level, null);
                }
                else 
                {
                    db.Add_Node_in_Base(topicRecord.Name, topicRecord.Tag.ToString(), topicRecord.Text, topicRecord.Level, topicRecord.Parent.Name);
                }
                    

                treeView_book.SelectedNode = null;
                label1.Focus();//передаем фокус на неважный элемент, чтобы при повторном
            }
            form.Dispose();
        }

        private void button_add_record_Click(object sender, EventArgs e)
        {
            string textForm="";
            if (node.Tag.ToString() == "note")
            {
                textForm = "Создание новой заметки: \"";
            }
            else 
            {
                textForm = "Создание нового файла: \"";
            }
            NewRecord form = new NewRecord(textForm + node.Text + "\"", imageList_Icon.Images[node.SelectedImageIndex],"");
            DialogResult result = form.ShowDialog();
            if (result==DialogResult.OK)
            {
                richTextBox_info.ReadOnly = false;
                //отображение на форму добавленной записи
                string data= form.rtfCode;
                richTextBox_info.Rtf = data;
                //сохранение в базу добавленной записи
                db.Add_Record_In_Node(node.Name, form.rtfCode);
                richTextBox_info.ReadOnly = true;
                if (data != "")
                {
                    button_add_record.Enabled = false;
                    button_edit_record.Enabled = true;
                }
                else
                {
                    button_add_record.Enabled = true;
                    button_edit_record.Enabled = false;
                }

            }
            form.Dispose();
        }
        private void button_edit_record_Click(object sender, EventArgs e)
        {
            string textForm = "";
            if (node.Tag.ToString() == "note")
            {
                textForm = "Редактирование заметки: \"";
            }
            else
            {
                textForm = "Редактирование файла: \"";
            }
            
            NewRecord form = new NewRecord(textForm + node.Text + "\"", imageList_Icon.Images[node.SelectedImageIndex], db.GetDataFromNode(node.Name));
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                richTextBox_info.ReadOnly = false;
                //отображение на форму добавленной записи
                string data= form.rtfCode;
                richTextBox_info.Rtf = data;
                //сохранение в базу добавленной/редактированной записи
                db.Add_Record_In_Node(node.Name, form.rtfCode);
                richTextBox_info.ReadOnly = true;

                if (data != "")
                {
                    button_add_record.Enabled = false;
                    button_edit_record.Enabled = true;
                }
                else
                {
                    button_add_record.Enabled = true;
                    button_edit_record.Enabled = false;
                }
            }
            form.Dispose();
        }


        //переменные для перетаскивания
        private TreeNode NodeSelected;
        private TreeNode insertInNode;
        private void treeView_book_ItemDrag(object sender, ItemDragEventArgs e)
        {
            NodeSelected= (TreeNode)e.Item;
            // ЗАПУСКАЕМ перетаскивание
            DoDragDrop(NodeSelected, DragDropEffects.Move);
        }

        private void treeView_book_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;//разрешаем бросать объект на дерево
        }

        private void treeView_book_DragOver(object sender, DragEventArgs e)
        {
            //событие срабатывает, когда двигем мышь
            //логика здесь следующая: если я взял папку,
            //то ее можно ли в другую папку, либо в корень,
            //файлы и заметки можно либо в корень(они отдельно хранятся), либо в папку
            // если можно добавить в этот узел, то горит плюс, иначе горит запрет
            // считаем координаты курсора относительно дерева
            var CursorPosition = treeView_book.PointToClient(new Point(e.X, e.Y));
            //проверяем курсор над узлом ли
            TreeNode targetNode = treeView_book.GetNodeAt(CursorPosition);
            if (targetNode != null)//если мы вставляем у узел, надо понять, можно ли в этот узел вставлять
            {
                //первая проверка, не бросаем ли мы узел сам в себя
                if (targetNode == NodeSelected)//сравнения ссылок
                {
                    e.Effect = DragDropEffects.None;
                    return;
                }

                //вторая проверка
                //Совместимы ли типы узлов?

                //1.если у нас папка, то ее можно вставить только в папку
                if (NodeSelected.Tag.ToString() == "folder")
                {
                    if (targetNode.Tag.ToString() != NodeSelected.Tag.ToString())
                    {
                        e.Effect = DragDropEffects.None;
                        return;
                    }
                }
                //2.если у нас файл, то его можно вставить только в папку
                else if (NodeSelected.Tag.ToString() == "file")
                {
                    if (targetNode.Tag.ToString() != "folder")
                    {
                        e.Effect = DragDropEffects.None;
                        return;
                    }
                }
                //3.если у нас заметка, то его можно вставить только в папку
                else if (NodeSelected.Tag.ToString() == "note")
                {
                    if (targetNode.Tag.ToString() != "folder")
                    {
                        e.Effect = DragDropEffects.None;
                        return;
                    }
                }
                // третья проверка, не бросаем ли мы родителя в потомка
                //нужно проверить нет ли у searchNode среди предков узла targetNode
                TreeNode parent = targetNode.Parent;
                while (parent != null)
                {
                    if (parent == NodeSelected)//значит выбранный узел является предком и ставим запрет
                    {
                        e.Effect = DragDropEffects.None;
                        return;
                    }
                    parent = parent.Parent;
                }
                //прошли цепочку и не вышли, значит там не оказалось родителя и в этот узел можно вставить

                //если дошли до сюда, значит прошли все проверки
                e.Effect = DragDropEffects.Move;//разрешить перетаскивание, систему покажет плючик
                insertInNode = targetNode;//запомнили куда будем вставлять

            }
            else //если null, значит это пустое просранство и можно сюда вставить узел,пустое пространсво - все, что не узел
            {
                e.Effect = DragDropEffects.Move;//разрешить перетаскивание, систему покажет плючик
                insertInNode = null;//нет родителя, значит бросаем в корень
            }
        }


        //После удаления узла из старого места, переменная NodeSelected продолжает указывать на этот же узел
        //(он просто теперь не привязан к дереву). Вы можете его добавить в новое место — всё будет работать.
        private void treeView_book_DragDrop(object sender, DragEventArgs e)
        {
            if (NodeSelected == null)
            {
                return;
            }
            NodeSelected.Remove();
            if (insertInNode == null)
            {
                treeView_book.Nodes.Add(NodeSelected);
                db.EditPositionNode(NodeSelected.Name, null, NodeSelected.Level);
            }
            else
            {
                insertInNode.Nodes.Add(NodeSelected);
                db.EditPositionNode(NodeSelected.Name, insertInNode.Name, NodeSelected.Level);
                insertInNode.Expand();//разворачиваем нового родителя
            }
            NodeSelected=null;
            insertInNode = null;
        }

        private void richTextBox_info_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        

        private void button_clear_record_Click(object sender, EventArgs e)
        {
            richTextBox_info.Rtf = "";
            db.ClearRecord(node.Name);
            button_add_record.Enabled = true;
            button_edit_record.Enabled = false;
        }
        List<KeyValuePair<string, string>> search_node;
        private void button_search_Click(object sender, EventArgs e)
        {
            //считываем атрибуты поиска
            string name = textBox_nameRecordForSearch.Text == "" ? null : textBox_nameRecordForSearch.Text;
            string text = textBox_textRecordForSearch.Text == "" ? null : textBox_textRecordForSearch.Text;
            string websait= textBox_addressRecordForSearch.Text == "" ? null : textBox_addressRecordForSearch.Text;
            //если ничего не введено,то возвращаютсмя все узлы
            search_node = db.SearchRecord(name, text, websait);
            textBox_SearchCount.Text = search_node.Count.ToString();//отображаем количество найденных записей
            if(search_node.Count==0)
            {
                comboBox_record.Text = "Ничего не найдено";
                comboBox_record.Enabled=false;
                richTextBox_info.Rtf = "";
                node = null;
                textBox_nameRecord.Text = "";

            }
            else
            {
                comboBox_record.Enabled = true;
                comboBox_record.DataSource = search_node;
                comboBox_record.DisplayMember = "Value";
                comboBox_record.ValueMember = "Key";
                comboBox_record.SelectedIndex = 0;
            }
        }
        private void SearchNodeByNumber(TreeNode n, string number, ref TreeNode s_node)
        {
            if (n.Name == number)
            { 
                s_node= n;
            }
            for (int i = 0; i < n.Nodes.Count; i++)
            {
                SearchNodeByNumber(n.Nodes[i], number, ref s_node);
            }
        }
        private void comboBox_record_SelectedIndexChanged(object sender, EventArgs e)
        {
            //получаем номер выбранного узла
            var numberNode = (KeyValuePair<string,string>)comboBox_record.SelectedItem;
            //отображение выбранной записи
            //поиск узла по номеру
            TreeNode s_node = null;
            foreach (TreeNode tmp_node in treeView_book.Nodes)
            {
                SearchNodeByNumber(tmp_node, numberNode.Key, ref s_node);
                if (s_node != null)
                {
                    break;
                }
            }
            node = s_node;
            if (node.Tag.ToString() == "folder")
            { 
                treeView_book.SelectedNode = node;//выделяем узел
                node.Expand();//разворачиваем узел дерева
            }
            else//здесь выбор заметки или файла
            {
                textBox_nameRecord.Text = node.Text;
                richTextBox_info.ReadOnly = false;
                //считываем данные из файла на форму
                string data = db.GetDataFromNode(node.Name);
                richTextBox_info.Rtf = db.GetDataFromNode(node.Name);
                richTextBox_info.ReadOnly = true;
                if (data != "")
                {
                    button_add_record.Enabled = false;
                    button_edit_record.Enabled = true;
                }
                else
                {
                    button_add_record.Enabled = true;
                    button_edit_record.Enabled = false;
                }

            }
        }
    }
}
