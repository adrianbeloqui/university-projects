
public class Flight {
	
	private String airlineCode;
	private String departureCityCode;
	private String destinationCityCode;
	private int cost;
	
	public void setAirlineCode(String newAirlineCode){
		airlineCode = newAirlineCode;
	}
	
	public void setDepartureCityCode(String newDepartureCityCode){
		departureCityCode = newDepartureCityCode;
	}
	
	public void setDestinationCityCode(String newDestinationCityCode){
		destinationCityCode = newDestinationCityCode;
	}
	
	public void setCost(int newCost){
		cost = newCost;
	}
	
	public String getAirlineCode(){
		return airlineCode;
	}
	
	public String getDepartureCityCode(){
		return departureCityCode;
	}
	
	public String getDestinationCityCode(){
		return destinationCityCode;
	}
	
	public int getCost(){
		return cost;
	}
	
		// Flight Constructor
	public Flight(){}

}
