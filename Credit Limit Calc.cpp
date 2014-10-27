/* Peter Danshov
 * CST2403 Section 2340
 * Assignment 4.14 page 156-157
 * March 18, 2012, 12:15 PM
 *
 * This application is a credit limit calculator.
 *
 */

#include <iostream>
using namespace std;
int main()
{
	int account = 1;
	float balance, charges, credits, limit, new_balance;
	while (account>=0)
	{
	cout<<"Enter account number (or -1 to quit): ";
	cin>>account;
		while (account>=0)
		{
			cout<<"Enter beginning balance: ";
			cin>>balance;
			cout<<"Enter total charges: ";
			cin>>charges;
			cout<<"Enter total credits: ";
			cin>>credits;
			cout<<"Enter credit limit: ";
			cin>>limit;
			new_balance = balance + charges - credits;
			if (new_balance>limit)
			{
				cout<<"New balance is "<<new_balance<<endl;
				cout<<"Account: "<<account<<endl;
				cout<<"Credit limit: "<<limit<<endl;
				cout<<"Balance: "<<balance<<endl;
				cout<<"Credit Limit Exceeded."<<endl;
			}
			else
			{
				cout<<"New balance is "<<new_balance<<endl;
			}
			break;
		}
	}
	return 0;
}
