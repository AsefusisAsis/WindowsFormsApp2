using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonLibrary;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace WindowsFormsApp2
{
    public partial class Remove : Form
    {
        int count ;
        string path = @"DataFiles\file.txt";

        ////string pattern = @"[A-Z]{2}[0-9]{7}";
        person[] Clients = new person[100];

        BinaryFormatter format = new BinaryFormatter();
        public Remove()
        {
            InitializeComponent();
            
            //FileInfo info = new FileInfo(path);
            Clients[0] = new person();
            Clients[1] = new person(3, "Robert Radriges", "A212", "AB7654321", (status)2, 2500);
            Clients[2] = new person(Clients[0]);
            count=Vivcount(path);
            
               
           
            
        }
        
        
        private void Remove_Load(object sender, EventArgs e)
        {
            
        }

        private void Label2_MouseEnter(object sender, EventArgs e)
        {
            label2.Image = Resource1.Button_target;
        }

        private void Label4_MouseEnter(object sender, EventArgs e)
        {
            label4.Image = Resource1.Button_target;
        }

        private void Label5_MouseEnter(object sender, EventArgs e)
        {
            label5.Image = Resource1.Button_target;
        }

        private void Label1_MouseEnter(object sender, EventArgs e)
        {
            label1.Image = Resource1.Button_target;
        }

        private void Label11_MouseEnter(object sender, EventArgs e)
        {
            label11.Image = Resource1.Button_target;
        }

        private void Label2_MouseLeave(object sender, EventArgs e)
        {
            label2.Image = Resource1.Button_nontarget;
        }

        private void Label4_MouseLeave(object sender, EventArgs e)
        {
            label4.Image = Resource1.Button_nontarget;
        }

        private void Label5_MouseLeave(object sender, EventArgs e)
        {
            label5.Image = Resource1.Button_nontarget;
        }

        private void Label1_MouseLeave(object sender, EventArgs e)
        {
            label1.Image = Resource1.Button_nontarget;
        }

        private void Label11_MouseLeave(object sender, EventArgs e)
        {
            label11.Image = Resource1.Button_nontarget;
        }

        private void Label2_Click(object sender, EventArgs e)

        {Viv(path,count);
            searchvis(Clients, count);
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
                }
                richTextBox1.Text += "\r\n";
            }
            if (count1 == 0)
            {
                MessageBox.Show("Таких записей нет, повторите попытку...");
                richTextBox1.Text = ("Таких записей нет...");
            }
        }
        
        private void searchvis(person[] people, int count)//третья кнопка
        {
            richTextBox1.Text = null;
            int count1 = 0;
            richTextBox1.Text += "Вывод выселяющихся...";
            for (int i = 0; i < count; i++)
            {
                if (people[i].state == (status)3)
                {
                    count1 += 1;
                    //Console.WriteLine("По паспортным данным...");
                    richTextBox1.Text += ("\n\n" + "ID клиента:" + Clients[i].ID + "\n"
                                 + "ФИО клиента:" + Clients[i].name + "\n"
                                 + "Номер комнаты:" + Clients[i].room + "\n"
                                 + "Паспортные данные клиента:" + Clients[i].pasp + "\n"
                                 + "Статус клиента:" + Clients[i].state + "\n"
                                 + "Внесенная сумма:" + Clients[i].Sum);
                }
                richTextBox1.Text += "\r\n";
            }
            if (count1 == 0)
            {
                MessageBox.Show("Таких записей нет, повторите попытку...");
                richTextBox1.Text = ("Таких записей нет...");
            }
        }


        public Int32 Vivcount(string path)
        {
            int count1 = 0;
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
            {


                while(reader.PeekChar()>=0)
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
            }return count1;
        }
        public void Viv(string path, int count)
        {
            
            
            int count1 = 0;

            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
            {
               

                        for (int i = 0; i < count; i++)
                        {



                            Clients[i] = new person();
                            Clients[i].ID = reader.ReadInt32();
                            Clients[i].name = reader.ReadString();
                            Clients[i].pasp = reader.ReadString();
                            Clients[i].room = reader.ReadString();

                            Clients[i].state = (status)reader.ReadInt32();
                            Clients[i].Sum = reader.ReadDecimal();

                            count1++;
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

       
        private void SearchState(person[] people, int count, string str)
        {

            richTextBox1.Text = null;

            int count1 = 0;
            richTextBox1.Text += "Вывод информации о жильцах комнаты..." + "\n\n";
            for (int i = 0; i < count; i++)
            {

                if ((people[i].room == str))
                {

                    count1 += 1;
                    //Console.WriteLine("По паспортным данным...");
                    richTextBox1.Text += (
                                 "ФИО клиента:" + Clients[i].name + "\n"
                                 + "Статус клиента:" + Clients[i].state
                                 );

                }
                richTextBox1.Text += "\r\n";
            }

            if (count1 == 0)
            {

                richTextBox1.Text = ("В комнате нет постояльцев...");
            }

        }
        private void InfoPass(person[] people, int count, string pasport)
        {
            richTextBox1.Text = null;
            textBox1.Text = null;
            int count1 = 0;
            for (int i = 0; i < count; i++)
            {
                if ((people[i].pasp == pasport))
                {

                    count1 += 1;
                    //Console.WriteLine("По паспортным данным...");
                    richTextBox1.Text += (
                                  "ФИО клиента:" + Clients[i].name + "\n"
                                 + "Номер комнаты:" + Clients[i].room + "\n"
                                 );

                }
                if (count1 == 0)
                {
                    richTextBox1.Text = "Таких постояльцев нет...";
                }
                richTextBox1.Text += "\r\n";
            }

        }
        private void writeall(person[] people, int count)
        {
            richTextBox1.Text = null;
            textBox1.Text = null;
            int count1 = 0;
            for (int i = 0; i < count; i++)
            {
               
                {
                    //Вывод всего
                    richTextBox1.Text += ("Вывод из файла" + "\n\r" + "ID клиента:" + Clients[i].ID + "\n"
                                                        + "ФИО клиента:" + Clients[i].name + "\n"
                                                        + "Номер комнаты:" + Clients[i].room + "\n"
                                                        + "Паспортные данные клиента:" + Clients[i].pasp + "\n"
                                                        + "Статус клиента:" + Clients[i].state + "\n"
                                                        + "Внесенная сумма:" + Clients[i].Sum + "\n");

                    count1 += 1;

                }
                if (count1 == 0)
                {
                    richTextBox1.Text = "Таких постояльцев нет...";
                }
                richTextBox1.Text += "\r\n";
            }

        }
        private void Label4_Click(object sender, EventArgs e)
        {
            Viv(path, count);
            SearchState(Clients,count,textBox1.Text);
        }

        private void Label5_Click(object sender, EventArgs e)
        {
            Viv(path, count);
            InfoPass(Clients,count,textBox1.Text);
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            Viv(path,count);
           writeall (Clients,count);
        }

        private void Label11_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
   
}
