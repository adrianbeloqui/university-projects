import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.Scanner;

public class AirlinesInterface {
	
		// Private string that holds the name of the file where the data is located.
	private String fileName = "airlines.txt";
	
	/* Method that prints the list of airlines in the system.*/
	public void PrintList(){
		ArrayList<Airline> airlinesList = Load();
		for (Airline ap : airlinesList){
			System.out.println(ap.getCode() + " " + ap.getName());
		}
	}
	
	/* Method that checks if an airline's code is already in the system
	 * 
	 * param newAirline: Airline object that is compared to all the airlines in the system.
	 * */
	public Boolean FindDuplicate(Airline newAirline){
		ArrayList<Airline> airlinesList = Load();
		for (Airline ap : airlinesList){
			if (newAirline.getCode().equals(ap.getCode())){
				return true;
			}
		}
		return false;
	}
	
	
	/* Method that stores a new airline into a file.
	 * 
	 * param newAirline: Airline object that is meant to be stored.
	 * */
	public void Store(Airline newAirline){
			// Check for duplicates. If the is a duplicate, let the user know and abort the operation.
		if (FindDuplicate(newAirline)){
			System.out.println("OPERATION ABORTED -- An airline with the code " + newAirline.getCode() + " already exists in the system");
			return;
		}
		
		File outFile = new File(fileName);
	    FileWriter fWriter = null;
		try {
			fWriter = new FileWriter(outFile, true);
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	    PrintWriter pWriter = new PrintWriter(fWriter);
	    pWriter.println(newAirline.getCode() + "," + newAirline.getName());
	    pWriter.close();
	}
	
	/* Method that loads all the airlines stored in a file and puts them in a ArrayList of Airlines. 
	 * The method returns this ArrayList.
	 * */
	public ArrayList<Airline> Load(){
		ArrayList<Airline> airlinesList= new ArrayList<Airline>();
		try
		{
			Scanner in = new Scanner(new File(fileName)); // could give an I/O Exception
			
			// as long as there are terms to process, process them!
			while(in.hasNext())
			{
				Airline newAirline = new Airline();
				String[] line = in.nextLine().split(",");
				newAirline.setCode(line[0]);
				newAirline.setName(line[1]);
				airlinesList.add(newAirline);
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
		return airlinesList;
	}
	
		// AirlinesInterface Constructor
	public AirlinesInterface(){}

}
