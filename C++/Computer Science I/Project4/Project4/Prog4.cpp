//***************************************     PROGRAM IDENTIFICATION   ************************************
//*                                                                                                       *
//* 	PROGRAM FILE NAME:   Prog4.cpp		    ASSIGNMENT  #:  4			Grade: _______                *
//*                                                                                                       *
//*  	PROGRAM AUTHOR:       ____________________________________                                        *
//*                                       Adrian Beloqui                                                  *
//*                                                                                                       *
//*  	COURSE #:   CSC  24400  11                               DUE DATE:    March 24, 2016              *
//*                                                                                                       *
//*********************************************************************************************************

//***************************************    PROGRAM DESCRIPTION   ****************************************
//*                                                                                                       *
//*      PROCESS: This program is designed to read a file with up to 50 student IDs and test scores and   *
//*               store them in arrays. It is then to print both arrays in a readable way. It is then to  *
//*               sort the arrays from high to low based on the student ID numbers and print them out     *
//*               in a readable way. It is then to calculate the average of the test scores for each      *
//*               student. It is then to calculate the letter grade of the course for each student. It is *
//*               then to print both arrays in a readable way. It is then to sort both arrays based on    *
//*               the average test scores. Finally, it is print the sorted arrays.                        *                                                                    *
//*                                                                                                       *
//*      USER DEFINED                                                                                     *
//*      MODULES      : main - Controlls the flow of the entire program, calling functions is the         *
//*                            right sequence and printing the labels into the output file.               *
//*                     ReadInputFile - Reads the whole input file and stores the data into arrays.       *
//*                     PrintLists - Prints the student IDs and test score arrays into the output file    *
//*                     ExchangeSortStudentID - Sorts both lists from high to low based on the student ID *
//*                                             number using the Exchange Sort algorithm.                 *
//*                     ExchangeSortAverage - Sorts both lists from high to low based on the average test *
//*                                           score using the Exchange Sort algorithm.                    *
//*                     CalculateAverageScore - Calculates the average score.                             *
//*                     CalculateLetterGrade - Calculates the letter grades.                              *
//*                     PageBreak - Adds end lines to the output file.                                    *
//*                     Header - Prints a header in the output file.                                      *
//*                     Footer - Prints a footer in the output file.                                      *
//*********************************************************************************************************

	//Imports
#include <fstream>
#include <iomanip>

	//Definition of logical operators
#define ArrayInitialLenght 50

	//Definition of namespace
using namespace std;

	//Function prototypes definitions
void Header(ofstream &);
void Footer(ofstream &);
void ReadInputFile(ifstream &, int[], float[][6], int &, int &);
void PrintLists(ofstream &, int[], float[][6], int);
void ExchangeSortStudentID(int[], float[][6], int EU);
void ExchangeSortAverage(int[], float[][6], int EU);
void PageBreak(ofstream &);
void CalculateAverageScore(float[][6], int);
void CalculateLetterGrade(float[][6], int);


//***************************************** FUNTION MAIN  *************************************************
int main()
{
	ifstream InFile;
	ofstream OutFile;
	int RowElementsUsed = 0, ColElementUsed = 0;
	int StudentIDs[ArrayInitialLenght];
	float TestScores[ArrayInitialLenght][6];

		// Open the input file
	InFile.open("DATA4.TXT", ios::in);

		// Create the output file
	OutFile.open("OUTPUT4.TXT", ios::out);

		// Print the header in the output file.
	Header(OutFile);

		// Read the input file.
	ReadInputFile(InFile, StudentIDs, TestScores, RowElementsUsed, ColElementUsed);

		// Print label for the original lists
	OutFile << "The original student data is:" << endl << endl;
		// Print column headers for the original lists
	OutFile << setw(16) << "Student ID" << setw(12) << "Test 1" << setw(13) << "Test 2" << setw(13)
		<< "Test 3" << setw(13) << "Test 4" << endl;
	OutFile << setw(16) << "----------" << setw(12) << "------" << setw(13) << "------" << setw(13)
		<< "------" << setw(13) << "------" << endl;

		// Print the original arrays
	PrintLists(OutFile, StudentIDs, TestScores, RowElementsUsed);

		// Print line breaks
	PageBreak(OutFile);

		// Sort both arrays based on Student IDs form high to low
	ExchangeSortStudentID(StudentIDs, TestScores, RowElementsUsed);

		// Print label for the sorted lists
	OutFile << "The list of students sorted by ID Number high to low is:" << endl << endl;
		// Print column headers for the sorted lists
	OutFile << setw(16) << "Student ID" << setw(12) << "Test 1" << setw(13) << "Test 2" << setw(13) 
		<< "Test 3" << setw(13) << "Test 4" << endl;
	OutFile << setw(16) << "----------" << setw(12) << "------" << setw(13) << "------" << setw(13) 
		<< "------" << setw(13) << "------" << endl;

		// Print the sorted arrays
	PrintLists(OutFile, StudentIDs, TestScores, RowElementsUsed);

		// Print line breaks
	PageBreak(OutFile);

		// Calculate average scores
	CalculateAverageScore(TestScores, RowElementsUsed);
		
		// Caluclate letter grades
	CalculateLetterGrade(TestScores, RowElementsUsed);
	
		// Print label for test average score and letter grade
	OutFile << "The list of students with their test avarage and course grade is:" << endl << endl;
		// Print column headers for the student and test information
	OutFile << setw(16) << "Student ID" << setw(12) << "Test 1" << setw(13) << "Test 2" << setw(13)
		<< "Test 3" << setw(13) << "Test 4" << setw(13) << "Test Average" << setw(13) 
		<< "Course Grade" << endl;
	OutFile << setw(16) << "----------" << setw(12) << "------" << setw(13) << "------" << setw(13)
		<< "------" << setw(13) << "------" << setw(13) << "------------" << setw(13)
		<< "------------" << endl;

		// Print arrays with average scores and letter grades
	PrintLists(OutFile, StudentIDs, TestScores, RowElementsUsed);

		// Print line breaks
	PageBreak(OutFile);

		// Sort both arrays based on average test scores form high to low
	ExchangeSortAverage(StudentIDs, TestScores, RowElementsUsed);

		// Print label for the sorted lists
	OutFile << "The list of students sorted by test average high to low is:" << endl << endl;
		// Print column headers for the sorted lists
	OutFile << setw(16) << "Student ID" << setw(12) << "Test 1" << setw(13) << "Test 2" << setw(13)
		<< "Test 3" << setw(13) << "Test 4" << setw(13) << "Test Average" << setw(13)
		<< "Course Grade" << endl;
	OutFile << setw(16) << "----------" << setw(12) << "------" << setw(13) << "------" << setw(13)
		<< "------" << setw(13) << "------" << setw(13) << "------------" << setw(13)
		<< "------------" << endl;

		// Print the sorted arrays
	PrintLists(OutFile, StudentIDs, TestScores, RowElementsUsed);

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

	for (int i = 0; i < 3; i++){
		Outfile << endl;
	}
}
//************************************  END OF FUNCTION PAGEBREAK  ****************************************

//***************************************** FUNTION EXCHANGESORTAVERAGE ***********************************
void ExchangeSortAverage(int StIDS[], float TestS[][6], int EU)
{
		// Receives - The student IDs array, the test score array, and the amount of elements used.
		// Task - Sort from high to low both arrays based on the average test score.
		// Returns - Both arrays sorted.

	float temp;
	int temp2;

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
			// Swap the student IDs to put them in high to low order
		temp2 = StIDS[M];
		StIDS[M] = StIDS[Max];
		StIDS[Max] = temp2;

			// Swap the test scores to keep the relationship with the student IDs
		for (int i = 0; i < 6; i++){
			temp = TestS[M][i];
			TestS[M][i] = TestS[Max][i];
			TestS[Max][i] = temp;
		}

	}
}
//************************************  END OF FUNCTION EXCHANGESORTAVERAGE  ******************************

//***************************************** FUNTION EXCHANGESORTSTUDENTID  ********************************
void ExchangeSortStudentID(int StIDS[], float TestS[][6], int EU)
{
		// Receives - The student IDs array, the test score array, and the amount of elements used.
		// Task - Sort from high to low both arrays based on the student ID number.
		// Returns - Both arrays sorted.

	float temp;
	int temp2;

		// Loop through the array
	for (int M = 0; M < EU - 1; M++)
	{
			// Set the index of the maximum location to the current cycle of the loop
		int Max = M;
			// Loop through the array from right to left
		for (int N = EU - 1; N > M; N--){
				// Check if the student ID in the current cycle of the loop is higher than the maximum
				// location stored
			if (StIDS[N] > StIDS[Max]){
					// Update the location of the maximum student ID
				Max = N;
			}
		}
			// Swap the student IDs to put them in high to low order
		temp2 = StIDS[M];
		StIDS[M] = StIDS[Max];
		StIDS[Max] = temp2;

			// Swap the test scores to keep the relationship with the student IDs
		for (int i = 0; i < 6; i++){
			temp = TestS[M][i];
			TestS[M][i] = TestS[Max][i];
			TestS[Max][i] = temp;
		}
		
	}
}
//************************************  END OF FUNCTION EXCHANGESORTSTUDENTID  ****************************

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
void PrintLists(ofstream &Outfile, int StIDS[], float TestS[][6], int REU)
{
		// Receives - The output file, the student IDs array, the Test Scores array and the amount of
		//            elements used.
		// Task - Print two arrays in the output file.
		// Returns - Nothing.

		// Set the output file to print float numbers with two decimal places.
	Outfile.setf(ios::fixed);

	for (int i = 0; i < REU; i++){
			// Print the Student ID
		Outfile << setw(14) << StIDS[i];
		for (int j = 0; j < 6; j++){
				// Check if it is a test score
			if (TestS[i][j] > 0 && j < 4){
					// Set decimal precision to one
				Outfile.precision(1);
					// Print test score
				Outfile << setw(13) << TestS[i][j];
			}
				// Check if it the average score
			if (TestS[i][j] > 0 && j == 4){
					// Set decimal precision to two
				Outfile.precision(2);
					// Print average score
				Outfile << setw(13) << TestS[i][j];
			}
				// Check if there is a letter grade to print
			if (TestS[i][j] > 0 && j == 5){
					// Print letter grade
				Outfile << setw(13) << (char)TestS[i][j];
			}
		}
		Outfile << endl;
	}

	Outfile << endl;
	return;
}
//************************************  END OF FUNCTION PRINTORIGINALLISTS  *******************************

//***************************************** FUNTION READINPUTFILE  ****************************************
void ReadInputFile(ifstream &Infile, int StIDS[], float Scores[][6], int &REU, int &CEU)
{
		// Receives - The input file, the student IDs array, the Test Score array and the elements used
		//            in the arrays.
		// Task - Read the input file and save the values into arrays.
		// Returns - The student IDs array, the Test Score array and the Elements Used numbers.

		// Declare initial index values for the arrays
	int StID = 0;
	float TestScr = 0;
	int counter = 0;

		// Read the first value from the input file
	Infile >> StID;

		// While the student ID is greater than zero
	while (StID > 0){

		CEU = 0;
			// Read the second value from the input file
		Infile >> TestScr;
			// Assign the student ID to the student IDs array
		StIDS[REU] = StID;
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
			// Increase the elements used in the rows by one
		REU++;
			// Set counter of test scores saved to 0
		counter = 0;
			// Read the next value from the input file
		Infile >> StID;
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
	Outfile << setw(20) << "Assignment #4" << endl;
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