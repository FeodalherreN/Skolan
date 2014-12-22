//Markus Olsson, AB7158
//Systemutvecklare MAH
package p5;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.Font;
import javax.swing.BorderFactory;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;
/*
 * This class is responsible for the Frame called "CountryViewer". Its main purpose is to
 * fill the list with countryobjects and update the statistics.
 */
public class CountryViewer extends JPanel {
	private JFrame frame = new JFrame("CountryViewer"); //A new frame!
	private JPanel pnlHeader; //An instance variable of a northpanel
	private JPanel pnlList;//An instance variable of a centerpanel
	private JPanel pnlStats;//An instance variable of a bottompanel
	private JTextArea txtList; //A textarea variable
	private JTextArea txtStats; //A textarea variable
	private JScrollPane scroll; //A scroll used for the list of countries...
	private JLabel lblHeader; //A label for the northpanel.
	
	//Constructor that takes a width and a height.
public CountryViewer(int x, int y)
{
    frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); //Sets the behaviour on close.
    frame.setLocation(x,y); //sets the frames location
    frame.setSize(x, y); //Sets the frames size.
    frame.add(InitiateGUI()); //Adds the panel InitiateGUI to the frame...
    frame.setVisible(true); //Sets the frame visible.
}
/*This method returns a mainpanel.
 * @returns a panel
 */
private JPanel InitiateGUI()
{
	JPanel panel = new JPanel(new BorderLayout()); //Creates a mainpanel
	panel.add(panelHeader(),BorderLayout.NORTH); //Adds a panel to the northside.
    panel.add(panelList(),BorderLayout.CENTER); //Adds a panel to the center.
    panel.add(panelStatistics(),BorderLayout.SOUTH); //Adds the panel to the south.
	return panel;
}
/*Creates a panel for the top.
 * @returns a panel
 */
private JPanel panelHeader()
{
	pnlHeader = new JPanel(); // New instance of the panel.
	pnlHeader.setBackground(Color.black); //Sets the backgroundcolor to black.
	lblHeader = new JLabel("Länder och deras befolkning"); //Instansiates the label and sets the text.
	lblHeader.setForeground(Color.white); //Sets the texts foreground color to white.
	pnlHeader.add(lblHeader); //Adds the label to the panel.
	return pnlHeader; //Returns the panel.
}
//Creates a panel for the top.
private JPanel panelList() {
    pnlList = new JPanel();// New instance of the panel.
    txtList = new JTextArea(); //A new instance of the textarea for the countrylist.
    txtList.setEditable(false); //Sets it noneditable.
    txtList.setFont(new Font(Font.MONOSPACED,Font.PLAIN, 12)); //sets the font of the textarea.
    scroll = new JScrollPane(txtList); //New instance of the scrollpane.
    scroll.setPreferredSize(new Dimension(320, 250)); //Sets the preferedsize of the textarea
    pnlList.setBorder(BorderFactory.createLineBorder(Color.BLACK)); //Sets a border to the panel.
    pnlList.add(scroll); //Adds the scroll to the panel.
    return pnlList; //Returns the panel.
}
/*Creates a panel for the top.
 * @returns a panel
 */
private JPanel panelStatistics()
{
	pnlStats = new JPanel();// New instance of the panel.
	pnlStats.setBorder(BorderFactory.createTitledBorder("Statistik"));
	txtStats = new JTextArea();//A new instance of the textarea for the statistics.
	txtStats.setEditable(false); //Sets it noneditable.
	pnlStats.add(txtStats); //Adds the textarea to the panel.
	txtStats.setPreferredSize(new Dimension(320, 150)); //Sets the preferedsize of the textarea
	return pnlStats; //Returns the panel.
	
}
//This method updates the textarea dedicated for the countrylist with new data.
public void showCountries(Country[] countries)
{
	txtList.setText(""); //Clears the textarea for the list of countries.
	long TotalPopulation = 0; //A long to keep track of the totalpopulation.
	long MinPopulation = 0; //A long to keep track of the minimum population
	long MaxPopulation = 0; //A long to keep track of the maximum population
	for(int i = 0; i < countries.length; i++) //Loops the given country array.
	{
		txtList.append(countries[i].toString()+ "\n"); //Adds the country to the list of countries.
		TotalPopulation += countries[i].getPopulation();//adds to the totalpopulation.
		if(i == 0)//checks if it is the first loop.
		{
			MinPopulation = countries[i].getPopulation();//Sets the minpopulation variable to i.
			MaxPopulation = countries[i].getPopulation();//Sets the maxpopulation variable to i.
		}
		else //If it is not the first iteration...
		{
			if(countries[i].getPopulation() < MinPopulation) //Checks if minpopulation is greater than the given country.
				MinPopulation = countries[i].getPopulation();
			if(countries[i].getPopulation() > MaxPopulation)//Checks if maxpopulation is less than the given country.
				MaxPopulation = countries[i].getPopulation();
		}
	}
	//Once its all done with iterations, it calls for showStatistics with a formatted string.
	showStatistics("Antal länder: " + countries.length + "\n" + "Total befolkning: " + TotalPopulation + "\n"
			+ "Minsta befolkning: " + MinPopulation + ", Största befolkning: " + MaxPopulation);
}
//This method updates the textarea dedicated for the statistics with new data.
public void showStatistics(String statistics)
{
	txtStats.setText(""); //Clears the textarea for the stats.
	txtStats.append(statistics); //Appends a new text given from the parameter.
}
}
