//***************************************     PROGRAM IDENTIFICATION   ************************************
//*                                                                                                       *
//* 	PROGRAM FILE NAME:   Prog2.cpp		    ASSIGNMENT  #:  2			Grade: _______                *
//*                                                                                                       *
//*  	PROGRAM AUTHOR:       ____________________________________                                        *
//*                                       Adrian Beloqui                                                  *
//*                                                                                                       *
//*  	COURSE #:   CSC  24400  11                               DUE DATE:    February 26, 2016           *
//*                                                                                                       *
//*********************************************************************************************************

//***************************************    PROGRAM DESCRIPTION   ****************************************
//*                                                                                                       *
//*      PROCESS: This program is designed to read a file with up to 50 student IDs and test scores and   *
//*               store them in arrays. It is then to print both arrays in a readable way. It is then to  *
//*               print the student IDs in groups according to the letter grade they received. It is then *
//*               to find the minium and maximum scores and print these with they student ID associated   *
//*               to them. Finally, it is compute the average test score and print it.                    *
//*                                                                                                       *
//*      USER DEFINED                                                                                     *
//*      MODULES      : main - Controlls the flow of the entire program, calling functions is the         *
//*                            right sequence and printing the labels into the output file.               *
//*                     ReadInputFile - Reads the whole input file and stores the data into arrays.       *
//*                     PrintOriginalLists - Prints the student IDs and test score arrays into the output *
//*                                          file.                                                        *
//*                     GetListsByCourseGrade - Groups the student IDs into arrays according to their     *
//*                                             letter grade.                                             *
//*                     FindMinScore - Finds the location of the minimum score.                           *
//*                     FindMaxScore - Finds the location of the maximum score.                           *
//*                     FindAverageScore - Calculates the average score.                                  *
//*                     PrintGradesList - Prints a grade array into the output file.                      *
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
void PrintOriginalLists(ofstream &, int[], float[], int );
void GetListsByCourseGrade(ofstream &, int[], float[], int, int[], int[], int[], int[], int[]);
int FindMinScore(float[], int);
int FindMaxScore(float[], int);
float FindAverageScore(float[], int);
void PrintGradesList(ofstream &, int[], int);

//***************************************** FUNTION MAIN  *************************************************
int main()
{
	ifstream InFile;
	ofstream OutFile;
	int ElementsUsed = 0;
	int StudentIDs[ArrayInitialLenght], GradeA[ArrayInitialLenght], GradeB[ArrayInitialLenght];
	int GradeC[ArrayInitialLenght], GradeD[ArrayInitialLenght], GradeF[ArrayInitialLenght];
	float TestScores[ArrayInitialLenght];

		// Open the input file
	InFile.open("DATA2.TXT", ios::in);

		// Create the output file
	OutFile.open("OUTPUT2.TXT", ios::out);

		// Print the header in the output file.
	Header(OutFile);

		// Read the input file.
	ReadInputFile(InFile, StudentIDs, TestScores, ElementsUsed);

	OutFile << "The original list of test scores is:" << endl;
	OutFile << "Student ID #" << setw(14) << "Test Score" << endl;

		// Print the original arrays
	PrintOriginalLists(OutFile, StudentIDs, TestScores, ElementsUsed);
		
		// Group the student IDs by grades. 
	GetListsByCourseGrade(OutFile, StudentIDs, TestScores, ElementsUsed, GradeA, GradeB, GradeC, GradeD,
		GradeF);

	OutFile << endl;
	OutFile << "Students receiving a grade of A are:";
		// Print the student IDs that belong to the group of grades A.
	PrintGradesList(OutFile, GradeA, ElementsUsed);

	OutFile << "Students receiving a grade of B are:";
		// Print the student IDs that belong to the group of grades B.
	PrintGradesList(OutFile, GradeB, ElementsUsed);

	OutFile << "Students receiving a grade of C are:";
		// Print the student IDs that belong to the group of grades C.
	PrintGradesList(OutFile, GradeC, ElementsUsed);

	OutFile << "Students receiving a grade of D are:";
		// Print the student IDs that belong to the group of grades D.
	PrintGradesList(OutFile, GradeD, ElementsUsed);

	OutFile << "Students receiving a grade of F are:";
		// Print the student IDs that belong to the group of grades F.
	PrintGradesList(OutFile, GradeF, ElementsUsed);
	
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
	OutFile << "The average test score for the group was " << Average << endl ;

		// Print the footer into the output file.
	Footer(OutFile);


	return 0;
}
//************************************  END OF FUNCTION MAIN  *********************************************

//***************************************** FUNTION PRINTGRADESLIST  **************************************
void PrintGradesList(ofstream &OutFile, int GradeArray[], int EU)
{
		// Receives - The output file, an array of integers and the amount of elements used.
		// Task - Prints the array of integers.
		// Returns - Nothing.

	for (int i = 0; i < EU; i++){
		if (GradeArray[i] > 0){
			OutFile << setw(5) << GradeArray[i];
		}
	}
	OutFile << endl;

	return;
}
//************************************  END OF FUNCTION PRINTGRADESLIST  **********************************

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

//***************************************** FUNTION PRINTLISTSBYCOURSEGRADE  ******************************
void GetListsByCourseGrade(ofstream &Outfile, int StIDS[], float TestS[], int EU, int gradeA[], 
	int gradeB[], int gradeC[], int gradeD[], int gradeF[])
{
		// Receives - The output file, the student IDs array, the Test Scores array and the amount of
		//            elements used, and one array for each grade (A, B, C, D, and F).
		// Task - Assign each grade to their respective grade array.
		// Returns - The student IDs array, the Test Scores array and one array for 
		//           each grade (A, B, C, D, and F) filled with the corresponding data.

		// Loop through the Test Scores for each grade, and apply the conditions to meet the requirements
		// of each grade group. If the conditions are satisfied, the student ID related to the grade must
		// be assigned to the corresponding grade array.

		// Set an initial index to 0, to start assinging values to each grade array from the begining
		// of the array.

		// Set initial index.
	int index = 0;
		// Loop through each test score
	for (int i = 0; i < EU; i++){
			// Check the necessary condition that apply for the grade group. 
		if (TestS[i] > 90.0){
				// Assing student Id to the corresponding grade array.
			gradeA[index] = StIDS[i];
				// Increase index by 1.
			index++;
		}
	}

		// Set initial index.
	index = 0;
		// Loop through each test score
	for (int i = 0; i < EU; i++){
			// Check the necessary condition that apply for the grade group. 
		if (TestS[i] > 80.0 && TestS[i] < 90.0){
				// Assing student Id to the corresponding grade array.
			gradeB[index] = StIDS[i];
				// Increase index by 1.
			index++;
		}
	}

		// Set initial index.
	index = 0;
		// Loop through each test score
	for (int i = 0; i < EU; i++){
			// Check the necessary condition that apply for the grade group. 
		if (TestS[i] > 70.0 && TestS[i] < 80.0){
				// Assing student Id to the corresponding grade array.
			gradeC[index] = StIDS[i];
				// Increase index by 1.
			index++;
		}
	}
	
		// Set initial index.
	index = 0;
		// Loop through each test score
	for (int i = 0; i < EU; i++){
			// Check the necessary condition that apply for the grade group. 
		if (TestS[i] > 60.0 && TestS[i] < 70.0){
				// Assing student Id to the corresponding grade array.
			gradeD[index] = StIDS[i];
				// Increase index by 1.
			index++;
		}
	}
	
		// Set initial index.
	index = 0;
		// Loop through each test score
	for (int i = 0; i < EU; i++){
			// Check the necessary condition that apply for the grade group. 
		if (TestS[i] < 60.0){
				// Assing student Id to the corresponding grade array.
			gradeF[index] = StIDS[i];
				// Increase index by 1.
			index++;
		}
	}

	return;
}
//************************************  END OF FUNCTION PRINTLISTSBYCOURSEGRADE  **************************

//***************************************** FUNTION PRINTORIGINALLISTS  ***********************************
void PrintOriginalLists(ofstream &Outfile, int StIDS[], float TestS[], int EU)
{
		// Receives - The output file, the student IDs array, the Test Scores array and the amount of
		//            elements used.
		// Task - Print two arrays in the output file.
		// Returns - Nothing.

		// Set the output file to print float numbers with two decimal places.
	Outfile.setf(ios::fixed);
	Outfile.precision(2);

	for (int i = 0; i < EU; i++){
		Outfile << setw(4) << StIDS[i];
		Outfile << setw(19) << TestS[i] << endl;
	}
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
	Outfile << setw(20) << "Assignment #2" << endl;
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