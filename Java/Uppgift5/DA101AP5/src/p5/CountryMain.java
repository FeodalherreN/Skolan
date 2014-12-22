//Markus Olsson, AB7158
//Systemutvecklare MAH
package p5;

import javax.swing.SwingUtilities;

public class CountryMain {

	public static void main(String[] args) {
		SwingUtilities.invokeLater( new Runnable() {
			public void run() {
			CountryViewer viewer = new CountryViewer(350, 550);
			CountryIO io = new CountryIO( "C:/java/befolkning.txt" );
			CountryController controller = new CountryController( viewer, io );
			CountryUserInput user = new CountryUserInput(controller, 500, 50 );
			}
			});

	}

}
