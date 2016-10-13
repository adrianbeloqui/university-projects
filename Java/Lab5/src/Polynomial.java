import java.io.File;
import java.io.IOException;
import java.util.Scanner;


public class Polynomial {
  private PolyTerm [] thePoly;
  private int maxDegree;
  
  public Polynomial()
  {
	  thePoly = new PolyTerm[100]; // max degree is 99
	  for(int deg =0; deg<100; deg++)
		  thePoly[deg]=new PolyTerm();
	  maxDegree=99;
  }
  
  public Polynomial(Polynomial poly)
  {
	  thePoly = new PolyTerm[poly.maxDegree+1];
	  maxDegree=poly.maxDegree;
	  for(int deg =0; deg<=maxDegree; deg++)
	  {
			  thePoly[deg]=new PolyTerm();
			  thePoly[deg].setCoeff(poly.thePoly[deg].getCoeff());
			  thePoly[deg].setDegree(poly.thePoly[deg].getDegree());
	  }
  }
  
  public Polynomial negate()
  {
	  Polynomial answer = new Polynomial(this);
	  for(int deg=0; deg<=maxDegree; deg++)
	  {
		  answer.thePoly[deg].negate();
	  }
	  return answer;
  }
  
  
  public Polynomial addTerm(PolyTerm t)
  {
	  int deg = t.getDegree();
	  Polynomial result = new Polynomial(this);
	  result.thePoly[deg].setCoeff(thePoly[deg].getCoeff()+t.getCoeff());
	  result.thePoly[deg].setDegree(deg);
	  return result;
  }

  public Polynomial addPolynomial(Polynomial other)
  {
	  Polynomial result = new Polynomial(this);
	  for(int deg=0;  deg<=maxDegree; deg++)
	  {		  
		  result = result.addTerm(other.thePoly[deg]);
	  }
	  return result;
  }
  
  public double evalAt(double xVal)
  {
	  double val =0;
	  for (PolyTerm t : thePoly)
		  val += t.evalAt(xVal);
	  return val;
  }
  
  public void print()
  {
	  boolean anyPrinted=false;
	  for(int deg=maxDegree; deg>=0; deg--)
	  {
		  double currCoeff=thePoly[deg].getCoeff();
		  if (currCoeff!=0)
		  {
			  if (anyPrinted && currCoeff>0)
			  {
				  System.out.print("+");
			  }
			  thePoly[deg].print();
			  anyPrinted=true;
		  }
	  }
	  if (!anyPrinted)
		  System.out.print("0.00");
  }
  
  public void read(String fromFileName)
  {
	  File myFile=null;
	  Scanner reader;
	  try
	  {
			myFile=new File(fromFileName);
			reader = new Scanner(myFile);
			read(reader);
			reader.close();
	  }
	  catch (IOException e)
	  {
		  System.err.print("Something went wrong when reading the file!");
		  System.err.println(" ["+e.getMessage()+"]");
	  }
  }
  
  private void read(Scanner fromScanner)
  {
	  Polynomial p = new Polynomial(); 
	  while (fromScanner.hasNext())
	  {
		  PolyTerm nextTerm=new PolyTerm();
		  nextTerm.read(fromScanner);
		  p = p.addTerm(nextTerm);
	  }
	  thePoly = p.thePoly;
  }
  
  
  
}
