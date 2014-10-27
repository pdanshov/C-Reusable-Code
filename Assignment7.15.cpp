/* Peter Danshov
 * CST2403 Section 2340
 * Assignment 7.15 page 336
 * May 6, 2012, 11:58 AM
 *
 * This application reads in, stores in an array,
 * and prints twenty unique numbers.
 */
#include<iostream>
bool linearSearch(const int[], int, int); //linearSearch prototype
void dataSort(int[], int); //dataSort prototype
void validInput(int&); //validInput prototype
using namespace std;
int main()
{
	const int arraySize = 20;
	int array[arraySize]={};
	int number;
	cout<<"Input 20 numbers from 10 - 100."<<endl;
	for(int c=0; c<arraySize; c++) //populate array with user-entered numbers
	{
		cout<<"Integer #"<<c+1<<": ";
		validInput(number); //gets and validates input
		if(linearSearch(array, number, arraySize)) //use linearSearch to check if number already exists in array, if not, insert into array
		{
			array[c]=number;
		}
	}
	dataSort(array, arraySize); //sort the user-entered numbers
	cout<<"Unique user-entered numbers: "; //display all unique user-entered numbers
	for(int c=0; c<arraySize-1; c++)
	{
		if(array[c] != 0)
			cout<<array[c]<<", ";
	}
	cout<<array[19]<<"."<<endl;
	return 0;
}
//linearSearch function
bool linearSearch(const int array[], int searchKey, int arraySize)
{
	for(int e=0; e<arraySize; e++)
		if(array[e] == searchKey)
			return false;
	return true;
}
//dataSort function
void dataSort(int array[], int arraySize)
{
	int insert;
	for(int next=1; next<arraySize; next++)
	{
		insert=array[next];
		int moveItem=next;
		while((moveItem>0) && (array[moveItem-1]>insert))
		{
			array[moveItem] = array[moveItem-1];
			moveItem--;
		}
		array[moveItem]=insert;
	}
}
//validInput function
void validInput(int& digit)
{
	for(;;)
	{
		if(cin>>digit)
		{
			break;
		}
		else
		{
			cout<<"Please enter a valid integer"<<endl;
			cin.clear();
			cin.ignore(numeric_limits<streamsize>::max(), '\n');
		}
	}
}