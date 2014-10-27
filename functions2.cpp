#include <iostream>
using namespace std;
/*
	void main()
	{
		void swap(int,int); //prototype call by value
		int a = 10, b=12;
		cout<<"before swap a = "<<a<<"b = "<<b<<swap(a,b)<<endl;
		cout<<"after swap a = "<<a<<"b = "<<b<<swap(a,b)<<endl;
	}
	void swap(int a, int b)
	{
		int t = a;
		a = b
		b = t
		cout<<"in swap"<<endl;
		cout<<"after swap a = "<<a<<"b = "<<b<<swap(a,b)<<endl;
	}
	*/
void main()
	{
		void swap(int &, int &); //prototype call by reference (address)
		int a = 10, b=12;
		cout<<"before swap a = "<<a<<"b = "<<b<<swap(a,b)<<endl;
		cout<<"after swap a = "<<a<<"b = "<<b<<swap(a,b)<<endl;
	}
	void swap(int &a, int& b)
	{
		int t = a;
		a = b
		b = t
		cout<<"in swap"<<endl;
		cout<<"after swap a = "<<a<<"b = "<<b<<swap(a,b)<<endl;
	}