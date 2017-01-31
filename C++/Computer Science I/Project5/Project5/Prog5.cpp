//***************************************     PROGRAM IDENTIFICATION   ************************************
//*                                                                                                       *
//* 	PROGRAM FILE NAME:   Prog5.cpp		    ASSIGNMENT  #:  5			Grade: _______                *
//*                                                                                                       *
//*  	PROGRAM AUTHOR:       ____________________________________                                        *
//*                                       Adrian Beloqui                                                  *
//*                                                                                                       *
//*  	COURSE #:   CSC  24400  11                               DUE DATE:    April 12, 2016              *
//*                                                                                                       *
//*********************************************************************************************************

//***************************************    PROGRAM DESCRIPTION   ****************************************
//*                                                                                                       *
//*      PROCESS: This program is designed to read a file with up to 50 student names, last names, and    *
//*               test scores and store them in arrays. It is then to print all the arrays in a readable  *
//*               way. It is then to sort the arrays from A to Z based on the student last names and      *
//*               print them out in a readable way. It is then to calculate the average of the test       *
//*               scores for each student. It is then to calculate the letter grade of the course for     *
//*               each student. It is then to print both arrays in a readable way. It is then to sort     *
//*               both arrays based on the average test scores. Finally, it is print the sorted arrays.   *                                                                    *
//*                                                                                                       *
//*      USER DEFINED                                                                                     *
//*      MODULES      : main - Controlls the flow of the entire program, calling functions is the         *
//*                            right sequence and printing the labels into the output file.               *
//*                     ReadInputFile - Reads the whole input file and stores the data into arrays.       *
//*                     PrintLists - Prints the student names and last names and test score arrays into   *
//*                                  the output file                                                      *
//*                     ExchangeSortStudentLName - Sorts all the lists from A to Z based on the student   *
//*                                                last names using the Exchange Sort algorithm.          *
//*                     ExchangeSortAverage - Sorts all the lists from high to low based on the           *
//*                                           average test score using the Exchange Sort algorithm.       *
//*                     CalculateAverageScore - Calculates the average score.                             *
//*                     CalculateLetterGrade - Calculates the letter grades.                              *
//*                     PageBreak - Adds end lines to the output file.                                    *
//*                     Header - Prints a header in the output file.                                      *
//*                     Footer - Prints a footer in the output file.                                      *
//*********************************************************************************************************

	//Imports
#include <string>
#include <fstream>
#include <iomanip>

	//Definition of logical operators
#define ArrayInitialLenght 50

	//Definition of namespace
using namespace std;

	//Function prototypes definitions
void Header(ofstream &);
void Footer(ofstream &);
void ReadInputFile(ifstream &, char*[], char*[], float[][6], int &, int &);
void PrintLists(ofstream &, char*[], char*[], float[][6], int);
void ExchangeSortStudentLName(char*[], char*[], float[][6], int EU);
void ExchangeSortAverage(char*[], char*[], float[][6], int EU);
void PageBreak(ofstream &);
void CalculateAverageScore(float[][6], int);
void CalculateLetterGrade(float[][6], int);


//***************************************** FUNTION MAIN  *************************************************
int main()
{
	ifstream InFile;
	ofstream OutFile;
	int RowElementsUsed = 0, ColElementUsed = 0;
	char *StudentNames[ArrayInitialLenght] = { 0 };
	char *StudentLastNames[ArrayInitialLenght] = { 0 };
	float TestScores[ArrayInitialLenght][6];

		// Open the input file
	InFile.open("DATA5.TXT", ios::in);

		// Create the output file
	OutFile.open("OUTPUT5.TXT", ios::out);

		// Print the header in the output file.
	Header(OutFile);

		// Read the input file.
	ReadInputFile(InFile, StudentNames, StudentLastNames,TestScores, RowElementsUsed, ColElementUsed);

		// Print label for the original lists
	OutFile << "The original student data is:" << endl;
	OutFile << setw(16) << "Student Name" << endl;
		// Print column headers for the original lists
	OutFile << "First" << setw(13) << "Last" << setw(20) << "Test 1" << setw(10) << "Test 2" << setw(10)
		<< "Test 3" << setw(10) << "Test 4" << endl;
	OutFile << "----------" << setw(13) << "----------" << setw(15) << "------" << setw(10) << "------" << setw(10)
		<< "------" << setw(10) << "------" << endl;

		// Print the original arrays
	PrintLists(OutFile, StudentNames, StudentLastNames, TestScores, RowElementsUsed);

		// Print line breaks
	PageBreak(OutFile);
	
		// Sort all the arrays based on Student Last Names form A to Z
	ExchangeSortStudentLName(StudentNames, StudentLastNames, TestScores, RowElementsUsed);

		// Print label for the sorted lists
	OutFile << "The list of students sorted A thru Z by Last Name is:" << endl;
	OutFile << setw(16) << "Student Name" << endl;
		// Print column headers for the sorted lists
	OutFile << "First" << setw(13) << "Last" << setw(20) << "Test 1" << setw(10) << "Test 2" << setw(10)
		<< "Test 3" << setw(10) << "Test 4" << endl;
	OutFile << "----------" << setw(13) << "----------" << setw(15) << "------" << setw(10) << "------" << setw(10)
		<< "------" << setw(10) << "------" << endl;

		// Print the sorted arrays
	PrintLists(OutFile, StudentNames, StudentLastNames, TestScores, RowElementsUsed);

		// Print line breaks
	PageBreak(OutFile);
	
		// Calculate average scores
	CalculateAverageScore(TestScores, RowElementsUsed);

		// Caluclate letter grades
	CalculateLetterGrade(TestScores, RowElementsUsed);

		// Print label for test average score and letter grade
	OutFile << "The list of students with their test average and course grade is:" << endl;
	OutFile << setw(16) << "Student Name" << endl;
		// Print column headers for the lists
	OutFile << "First" << setw(13) << "Last" << setw(20) << "Test 1" << setw(10) << "Test 2" << setw(10)
		<< "Test 3" << setw(10) << "Test 4" << setw(10) << "Average" << setw(10)
		<< "Grade" << endl;
	OutFile << "----------" << setw(13) << "----------" << setw(15) << "------" << setw(10) << "------" << setw(10)
		<< "------" << setw(10) << "------" << setw(10) << "-------" << setw(10)
		<< "-------" << endl;

		// Print arrays with average scores and letter grades
	PrintLists(OutFile, StudentNames, StudentLastNames, TestScores, RowElementsUsed);

		// Print line breaks
	PageBreak(OutFile);
	
		// Sort all the arrays based on average test scores form high to low
	ExchangeSortAverage(StudentNames, StudentLastNames, TestScores, RowElementsUsed);

		// Print label for the sorted lists
	OutFile << "The list of students sorted by test average high to low is:" << endl;
	OutFile << setw(16) << "Student Name" << endl;
		// Print column headers for the lists
	OutFile << "First" << setw(13) << "Last" << setw(20) << "Test 1" << setw(10) << "Test 2" << setw(10)
		<< "Test 3" << setw(10) << "Test 4" << setw(10) << "Average" << setw(10)
		<< "Grade" << endl;
	OutFile << "----------" << setw(13) << "----------" << setw(15) << "------" << setw(10) << "------" << setw(10)
		<< "------" << setw(10) << "------" << setw(10) << "-------" << setw(10)
		<< "-------" << endl;

		// Print the sorted arrays
	PrintLists(OutFile, StudentNames, StudentLastNames, TestScores, RowElementsUsed);

		// Print the footer into the output file.
	Footer(OutFile);

	return 0;
}
//************************************  END OF FUNCTION MAIN  *********************************************

//***************************************** FUNTION PAGEBREAK  ********************************************
void PageBreak(ofstream &Outfile)
{
		// Receives - The output file.
		// Task - Add end lines to the output file.
		// Returns - Nothing.

	for (int i = 0; i < 17; i++){
		Outfile << endl;
	}
}
//************************************  END OF FUNCTION PAGEBREAK  ****************************************

//***************************************** FUNTION EXCHANGESORTAVERAGE ***********************************
void ExchangeSortAverage(char *StNames[], char *StLNames[], float TestS[][6], int EU)
{
		// Receives - The student names and last names array, the test score array, and the amount 
		//            of elements used.
		// Task - Sort from high to low all the arrays based on the average test score.
		// Returns - All the arrays sorted.

	float temp;
	char *temp2;

		// Loop through the array
	for (int M = 0; M < EU - 1; M++)
	{
			// Set the index of the maximum location to the current cycle of the loop
		int Max = M;
			// Loop through the array from right to left
		for (int N = EU - 1; N > M; N--){
				// Check if average score in the current cycle of the loop is higher than the maximum
				// location stored
			if (TestS[N][4] > TestS[Max][4]){
					// Update the location of the maximum average score
				Max = N;
			}
		}
			// Swap the student last names to put them in high to low order
		temp2 = new char[15];
		char *sp1 = StLNames[Max];
		char *sp2 = StLNames[M];
		strcpy_s(temp2, 15, sp2);
		strcpy_s(sp2, 15, sp1);
		strcpy_s(sp1, 15, temp2);
			// Swap the student names to keep the relationship with the student last names
		temp2 = new char[15];
		sp1 = StNames[Max];
		sp2 = StNames[M];
		strcpy_s(temp2, 15, sp2);
		strcpy_s(sp2, 15, sp1);
		strcpy_s(sp1, 15, temp2);

			// Swap the test scores to keep the relationship with the student last names
		for (int i = 0; i < 6; i++){
			temp = TestS[M][i];
			TestS[M][i] = TestS[Max][i];
			TestS[Max][i] = temp;
		}

	}
}
//************************************  END OF FUNCTION EXCHANGESORTAVERAGE  ******************************

//***************************************** FUNTION EXCHANGESORTSTUDENTLNAME  *****************************
void ExchangeSortStudentLName(char *StNames[], char *StLNames[], float TestS[][6], int EU)
{
		// Receives - The student names and last names arrays, the test score array, and the amount 
		//            of elements used.
		// Task - Sort from A to Z all the arrays based on the student last names.
		// Returns - All the arrays sorted.

	float temp;
	char *temp2;

		// Loop through the array
	for (int M = 0; M < EU - 1; M++)
	{
			// Set the index of the minimum location to the current cycle of the loop
		int Min = M;
			// Loop through the array from right to left
		for (int N = EU - 1; N > M; N--){
				// Check if the student last name in the current cycle of the loop is higher than the minimum
				// location stored
			char *sp1 = StLNames[Min];
			char *sp2 = StLNames[N];
			if (strcmp(sp2, sp1) < 0){
					// Update the location of the minimum student last name
				Min = N;
			}
		}
			// Swap the student last names to put them in A to Z order
		temp2 = new char[15];
		char *sp1 = StLNames[Min];
		char *sp2 = StLNames[M];
		strcpy_s(temp2, 15, sp2);
		strcpy_s(sp2, 15, sp1);
		strcpy_s(sp1, 15, temp2);
			// Swap the student names to keep the relationship with the student last names
		temp2 = new char[15];
		sp1 = StNames[Min];
		sp2 = StNames[M];
		strcpy_s(temp2, 15, sp2);
		strcpy_s(sp2, 15, sp1);
		strcpy_s(sp1, 15, temp2);

			// Swap the test scores to keep the relationship with the student last names
		for (int i = 0; i < 6; i++){
			temp = TestS[M][i];
			TestS[M][i] = TestS[Min][i];
			TestS[Min][i] = temp;
		}

	}
}
//************************************  END OF FUNCTION EXCHANGESORTSTUDENTLNAME **************************

//***************************************** FUNTION CALCULATELETTERGRADE  *********************************
void CalculateLetterGrade(float TestS[][6], int EU)
{
		// Receives - The test score array and the amount of elements used.
		// Task - Calculates the letter grades.
		// Returns - the test score array with the letter grades calculated.

		// Set the initial total amount.
	float ScoreAdded = 0;
	int counter = 0;
		// Loop through the test score array
	for (int i = 0; i < EU; i++){
			// Check for what letter grade requirement applies the current average score that is
			// iterating
		if (TestS[i][4] >= 90){
			TestS[i][5] = 'A';
		}
		else if (TestS[i][4] >= 80 && TestS[i][4] < 90){
			TestS[i][5] = 'B';
		}
		else if (TestS[i][4] >= 70 && TestS[i][4] < 80){
			TestS[i][5] = 'C';
		}
		else if (TestS[i][4] >= 60 && TestS[i][4] < 70){
			TestS[i][5] = 'D';
		}
		else{
			TestS[i][5] = 'F';
		}
	}

	return;
}
//************************************  END OF FUNCTION CALCULATELETTERGRADE  *****************************

//***************************************** FUNTION CALCULATEAVERAGESCORE  ********************************
void CalculateAverageScore(float TestS[][6], int EU)
{
		// Receives - The test score array and the amount of elements used.
		// Task - Calculates the average score.
		// Returns - The test score array with the average scores calculated.

		// Set the initial total amount.
	float ScoreAdded = 0;
	int counter = 0;
		// Loop through the test score array
	for (int i = 0; i < EU; i++){
		counter = 0;
		ScoreAdded = 0;
		for (int j = 0; j < 4; j++){
				// Add the test score to the total.
			ScoreAdded += TestS[i][j];
			counter++;
		}
			// Calculate the average of the test scores.
		float Average = ScoreAdded / counter;
			// Assing the average score to the correct location in the array.
		TestS[i][4] = Average;
	}

	return;
}
//************************************  END OF FUNCTION CALCULATEAVERAGESCORE  ****************************

//***************************************** FUNTION PRINTORIGINALLISTS  ***********************************
void PrintLists(ofstream &Outfile, char *StNames[], char *StLNames[], float TestS[][6], int REU)
{
		// Receives - The output file, the student names and last names arrays, the Test Scores array 
		//            and the amount of elements used.
		// Task - Print three arrays in the output file.
		// Returns - Nothing.

		// Set the output file to print float numbers with two decimal places.
	Outfile.setf(ios::fixed);
		// Set decimal precision to two
	Outfile.precision(2);

	for (int i = 0; i < REU; i++){
			// Print the Student Name and Last Name
		Outfile << StNames[i];
		Outfile << setw(12) << StLNames[i];
		for (int j = 0; j < 6; j++){
				// Check if it is a test score
			if (TestS[i][j] > 0 && j < 4){
					// Print test score
				Outfile << setw(10) << TestS[i][j];
			}
				// Check if it the average score
			if (TestS[i][j] > 0 && j == 4){
					// Print average score
				Outfile << setw(8) << TestS[i][j];
			}
				// Check if there is a letter grade to print
			if (TestS[i][j] > 0 && j == 5){
					// Print letter grade
				Outfile << setw(8) << (char)TestS[i][j];
			}
		}
		Outfile << endl;
	}

	Outfile << endl;
	return;
}
//************************************  END OF FUNCTION PRINTORIGINALLISTS  *******************************

//***************************************** FUNTION READINPUTFILE  ****************************************
void ReadInputFile(ifstream &Infile, char *StNames[], char *StLNames[], float Scores[][6], int &REU
	, int &CEU)
{
		// Receives - The input file, the student names array, the student last names array,
		//            the Test Score array and the elements used in the arrays.
		// Task - Read the input file and save the values into arrays.
		// Returns - The student names and last names arrays, the Test Score array and the Elements 
		//           Used numbers.

		// Declare helper variables
	char  *newPtr;
	char String[15];
	float TestScr = 0;
	int counter = 0;

		// Read the first value from the input file
	Infile >> ws;
	Infile.getline(String, 15);

		// While the student name is different from the sentinel "No            "
	while (strcmp(String, "No            ")!= 0){
			// Declare pointer to a character array
		newPtr = new char[15];
			// Copy first value read into pointer
		strcpy_s(newPtr, 15, String);
			// Assign pointer to an element of the student names array
		StNames[REU] = newPtr;
			// Read the next value in the input file
		Infile >> ws;
		Infile.getline(String, 20);
			// Declare pointer to a character array
		newPtr = new char[15];
			// Copy first value read into pointer
		strcpy_s(newPtr,15, String);
			// Assign pointer to an element of the student last names array
		StLNames[REU] = newPtr;


			// Read the next value from the input file
		Infile >> TestScr;
			// While the test score is greater than zero and there are less than 5 test scores saved
		while (TestScr > 0 && counter < 4)
		{
				// Assign the test score to the test score array
			Scores[REU][CEU++] = TestScr;
				// Increase the amount of saved scores by one
			counter++;
				// Check if the counter has reached 4 scores saved
			if (counter < 4){
				// read the next value from the input file
				Infile >> TestScr;
			}
		}

			// Increase the elements used in the rows by one, and set elements used in columns to zero
		REU++;
		CEU = 0;
			// Set counter of test scores saved to 0
		counter = 0;
			// Read the next value from the input file
		Infile >> ws;
		Infile.getline(String, 20);
	}

	return;
}
//************************************  END OF FUNCTION READINPUTFILE  ************************************

//***************************************** FUNTION HEADER  ***********************************************
void Header(ofstream &Outfile)
{
		// Receives - The output file
		// Task - Prints the output preamble
		// Returns - Nothing

	Outfile << setw(30) << "Adrian Beloqui ";
	Outfile << setw(17) << "CSC 24400";
	Outfile << setw(15) << "Section 11" << endl;
	Outfile << setw(30) << "Spring 2016";
	Outfile << setw(20) << "Assignment #5" << endl;
	Outfile << setw(35) << "------------------------------------------------";
	Outfile << setw(35) << "------------------------------------------------" << endl << endl;
	return;
}
//************************************  END OF FUNCTION HEADER  *******************************************

//***************************************** FUNTION FOOTER  ***********************************************
void Footer(ofstream &Outfile)
{
		// Receives - The output file
		// Task - Prints the output salutation
		// Returns - Nothing

	Outfile << endl;
	Outfile << setw(35) << "------------------------------------------------" << endl;
	Outfile << setw(35) << "|               END OF PROGRAM OUTPUT          |" << endl;
	Outfile << setw(35) << "------------------------------------------------" << endl;
	return;
}
//************************************  END OF FUNCTION FOOTER  *******************************************