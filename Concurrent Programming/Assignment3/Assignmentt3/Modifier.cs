//Markus Olsson, AB7158
//Concurrent Programming, Assignment 3
using System.Windows.Forms;

namespace Assignmentt3
{
    public class Modifier
    {

        private int count; //Number of strings in the Source Richtextbox.
        private CircleBuffer buffer; //object variable of buffer.
        private string find; //The string that the user tries to replace.
        private string replace; //THe string that the user wants to replace the find string with.
        private delegate void SetNotification(string changes); //Úsed to invoke the label if the user wants to be notified.
        private Label ivNotify; //THe label to invoke.


        public Modifier(CircleBuffer piBufferIn, int piNrOfStrings, string piFind, string piReplace, Label notifyLbl)
        {
            this.count = piNrOfStrings;
            this.buffer = piBufferIn;
            this.find = piFind;
            this.replace = piReplace;
            this.ivNotify = notifyLbl;
        }
        /// <summary>
        /// This method calls for the modify method in the buffer x times, where x equals count. It then checks if the 
        /// user wants to get notified how many changes where made and writes it to the label if the case is so.
        /// </summary>
        public void Modify()
        {
            int localcount = 0;
            while(localcount < count)
            {
                buffer.Modify(localcount);
                localcount++;
            }
            if (buffer.NotifyUser)
            ivNotify.Invoke(new SetNotification(NotifyUser), new object[] { buffer.NumberOfChanges.ToString() }); //Invokar stringtoread
        }
        /// <summary>
        /// The method used to invoke the label with number of changes made.
        /// </summary>
        /// <param name="changes"></param>
        public void NotifyUser(string changes)
        {
            ivNotify.Text = buffer.NumberOfChanges.ToString() + " changes made.";
        }
    }
}
