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
    /// Denna klassen är gjord för att hantera den triangeln som ska hoppa runt i programmet.
    /// </summary>
    public class MovingTriangle
    {
        #region Variabler
        private bool StartMovingTriangle;
        private int ivWidth;
        private int ivHeight;
        private int PbTwoHeight;
        private int PbTwoWidth;
        private Random random;
        #endregion

        public MovingTriangle()
        {
            random = new Random();
        }

        #region Metoder
        /// <summary>
        /// Metod som tar emot en picturebox. Därefter slumpar den koordinater utifrån pictureboxen i bakgrundens bredd och höjd.
        /// Den invokar i sin tur den mottagna pictureboxen eftersom den ligger på en annan tråd. Sist sover tråden en sekund emellan varje operation.
        /// </summary>
        /// <param name="picturebox"></param>
        public void MoveTriangle(Control picturebox)
        {
            while (StartMovingTriangle == true)
            {
                int width = Width - picturebox.Width;
                int height = Height - picturebox.Height;
                PbTwoWidth = random.Next(0, width);
                PbTwoHeight = random.Next(0, height);
                MoveTriangleInvoke(picturebox);
                Thread.Sleep(1000);
            }
        }
        delegate void SetTriangleCallback(Control ctrl);

        /// <summary>
        /// En invokemetod för pictureboxen som tagits emot så att den kan ändra dess property "location", dvs dess position.
        /// </summary>
        /// <param name="ctrl"></param>
        private void MoveTriangleInvoke(Control ctrl)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.BeginInvoke(new SetTriangleCallback(MoveTriangleInvoke), ctrl);
            }
            else
            {
                ctrl.Location = new Point(PbTwoWidth, PbTwoHeight);
            }
        }
        #endregion

        #region Properties
        public bool MoveTriangleBox
        {
            get { return StartMovingTriangle; }
            set { StartMovingTriangle = value; }
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
