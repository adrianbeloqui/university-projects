//***************************************     PROGRAM IDENTIFICATION   ************************************
//*                                                                                                       * 
//* 	PROGRAM FILE NAME:   Prog1.cpp		    ASSIGNMENT  #:  1			Grade: _______                *
//*                                                                                                       *
//*  	PROGRAM AUTHOR:       ____________________________________                                        *
//*                                       Adrian Beloqui                                                  *
//*                                                                                                       *
//*  	COURSE #:   CSC  24400  11                               DUE DATE:    February 12, 2016           *
//*                                                                                                       *
//*********************************************************************************************************

//***************************************    PROGRAM DESCRIPTION   ****************************************
//*                                                                                                       *
//*      PROCESS: This program is designed to read a file with the information of the vehicles that enter *
//*      to the Missouri Western University's parking. It is then to read the information of one vehicle  *
//*      at a time. It is then to calculate the time spent inside the parking for that vehicle. It is     *
//*      then to calculate the parking free for that specific vehicle. Finally, it is to print the        *
//*      customer's ticket containing the following information: his/her car type, amount of ours inside  *
//*      the parking and parking fee.                                                                     *
//*                                                                                                       *
//*      USER DEFINED                                                                                     *
//*      MODULES      : main - Controlls the flow of the entire program, calling functions is the         *
//*                            right sequence.                                                            *
//*                     ReadValuesFromFile - Reads the information of one vehicle from the input file     *
//*                     CalculateTimeSpent - Calculates the amount in hours that one vehicle spent inside *
//*                                          the parking.                                                 *
//*                     CalculateAmountPaid - Calculates the parking fee of one vehicle in realtion with  *
//*                                           the time this car spent inside the parking.                 *
//*                     PrintTicket - Prints the input data of one vehicle, followed by the customer's    *
//*                                   ticket.                                                             *
//*                     PageBreak - Adds end lines to the output file.                                    *
//*                     Header - Prints a header in the output file.                                      *
//*                     Footer - Prints a footer in the output file.                                      *
//********************************************************************************************************* 

	//Imports
#include <fstream>
#include <iomanip>

	//Definition of logical operators
#define NOT !
#define AND &&
#define NOTEQUAL !=
#define EQUAL ==

	//Definition of namespace
using namespace std;

	//Function prototypes definitions
void Header(ofstream &);
void Footer(ofstream &);
void ReadValuesFromFile(ifstream &, char &, int &, int &, bool &);
void PrintTicket(ofstream &, char &, int &, int &);
int CalculateTimeSpent(int, int);
float CalculateAmountPaid(int, char);
void PageBreak(ofstream &);

//***************************************** FUNTION MAIN  ***************************************************
int main()
{
	ifstream InFile;
	ofstream OutFile;
	bool endOfFile = false;

		// Open the input file
	InFile.open("DATA1.TXT", ios::in);
	
		// Create the output file
	OutFile.open("OUTPUT1.TXT", ios::out);

		// Print the header in the output file
	Header(OutFile);

		// Initialize the counter of tickets printed in one page
	int LiveCount = 0;

	char CarType;
	int EntryTime;
	int ExitTime;

		// Do while the end of the input file is not reached
	do{
			// Read the information from the input file
		ReadValuesFromFile(InFile, CarType, EntryTime, ExitTime, endOfFile);

			// Check if the program has not reached the end of the input file
		if (NOT endOfFile)
		{
				// Print ticket for the vehicle. 
			PrintTicket(OutFile, CarType, EntryTime, ExitTime);
			
				// Increase by 1 the count of tickets printed in the page. 
			LiveCount++;

				// Check if there have been three printed tickets in the current page
			if (LiveCount == 3){

					// Print end lines to the output file
				PageBreak(OutFile);

					// Set the counter of tickets printed in one page to 0
				LiveCount = 0;
			}
		}
	} while (NOT endOfFile);

		// Print the footer in the output file.
	Footer(OutFile);

		// Close the files used. 
	InFile.close();
	OutFile.close();

	return 0;
}
//************************************  END OF FUNCTION MAIN  ***********************************************

//***************************************** FUNTION CALCULATEAMOUNTSPENT  ***********************************
void PageBreak(ofstream &Outfile)
{
		// Receives - The output file.
		// Task - Add end lines to the output file.
		// Returns - Nothing.

	for (int i = 0; i < 3; i++){
		Outfile << endl;
	}
}
//************************************  END OF FUNCTION CALCULATEAMOUNTSPENT  *******************************

//***************************************** FUNTION PRINTTICKET  ********************************************
void PrintTicket(ofstream &Outfile, char &CarType, int &EntryTime, int &ExitTime)
{
		// Receives - The output file, the car type variable, the entry time, variable and the exit time 
		//            variable
		// Task - Prints the input data, and the customer's ticket.
		// Returns - The car type, the entry time, and the exit time.

		// Calculate the time spent for a vehicle
	int TimeSpent = CalculateTimeSpent(EntryTime, ExitTime);

		// Calculate the parking fee for a vehicle
	float AmountPaid = CalculateAmountPaid(TimeSpent, CarType);

		// Print the input data.
	Outfile << "The inputa data was:" << endl;
	Outfile << "  " << CarType << " " << EntryTime << " " << ExitTime << endl << endl;

		// Print the customer's ticket.
	Outfile << "$$$$$$$$$$$$$$$$$$$$$$$$$" << endl;
	Outfile << "$                       $" << endl;
	Outfile << "$    MISSOURI WESTERN   $" << endl;
	Outfile << "$    UNIVERSITY         $" << endl;
	Outfile << "$                       $" << endl;
	Outfile << "$$$$$$$$$$$$$$$$$$$$$$$$$" << endl;
	Outfile << "$      PARKING FEE      $" << endl;
	Outfile << "$                       $" << endl;
	Outfile << "$  Customer             $" << endl;
	if (CarType EQUAL 'C')
		Outfile << "$  Category: Car        $" << endl;
	if (CarType EQUAL 'T')
		Outfile << "$  Category: Truck      $" << endl;
	if (CarType EQUAL 'S')
		Outfile << "$  Category: SC         $" << endl;
	Outfile << "$                       $" << endl;
	Outfile << "$" << setw(8) << "Time: " << setw(5) << TimeSpent << " hours" << setw(5) << "$" << endl;
	Outfile << "$                       $" << endl;
	Outfile << "$  Amount               $" << endl;
	Outfile.setf(ios::fixed);
	Outfile.precision(2);
	Outfile << "$" << setw(7) << "Paid:" << setw(6) << "$"  << AmountPaid << setw(7) << "$" << endl;
	Outfile << "$                       $" << endl;
	Outfile << "$$$$$$$$$$$$$$$$$$$$$$$$$" << endl << endl;
	return;
}
//************************************  END OF FUNCTION PRINTTICKET  ****************************************

//***************************************** FUNTION CALCULATEAMOUNTSPENT  ***********************************
float CalculateAmountPaid(int TimeSpent, char CarType)
{
		// Receives - The car type and the time spent of that car
		// Task - Calculates the parking fee for a car type depending on the time spent in the parking. 
		// Returns - The parking fee

		// Set the initial parking fee to 0.0.
	float TotalAmount = 0.0;

		// Loop from 1 to the total time spent increasing by 1 the variable i in each recursion. 
	for (int i = 1; i <= TimeSpent; i++){
		
			// Check if the car type is not 'S'
		if (CarType NOTEQUAL 'S'){

				// Depending of the value of i which represents the hours spent, and depending
				// on the category of the car, a specific fee is added to the total parking fee
			if (i EQUAL 1){
				if (CarType EQUAL 'C')
					TotalAmount += 0.20;
				else
					TotalAmount += 0.40;
			}
			if (i EQUAL 2){
				if (CarType EQUAL 'C')
					TotalAmount += 0.20;
				else
					TotalAmount += 0.25;
			}
			if (i > 2 AND i <= 4){
				if (CarType EQUAL 'C')
					TotalAmount += 0.15;
				else
					TotalAmount += 0.25;
			}
			if (i EQUAL 5){
				if (CarType EQUAL 'C')
					TotalAmount += 0.15;
				else
					TotalAmount += 0.10;
			}
			if (i > 5 AND i <= 15){
				if (CarType EQUAL 'C')
					TotalAmount += 0.05;
				else
					TotalAmount += 0.10;
			}
			if (i > 15 AND i <= 16){
				if (CarType EQUAL 'T')
					TotalAmount += 0.10;
			}
		}
			// The car type is 'S', so the same fee is added for each your spent in the parking.
		else  
		{
			TotalAmount += 0.12;
		}
	}
	return TotalAmount;
}
//************************************  END OF FUNCTION CALCULATEAMOUNTSPENT  *******************************

//***************************************** FUNTION CALCULATETIMESPENT  *************************************
int CalculateTimeSpent(int EntryTime, int ExitTime)
{
		// Receives - The car entry time and exit time.
		// Task - Calculates the amount in whole hours that a car spent inside the parking.
		// Returns - An integer that is the total amount of hours.

		// Calculate the total time spent inside the parking lot.
	int TotalTime = ExitTime - EntryTime;

		// Check if the module of the total time spent is greater than 0
	if ((TotalTime % 60) > 0){

			// Find the time difference that there is from the first whole hour that is higher than the
			// whole hour part of the total time spent in hours.
		int TimeDifference = 60 - (TotalTime % 60);
			// Add the time difference to the total time spent.
		int NewTotalTime = TotalTime + TimeDifference;
			// Return the new total time in hours 
		return (NewTotalTime / 60);
	}
	else{
			// Module of the total time spent was equal to 0 so it returns the amount in whole hours without 
			// calculations
		return (TotalTime / 60);
	}
	
}
//************************************  END OF FUNCTION CALCULATETIMESPENT  *********************************

//***************************************** FUNTION READVALUESFROMFILE  *************************************
void ReadValuesFromFile(ifstream &Infile, char &CarType, int &EntryTime, int &ExitTime, bool &endOfFile)
{
		// Receives - the input file, the car type variable, the entry time variable, the exit time variable
		//            and the boolean that determines the end of the file. 
		// Task - Reads the data for one vehicle.
		// Returns - The car type, the entry time, the exit time, and the boolean that determines the end 
		//           of the file.

		// Check if there is a following value to read from the input file, and check if that value is 
		// not equal to 'X', which determines the end of the file
	if ((Infile >> CarType) AND (CarType NOTEQUAL 'X'))
	{
			// Assign next two values to the entry time and exit time of that vehicle
		Infile >> EntryTime;
		Infile >> ExitTime;
	}
		// An 'X' was found as CarType
	else 
	{
			// Set end of file
		endOfFile = true;
	}
	return;
}
//************************************  END OF FUNCTION READVALUESFROMFILE  *********************************

//***************************************** FUNTION HEADER  *************************************************
void Header( ofstream &Outfile)
{                 
		// Receives - The output file
		// Task - Prints the output preamble
		// Returns - Nothing
	Outfile << setw(30) << "Adrian Beloqui ";
	Outfile << setw(17) << "CSC 24400";
	Outfile << setw(15) << "Section 11" << endl;
	Outfile << setw(30) << "Spring 2016";
	Outfile << setw(20) << "Assignment #1" << endl;
	Outfile << setw(35) << "------------------------------------------------";
	Outfile << setw(35) << "------------------------------------------------" << endl << endl;
	return;
}
//************************************  END OF FUNCTION HEADER  *********************************************

//***************************************** FUNTION FOOTER  *************************************************
void Footer( ofstream &Outfile)
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
//************************************  END OF FUNCTION FOOTER  *********************************************