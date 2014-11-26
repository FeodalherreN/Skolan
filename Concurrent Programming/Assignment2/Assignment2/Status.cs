//Markus Olsson, AB7158
//Concurrent programming

using System.Drawing;
using System.Windows.Forms;

namespace Assignment2
{
    /// <summary>
    /// Denna klassen är skapad för att hålla koll readern och writerns status. När de är klara med att
    /// skriva och läsa så sätts pictureboxen till grön om de blev en matchning och röd om det inte blev en
    /// matchning.
    /// </summary>
    public class Status
    {
        private PictureBox pb;
        private CharacterBuffer buffer;
        bool changed = false;

        public Status(CharacterBuffer bf, PictureBox pbResult)
        {
            this.buffer = bf; //En redan instansierad buffer
            this.pb = pbResult; //pictureboxen som ska ändras.
        }

        public void DisplayResultsWhenThreadsAreDone()
        {
            while (!changed)
            {
                //väntar på att få konfirmation om reader/writer är klara, WaitForResult returnerar true om det är en matchning.
                if (buffer.WaitForResult())
                {
                    pb.BackColor = Color.Green; //Pictureboxen blir grön om det är en matchning.
                    changed = true;
                }
                else
                {
                    pb.BackColor = Color.Red; //Pictureboxen blir röd om det inte är en matchning.
                    changed = true;
                }
            }
        }

        //Property som berättar om pictureboxen har ändrat färg.
        public bool Changed
        {
            set { changed = value; }
        }
    }
}
