//Markus Olsson, AB7158
//Concurrent programming

using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class Form1 : Form
    {
        private Reader reader;
        private Writer writer;
        private CharacterBuffer bf;
        private Status status;
        private Random rand;
        private Thread writerThread;
        private Thread readerThread;
        private Thread statusThread;
        private string textData; //sträng för att hålla den angivna texten i programmet.

        public Form1()
        {
            InitializeComponent();
            pbResult.BackColor = Color.Silver; //Sätter pictureboxens färg till silver.
            rand = new Random(); //Ny instans av random.
            btnSync.Checked = true; //markerar syncronized som checked i början.
            this.FormClosing += Form1_FormClosing; //event för när man trycker på exit X.
        }

        //event för när programmet avslutas. Om någon av trådarna inte är null så abortas dem.
        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (writerThread != null)
                writerThread.Abort();
            if (readerThread != null)
                readerThread.Abort();
            if(statusThread != null)
                statusThread.Abort();
        }
        //Kollar om textboxen inte är tom, felmeddelande om den är de. Returnerar true eller false
        private bool ReadDataToTransfer()
        {
            if (string.IsNullOrWhiteSpace(boxString.Text))
            {
                MessageBox.Show("No string to transfer!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                textData = boxString.Text; //sätter textboxens sträng till den lokala variablen.
            return true;
        }
        //Metod som kollar vilken synkroniseringsform som angetts. Om ingen är vald så kommer ett error.
        private bool CheckSyncMode()
        {
            if(btnSync.Checked)
            {
                reader.Synchronized = true;
                writer.Synchronized = true;
                return true;
            }
            else if(btnAsync.Checked)
            {
                writer.Synchronized = false;
                reader.Synchronized = false;
                return true;
            }
            else
            {
                MessageBox.Show("Please select a mode.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        //runknappens event.
        private void btnRun_Click(object sender, EventArgs e)
        {
            if (!ReadDataToTransfer()) //kollar om en sträng är angiven.
                return;

            btnRun.Enabled = false; //disablar run knappen

            CreateObjects(); //skapar instanser av klasserna reader, writer, buffer och status.

            if (!CheckSyncMode()) //Kollar vilket synkläge som önskas.
                return;

            CreateAndStartThreads(); //Skapar upp alla trådar.
        }
        //skapar instanser av klasserna reader, writer, buffer och status.
        private void CreateObjects()
        {
            bf = new CharacterBuffer(listWriteLogger, listReadLogger);
            reader = new Reader(bf, rand, textData.Length, ReadResultLabel);
            writer = new Writer(bf, rand, textData, WriteResultLabel);
            status = new Status(bf, pbResult);
        }
        //Skapar upp alla trådar och startar dem.
        private void CreateAndStartThreads()
        {
            writerThread = new Thread(writer.WriteChar);
            writerThread.Start();
            readerThread = new Thread(reader.ReadChar);
            readerThread.Start();
            statusThread = new Thread(status.DisplayResultsWhenThreadsAreDone);
            statusThread.Start();
        }

        //Event för när CLEAR trycks.
        private void btnClear_Click(object sender, EventArgs e)
        {
            listReadLogger.Items.Clear(); //tömmer readers listbox
            listWriteLogger.Items.Clear(); //tömmer writers listbox
            boxString.Text = ""; //textboxen återställs.
            btnRun.Enabled = true; //Run blir åter klickbar.
            pbResult.BackColor = Color.Silver; //pictureboxen blir silvrig igen (ingen status)
            WriteResultLabel.Text = ""; //Resultat labelen återställs.
            ReadResultLabel.Text = ""; //Resultat labelen återställs.
        }
    }
}
