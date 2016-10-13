//***************************************     PROGRAM IDENTIFICATION   ************************************
//*                                                                                                       *
//* 	PROGRAM FILE NAME:   Prog3.cpp		    ASSIGNMENT  #:  3			Grade: _______                *
//*                                                                                                       *
//*  	PROGRAM AUTHOR:       ____________________________________                                        *
//*                                       Adrian Beloqui                                                  *
//*                                                                                                       *
//*  	COURSE #:   CSC  24400  11                               DUE DATE:    March 10, 2016              *
//*                                                                                                       *
//*********************************************************************************************************

//***************************************    PROGRAM DESCRIPTION   ****************************************
//*                                                                                                       *
//*      PROCESS: This program is designed to read a file with up to 50 student IDs and test scores and   *
//*               store them in arrays. It is then to print both arrays in a readable way. It is then to  *
//*               sort the arrays from high to low based on the test scores and print them out in a       *
//*               readable way. It is then to sort the arrays from low to high based on the student ID    *
//*               number and print them in output file. It is then to find the minium and maximum scores  *
//*               and print these with they student ID associated to them. Finally, it is compute the     *
//*               average test score and print it.                                                        *
//*                                                                                                       *
//*      USER DEFINED                                                                                     *
//*      MODULES      : main - Controlls the flow of the entire program, calling functions is the         *
//*                            right sequence and printing the labels into the output file.               *
//*                     ReadInputFile - Reads the whole input file and stores the data into arrays.       *
//*                     PrintLists - Prints the student IDs and test score arrays into the output file    *
//*                     BubbleSort - Sorts both lists from high to low based on test scores using the     *
//*                                  Bubble Sort algorithm.                                               *
//*                     ExchangeSort - Sorts both lists from low to high based on the student ID number   *
//*                                    using the Exchange Sort algorithm.                                 *
//*                     FindMinScore - Finds the location of the minimum score.                           *
//*                     FindMaxScore - Finds the location of the maximum score.                           *
//*                     FindAverageScore - Calculates the average score.                                  *
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
void ReadInputFile(ifstream &, int[], float[], int &);
void PrintLists(ofstream &, int[], float[], int);
void BubbleSort(int[], float[], int);
void ExchangeSort(int[], float[], int EU);
int FindMinScore(float[], int);
int FindMaxScore(float[], int);
float FindAverageScore(float[], int);
void PageBreak(ofstream &);

//***************************************** FUNTION MAIN  *************************************************
int main()
{
	ifstream InFile;
	ofstream OutFile;
	int ElementsUsed = 0;
	int StudentIDs[ArrayInitialLenght];
	float TestScores[ArrayInitialLenght];

		// Open the input file
	InFile.open("DATA3.TXT", ios::in);

		// Create the output file
	OutFile.open("OUTPUT3.TXT", ios::out);

		// Print the header in the output file.
	Header(OutFile);

		// Read the input file.
	ReadInputFile(InFile, StudentIDs, TestScores, ElementsUsed);

		// Print label for the original lists
	OutFile << "The original list of test scores is:" << endl << endl;
		// Print column headers for the original lists
	OutFile << setw(16) << "Student ID #" << setw(14) << "Test Score" << endl;

		// Print the original arrays
	PrintLists(OutFile, StudentIDs, TestScores, ElementsUsed);

		// Print line breaks
	PageBreak(OutFile);

		// Sort both arrays based on test scores form high to low
	BubbleSort(StudentIDs, TestScores, ElementsUsed);

		// Print label for the sorted lists
	OutFile << "The test scores sorted highest to lowest are:" << endl << endl;
		// Print column headers for the sorted lists
	OutFile << setw(16) << "Student ID #" << setw(14) << "Test Score" << endl;

		// Print the sorted arrays
	PrintLists(OutFile, StudentIDs, TestScores, ElementsUsed);

		// Print line breaks
	PageBreak(OutFile);

		// Sort both lists from low to high based on the student ID number
	ExchangeSort(StudentIDs, TestScores, ElementsUsed);

		// Print label for the sorted lists
	OutFile << "The student ID numbers sorted lowest to highest are:" << endl << endl;
		// Print column headers for the sorted lists
	OutFile << setw(16) << "Student ID #" << setw(14) << "Test Score" << endl;

		// Print the sorted arrays
	PrintLists(OutFile, StudentIDs, TestScores, ElementsUsed);

		// Print line breaks
	PageBreak(OutFile);

		// Find the location of the minimum score.
	int MinScore = FindMinScore(TestScores, ElementsUsed);
	OutFile << endl;
	OutFile << "The lowest test score was " << TestScores[MinScore] << " achieved by student #"
		<< StudentIDs[MinScore] << endl << endl;

		// Find the location of the maximum score.
	int MaxScore = FindMaxScore(TestScores, ElementsUsed);
	OutFile << "The highest test score was " << TestScores[MaxScore] << " achieved by student #"
		<< StudentIDs[MaxScore] << endl << endl;

		// Calculate the average of the test scores.
	float Average = FindAverageScore(TestScores, ElementsUsed);
	OutFile << "The average test score for the group is " << Average << endl;

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

//***************************************** FUNTION EXCHANGESORT  *****************************************
void ExchangeSort(int StIDS[], float TestS[], int EU)
{
		// Receives - The student IDs array, the test score array, and the amount of elements used.
		// Task - Sort from low to high both arrays based on the student ID number.
		// Returns - Both arrays sorted.

	float temp;
	int temp2;

		// Loop through the array
	for (int M = 0; M < EU - 1; M++)
	{
			// Set the index of the minimum location to the current cycle of the loop
		int Min = M;
			// Loop through the array from right to left
		for (int N = EU - 1; N > M; N--){
				// Check if the student ID in the current cycle of the loop is lower than the minimum
				// location stored
			if (StIDS[N] < StIDS[Min]){
					// Update the location of the minimum student ID
				Min = N;
			}
		}
			// Swap the student IDs to put them in low to high order
		temp2 = StIDS[M];
		StIDS[M] = StIDS[Min];
		StIDS[Min] = temp2;

			// Swap the test scores to keep the relationship with the student IDs
		temp = TestS[M];
		TestS[M] = TestS[Min];
		TestS[Min] = temp;
	}
}
//************************************  END OF FUNCTION EXCHANGESORT  *************************************

//***************************************** FUNTION BUBBLESORT  *******************************************
void BubbleSort(int StIDS[], float TestS[], int EU)
{
		// Receives - The student IDs array, the test score array, and the amount of elements used.
		// Task - Sort from high to low both arrays based on test scores.
		// Returns - Both arrays sorted.

	float temp;
	int temp2;

		// Loop through the array from left to right
	for (int M = 0; M < EU - 1; M++)
	{
			// Loop through the array from right to left
		for (int N = EU - 1; N > M; N--){
				// Check if the test score in the current cycle is higher than the test score on 
				// it's left
			if (TestS[N] > TestS[N - 1])
			{
					// Swap the test scores to put them from hight to low
				temp = TestS[N];
				TestS[N] = TestS[N - 1];
				TestS[N - 1] = temp;

					// Swap the student IDs to keep the corelation
				temp2 = StIDS[N];
				StIDS[N] = StIDS[N - 1];
				StIDS[N - 1] = temp2;

			}
		}
	}
	return;
}
//************************************  END OF FUNCTION BUBBLESORT  ***************************************

//***************************************** FUNTION FINDAVERAGESCORE  *************************************
float FindAverageScore(float TestS[], int EU)
{
		// Receives - The test score array and the amount of elements used.
		// Task - Calculates the average score.
		// Returns - The average score, as a float.

		// Set the initial total amount.
	float ScoreAdded = 0;
		// Loop through the test score array
	for (int i = 0; i < EU; i++){
			// Add the test score to the total.
		ScoreAdded += TestS[i];
	}
		// Calculate the average of the test scores.
	float Average = ScoreAdded / EU;

		// Return the average floating number.
	return Average;
}
//************************************  END OF FUNCTION FINDAVERAGESCORE  *********************************

//***************************************** FUNTION FINDMAXSCORE  *****************************************
int FindMaxScore(float TestS[], int EU)
{
		// Receives - The test score array and the amount of elements used.
		// Task - Finds the maximum score in the test score array.
		// Returns - The index where maximum score is located in the array, as an integer.

		// Set initial location for the maximum score.
	int MaxLoc = 0;
		// Set initial minimum score as the seed.
	int seed = 0;
		// Loop through the test score array
	for (int i = 0; i < EU; i++){
			// Check if the seed is less than the score in each recursion.
		if (seed < TestS[i]){
				// Assign the new value of the maximum score to the seed.
			seed = TestS[i];
				// Set the new location of the maximum score.
			MaxLoc = i;
		}
	}
		// Return the location.
	return MaxLoc;
}
//************************************  END OF FUNCTION FINDMAXSCORE  *************************************

//***************************************** FUNTION FINDMINSCORE  *****************************************
int FindMinScore(float TestS[], int EU)
{
		// Receives - The test score array and the amount of elements used.
		// Task - Finds the minimum score in the test score array.
		// Returns - The index where minimum score is located in the array, as an integer.

		// Set initial location for the minimum score.
	int MinLoc = 0;
		// Set initial minimum score as the seed.
	int seed = 150;
		// Loop through the test score array
	for (int i = 0; i < EU; i++){
			// Check if the seed is greater than the score in each recursion.
		if (seed > TestS[i]){
				// Assign the new value of the minimum score to the seed.
			seed = TestS[i];
				// Set the new location of the minimum score.
			MinLoc = i;
		}
	}
		// Return the location.
	return MinLoc;
}
//************************************  END OF FUNCTION FINDMINSCORE  *************************************

//***************************************** FUNTION PRINTORIGINALLISTS  ***********************************
void PrintLists(ofstream &Outfile, int StIDS[], float TestS[], int EU)
{
		// Receives - The output file, the student IDs array, the Test Scores array and the amount of
		//            elements used.
		// Task - Print two arrays in the output file.
		// Returns - Nothing.

		// Set the output file to print float numbers with two decimal places.
	Outfile.setf(ios::fixed);
	Outfile.precision(1);

	for (int i = 0; i < EU; i++){
		Outfile << setw(10) << StIDS[i];
		Outfile << setw(19) << TestS[i] << endl;
	}

	Outfile << endl;

	return;
}
//************************************  END OF FUNCTION PRINTORIGINALLISTS  *******************************

//***************************************** FUNTION READINPUTFILE  ****************************************
void ReadInputFile(ifstream &Infile, int StIDS[], float TestS[], int &EU)
{
		// Receives - The input file, the student IDs array, the Test Score array and the elements used
		//            in the arrays.
		// Task - Read the input file and save the values into arrays.
		// Returns - The student IDs array, the Test Score array and the Elements Used number.

		// Declare initial index values for the arrays
	int StID = 0;
	float TestScr = 0;

		// Read the first value from the input file
	Infile >> StID;

		// While the student ID is greater than zero
	while (StID > 0){

			// Read the second value from the input file
		Infile >> TestScr;
			// Assign the student ID to the student IDs array
		StIDS[EU] = StID;
			// Assign the test score to the test score array
		TestS[EU] = TestScr;
			// Increase by 1 the index of the arrays
		EU++;
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
	Outfile << setw(20) << "Assignment #3" << endl;
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