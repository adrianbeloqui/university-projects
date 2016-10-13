import java.util.Scanner;

public class Program {

	/* Main entry to the program */
	public static void main(String[] args) {		
		
			// Instances of each interface of each entity in the program.
		AirportsInterface airportInt = new AirportsInterface();
		AirlinesInterface airlineInt = new AirlinesInterface();
		FlightsInterface flightInt = new FlightsInterface();
		
			// Input scanner of the program
		Scanner input = new Scanner(System.in);
			// Boolean that controls when the user wants to exit the program
		Boolean exit = false;
		
			// While the user does not want to exit the program
		while(!exit){
				// Prompt the user to enter a command line
			System.out.print(">>>");
			String mainLine = input.nextLine();
				// Split the command by blank spaces
			String[] mainLineProcessed = mainLine.split(" ");
			String mainCommand = mainLineProcessed[0];
			String subCommand = null;
				// Switch the first command through the different options "a" (add), "l" (list), "f" (find) and "q" (quit)
			switch(mainCommand){
				case "a":
						// Check if the command has a second command to process, if not, let the user know.
					if (mainLineProcessed.length < 2){
						System.out.println("You must enter a second parameter when adding an airport, airline or flight.");
						break;
					}
					subCommand = mainLineProcessed[1];
						//Switch the second command for adding through the different options "c" (city), "a" (airline) and "f" (flight)
					switch(subCommand){
						case "c":
								// Check if the command has all the parameters required
							if (mainLineProcessed.length < 4){
								System.out.println("When adding an airport a minimum of 4 parameters in total are required.");
								break;
							}
								// Create a new airport, set its properties, and store it.
							Airport airport = new Airport();
							airport.setCode(mainLineProcessed[2]);
							String airportCity = getFullText(3, mainLineProcessed);
							airport.setCity(airportCity);
							airportInt.Store(airport);
							break;
						case "a":
								// Check if the command has all the parameters required
							if (mainLineProcessed.length < 4){
								System.out.println("When adding an airline a minimum of 4 parameters in total are required.");
								break;
							}
								// Create a new airline, set its properties, and store it.
							Airline airline = new Airline();
							airline.setCode(mainLineProcessed[2]);
							String airlineName = getFullText(3, mainLineProcessed);
							airline.setName(airlineName);
							airlineInt.Store(airline);
							break;
						case "f":
								// Check if the command has all the parameters required
							if (mainLineProcessed.length < 6){
								System.out.println("When adding a flight a minimum of 6 parameters in total are required.");
								break;
							}
								// Create a new flight, set its properties, and store it.
							Flight newFlight = new Flight();
							newFlight.setAirlineCode(mainLineProcessed[2]);
							newFlight.setDepartureCityCode(mainLineProcessed[3]);
							newFlight.setDestinationCityCode(mainLineProcessed[4]);
							newFlight.setCost(Integer.parseInt(mainLineProcessed[5]));
							flightInt.Store(newFlight);
							break;
					}
					break;
				case "l":
						// Check if the command has all the parameters required
					if (mainLineProcessed.length < 2){
						System.out.println("You must enter a second parameter when you want to list airports, airlines or flights.");
						break;
					}
					subCommand = mainLineProcessed[1];
						// Switch the second command through the different options for listing.
					switch(subCommand){
					case "c":
							// Print the list of airports
						airportInt.PrintList();
						break;
					case "a":
							// Print the list of airlines
						airlineInt.PrintList();
						break;
					case "f":
							// Print the list of flights
						flightInt.PrintList();
						break;
					}
					break;
				case "f":
						// Check if the command has all the parameters required
					if (mainLineProcessed.length < 4){
						System.out.println("When looking for flights a minimum of 4 parameters in total are required.");
						break;
					}
						// Find all the flights meeting the input of the user
					flightInt.FindFlights(mainLineProcessed[1], mainLineProcessed[2], Integer.parseInt(mainLineProcessed[3]));
					break;
				case "q":
						// Exit the program
					exit = true;
					System.out.println("Bye!");
					break;
			}
		}
		input.close();
	}
	
	/*Method that concatenates string elements of an array into a single string, and returns the result.
	 * 
	 * param index: sets the initial position of the array from which it will start concatenating elements
	 * param textList: string array from which the elements will be concatenated 
	 * */
	private static String getFullText(int index, String[] textList){
		String text = "";
		for (int i=index; i < textList.length; i++){
			text += textList[i];
			if (i != (textList.length - 1)){
				text += " ";
			}
		}
		return text;
	}

}
