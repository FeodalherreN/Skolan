using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoutubeDownloader
{
    public partial class Form1 : Form
    {
        private Search search;
        private SnippetResult snippet;
        private Download download;
        public Form1()
        {
            InitializeComponent();
            search = new Search();
            snippet = new SnippetResult();
            download = new Download();
            this.AcceptButton = btnSearch;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            listResult.Items.Clear();
            snippet = search.searchForVideo(txtSearch.Text);
            lblNrOfResults.Text = snippet.pageInfo.totalResults.ToString() + " results";
            foreach (Item snip in snippet.items)
            {
                listResult.Items.Add(snip.snippet.title);
            }
        }

        private void listResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (snippet != null)
            {
                foreach (Item snip in snippet.items)
                {
                    if(snip.snippet.title == listResult.SelectedItem.ToString())
                    {
                        picThumb.Load(snip.snippet.thumbnails.defaultt.url);
                    }
                }
            }
        }

        private void BtnDownload_Click(object sender, EventArgs e)
        {
            if (snippet != null)
            {
                foreach (Item snip in snippet.items)
                {
                    if (snip.snippet.title == listResult.SelectedItem.ToString())
                    {
                        download.start(snip.id.videoId);
                    }
                }
            }
        }
    }
}
