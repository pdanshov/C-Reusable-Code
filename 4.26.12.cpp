
/*
#include<iostream>
#include<cstdlib>
using namespace std;
void main()
{
	for ( int j = 0; j< 8; j++)
		cout << rand()<< endl;
	cout << " RAND_MAX = " << RAND_MAX<<endl;
}
*/

/*
#include<iostream>
#include<cstdlib>
using namespace std;
void main()
{
	unsigned seed;
	cout <<"Enter seed: ";
	cin>>seed;
	srand(seed);		//initializes the seed
	for ( int j = 0; j< 8; j++)
		cout << rand()<< endl;
}
*/

/*
#include<iostream>
#include<cstdlib>
#include<ctime>
using namespace std;
void main()
{
	unsigned seed = time(NULL);	//uses the system clock
	cout <<"seed = " << seed<<endl;
	srand(seed);
	for ( int j = 0; j< 8; j++)
		cout << rand()<< endl;
}
*/

/*
#include<iostream>
#include<cstdlib>
#include<ctime>
using namespace std;
void main()
{
	unsigned seed = time(NULL);	//uses the system clock
	cout <<"seed = " << seed<<endl;
		srand(seed);
		int min, max, r, range;
		cout <<"Enter minimum and maximum:  ";
		cin>>min>>max;		//lowest and highest numbers( 1, 100)
		range = max - min + 1;	// number of numbers in range

	for ( int j = 0; j< 20; j++)
	{
		r = rand() /100 % range + min;
		cout << r<< " ";
	}
	cout <<endl;
}
*/
