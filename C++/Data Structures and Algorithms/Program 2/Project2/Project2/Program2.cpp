//***************************************     PROGRAM IDENTIFICATION   ************************************
//*                                                                                                       *
//* 	PROGRAM FILE NAME:   Program2.cpp		    ASSIGNMENT  #:  2			Grade: _______            *
//*                                                                                                       *
//*  	PROGRAM AUTHOR:       ____________________________________                                        *
//*                                       Adrian Beloqui                                                  *
//*                                                                                                       *
//*  	COURSE #:   CSC  36000  11                               DUE DATE:    Feb 07, 2016                *
//*                                                                                                       *
//*********************************************************************************************************

//***************************************    PROGRAM DESCRIPTION   ****************************************
//*                                                                                                       *
//*      PROCESS: This program is designed to read a file with an unknown number of records and           *
//*               it is to process each record by a transaction code. It is to add records to a mailing   *
//*               list, to delete these records, to update the records and to print them in a especific   *
//*               way. It is to keep the records alphabetically ordered from A to Z.                      *
//*                                                                                                       *
//*      USER DEFINED                                                                                     *
//*      MODULES      : main - Controlls the flow of the entire program, calling functions is the         *
//*                            right sequence and printing the labels into the output file.               *
//*                     Header - Prints a header in the output file.                                      *
//*                     Footer - Prints a footer in the output file.                                      *
//*                     PageBreak - Adds end lines to the output file.                                    *
//*                     LinkedListCLASS::LinkedListCLASS - Initializes the pointer of the linked list to  *
//*                                                        Null.                                          *
//*                     LinkedListCLASS::InsertNode - Adds a node (or record) into the mailing list       *
//*                                                   (or linked list)                                    *
//*                     LinkedListCLASS::DeleteNode - Deletes a node (or record) from the mailing list    *
//*                                                   (or linked list)                                    *
//*                     LinkedListCLASS::CheckNodeExistance - Checks if a record exists in the mailing    *
//*                                                           list.                                       *
//*                     LinkedListCLASS::ReadNode - Reads a record into a node instance                   *
//*                     LinkedListCLASS::ReadInputCode - Reads the transaction code from the input file.  *
//*                     LinkedListCLASS::Print - Prints the mailing list.                                 *
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

	//Definition of a node structure
struct NodeTYPE{
	char firstName[13];
	char lastName[13];
	char streetAddress[21];
	char city[13];
	char state[3];
	char zipCode[6];

	NodeTYPE *nextPtr;
};

	//Definition of classes
class LinkedListCLASS{

public:
		// Constructor
	LinkedListCLASS();

		// Functions
	void InsertNode(ofstream &, NodeTYPE, int &, bool &);
	void DeleteNode(ofstream &, NodeTYPE);
	bool CheckNodeExistance(NodeTYPE &);
	void ReadNode(ifstream &, NodeTYPE &, char);
	char ReadInputCode(ifstream &);
	void Print(ofstream &, int &);

private:
	NodeTYPE *StartPtr;
};

	//Function prototypes definitions
void Header(ofstream &);
void Footer(ofstream &);
void PageBreak(ofstream &, int &);

//***************************************** FUNCTION MAIN  ************************************************
int main()
{
	ifstream InFile;
	ofstream OutFile;

		//Set initial variables
	int linesWritten = 0;
	bool endOfFile = false, errorMessagePrinted = false;
	char inputCode;
	NodeTYPE newNode;
	LinkedListCLASS LinkedList;

		// Open the input file
	InFile.open("data2.txt", ios::in);

		// Create the output file
	OutFile.open("output2.txt", ios::out);

		// Print the header in the output file.
	Header(OutFile);
		// Add amount of lines written into the output file
	linesWritten += 3;
		// Print separator line
	OutFile << "=================================================="
		<< "==============================================" << endl << endl;
		// Add amount of lines written into the output file
	linesWritten += 2;

		// Process the input file while the sentinel is not reached
	do {
			// Read the transaction code from the input file
		inputCode = LinkedList.ReadInputCode(InFile);
			// Take an action depending on the value of the transaction code
		switch (inputCode){
		case 'A':
				// Read the record into a Node
			LinkedList.ReadNode(InFile, newNode, inputCode);
				// Check if the Node is already in the mailing list
			if (NOT LinkedList.CheckNodeExistance(newNode)){
					// Add the Node to the mailing list
				LinkedList.InsertNode(OutFile, newNode, linesWritten, errorMessagePrinted);
			}
			else{
					// Print error message
				OutFile << newNode.firstName << newNode.lastName << " is already in the list. Attempt "
					<< "to add duplicate record failed!" << endl << endl;
					// Add lines printed into the output file
				linesWritten += 2;
					// Establish sentinel for error messages to true
				errorMessagePrinted = true;
			}
			break;
		case 'D':
				// Read the record into a Node
			LinkedList.ReadNode(InFile, newNode, inputCode);
				// Check if the Node is already in the mailing list
			if (LinkedList.CheckNodeExistance(newNode)){
					// Remove the Node from the mailing list
				LinkedList.DeleteNode(OutFile, newNode);
			}
			else{
					// Print error message
				OutFile << "Record of " << newNode.firstName << newNode.lastName 
					<< " not found. Attempt " << "to delete record failed!" << endl << endl;
					// Add lines printed into the output file
				linesWritten += 2;
					// Establish sentinel for error messages to true
				errorMessagePrinted = true;
			}
			break;
		case 'C':
				// Read the record into a Node
			LinkedList.ReadNode(InFile, newNode, inputCode);
				// Check if the Node is already in the mailing list
			if (LinkedList.CheckNodeExistance(newNode)){
					// Read field number from the input file
				char fieldNumber;
				InFile >> fieldNumber;
					// Take an action depending on the value of the data read
				switch (fieldNumber){
				case '1':
						// Remove a Node from the mailing list
					LinkedList.DeleteNode(OutFile, newNode);
					char newFirstName[13];
					InFile >> ws;
						// Read the new value from the input file
					InFile.getline(newFirstName, 13);
						// Set the new value to the Node
					strcpy_s(newNode.firstName, newFirstName);
						// Add the Node modified into the mailinglist
					LinkedList.InsertNode(OutFile, newNode, linesWritten, errorMessagePrinted);
					break;
				case '2':
						// Remove a Node from the mailing list
					LinkedList.DeleteNode(OutFile, newNode);
					char newLastName[13];
					InFile >> ws;
						// Read the new value from the input file
					InFile.getline(newLastName, 13);
						// Set the new value to the Node
					strcpy_s(newNode.lastName, newLastName);
						// Add the Node modified into the mailinglist
					LinkedList.InsertNode(OutFile, newNode, linesWritten, errorMessagePrinted);
					break;
				case '3':
					char newAddress[21];
					InFile >> ws;
						// Read the new value from the input file
					InFile.getline(newAddress, 21);
						// Set the new value to the Node
					strcpy_s(newNode.streetAddress, newAddress);
					break;
				case '4':
					char newCity[13];
					InFile >> ws;
						// Read the new value from the input file
					InFile.getline(newCity, 13);
						// Set the new value to the Node
					strcpy_s(newNode.city, newCity);
					break;
				case '5':
					char newState[3];
					InFile >> ws;
						// Read the new value from the input file
					InFile.getline(newState, 3);
						// Set the new value to the Node
					strcpy_s(newNode.state, newState);
					break;
				case '6':
					char newZip[6];
					InFile >> ws;
						// Read the new value from the input file
					InFile.getline(newZip, 6);
						// Set the new value to the Node
					strcpy_s(newNode.zipCode, newZip);
					break;
				}
			}
			else{
					// Print error message
				OutFile << "Record of " << newNode.firstName << newNode.lastName 
					<< " not found. Attempt " << "to change record failed!" << endl << endl;
					// Add lines printed into the output file
				linesWritten += 2;
					// Establish sentinel for error messages to true
				errorMessagePrinted = true;
			}
			break;
		case 'P':
				// Check if error messages where printed
			if (errorMessagePrinted){
					// Print line breaks
				PageBreak(OutFile, linesWritten);
					// Reset error message sentinel
				errorMessagePrinted = false;
			}
				// Print labels for the chart.
			OutFile << setw(40) << "MAILING LIST" << endl;
			OutFile << "Last Name" << setw(13) << "First Name" << setw(9) << "Address" 
				<< setw(17) << "City" << setw(16) << "State" << setw(10) << "Zip Code" << endl;
			OutFile << "=================================================="
				<< "========================" << endl;
				// Add lines printed into the output file
			linesWritten += 3;
				// Print the mailing list
			LinkedList.Print(OutFile, linesWritten);
				// Print line breaks
			PageBreak(OutFile, linesWritten);
			break;
		case 'Q':
				// Set sentinel to exit the processing of the input file
			endOfFile = true;
			break;
		}
	} while (NOT endOfFile);

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

//***************************************** FUNCTION PRINT ************************************************
void LinkedListCLASS::Print(ofstream &Outfile, int &linesWritten)
{
		// Receives - The output file and the number of lines written into the output file
		// Task - Print the mailing list into the output file
		// Returns - The output file and the number of lines written into the output file

	NodeTYPE  *CurrentPtr;
		// Initialize a current pointer to the start of the linked list
	CurrentPtr = StartPtr;
		// Check for an Empty List
	if (CurrentPtr == NULL)
	{
			// Print empty list message
		Outfile << "The list is empty" << endl << endl;
			// Add lines printed into the output file
		linesWritten += 2;
		return;
	}
	while (CurrentPtr != NULL)
	{
			//  Print the data
		Outfile << setw(12) << CurrentPtr->lastName << setw(12) << CurrentPtr->firstName 
			<< setw(20) << CurrentPtr->streetAddress << setw(12) << CurrentPtr->city 
			<< setw(5) << CurrentPtr->state << setw(10) << CurrentPtr->zipCode << endl;
			//  Move to the next NODE
		CurrentPtr = CurrentPtr->nextPtr;
			// Add lines printed into the output file
		linesWritten++;
	}
	return;
}
//************************************  END OF FUNCTION PRINT  ********************************************

//***************************************** FUNCTION DELETENODE *******************************************
void LinkedListCLASS::DeleteNode(ofstream &Outfile, NodeTYPE node)
{
		// Receives - The output file and the node to be deleted
		// Task - Delete a node from the mailing list
		// Returns - The output file and the node deleted

	NodeTYPE *tempPtr, *PreviousPtr, *CurrentPtr;

		// Check if node to be deleted is in the first node.
	if (((strcmp(node.lastName, StartPtr->lastName)) == 0) 
		&& ((strcmp(node.firstName, StartPtr->firstName)) == 0)){
			// Reset the starting pointer
		tempPtr = StartPtr;
		StartPtr = StartPtr->nextPtr;
		delete (tempPtr);
		return;
	}
	else{	
			// Initialize local pointers.
		PreviousPtr = StartPtr;
		CurrentPtr = StartPtr->nextPtr;
			// Search for the node to be deleted
		while ((CurrentPtr != NULL) && ((strcmp(node.lastName, CurrentPtr->lastName)) != 0) 
			&& ((strcmp(node.firstName, StartPtr->firstName)) != 0))
		{
				// Move forward in the list
			PreviousPtr = CurrentPtr;
			CurrentPtr = CurrentPtr->nextPtr;
		}
			// Check if a node was found.
		if (CurrentPtr != NULL)
		{
				// Delete links that the node meant to be deleted has with the rest of the list
			tempPtr = CurrentPtr;
			PreviousPtr->nextPtr = CurrentPtr->nextPtr;
				// Free memory used
			delete (tempPtr);
			return;
		}
	}
	return;
}
//************************************  END OF FUNCTION DELETENODE  ***************************************

//***************************************** FUNCTION CHECKNODEEXISTANCE ***********************************
bool LinkedListCLASS::CheckNodeExistance(NodeTYPE &node)
{
		// Receives -The node to be compared with the mailing list
		// Task - Check if a node exists in the list
		// Returns - A node and a boolean indicating if a matching node was found
	
		// Check if the list is empty
	if (StartPtr != NULL){

		NodeTYPE *CurrentPtr;
			// Set the beginning of the mailing list
		CurrentPtr = StartPtr;
			// Search until the end of the list is reached
		while (CurrentPtr != NULL) {
				// Check if the node in the list is the same as the one that is being checked
			if (((strcmp(node.lastName, CurrentPtr->lastName)) == 0) 
				&& ((strcmp(node.firstName, CurrentPtr->firstName)) == 0)){
					// Update the node being checked with the data of the node found in the list
				strcpy_s(node.streetAddress,CurrentPtr->streetAddress);
				strcpy_s(node.city, CurrentPtr->city);
				strcpy_s(node.state, CurrentPtr->state);
				strcpy_s(node.zipCode, CurrentPtr->zipCode);
				return true;
			}
			else {
					// Move forward in the mailing list
				CurrentPtr = CurrentPtr->nextPtr;
			}
		}
	}
		// Return signal that no matching was found
	return false;
}
//************************************  END OF FUNCTION CHECKNODEEXISTANCE  *******************************

//***************************************** FUNCTION INSERTNODE *******************************************
void LinkedListCLASS::InsertNode(ofstream &Outfile, NodeTYPE node, int &linesWritten,
	bool &errorMessagePrinted)
{
		// Receives -The output file, a node, the amount of lines written in the output file, and a 
		//           boolean indicating if error messages were printed
		// Task - Insert a node into the mailing list
		// Returns - The output file, a node, the amount of lines written in the output file, and a 
		//           boolean indicating if error messages were printed

		// Declare local pointers
	NodeTYPE *newPtr, *PreviousPtr, *CurrentPtr;
		// Reserve memory for a new node
	newPtr = new (NodeTYPE);
		// Check if there is no free memory
	if (newPtr == NULL){
			// Print an error message
		Outfile << "Node not inserted. No memory available." << endl;
			// Add lines printed into the output file
		linesWritten++;
			// Establish sentinel for error messages to true
		errorMessagePrinted = true;
	}
	else{       	
			// Place the data into the new node
		strcpy_s(newPtr->firstName, node.firstName);
		strcpy_s(newPtr->lastName, node.lastName);
		strcpy_s(newPtr->streetAddress, node.streetAddress);
		strcpy_s(newPtr->city, node.city);
		strcpy_s(newPtr->state, node.state);
		strcpy_s(newPtr->zipCode, node.zipCode);
		newPtr->nextPtr = node.nextPtr;

		PreviousPtr = NULL;
		CurrentPtr = StartPtr;
			// Search for the location to insert the new node
		while ((CurrentPtr != NULL) && (strcmp(newPtr->lastName, CurrentPtr->lastName))> 0){
			PreviousPtr = CurrentPtr;
			CurrentPtr = CurrentPtr->nextPtr;
		}

			// Check if the Current node has the same key as the node to be added
		if ((CurrentPtr != NULL) && (strcmp(newPtr->lastName, CurrentPtr->lastName) == 0)){
				// Check if the new node goes after the current position found
			if (strcmp(newPtr->firstName, CurrentPtr->firstName) > 0){
					// Update links between nodes
				newPtr->nextPtr = CurrentPtr->nextPtr;
				CurrentPtr->nextPtr = newPtr;
				return;
			}
		}
			// If list is empty, place new node at the start of the list
		if (PreviousPtr == NULL)
		{
			newPtr->nextPtr = StartPtr;
			StartPtr = newPtr;
		}
		else
		{		// Insert the new node into the list
			PreviousPtr->nextPtr = newPtr;
			newPtr->nextPtr = CurrentPtr;
		}

	}
	return;
}
//************************************  END OF FUNCTION INSERTNODE  ***************************************

//***************************************** FUNTION READNODE  *********************************************
void LinkedListCLASS::ReadNode(ifstream &Infile, NodeTYPE &newNode, char opCode)
{
		// Receives - The input file, a node, and a character indicating the transaction code
		// Task - Accordingly to the transaction code, read the input file into the node
		// Returns - The input file and a node
	
		// Take an action depending on the value of the transaction code
	switch (opCode){
	case 'A':
			// Read all properties of a node to be inserted into the mailing list
		Infile >> ws;
		Infile.getline(newNode.firstName, 13);
		Infile.getline(newNode.lastName, 13);
		Infile.getline(newNode.streetAddress, 21);
		Infile.getline(newNode.city, 13);
		Infile.getline(newNode.state, 3);
		Infile.getline(newNode.zipCode, 6);
		break;
	case 'D': case 'C':
			// Read the first two properties of a node to be deleted or edited
		Infile >> ws;
		Infile.getline(newNode.firstName, 13);
		Infile.getline(newNode.lastName, 13);
		break;
	}
	return;
}
//************************************  END OF FUNCTION READNODE  *****************************************

//***************************************** FUNTION READINPUTCODE  ****************************************
char LinkedListCLASS::ReadInputCode(ifstream &Infile)
{
	// Receives - The input file
	// Task - Read the transaction code
	// Returns - The input file and a character representing the transaction code

		// Initialize local variables
	char code = ' ';

		// Read the input values
	Infile >> ws;
	Infile >> code;
	
	return code;
}
//************************************  END OF FUNCTION READINPUTCODE  ************************************

//***************************************** FUNCTION LINKEDLISTCLASS **************************************
LinkedListCLASS::LinkedListCLASS()
{
		// Receives - Nothing
		// Task - Initialized the pointer of the start of the mailing list
		// Returns - Nothing

	StartPtr = NULL;

	return;
}
//************************************  END OF FUNCTION LINKEDLISTCLASS  **********************************

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
	Outfile << setw(20) << "Assignment #2" << endl;
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