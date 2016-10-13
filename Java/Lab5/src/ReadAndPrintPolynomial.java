import java.awt.FileDialog;
import java.util.*;
import java.io.*;

public class ReadAndPrintPolynomial {

	/*
	 * Utility method to read a Polynomial from a fie
	 *   where the file is specified by a FIleDialog box.
	 */
	private static Polynomial getFromFile()
	{
		// set up the file dialog box and display it, waiting for the user.
		FileDialog fd = null;
		fd = new FileDialog(fd, "Choose a file with a polynomial in it", FileDialog.LOAD);
		fd.setVisible(true);
		
		// if user did select a file, read it into a polynomial
		if (fd.getFile()!=null)
		{
			String fullName = fd.getDirectory() + fd.getFile();
			Polynomial p = new Polynomial();
			p.read(fullName);
			return p;
		}
		else 		// if the user gave a bad filename or didn't choose "OK", quit ...

		{
			System.err.println("You did not select a file.");
			System.exit(1); // quit the program, with an error code of 1
		}
		return null; // keeps compiler happy, but this should never be reached. 
	}
	
	public static void main(String[] args) {		
		// build a two polynomials, each from files
		Polynomial p= getFromFile();
		p.print();
	}

}
