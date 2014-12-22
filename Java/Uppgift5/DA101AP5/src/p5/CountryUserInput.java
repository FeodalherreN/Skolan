//Markus Olsson, AB7158
//Systemutvecklare MAH
package p5;
import javax.swing.*;

import java.awt.*;
import java.awt.event.*;
import java.io.IOException;
/*
 * This class handles the userinput in the "CountryUserInput" frame.
 */
public class CountryUserInput extends JPanel {
    private CountryController controller;
    private JFrame frame = new JFrame("CountryUserInput");
    private JButton btnShowAll = new JButton("Visa alla l�nder");
    private JButton btnRead = new JButton("H�mta l�nder");
    private JButton btnWrite = new JButton("Spara l�nder");
    private JButton btnSelection = new JButton("G�r urval");
    private JButton btnChange = new JButton("�ndra");
    private JTextField tfPopulation = new JTextField();
    private JTextField tfCountry = new JTextField();
    private JTextField tfMaximum = new JTextField();
    private JTextField tfMinimum = new JTextField();

    public CountryUserInput(CountryController controller, int x, int y) {
        this.controller = controller;
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setLocation(x,y);
        frame.add(mainPanel());
        frame.pack();
        frame.setVisible(true);
        InitiateGUI();
    }
    /*
     * This method sets the actionlisteners to the buttons.
     * */
    private void InitiateGUI()
    {
    	//This action calls for the changePopulation method in the controller.
    	btnChange.addActionListener(new ActionListener()
    			{
    		@Override
    		public void actionPerformed(ActionEvent e) {
    			//Checks that the necessary textboxes are filled with data.
    			if(tfCountry.getText().equals("") || tfPopulation.getText().equals(""))
    			{
    				JOptionPane.showMessageDialog(null, "Please fill all the necessary fields.");
    			}
    			else
    			{
        			String country = tfCountry.getText(); //gets the country
        			long population = Long.parseLong(tfPopulation.getText()); //gets the new population
        			controller.changePopulation(country, population); //Calls for the method changePopulation in the controller.
    			}
    		}	
    			});
    	//This action calls for the showSelection method in the controller.
    	btnSelection.addActionListener(new ActionListener()
    	{
    		@Override
    		public void actionPerformed(ActionEvent e) {
    			//Checks that the necessary textboxes are filled with data.
    			if(tfMinimum.getText().equals("") || tfMaximum.getText().equals(""))
    			{
    				JOptionPane.showMessageDialog(null, "Please fill all the necessary fields.");
    			}
    			long min = Long.parseLong(tfMinimum.getText()); //Gets the minimum number of citizens.
    			long max = Long.parseLong(tfMaximum.getText());//Gets the maximum number of citizens.
    			controller.showSelection(min, max); //Calls for the method showSelection in the controller.
    		}	
    	});
    	//This action calls for the showCountries method in the controller.
    	btnShowAll.addActionListener(new ActionListener()
    	{
    		@Override
    		public void actionPerformed(ActionEvent e) {
    			controller.showAllCountries(); //Calls for the method showAllCountries in the controller.
    		}	
    	});
    	//This method calls for the method loadCountries in the controller.
    btnRead.addActionListener(new ActionListener()
    {
		@Override
		public void actionPerformed(ActionEvent e) {
			try {
				controller.loadCountries();//Calls for the method loadCountries in the controller.
			} catch (IOException e1) {
				// TODO Auto-generated catch block
				e1.printStackTrace();
			}
		}
    	
    });
  //This method calls for the method saveCountries in the controller.
    btnWrite.addActionListener(new ActionListener()
    {
		@Override
		public void actionPerformed(ActionEvent e) {
			controller.saveCountries();//Calls for the method saveCountries in the controller.
		}
    	
    });
    }
    
    private JPanel mainPanel() {
    	JPanel panel = new JPanel(new BorderLayout());
        panel.add(panelSelection(),BorderLayout.NORTH);
        panel.add(panelChange(),BorderLayout.CENTER);
        panel.add(panelIO(),BorderLayout.SOUTH);
    	return panel;
    }

    /*
     * Skapar panelen i vilken användaren kan ange minsta resp största befolkning, och
     * klicka på knapparna "Gör urval" och "Visa alla länder". När panelen med komponenter
     * är färdig returneras panelen av metoden.
     */
    private JPanel panelSelection() {
        JPanel pnlSelection = new JPanel(new GridLayout(2,3,10,3));
        JLabel lblMin = new JLabel("Minimal befolkning");
        JLabel lblMax = new JLabel("Maximal befolkning");

        pnlSelection.setBorder(BorderFactory.createTitledBorder("Urval"));
        pnlSelection.setPreferredSize(new Dimension(400, 70));
        pnlSelection.add(lblMin);
        pnlSelection.add(lblMax);
        pnlSelection.add(btnShowAll);
        pnlSelection.add(tfMinimum);
        pnlSelection.add(tfMaximum);
        pnlSelection.add(btnSelection);

        return pnlSelection;
    }

    /*
     * Skapar panelen i vilken användaren kan ange ett land och ny befolkning, och
     * klicka på knappen "Ändra". När panelen med komponenter är färdig returneras
     * panelen av metoden.
     */
    private JPanel panelChange() {
        JPanel pnlChange = new JPanel(new GridLayout(2,3,10,3));
        JLabel lblCountry = new JLabel("Land");
        JLabel lblPopulation = new JLabel("Befolkning");
        pnlChange.setBorder(BorderFactory.createTitledBorder("�ndra befolkning"));
        pnlChange.setPreferredSize(new Dimension(400, 70));
        pnlChange.add(lblCountry);
        pnlChange.add(lblPopulation);
        pnlChange.add(new JLabel());
        pnlChange.add(tfCountry);
        pnlChange.add(tfPopulation);
        pnlChange.add(btnChange);

        return pnlChange;
    }
    
    /*
     * Skapar panelen i vilken användaren kan klicka på "Hämta länder" och 
     * "Spara länder". När panelen med komponenter är färdig returneras
     * panelen av metoden.
     */
    private JPanel panelIO() {
        JPanel pnlIO = new JPanel(new GridLayout(1,2,10,0));
        pnlIO.setBorder(BorderFactory.createEmptyBorder(5,5,5,5));
        pnlIO.add(btnRead);
        pnlIO.add(btnWrite);
        return pnlIO;
    }
}

