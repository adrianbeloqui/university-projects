//***************************************     PROGRAM IDENTIFICATION   ************************************
//*                                                                                                       *
//* 	PROGRAM FILE NAME:   Prog6.cpp		    ASSIGNMENT  #:  6			Grade: _______                *
//*                                                                                                       *
//*  	PROGRAM AUTHOR:       ____________________________________                                        *
//*                                       Adrian Beloqui                                                  *
//*                                                                                                       *
//*  	COURSE #:   CSC  24400  11                               DUE DATE:    April 26, 2016              *
//*                                                                                                       *
//*********************************************************************************************************

//***************************************    PROGRAM DESCRIPTION   ****************************************
//*                                                                                                       *
//*      PROCESS: This program is designed to read a file with up to 50 mailing list records that         *
//*               contain personal information about each customer. It is then to be able to act upon     *
//*               specific signals to in order to add, delete, update, or print one customer or the       *
//*               whole database. It is then to print success or error message depending on each action   *
//*               requested and if there were any problems while do in what was requested.                *                                                                  *
//*                                                                                                       *
//*      USER DEFINED                                                                                     *
//*      MODULES      : main - Controlls the flow of the entire program, calling functions is the         *
//*                            right sequence and printing the labels into the output file.               *
//*                     Header - Prints a header in the output file.                                      *
//*                     Footer - Prints a footer in the output file.                                      *
//*                     ReadFlag - Read a character from the input file.                                  *
//*                     ReadRecord - Read all the information of a customer and check if this is not      *
//*                                  already in the list.                                                 *
//*                     GetRecord - Read the information of the customer that is meant to be deleted      *
//*                     DeleteRecord - Deletes a record from the mailing list if this in it               *
//*                     GetEditingData - Read the data needed to update a record                          *
//*                     UpdateRecord - Updates the information of a record if this in the mailing list    *
//*                     GetTypeOfPrinting - Read a character from the input file and an array of          *
//*                                         characters.                                                   *
//*                     PrintList - Prints the whole mailing list in a readable way                       *
//*                     PrintCustomer - Prints the information of a customer in a readable way            *
//*                     ErrorMessage - Prints an error message when an exception occurs.                  *
//*                     SuccessMessage - Prints a success message when an action is completed succesfully *
//*                     ExchangeSortCustomerLastName - Sort the mailing list from A to Z based on the     *
//*                                                    customers' last names.                             *
//*********************************************************************************************************

	//Imports
#include <string>
#include <fstream>
#include <iomanip>

	//Definition of logical operators
#define ArrayInitialLenght 50

	//Definition of namespace
using namespace std;

	//Definition of structures
struct customerTYPE{
	char LastName[13];
	char FirstName[13];
	char StreetAddr[21];
	char City[13];
	char State[3];
	char Zip[6];
	bool Visible;
};

	//Function prototypes definitions
void Header(ofstream &);
void Footer(ofstream &);
void ReadFlag(ifstream &, char &);
void ReadRecord(ifstream &, customerTYPE [], int &, bool &, int &);
void GetRecord(ifstream &, char [], char []);
void DeleteRecord(char[], char[], customerTYPE [], int &, bool &, int &);
void GetEditingData(ifstream &, char[], int &, char[]);
void UpdateRecord(customerTYPE[], char[], int &, char[], int &, bool &, int &);
void GetTypeOfPrinting(ifstream &, char &, char[]);
void PrintList(ofstream &, customerTYPE [], int );
void PrintCustomer(ofstream &, customerTYPE [], int, char [], bool &, int &);
void ErrorMessage(ofstream &, char);
void SuccessMessage(ofstream &, customerTYPE [], char, int);
void ExchangeSortCustomerLastName(customerTYPE [], int );

//***************************************** FUNCTION MAIN  ************************************************
int main()
{
	ifstream InFile;
	ofstream OutFile;

		//Set initial variables
	customerTYPE customerList[ArrayInitialLenght];
	bool KeepReading = true, NoExceptions = true;
	char DeleteFirstName[13], DeleteLastName[13], Flag, EditingLastName[13], EditingNewInfo[21]
		, PrintingType, PrintingLastName[13];
	int ElementsUsed = 0, EditingFieldID, Index;

		// Open the input file
	InFile.open("DATA6.TXT", ios::in);

		// Create the output file
	OutFile.open("OUTPUT6.TXT", ios::out);

		// Print the header in the output file.
	Header(OutFile);

	do{
			// Read the Transaction type character
		ReadFlag(InFile, Flag);
			// Set the variable that tells there are no exceptions to true before each iteration
		NoExceptions = true;
			// Switch the transaction type to apply the instructions needed accordingly
		switch (Flag){
			// Addition
		case 'A':
				// Read a record from the input file and add it to the customers list if it does
				// not exists already
			ReadRecord(InFile, customerList, ElementsUsed, NoExceptions, Index);
				// Print error or success message depending on the boolean that controls the exceptions
			if (!NoExceptions){
				ErrorMessage(OutFile, Flag);
			}
			else{
				SuccessMessage(OutFile, customerList, Flag, Index);
			}
			break;
			// Deleting
		case 'D':
				// Read the values of the record that is meant to be deleted
			GetRecord(InFile, DeleteFirstName, DeleteLastName);
				// Delete the record from the customers list if this is in it. 
			DeleteRecord(DeleteFirstName, DeleteLastName, customerList, ElementsUsed
				, NoExceptions, Index);
				// Print error or success message depending on the boolean that controls the exceptions
			if (!NoExceptions){
				ErrorMessage(OutFile, Flag);
			}
			else{
				SuccessMessage(OutFile, customerList, Flag, Index);
			}
			break;
			// Updating
		case 'C':
				// Read the values needed to edit a record.
			GetEditingData(InFile, EditingLastName, EditingFieldID, EditingNewInfo);
				// Update the values of a record if this is in the customers list
			UpdateRecord(customerList, EditingLastName, EditingFieldID, EditingNewInfo, ElementsUsed
				, NoExceptions, Index);
				// Print error or success message depending on the boolean that controls the exceptions
			if (!NoExceptions){
				ErrorMessage(OutFile, Flag);
			}
			else{
				SuccessMessage(OutFile, customerList, Flag, Index);
			}
			break;
			//Printing
		case 'P':
				// Read from the input file what type of printing will be. 
			GetTypeOfPrinting(InFile, PrintingType, PrintingLastName);
				// Check if the whole database needs to be printed
			if(PrintingType == 'E'){
					// Print label for the mailing list
				OutFile << setw(43) << "MAILING LIST" << endl;
					// Print column headers for the mailing list
				OutFile << "Customer" << setw(7) << "Last" << setw(13) << "First" 
					<< setw(10) << "       " << setw(10) << "    " << setw(10) << "     " 
					<< setw(22) << "Zip" << endl;
				OutFile << "Number" << setw(9) << "Name" << setw(12) << "Name" << setw(15) 
					<< "Address" << setw(17)
					<< "City" << setw(14) << "State" << setw(8) << "Code" << endl;
				OutFile << "==================================================" 
					<< "================================" << endl;
					//Sort the mailing list alphabetically 
				ExchangeSortCustomerLastName(customerList, ElementsUsed);
					// Print the database in a readable way
				PrintList(OutFile, customerList, ElementsUsed);
			}
			else{
					// Print a specific customer into the output file in a readable way
				PrintCustomer(OutFile, customerList, ElementsUsed, PrintingLastName, NoExceptions, Index);
					// Print error or success message depending on the boolean that controls the exceptions
				if (!NoExceptions){
					ErrorMessage(OutFile, Flag);
				}
				else{
					SuccessMessage(OutFile, customerList, Flag, Index);
				}
			}
			break;
			// Quit program
		case 'Q':
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

//***************************************** FUNTION EXCHANGESORTCUSTOMERLASTNAME  **************************
void ExchangeSortCustomerLastName(customerTYPE mailingList[], int EU)
{
		// Receives - The mailing list and the elements used integer
		// Task - Sort from A to Z all the arrays based on the customer's last names.
		// Returns - The mailing list array sorted.

	customerTYPE temp;

		// Loop through the array
	for (int M = 0; M < EU - 1; M++)
	{
			// Set the index of the minimum location to the current cycle of the loop
		int Min = M;
			// Loop through the array from right to left
		for (int N = EU - 1; N > M; N--){
				// Check if the student last name in the current cycle of the loop is higher than the minimum
				// location stored
			if (strcmp(mailingList[N].LastName, mailingList[Min].LastName) < 0){
					// Update the location of the minimum student last name
				Min = N;
			}
		}
			// Swap the customers to update the order
		temp = mailingList[M];
		mailingList[M] = mailingList[Min];
		mailingList[Min] = temp;

	}
}
//************************************  END OF FUNCTION EXCHANGESORTCUSTOMERLASTNAME **********************

//***************************************** FUNCTION SUCCESSMESSAGE ***************************************
void SuccessMessage(ofstream &Outfile, customerTYPE mailingList[], char flag, int Index)
{
		// Receives - The output file, the customers list, a character and an integer
		// Task - Print a message with the customers information for each successful transaction
		// Returns - Nothing. 

		//Switch the character that identifies the transaction type and print the message accordingly. 
	switch (flag){
	case 'A':
		Outfile << "New customer " << mailingList[Index].FirstName << "" 
			<< mailingList[Index].LastName << " successfully added to the database! " << endl;
		Outfile << "**********************************************************************" << endl;
		break;
	case 'D':
		Outfile << "Customer " << mailingList[Index].FirstName << ""
			<< mailingList[Index].LastName << " successfully removed from the database! " << endl;
		Outfile << "**********************************************************************" << endl;
		break;
	case 'C':
		Outfile << "Customer " << mailingList[Index].FirstName << ""
			<< mailingList[Index].LastName << " successfully updated! " << endl;
		Outfile << "**********************************************************************" << endl;
		break;
	}

	return;
}
//************************************  END OF FUNCTION SUCCESSMESSAGE  ***********************************

//***************************************** FUNCTION ERRORMESSAGE *****************************************
void ErrorMessage(ofstream &Outfile, char flag)
{
		// Receives - The output file and a character
		// Task - Print an error message accordingly to the character that the function receives
		// Returns - Nothing.

		//Switch the flag that identifies the transaction type, and print the message accordingly. 
	switch (flag){
	case 'A':
		Outfile << "ERROR ! Attempt to add a duplicate record. Attempt failed!" << endl;
		Outfile << "**********************************************************************" << endl;
		break;
	case 'D':
		Outfile << "ERROR ! Attempt to delete a non-exitent record. Attempt failed!" << endl;
		Outfile << "**********************************************************************" << endl;
		break;
	case 'C':
		Outfile << "ERROR ! Attempt to change a non-existent record. Attempt failed!" << endl;
		Outfile << "**********************************************************************" << endl;
		break;
	case 'P':
		Outfile << "ERROR ! Attempt to print a non-existent record. Attempt failed!" << endl;
		Outfile << "**********************************************************************" << endl;
		break;
	}
	
	return;
}
//************************************  END OF FUNCTION ERRORMESSAGE  *************************************

//***************************************** FUNCTION PRINTCUSTOMER ****************************************
void PrintCustomer(ofstream &Outfile, customerTYPE mailingList[], int EU, char PLastName[]
	, bool &NoExceptions, int &Index)
{
		// Receives - The output file, the customers list, the elements used integer, the last name of
		//            the record to be printed, the boolean that controls the exceptions and the index
		//            integer
		// Task - Print the information of a specific customer if this is in the list
		// Returns - The boolean that controls the exceptions and the index integer

	bool found = false;

		//Check if an attempt of printing non-records is occuring
	for (int i = 0; i < EU; i++){
			//Check if the last name is in the customers list
		if (strcmp(PLastName, mailingList[i].LastName) == 0){
				//Check if the customer is not deleted
			if (mailingList[i].Visible != false){
				found = true;
				Index = i;

				Outfile << "Customer Number: " << (i + 1) << endl;
				Outfile << setw(13) << "Name: " << mailingList[i].FirstName << " " 
					<< mailingList[i].LastName << setw(11) << "Address: " 
					<< mailingList[i].StreetAddr << endl;
				Outfile << setw(13) << "City: " << mailingList[i].City << setw(22)
					<< "State: " << mailingList[i].State << setw(13) << "Zip Code: " 
					<< mailingList[i].Zip << endl;

				Outfile << "**********************************************************************" << endl;
			}
		}
	}

	if (!found){
			//Raise an exception if there is no record to print
		NoExceptions = false;
	}
	
	return;
}
//************************************  END OF FUNCTION PRINTCUSTOMER  ************************************

//***************************************** FUNCTION PRINTLIST ********************************************
void PrintList(ofstream &Outfile, customerTYPE mailingList[], int EU)
{
		// Receives - The output file, the customers list, and the elements used
		// Task - Print the list in a readable way
		// Returns - Nothing. 

	for (int i = 0; i < EU; i++){
		if (mailingList[i].Visible != false){
			Outfile << (i+1) << setw(22) << mailingList[i].LastName << setw(10) << mailingList[i].FirstName
				<< setw(10) << mailingList[i].StreetAddr << setw(10) << mailingList[i].City << setw(5) 
				<< mailingList[i].State << setw(10) << mailingList[i].Zip << endl;
		}
	}
	Outfile << "**********************************************************************" << endl;
	return;
}
//************************************  END OF FUNCTION PRINTLIST  ****************************************

//***************************************** FUNCTION GETTYPEOFPRINTING ************************************
void GetTypeOfPrinting(ifstream &Infile, char &PrintOpt, char PLastName[])
{
		// Receives - The input file, a character and an array of characters
		// Task - Read the printing option, and the last name of the record to be printed
		// Returns - The character that determinates the printing option, and the last name of the record

		// Read the values from the input file
	Infile >> ws;
	Infile.get(PrintOpt);
		//Check if the printing option is of one customer in specific
	if (PrintOpt != 'E'){
		Infile >> ws;
		Infile.getline(PLastName, 13);
	}
	return;
}
//************************************  END OF FUNCTION GETTYPEOFPRINTING  ********************************

//***************************************** FUNCTION UPDATERECORD *****************************************
void UpdateRecord(customerTYPE mailingList[], char EdLastName[], int &FieldID, char NewInfo[], 
	int &EU, bool &NoExceptions, int &Index)
{
		// Receives - The customers list, the last name, field id and new information of the record
		//            that is meant to be edited, the elements used integer, the boolean that controls
		//            the exceptions, and the index integer
		// Task - Update a record from the customers list if this is in the list. 
		// Returns - The customers list, the last name, field id and new information of the record
		//           that is meant to be edited, the elements used integer, the boolean that controls
		//           the exceptions, and the index integer

		//Set helper values
	bool found = false;
	int indexFound = -1;

		//Check if an attempt of changing non-records is occuring
	for (int i = 0; i < EU; i++){
			//Check if the lastname of the record meant to be edited is in the list
		if ((strcmp(EdLastName, mailingList[i].LastName) == 0)){
				//Check if the record is not deleted
			if (mailingList[i].Visible != false){
				found = true;
				indexFound = i;
			}
		}
	}

	if (!found){
			//Raise an exception if a record is not found
		NoExceptions = false;
	}
	else{
			//Set the index to the index of the record found
		Index = indexFound;
			//Switch the field id between the different given cases to apply their specific
			//instruction
		switch (FieldID){
		case 1:
			strcpy_s(mailingList[indexFound].FirstName, 13, NewInfo);
			break;
		case 2:
			strcpy_s(mailingList[indexFound].LastName, 13, NewInfo);
			break;
		case 3:
			strcpy_s(mailingList[indexFound].StreetAddr, 21, NewInfo);
			break;
		case 4:
			strcpy_s(mailingList[indexFound].City, 13, NewInfo);
			break;
		case 5:
			strcpy_s(mailingList[indexFound].State, 3, NewInfo);
			break;
		case 6:
			strcpy_s(mailingList[indexFound].Zip, 6, NewInfo);
			break;
		}
	}

	return;
}
//************************************  END OF FUNCTION UPDATERECORD  *************************************

//***************************************** FUNCTION GETEDITINGDATA ***************************************
void GetEditingData(ifstream &Infile, char EditingLastName[], int &FieldID, char EditingNewInfo[])
{
		// Receives - The input file, the last name array of the record that is going to be edited,
		//            the field id, and the new information array
		// Task - Read from the input file the last name, field id, and new information of the 
		//        record that is meant to be edited. 
		// Returns - The last name array of the record that is going to be edited,
		//           the field id, and the new information array

		// Read the values from the input file
	Infile >> ws;
	Infile.getline(EditingLastName, 13);
	Infile >> FieldID;
	Infile >> ws;
	Infile.getline(EditingNewInfo, 21);
	return;
}
//************************************  END OF FUNCTION GETEDITINGDATA  ***********************************

//***************************************** FUNCTION DELETERECORD *****************************************
void DeleteRecord(char DeleteFirstName[], char DeleteLastName[], customerTYPE mailingList[], int &EU
	, bool &NoExceptions, int &Index)
{
		// Receives - The first and last name character arrays that need to be deleted, the customers
		//            array, the elements used integer, the boolean that controls the exceptions, and
		//            the index integer
		// Task - "Deletes" a record from the customers list, checking that it is in the list before
		//         deleting
		// Returns - The first and last name character arrays that need to be deleted, the customers
		//            array, the elements used integer, the boolean that controls the exceptions, and
		//            the index integer

		//Set helper value
	bool found = false;

		//Check if an attempt of deleting a non-existing record is occuring
	for (int i = 0; i < EU; i++){
			//Check if the first and last name of the record that is going to be deleted 
			//actually is in the customers list
		if ((strcmp(DeleteFirstName, mailingList[i].FirstName) == 0) 
			&& (strcmp(DeleteLastName, mailingList[i].LastName) == 0)){
				//Check if the record is not already "deleted"
			if (mailingList[i].Visible != false){
					//Delete the record
				mailingList[i].Visible = false;
				found = true;
				Index = i;
			}
		}
	}

		
	if (!found){
			//Raise an exception if no record was found
		NoExceptions = false;
	}

	return;
}
//************************************  END OF FUNCTION DELETERECORD  *************************************

//***************************************** FUNCTION GETRECORD ********************************************
void GetRecord(ifstream &Infile, char DFirstName[], char DLastName[])
{
		// Receives - The input file, and two character arrays for the first name and last name
		//            of the record that needs to be deleted
		// Task - Read the first and last name of the record that needs to be deleted
		// Returns - The first and last name character arrays

		// Read the values from the input file
	Infile >> ws;
	Infile.getline(DFirstName,13);
	Infile.getline(DLastName, 13);
	return;
}
//************************************  END OF FUNCTION GETRECORD  ****************************************

//***************************************** FUNCTION READRECORD *******************************************
void ReadRecord(ifstream &Infile, customerTYPE mailingList[], int &EU, bool &NoException, int &Index)
{
		// Receives - The input file, the list of customers, the elements used, the boolean
		//            that controls the exceptions, and the index integer
		// Task - Reads the values of one customer from the input file, checking that it has not
		//        been added before.
		// Returns - The list of customers, the elements used, the boolean that controls the 
		//           exceptions and the index integer
	
		//Set helper values
	char firstName[13];
	char lastName[13];

		//Read first and last name of record
	Infile >> ws;
	Infile.getline(firstName,13);
	Infile.getline(lastName,13);

		//Check if an attempt of duplicating records is occuring
	for (int i = 0; i < EU; i++){
			//Check if exists a customer with the same name and lastname of that that
			//has been read
		if ((strcmp(firstName, mailingList[i].FirstName) == 0) 
			&& (strcmp(lastName, mailingList[i].LastName) == 0)){
				//Check if the record it is not "deleted"
			if (mailingList[i].Visible != false){
					//Signal that there was an attemp of duplicating records
				NoException = false;
			}
		}
	}

		//Check if the control did not rised any exceptions
	if (NoException){
			// Read the first value from the input file
		strcpy_s(mailingList[EU].FirstName,13,firstName);
		strcpy_s(mailingList[EU].LastName, 13, lastName);
		Infile.getline(mailingList[EU].StreetAddr, 21);
		Infile.getline(mailingList[EU].City, 13);
		Infile.getline(mailingList[EU].State, 3);
		Infile.getline(mailingList[EU].Zip, 6);
		mailingList[EU].Visible = true;

			//Set index of current record
		Index = EU;
			//Increase elements used counter
		EU++;
	}
	return;
}
//************************************  END OF FUNCTION READRECORD  ***************************************

//***************************************** FUNCTION READFLAG *********************************************
void ReadFlag(ifstream &Infile, char &flag)
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
	Outfile << setw(20) << "Assignment #6" << endl;
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