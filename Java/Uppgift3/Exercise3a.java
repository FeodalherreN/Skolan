//Markus Olsson
//AB7158

package p3;
import java.util.Arrays;

public class Exercise3a 
{
	// max vilken returnerar st�rsta v�rdet i en heltalsarray.
	public int max(int[] array)
	{
	      int maxValue = array[0];   //S�tter f�rsta till max
	      for(int i=1;i < array.length;i++)
	      {  
	      if(array[i] > maxValue) //loopar sen igenom alla andra och kollar om de �r st�rre, ers�tter int maxvalue s�fall.
	      maxValue = array[i];
	      }
	      return maxValue;
	}
	//min vilken returnerar minsta v�rdet i en heltalsarray.
	public int min(int[] array)
	{
	      int minValue = array[0];  //S�tter f�rsta till min
	      for(int i=1;i < array.length;i++)
	      {  
	      if(array[i] < minValue) //loopar sen igenom alla andra och kollar om de �r mindre, ers�tter int minvalue s�fall.
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
			totalsum = totalsum + array[i]; //loopar igenom arrayen och l�gger p� v�rdena i totalsum.
		}
		return totalsum;
	}
	//average vilken returnerar medelv�rdet av talen i en heltalsarray. Observera att medelv�rdet ska
	//vara flyttalstyp.
	public float average(int[] array)
	{
		float totalsum = sum(array); //h�mtar summan av arrayen
		float totalcount = count(array); //r�knar ut hur m�nga v�rden arrayen har
		return totalsum/totalcount; // summan/m�ngden
	}
	//r�knar ut hur m�nga tal en array har.
	public int count(int[] array)
	{
		int total = 0;
		for(int i = 0; i < array.length; i++) //loopar igenom arrayen och r�knar hur m�nga tal den har.
		{
			total++;
		}
		return total;
	}
	//sortAsc vilken sorterar talen i en heltalsarray v�xande, t.ex. {3,7,34,89}
	public int[] sortAsc(int[] array)
	{
		Arrays.sort(array); // sorterar arrayen med sortascending
		return array;
	}
	//sortDesc vilken sorterar talen i en heltalsarray avtagande, t.ex. {89,34,7,3}
	public int[] sortDesc(int[] array)
	{
		int[] sortedarray = sortAsc(array); // f�rst sorteras arrayen med sortasc.
	    for (int i=0; i < sortedarray.length / 2; i++) //nu speglas arrayen och byter plats p� alla v�rden.
	    {   
	        int temp = sortedarray[i];
	        sortedarray[i] = array[sortedarray.length - i - 1];
	        sortedarray[sortedarray.length - i - 1] = temp;
	    }
	    array = sortedarray;
		return array;
	}
	//copy vilken returnerar en kopia av en heltalsarray. Eftersom metoden ska returnera en ny array
	//m�ste denna skapas inuti metoden.
	public int[] copy(int[] array)
	{
		int[] copyarray = new int[array.length]; // g�r en ny array med arrays storlek
		System.arraycopy( array, 0, copyarray, 0, array.length ); // kopierar arrayen till copyarray.
		return copyarray;
	}
	//toString vilken ska returnera en heltals-array som en str�ng. Str�ngen ska vara p� formen
	//"{3,7,4,5}" dvs med inledande parentes, sedan talen uppr�knade med komma-tecken som
	//avgr�nsare, och slutligen en avslutande parentes.
	public String toString(int[] array)
	{
		String result = "{"; //str�ngen som ska returneras instansieras.
		for(int i = 0; i < array.length; i++)
		{
			result += array[i]; // l�gger till nummret p� position i.
			result += ","; // l�gger till ett komma efter.
		}
		result = result.substring(0,result.length()-1); // sista kommat tas bort.
		result += "}"; // en sluthakparantes l�ggs till i slutet.
		return result;
	}
}
