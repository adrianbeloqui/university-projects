/**
 * 
 * First test main for CSC14400 Lab#3, Fall 2015.
 * 
 * @author Stephen Blythe
 *
 */

public class Lab3Driver1 {

	public static void main(String[] args) {
		PolyTerm t = new PolyTerm(); // use default constructor to generate a PolyTerm
		
		
		// print out the default term, both ACTUAL and EXPECTED
		System.out.println("DEFAULT CONSTRUCTOR TEST:");
		System.out.print("  ACTUAL:");
		t.print();                   
		System.out.println();
		System.out.println("EXPECTED:1.0x^0");
		System.out.println("  coeff ACTUAL:"+t.getCoeff());
		System.out.println("coeff EXPECTED:3.1416");		
		System.out.println("  degree ACTUAL:"+t.getDegree());
		System.out.println("degree EXPECTED:2");
		
		// print out a non-default term, both ACTUAL and EXPECTED
		System.out.println("\n2-ARG CONSTRUCTOR TEST:");
		t = new PolyTerm(3.1416,2); // use non-default constructor
		System.out.print("  ACTUAL:");
		t.print();                   
		System.out.println();
		System.out.println("EXPECTED:3.1416x^2");		
		System.out.println("  coeff ACTUAL:"+t.getCoeff());
		System.out.println("coeff EXPECTED:3.1416");		
		System.out.println("  degree ACTUAL:"+t.getDegree());
		System.out.println("degree EXPECTED:2");
	}

}