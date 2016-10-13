//***************************************     PROGRAM IDENTIFICATION   ************************************
//*                                                                                                       *
//* 	PROGRAM FILE NAME:   Prog7.cpp		    ASSIGNMENT  #:  7			Grade: _______                *
//*                                                                                                       *
//*  	PROGRAM AUTHOR:       ____________________________________                                        *
//*                                       Adrian Beloqui                                                  *
//*                                                                                                       *
//*  	COURSE #:   CSC  24400  11                               DUE DATE:    May 10, 2016                *
//*                                                                                                       *
//*********************************************************************************************************

//***************************************    PROGRAM DESCRIPTION   ****************************************
//*                                                                                                       *
//*      PROCESS: This program is designed to read a file with up to 50 employee list records that        *
//*               contain payroll information about each employee. It is then to be able to act upon      *
//*               specific signals to in order to add, delete, update, or print one employee or the       *
//*               whole database. It is then to calculate the total amount of payroll and print it        *
//*               along with the information of the rest of the employees.                                *
//*                                                                                                       *
//*      USER DEFINED                                                                                     *
//*      MODULES      : main - Controlls the flow of the entire program, calling functions is the         *
//*                            right sequence and printing the labels into the output file.               *
//*                     Header - Prints a header in the output file.                                      *
//*                     Footer - Prints a footer in the output file.                                      *
//*                     PageBreak - Adds end lines to the output file.                                    *
//*                     employeeCLASS::ReadFlag - Read a character from the input file.                   *
//*                     employeeCLASS::ReadRecord - Read all the information of an employee               *
//*                     employeeCLASS::GetRecord - Read the information of the employee that              *
//*                                                is meant to be deleted.                                *
//*                     employeeCLASS::DeleteRecord - Deletes a record from the employee list             *
//*                     employeeCLASS::GetEditingData - Read the data needed to update a record           *
//*                     employeeCLASS::UpdateRecord - Updates the information of a record                 *
//*                     employeeCLASS::GetTypeOfPrinting - Read a character from the input file and       *
//*                                                        an integer.                                    *
//*                     employeeCLASS::PrintList - Prints the whole employee list in a readable way       *
//*                     employeeCLASS::PrintEmployee - Prints the information of an employee in           *
//*                                                    a readable way                                     *
//*                     employeeCLASS::ExchangeSortEmployeeID - Sort the employee list from low to high   *
//*                                                    based on the employees' Ids                        *
//*********************************************************************************************************

	//Imports
#include <string>
#include <fstream>
#include <iomanip>
#include <algorithm>

	//Definition of logical operators
#define ArrayInitialLenght 50

	//Definition of namespace
using namespace std;

	//Definition of structures
struct employeeTYPE{
	int Id;
	char FirstName[15];
	char LastName[15];
	char Department[17];
	char Title[17];
	float Pay;
	bool Visible;
};

	//Definition of classes
class employeeCLASS{
public:
		// Constructor
	employeeCLASS(){ TotalPayroll = 0.0; }

		// Accessor functions
	employeeTYPE GetEmployeeData() { return EmployeeData; }
	float GetTotalPayroll() { return TotalPayroll; }
	void SetTotalPayroll(float Pay) { TotalPayroll = Pay; }
	void SetVisible(bool newVisible) { Visible = newVisible; }
	bool GetVisible() { return Visible; }
	void SetID(int ID) { EmployeeData.Id = ID; }
	void SetFirstName(char FN[]) { strcpy_s(EmployeeData.FirstName, 15, FN); }
	void SetLastName(char LN[]) { strcpy_s(EmployeeData.LastName, 15, LN); }
	void SetDepartment(char DE[]) { strcpy_s(EmployeeData.Department, 17, DE); }
	void SetTitle(char TI[]) { strcpy_s(EmployeeData.Title, 17, TI); }
	void SetPay(float Pay) { EmployeeData.Pay = Pay; }

		// Functions
	void ExchangeSortEmployeeID(employeeCLASS[], int);
	void PrintEmployee(ofstream &, employeeCLASS[], int EU, int &);
	void PrintList(ofstream &, employeeCLASS[], int EU, float &);
	void GetTypeOfPrinting(ifstream &, char &, int &);
	void UpdateRecord(employeeCLASS[], int &, int &, char[], float &, int &EU);
	void GetEditingData(ifstream &, int &, int &, char[], float &);
	void DeleteRecord(int &, employeeCLASS[], int &);
	void GetRecord(ifstream &, int &);
	void ReadRecord(ifstream &, employeeCLASS[], int &);
	void ReadFlag(ifstream &, char &);
private:
	employeeTYPE EmployeeData;
	static float TotalPayroll;
	bool Visible;
};

	//Static variables
float employeeCLASS::TotalPayroll;

	//Function prototypes definitions
void Header(ofstream &);
void Footer(ofstream &);
void PageBreak(ofstream &, int);


//***************************************** FUNCTION MAIN  ************************************************
int main()
{
	ifstream InFile;
	ofstream OutFile;

		//Set initial variables
	employeeCLASS employeeList[ArrayInitialLenght];
	char Flag, EditingCharInfo[17], PrintingType;
	int ElementsUsed = 0, DeleteID, EditingID, EditingFieldID, PrintingID;
	float EditingFloatInfo, TotalPayroll;
	bool KeepReading = true;

		// Open the input file
	InFile.open("DATA7A.TXT", ios::in);

		// Create the output file
	OutFile.open("OUTPUT7.TXT", ios::out);

		// Print the header in the output file.
	Header(OutFile);
		// Print separator line
	OutFile << "=================================================="
		<< "===================================" << endl;

	do{
			// Read the Action code type character
		employeeList[0].ReadFlag(InFile, Flag);
			// Switch the transaction type to apply the instructions needed accordingly
		switch (Flag){
				// Instanciate
		case 'I': case 'i':
				// Read a record from the input file and add it to the employees list
			employeeList[0].ReadRecord(InFile, employeeList, ElementsUsed);
			break;
					// Deleting
		case 'D': case 'd':
				// Read the values of the record that is meant to be deleted
			employeeList[0].GetRecord(InFile, DeleteID);
				// Delete the record from the employee list. 
			employeeList[0].DeleteRecord(DeleteID, employeeList, ElementsUsed);
			break;
					// Updating
		case 'C': case 'c':
				// Read the values needed to edit a record.
			employeeList[0].GetEditingData(InFile, EditingID, EditingFieldID, EditingCharInfo
				, EditingFloatInfo);
				// Update the values of a record
			employeeList[0].UpdateRecord(employeeList, EditingID, EditingFieldID, EditingCharInfo
				, EditingFloatInfo,
				ElementsUsed);
			break;
				//Printing
		case 'P': case 'p':
				// Read from the input file what type of printing will be. 
			employeeList[0].GetTypeOfPrinting(InFile, PrintingType, PrintingID);
				// Check if the whole database needs to be printed
			if (PrintingType == 'E'){
					// Print column headers for the employee list
				OutFile << "ID #" << setw(20) << "Name" << setw(27) << "Department"
					<< setw(14) << "Position" << setw(12) << "Pay"<< endl;
				OutFile << "--------------------------------------------------------"
					<< "-----------------------------" << endl;
					//Sort the employee list accordingly to the employee's Id 
				employeeList[0].ExchangeSortEmployeeID(employeeList, ElementsUsed);
					// Print the database in a readable way
				employeeList[0].PrintList(OutFile, employeeList, ElementsUsed, TotalPayroll);

					// Print total payroll
				OutFile << "--------------------------------------------------------"
					<< "-----------------------------" << endl;
				OutFile << setw(60) << "Total Amount of Payroll" << setw(15)
					<< "$ " << TotalPayroll << endl;
					// Print separator line
				OutFile << "********************************************************"
					<< "*****************************" << endl;
					// Print line breaks
				PageBreak(OutFile, 2);
			}
			else{
					// Print column headers for the mailing list
				OutFile << "ID #" << setw(20) << "Name" << setw(27) << "Department"
					<< setw(14) << "Position" << setw(12) << "Pay" << endl;
				OutFile << "--------------------------------------------------------"
					<< "-----------------------------" << endl;
					// Print a specific employee into the output file in a readable way
				employeeList[0].PrintEmployee(OutFile, employeeList, ElementsUsed, PrintingID);
					// Print separator line
				OutFile << "********************************************************"
					<< "*****************************" << endl;
					// Print line breaks
				PageBreak(OutFile, 40);
			}
			break;
				// Quit program
		case 'Q': case 'q':
				// Set signal value to stop iterating
			KeepReading = false;
			break;
		}
	} while (KeepReading);

		// Print the footer into the output file.
	Footer(OutFile);

	return 0;
}
//************************************  END OF FUNCTION MAIN  *********************************************

//***************************************** FUNTION PAGEBREAK  ********************************************
void PageBreak(ofstream &Outfile, int limit)
{
		// Receives - The output file.
		// Task - Add end lines to the output file.
		// Returns - Nothing.

	for (int i = 0; i < limit; i++){
		Outfile << endl;
	}
}
//************************************  END OF FUNCTION PAGEBREAK  ****************************************

//***************************************** FUNTION EXCHANGESORTEMPLOYEEID  *******************************
void employeeCLASS::ExchangeSortEmployeeID(employeeCLASS EmpList[], int EU)
{
		// Receives - The employee list and the elements used integer
		// Task - Sort from low to high all the array based on the employee's Ids.
		// Returns - The employee list array sorted.

		// Set helper variables
	employeeCLASS temp;

		// Loop through the array
	for (int M = 0; M < EU - 1; M++)
	{
			// Set the index of the minimum location to the current cycle of the loop
		int Min = M;
			// Loop through the array from right to left
		for (int N = EU - 1; N > M; N--){
				// Check if the employee ID in the current cycle of the loop is higher 
				// than the minimum location stored
			if (EmpList[N].GetEmployeeData().Id < EmpList[Min].GetEmployeeData().Id){
					// Update the location of the minimum employee Id
				Min = N;
			}
		}
			// Swap the employees to update the order
		temp = EmpList[M];
		EmpList[M] = EmpList[Min];
		EmpList[Min] = temp;

	}
}
//************************************  END OF FUNCTION EXCHANGESORTEMPLOYEEID ****************************

//***************************************** FUNCTION PRINTEMPLOYEE ****************************************
void employeeCLASS::PrintEmployee(ofstream &Outfile, employeeCLASS EmpList[], int EU, int &PrintingID)
{
		// Receives - The output file, the employee list, the elements used integer, and the id of
		//            the record to be printed
		// Task - Print the information of a specific employee
		// Returns - The output file, the employee list, and the id of
		//           the record to be printed

		// Set helper variables
	bool found = false;

		//Set format of floating numbers in the output file
	Outfile.setf(ios::fixed);
	Outfile.precision(2);
	Outfile.right;

		// Iterate through the list of employees
	for (int i = 0; i < EU; i++){
			// Check if the employee is the one that is meant to be printed 
		if (EmpList[i].GetEmployeeData().Id == PrintingID){
			if (EmpList[i].GetVisible() != false){
				Outfile << EmpList[i].GetEmployeeData().Id << setw(22)
					<< EmpList[i].GetEmployeeData().FirstName << setw(10)
					<< EmpList[i].GetEmployeeData().LastName
					<< setw(10) << EmpList[i].GetEmployeeData().Department << setw(10)
					<< EmpList[i].GetEmployeeData().Title << setw(3)
					<< "$ " << setw(9) << EmpList[i].GetEmployeeData().Pay << endl;
			}
		}
	}
	Outfile << endl;
	return;
}
//************************************  END OF FUNCTION PRINTEMPLOYEE  ************************************

//***************************************** FUNCTION PRINTLIST ********************************************
void employeeCLASS::PrintList(ofstream &Outfile, employeeCLASS EmpList[], int EU, float &Payroll)
{
		// Receives - The output file, the employee list, the elements used, and a float number
		// Task - Print the list in a readable way
		// Returns - A float number determinating the total amount of payroll. 
		
		// Set helper variables
	float sumPayroll = 0.0;
	int index;

		//Set format of floating numbers in the output file
	Outfile.setf(ios::fixed);
	Outfile.precision(2);
	Outfile.right;

		// Iterate through the list of employees
	for (int i = 0; i < EU; i++){
		if (EmpList[i].GetVisible() != false){
			Outfile << EmpList[i].GetEmployeeData().Id << setw(22) 
				<< EmpList[i].GetEmployeeData().FirstName << setw(10) 
				<< EmpList[i].GetEmployeeData().LastName
				<< setw(10) << EmpList[i].GetEmployeeData().Department << setw(10) 
				<< EmpList[i].GetEmployeeData().Title << setw(3)
				<< "$ " << setw(9) << EmpList[i].GetEmployeeData().Pay << endl;
				// Sum the pay of an employee to the total payroll
			sumPayroll += EmpList[i].GetEmployeeData().Pay;
			index = i;
		}
	}
	Outfile << endl;
		// Set the sum of the pays to the total payroll
	Payroll = sumPayroll;
		// Set the total payroll in the array of objects
	EmpList[index].SetTotalPayroll(sumPayroll);
	return;
}
//************************************  END OF FUNCTION PRINTLIST  ****************************************

//***************************************** FUNCTION GETTYPEOFPRINTING ************************************
void employeeCLASS::GetTypeOfPrinting(ifstream &Infile, char &PrintOpt, int &PrintID)
{
		// Receives - The input file, a character and an integer
		// Task - Read the printing option, and the Id of the record to be printed
		// Returns - The character that determinates the printing option, and the Id of the record

		// Read the values from the input file
	Infile >> ws;
	Infile.get(PrintOpt);
		//Check if the printing option is of one employee in specific
	if (PrintOpt != 'E'){
		Infile >> PrintID;
	}
	return;
}
//************************************  END OF FUNCTION GETTYPEOFPRINTING  ********************************

//***************************************** FUNCTION UPDATERECORD *****************************************
void employeeCLASS::UpdateRecord(employeeCLASS EmpList[], int &EdID, int &FieldID, char NewInfo[],
	float &NewFloat, int &EU)
{
		// Receives - The employee list, the editing id, field id and new information of the record
		//            that is meant to be edited and the elements used integer
		// Task - Update a record from the employee list. 
		// Returns - The employee list, the editing id, field id and new information of the record

		//Set helper values
	int indexFound = -1;

		// Search for the index of the employee in the employee list
	for (int i = 0; i < EU; i++){
		if (EmpList[i].GetEmployeeData().Id == EdID){
			indexFound = i; 
		}
	}

		//Switch the field id between the different given cases to apply their specific
		//instruction
	switch (FieldID){
	case 1:
		char tempFName[15];
		strcpy_s(tempFName, 15, NewInfo);
		EmpList[indexFound].SetFirstName(tempFName);
		break;
	case 2:
		char tempLName[15];
		strcpy_s(tempLName, 15, NewInfo);
		EmpList[indexFound].SetLastName(tempLName);
		break;
	case 3:
		char tempDept[17];
		strcpy_s(tempDept, 17, NewInfo);
		EmpList[indexFound].SetDepartment(tempDept);
		break;
	case 4:
		char tempTitle[17];
		strcpy_s(tempTitle, 17, NewInfo);
		EmpList[indexFound].SetTitle(tempTitle);
		break;
	case 5:
		EmpList[indexFound].SetPay(NewFloat);
		break;
	}

	return;
}
//************************************  END OF FUNCTION UPDATERECORD  *************************************

//***************************************** FUNCTION GETEDITINGDATA ***************************************
void employeeCLASS::GetEditingData(ifstream &Infile, int &EditingID, int &FieldID, char EditingNewInfo[],
	float &EditingFloatInfo)
{
		// Receives - The input file, the id of the record to be edited, the id of the file, the char
		//            array to store the new information, and the float variable to store the new pay
		// Task - Read from the input file the id to be edited, the field id, and the new information
		// Returns - The id of the record to be edited, the id of the file, the char
		//           array to store the new information, and the float variable to store the new pay

		// Read the values from the input file
	Infile >> EditingID;
	Infile >> FieldID;
	if (FieldID == 5){
		Infile >> EditingFloatInfo;
	}
	else{
		Infile >> ws;
		Infile.getline(EditingNewInfo, 17);
	}
	return;
}
//************************************  END OF FUNCTION GETEDITINGDATA  ***********************************

//***************************************** FUNCTION DELETERECORD *****************************************
void employeeCLASS::DeleteRecord(int &DeleteID, employeeCLASS EmpList[], int &EU)
{
		// Receives - The id of the employee to be deleted, the list of employees and the elements used
		// Task - "Deletes" a record from the employees list
		// Returns - The id of the employee to be deleted, the list of employees and the elements used


	for (int i = 0; i < EU; i++){
			// Check if the Id of the employee to be deleted is equal to the one in the iteration
		if (EmpList[i].GetEmployeeData().Id == DeleteID){
				// Set the employee to be deleted as not visible
			EmpList[i].SetVisible(false);
		}
	}

	return;
}
//************************************  END OF FUNCTION DELETERECORD  *************************************

//***************************************** FUNCTION GETRECORD ********************************************
void employeeCLASS::GetRecord(ifstream &Infile, int &DeleteID)
{
		// Receives - The input file, and an integer
		// Task - Read the ID of the record that needs to be deleted
		// Returns - The id of the record to be deleted

		// Read the values from the input file
	Infile >> DeleteID;
	return;
}
//************************************  END OF FUNCTION GETRECORD  ****************************************

//***************************************** FUNCTION READRECORD *******************************************
void employeeCLASS::ReadRecord(ifstream &Infile, employeeCLASS empList[], int &EU)
{
		// Receives - The input file, the list of employees, and the elements used
		// Task - Reads the values of one employee from the input file
		// Returns - The list of employees, and the elements used

		// Set the helper variables
	int tempID;
	char TempFName[15], TempLName[15], TempDept[17], TempTit[17];
	float TempPay;
		// Read the input values into the helper variables
	Infile >> tempID;
	Infile >> ws;
	Infile.getline(TempFName, 15);
	Infile.getline(TempLName, 15);
	Infile.getline(TempDept, 17);
	Infile.getline(TempTit, 17);
	Infile >> TempPay;

		// Copy each value read into the corresponding variable of the employee
	empList[EU].SetVisible(true);
	empList[EU].SetID(tempID);
	empList[EU].SetFirstName(TempFName);
	empList[EU].SetLastName(TempLName);
	empList[EU].SetDepartment(TempDept);
	empList[EU].SetTitle(TempTit);
	empList[EU].SetPay(TempPay);

		//Increase elements used counter
	EU++;

	return;
}
//************************************  END OF FUNCTION READRECORD  ***************************************

//***************************************** FUNCTION READFLAG *********************************************
void employeeCLASS::ReadFlag(ifstream &Infile, char &flag)
{
		// Receives - The input file and a character
		// Task - Reads a character from the input file
		// Returns - The character read

		// Read the code character value from the input file
	Infile >> ws;
	Infile.get(flag);
	return;
}
//************************************  END OF FUNCTION READFLAG  *****************************************

//***************************************** FUNCTION HEADER  **********************************************
void Header(ofstream &Outfile)
{
		// Receives - The output file
		// Task - Prints the output preamble
		// Returns - Nothing

	Outfile << setw(30) << "Adrian Beloqui ";
	Outfile << setw(17) << "CSC 24400";
	Outfile << setw(15) << "Section 11" << endl;
	Outfile << setw(30) << "Spring 2016";
	Outfile << setw(20) << "Assignment #7" << endl;
	Outfile << setw(35) << "------------------------------------------------";
	Outfile << setw(35) << "------------------------------------------------" << endl << endl;
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