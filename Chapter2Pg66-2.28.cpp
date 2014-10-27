// Peter Danshov
// CST2403 Section 2340
// Assignment 2.28 page 66

// This program takes a five-digit integer input, separates
// the integer into its digits and prints them separated by
// three spaces each.
#include<cstdlib>
#include<iostream>
using namespace std;
int main(int argc, char** argv)
{
    int n,o,t,h,th,tth;
    cout<<"Please enter a five-digit integer."<<endl;
    cin>>n;
    o=n%10,t=(n/10)%10,h=(n/100)%10,th=(n/1000)%10,tth=(n/10000)%10;
    cout<<tth<<"   "<<th<<"   "<<h<<"   "<<t<<"   "<<o<<endl;
    return 0;
}

/*
#include<iostream>
#include<vector>
using namespace std;
int main()
{
	vector<int> numberlist;
	int number,digit;
	cout<<"Please enter a five-digit integer: ";
	cin>>number;
	while(number>0)
	{
		digit=number%10;
		numberlist.push_back(digit);
		number=number/10;
	}
	int length=(int)numberlist.size();
	while(length>0,length--)
	{
		digit=numberlist.pop_back();
		cout<<digit;
	}
	return 0;
}

// Peter Danshov
// CST2403 Section 2340
// Assignment 2.28 page 66

// This program takes an input integer up to ten-digits, separates
// the integer into its digits and prints them separated by
// three spaces each.

#include<iostream>
#include<vector>
using namespace std;
int main()
{
	vector<int> numberlist;
	int number,digit,length;
	cout<<"Please enter a five-digit integer: ";
	cin>>number;
	while(number>0)
	{
		digit=number%10;
		numberlist.push_back(digit);
		number=number/10;
	}
    cout<<endl;
    length=numberlist.size();
    for (int i=0; i<length; i++)
	{
		cout<<numberlist.back()<<"   ";
        numberlist.pop_back();
	}
    cout<<endl;
    return 0;
}

*/
