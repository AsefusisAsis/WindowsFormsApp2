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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
    
namespace WindowsFormsApp2
{
   
    public partial class AddForm : Form

    {
        int count =3;
        string path = @"DataFiles\file.txt";

        ////string pattern = @"[A-Z]{2}[0-9]{7}";
        person[] Clients = new person[100];

        BinaryFormatter format = new BinaryFormatter();
        public AddForm()
        {
            InitializeComponent();
           
            //FileInfo info = new FileInfo(path);
            Clients[0] = new person();
            Clients[1] = new person(3, "Robert Radriges", "A212", "AB7654321", (status)2, 2500);
            Clients[2] = new person(Clients[0]);
            count = Vivcount(path);
            Viv(path, count);
        }
        public string outcount
        {
            get {return label1.Text; }
            set {label1.Text=value; }
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
        private void Label3_MouseEnter(object sender, EventArgs e)
        {
            label3.Image = Resource1.Button_target;
        }

        private void Label3_MouseLeave(object sender, EventArgs e)
        {
            label3.Image = Resource1.Button_nontarget;
        }

        private void Label19_MouseEnter(object sender, EventArgs e)
        {
            label19.Image = Resource1.Button_target;
        }

        private void Label19_MouseLeave(object sender, EventArgs e)
        {
            label19.Image = Resource1.Button_nontarget;
        }
        private void AddPerson()
        {

            Clients[count] = new person();
            Clients[count].ID = count + 1;
            Clients[count].name = Add_name.Text;
            Clients[count].room = Add_room.Text;
            Clients[count].pasp = Add_pasp.Text;
            Clients[count].state = (status)Convert.ToInt32(Add_state.Text);
            Clients[count].Sum = Convert.ToDecimal(Add_sum.Text);
            count++;
            LCount = Convert.ToString(count);
            

        }

        private void AddForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            
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

        private void Label3_Click(object sender, EventArgs e)
        {
            AddPerson();
            richTextBox1.Text += ("ID клиента:" + Clients[count-1].ID + "\n"
                             + "ФИО клиента:" + Clients[count-1].name + "\n"
                             + "Номер комнаты:" + Clients[count-1].room + "\n"
                             + "Паспортные данные клиента:" + Clients[count-1].pasp + "\n"
                             + "Статус клиента:" + Clients[count-1].state + "\n"
                             + "Внесенная сумма:" + Clients[count-1].Sum);

            
        }

        private void Label19_Click(object sender, EventArgs e)
        {
            Zap(path, Clients, count);
            this.Close();
        }
        public string LCount
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
    }
}
