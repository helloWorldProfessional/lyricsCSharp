using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace CsharpLyrics
{
    public partial class Lyrics : Form
    {
        public Lyrics()
        {
            InitializeComponent();
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            string artistName = ArtistTextBox.Text;
            string songTitle = SongTextBox.Text;
            if (artistName == "" || songTitle == "")
                MessageBox.Show("Unesite oba polja!");
            else {
                try
                {
                    string apiUrl = String.Format("https://api.lyrics.ovh/v1/" + artistName + "/" + songTitle);
                    WebClient client = new WebClient();
                    string jResponse = client.DownloadString(apiUrl);
                    dynamic dobj = JsonConvert.DeserializeObject<dynamic>(jResponse);
                    string lyrics = dobj["lyrics"].ToString();
                    label4.Text = lyrics;
                    label4.Visible=true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Traženi tekst nije pronađen");
                }
            }
        }
    }
}
