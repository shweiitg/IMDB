using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Net;


namespace IMDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            


        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private string Final(string result)
        {
           //// var url = "http://www.imdb.com/find?ref_=nv_sr_fn&q=game+of+thrones&s=all";
            var textFromFile = (new WebClient()).DownloadString(result);
            string str = textFromFile.ToString();
            string searchfor = "<strong title=";
            int location = 0;//str.IndexOf(searchfor);
            string temp = null;
            while (location < str.Length - searchfor.Length - 10 && !string.Equals(str.Substring(location, searchfor.Length), searchfor))
                location++;
            if (string.Equals(str.Substring(location, searchfor.Length), searchfor))
            {
                location = location + searchfor.Length + 1;
                string va = str.Substring(location, 50);
                while (str[location] != '"')
                {
                    temp += str[location++];
                }
                return temp;
            }
            return temp;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str=null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = @"C:\";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                str = openFileDialog1.FileName;
            }
            //string temp = File.Path(str);
            string directoryPath = Path.GetDirectoryName(str);
            string[] FileName = Directory.GetFiles(directoryPath);
            string[] FolderName = Directory.GetDirectories(directoryPath);
            foreach(string F_name in FileName)
            {
                //string D_name = Path.GetFileName(F_name);
                //string Fname = getres(D_name);
                //dataGridView2.Rows.Add(D_name, Fname, null);
            }

            foreach (string F_name in FolderName)
            {
               
                string D_name=Path.GetFileName(F_name);
                string Fname = getres(D_name);
                dataGridView2.Rows.Add(D_name, Fname, null);
            }


        }

        public string getres(string full)
        {
            //string str= 
            //System.Diagnostics.Process.Start("http://google.com");
            // var url = "http://www.imdb.com/title/tt0944947/?ref_=fn_al_tt_1";
            full = full.Replace(' ', '+').Replace('\t', '+').Replace('\n','+').Replace('.', '+');
            //var url = "http://www.imdb.com/find?ref_=nv_sr_fn&q=game+of+thrones&s=all";
            var url = "http://www.imdb.com/find?ref_=nv_sr_fn&q=" + full + "&s=all";
            var textFromFile = (new WebClient()).DownloadString(url);
            string str = textFromFile.ToString();
            string searchfor = "<strong title=";
            int location = 0;//str.IndexOf(searchfor);
            string res = "http://www.imdb.com/";
            string temp = null;

            location = 0;
            string result = "<tr class";
            while (location < str.Length - result.Length - 10 && !string.Equals(str.Substring(location, result.Length), result))
                location++;
            string result1 = "<a href=";
            while (location < str.Length - result1.Length - 10 && !string.Equals(str.Substring(location, result1.Length), result1))
                location++;
            location = location + 1 + result1.Length;
            while (location < str.Length - result1.Length - 10 && str[location] != '"')
                temp += str[location++];
            if(temp!=null)
            temp=temp.Replace(' ', '+').Replace('\t', '+').Replace('\n', '+').Replace('.', '+');
            res += temp;
            if(temp == null)
                return null;
           return Final(res);
        }
    }
}
