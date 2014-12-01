//Markus Olsson
//AB7158

package p3;

import java.util.Random;

import javax.swing.JOptionPane;

public class Exercise3b 
{
    private Runner[] runners; // En array av runnersobjekt
    
    //Denna metoden loopar igenom alla l�pare och fr�gar efter deras namn och skapar objekt av l�paren d�refter.
    public void getRunners(int n) 
    {
    	runners = new Runner[n]; //Skapar en ny l�pare
    	for(int i = 0; i < n; i++)
    	{
    		String str = JOptionPane.showInputDialog( "Ange namn p� l�pare " + (i+1) + "?" ); //En inputdialog som fr�gar efter namn.
    		Runner lopare = new Runner(str); //ny instans av l�paren med namnet som angivits.
    		runners[i] = lopare; // l�gger till l�paren p� positionen i.
    	}
    }
    
    //Simulerar ett race. Varje l�pare i arrayen f�r en slumpad tid.
    public void race(long minTime, long maxTime) 
    {
    	for(int i = 0; i < runners.length; i++)
    	{
       	 Random random = new Random(); //Nytt randomobjekt.
       	 long randomValue = minTime + (long)(random.nextDouble()*(maxTime - minTime)); // genererar en random long.
       	 runners[i].setTime(randomValue); //L�gger till tiden till l�paren.
    	}
    }
    
    //Visar resultatet av l�pningen.
    public void showResults() 
    {
    	String message = "RESULTAT I L�PNINGEN \n";
    	for(int i = 0; i < runners.length; i++)
    	{
    		message += runners[i].toString() + "\n"; //Anv�nder runners.toString metod f�r att f� en formaterad str�ng att l�gga i message.
    	}
    	JOptionPane.showMessageDialog(null, message); //Skriver ut message i en MessageDialog.
    }
    
    public void statistics() 
    {
    	String statistics = "STATISTIK \n";
        int best = 0; //Reserverad int f�r index till den b�sta l�paren i arrayen.
        int worst = 0; //Reserverad int f�r index till den s�msta l�paren i arrayen.
        for(int i = 0; i < runners.length; i++)
        {
          if(runners[i].getTime() > runners[worst].getTime()) //Kollar om l�paren p� position i har s�mre tid �n den p� worst.
           worst = i; //s�fall �r i worst.
         
          else if(runners[i].getTime() < runners[best].getTime()) //Kollar om l�paren p� position i har b�ttre tid �n den p� best.
           best = i; //s�fall �r i best.
        }
        statistics += "B�sta tid: " + runners[best].toString() + "\n"; //skriver ut l�paren med b�st tid.
        statistics += "S�msta tid: " + runners[worst].toString() + "\n"; //skriver ut l�paren med s�mst tid.
        JOptionPane.showMessageDialog(null, statistics); // skriver ut str�ngen statistics via en messagedialog.
    }
}
