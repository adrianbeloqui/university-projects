import java.util.Scanner;

public class PolyTerm {
	
	private double coefficient;
	private int degree;
	
	public PolyTerm(){
		coefficient = 1.0;
		degree = 0;
	}
	
	public PolyTerm(Double coef, Integer deg){
		coefficient = coef;
		degree = deg;
	}
	
	public double getCoeff(){
		return coefficient;
	}
	
	public int getDegree(){
		return degree;
	}
	
	public double evalAt(Double value){
		double x = value;
		double result = coefficient * Math.pow(x, degree);
		return result;
	}
	
	public void print(){
		System.out.println(coefficient + "x^" + degree);
	}
	
	public void read(Scanner input){
		coefficient = input.nextDouble();
		String variable = input.next();
		degree = input.nextInt();
	}

}
