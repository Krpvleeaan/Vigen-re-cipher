using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vizhenere
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != "Russian" && comboBox2.SelectedItem != "English" && comboBox1.SelectedItem != "Зашифровать" && comboBox1.SelectedItem != "Расшифровать")
            {
                richTextBox3.Text = "";
                MessageBox.Show("Выберите что нибудь");
            }
            if ((comboBox2.SelectedItem == "Russian" || comboBox2.SelectedItem == "English") && comboBox1.SelectedItem != "Зашифровать" && comboBox1.SelectedItem != "Расшифровать")
            {
                richTextBox3.Text = "";
                MessageBox.Show("Выберите , что нужно сделать с текстом");
            }
            if (comboBox2.SelectedItem != "Russian" && comboBox2.SelectedItem != "English" && (comboBox1.SelectedItem == "Зашифровать" || comboBox1.SelectedItem == "Расшифровать"))
            {
                richTextBox3.Text = "";
                MessageBox.Show("Выберите язык");
            }
            if (comboBox2.SelectedItem == "Russian" && comboBox1.SelectedItem == "Зашифровать")
            {
                if (Checker_For_Russian() == 1)
                {
                    richTextBox3.Text = "";
                    richTextBox3.AppendText(EncryptionRU());
                }
            }
            if (comboBox2.SelectedItem == "Russian" && comboBox1.SelectedItem == "Расшифровать")
            {
                if (Checker_For_Russian() == 1)
                {
                    richTextBox3.Text = "";
                    richTextBox3.AppendText(DecryptionRU());
                }
            }
            if (comboBox2.SelectedItem == "English" && comboBox1.SelectedItem == "Зашифровать")
            {
                if (Checker_For_English() == 1)
                {
                    richTextBox3.Text = "";
                    richTextBox3.AppendText(EncryptionENG());
                }
            }
            if (comboBox2.SelectedItem == "English" && comboBox1.SelectedItem == "Расшифровать")
            {
                if (Checker_For_English() == 1)
                {
                    richTextBox3.Text = "";
                    richTextBox3.AppendText(DecryptionENG());
                }
            }
        }
        public string Key_plus_ru(string original_text, string key)
        {
            string Alpha = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя0123456789";
            int check = 0;
            if (key == "")
                return (null);
            for (int i = 0; i < key.Length; i++)
            {
                for (int j = 0; j < Alpha.Length; j++)
                {
                    if (key[i] == Alpha[j])
                    {
                        check = 0;
                        break;
                    }
                    check = 1;
                }
                if (check == 1)
                    return (null);
            }
            int length = key.Length;
            if (original_text.Length > length)
                for (int i = 0; i < original_text.Length - length; i++)
                    key += key[i];
            return key;
        }
        public string Key_plus_eng(string original_text, string key)
        {
            string Alpha = "abcdefghijklmnopqrstuvwxyz0123456789";
            int check = 0;
            if (key == "")
                return (null);
            for (int i = 0; i < key.Length; i++)
            {
                for (int j = 0; j < Alpha.Length; j++)
                {
                    if (key[i] == Alpha[j])
                    {
                        check = 0;
                        break;
                    }
                    check = 1;
                }
                if (check == 1)
                    return (null);
            }
            int length = key.Length;
            if (original_text.Length > length)
                for (int i = 0; i < original_text.Length - length; i++)
                    key += key[i];
            return key;
        }
        public string EncryptionRU()
        {
            string FINAL = "";
            string ru_Alpha = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя0123456789";
            string original_text = richTextBox1.Text.ToLower();
            original_text = original_text.Replace(" ", "");
            string key = Key_plus_ru(original_text, richTextBox2.Text.ToLower());
            if (key == null)
            {
                MessageBox.Show("Неверный ключ");
                return ("");
            }    
            int[] arr = new int[original_text.Length];
            for (int i = 0; i < original_text.Length; i++)
            {
                for (int j = 0; j < ru_Alpha.Length; j++)
                {
                    if (ru_Alpha[j] == key[i])
                        arr[i] = j;
                }
            }
            for (int i = 0; i < original_text.Length; i++)
            {
                if (original_text[i] == ' ')
                    continue;
                for (int j = 0; j < ru_Alpha.Length; j++)
                {
                    if (ru_Alpha[j] == original_text[i])
                    {
                        FINAL += ru_Alpha[(ru_Alpha.Length + j + arr[i]) % 43];
                        break;
                    }
                }
            }
            return (FINAL);
        }
        public string DecryptionRU()
        {
            string FINAL = "";
            string ru_Alpha = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя0123456789";
            string original_text = richTextBox1.Text.ToLower();
            original_text = original_text.Replace(" ", "");
            string key = Key_plus_ru(original_text, richTextBox2.Text.ToLower());
            if (key == null)
            {
                MessageBox.Show("Неверный ключ");
                return ("");
            }
            int[] arr = new int[original_text.Length];
            for (int i = 0; i < original_text.Length; i++)
            {
                for (int j = 0; j < ru_Alpha.Length; j++)
                {
                    if (ru_Alpha[j] == key[i])
                        arr[i] = j;
                }
            }
            for (int i = 0; i < original_text.Length; i++)
            {
                if (original_text[i] == ' ')
                    continue;
                for (int j = 0; j < ru_Alpha.Length; j++)
                {
                    if (ru_Alpha[j] == original_text[i])
                    {
                        FINAL += ru_Alpha[(ru_Alpha.Length + j - arr[i]) % 43];
                        break;
                    }
                }
            }
            return (FINAL);
        }
        public string EncryptionENG()
        {
            string FINAL = "";
            string ru_Alpha = "abcdefghijklmnopqrstuvwxyz0123456789";
            string original_text = richTextBox1.Text.ToLower();
            original_text = original_text.Replace(" ", "");
            string key = Key_plus_eng(original_text, richTextBox2.Text.ToLower());
            if (key == null)
            {
                MessageBox.Show("Неверный ключ");
                return ("");
            }
            int[] arr = new int[original_text.Length];
            for (int i = 0; i < original_text.Length; i++)
            {
                for (int j = 0; j < ru_Alpha.Length; j++)
                {
                    if (ru_Alpha[j] == key[i])
                        arr[i] = j;
                }
            }
            for (int i = 0; i < original_text.Length; i++)
            {
                if (original_text[i] == ' ')
                    continue;
                for (int j = 0; j < ru_Alpha.Length; j++)
                {
                    if (ru_Alpha[j] == original_text[i])
                    {
                        FINAL += ru_Alpha[(ru_Alpha.Length + j + arr[i]) % 36];
                        break;
                    }
                }
            }
            return (FINAL);
        }
        public string DecryptionENG()
        {
            string FINAL = "";
            string ru_Alpha = "abcdefghijklmnopqrstuvwxyz0123456789";
            string original_text = richTextBox1.Text.ToLower();
            original_text = original_text.Replace(" ", "");
            string key = Key_plus_eng(original_text, richTextBox2.Text.ToLower());
            if (key == null)
            {
                MessageBox.Show("Неверный ключ");
                return ("");
            }
            int[] arr = new int[original_text.Length];
            for (int i = 0; i < original_text.Length; i++)
            {
                for (int j = 0; j < ru_Alpha.Length; j++)
                {
                    if (ru_Alpha[j] == key[i])
                        arr[i] = j;
                }
            }
            for (int i = 0; i < original_text.Length; i++)
            {
                if (original_text[i] == ' ')
                    continue;
                for (int j = 0; j < ru_Alpha.Length; j++)
                {
                    if (ru_Alpha[j] == original_text[i])
                    {
                        FINAL += ru_Alpha[(ru_Alpha.Length + j - arr[i]) % 36];
                        break;
                    }
                }
            }
            return (FINAL);
        }
        public int Checker_For_Russian()
        {
            string text = richTextBox1.Text;
            if (text == "")
            {
                MessageBox.Show("Вы не ввели текст");
                return (0);
            }
            string ru_Alpha = " абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ0123456789";
            for (int i = 0; i < text.Length; i++)
            {
                int checker = 0;
                for (int j = 0; j < ru_Alpha.Length; j++)
                {
                    if (text[i] == ru_Alpha[j])
                        checker = 1;
                }
                if (checker == 0)
                {
                    MessageBox.Show("Вы ввели некорректные символы в тексте");
                    return (0);
                }
            }
            return (1);
        }
        public int Checker_For_English()
        {
            string text = richTextBox1.Text;
            string eng_Alpha = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            if (text == "")
            {
                MessageBox.Show("Вы не ввели текст");
                return (0);
            }
            for (int i = 0; i < text.Length; i++)
            {
                int checker = 0;
                for (int j = 0; j < eng_Alpha.Length; j++)
                {
                    if (text[i] == eng_Alpha[j])
                        checker = 1;
                }
                if (checker == 0)
                {
                    MessageBox.Show("Вы ввели некорректные символы в тексте");
                    return (0);
                }
            }
            return (1);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
