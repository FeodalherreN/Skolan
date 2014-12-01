import javax.swing.JOptionPane;
import java.util.Calendar;

public class Prog1 {

	public static void main(String[] args) {

	}
	// Metoden fr�gar efter antalet vuxna, barn och pension�rer och
	// ber�knar totala biljettkostnaden f�r personerna och den
	// genomsnittliga biljettkostnaden. Resultatet av ber�kningarna
	// meddelas via ett dialogf�nster.
	public void price() {
	    String stringvuxna= JOptionPane.showInputDialog("Ange antalet vuxna: "); //Fr�gar anv�ndaren om antalet vuxna och sparar svaret i en str�ng
	    String stringbarn= JOptionPane.showInputDialog("Ange antalet barn: ");//Fr�gar anv�ndaren om antalet barn och sparar svaret i en str�ng
	    String stringpens= JOptionPane.showInputDialog("Ange antalet pension�rer: ");//Fr�gar anv�ndaren om antalet pension�rer och sparar svaret i en str�ng

	    int antalvuxna = Integer.parseInt(stringvuxna);//konverterar svaret f�r vuxna till int
	    int antalbarn = Integer.parseInt(stringbarn);//konverterar svaret f�r barn till int
	    int antalpens = Integer.parseInt(stringpens);//konverterar svaret f�r pension�rer till int
	    
	    int prisforvuxna = 110; //h�rdkodat pris f�r vuxna
	    int prisforbarn = 60;//h�rdkodat pris f�r barn
	    int prisforpens = 80;//h�rdkodat pris f�r pension�rer
	    
	    int sum = (antalvuxna * prisforvuxna) + (antalbarn * prisforbarn) + (antalpens * prisforpens); //multiplicerar antal deltagare med respektive pris och plusar ihop resultatet.
	    int medelpris = sum/(antalvuxna + antalbarn + antalpens); //totalkostanden delat p� antalet deltagare ger medelpriset.
	    JOptionPane.showMessageDialog(null, "Totala kostnaden: " + sum + "kr." + " Medelpriset: " + medelpris + "kr."); //skriver ut resultatet lite fint.
	} 
	//Metoden h�mtar information fr�n den inbyggda kalendern och skriver ut lite information om dagens datum och tid.
	public void date()
	{
		Calendar cal = Calendar.getInstance(); //skapar en instans av kalendern.
		int hourOfDay = cal.get(Calendar.HOUR_OF_DAY); // h�mtar ut den nuvarande timmen.
		int minuteOfDay = cal.get(Calendar.MINUTE);// h�mtar ut den nuvarande minuten.
		int secondOfDay = cal.get(Calendar.SECOND);// h�mtar ut den nuvarande sekunden.
		int Date = cal.get(Calendar.DATE); // h�mtar ut det nuvarande datumet i m�naden.
		int Month = cal.get(Calendar.MONTH);// h�mtar ut den nuvarande m�naden.
		int Year = cal.get(Calendar.YEAR);// h�mtar ut det nuvarande �ret.
		System.out.println("Timme: " + hourOfDay + "\nMinut: " + minuteOfDay + "\nSekund: " + secondOfDay + "\nDatum: " + Date
				+ "/" + (Month + 1) + " - " + Year); // skriver ut resultatet lite fint.
	}
	//Metoden skriver ut oj�mna nummer mellan 0-100.
	public void odd()
	{
		for(int i=0; i<101; i++) // loopar fram tills i �r 100 (dvs mindre �n 101).
		{
			if (i % 2 != 0)  //om modulus fr�n i inte �r lika med 0 s� �r talet oj�mnt.
			{
				System.out.println(i + " "); //printar ut talet om det �r oj�mnt.
			} 
		}
	}
	//Metoden beg�r att man matar in 4 tal. D�refter avg�r den om talen �r negativa, positiva eller noll.
	public void positiveNegative()
	{
		for(int i = 0; i<4; i++) // s�l�nge i inte �r st�rre �n fyra s�...
		{
			String tal = JOptionPane.showInputDialog("Mata in ett tal."); //H�nvisar anv�ndaren att mata in ett tal.
			int intTal = Integer.parseInt(tal); //konverterar svaret anv�ndaren ger till integer. 
		    if( intTal == 0) //Om talet �r lika med 0 s� �r det noll.
		    { System.out.println("Number" + intTal + " is equal to zero"); }
		    else if (intTal > 0)//Om talet �r st�rre �n noll s�.. �r det positivt.
		    { System.out.println("Number" + intTal + " is positive"); }
		    else //om talet varken �r noll eller positivt s� �r det negativt.
		    { System.out.println("Number" + intTal + " is negative"); }
		}
	}
	//Metoden tar emot ett min v�rde och ett max v�rde och printar ut var 7:de siffra emellan dem. 
	public void series7(int min, int max)
	{
		int count = 0; //en int som anv�nds f�r att r�kna upp till 7.
		String temp = ""; //tempor�r str�ng f�r att l�gga in nummerna i.
		temp += min+", "; //f�rst l�ggs min in i str�ngen och ett kommatecken. 
		for(int i = min; i<=max; i++) // i �r min. S�l�nge i �r mindre �n eller lika med max s� k�rs loopen.
		{
			if(count == 7) // om count �r 7...
			{
				temp += i+", "; //om count �r 7 s� l�ggs siffran till i str�ngen.
				count = 1; //count �terst�lls.
			}
			else // om count inte �r 7...
			{
				count++; // Om count inte �r 7 s� adderas count med 1.
			}
		}
		String result = temp.substring(0,temp.length()-2); //Tar temp str�ngen och tar bort de 2 sista charsen i den, dvs ", " i detta fallet.
		System.out.println(result); //printar ut resultatet.
	}
	//Tar emot en siffra som kallas table. D�refter multipliceras siffran mellan min och max v�rdet och printas sedan ut.
	public void table(int table, int min, int max) 
	{
		for(int i = min; i<=max; i++) // i s�tts till min v�rdet. S�l�nge i �r mindre �n max s� adderar man i med 1.
		{
			int calculatedNr = i*table; //tar i och g�ngar med siffran som man valt.
			System.out.println(i + " * " + table + " = " + calculatedNr); // Printar ut resultatet.
		}
	}
	//Metoden ber�knar och skriver ut hur ett kapital v�xer med r�nta p� r�nta under
	//ett visst antal �r. Varje �r visas beloppet vid �rets b�rjan, �rets r�nta och slutligen beloppet vid �rets
	//slut.
	public void balance(double capital, double interest, int years)
	{
		double oldCapital;//sparar undan de f�reg�ende �rets kapital.
		double newInterest; //sparar undan den nya r�ntan. 
		for(int i  = 1; i<=years; i++) //Loopar x g�nger antal �r man angivit.
		{
			newInterest = capital * interest; //Den nya r�ntan �r samma som kapitalet multiplicerat med r�ntan.
			oldCapital = capital; //Det nuvarande kapitalet sparas undan.
			capital = capital + newInterest; //�kar kapitalet med r�ntan.
			String str = String.format( "%2d%12.2f%12.2f%12.2f", i, oldCapital, newInterest, capital); //formaterar doublesen s� att de bara har 2 decimaler.
			System.out.println(str); //skriver ut den formaterade str�ngen.
		}
	}
	//Metoden delar upp ett tals siffor och adderar dem.
	public void sum(int number)
	{
        int sum = 0;  //Integer reserverad f�r summan.
        while ( number > 0 )  //s�l�nge det angivna nummret �r st�rre �n noll s�..
        {  
            sum += number % 10;  //modulus utav nummert och 10 l�ggs till i sum.
            number /= 10; //delar nummert med 10 och ger den dess resultat.
        }
        System.out.println("sum: " + sum); //printar ut resultatet.
	}
	//Tar emot ett nummer och en intervall mellan min och max. D�refter adderas min med nummer tills max �r n�dd. D�refter adderas 
	//alla nummer som skapats d�remellan och printar ut ett resultat.
	public void sumN(int number, int min, int max)
	{
		int newMin = min; // newmin s�tts till min.
		int sum = min; // summan s�tts till min.
		String values = min + ", "; //En str�ng f�r alla v�rdena d�r min l�ggs till direkt. 
		while (newMin<max) //s�l�nge min �r mindre �n max s�...
		{
			newMin = newMin + number; //number adderas p� newmin.
			if(newMin>max)//om newmin nu �r st�rre �n max s� l�ggs den varken till i summan eller values str�ngen. Den breakas d�..
			{
				break;
			}
			sum = sum + newMin; // newmin adderas p� summan.
			values += newMin + ", "; // newmin l�ggs till i values.
		}
		String result = values.substring(0,values.length()-2); //Str�ngen cuttas. De tv� sista charsen tas bort, dvs ", ".
		System.out.println(result + " = " + sum); // resultatet av v�rdena och summan printas ut. 
	}
	//metod som r�knar ut fakulteten av ett nummer, dvs alla nummer upp till det angivna nummert multipliceras.
	public void factorial(int n)
	{
		if(n<0) //om n �r mindre �n noll s� �r argumentet felaktigt.
		{
			System.out.println("Felaktigt argument: " + n);
		}
		else //annars!!! 
		{
			String Values = "";//str�ng reserverad f�r alla v�rdena.
			int result = 1; // resultat int.
		       for (int i = 1; i <= n; i++) //loopar fr�n 1 till det angivna nummert.
		       {
		           result = result * i; // multiplicerar resultatet med i.
		           Values += i + "*"; // i l�ggs till i values str�ngen.
		       }
		       String res = Values.substring(0,Values.length()-1); // tar bort sista kommatecknet ur valuesstr�ngen.
		       System.out.println(res + " = " + result); // printar ut resultatet.
		}
	}
}
