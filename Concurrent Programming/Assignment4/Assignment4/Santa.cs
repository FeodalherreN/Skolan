//Markus Olsson, AB7158

using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Assignment4
{
    /// <summary>
    /// This class represents Santa. Santa has a sled that only can carry a maxweight and a specific number of items.
    /// Santas thread sleeps aslong as the elves are packing toys in the toyfactory.
    /// </summary>
    public class Santa
    {
        private int maxWeight = 50; //Maxweight in kilos.
        private int maxItems = 2; //Maxnumber of items.
        private int currentWeight = 0; //The current weight
        private int currentItems = 0; //Current nr of items.
        private Buffer buffer; //A buffer
        private bool WakeSanta = true; //A bool that notifies if santa should be woken up.
        private List<Toy> santasToys; //A list with santas toys on his sled.
        private ListBox detailbox; //A detailbox.
        private PictureBox santa; //A picturebox (Used for santa animation).
        private Button btnGO; //The start christmas button.
        private delegate void DisplayDelagate(string s); //A delegate to invoke the listbox.
        private delegate void WakeSantaDelegate(); //A delegate used for both change picture of santa and reset the GObutton when done.

        public Santa(Buffer buff, ListBox listbox, PictureBox piSanta, Button gobtn)
        {
            this.buffer = buff; //An already instansiated buffer.
            santasToys = new List<Toy>();
            detailbox = listbox;
            santa = piSanta;
            this.btnGO = gobtn;
        }
        /// <summary>
        /// This method is used to wake santa up when the toyfactorys is done loading things in the bag.
        /// Then it fills santas bag in the sled until its either too heavy or the max number of items has been met.
        /// </summary>
        public void LookForItems()
        {
            bool close = false; //A bool made for closing the loop.
            while (currentItems != maxItems || currentWeight != maxWeight) //Loop aslong as the maxnrofitems or maxweight isnt met.
            {
                if (close) //if the close bool is true, break.
                    break;
                Toy temp = buffer.GetItem(); //Tries to get an item from the bag. It will stay here until the toyfactories are done.
                if (WakeSanta) //If wakesanta is true. (Always first time coming to this line).
                {
                    santa.Invoke(new WakeSantaDelegate(WakeSantaUp)); //Change the picture to awakesanta.
                    WakeSanta = false; //Set the bool to false.
                }
                if (temp == null) //Checks if the buffer.GetItem() returns null, if so, the queue is empty. Break.
                    break;
                
                if ((currentWeight + temp.Weight) > maxWeight) //If the current weight + the temp toys weight is bigger than the max weight...
                {
                    //Display this string, but keep looping to see if next item is less heavy.
                    detailbox.Invoke(new DisplayDelagate(DisplayString), new object[] { "Santa cant carry this item.." }); 
                }
                else
                {
                    currentWeight = currentWeight + temp.Weight; //Add to the current wieght.
                    currentItems++; //Add to the current items.
                    if (currentItems == maxItems) //If the bag becomes full from this toy..
                    {
                        santasToys.Add(temp); //Add the toy.
                        //Write this string that tells that it will be the last toy.
                        detailbox.Invoke(new DisplayDelagate(DisplayString), new object[] { temp.Name + " was added to Santas Sled and was the last one Santa could carry." });
                        close = true; //Set close to true.
                    }
                    else
                    {
                        santasToys.Add(temp); //Add item to list.
                        //Display that the item was added.
                        detailbox.Invoke(new DisplayDelagate(DisplayString), new object[] { temp.Name + " was added to Santas Sled." });
                    }
                }
                Thread.Sleep(300); // Let thread sleep. (Didnt use random because no other threads are working simultaniously.
            }
            btnGO.Invoke(new WakeSantaDelegate(ResetButton)); // When everything is done, set the button to enabled.
        }
        /// <summary>
        /// A property to set the max nr of items.
        /// </summary>
        public int MaxItems
        {
            set { maxItems = value; }
        }
        /// <summary>
        /// A property to set the max weight.
        /// </summary>
        public int MaxWeight
        {
            set { maxWeight = value; }
        }
        /// <summary>
        /// Method used for invoking the listbox.
        /// </summary>
        /// <param name="s"></param>
        public void DisplayString(string s)
        {
            detailbox.Items.Add(s);
            detailbox.SelectedIndex = detailbox.Items.Count - 1;
            detailbox.SelectedIndex = -1;
        }
        /// <summary>
        /// Method used for invoking the btnGO.
        /// </summary>
        public void ResetButton()
        {
            btnGO.Enabled = true;
        }
        /// <summary>
        /// Method used for invoking the santa image.
        /// </summary>
        public void WakeSantaUp()
        {
            santa.Image = Image.FromFile(@"pictures\awakesanta.png");
        }
    }
}
