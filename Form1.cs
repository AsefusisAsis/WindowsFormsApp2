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
    public partial class Form1 : Form
    {
        
        int count = 3;
        string path = @"DataFiles\file.txt";

        ////string pattern = @"[A-Z]{2}[0-9]{7}";
        person[] Clients = new person[100];

        BinaryFormatter format = new BinaryFormatter();
        
        public Form1()
        {
            InitializeComponent();
            
            
            count = Viv(path, count);
            
            

        }
        
        private void MenuItem1_Click(object sender, EventArgs e)
        {
            Remove newMDIChild = new Remove();


        newMDIChild.MdiParent = this;
            newMDIChild.Show();
            
            
            
        }

        private void MenuItem12_Click(object sender, EventArgs e)
        {
            Change newMDIChild = new Change();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();

        }

        private void MenuItem8_Click(object sender, EventArgs e)
        {
            
        }

        private void MenuItem9_Click(object sender, EventArgs e)
        {
            if (MdiChildren.Count() > 0)
            {
                do
                {
                    MdiChildren[0].Close();
                } while (MdiChildren.Count() > 0);
            }

        }

        private void MenuItem11_Click(object sender, EventArgs e)
        {
            AddForm newMDIChild = new AddForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
            
        }
        public Int32 Viv(string path, int count)
        {
           
            
            int count1 = 0;

            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
            {
               
                
                for(int i=0;i<count;i++)
                {

                    
                    
                    Clients[i]=new person();
                    Clients[i].ID = reader.ReadInt32();
                    Clients[i].name = reader.ReadString();
                    Clients[i].pasp = reader.ReadString();
                    Clients[i].room = reader.ReadString();
                    
                    Clients[i].state = (status)reader.ReadInt32();
                    Clients[i].Sum = reader.ReadDecimal();
                   
                    count1++;

                }

                reader.Close();
                
                return count1;
                
            }

        }

        private void MenuItem7_Click(object sender, EventArgs e)
        {
            Viv(path, count);
            MessageBox.Show("File was readed...");
        }
    }
}
