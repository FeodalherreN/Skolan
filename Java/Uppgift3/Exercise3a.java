//Markus Olsson
//AB7158

package p3;
import java.util.Arrays;

public class Exercise3a 
{
	// max vilken returnerar största värdet i en heltalsarray.
	public int max(int[] array)
	{
	      int maxValue = array[0];   //Sätter första till max
	      for(int i=1;i < array.length;i++)
	      {  
	      if(array[i] > maxValue) //loopar sen igenom alla andra och kollar om de är större, ersätter int maxvalue såfall.
	      maxValue = array[i];
	      }
	      return maxValue;
	}
	//min vilken returnerar minsta värdet i en heltalsarray.
	public int min(int[] array)
	{
	      int minValue = array[0];  //Sätter första till min
	      for(int i=1;i < array.length;i++)
	      {  
	      if(array[i] < minValue) //loopar sen igenom alla andra och kollar om de är mindre, ersätter int minvalue såfall.
	    	  minValue = array[i];
	      }
	      return minValue;
	}
	//sum vilken returnerar summan av talen i en heltalsarray.
	public int sum(int[] array)
	{
		int totalsum = 0;
		for(int i = 0; i < array.length; i++)
		{
			totalsum = totalsum + array[i]; //loopar igenom arrayen och lägger på värdena i totalsum.
		}
		return totalsum;
	}
	//average vilken returnerar medelvärdet av talen i en heltalsarray. Observera att medelvärdet ska
	//vara flyttalstyp.
	public float average(int[] array)
	{
		float totalsum = sum(array); //hämtar summan av arrayen
		float totalcount = count(array); //räknar ut hur många värden arrayen har
		return totalsum/totalcount; // summan/mängden
	}
	//räknar ut hur många tal en array har.
	public int count(int[] array)
	{
		int total = 0;
		for(int i = 0; i < array.length; i++) //loopar igenom arrayen och räknar hur många tal den har.
		{
			total++;
		}
		return total;
	}
	//sortAsc vilken sorterar talen i en heltalsarray växande, t.ex. {3,7,34,89}
	public int[] sortAsc(int[] array)
	{
		Arrays.sort(array); // sorterar arrayen med sortascending
		return array;
	}
	//sortDesc vilken sorterar talen i en heltalsarray avtagande, t.ex. {89,34,7,3}
	public int[] sortDesc(int[] array)
	{
		int[] sortedarray = sortAsc(array); // först sorteras arrayen med sortasc.
	    for (int i=0; i < sortedarray.length / 2; i++) //nu speglas arrayen och byter plats på alla värden.
	    {   
	        int temp = sortedarray[i];
	        sortedarray[i] = array[sortedarray.length - i - 1];
	        sortedarray[sortedarray.length - i - 1] = temp;
	    }
	    array = sortedarray;
		return array;
	}
	//copy vilken returnerar en kopia av en heltalsarray. Eftersom metoden ska returnera en ny array
	//måste denna skapas inuti metoden.
	public int[] copy(int[] array)
	{
		int[] copyarray = new int[array.length]; // gör en ny array med arrays storlek
		System.arraycopy( array, 0, copyarray, 0, array.length ); // kopierar arrayen till copyarray.
		return copyarray;
	}
	//toString vilken ska returnera en heltals-array som en sträng. Strängen ska vara på formen
	//"{3,7,4,5}" dvs med inledande parentes, sedan talen uppräknade med komma-tecken som
	//avgränsare, och slutligen en avslutande parentes.
	public String toString(int[] array)
	{
		String result = "{"; //strängen som ska returneras instansieras.
		for(int i = 0; i < array.length; i++)
		{
			result += array[i]; // lägger till nummret på position i.
			result += ","; // lägger till ett komma efter.
		}
		result = result.substring(0,result.length()-1); // sista kommat tas bort.
		result += "}"; // en sluthakparantes läggs till i slutet.
		return result;
	}
}
