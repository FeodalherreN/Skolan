//Markus Olsson, AB7158
//Concurrent Programming, Assignment 3
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Assignmentt3
{
    public partial class Form1 : Form
    {
        private Thread ThreadWriter; //A thread that is used by the writer class.
        private Thread ThreadReader; //A thread that is used by the reader class.
        private Thread ThreadModifier; //A thread that is used by the modifier class.

        private CircleBuffer buffer; //A buffer that is going to be instansiated and sent to the three other classes.
        private Writer writer; //A writer
        private Reader reader; //A reader
        private Modifier modifier; //A modifier.

        RichTextBox txtSource; //The Richtextbox Source.
        RichTextBox txtDestination; //The Richtextbox Destionation.

        private string ivFind; //string to hold the users find input.
        private string ivReplace; //string to hold the users replace input.
        private string word; //This string is used for the searchmethod. 

        private int ivNrOfStrings; //Number of strings in the sourcebox.

        private bool notify; //Bool used if the user wants to get notified or not.

        List<string> Stringlist; //The list of strings in the source textbox.

        public Form1()
        {
            InitializeComponent();
            tabBox.SelectedIndexChanged += tabBox_SelectedIndexChanged;
            FormClosing += Form1_FormClosing;
            txtFind.TextChanged += txtFind_TextChanged;
            InitializeGUI();
        }
        /// <summary>
        /// Event triggered if the text changes in the text find textbox. The event searches for matches using "SearchKeyword" method.
        /// </summary>
        void txtFind_TextChanged(object sender, EventArgs e)
        {
            txtSource.SelectAll();
            txtSource.SelectionBackColor = Color.White;
            if(Stringlist != null && txtFind.Text != "")
            {
                word = txtFind.Text;
                this.SearchKeyword(word, Color.Tomato);
            }
        }
        /// <summary>
        /// This method checks with regex if there is a match between the Find textbox and the richtextbox called Source.
        /// </summary>
        /// <param name="word"></param>
        /// <param name="color"></param>
        private void SearchKeyword(string word, Color color)
        {
                Regex reg = new Regex(word, RegexOptions.IgnoreCase);
                foreach (Match find in reg.Matches(txtSource.Text))
                {
                    this.txtSource.Select(find.Index, find.Length);
                    this.txtSource.SelectionBackColor = color;
                }
        }
        /// <summary>
        /// Instansiates the classes.
        /// </summary>
        private void InstansiateClasses()
        {
            buffer = new CircleBuffer(ivNrOfStrings, notify, ivFind, ivReplace);
            buffer.NotifyUser = CBNotify.Checked;
            reader = new Reader(buffer, ivNrOfStrings, txtDestination, txtSource);
            writer = new Writer(buffer, Stringlist);
            modifier = new Modifier(buffer, ivNrOfStrings, ivFind, ivReplace, lblChangesMade);
        }
        /// <summary>
        /// Validates the input from user.
        /// </summary>
        private bool ValidateInput()
        {
            if (txtSource.Text == "")
            {
                MessageBox.Show("There is nothing to process.");
                return false;
            }
            if(txtFind.Text == txtReplace.Text)
            {
                MessageBox.Show("Find and replace strings are identical, no need to replace.");
                return false;
            }
            ivFind = txtFind.Text.ToString();
            ivReplace = txtReplace.Text.ToString();
            return true;
        }

        /// <summary>
        /// Instansiates and starts the threads.
        /// </summary>
        private void CreateAndStartThreads()
        {
            ThreadWriter = new Thread(writer.Write);
            ThreadReader = new Thread(reader.Read);
            ThreadModifier = new Thread(modifier.Modify);
            ThreadWriter.Start();
            ThreadReader.Start();
            ThreadModifier.Start();
        }

        /// <summary>
        /// Clears the GUI.
        /// </summary>
        private void ClearGUI()
        {
            txtFind.Text = ""; //Findtextbox gets cleared.
            txtReplace.Text = ""; //ReplaceTextBox gets cleared.
        }

        /// <summary>
        /// Initializes the Graphical user interface.
        /// </summary>
        private void InitializeGUI()
        {
            BtnClearDest.Enabled = false; //BtnClearDest börjar vara avstängd.
            BtnClearDest.Visible = false; //BtnClearDest börjar vara osynlig.
            txtSource = new RichTextBox(); //RTB for the sourceTab.
            txtDestination = new RichTextBox(); //RTB for the DestinationTab.
            txtSource.Width = tabPage1.Width; //Sets the sourceRTBs width to the width of the Tab.
            txtSource.Height = tabPage1.Height; //Sets the sourceRTBs height to the height of the Tab.
            txtDestination.Width = tabPage2.Width; //Sets the DestinationRTBs width to the width of the Tab.
            txtDestination.Height = tabPage2.Height; //Sets the DestinationRTBs height to the height of the Tab.
            tabPage1.Text = "Source"; //Sets the name of the first tab to "Source".
            tabPage2.Text = "Destination"; //Sets the name of the second tab to "Destination."
            tabPage1.Controls.Add(txtSource); //Adds the RTB controller to tab.
            tabPage2.Controls.Add(txtDestination); //Adds the RTB controller to tab.
        }

        /// <summary>
        /// This eventhandler executes when open is selected. The user choses a txt file,
        /// it then gets written to the RichTextBox called "Source".
        /// </summary>
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog(); //Creates a new filedialog.
            ofd.Title = "Find file"; //Sets the title of the filedialog to "Find File"
            ofd.Filter = "Text Files|*.txt"; //Only excepts txt files.
            DialogResult result = ofd.ShowDialog(); // Show the dialog.
            if(result == DialogResult.OK) //checks if OK pressed.
            {
                try
                {
                    txtSource.LoadFile(ofd.FileName, RichTextBoxStreamType.PlainText); //Writes the text from file to the rich textbox.
                    Stringlist = new List<string>();
                    foreach (string word in txtSource.Lines)
                    {
                        Stringlist.Add(word);
                    }
                    ivNrOfStrings = Stringlist.Count;
                }
                catch (IOException)
                {
                    MessageBox.Show("Something went wrong.");
                }
            }
        }
        /// <summary>
        /// Event that handles when selectedindex of the tabs changes. 
        /// </summary>
        private void tabBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabBox.SelectedTab == tabPage1)//Om source är vald så ska inte BtnClearDest visas.
            {
                BtnClearDest.Enabled = false;
                BtnClearDest.Visible = false;
            }
            if (tabBox.SelectedTab == tabPage2)//Om destination är vald så ska BtnClearDest visas.
            {
                BtnClearDest.Enabled = true;
                BtnClearDest.Visible = true;
            }
        }
        /// <summary>
        /// Event that handles Createdest button. Confirmates the changes with the user...
        /// </summary>
        private void btnCreateDestFile_Click(object sender, EventArgs e)
        {
            if(ValidateInput())
            {
                if (ivReplace != "")
                {
                    DialogResult dialogResult = MessageBox.Show("Replace " + ivFind + " with " + ivReplace + "?", "Replace", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        ClearGUI();
                        InstansiateClasses();
                        CreateAndStartThreads();
                        tabBox.SelectedTab = tabPage2;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //Do nothing :D
                    }
                }
                else
                {
                        ClearGUI();
                        InstansiateClasses();
                        CreateAndStartThreads();
                        tabBox.SelectedTab = tabPage2;
                }
            }
        }
        /// <summary>
        /// Aborts all threads on close.
        /// </summary>
        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ThreadWriter != null)
                ThreadWriter.Abort();
            if (ThreadReader != null)
                ThreadReader.Abort();
            if (ThreadModifier != null)
                ThreadModifier.Abort();
        }
        /// <summary>
        /// This event fires when a user clicks the clearbutton. It clears the text in the form and sets the notify to unchecked.
        /// </summary>
        private void BtnClearDest_Click(object sender, EventArgs e)
        {
            txtDestination.Text = "";
            CBNotify.Checked = false;
            if(buffer != null)
            {
                buffer.NotifyUser = false;
            }
        }
    }
}
