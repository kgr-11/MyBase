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
    public partial class NewRecord : Form
    {
        // Метод преобразования из Image в Icon- это Deepseak
        private Icon ConvertImageToIcon(Image image)
        {
            using (Bitmap bitmap = new Bitmap(image))
            {
                IntPtr hIcon = bitmap.GetHicon();
                Icon icon = (Icon)Icon.FromHandle(hIcon).Clone();
                return icon;
            }
        }
        public NewRecord(string NameFrom,Image Icon,string RtfCode)
        {
            InitializeComponent();
            Text = NameFrom;
            this.Icon = ConvertImageToIcon(Icon);
            richTextBox_record.DetectUrls = true;
            richTextBox_record.Rtf=RtfCode;
        }
        //загрузка изображения
        private bool LoadImage(out Image photo)
        {
            //загрузка изображения
            // Создаём диалог выбора файла
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Настройки диалога
            openFileDialog.Title = "Выберите изображение";
            openFileDialog.Filter = "Изображения|*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.ico|Все файлы|*.*";
            openFileDialog.FilterIndex = 1;

            DialogResult res = openFileDialog.ShowDialog();
            bool flag = false;
            photo = new Bitmap(800, 600);//пустое изображение 
            // Показываем диалог и проверяем, что пользователь выбрал файл
            if (res == DialogResult.OK)
            {
                // Загружаем изображение из выбранного файла
                photo = Image.FromFile(openFileDialog.FileName);
                flag = true;
            }
            return flag;
        }

        private void button_add_image_Click(object sender, EventArgs e)
        {
            //загрузка изображения

            if (LoadImage(out Image image))
            {
                // Вычисляем новые размеры с сохранением пропорций
                float ratio = Math.Min((float)richTextBox_record.Size.Width / image.Width, (float)richTextBox_record.Size.Height / image.Height);
                int newWidth = (int)(image.Width * ratio);
                int newHeight = (int)(image.Height * ratio);

                Bitmap resized = new Bitmap(newWidth, newHeight);
                using (Graphics g = Graphics.FromImage(resized))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(image, 0, 0, newWidth, newHeight);
                }

                Clipboard.SetImage(resized);

                //выгрузка изображения на форму
                richTextBox_record.Paste();
                richTextBox_record.AppendText(Environment.NewLine);
                Clipboard.Clear();

                resized.Dispose();
            }
            
        }
        private void button_add_giperRef_Click(object sender, EventArgs e)
        {
            AddRef form = new AddRef();
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                //добавление текста в RichTextBox
                if (!form.Ref.StartsWith("http://") && !form.Ref.StartsWith("https://"))
                {
                    richTextBox_record.AppendText("https://" + form.Ref+Environment.NewLine);
                }
                else
                {
                    richTextBox_record.AppendText(form.Ref+ Environment.NewLine);
                }
            }
            form.Dispose();
        }

        //обработчик нажатия на ссылку
        private void richTextBox_record_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
        //public string file_name;
        public string rtfCode;
        private void button_saveRecord_Click(object sender, EventArgs e)
        {
            rtfCode = richTextBox_record.Rtf;
            DialogResult= DialogResult.OK;
            Close();
        }
    }
}
