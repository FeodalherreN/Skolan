//Markus Olsson, AB7158
//Systemutvecklare MAH
package p5;
import java.io.IOException;
import javax.swing.JOptionPane;

/*
 * This class is the controller for the view. All user interaction with the buttons calls for 
 * this class methods.
 */
public class CountryController {
private CountryViewer viewer; //A instance variable of CountryViewer
private CountryIO inOut; //A instance variable of CountryIO
private Country[] countries; //A instance variable array of Country

public CountryController(CountryViewer piViewer, CountryIO piInOut)
{
	this.viewer = piViewer; //Sets the local CountryViewer to the recieved one.
	this.inOut = piInOut; //Sets the local CountryIO to the recieved one.
}
//This method sets the country array to the array recieved by the method "readCountries" in CountryIO
public void loadCountries() throws IOException
{
	countries = inOut.readCountries();
}
//This method saves the countries to a file by calling the method "saveCountries" in CountryIO
public void saveCountries()
{
	inOut.saveCountries(countries);
}
//This method calls for the viewers method showCountries if the country array is instanciated.
public void showAllCountries()
{
	if(countries != null)
	viewer.showCountries(countries);
}
//This method shows specific countries depending on the minimum population and maximum population variables
//in the parameters.
public void showSelection(long min, long max)
{
	if(countries != null) //Checks if countries is instanciated.
	{
		int matches = 0; //An int to keep track of how many matches it gets.
	for(int i = 0; i < countries.length; i++) //Loops the array.
	{
		if(countries[i].getPopulation() > min && countries[i].getPopulation() < max) //Checks if the countries criteria is met.
		{
			matches++; //Adds to matches if it is met.
		}
	}
	Country[] localCountries = new Country[matches]; // makes a new array of countries with the size of the matches integer.
	int localCount = 0; //A local count variable to keep track on the new arrays index.
	for(int j = 0;j < countries.length; j++) //Loops the array again.
	{
		if(countries[j].getPopulation() > min && countries[j].getPopulation() < max) //If the criteria is met.
		{
			localCountries[localCount] = countries[j]; //Add the country to the new array.
			localCount++; //Add to localcount.
		}
	}
	viewer.showCountries(localCountries); //Call for viewers showCountries method.
	}
}
//This method allows the user to change the populationscore of a country.
public void changePopulation(String country, long population)
{
	int index = -1; //An index with the startvalue of -1.
	Country newCountry = null; //A country.
	for(int i = 0; i < countries.length; i++) //Loop the countries array!
	{
		if(countries[i].getName().equals(country)) //If the countrys name at the specific index equals the given name..
		{
			index = i; //Save the index.
			newCountry = new Country(country, population); //Create a new Country with the specific data.
		}
	}
	if(index != -1) //Checks if there were matches..
	{
		countries[index] = newCountry; //sets the new data to the old array.
		viewer.showCountries(countries); //Calls for viewer.ShowCountries.
	}
	else //If there were no matches...
	{
		JOptionPane.showMessageDialog(null, country + " finns ej i listan med länder"); //Shows this messagedialog.
	}
}
}
