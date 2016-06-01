using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;

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
            //string str= 
                //System.Diagnostics.Process.Start("http://google.com");
            var url = "http://www.imdb.com/title/tt0944947/?ref_=fn_al_tt_1";
            var textFromFile = (new WebClient()).DownloadString(url);
            string str = textFromFile.ToString();
            int location = str.IndexOf("<strong title=");
            string temp=null;
            if(location>0)
            {
                location++;
                while(str[location]!='"')
                {
                    temp += str[location++];
                }
            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
