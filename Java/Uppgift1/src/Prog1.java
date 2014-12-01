import javax.swing.JOptionPane;
import java.util.Calendar;

public class Prog1 {

	public static void main(String[] args) {

	}
	// Metoden frågar efter antalet vuxna, barn och pensionärer och
	// beräknar totala biljettkostnaden för personerna och den
	// genomsnittliga biljettkostnaden. Resultatet av beräkningarna
	// meddelas via ett dialogfönster.
	public void price() {
	    String stringvuxna= JOptionPane.showInputDialog("Ange antalet vuxna: "); //Frågar användaren om antalet vuxna och sparar svaret i en sträng
	    String stringbarn= JOptionPane.showInputDialog("Ange antalet barn: ");//Frågar användaren om antalet barn och sparar svaret i en sträng
	    String stringpens= JOptionPane.showInputDialog("Ange antalet pensionärer: ");//Frågar användaren om antalet pensionärer och sparar svaret i en sträng

	    int antalvuxna = Integer.parseInt(stringvuxna);//konverterar svaret för vuxna till int
	    int antalbarn = Integer.parseInt(stringbarn);//konverterar svaret för barn till int
	    int antalpens = Integer.parseInt(stringpens);//konverterar svaret för pensionärer till int
	    
	    int prisforvuxna = 110; //hårdkodat pris för vuxna
	    int prisforbarn = 60;//hårdkodat pris för barn
	    int prisforpens = 80;//hårdkodat pris för pensionärer
	    
	    int sum = (antalvuxna * prisforvuxna) + (antalbarn * prisforbarn) + (antalpens * prisforpens); //multiplicerar antal deltagare med respektive pris och plusar ihop resultatet.
	    int medelpris = sum/(antalvuxna + antalbarn + antalpens); //totalkostanden delat på antalet deltagare ger medelpriset.
	    JOptionPane.showMessageDialog(null, "Totala kostnaden: " + sum + "kr." + " Medelpriset: " + medelpris + "kr."); //skriver ut resultatet lite fint.
	} 
	//Metoden hämtar information från den inbyggda kalendern och skriver ut lite information om dagens datum och tid.
	public void date()
	{
		Calendar cal = Calendar.getInstance(); //skapar en instans av kalendern.
		int hourOfDay = cal.get(Calendar.HOUR_OF_DAY); // hämtar ut den nuvarande timmen.
		int minuteOfDay = cal.get(Calendar.MINUTE);// hämtar ut den nuvarande minuten.
		int secondOfDay = cal.get(Calendar.SECOND);// hämtar ut den nuvarande sekunden.
		int Date = cal.get(Calendar.DATE); // hämtar ut det nuvarande datumet i månaden.
		int Month = cal.get(Calendar.MONTH);// hämtar ut den nuvarande månaden.
		int Year = cal.get(Calendar.YEAR);// hämtar ut det nuvarande året.
		System.out.println("Timme: " + hourOfDay + "\nMinut: " + minuteOfDay + "\nSekund: " + secondOfDay + "\nDatum: " + Date
				+ "/" + (Month + 1) + " - " + Year); // skriver ut resultatet lite fint.
	}
	//Metoden skriver ut ojämna nummer mellan 0-100.
	public void odd()
	{
		for(int i=0; i<101; i++) // loopar fram tills i är 100 (dvs mindre än 101).
		{
			if (i % 2 != 0)  //om modulus från i inte är lika med 0 så är talet ojämnt.
			{
				System.out.println(i + " "); //printar ut talet om det är ojämnt.
			} 
		}
	}
	//Metoden begär att man matar in 4 tal. Därefter avgör den om talen är negativa, positiva eller noll.
	public void positiveNegative()
	{
		for(int i = 0; i<4; i++) // sålänge i inte är större än fyra så...
		{
			String tal = JOptionPane.showInputDialog("Mata in ett tal."); //Hänvisar användaren att mata in ett tal.
			int intTal = Integer.parseInt(tal); //konverterar svaret användaren ger till integer. 
		    if( intTal == 0) //Om talet är lika med 0 så är det noll.
		    { System.out.println("Number" + intTal + " is equal to zero"); }
		    else if (intTal > 0)//Om talet är större än noll så.. är det positivt.
		    { System.out.println("Number" + intTal + " is positive"); }
		    else //om talet varken är noll eller positivt så är det negativt.
		    { System.out.println("Number" + intTal + " is negative"); }
		}
	}
	//Metoden tar emot ett min värde och ett max värde och printar ut var 7:de siffra emellan dem. 
	public void series7(int min, int max)
	{
		int count = 0; //en int som används för att räkna upp till 7.
		String temp = ""; //temporär sträng för att lägga in nummerna i.
		temp += min+", "; //först läggs min in i strängen och ett kommatecken. 
		for(int i = min; i<=max; i++) // i är min. Sålänge i är mindre än eller lika med max så körs loopen.
		{
			if(count == 7) // om count är 7...
			{
				temp += i+", "; //om count är 7 så läggs siffran till i strängen.
				count = 1; //count återställs.
			}
			else // om count inte är 7...
			{
				count++; // Om count inte är 7 så adderas count med 1.
			}
		}
		String result = temp.substring(0,temp.length()-2); //Tar temp strängen och tar bort de 2 sista charsen i den, dvs ", " i detta fallet.
		System.out.println(result); //printar ut resultatet.
	}
	//Tar emot en siffra som kallas table. Därefter multipliceras siffran mellan min och max värdet och printas sedan ut.
	public void table(int table, int min, int max) 
	{
		for(int i = min; i<=max; i++) // i sätts till min värdet. Sålänge i är mindre än max så adderar man i med 1.
		{
			int calculatedNr = i*table; //tar i och gångar med siffran som man valt.
			System.out.println(i + " * " + table + " = " + calculatedNr); // Printar ut resultatet.
		}
	}
	//Metoden beräknar och skriver ut hur ett kapital växer med ränta på ränta under
	//ett visst antal år. Varje år visas beloppet vid årets början, årets ränta och slutligen beloppet vid årets
	//slut.
	public void balance(double capital, double interest, int years)
	{
		double oldCapital;//sparar undan de föregående årets kapital.
		double newInterest; //sparar undan den nya räntan. 
		for(int i  = 1; i<=years; i++) //Loopar x gånger antal år man angivit.
		{
			newInterest = capital * interest; //Den nya räntan är samma som kapitalet multiplicerat med räntan.
			oldCapital = capital; //Det nuvarande kapitalet sparas undan.
			capital = capital + newInterest; //Ökar kapitalet med räntan.
			String str = String.format( "%2d%12.2f%12.2f%12.2f", i, oldCapital, newInterest, capital); //formaterar doublesen så att de bara har 2 decimaler.
			System.out.println(str); //skriver ut den formaterade strängen.
		}
	}
	//Metoden delar upp ett tals siffor och adderar dem.
	public void sum(int number)
	{
        int sum = 0;  //Integer reserverad för summan.
        while ( number > 0 )  //sålänge det angivna nummret är större än noll så..
        {  
            sum += number % 10;  //modulus utav nummert och 10 läggs till i sum.
            number /= 10; //delar nummert med 10 och ger den dess resultat.
        }
        System.out.println("sum: " + sum); //printar ut resultatet.
	}
	//Tar emot ett nummer och en intervall mellan min och max. Därefter adderas min med nummer tills max är nådd. Därefter adderas 
	//alla nummer som skapats däremellan och printar ut ett resultat.
	public void sumN(int number, int min, int max)
	{
		int newMin = min; // newmin sätts till min.
		int sum = min; // summan sätts till min.
		String values = min + ", "; //En sträng för alla värdena där min läggs till direkt. 
		while (newMin<max) //sålänge min är mindre än max så...
		{
			newMin = newMin + number; //number adderas på newmin.
			if(newMin>max)//om newmin nu är större än max så läggs den varken till i summan eller values strängen. Den breakas då..
			{
				break;
			}
			sum = sum + newMin; // newmin adderas på summan.
			values += newMin + ", "; // newmin läggs till i values.
		}
		String result = values.substring(0,values.length()-2); //Strängen cuttas. De två sista charsen tas bort, dvs ", ".
		System.out.println(result + " = " + sum); // resultatet av värdena och summan printas ut. 
	}
	//metod som räknar ut fakulteten av ett nummer, dvs alla nummer upp till det angivna nummert multipliceras.
	public void factorial(int n)
	{
		if(n<0) //om n är mindre än noll så är argumentet felaktigt.
		{
			System.out.println("Felaktigt argument: " + n);
		}
		else //annars!!! 
		{
			String Values = "";//sträng reserverad för alla värdena.
			int result = 1; // resultat int.
		       for (int i = 1; i <= n; i++) //loopar från 1 till det angivna nummert.
		       {
		           result = result * i; // multiplicerar resultatet med i.
		           Values += i + "*"; // i läggs till i values strängen.
		       }
		       String res = Values.substring(0,Values.length()-1); // tar bort sista kommatecknet ur valuessträngen.
		       System.out.println(res + " = " + result); // printar ut resultatet.
		}
	}
}
