//Markus Olsson, AB7158
//Concurrent Programming, Assignment 3

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Assignmentt3
{
    /// <summary>
    /// This class reads from the circlebuffer. It then fills the strings it recieves and puts
    /// it in a local string list. In the end it out the strings in the destination richtextbox.
    /// </summary>
    public class Reader
    {

        private int count; //A count of all the strings in the sourcetextbox.
        private CircleBuffer buffer; //A circlebuffer object that will be set to the already instansiated one recieved from Form1.
        private RichTextBox boxResult; //A richtextbox that will be assigned to the destination textbox.
        private RichTextBox boxSource; //A richtextbox that will be assigned to the source textbox.
        private List<string> stringlist; //A list of strings that will be filled from the circlebuffer.
        private delegate void Marker(List<string> value);       //Delegate used for a textbox invoke

        public Reader(CircleBuffer piBufferIn, int piNrOfStrings, RichTextBox piRtResult, RichTextBox piRtSource)
        {
            this.boxResult = piRtResult;
            this.boxSource = piRtSource;
            this.count = piNrOfStrings;
            this.buffer = piBufferIn;
            stringlist = new List<string>();
        }
        /// <summary>
        /// This method calls for the Read method in the circlebufferclass n times, where n is equal to the count variables value.
        /// </summary>
        public void Read()
        {
            int localcount = 0; //localcount is used to loop in the while statement.
            while(localcount < count)
            {
                stringlist.Add(buffer.Read(localcount)); //Adds the string it recieves from buffer.read to the string list.
                localcount++; //increments the localcount.
            }
            boxResult.Invoke(new Marker(AppendRichTextBox), new object[] { stringlist }); //Invokes the richtextbox. Calls for AppendRichTextBox.
        }

        /// <summary>
        /// this is the method used for invoking. The method just adds all the strings in the list to the richtextbox.
        /// It then highlights all the matches of the replacement string
        /// </summary>
        /// <param name="value"></param>
        public void AppendRichTextBox(List<string> value)
        {
            foreach (string val in value)
            {
                boxResult.Text += val + Environment.NewLine;
            }
            if (buffer.NumberOfChanges != 0)
            {
                Regex reg = new Regex(buffer.ReplacementString, RegexOptions.IgnoreCase);
                foreach (Match find in reg.Matches(boxResult.Text))
                {
                    this.boxResult.Select(find.Index, find.Length);
                    this.boxResult.SelectionBackColor = Color.Green;
                }
            }
        }
    }
}
