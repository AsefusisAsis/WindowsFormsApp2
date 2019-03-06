using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonLibrary;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsFormsApp2
{
    public partial class Change : Form
    {
        int count = 3;
        person[] Clients = new person[100];
        BinaryFormatter format = new BinaryFormatter();
        string path = @"DataFiles\file.txt";
        public Change()
        {
            InitializeComponent();
            
            //FileInfo info = new FileInfo(path);
            Clients[0] = new person();
            Clients[1] = new person(3, "Robert Radriges", "A212", "AB7654321", (status)2, 2500);
            Clients[2] = new person(Clients[0]);
            count = Vivcount(path);
            Viv(path, count);
        }
        public Int32 Vivcount(string path)
        {
            int count1 = 0;
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
            {


                while (reader.PeekChar() >= 0)
                {




                    reader.ReadInt32();
                    reader.ReadString();
                    reader.ReadString();
                    reader.ReadString();
                    reader.ReadInt32();
                    reader.ReadDecimal();

                    count1++;
                }




                reader.Close();
            }
            return count1;
        }
        private void Label6_MouseEnter(object sender, EventArgs e)
        {
            label6.Image = Resource1.Button_target;
        }

        private void Label6_MouseLeave(object sender, EventArgs e)
        {
            label6.Image = Resource1.Button_nontarget;
        }

        private void Label11_MouseEnter(object sender, EventArgs e)
        {
            label11.Image = Resource1.Button_target;
        }

        private void Label11_MouseLeave(object sender, EventArgs e)
        {
            label11.Image = Resource1.Button_nontarget;
        }

        private void Label6_Click(object sender, EventArgs e)
        {
            ChangeState(textBox2.Text, Clients, count, textBox1.Text);
            textBox1.Enabled = true;
            
        }
        private person[] ChangeState(string str, person[] people, int count, string pasport)
        {
            richTextBox1.Text = null;
            int count1 = 0;
            for (int i = 0; i < count; i++)
            {
                if ((people[i].state != (status)Convert.ToInt32(str)) && (people[i].pasp == pasport))
                {
                    people[i].state = (status)Convert.ToInt32(str);
                    count1 += 1;
                    //Console.WriteLine("По паспортным данным...");
                    richTextBox1.Text += ("ID клиента:" + Clients[i].ID + "\n"
                                 + "ФИО клиента:" + Clients[i].name + "\n"
                                 + "Номер комнаты:" + Clients[i].room + "\n"
                                 + "Паспортные данные клиента:" + Clients[i].pasp + "\n"
                                 + "Статус клиента:" + Clients[i].state + "\n"
                                 + "Внесенная сумма:" + Clients[i].Sum);
                    textBox2.Enabled = false;

                }
                richTextBox1.Text += "\r\n";
            }
            richTextBox1.Text += "Статус изменен.";
            if (count1 == 0)
            {

                richTextBox1.Text = ("Статус остался прежним...");
            }
            return people;
        }

        private void Change_Load(object sender, EventArgs e)
        {

        }

        private void Change_FormClosing(object sender, FormClosingEventArgs e)
        {
            Zap(path,Clients,count);
        }
        public void Viv(string path, int count)
        {
            int int1;


            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                for (int i = 0; i < count; i++)
                {


                    int1 = 0;
                    Clients[i] = new person();
                    Clients[i].ID = reader.ReadInt32();
                    Clients[i].name = reader.ReadString();
                    Clients[i].pasp = reader.ReadString();
                    Clients[i].room = reader.ReadString();
                    int1 = reader.ReadInt32();
                    Clients[i].state = (status)int1;
                    Clients[i].Sum = reader.ReadDecimal();
                    richTextBox1.Text += ("Вывод из файла" + "\n\r" + "ID клиента:" + Clients[i].ID + "\n"
                                                        + "ФИО клиента:" + Clients[i].name + "\n"
                                                        + "Номер комнаты:" + Clients[i].room + "\n"
                                                        + "Паспортные данные клиента:" + Clients[i].pasp + "\n"
                                                        + "Статус клиента:" + Clients[i].state + "\n"
                                                        + "Внесенная сумма:" + Clients[i].Sum);


                }
                reader.Close();

            }
        }
        private void Zap(string path, person[] people, int count)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {

                for (int i = 0; i < count; i++)
                {
                    writer.Write(people[i].ID);
                    writer.Write(people[i].name);
                    writer.Write(people[i].pasp);
                    writer.Write(people[i].room);
                    writer.Write(Convert.ToInt32(people[i].state));
                    writer.Write(people[i].Sum);
                }
                writer.Close();

                //MessageBox.Show("Выгрузка завершена...");
            }
        }
        private void pass(string str, person[] people, int count)//ссылка на обьект не указывает на экземпляр обьекта
        {
            richTextBox1.Text = null;
            int count1 = 0;
            for (int i = 0; i < count; i++)
            {
                if (people[i].pasp == str)
                {
                    count1 += 1;
                    //Console.WriteLine("По паспортным данным...");
                    richTextBox1.Text += ("ID клиента:" + Clients[i].ID + "\n"
                                 + "ФИО клиента:" + Clients[i].name + "\n"
                                 + "Номер комнаты:" + Clients[i].room + "\n"
                                 + "Паспортные данные клиента:" + Clients[i].pasp + "\n"
                                 + "Статус клиента:" + Clients[i].state + "\n"
                                 + "Внесенная сумма:" + Clients[i].Sum);
                    textBox1.Enabled = false;
                    textBox2.Enabled = true;
                }
                richTextBox1.Text += "\r\n";
                
            }
            if (count1 == 0)
            {
                
                MessageBox.Show("Таких записей нет, повторите попытку...");
                richTextBox1.Text = ("Таких записей нет...");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            pass(textBox1.Text,Clients,count);
            
        }

        private void Label11_Click(object sender, EventArgs e)
        {
            Zap(path,Clients,count);
            this.Close();
        }
        public string LCount
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
    }
}
