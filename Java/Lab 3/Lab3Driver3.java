import java.util.Scanner;

/**
 *  a test of using a Scanner to read in a PolyTerm. Remember, 
 *    you do not need to understand any of this code to get it
 *    to work - you have to implement the PolyTerm class properly,
 *    and this code will work automatically when you do so!!!
 *  
 *  ALERT:  DO NOT MODIFY **ANY** OF THIS FILE IN ANY WAY
 *         If you think you need to modify this file in some way,
 *         you are not following directions, and will fail the lab!!!
 *         
 * @author sblythe
 *
 */
public class Lab3Driver3 {

	public void stripPoly(String fromString)
	{
		// Build a scanner out of the string arument
		Scanner stringScanner = new Scanner(fromString);

		// build a "generic" polyterm
		PolyTerm term = new PolyTerm();
		
		
		int termNumber=0; // keeps track of the term number
		
		// as long as there are terms to process, process them!
		while(stringScanner.hasNext())
		{
			termNumber++; // we've seen one more term ...
			
			term.read(stringScanner); // read the new term in 
			
			// print out the new term 
			System.out.print("term #" + termNumber + ": ");
			term.print();
			System.out.println();			
		}
		
		// close the scanner (keeps the warning messages away)
		stringScanner.close();
	}
	
	public static void main(String args[])
	{
		// build an object of this class (so we can call the above method)
		Lab3Driver3 l3d = new Lab3Driver3();
		
		System.out.println( "For the polynomial: 7x3 + 7x2 + 7x + 7:");
		l3d.stripPoly("7 x 3 +7 x 2 +7 x 1 +7 x 0");
		
		System.out.println( "For the polynomial: x9 - 2x8 + 3x7 - 4x6 +"
				+ " 5x5 - 6x4 + 7x3 -8x2 +9x +0 :");
		l3d.stripPoly("1 x 9 -2 x 8 +3 x 7 -4 x 6 +5 x 5 -6 x 4 +7 x 3"+
					" -8 x 2 +9 x 1 -0 x 0");

	}
}