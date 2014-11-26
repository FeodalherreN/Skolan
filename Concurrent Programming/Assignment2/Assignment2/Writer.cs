//Markus Olsson, AB7158
//Concurrent programming

using System;
using System.Threading;
using System.Windows.Forms;

namespace Assignment2
{
    /// <summary>
    /// Denna klassen skriver till characterbuffern. Den loopar igenom strängen som angivits 
    /// och sätter in dess character en efter en i buffern. Den väntar mellan varje operation på 
    /// att readern har läst om det är synkroniserat.
    /// </summary>
    public class Writer
    {
        private CharacterBuffer charbuffer;
        private Random random;
        private string StringToWrite;
        private bool sync;
        private Label label;

        private delegate void DisplayDelagate(string s); //invokedelegat för string

        public Writer(CharacterBuffer bf, Random r, string s, Label l)
        {
            this.charbuffer = bf; //tar emot en redan instansierad characterbuffer
            this.random = r; //tar emot en redan instansierad random
            this.StringToWrite = s; // sätter strängen från textboxen
            this.label = l; // sätter label under writer.
        }

        //property för om writern ska vara synchronized
        public bool Synchronized
        {
            get { return sync; }
            set { sync = value; }
        }

        //Metoden som writertråden kör. Loopar igenom strängen och skriver till buffern.
        public void WriteChar()
        {
            for (int i = 0; i < StringToWrite.Length; i++) //Loopar efter hur många char strängen innehåller.
            {
                if(Synchronized)
                {
                    charbuffer.SyncReadWrite = StringToWrite[i];
                }
                else
                {
                    charbuffer.AsyncReadWrite = StringToWrite[i];
                }
                Thread.Sleep(random.Next(400, 1000)); //sover en random tid mellan 400-1000 ms efter att ha kallat på properties i buffern.
            }
            label.Invoke(new DisplayDelagate(DisplayString), new object[] { StringToWrite }); //invokar StringToWrite
            charbuffer.FinishedWriting(StringToWrite); //berättar för buffern att den är klar med skrivandet.
        }

        //metod för invoke delegatet.
        public void DisplayString(string s)
        {
            label.Text = s;
        }
    }
}
