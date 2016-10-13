import java.io.*;
import java.util.Scanner;
import java.util.ArrayList;

public class AirportsInterface {
	
		// Private string that holds the name of the file where the data is located.
	private String fileName = "airports.txt";
	
	/* Method that prints the list of airports in the system.*/
	public void PrintList(){
		ArrayList<Airport> airportsList = Load();
		for (Airport ap : airportsList){
			System.out.println(ap.getCode() + " " + ap.getCity());
		}
	}
	
	/* Method that checks if an airport's code is already in the system
	 * 
	 * param newAirport: Airport object that is compared to all the airports in the system.
	 * */
	public Boolean FindDuplicate(Airport newAirport){
		ArrayList<Airport> airportsList = Load();
		for (Airport ap : airportsList){
			if (newAirport.getCode().equals(ap.getCode())){
				return true;
			}
		}
		return false;
	}
	
	/* Method that stores a new airport into a file.
	 * 
	 * param newAirport: Airport object that is meant to be stored.
	 * */
	public void Store(Airport newAirport){
			// Check for duplicates. If the is a duplicate, let the user know and abort the operation.
		if (FindDuplicate(newAirport)){
			System.out.println("OPERATION ABORTED -- An airport with the code " + newAirport.getCode() + " already exists in the system");
			return;
		}
		
		File outFile = new File (fileName);
	    FileWriter fWriter = null;
		try {
			fWriter = new FileWriter(outFile, true);
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	    PrintWriter pWriter = new PrintWriter(fWriter);
	    pWriter.println(newAirport.getCode() + "," + newAirport.getCity());
	    pWriter.close();
	}
	
	
	/* Method that loads all the airports stored in a file and puts them in a ArrayList of Airports. 
	 * The method returns this ArrayList.
	 * */
	public ArrayList<Airport> Load(){
		ArrayList<Airport> airportsList= new ArrayList<Airport>();
		try
		{
			Scanner in = new Scanner(new File(fileName)); // could give an I/O Exception
				
				// as long as there are terms to process, process them!
			while(in.hasNext())
			{
				Airport newAirport = new Airport();
				String[] line = in.nextLine().split(",");
				newAirport.setCode(line[0]);
				newAirport.setCity(line[1]);
				airportsList.add(newAirport);
			}
			in.close();
		}
		catch (IOException exception)
		{
				// Create the file
			try {
				PrintWriter outFile = new PrintWriter(fileName);
				outFile.close();
			} catch (FileNotFoundException e1) {
				// TODO Auto-generated catch block
				e1.printStackTrace();
			}
		}
		return airportsList;
	}
	
		// AirportsInterface Constructor
	public AirportsInterface(){}
	

}
