/* Peter Danshov
 * CST2403 Section 2340
 * Assignment 4.27 page 160
 * March 18, 2012, 12:52 PM
 *
 * This application prints the decimal equivalent of a binary number.
 *
 */

#include <iostream>
#include <sstream>
#include <string>
using namespace std;
int main()
{
	int number, digit, value = 1, decimal = 0;
	string s;
	cout<<"Enter binary number: ";
	cin>>s;
	istringstream buffer(s);
	buffer >> number;
	cout<<"Binary number: "<<s<<endl;
		while (number)
		{
			digit = number % 10;
			number /= 10;
			decimal += (digit * value);
			value *= 2;
		}
	cout<<"The decimal value: "<<decimal<<endl;
	return 0;
}
