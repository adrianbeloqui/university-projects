//***************************************     PROGRAM IDENTIFICATION   ************************************
//*                                                                                                       *
//* 	PROGRAM FILE NAME:   Program1.cpp		    ASSIGNMENT  #:  1			Grade: _______            *
//*                                                                                                       *
//*  	PROGRAM AUTHOR:       ____________________________________                                        *
//*                                       Adrian Beloqui                                                  *
//*                                                                                                       *
//*  	COURSE #:   CSC  36000  11                               DUE DATE:    Jan 23, 2016                *
//*                                                                                                       *
//*********************************************************************************************************

//***************************************    PROGRAM DESCRIPTION   ****************************************
//*                                                                                                       *
//*      PROCESS: This program is designed to read a file with an unknown number of passangers and        *
//*               assign a seat to each passanger in the various flights. Different rules are applied     *
//*               at the moment of assigning seats for a passanger. The program is to apply each rule     *
//*               accordingly. It is then to print the whole information for a flight including the       *
//*               seating chart and the waiting list of passangers.                                       *
//*                                                                                                       *
//*      USER DEFINED                                                                                     *
//*      MODULES      : main - Controlls the flow of the entire program, calling functions is the         *
//*                            right sequence and printing the labels into the output file.               *
//*                     Header - Prints a header in the output file.                                      *
//*                     Footer - Prints a footer in the output file.                                      *
//*                     PageBreak - Adds end lines to the output file.                                    *
//*                     ReadPassanger - Reads input file into a passanger structure                       *
//*                     GetFlightIndex - Gets a list's index for a specific flight number                 *
//*                     flightCLASS::TryHonorRequests - Attempts to assign a seat for the passanger's     *
//*                                                     requested seat.                                   *
//*                     flightCLASS::ApplyRuleOne - Attempts to assign a seat in the same row as the      *
//*                                                 passanger's requested row.                            *
//*                     flightCLASS::ApplyRuleTwo - Attempts to assign a seat in the same columns as the  *
//*                                                 passanger's requested row.                            *
//*                     flightCLASS::ApplyRuleThree - Attempts to assign a seat as forward as possible    *
//*                                                   for a specific passanger.                           *
//*                     flightCLASS::AddToWaitingList - Adds passanger to the flight's waiting list       *
//*                     flightCLASS::PrintFlightData - Prints flight number, departure and arrival city.  *
//*                     flightCLASS::PrintFlightSeats - Prints flight seating chart.                      *
//*                     flightCLASS::PrintFlightWaitingList - Prints flight waiting list.                 *
//*                                                                                                       *
//*********************************************************************************************************

	//Imports
#include <string>
#include <fstream>
#include <iomanip>

	//Definition of constants
#define NOT !
#define LinesPerPage 66

	//Definition of namespace
using namespace std;

	//Definition of passanger structure
struct passangerTYPE{
	int boardingNum;
	int flightNum;
	char section;
	int seatRow;
	int seatCol;
};

	//Definition of flight data structure
struct flightDataTYPE{
	char destinyCity[25];
	char departureCity[25];
	int flightNumber;
};

	//Definition of classes
class flightCLASS{

public:
		// Constructor
	flightCLASS(){ }
	flightCLASS(int fNum, char DCN[], char FCN[]);

		// Accessor functions
	flightDataTYPE GetFlightData() { return flightData; }
	void SetPrintingAvailability() { print = true; }
	bool GetPrintingAvailability() { return print; }
	void SetDestinyCity(char CN[]) { strcpy_s(flightData.destinyCity, 25, CN); }
	void SetDepartureCity(char CN[]) { strcpy_s(flightData.departureCity, 25, CN); }
	void SetFlightNumber(int num) { flightData.flightNumber = num; }

		// Functions
	bool TryHonorRequests(passangerTYPE &);
	bool ApplyRuleOne(passangerTYPE &);
	bool ApplyRuleTwo(passangerTYPE &);
	bool ApplyRuleThree(passangerTYPE &);
	void AddToWaitingList(passangerTYPE &);
	void PrintFlightWaitingList(ofstream &, int &);
	void PrintFlightSeats(ofstream &, int &);
	void PrintFlightData(ofstream &, int &);

private:
	flightDataTYPE flightData;
	int seatingChart[10][3];
	int waitingList[50];
	int waitlisted;
	bool print;
};

	//Function prototypes definitions
void Header(ofstream &);
void Footer(ofstream &);
void PageBreak(ofstream &, int &);
void ReadPassanger(ifstream &, passangerTYPE &, bool &);
int GetFlightIndex(flightCLASS[], passangerTYPE &);


//***************************************** FUNCTION MAIN  ************************************************
int main()
{
	ifstream InFile;
	ofstream OutFile;

		//Set initial variables
	flightCLASS flightList[8];
	passangerTYPE passanger;
	bool endOfFile = false, passangerSeated = false;
	int flightIndex = -1;
	int linesWritten = 0;

		//Set all flights available
	flightList[0] = flightCLASS(1010, "Memphis, Tennessee", "Jackson, Mississippi");
	flightList[1] = flightCLASS(1015, "Jackson, Mississippi", "Memphis, Tennessee");
	flightList[2] = flightCLASS(1020, "Little Rock, Arkansas", "Jackson, Mississippi");
	flightList[3] = flightCLASS(1025, "Jackson, Mississippi", "Little Rock, Arkansas");
	flightList[4] = flightCLASS(1030, "Shreveport, Louisiana", "Jackson, Mississippi");
	flightList[5] = flightCLASS(1035, "Jackson, Mississippi", "Shreveport, Louisiana");
	flightList[6] = flightCLASS(1040, "Orlando, Florida", "Jackson, Mississippi");
	flightList[7] = flightCLASS(1045, "Jackson, Mississippi", "Orlando, Florida");

		// Open the input file
	InFile.open("data1.txt", ios::in);

		// Create the output file
	OutFile.open("output1.txt", ios::out);

		// Print the header in the output file.
	Header(OutFile);
		// Add amount of lines written into the output file
	linesWritten += 3;
		// Print separator line
	OutFile << "=================================================="
		<< "==============================================" << endl << endl;
		// Add amount of lines written into the output file
	linesWritten += 2;

	do {
			// Read a passanger from the input file
		ReadPassanger(InFile, passanger, endOfFile);
			// Check if it the end of the file
		if (NOT endOfFile){
				// Get index of the flight requested from the list of flights
			flightIndex = GetFlightIndex(flightList, passanger);

				// Set the flight as available for printing
			flightList[flightIndex].SetPrintingAvailability();

				// Attempt to seat passanger in the requested seat
			passangerSeated = flightList[flightIndex].TryHonorRequests(passanger);

				// Check if the passanger was not seated
			if (NOT passangerSeated){
					// Apply first rule to attempt to seat the passanger
				passangerSeated = flightList[flightIndex].ApplyRuleOne(passanger);
					// Check if the passanger was not seated
				if (NOT passangerSeated){
						// Apply second rule to attempt to seat the passanger
					passangerSeated = flightList[flightIndex].ApplyRuleTwo(passanger);
						// Check if the passanger was not seated
					if (NOT passangerSeated){
							// Apply third rule to attempt to seat the passanger
						passangerSeated = flightList[flightIndex].ApplyRuleThree(passanger);
							// Check if the passanger was not seated
						if (NOT passangerSeated){
								// Add passanger to the flight's waiting list
							flightList[flightIndex].AddToWaitingList(passanger);
						}
					}
				}
			}
		}
	} while (NOT endOfFile);

		// Attempt to print each flight from the flights list
	for (int i = 0; i < 8; i++){
			// Check if the flight must be printed
		if (flightList[i].GetPrintingAvailability()){
				// Print airline header
			OutFile << setw(48) << "Southern Comfort Airlines" << endl << endl;
				// Add amount of lines written into the output file
			linesWritten += 2;
				// Print flight data
			flightList[i].PrintFlightData(OutFile, linesWritten);
				// Print flight seating chart
			flightList[i].PrintFlightSeats(OutFile, linesWritten);
				// Print label
			OutFile << "WAITING LIST" << endl << endl;
				// Add amount of lines written into the output file
			linesWritten += 2;
				// Print flight waiting list
			flightList[i].PrintFlightWaitingList(OutFile, linesWritten);
				// Print label
			OutFile << "END OF SEATING CHART" << endl;
				// Add amount of lines written into the output file
			linesWritten += 1;
				// Check if the last flight is being printed
			if (i != 7) {
					// Add page break
				PageBreak(OutFile, linesWritten);
			}
		}
	}

		// Print the footer into the output file.
	Footer(OutFile);

	return 0;
}
//************************************  END OF FUNCTION MAIN  *********************************************

//***************************************** FUNTION PAGEBREAK  ********************************************
void PageBreak(ofstream &Outfile, int &limit)
{
		// Receives - The output file and the amount of lines written in the current page.
		// Task - Add end lines to the output file.
		// Returns -  The output file and the amount of lines written in the current page.
		
		// Calculate amount of blank lines needed for new page
	limit = LinesPerPage - limit;

		// Print blank lines
	for (int i = 0; i < limit; i++){
		Outfile << endl;
	}
		// Reset amount of lines writen in one page
	limit = 0;
}
//************************************  END OF FUNCTION PAGEBREAK  ****************************************

//***************************************** FUNCTION PRINTFLIGHTWAITINGLIST *******************************
void flightCLASS::PrintFlightWaitingList(ofstream &OutFile, int &linesWritten)
{
		// Receives - The output file, and an integer indicating the amount of lines written in the output
		//            file
		// Task - Print a flight's waiting list into the output file
		// Returns - The output file, and an integer indicating the amount of lines written in the output
		//           file

	if (waitlisted == 0){
			// Print message when waiting list is empty
		OutFile << setw(45) << "There is no waiting list for this flight." << endl;
			// Add amount of lines written into the output file
		linesWritten += 1;
	}
	else{
			// Amount of boarding numbers printed so far
		int printed = 0;
			// Print the waiting list
		for (int i = 0; i < waitlisted; i++){
				// Print boarding number
			OutFile << setw(7) << waitingList[i];
				// Add one to the amount of boarding numbers printed
			printed++;
				// Check if it is time to print a new line
			if (printed == 10){
					// Print new line
				OutFile << endl;
					// Add amount of lines written into the output file
				linesWritten += 1;
					// Reset amount of boarding numbers printed
				printed = 0;
			}
		}
			// Print a blank line
		OutFile << endl;
			// Add amount of lines written into the output file
		linesWritten += 1;
	}
		// Print a blank line
	OutFile << endl;
		// Add amount of lines written into the output file
	linesWritten += 1;

	return;
}
//************************************  END OF FUNCTION PRINTFLIGHTWAITINGLIST  ***************************

//***************************************** FUNCTION PRINTFLIGHTSEATS *************************************
void flightCLASS::PrintFlightSeats(ofstream &OutFile, int &linesWritten)
{
		// Receives - The output file, and an integer indicating the amount of lines written in the output
		//            file
		// Task - Prints a flight's seating chart into the output file
		// Returns - The output file, and an integer indicating the amount of lines written in the output
		//           file

		// Print each row of the seating char into the output file
	for (int i = 0; i < 10; i++){
		OutFile << setw(12) << seatingChart[i][0];
		OutFile << setw(12) << seatingChart[i][1];
		OutFile << setw(12) << seatingChart[i][2] << endl;
	}

		// Print a blank line
	OutFile << endl;
		// Add amount of lines written into the output file
	linesWritten += 11;

	return;
}
//************************************  END OF FUNCTION PRINTFLIGHTSEATS  *********************************

//***************************************** FUNCTION PRINTFLIGHTDATA **************************************
void flightCLASS::PrintFlightData(ofstream &OutFile, int &linesWritten)
{
		// Receives - The output file, and an integer indicating the amount of lines written in the output
		//            file
		// Task - Print the flight number, departure city and arrival city into the output file
		// Returns - The output file, and an integer indicating the amount of lines written in the output
		//           file

		// Print flight number and departure city
	OutFile << "Flight " << GetFlightData().flightNumber << setw(40) 
		<< "FROM: " << GetFlightData().departureCity << endl;

		// Print arrival city
	OutFile << setw(49) << "TO: " << GetFlightData().destinyCity << endl << endl;

		// Add amount of lines written into the output file
	linesWritten += 3;

	return;
}
//************************************  END OF FUNCTION PRINTFLIGHTDATA  **********************************

//***************************************** FUNCTION ADDTOWAITINGLIST *************************************
void flightCLASS::AddToWaitingList(passangerTYPE &passanger)
{
		// Receives - The passanger structure
		// Task - Add a passanger to a flight's waiting list
		// Returns - The passanger structure

	waitingList[waitlisted++] = passanger.boardingNum;
	return;
}
//************************************  END OF FUNCTION ADDTOWAITINGLIST  *********************************

//***************************************** FUNCTION APPLYRULETHREE ***************************************
bool flightCLASS::ApplyRuleThree(passangerTYPE &passanger)
{
		// Receives - The passanger structure
		// Task - Attempts to seat the passanger as forward as possible, starting from the front left
		//        in the first vacant seat found.
		// Returns - A boolean indicating whether the passanger was seated or not, and the passanger

		// Check the passanger's requested section
	if (passanger.section == 'F'){
			// Check for vacant seats in the corresponding section
		for (int i = 0; i < 3; i++){
			for (int j = 0; j < 3; j++){
					// Check if the seat is vacant
				if (seatingChart[i][j] == -999){
						// Assign the passanger to the vacant seat
					seatingChart[i][j] = passanger.boardingNum;
						// Return signal that the passanger was seated successfully
					return true;
				}
			}
		}
	}
	else {
			// Check for vacant seats in the corresponding section
		for (int i = 3; i < 10; i++){
			for (int j = 0; j < 3; j++){
					// Check if the seat is vacant
				if (seatingChart[i][j] == -999){
						// Assign the passanger to the vacant seat
					seatingChart[i][j] = passanger.boardingNum;
						// Return signal that the passanger was seated successfully
					return true;
				}
			}
		}
	}

		// Return signal that the passanger was not seated successfully
	return false;
}
//************************************  END OF FUNCTION APPLYRULETHREE  ***********************************

//***************************************** FUNCTION APPLYRULETWO *****************************************
bool flightCLASS::ApplyRuleTwo(passangerTYPE &passanger)
{
		// Receives - The passanger structure
		// Task - Attempts to seat the passanger in the same column as the one requested as forward as
		//        possible, while not changing the section the passanger requested
		// Returns - A boolean indicating whether the passanger was seated or not, and the passanger

		// Check the passanger's requested section
	if (passanger.section == 'F'){
			// Check for vacant seats in the corresponding section' columns
		for (int i = 0; i < 3; i++){
				// Check if the seat for the column requested is vacant
			if (seatingChart[i][passanger.seatCol] == -999){
					// Assign the passanger to the vacant seat
				seatingChart[i][passanger.seatCol] = passanger.boardingNum;
					// Return signal that the passanger was seated successfully
				return true;
			}
		}
	}
	else {
			// Check for vacant seats in the corresponding section' columns
		for (int i = 3; i < 10; i++){
				// Check if the seat for the column requested is vacant
			if (seatingChart[i][passanger.seatCol] == -999){
					// Assign the passanger to the vacant seat
				seatingChart[i][passanger.seatCol] = passanger.boardingNum;
					// Return signal that the passanger was seated successfully
				return true;
			}
		}
	}
		// Return signal that the passanger was not seated successfully
	return false;
}
//************************************  END OF FUNCTION APPLYRULETWO  *************************************

//***************************************** FUNCTION APPLYRULEONE *****************************************
bool flightCLASS::ApplyRuleOne(passangerTYPE &passanger)
{
		// Receives - The passanger structure
		// Task - Attempts to seat the passanger in the same row as the one requested
		// Returns - A boolean indicating whether the passanger was seated or not, and the passanger

		// Check if there are vacant seats in the row
	for (int i = 0; i < 3; i++){
			// Check if the seat in the row the passanger requested is vacant
		if (seatingChart[passanger.seatRow][i] == -999){
				// Assign the passanger to the vacant seat
			seatingChart[passanger.seatRow][i] = passanger.boardingNum;
				// Return signal that the passanger was seated successfully
			return true;
		}
	}
		// Return signal that the passanger was not seated successfully
	return false;
}
//************************************  END OF FUNCTION APPLYRULEONE  *************************************

//***************************************** FUNCTION TRYHONORREQUESTS *************************************
bool flightCLASS::TryHonorRequests(passangerTYPE &passanger)
{
		// Receives - The passanger structure
		// Task - Attempts to assign the exact seat the passanger requested
		// Returns - A boolean indicating whether the passanger was seated or not, and the passanger

		// Check if the passanger's requested seat is vacant
	if (seatingChart[passanger.seatRow][passanger.seatCol] == -999){
			// Assign the passanger to the requested seat
		seatingChart[passanger.seatRow][passanger.seatCol] = passanger.boardingNum;
			// Return signal that the passanger was seated successfully
		return true;
	}
		// Return signal that the passanger was not seated successfully
	return false;
}
//************************************  END OF FUNCTION TRYHONORREQUESTS  *********************************

//***************************************** FUNTION GETFLIGHTINDEX  ***************************************
int GetFlightIndex(flightCLASS flightList[], passangerTYPE &passanger)
{
		// Receives - The list of flights and the passanger structure
		// Task - Find the index of the flight the passanger requested inside the flight list
		// Returns - The index of the passanger's flight

		// Search through the flight list
	for (int i = 0; i < 8; i++){
			// Check if the flight is the same as the passanger's flight
		if (flightList[i].GetFlightData().flightNumber == passanger.flightNum){
				// return flight index
			return i;
		}
	}
	return -1;
}
//************************************  END OF FUNCTION GETFLIGHTINDEX  ***********************************

//***************************************** FUNTION READPASSANGER  ****************************************
void ReadPassanger(ifstream &Infile, passangerTYPE &passanger, bool &endOfFile)
{
		// Receives - The input file, the passanger structure, and the end of file boolean
		// Task - Reads the passanger data from the input file while checking for the end of file
		// Returns - The input file, the passanger structure, and the end of file sentinel

		// Initialize local variables
	int tempBoardingNumber, tempRowNum;
	char seatColName;

		// Read the input values
	Infile >> ws;
		// Read first number
	Infile >> tempBoardingNumber;

		// Check if the first number indicates the end of file
	if (tempBoardingNumber == -999){
			// Establish end of file
		endOfFile = true;
	}
	else{
			// Set passanger boarding number
		passanger.boardingNum = tempBoardingNumber;
			// Read passanger flight number and section
		Infile >> passanger.flightNum;
		Infile >> passanger.section;
			// Read passanger row number
		Infile >> tempRowNum;
			// Set passanger row number to match array's indexing
		passanger.seatRow = tempRowNum - 1;
			// Read passanger column char
		Infile >> seatColName;
			// Set column number accordingly to the column char read
		switch (seatColName){
		case 'L':
			passanger.seatCol = 0;
			break;
		case 'M':
			passanger.seatCol = 1;
			break;
		case 'R':
			passanger.seatCol = 2;
			break;
		}
	}
	return;
}
//************************************  END OF FUNCTION READPASSANGER  ************************************

//***************************************** FUNCTION FLIGHTCLASS ******************************************
flightCLASS::flightCLASS(int fNum, char DCN[], char FCN[])
{
		// Receives - The flight number as an integer, the destiny city name as a char array, and the 
	    //            departure city name as a char array.
		// Task - Sets a flight information with the corresponding values and initializes the seating char
	    //        and the waiting list array
		// Returns - The flight instance

		// Set flight number
	SetFlightNumber(fNum);
		// Set flight's destiny city
	SetDestinyCity(DCN);
		// Set flight's departure city
	SetDepartureCity(FCN);
		// Initialize seating chart
	seatingChart[10][3] = { };

		// Set seats as vacant
	for (int i = 0; i < 10; i++){
		for (int j = 0; j < 3; j++){
			seatingChart[i][j] = -999;
		}
	}

		// Initialize waiting list
	waitingList[50] = { };
		// Set passagers waiting to zero
	waitlisted = 0;
		// Set flight to not print at this point
	print = false;

	return;
}
//************************************  END OF FUNCTION FLIGHTCLASS  **************************************

//***************************************** FUNCTION HEADER  **********************************************
void Header(ofstream &Outfile)
{
		// Receives - The output file
		// Task - Prints the output preamble
		// Returns - Nothing

	Outfile << setw(30) << "Adrian Beloqui ";
	Outfile << setw(17) << "CSC 36000";
	Outfile << setw(15) << "Section 11" << endl;
	Outfile << setw(30) << "Spring 2017";
	Outfile << setw(20) << "Assignment #1" << endl;
	Outfile << setw(35) << "------------------------------------------------";
	Outfile << setw(35) << "------------------------------------------------" << endl;
	return;
}
//************************************  END OF FUNCTION HEADER  *******************************************

//***************************************** FUNCTION FOOTER  **********************************************
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