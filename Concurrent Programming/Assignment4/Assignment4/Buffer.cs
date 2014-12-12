//Markus Olsson, AB7158

using System.Collections.Generic;
using System.Threading;

namespace Assignment4
{
    /// <summary>
    /// This class holds a queue and two methods that enqueues a toy to the queue, or dequeues a toy from the queue.
    /// Monitors are used in the methods to make them threadsafe and synchronized.
    /// </summary>
    public class Buffer
    {
        private Queue<Toy> toyBag; //A queue holding toys. 
        private int maxNrOfItems = 25; //The maximum nr of items the bag can hold with a standard value of 25.
        private bool full = false; //A bool thats made to indicate wheather the queue is full or not.

        object mylock = new object(); //A lock 
        object finishlock = new object(); //Another lock

        public Buffer()
        {
            toyBag = new Queue<Toy>(); //New instance of the queue..
        }
        /// <summary>
        /// This method either adds a given toy to the queue and returns true, or returns false if the bag is full.
        /// Locks and monitors are used to make the method threadsafe.
        /// </summary>
        /// <param name="toyToAdd"></param>
        /// <returns></returns>
        public bool AddItem(Toy toyToAdd)
        {
            lock(mylock) //Locks this codeblock.
            {
                if(full == true) //if the queue is full, return false.
                {
                    return false;
                }
                else if (toyBag.Count != maxNrOfItems) //if the queue has room, add the toy to the queue and pulse the other threads waiting for mylock. 
                {
                    toyBag.Enqueue(toyToAdd);
                    Monitor.PulseAll(mylock);
                    return true;
                }
                else //If the bool full is not true, but there is no more space left, set full to true and pulse the others waiting for mylock and finishlock.
                {
                    full = true;
                    Monitor.PulseAll(mylock);
                    lock (finishlock) 
                    {
                        Monitor.PulseAll(finishlock); 
                    }
                    return false;
                }
            }
        }
        /// <summary>
        /// This method either returns a Toy or null, depending if there are Toys in the queue.
        /// </summary>
        /// <returns></returns>
        public Toy GetItem()
        {
            lock(finishlock) //Locks with finishlock.
            {
                while (!full) //As long as full is false
                {
                    Monitor.Wait(finishlock); //Waits for finishlock to get pulsed.
                }
                if (toyBag.Count != 0) //if the bag is not empty..
                    return toyBag.Dequeue(); //Return a Toy from the bag.
                else //Otherwise, return null.
                    return null;
            }
        }
        /// <summary>
        /// A property to set the value of maxitems in the queue.
        /// </summary>
        public int MaxNumberOfItems
        {
            set { maxNrOfItems = value; }
        }
    }
}
