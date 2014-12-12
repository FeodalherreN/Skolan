//Markus Olsson, AB7158

using System.Collections.Generic;

namespace Assignment4
{
    /// <summary>
    /// This class is made to make a list of toys. If it is instansiated, the list is created.
    /// If you call for the toys property, you get the list.
    /// </summary>
    public class ToyCollection
    {
        private List<Toy> toyCollection; //A toycollection.
        public ToyCollection()
        {
            CreateToyCollection(); //Calls for this method on instansiation.
        }
        public void CreateToyCollection()
        {
            toyCollection = new List<Toy>(); // new instance.
            //Add a whole lot of toys to the collection.
            //name, weight, length, width, depth (Last two not used because of insufficiant knowledge.)
            toyCollection.Add(new Toy("Svärd", 2, 30, 5, 4));
            toyCollection.Add(new Toy("Bil", 1, 5, 10, 5));
            toyCollection.Add(new Toy("Brandbil", 3, 30, 10, 8));
            toyCollection.Add(new Toy("Pistol", 2, 10, 8, 4));
            toyCollection.Add(new Toy("Docka", 3, 50, 10, 10));
            toyCollection.Add(new Toy("Barbie", 1, 30, 5, 4));
            toyCollection.Add(new Toy("Ubåt", 4, 40, 10, 8));
            toyCollection.Add(new Toy("Pandabjörn", 1, 30, 5, 4));
            toyCollection.Add(new Toy("Glas", 1, 30, 5, 4));
            toyCollection.Add(new Toy("AK-47", 7, 30, 5, 4));
            toyCollection.Add(new Toy("Rullor", 1, 30, 5, 4));
            toyCollection.Add(new Toy("Studsboll", 1, 30, 5, 4));
            toyCollection.Add(new Toy("Kniv", 1, 30, 5, 4));
            toyCollection.Add(new Toy("Boll", 1, 30, 5, 4));
            toyCollection.Add(new Toy("Tennisrack", 2, 30, 5, 4));
            toyCollection.Add(new Toy("Pingisrack", 1, 30, 5, 4));
            toyCollection.Add(new Toy("Spade", 3, 30, 5, 4));
            toyCollection.Add(new Toy("Bilbana", 5, 30, 5, 4));
            toyCollection.Add(new Toy("Lasersvärd", 1, 30, 5, 4));
            toyCollection.Add(new Toy("Choklad", 1, 30, 5, 4));
            toyCollection.Add(new Toy("Pokemonkort", 1, 30, 5, 4));
            toyCollection.Add(new Toy("Mobiltelefon", 1, 30, 5, 4));
            toyCollection.Add(new Toy("Ipad", 1, 30, 5, 4));
            toyCollection.Add(new Toy("Pengar", 1, 30, 5, 4));
            toyCollection.Add(new Toy("Dator", 5, 30, 5, 4));
            toyCollection.Add(new Toy("Ipod", 1, 30, 5, 4));
            toyCollection.Add(new Toy("Film", 1, 30, 5, 4));
            toyCollection.Add(new Toy("Badboll", 1, 30, 5, 4));
            toyCollection.Add(new Toy("Bok", 1, 30, 5, 4));
            toyCollection.Add(new Toy("Ukulele", 3, 30, 5, 4));
        }
        /// <summary>
        /// Property for the toycollection. Returns the list.
        /// </summary>
        public List<Toy> Toys
        {
            get { return toyCollection; }
        }
    }
}
