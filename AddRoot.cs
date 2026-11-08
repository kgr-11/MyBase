using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBaseOnCSharp
{
    public partial class AddRoot : Form
    {
        private ImageList imageList_Icon;
        public AddRoot(ImageList imageList_Icon)
        {
            InitializeComponent();
            this.imageList_Icon = imageList_Icon;   
            comboBox_nameIcon.SelectedIndex = 0;
        }

        private string nameNode;
        public string NameNode
        {
            get { return nameNode; }
            set { this.nameNode = value; }
        }
        private int icon_index;
        public int IndexIcon
        {
            get { return icon_index; }
            set { this.icon_index = value; }
        }
        private string tagNode;
        public string TagNode
        {
            get { return tagNode; }
            set { this.tagNode = value; }
        }
        private void button_add_Click(object sender, EventArgs e)
        {
            //считываем итоговое название темы
            NameNode = textBox_nameNode.Text;
            //считываем итоговую иконку
            int index = comboBox_nameIcon.SelectedIndex;
            IndexIcon=index;
            if (comboBox_nameIcon.SelectedIndex == 0)
            {
                TagNode = "folder";
            }
            else if (comboBox_nameIcon.SelectedIndex == 1)
            {
                TagNode = "file";
            }
            else if (comboBox_nameIcon.SelectedIndex == 2)
            {
                TagNode = "note";
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void comboBox_nameIcon_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox_nameIcon.SelectedIndex;
            pictureBox_Icon.Image = imageList_Icon.Images[index];
            pictureBox_Icon.SizeMode = PictureBoxSizeMode.Zoom;//растягиваем иконку на весь элемент
        }
    }
}
