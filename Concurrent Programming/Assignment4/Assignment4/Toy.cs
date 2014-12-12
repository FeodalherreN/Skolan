//Markus Olsson, AB7158

namespace Assignment4
{
    /// <summary>
    /// This is a class defining a toyobject.
    /// </summary>
    public class Toy
    {
        private string name; //A toy must have name.
        private int weight; //A toy must have weight.
        private int width; //A toy must have width.
        private int length; //A toy must have length.
        private int depth; //A toy must have depth.

        public Toy(string piName, int piWeight, int piHeight, int piWidth, int piDepth)
        {
            this.name = piName;
            this.weight = piWeight;
            this.width = piHeight;
            this.length = piWidth;
            this.depth = piDepth;
        }
        /// <summary>
        /// Property to get or set the name of the Toy.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// Property to get or set the weight of the Toy.
        /// </summary>
        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        /// <summary>
        /// Property to get or set the Height of the Toy.
        /// </summary>
        public int Height
        {
            get { return width; }
            set { width = value; }
        }
        /// <summary>
        /// Property to get or set the Width of the Toy.
        /// </summary>
        public int Width
        {
            get { return length; }
            set { length = value; }
        }
        /// <summary>
        /// Property to get or set the Depth of the Toy.
        /// </summary>
        public int Depth
        {
            get { return depth; }
            set { depth = value; }
        }
    }
}
