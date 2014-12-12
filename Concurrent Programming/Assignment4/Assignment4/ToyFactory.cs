//Markus Olsson, AB7158

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Assignment4
{
    /// <summary>
    /// This class is used to randomly add toys from its own toycollection to the queue in the buffer.
    /// </summary>
    public class ToyFactory
    {
        private List<Toy> toyCollection; //A collection of toys.
        private Buffer buffer; //A buffer.
        private Random random; //A random.
        private ListBox detailbox; //The detailbox.
        private PictureBox[] pictureBoxes; //A pictureboxarray, later used for moving the elves in the GUI.
        private delegate void DisplayDelagate(string s); //delegate to invoke the listbox.
        private delegate void MoveElvesDelegate(PictureBox p); //delegate used to move the elves in the GUI.

        public ToyFactory(Buffer buff, List<Toy> piToyCollection, Random rand, ListBox listdetail, PictureBox[] pbArr)
        {
            buffer = buff; //Already instansiated buffer.
            toyCollection = piToyCollection;
            random = rand; //Already instansiated random.
            detailbox = listdetail;
            pictureBoxes = pbArr;
        }
        /// <summary>
        /// This method is used to fill santas bag until certain criteria are met. 
        /// </summary>
        public void FillSantasBag()
        {
            while(true) 
            {
                int randomInt = random.Next(0, toyCollection.Count); //New random index for toycollection.
                int randomSleep = random.Next(400, 1000); //New random sleep interval.
                int randomPictureBox = random.Next(0, 3); //new random picturebox position.
                Toy temp = toyCollection[randomInt]; //get a toy from toycollection at random index.
                if (!buffer.AddItem(temp)) //If the buffer.Additem returns false, break.
                {
                    break;
                }
                else
                {
                    detailbox.Invoke(new DisplayDelagate(DisplayString), new object[] { temp.Name + " was added to the bag." }); //Add to the listbox.
                    PictureBox tempb = pictureBoxes[randomPictureBox]; //get a random picturebox from the array.
                    tempb.Invoke(new MoveElvesDelegate(MoveElves), new object[] { tempb }); //Move the elf to this picturebox.
                    Thread.Sleep(randomSleep); //Threadsleep random.
                }
            }
        }
        /// <summary>
        /// This method is used for invoking the listbox.
        /// </summary>
        /// <param name="s"></param>
        public void DisplayString(string s)
        {
            detailbox.Items.Add(s);
            detailbox.SelectedIndex = detailbox.Items.Count - 1; //Autoscroll
            detailbox.SelectedIndex = -1; //Autoscoll
        }
        /// <summary>
        /// This method is used to move the elves and invoke the picturebox.
        /// </summary>
        /// <param name="p"></param>
        public void MoveElves(PictureBox p)
        {
            foreach(PictureBox pb in pictureBoxes) //Clears all the pictureboxes images.
            {
                pb.Image = null;
            }
            p.Image = Image.FromFile(@"pictures\tomtenisse.gif"); //Adds image to the random picturebox.
            p.SizeMode = PictureBoxSizeMode.StretchImage; //Stretches the image in the picturebox.
        }
    }
}
