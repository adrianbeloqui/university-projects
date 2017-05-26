//***************************************     PROGRAM IDENTIFICATION   ************************************
//*                                                                                                       *
//* 	PROGRAM FILE NAME:   Program3.cpp		    ASSIGNMENT  #:  3			Grade: _______            *
//*                                                                                                       *
//*  	PROGRAM AUTHOR:       ____________________________________                                        *
//*                                       Adrian Beloqui                                                  *
//*                                                                                                       *
//*  	COURSE #:   CSC  36000  11                               DUE DATE:    Feb 22, 2016                *
//*                                                                                                       *
//*********************************************************************************************************

//***************************************    PROGRAM DESCRIPTION   ****************************************
//*                                                                                                       *
//*      PROCESS: This program is designed to read a file with an unknown number of records and           *
//*               it is to process each record by adding each element to a queue such that the element    *
//*               is processed as quickly as possible. The program is to keep track of the elements that  *
//*               enter the queue and of the elements that leave the queues and keep this in their        *
//*               corresponding order. It is also to print both lists into an output file.                *
//*                                                                                                       *
//*      USER DEFINED                                                                                     *
//*      MODULES      : main - Controlls the flow of the entire program, calling functions is the         *
//*                            right sequence and printing the labels into the output file.               *
//*                     Header - Prints a header in the output file.                                      *
//*                     Footer - Prints a footer in the output file.                                      *
//*                     PageBreak - Adds end lines to the output file.                                    *
//*                     getQueueAvailable - Returns the number of the queue that and element is going to  *
//*                                         be added to, following certain rules.                         *
//*                     PrintLists - Prints the check in and check out lists into the output file.        *
//*                     LinkedListCLASS::LinkedListCLASS - Initializes the pointer of the linked list to  *
//*                                                        NULL.                                          *
//*                     LinkedListCLASS::InsertNode - Adds a node (or record) into the linked list.       *
//*                     LinkedListCLASS::DeleteNode - Deletes a node (or record) from the linked list.    *
//*                     LinkedListCLASS::getStartPtr - Returns the start pointer of the linked list.      *
//*                     QueueCLASS::QueueCLASS - Initializes the private members of the queue.            *
//*                     QueueCLASS::isEmpty - Checks if the queue is empty.                               *
//*                     QueueCLASS::isFull - Checks if the queue is full                                  *
//*                     QueueCLASS::getFirst - Returns the fist element of the queue.                     *
//*                     QueueCLASS::AddNode - Adds a node (or record) into the queue.                     *
//*                     QueueCLASS::RemoveNode - Deletes the fist element of the queue.                   *
//*                     QueueCLASS::Process - Reduces the processing time of the first element of the     *
//*                                           queue.                                                      *
//*                     QueueCLASS::TotalProcessingTime - Calculates the total processing time of a queue *
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
struct CustomerTYPE{
	int arrivalTime;
	char name[21];
	int processingTime;

	CustomerTYPE *nextPtr;
};

	//Definition of classes
class QueueCLASS{

public:
		// Constructor
	QueueCLASS();

		// Functions
	bool isEmpty() { return ((front == NULL) ? true : false); }
	bool isFull();
	CustomerTYPE* getFirst();
	bool AddNode(CustomerTYPE &);
	bool RemoveNode(CustomerTYPE &);
	void Process();
	int TotalProcessingTime();

private:
	int count;
	CustomerTYPE *front;
	CustomerTYPE *rear;
};

	//Definition of classes
class LinkedListCLASS{

public:
		// Constructor
	LinkedListCLASS();

		// Functions
	void InsertNode(ofstream &, CustomerTYPE, int &);
	void ReadNode(ifstream &, CustomerTYPE &);
	CustomerTYPE* getStartPtr() { return StartPtr; }

private:
	CustomerTYPE *StartPtr;
};

	//Function prototypes definitions
void Header(ofstream &);
void Footer(ofstream &);
void PageBreak(ofstream &, int &);
int getQueueAvailable(QueueCLASS, QueueCLASS, QueueCLASS);
void PrintLists(ofstream &, LinkedListCLASS, LinkedListCLASS, int &);

//***************************************** FUNCTION MAIN  ************************************************
int main()
{
	ifstream InFile;
	ofstream OutFile;

		//Set initial variables
	int linesWritten = 0, arrivalTime = 1, tempQueue;
	bool endOfFile = false, newCustomer = true, storeClosed = false, finishProcessing = false;
	CustomerTYPE newNode, temp, *tempPtr;
	LinkedListCLASS arrivalList, checkoutList;
	QueueCLASS queueLine1, queueLine2, queueLine3;

		// Open the input file
	InFile.open("queue_in.txt", ios::in);

		// Create the output file
	OutFile.open("output3.txt", ios::out);

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
			// Check if a new customer can enter the checkout area
		if (newCustomer){
				// Read the new node from the input file
			arrivalList.ReadNode(InFile, newNode);
		}

			// Check if the store is closed
		if (newNode.arrivalTime == -99){
			storeClosed = true;
				// Check if the lines are done processing clients
			if (queueLine1.isEmpty() && queueLine2.isEmpty() && queueLine3.isEmpty()){
				finishProcessing = true;
			}
		}

			// Check if the store is closed or if the lines are done processing clients
		if (NOT storeClosed || NOT finishProcessing){
				// Check if the store is closed and if a new customer entered the checkout area
			if (NOT storeClosed && newCustomer){
					// Insert new node to the arrival list
				arrivalList.InsertNode(OutFile, newNode, linesWritten);
			}

				// Check if the customer can enter a processing line
			if (arrivalTime == newNode.arrivalTime){
					// Get queue to add the new node into
				tempQueue = getQueueAvailable(queueLine1, queueLine2, queueLine3);
					// Check which queue is the node going to be added to
				switch (tempQueue){
				case 1:
						// Add new node
					queueLine1.AddNode(newNode);
					break;
				case 2:
						// Add new node
					queueLine2.AddNode(newNode);
					break;
				case 3:
						// Add new node
					queueLine3.AddNode(newNode);
					break;
				}
					// A new customer can enter the checkout area
				newCustomer = true;
			}
			else {
					// A customer is still waiting in the checkout area
				newCustomer = false;
			}
				// Check if the queue is empty
			if (NOT queueLine1.isEmpty()){
					// Process the queue
				queueLine1.Process();
					// Get first element of the queue
				tempPtr = queueLine1.getFirst();
					// Check if elements has finished being processed
				if (tempPtr->processingTime == 0){
						// Copy element into a temporal node
					temp.arrivalTime = tempPtr->arrivalTime;
					strcpy_s(temp.name, tempPtr->name);
					temp.processingTime = tempPtr->processingTime;
					temp.nextPtr = tempPtr->nextPtr;
						// Remove node from the queue
					queueLine1.RemoveNode(temp);
						// Add node to the checkout list
					checkoutList.InsertNode(OutFile, temp, linesWritten);
				}
			}
				// Check if the queue is empty
			if (NOT queueLine2.isEmpty()){
					// Process the queue
				queueLine2.Process();
					// Get first element of the queue
				tempPtr = queueLine2.getFirst();
					// Check if elements has finished being processed
				if (tempPtr->processingTime == 0){
						// Copy element into a temporal node
					temp.arrivalTime = tempPtr->arrivalTime;
					strcpy_s(temp.name, tempPtr->name);
					temp.processingTime = tempPtr->processingTime;
					temp.nextPtr = tempPtr->nextPtr;
						// Remove node from the queue
					queueLine2.RemoveNode(temp);
						// Add node to the checkout list
					checkoutList.InsertNode(OutFile, temp, linesWritten);
				}
			}
				// Check if the queue is empty
			if (NOT queueLine3.isEmpty()){
					// Process the queue
				queueLine3.Process();
					// Get first element of the queue
				tempPtr = queueLine3.getFirst();
					// Check if elements has finished being processed
				if (tempPtr->processingTime == 0){
						// Copy element into a temporal node
					temp.arrivalTime = tempPtr->arrivalTime;
					strcpy_s(temp.name, tempPtr->name);
					temp.processingTime = tempPtr->processingTime;
					temp.nextPtr = tempPtr->nextPtr;
						// Remove node from the queue
					queueLine3.RemoveNode(temp);
						// Add node to the checkout list
					checkoutList.InsertNode(OutFile, temp, linesWritten);
				}
			}
				// Increase the current arrival time
			arrivalTime++;
		}
		else {
				// Set sentinel to exit the processing of the input file
			endOfFile = true;
			break;
		}
	} while (NOT endOfFile);

		// Print labels
	OutFile << "The order of customer arrival is:" << setw(50) << "The order of customer departure is:" << endl;
	OutFile << "---------------------------------------" << setw(48) << "---------------------------------------" << endl;
		// Print lists into the output file
	PrintLists(OutFile, arrivalList, checkoutList, linesWritten);
	
		// Print page break
	PageBreak(OutFile, linesWritten);

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
void PrintLists(ofstream &OutFile, LinkedListCLASS checkIn, LinkedListCLASS checkOut,
	int &linesWritten)
{
		// Receives - The output file, two linked lists, and the number of lines written into the output file
		// Task - Print the check in and check out lists into the output file
		// Returns - The output file and the number of lines written into the output file

	CustomerTYPE  *CurrentPtrCheckIn, *CurrentPtrCheckOut;
		// Initialize a current pointer to the start of the linked list
	CurrentPtrCheckIn = checkIn.getStartPtr();
		// Initialize a current pointer to the start of the linked list
	CurrentPtrCheckOut = checkOut.getStartPtr();
		// Check for an Empty List in both lists
	if (CurrentPtrCheckIn == NULL && CurrentPtrCheckOut == NULL)
	{
			// Print empty list message
		OutFile << "The lists are empty" << endl << endl;
			// Add lines printed into the output file
		linesWritten += 2;
		return;
	}
	while (CurrentPtrCheckIn != NULL && CurrentPtrCheckOut != NULL)
	{
			//  Print the data
		OutFile << CurrentPtrCheckIn->name << setw(22) << "|" << setw(32) << CurrentPtrCheckOut->name << endl;
			//  Move to the next NODE
		CurrentPtrCheckIn = CurrentPtrCheckIn->nextPtr;
			//  Move to the next NODE
		CurrentPtrCheckOut = CurrentPtrCheckOut->nextPtr;
			// Add lines printed into the output file
		linesWritten++;
	}
	return;
}
//************************************  END OF FUNCTION PRINT  ********************************************

//***************************************** FUNCTION TOTALPROCESSINGTIME **********************************
int QueueCLASS::TotalProcessingTime()
{
		// Receives - Nothing
		// Task - Calculate the total processing time of a queue
		// Returns - An integer representing the total processing time

	CustomerTYPE *temp;
		// Set total processing time
	int processingTime = 0;
		// Copy reference of the front of the queue
	temp = front;
		// Check if there is something to process
	while (temp != NULL){
			// Sum the processing time of the node to the total processing time
		processingTime += temp->processingTime;
			// Advance in the search
		temp = temp->nextPtr;
	}
	return processingTime;

}
//************************************  END OF FUNCTION TOTALPROCESSINGTIME  ******************************

//***************************************** FUNTION GETQUEUEAVAILABLE  ************************************
int getQueueAvailable(QueueCLASS queue1, QueueCLASS queue2, QueueCLASS queue3)
{
		// Receives - Three queues
		// Task - Identify which queue is available accordingly to the rules for adding a node.
		// Returns -  An integer indicating the number of the queue.

		// Check if the queue is empty
	if (queue1.isEmpty()){
		return 1;
	}
		// Check if the queue is empty
	if (queue2.isEmpty()){
		return 2;
	}
		// Check if the queue is empty
	if (queue3.isEmpty()){
		return 3;
	}
		// Get the total processing time for each queue
	int totalProcessingTimeQueue1 = queue1.TotalProcessingTime();
	int totalProcessingTimeQueue2 = queue2.TotalProcessingTime();
	int totalProcessingTimeQueue3 = queue3.TotalProcessingTime();
		// Create an array of the total processing times of the queues
	int totalProcessingTime[3] = { totalProcessingTimeQueue1, totalProcessingTimeQueue2, totalProcessingTimeQueue3 };
		// Set minimum processing time as the processing time of the first queue
	int min = totalProcessingTimeQueue1;
		// Search for the minimum total procesing time
	for (int i = 0; i < 3; i++){
		if (min > totalProcessingTime[i]){
			min = totalProcessingTime[i];
		}
	}
		// Check if the minimum processing is the same as the queue
	if (min == totalProcessingTimeQueue1){
		return 1;
	}
		// Check if the minimum processing is the same as the queue
	if (min == totalProcessingTimeQueue2){
		return 2;
	}
		// Check if the minimum processing is the same as the queue
	if (min == totalProcessingTimeQueue3){
		return 3;
	}

}
//************************************  END OF FUNCTION GETQUEUEAVAILABLE  ********************************

//***************************************** FUNCTION PROCESS **********************************************
void QueueCLASS::Process()
{
		// Receives - Nothing
		// Task - Reduce the processing time of the node at the front of the queue
		// Returns - Nothing

		// Check if the queue is empty
	if (front != NULL){
			// Reduce processing time of the node
		front->processingTime--;
	}
	return;

}
//************************************  END OF FUNCTION PROCESS  ******************************************

//***************************************** FUNCTION REMOVENODE *******************************************
bool QueueCLASS::RemoveNode(CustomerTYPE & newNode)
{
		// Receives - A node of type CustomerTYPE
		// Task - Remove a node from the queue
		// Returns - A boolean

	CustomerTYPE *temp;
		// Check if the queue is empty
	if (isEmpty()){
		return false;
	}
		// Save the information into a temporal node
	newNode.arrivalTime = front->arrivalTime;
	strcpy_s(newNode.name, front->name);
	newNode.processingTime = front->processingTime;
	newNode.nextPtr = front->nextPtr;
		// Reduce the amount of elements in the queue
	count--;
		// Delete the node from the queue
	temp = front;
	front = front->nextPtr;
	delete temp;
	return true;

}
//************************************  END OF FUNCTION REMOVENODE  ***************************************

//***************************************** FUNCTION ADDNODE **********************************************
bool QueueCLASS::AddNode(CustomerTYPE &newNode)
{
		// Receives - A node of type CustomerTYPE
		// Task - Add a node to the queue
		// Returns - A boolean

	CustomerTYPE *NewPtr;
		// Allocate memory space for new node
	NewPtr = new(CustomerTYPE);
		// Check if the queue is full
	if (isFull())
		return false;
		// Copy data into the new node
	NewPtr->arrivalTime = newNode.arrivalTime;
	strcpy_s(NewPtr->name, newNode.name);
	NewPtr->processingTime = newNode.processingTime;
	NewPtr->nextPtr = NULL;

		// Check if the queue is empty
	if (front == NULL){
		front = NewPtr;
	}
	else {
		rear->nextPtr = NewPtr;
	}
		// Place the new node at the rear of the queue
	rear = NewPtr;
		// Increse amount of elements in the queue
	count++;
	return true;


}
//************************************  END OF FUNCTION ADDNODE  ******************************************

//***************************************** FUNCTION ISFULL ***********************************************
bool QueueCLASS::isFull()
{
		// Receives - Nothing
		// Task - Check if the memory the queue is full
		// Returns - A boolean

	CustomerTYPE  *p;
		// Allocate memory space
	p = new(CustomerTYPE);
		// Check if there is memory allocated
	if (p == NULL)
	{
			// Delete allocated memory
		delete p;
		return true;
	}
	return false;


}
//************************************  END OF FUNCTION ISFULL  *******************************************

//***************************************** FUNCTION GETFIRST *********************************************
CustomerTYPE* QueueCLASS::getFirst()
{
		// Receives - Nothing
		// Task - The first element in the queue
		// Returns - A pointer of type customerTYPE or NULL

		// Check if the queue is empty
	if (isEmpty())
	{
		return NULL;
	}
	return front;

}
//************************************  END OF FUNCTION GETFIRST  *****************************************

//***************************************** FUNCTION QUEUECLASS *******************************************
QueueCLASS::QueueCLASS()
{
		// Receives - Nothing
		// Task - Initialized the pointers of the queue
		// Returns - Nothing

	front = NULL;
	rear = NULL;
	count = 0;

	return;
}
//************************************  END OF FUNCTION QUEUECLASS  ***************************************

//***************************************** FUNCTION INSERTNODE *******************************************
void LinkedListCLASS::InsertNode(ofstream &Outfile, CustomerTYPE node, int &linesWritten)
{
		// Receives -The output file, a node, and the amount of lines written in the output file
		// Task - Insert a node into the linked list
		// Returns - The output file, a node, and the amount of lines written in the output file

		// Declare local pointers
	CustomerTYPE *newPtr, *PreviousPtr, *CurrentPtr;
		// Reserve memory for a new node
	newPtr = new (CustomerTYPE);
		// Check if there is no free memory
	if (newPtr == NULL){
			// Print an error message
		Outfile << "Node not inserted. No memory available." << endl;
			// Add lines printed into the output file
		linesWritten++;
	}
	else{
			// Place the data into the new node
		newPtr->arrivalTime = node.arrivalTime;
		strcpy_s(newPtr->name, node.name);
		newPtr->processingTime = node.processingTime;
		newPtr->nextPtr = node.nextPtr;

		PreviousPtr = NULL;
		CurrentPtr = StartPtr;
			// Search for the location to insert the new node
		while (CurrentPtr != NULL){
			PreviousPtr = CurrentPtr;
			CurrentPtr = CurrentPtr->nextPtr;
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
void LinkedListCLASS::ReadNode(ifstream &Infile, CustomerTYPE &newNode)
{
		// Receives - The input file, a node, and customerTYPE structure
		// Task - Read the input file into the node
		// Returns - The input file and a node

		// Read all properties of a node to be inserted into the it
	Infile >> ws;
	Infile >> newNode.arrivalTime;
	Infile >> ws;
	Infile.getline(newNode.name, 21);
	Infile >> newNode.processingTime;
	newNode.nextPtr = NULL;
	return;
}
//************************************  END OF FUNCTION READNODE  *****************************************

//***************************************** FUNCTION LINKEDLISTCLASS **************************************
LinkedListCLASS::LinkedListCLASS()
{
		// Receives - Nothing
		// Task - Initialized the pointer of the start of the linked list
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
		// Returns - The output file

	Outfile << setw(30) << "Adrian Beloqui ";
	Outfile << setw(17) << "CSC 36000";
	Outfile << setw(15) << "Section 11" << endl;
	Outfile << setw(30) << "Spring 2017";
	Outfile << setw(20) << "Assignment #3" << endl;
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
		// Returns - The output file

	Outfile << endl;
	Outfile << setw(35) << "------------------------------------------------" << endl;
	Outfile << setw(35) << "|               END OF PROGRAM OUTPUT          |" << endl;
	Outfile << setw(35) << "------------------------------------------------" << endl;
	return;
}
//************************************  END OF FUNCTION FOOTER  *******************************************