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
    public partial class AddRef : Form
    {
        public AddRef()
        {
            InitializeComponent();
        }

        
        private string reference;
        public string Ref
        {
            get { return reference; }
        }
        private void button_add_Click(object sender, EventArgs e)
        {
            reference = textBox_ref.Text;
            DialogResult=DialogResult.OK;
            Close();
        }
    }
}
