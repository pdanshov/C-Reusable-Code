


#include <fstream>
#include <cmath>
#include <complex>
#include <iostream>
#include <iomanip>
#include <vector>
#include <limits>
#include <stdlib.h>
#include <stdio.h>
#include <time.h>
#include <fcntl.h>
#include <string.h>
#include <ctype.h>
#include <icrsint.h>

using namespace std;

#import <C:\\Program Files\\Common Files\\system\\ado\\msado15.dll> rename( "EOF", "AdoNSEOF")

_bstr_t bstrConnect = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Program Files\\Microsoft Office\\Office\\Samples\\Northwind.mdb;";

HRESULT hr;

int main()
{
    ::CoInitialize(NULL);
    const char* DAM = "ADO";
    ADODB::_ConnectionPtr pConn("ADODB.Connection");
    hr = pConn->Open(bstrConnect, "admin", "", ADODB::adConnectUnspecified);
    if(SUCCEEDED(hr))
    {
        cout<<DAM<<": Successfully connected to database. Data source name:\n  "
            <<pConn->GetConnectionString()<<endl;

        // Prepare SQL query
        _bstr_t query = "SELECT Customers.[Company], Customers.[First Name] FROM Customers;";
        cout <<DAM<<": SQL query \n  "<<query<<endl;

        // Execute
        ADODB::_RecordsetPtr pRS("ADODB.Recordset");
        hr = pRS->Open(query,
            _variant_t((IDispatch *) pConn, true),
            ADODB::adOpenUnspecified,
            ADODB::adLockUnspecified,
            ADODB::adCmdText);
        if(SUCCEEDED(hr))
        {
            cout<<DAM<<": Retrieve schema info for the given result set: "<< endl;
            ADODB::Fields* pFields = NULL;
            hr = pRS->get_Fields(&pFields);
            if(SUCCEEDED(hr) && pFields && pFields->GetCount() > 0)
            {
                for(long nIndex=0; nIndex < pFields->GetCount(); nIndex++)
                {
                    cout << " | "<<_bstr_t(pFields->GetItem(nIndex)->GetName());
                }
                cout << endl;
            }
            else
            {
                cout<<DAM<<": Error: Number of fields in the result is set to zero." << endl;
            }
            cout<<DAM<<": Fetch the actual data: " << endl;
            int rowCount = 0;
            while (!pRS->AdoNSEOF)
            {
                for(long nIndex=0; nIndex < pFields->GetCount(); nIndex++)
                {
                    cout<<" | "<<_bstr_t(pFields->GetItem(nIndex)->GetValue());
                }
                cout<< endl;
                pRS->MoveNext();
                rowCount++;
            }
            cout<<DAM<<": Total Row Count:  " << rowCount << endl;
        }
        pRS->Close();
        pConn->Close();
        cout<<DAM<<": Cleanup Done" << endl;
    }
    else
    {
        cout<<DAM<<" : Unable to connect to data source: "<<bstrConnect<<endl;
    }
    ::CoUninitialize();
    return 0;
}

Read more: http://www.physicsforums.com

-------===========--------==========----------==========----------==========--------===========-

ncludes--> fstream cmath complex iostream iomanip vector limits stdlib.h stdio.h time.h fcntl.h string.h ctype.h icrsint.h

using namespace std;


try {
    ADO::_ConnectionPtr conn;
    conn.CreateInstance( __uuidof( ADO::Connection ) );
    conn->Open( L"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\database.mdb;",
        L"",
        L"password",
        ADO::adConnectUnspecified);
} 

catch (_com_error& e) {
    printf("Error:\n");
    printf("Code = %08lx\n", e.Error());
    printf("Message = %s\n", e.ErrorMessage());
    printf("Source = %s\n", (LPCSTR) e.Source());
    printf("Description = %s\n", (LPCSTR) e.Description());
}




This script assumes the first argument is the source file name and that it's a .cpp file. Error handling emitted for brevity.

#!/bin/bash
#set -x
CC=g++
CFLAGS=-O
input_file=$1
shift # pull off first arg
args="$*"
filename=${input_file%%.cpp}

$CC -o $filename.out $CFLAGS $input_file
rc=$?

if [[ $rc -eq 0 ]]; then
   ./$filename.out $args
   exit $?
fi

exit $rc

So, for example running the script "doit" with the arguments "myprogram.cpp input.txt parameter output.txt" we see:

% bash -x ./doit myprogram.cpp input.txt parameter output.txt
+ set -x
+ CC=g++
+ CFLAGS=-O
+ input_file=myprogram.cpp
+ shift
+ args='input.txt parameter output.txt'
+ filename=myprogram
+ g++ -o myprogram.out -O myprogram.cpp
+ rc=0
+ [[ 0 -eq 0 ]]
+ ./myprogram.out input.txt parameter output.txt
+ exit 0



