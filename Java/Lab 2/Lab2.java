import java.util.GregorianCalendar;
import java.util.Scanner;

public class Lab2 {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		//The GregorianCalendar object is created
		GregorianCalendar calendar = new GregorianCalendar();
		//1 is added to the month because the GregorianCalendar starts counting the months at 0
		int month = calendar.get(GregorianCalendar.MONTH) + 1;
		//Print the date in the format of MM/DD/YYYY
		System.out.println("Today's date: " + month + "/" + calendar.get(GregorianCalendar.DAY_OF_MONTH) + "/" + calendar.get(GregorianCalendar.YEAR));
		
		System.out.println("How many days do you want to add? ");
		//Initialize the Scanner Object
		Scanner inputReader = new Scanner(System.in);
		//Get the input from the user
		int daysToAdd = inputReader.nextInt();
		//Call a function of the GregorianCalendar to add days to a date
		calendar.add(GregorianCalendar.DAY_OF_MONTH, daysToAdd);
		//Again add 1 to the amount of months
		month = calendar.get(GregorianCalendar.MONTH) + 1;
		//Print the future date in the same format as the previous one
		System.out.println("Future date: " + month + "/" + calendar.get(GregorianCalendar.DAY_OF_MONTH) + "/" + calendar.get(GregorianCalendar.YEAR));
		
		inputReader.close();

	}

}
