/* Peter Danshov
 * CST2403 Section 2340
 * Assignment 6.24 page 275
 * April 29, 2012, 5:00 PM
 *
 * This application prints the digits of an integer.
 *
 */

#include<iostream>

inline int integer(int a, int b){return a/b;}
inline int remainder(int a, int b){return a%b;}
void separate(int);

using namespace std;
int main()
{
	int number;
	cout<<"Input a number from 1 - 32767: ";
	cin>>number;
	separate(number);
	return 0;
}
void separate(int input)
{
	int d = 0, c = input, m = 1;
	while(c)
	{
		c = integer(c, 10);
		m *= 10;
	}
	m = integer(m, 10);
	while(m)
	{
		c = integer(input, m);
		d = remainder(c, 10);
		cout<<d<<"  ";
		m = integer(m, 10);
	}
}