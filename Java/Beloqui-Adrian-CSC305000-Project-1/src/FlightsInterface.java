import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.Scanner;

public class FlightsInterface {
	
		// Private string that holds the name of the file where the data is located.
	private String fileName = "flights.txt";
	
	/* Method that looks for flights options based on the flights stored in the system. 
	 * For each flight found that meets the requirements passed in the parameters, the method
	 * prints a line with the required information.
	 * 
	 * param departureCity: string representing the city code from where the user wants to departure
	 * param arrivalCity: string representing the city code to where the user wants to go
	 * param connections: number of connections desired by the user.
	 * */
	public void FindFlights(String departureCity, String arrivalCity, int connections){
		
			// Check if the cities entered by the user exist in the system.
		if(!FindCity(departureCity)){
			return;
		}
		if (!FindCity(arrivalCity)){
			return;
		}
		
			// If the user only wants direct flights.
		if (connections == 0){
				// Look for flights with the same departure and arrival city as the user asked for and print each option.
			ArrayList<Flight> flightsList = Load();
			for (Flight fl : flightsList){
				if (fl.getDepartureCityCode().equals(departureCity) && fl.getDestinationCityCode().equals(arrivalCity)){
					System.out.println(departureCity + " -> " + arrivalCity + " : " + fl.getAirlineCode() + " $" + fl.getCost());
				}
			}
		}
		 // If the user wants flights with one connection.
		if (connections == 1){
			ArrayList<Flight> flightsList = Load();
			ArrayList<Flight> matchingDepartureFlights = new ArrayList<Flight>();
			ArrayList<Flight> matchingArrivalFlights = new ArrayList<Flight>();
			
				// Divide all the flights into two groups. The ones that has the same departure city as the user asked for,
				// and the ones that has the same arrival city as the user asked for.
			for (Flight fl : flightsList){
				if (fl.getDepartureCityCode().equals(departureCity)){
					matchingDepartureFlights.add(fl);
				}
				if (fl.getDestinationCityCode().equals(arrivalCity)){
					matchingArrivalFlights.add(fl);
				}
			}
				// For each flight that departs from the same departure city as the user asked for, find a flight that goes from
				// the arrival city of this flight to the arrival city that the user asked for. If a match is found, print the information
				// as required.
			for (Flight con1 : matchingDepartureFlights){
				for (Flight con2 : matchingArrivalFlights){
					if (con1.getDestinationCityCode().equals(con2.getDepartureCityCode())){
						int total = con1.getCost() + con2.getCost();
						System.out.print(con1.getDepartureCityCode() + " -> " + con1.getDestinationCityCode() + " : " + con1.getAirlineCode() + " $" + con1.getCost() + "; ");
						System.out.print(con2.getDepartureCityCode() + " -> " + con2.getDestinationCityCode() + " : " + con2.getAirlineCode() + " $" + con2.getCost() + ", ");
						System.out.println("for a total cost of $" + total);
					}
				}
			}
		}
		
	}
	
	/* Method that prints the list of flights in the system.*/
	public void PrintList(){
		ArrayList<Flight> flightsList = Load();
		for (Flight fl : flightsList){
			AirlinesInterface airlineInt = new AirlinesInterface();
			AirportsInterface airportInt = new AirportsInterface();
			
			String airlineName = null;
			String departureCityName = null;
			String destinationCityName = null;
			
			for (Airline al : airlineInt.Load()){
				if (fl.getAirlineCode().equals(al.getCode())){
					airlineName = al.getName();
					break;
				}
			}
			
			for (Airport ap : airportInt.Load()){
				if (fl.getDepartureCityCode().equals(ap.getCode())){
					departureCityName = ap.getCity();
				}
			}
			
			for (Airport ap : airportInt.Load()){
				if (fl.getDestinationCityCode().equals(ap.getCode())){
					destinationCityName = ap.getCity();
				}
			}
			
			System.out.println(airlineName + ": " + departureCityName + " -> " + destinationCityName + " $" + fl.getCost());
		}
	}
	
	/* Method that checks if a city code is stored in the system.
	 * 
	 * param cityCode: String representing the city code that the search is based on.
	 * */
	private Boolean FindCity(String cityCode){
		AirportsInterface airportInt = new AirportsInterface();
		Boolean found = false;
		
			// Look in the system if there is a city with the same code as the one in the parameter.
		found = false;
		for (Airport ap : airportInt.Load()){
			if (cityCode.equals(ap.getCode())){
				found = true;
				break;
			}
		}
			// If no city was found in the system, let the user know.
		if (!found){
			System.out.println("OPERATION ABORTED -- An city with the code " + cityCode + " does not exist in the system");
		}
		return found;
	}
	
	/*Method that checks if a flight's airline and cities exist in the system.
	 * 
	 * param newFlight: Flight object that the search is based on.
	 * */
	private Boolean FindRelations(Flight newFlight){
		AirlinesInterface airlineInt = new AirlinesInterface();
		Boolean found = false;
		
			// Look for an airline in the system that has the same code as the flight's airline.
		for (Airline al : airlineInt.Load()){
			if (newFlight.getAirlineCode().equals(al.getCode())){
				found = true;
				break;
			}
		}
		
			// Let the user know if there is such airline in the system.
		if (!found){
			System.out.println("OPERATION ABORTED -- An airline with the code " + newFlight.getAirlineCode() + " does not exist in the system");
			return false;
		}
		
			// Check if the flight's cities are in the system.
		if (!FindCity(newFlight.getDepartureCityCode())){
			return false;
		}
			// Check if the flight's cities are in the system.
		if (!FindCity(newFlight.getDestinationCityCode())){
			return false;
		}
		
		return true;
	}
	
	/* Method that checks if an flight is already in the system
	 * 
	 * param newFlight: Flight object that is compared to all the flights in the system.
	 * */
	public Boolean FindDuplicate(Flight newFlight){
		ArrayList<Flight> flightsList = Load();
		for (Flight fl : flightsList){
			if (newFlight.getAirlineCode().equals(fl.getAirlineCode()) && newFlight.getDepartureCityCode().equals(fl.getDepartureCityCode())
					&& newFlight.getDestinationCityCode().equals(fl.getDestinationCityCode()) && newFlight.getCost() == fl.getCost()){
				return true;
			}
		}
		return false;
	}
	
	
	/* Method that stores a new flight into a file.
	 * 
	 * param newFlight: Flight object that is meant to be stored.
	 * */
	public void Store(Flight newFlight){
		if (!FindRelations(newFlight)){
			return;
		}
		
		if (FindDuplicate(newFlight)){
			System.out.println("OPERATION ABORTED -- A flight with the exact same information is already stored in the system.");
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
	    pWriter.println(newFlight.getAirlineCode() + "," + newFlight.getDepartureCityCode() + "," + newFlight.getDestinationCityCode() + "," + newFlight.getCost());
	    pWriter.close();
	}
	
	/* Method that loads all the flights stored in a file and puts them in a ArrayList of Flights. 
	 * The method returns this ArrayList.
	 * */
	public ArrayList<Flight> Load(){
		ArrayList<Flight> flightsList= new ArrayList<Flight>();
		try
		{
			Scanner in = new Scanner(new File(fileName)); // could give an I/O Exception
			
				// as long as there are terms to process, process them!
			while(in.hasNext())
			{
				Flight newFlight = new Flight();
				String[] line = in.nextLine().split(",");
				newFlight.setAirlineCode(line[0]);
				newFlight.setDepartureCityCode(line[1]);
				newFlight.setDestinationCityCode(line[2]);
				newFlight.setCost(Integer.parseInt(line[3]));
				flightsList.add(newFlight);
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
		return flightsList;
	}
	
		// FlightsInterface Constructor
	public FlightsInterface(){}

}
