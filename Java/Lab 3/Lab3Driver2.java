/**
 * Lab3Driver2 - test code for CSC14400 Lab3, Fall 2015
 * 
 * @author sblythe
 *
 */
public class Lab3Driver2 {

	public static int myTest(double pred, double c, int d, double at)
	{
		double eval= c * Math.pow(at, d); // correct result. 
		
		// if correct result and actual result are too far apart, 
		//    mark this case as an error
		if (Math.abs(eval-pred)>.001)
		{
			System.out.printf("Possible isue with coeff=%f,degree=%d,x=%f\n",
					c, d, at);
			System.out.printf("  --> result should have been %f, you gave %f\n",
					eval, pred);
			return 1; // one error to report!
		}
		else
			return 0; // no error(s) to report. 
	}
	
	public static void main(String args[])
	{
		// counts number of incorrect values
		int errCount=0;
		
		// test a whole bunch of degree values
		for (int degValue=0; degValue<10; degValue++)
			// for each degree value, try a number of coefficients
			for(double coeffValue=-12; coeffValue<20; coeffValue+=5)
			{
				// build corresponding PolyTerm 
				PolyTerm t = new PolyTerm(coeffValue, degValue);
				
				// try a whole bunch of x values for current term
				for (double x=-10; x<=10; x+=.33)
				{
					double actual = t.evalAt(x); // get actual value
					
					// compare to correct result. 
					errCount+=myTest(actual, coeffValue, degValue, x);
				}
			}
		
		System.out.println("You had "+errCount+" suspicious results.");
	}
}