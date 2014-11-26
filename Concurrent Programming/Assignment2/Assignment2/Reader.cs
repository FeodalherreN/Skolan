//Markus Olsson, AB7158
//Concurrent programming

using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Assignment2
{
    /// <summary>
    /// Denna klassen läser från characterbuffern. Den loopar igenom strängens length som angivits 
    /// och läser ut dess characters en efter en från buffern. Den väntar mellan varje operation på 
    /// att writern har skrivit om det är synkroniserat.
    /// </summary>
    public class Reader
    {
        private CharacterBuffer charbuffer;
        private Random random;
        private string StringToRead;
        private int Count;
        private bool sync;
        private Label lblDisplayResult;

        private delegate void DisplayDelagate(string s); //Delegat som tar emot en sträng

        public Reader(CharacterBuffer bf, Random r, int count, Label l)
        {
            this.charbuffer = bf; //En redan instansierad characterbuffer
            this.random = r; //En redan instansierad random
            this.Count = count; //Strängen som angivits length
            this.lblDisplayResult = l; //Label tillhörande readerns resultat
        }
        //Property för om readern ska agera synkroniserat eller ej
        public bool Synchronized
        {
            get { return sync; }
            set { sync = value; }
        }
        //metoden som används av tråden. Den läser characters från buffern och loopar efter strängens length.
        public void ReadChar()
        {
            StringBuilder sb = new StringBuilder(StringToRead); //Stringbuilder för att spara charactersen i
            int j = 0;
            while (j < Count)
            {
                if(Synchronized)
                    sb.Append(charbuffer.SyncReadWrite); //hämtar en character från buffern och väntar på writern.

                else
                    sb.Append(charbuffer.AsyncReadWrite); //Hämtar en character från buffern utan hänsyn till writern.

                j++;
                Thread.Sleep(random.Next(400, 1000)); //sover en random tid mellan 400-1000 ms efter att ha kallat på properties i buffern.
            }
            StringToRead = sb.ToString(); //sparar stringbuildern i stringtoread
            lblDisplayResult.Invoke(new DisplayDelagate(DisplayString), new object[] { StringToRead }); //Invokar stringtoread
            charbuffer.FinishedReading(StringToRead);//berättar för buffern att den har hämtat allt.
        }

        //Metod för att invokea en sträng.
        public void DisplayString(string s)
        {
            lblDisplayResult.Text = s;
        }
    }
}
