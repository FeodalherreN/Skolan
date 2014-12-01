//Markus Olsson
//AB7158

package p3;

import java.util.Random;

import javax.swing.JOptionPane;

public class Exercise3b 
{
    private Runner[] runners; // En array av runnersobjekt
    
    //Denna metoden loopar igenom alla löpare och frågar efter deras namn och skapar objekt av löparen därefter.
    public void getRunners(int n) 
    {
    	runners = new Runner[n]; //Skapar en ny löpare
    	for(int i = 0; i < n; i++)
    	{
    		String str = JOptionPane.showInputDialog( "Ange namn på löpare " + (i+1) + "?" ); //En inputdialog som frågar efter namn.
    		Runner lopare = new Runner(str); //ny instans av löparen med namnet som angivits.
    		runners[i] = lopare; // lägger till löparen på positionen i.
    	}
    }
    
    //Simulerar ett race. Varje löpare i arrayen får en slumpad tid.
    public void race(long minTime, long maxTime) 
    {
    	for(int i = 0; i < runners.length; i++)
    	{
       	 Random random = new Random(); //Nytt randomobjekt.
       	 long randomValue = minTime + (long)(random.nextDouble()*(maxTime - minTime)); // genererar en random long.
       	 runners[i].setTime(randomValue); //Lägger till tiden till löparen.
    	}
    }
    
    //Visar resultatet av löpningen.
    public void showResults() 
    {
    	String message = "RESULTAT I LÖPNINGEN \n";
    	for(int i = 0; i < runners.length; i++)
    	{
    		message += runners[i].toString() + "\n"; //Använder runners.toString metod för att få en formaterad sträng att lägga i message.
    	}
    	JOptionPane.showMessageDialog(null, message); //Skriver ut message i en MessageDialog.
    }
    
    public void statistics() 
    {
    	String statistics = "STATISTIK \n";
        int best = 0; //Reserverad int för index till den bästa löparen i arrayen.
        int worst = 0; //Reserverad int för index till den sämsta löparen i arrayen.
        for(int i = 0; i < runners.length; i++)
        {
          if(runners[i].getTime() > runners[worst].getTime()) //Kollar om löparen på position i har sämre tid än den på worst.
           worst = i; //såfall är i worst.
         
          else if(runners[i].getTime() < runners[best].getTime()) //Kollar om löparen på position i har bättre tid än den på best.
           best = i; //såfall är i best.
        }
        statistics += "Bästa tid: " + runners[best].toString() + "\n"; //skriver ut löparen med bäst tid.
        statistics += "Sämsta tid: " + runners[worst].toString() + "\n"; //skriver ut löparen med sämst tid.
        JOptionPane.showMessageDialog(null, statistics); // skriver ut strängen statistics via en messagedialog.
    }
}
