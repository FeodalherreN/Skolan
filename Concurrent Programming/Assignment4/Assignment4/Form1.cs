//Markus Olsson, AB7158

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Assignment4
{
    public partial class Form1 : Form
    {
        private Thread firstToyFactoryThread; //ToyfactoryThread 1.
        private Thread secondToyFactoryThread; //Toyfactorythread 2.
        private Thread santaThread; //Santa thread.

        private PictureBox[] elves; //Picturebox array for the elves.
        private List<Toy> toys; //List of toys.

        private ToyCollection toyCollection; //A toycollection.
        private Buffer buff; //A buffer.
        private ToyFactory firstToyFactory; //A toyfactory.
        private ToyFactory secondToyFactory; //A second toyfactory.
        private Santa santa; //A santa.
        private Random rand; //A random.

        public Form1()
        {
            InitializeComponent();
            InitiateGUI(); //Initialize the gui.
            rand = new Random(); //New random.
            elves = new PictureBox[3] { pbGB1, pbGB2, pbGB3 }; //Set the three elfpictureboxes to the array.
            this.FormClosing += Form1_FormClosing; //Event for when the form is closed by pressing the X.
        }
        /// <summary>
        /// Aborts all threads if not null.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (firstToyFactoryThread != null)
                firstToyFactoryThread.Abort();
            if (secondToyFactoryThread != null)
                secondToyFactoryThread.Abort();
            if (santaThread != null)
                santaThread.Abort();
        }
        /// <summary>
        /// This method initializes the GUI, sets all the images and stretches them to fit the pictureboxes.
        /// </summary>
        private void InitiateGUI()
        {
            pbToyFactory1.Image = Image.FromFile(@"pictures\santasfactory.jpg");
            pbToyFactory1.SizeMode =PictureBoxSizeMode.StretchImage;
            pbToyFactory2.Image = Image.FromFile(@"pictures\santasfactory.jpg");
            pbToyFactory2.SizeMode = PictureBoxSizeMode.StretchImage;
            pbGB3.Image = Image.FromFile(@"pictures\tomtenisse.gif");
            pbGB3.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSanta.Image = Image.FromFile(@"pictures\sleepingsanta.png");
            pbSanta.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSantasBag.Image = Image.FromFile(@"pictures\santasbag.png");
            pbSantasBag.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        /// <summary>
        /// instansiates the classes.
        /// </summary>
        private void InstansiateClasses()
        {
            buff = new Buffer(); // THe buffer is later put in the other classes so they share the same resource.
            santa = new Santa(buff, listDetails, pbSanta, btnGO);
            firstToyFactory = new ToyFactory(buff, toys, rand, listDetails, elves);
            secondToyFactory = new ToyFactory(buff, toys, rand, listDetails, elves);
        }
        /// <summary>
        /// Creates and starts the threads.
        /// </summary>
        public void CreateAndStartThreads()
        {
            firstToyFactoryThread = new Thread(firstToyFactory.FillSantasBag);
            firstToyFactoryThread.Start();
            secondToyFactoryThread = new Thread(secondToyFactory.FillSantasBag);
            secondToyFactoryThread.Start();
            santaThread = new Thread(santa.LookForItems);
            santaThread.Start();
        }
        /// <summary>
        /// Logics for when the "Start Christmas" Button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGO_Click(object sender, EventArgs e)
        {
            listDetails.Items.Clear(); //CLear the listbox.
            btnGO.Enabled = false; //Set the button to disabled.
            listDetails.Items.Add("Brace yourselves, christmas is starting..."); //Write this. 
            toyCollection = new ToyCollection(); // New toycollection...
            toys = toyCollection.Toys;//This sets the own list of toys to the list made by the toycollectionclass.
            InstansiateClasses(); //Instansiates the classes.
            ValidateGUI(); //Validates the input in GUI.
            CreateAndStartThreads(); //Creates and starts the threads.
        }
        /// <summary>
        /// This method validates the input given by the user in the GUI.
        /// </summary>
        private void ValidateGUI()
        {
            if(boxMaxItems.Text != "") //Validates if the maxitems is empty, if not, validates if the input is an integer.
            {
                int x;
                bool isNumeric = int.TryParse(boxMaxItems.Text, out x);
                if (isNumeric)
                    santa.MaxItems = x;
            }
            if (boxMaxWeight.Text != "")//Validates if the maxweight is empty, if not, validates if the input is an integer.
            {
                int y;
                bool isNumeric = int.TryParse(boxMaxWeight.Text, out y);
                if (isNumeric)
                    santa.MaxWeight = y;
            }
            if (boxNrOfToys.Text != "")//Validates if the number of toys is empty, if not, validates if the input is an integer.
            {
                int z;
                bool isNumeric = int.TryParse(boxNrOfToys.Text, out z);
                if (isNumeric && z < 31)
                    buff.MaxNumberOfItems = z;
            }
        }
    }
}
