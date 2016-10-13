import java.util.Scanner;

/**
 * 
 * @author Stephen Blythe
 *
 *Describes an individual term in a polynomial
 */
public class PolyTerm {
	
	private double coeff; // the term's coefficient
	private int degree;   // the term's degree
	
	/**
	 * PolyTerm
	 * 
	 *   builds a default polyTerm, with coefficient of 0 and degree of 0
	 */
	public PolyTerm()
	{
		coeff=0;
		degree=0;
	}
	
	
	/**
	 * PolyTerm
	 * 
	 *   builds a polyTerm, with specified coefficient and degree
	 *   
	 *   @param coeff - the specified coefficient
	 *   @param degree - the specified degree
	 */
	public PolyTerm(double coeff, int degree)
	{
		this.coeff=coeff;
		this.degree=degree;
	}
	
	/**
	 * getCoeff - accessor for coefficient
	 * @return the coefficient value
	 */
	public double getCoeff() {return coeff;}
	
	/**
	 * getDegree - accessor for degree
	 * @return the degree value
	 */
	public int getDegree() {return degree;}
	
	/**
	 * setCoeff - setter for coefficient
	 * @param newCoeff - the new coefficient value
	 */
	public void setCoeff(double newCoeff) {coeff = newCoeff;}
	
	/**
	 * setDegree - setter for degree
	 * @param newDegree -  the new degree value
	 */
	public void setDegree(int newDegree) {degree=newDegree;}
	
	/**
	 * evalAt
	 *   calculate the value of the term
 	 * @param xValue - the value at which this polynomial term should be evaluated
	 * @return the result of evaluating this term
	 */
	public double evalAt(double xValue)
	{
		return coeff*Math.pow(xValue, degree);
	}
	
	/**
	 * negate
	 *   negates the coefficient (and therefore the term)
	 */
	public void negate()
	{
		coeff = -coeff;
	}
	
	/**
	 * print
	 *   print the term to the terminal (nicely)
	 *   
	 *   **** YOU WILL WANT TO CHANGE THIS ****
	 */
	public void print()
	{
		System.out.print(coeff);
		System.out.print("x^");
		System.out.print(degree);
	}
	
	/**
	 * read
	 *   read in a term from the specified source
	 * @param fromScanner - the source to read this term from 
	 */
	public void read(Scanner fromScanner)
	{
		// read the coefficient
		coeff = fromScanner.nextDouble();
		// skip the variable name
		/*String ignored =*/ fromScanner.next();
		// read the degree
		degree = fromScanner.nextInt();
	}
	
}
