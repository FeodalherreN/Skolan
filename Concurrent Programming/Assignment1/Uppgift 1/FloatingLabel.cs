//Markus Olsson AB7158
//2014-11-20
//Concurrent Programming, Assignment 1

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uppgift_1
{
    /// <summary>
    /// Denna klassen är gjord för att hantera den label som ska hoppa runt i programmet.
    /// </summary>
    public class FloatingLabel
    {
        #region Variabler
        private bool StartMovingLabel; 
        private int ivWidth;
        private int ivHeight;
        private int PbOneHeight;
        private int PbOneWidth;
        private Random random;
        #endregion

        public FloatingLabel()
        {
            random = new Random();
        }

        #region Metoder
        /// <summary>
        /// Metod som tar emot en label. Därefter slumpar den koordinater utifrån pictureboxen i bakgrundens bredd och höjd.
        /// Den invokar i sin tur labelen eftersom den ligger på en annan tråd. Sist sover tråden en sekund emellan varje operation.
        /// </summary>
        /// <param name="label"></param>
        public void moveLabel(Control label)
        {
            while (StartMovingLabel == true)
            {
                int width = Width - 25;
                int height = Height - 35;
                PbOneWidth = random.Next(0, width);
                PbOneHeight = random.Next(0, height);
                MoveText(label);
                Thread.Sleep(1000);
            }
        }
        delegate void SetGroupCallback(Control ctrl);

        /// <summary>
        /// En invokemetod för labelen så att den kan ändra dess property "location", dvs dess position.
        /// </summary>
        /// <param name="ctrl"></param>
        public void MoveText(Control ctrl)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.BeginInvoke(new SetGroupCallback(MoveText), ctrl);
            }
            else
            {
                ctrl.Location = new Point(PbOneWidth, PbOneHeight);
            }
        }
        #endregion

        #region Properties
        public bool MoveLabel
        {
            get { return StartMovingLabel; }
            set { StartMovingLabel = value; }
        }

        public int Width
        {
            get { return ivWidth; }
            set { ivWidth = value; }
        }
        public int Height
        {
            get { return ivHeight; }
            set { ivHeight = value; }
        }
        #endregion
    }
}
