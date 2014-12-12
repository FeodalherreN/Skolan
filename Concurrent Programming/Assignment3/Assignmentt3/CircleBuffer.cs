//Markus Olsson, AB7158
//Concurrent Programming, Assignment 3
using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace Assignmentt3
{
    /// <summary>
    /// 
    /// </summary>
    public class CircleBuffer
    {
        #region Variabler
        private string[] strArr;               //The actual buffer array
        private int Max;                       //Elements in buffer
        private int writePos;                  //The position pointers for each thread
        private int readPos;                   //Index for readposition
        private int modifyPos;                   //index for findposition
        private string findString;             //The string to search for
        private string ReplaceString;          //The string to replace with
        private int nbrReplacements;           //Replacement counter
        private bool notify;                   //A bool to notify the user

        private delegate void Marker(string value);       //Delegate used for a textbox invoke
        private static Semaphore modifySemaphore;  //A semaphore for the modifythread
        private static Semaphore readerSemaphore;  //A semaphore for the readThread.
        #endregion
        
        public CircleBuffer(int piElements, bool piNotify, string piFind, string piReplace)
        {
            this.Max = piElements;
            this.notify = piNotify;
            this.findString = piFind;
            this.ReplaceString = piReplace;
            strArr = new string[Max];
            modifySemaphore = new Semaphore(0, 1);
            readerSemaphore = new Semaphore(0, 1);
        }
        /// <summary>
        /// This method is called for from the Reader class. The method itself waits for the readersemaphore to get notified,
        /// and when it does, it reads the value in the stringarray at position index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string Read(int index)
        {
            readPos = index;
            Console.WriteLine("reader waits for semaphore...");
            readerSemaphore.WaitOne();
            Console.WriteLine("reader enters semaphore...");
            string temp = strArr[index];
            return temp;
        }
        /// <summary>
        /// This method is called for from the Writer class. The method itself just writes strings to the stringarray. After
        /// each writing it notifies the modifySemaphore that its done.
        /// </summary>
        /// <param name="StringToPut"></param>
        /// <param name="index"></param>
        public void Write(string StringToPut, int index)
        {
            writePos = index;
            strArr[index] = StringToPut;
            while(writePos != modifyPos)
            {
                Thread.Sleep(15);
            }
            modifySemaphore.Release();
        }
        /// <summary>
        /// This method is called for from the Modify class. It waits for the modify semaphore to get notified (meaning that the
        /// writer method is done) and then goes in at position index and checks if the string is the one the user is trying to replace.
        /// When its done it notifies the readerSemaphore that its done.
        /// </summary>
        /// <param name="index"></param>
        public void Modify(int index)
        {
            modifyPos = index;
            Console.WriteLine("modifier waits for semaphore...");
            modifySemaphore.WaitOne();
            if (ReplaceString != "")
            {
                Console.WriteLine("modifier enters semaphore...");
                bool contains = strArr[index].IndexOf(findString, StringComparison.OrdinalIgnoreCase) >= 0;
                if (contains)
                {
                    strArr[index] = Regex.Replace(strArr[index], findString, ReplaceString, RegexOptions.IgnoreCase);
                    nbrReplacements++;
                }
            }
            Console.WriteLine("modifier is about to release semaphore for reader..");
            readerSemaphore.Release();
            Console.WriteLine("modifier released semaphore for reader..");

        }
        /// <summary>
        /// A property to set if the user should be notified of how many changes that has been made.
        /// </summary>
        public bool NotifyUser
        {
            get { return notify; }
            set { notify = value; }
        }
        /// <summary>
        /// A property that returns the number of changes by modify.
        /// </summary>
        public int NumberOfChanges
        {
            get { return nbrReplacements; }
        }
        /// <summary>
        /// Returns the replacementstring
        /// </summary>
        public string ReplacementString
        {
            get { return ReplaceString; }
        }
    }
}
