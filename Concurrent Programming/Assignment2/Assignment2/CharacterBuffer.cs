//Markus Olsson, AB7158
//Concurrent programming

using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Assignment2
{
    /// <summary>
    /// Denna klassen fungerar som en mellanhand för writer och reader. Båda delar på samma instans av denna klassen
    /// och skriver och läser från den. Det som hanteras i klassen är en character. Klassen håller även koll på om 
    /// readern och writern är klara med sina uppgifter.
    /// </summary>
    public class CharacterBuffer
    {
        private char ch; //Den episka charen.
        private ListBox lstWriter;
        private ListBox lstReader;
        private bool writefinish = false; //bool för om writern är klar eller ej.
        private bool readfinish = false; //bool för om readern är klar eller ej.
        private string readOutput; //sträng för att hålla och jämföra readerns resultat.
        private string writeOutput; //sträng för att hålla och jämföra writerns resultat.
        private Queue<char> charstack; //En kö för att hålla charactern

        private delegate void DisplayDelegate(string s, ListBox lb); //delegat som tar emot en sträng och listbox.

        object mylock = new object(); //ett lås för ReadWrite properties.
        object finishlock = new object(); //Ett lås för väntan på writer och readers resultat.

        public CharacterBuffer(ListBox writerListBox, ListBox readerListBox)
        {
            lstReader = readerListBox; //Readerns listbox (höger på GUI)
            lstWriter = writerListBox; //Readerns listbox (vänster på GUI)
            charstack = new Queue<char>(); //instansiering av kön.
        }

        //property för charen ch om användaren önskar köra programmet asynkroniserat. Den har inga lås eller monitors.
        public Char AsyncReadWrite
        {
            get //hämta och skriv ut en char.
            {
                lstReader.Invoke(new DisplayDelegate(DisplayString), new object[] { "Reading..." + ch, lstReader });
                return ch;
            }
            set //skriv vad charen ska innehålla och skriv ut de.
            {
                ch = value;
                lstWriter.Invoke(new DisplayDelegate(DisplayString), new object[] { "Writing..." + ch, lstWriter });
            }
        }

        //property för charen ch om användaren önskar köra programmet synkroniserat. Använder lås och monitors.
        public Char SyncReadWrite
        {
            get
            {
                lock (mylock) //låser kodblocket för andra trådar.
                {
                    while(charstack.Count == 0) //medan charstacken är tom....
                    {
                        Monitor.Wait(mylock); //så väntar den på att någon ska pulsea mylock
                    }
                    char temp = charstack.Dequeue(); //hämtar ut och sparar undan charen i kön.
                    lstReader.Invoke(new DisplayDelegate(DisplayString), new object[] { "Reading..." + temp, lstReader }); //invokar charen till listboxen.
                    return temp; //returnerar temp (ch)
                }
            }
            set
            {
                lock (mylock) //låser kodblocket för andra trådar.
                {
                    charstack.Enqueue(value); //lägger till value i kön.
                    lstWriter.Invoke(new DisplayDelegate(DisplayString), new object[] { "Writing..." + value, lstWriter }); //invokar charen till listboxen.
                    Monitor.PulseAll(mylock); //pulsar mylock (släpper den)
                }
            }
        }
        //metod för att lägga till items i en listbox.
        private void DisplayString(string s, ListBox lb)
        {
            lb.Items.Add(s);
        }
        //metod för att vänta och analysera resultat av körningen.
        public bool WaitForResult()
        {
            lock (finishlock) //låser kodsnutten med finishlock.
            {
                while (!writefinish || !readfinish) //sålänge reader och writer inte är klara..
                {
                    Monitor.Wait(finishlock); //så väntar finishlock.
                }
                return readOutput == writeOutput; //Sedan returneras resultatet. Är strängarna lika?
            }
        }
        //metod som kallas på när writern är klar. tar emot strängen som skrivits.
        public void FinishedWriting(string writeoutput)
        {
            lock (finishlock) // låser med finishlock.
            {
                writefinish = true; //sätter writefinish till true.
                writeOutput = writeoutput; // sätter den lokala strängen till resultatet.
                Monitor.PulseAll(finishlock); //pulsar alla med finishlock
            }
        }
        public void FinishedReading(string readoutput)
        {
            lock (finishlock)
            {
                readfinish = true; //sätter readfinish till true.
                readOutput = readoutput; // sätter den lokala strängen till resultatet.
                Monitor.PulseAll(finishlock); //pulsar alla med finishlock
            }
        }
    }
}
