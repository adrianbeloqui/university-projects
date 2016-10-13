import java.awt.FileDialog;


public class SubPolys {

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
		// TODO Auto-generated method stub
		Polynomial a = getFromFile();
		Polynomial b = getFromFile();
		
		System.out.print("a:"); a.print(); System.out.println();
		System.out.print("b:"); b.print(); System.out.println();
		System.out.print("-a:"); a.negate().print(); System.out.println();
		System.out.print("-b:"); b.negate().print(); System.out.println();
		System.out.print("a-b:"); a.addPolynomial(b.negate()).print(); System.out.println();
		System.out.print("b-a:"); b.addPolynomial(a.negate()).print(); System.out.println();
		System.out.print("a-a:"); a.addPolynomial(a.negate()).print(); System.out.println();
		System.out.print("b-b:"); b.addPolynomial(b.negate()).print(); System.out.println();
        System.out.printf("-a(2.7183)=%.2f\n", a.negate().evalAt(3.14159));
        System.out.printf("-b(3.14159)=%.2f\n", b.negate().evalAt(3.14159));


	}

}
