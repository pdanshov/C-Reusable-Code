

// // // // // // // // // // // // // // // // // // //
// Breakpoint will not be hit, symbols not loaded
// // // // // // // // // // // // // // // // // // //

string path = Directory.GetCurrentDirectory();
/	-or- (Better)
string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
/	-also-
Path.GetDirectoryName(Application.ExecutablePath);
/	-which is the same as-
Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);


GetEntryAssembly() and GetExecutingAssembly() has an interesting difference. For details refer stackoverflow.com/a/18562036/30289


Console.WriteLine("The current directory is {0}", path);


// // // // // // // // // // // // // // // // // // //
// Code for Reports/Forms AAWS
// // // // // // // // // // // // // // // // // // //

/In Below block, after messagebox:

string[] lines = { "First line", "Second line", "Third line" };
            // WriteAllLines creates a file, writes a collection of strings to the file, 
            // and then closes the file.
            System.IO.File.WriteAllLines(@"C:\Desktop\WriteLines.txt", lines);

/After public override void Execute() in CSI.AAWS.ArCtbQuarterlyRpt.CtbQrtRptControl

private void InitializeComponent()
        {
            this.txtDateThru = new TRAVERSE.Controls.TravDateControl();
            this.splitContainerProcess.Panel1.SuspendLayout();
            this.splitContainerProcess.SuspendLayout();
            this.splitContainerBase.Panel1.SuspendLayout();
            this.splitContainerBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateThru.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateThru.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerProcess
            // 
            // 
            // splitContainerProcess.Panel1
            // 
            this.splitContainerProcess.Panel1.Controls.Add(this.txtDateThru);
            this.splitContainerProcess.Size = new System.Drawing.Size(739, 448);
            // 
            // splitContainerBase
            // 
            // 
            // txtDateThru
            // 
            this.txtDateThru.EditValue = null;
            this.txtDateThru.Location = new System.Drawing.Point(94, 16);
            this.txtDateThru.Name = "txtDateThru";
            this.txtDateThru.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.txtDateThru.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDateThru.Properties.Mask.EditMask = "MM/yyyy";
            this.txtDateThru.Properties.MaxValue = new System.DateTime(9999, 12, 31, 23, 59, 59, 0);
            this.txtDateThru.Properties.MinValue = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.txtDateThru.Properties.SetupFunctionId = 0;
            this.txtDateThru.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDateThru.SecurityId = null;
            this.txtDateThru.Size = new System.Drawing.Size(100, 20);
            this.txtDateThru.TabIndex = 1;
            // 
            // CtbQrtRptControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "CtbQrtRptControl";
            this.splitContainerProcess.Panel1.ResumeLayout(false);
            this.splitContainerProcess.ResumeLayout(false);
            this.splitContainerBase.Panel1.ResumeLayout(false);
            this.splitContainerBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateThru.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateThru.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

// // // // // // // // // // // // // // // // // // //
// SQL
// // // // // // // // // // // // // // // // // // //

int i;
//suppose ds is your dataset
for (i =0; i <= ds.Tables(0).Rows.Count - 1;i++) 
//you can pass the index/ name  of your table in the tables collection but name should be in string
{
       //Do your code here
       // You dont need to check any EOF or BOF in this case
      // It would only come in this loop if the records are there in the table
}

 -or- 

In .Net there is no more EOF and BOF
You can check the conditions by using the dataset tables itself..
Dim dt As New DataTable
Dim i As Integer
If i = 0 Or i = dt.Rows.Count - 1 Then
'Here you can check the things
Else
End If
'In .Net the Arrays are 0 index based

////////////////////////////////////////////////////////

conn.Open();
SqlDataAdapter adapter = new SqlDataAdapter();
DataSet ds0 = new DataSet();
SqlCommand cmd0 = new SqlCommand( "Sp_Select_Slitlamp_by_Slitlamp_id ", conn );
cmd0.CommandType = CommandType.StoredProcedure;
cmd0.Parameters.Add( "@Slitlamp_id" , Request["Slitlamp_id"] );
cmd0.Prepare();
adapter.SelectCommand = cmd0;
adapter.Fill(ds0);
DataView dvw0 = ds0.Tables[0].DefaultView;

this.chkbx_2.Checked = Convert.ToBoolean( dvw0[0]["FlairR"].ToString() );
this.chkbx_1.Checked = Convert.ToBoolean( dvw0[0]["CelsR"].ToString() );

/ // / / ////////////////////////////////////////////////////


// // // // // // // // // // // // // // // // // // //
// Save File Dialog
// // // // // // // // // // // // // // // // // // //

SaveFileDialog saveFileDialog1 = new SaveFileDialog(); 
saveFileDialog1.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments); 
saveFileDialog1.Filter = "Your extension here (*.EXT)|*.ext|All Files (*.*)|*.*" ; 
saveFileDialog1.FilterIndex = 1; 

if(saveFileDialog1.ShowDialog() == DialogResult.OK) 
{ 
    Console.WriteLine(saveFileDialog1.FileName);//Do what you want here
} 

/ ///////////////////////////////////////////////////////

private void Save_As_Click(object sender, EventArgs e)
{
  SaveFileDialog _SD = new SaveFileDialog(); 
  _SD.Filter = "Text File (*.txt)|*.txt|Show All Files (*.*)|*.*";
  _SD.FileName = "Untitled"; 
  _SD.Title = "Save As";
  if (__SD.ShowDialog() == DialogResult.OK)
  {
   RTBox1.SaveFile(__SD.FileName, RichTextBoxStreamType.UnicodePlainText);
  }
}

/////////////////////////////////////////////////////////

saveDialog.OverwritePrompt - will only prompt the user if they want to overwrite. It will not overwrite
								the file. You have to handle this in your code.
saveDialog.CheckFileExists - will only check if the file exists.
This code works - if I choose to overwerite an existing file it shows me the Prompt:
    SaveFileDialog saveDialog = new SaveFileDialog();
    saveDialog.OverwritePrompt = true;
    DialogResult dgResult = saveDialog.ShowDialog();
    if (dgResult == DialogResult.OK)
    {
        //exportAvi(saveDialog.FileName);
    }
[Window Title] Confirm Save As
[Content] XYZ.txt already exists. Do you want to replace it?
[Yes] [No]

//////////////////////////////////////////////////////////

http://csharp.net-tutorials.com/file-handling/reading-and-writing/:

namespace FileHandlingArticleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if(File.Exists("test.txt"))
            {
                string content = File.ReadAllText("test.txt");
                Console.WriteLine("Current content of file:");
                Console.WriteLine(content);
            }
            Console.WriteLine("Please enter new content for the file:");
            string newContent = Console.ReadLine();
            File.WriteAllText("test.txt", newContent);
        }
    }
}

File.AppendAllText("test.txt", newContent);

Console.WriteLine("Please enter new content for the file - type exit and press enter to finish editing:");
string newContent = Console.ReadLine();
while(newContent != "exit")
{
    File.AppendAllText("test.txt", newContent + Environment.NewLine);
    newContent = Console.ReadLine();
}

Console.WriteLine("Please enter new content for the file - type exit and press enter to finish editing:");
using(StreamWriter sw = new StreamWriter("test.txt"))
{
    string newContent = Console.ReadLine();
    while(newContent != "exit")
    {
        sw.Write(newContent + Environment.NewLine);
        newContent = Console.ReadLine();
    }
}

/////////////////////////////////////////////////////////////////////

http://codereview.stackexchange.com/questions/1420/safe-way-to-overwrite-an-existing-file-in-c:

string tempFile = Path.GetTempFileName();

using (Stream tempFileStream = File.Open(tempFile, FileMode.Truncate))
{
    SafeXmlSerializer xmlFormatter = new SafeXmlSerializer(typeof(Project));
    xmlFormatter.Serialize(tempFileStream, Project);
}

if (File.Exists(fileName)) File.Delete(fileName);
File.Move(tempFile, fileName);
if (File.Exists(tempFile)) File.Delete(tempFile);

if (!string.IsNullOrEmpty(oldFileTempName) && File.Exists(oldFileTempName))
{
	File.Move(oldFileTempName, fileName);
}
MessageBox.Show("...");
throw;

//////////////////////////////////////////////////////////////////////

Sounds to me that you actually want the user to pick the folder so you can then fill it with files. In which case you should use FolderBrowserDialog. It was designed to let the user choose a folder.

/////////////////////////////////////////////////////////////////////


SaveFileDialog textDialog;
public Page()
{
    InitializeComponent();
    textDialog = new SaveFileDialog();
    textDialog.Filter = "Text Files | *.txt";
    textDialog.DefaultExt = "txt";
 }

private void button1_Click(object sender, RoutedEventArgs e)
{
    bool? result = textDialog.ShowDialog();
    if (result == true)
    {
        System.IO.Stream fileStream = textDialog.OpenFile();
        System.IO.StreamWriter sw = new System.IO.StreamWriter(fileStream);
        sw.WriteLine("Writing some text in the file.");
        sw.Flush();
        sw.Close();
    }
}
 
// // // // // // // // // // // // // // // // // // //
// SQL Server Reporting Services PDF (SSRS)
// // // // // // // // // // // // // // // // // // //

We are doing an SSRS project and we need to test the reports for different parameters.
Hence I want to create an application which will automatically convert rdl(SSRS) to pdf by using the parameters.
Thanks, Kiran
Use the ReportExecutionService class. If you have any report parameters to set, use SetExecutionParameters() and Render() with Format=PDF. Code samples at the bottom of the Render method page.
http://msdn.microsoft.com/en-us/library/cc282506.aspx
http://msdn.microsoft.com/en-us/library/reportexecution2005.reportexecutionservice.setexecutionparameters.aspx
http://msdn.microsoft.com/en-us/library/reportexecution2005.reportexecutionservice.render.aspx
using System;
using System.IO;
using System.Web.Services.Protocols;
using myNamespace.MyReferenceName;
class Sample
{
    static void Main(string[] args)
    {
        ReportExecutionService rs = new ReportExecutionService();
        rs.Credentials = System.Net.CredentialCache.DefaultCredentials;
        rs.Url = "http://myserver/reportserver/ReportExecution2005.asmx";
        // Render arguments
        byte[] result = null;
        string reportPath = "/AdventureWorks Sample Reports/Employee Sales Summary";
        string format = "MHTML";
        string historyID = null;
        string devInfo = @"<DeviceInfo><Toolbar>False</Toolbar></DeviceInfo>";
        // Prepare report parameter.
        ParameterValue[] parameters = new ParameterValue[3];
        parameters[0] = new ParameterValue();
        parameters[0].Name = "EmpID";
        parameters[0].Value = "288";
        parameters[1] = new ParameterValue();
        parameters[1].Name = "ReportMonth";
        parameters[1].Value = "6"; // June
        parameters[2] = new ParameterValue();
        parameters[2].Name = "ReportYear";
        parameters[2].Value = "2004";
        DataSourceCredentials[] credentials = null;
        string showHideToggle = null;
        string encoding;
        string mimeType;
        string extension;
        Warning[] warnings = null;
        ParameterValue[] reportHistoryParameters = null;
        string[] streamIDs = null;
        ExecutionInfo execInfo = new ExecutionInfo();
        ExecutionHeader execHeader = new ExecutionHeader();
        rs.ExecutionHeaderValue = execHeader;
        execInfo = rs.LoadReport(reportPath, historyID);
        rs.SetExecutionParameters(parameters, "en-us"); 
        String SessionId = rs.ExecutionHeaderValue.ExecutionID;
        Console.WriteLine("SessionID: {0}", rs.ExecutionHeaderValue.ExecutionID);
        try
        {
            result = rs.Render(format, devInfo, out extension, out encoding, out mimeType, out warnings, out streamIDs);
            execInfo = rs.GetExecutionInfo();
            Console.WriteLine("Execution date and time: {0}", execInfo.ExecutionDateTime);
        }
        catch (SoapException e)
        {
            Console.WriteLine(e.Detail.OuterXml);
        }
        // Write the contents of the report to an MHTML file.
        try
        {
            FileStream stream = File.Create("report.mht", result.Length);
            Console.WriteLine("File created.");
            stream.Write(result, 0, result.Length);
            Console.WriteLine("Result written to the file.");
            stream.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

///////////////////////////////////////////////////////////////////////////////

public static void SaveReport()
        {

            //SSRS_Report.RS2010.ReportExecutionService rs = new System.Web.Services.ReportExecutionService();
            SSRS_Report.RS2010.ReportingService2010 svc = new SSRS_Report.RS2010.ReportingService2010();

            // The SQL 2008 endpoint contains both of these and the separate links are not needed
            SSRS_Report.RS2010.ReportingService2010 rs;
            //RE2010.ReportExecutionService rsExec;
            SSRS_Report.RS2010.ReportingService2010 rsExec;

            // Create a new proxy to the web service
            rs = new SSRS_Report.RS2010.ReportingService2010();
            rsExec = new SSRS_Report.RS2010.ReportingService2010();

            // Authenticate to the Web service using Windows credentials
            rs.Credentials = System.Net.CredentialCache.DefaultCredentials;
            rsExec.Credentials = System.Net.CredentialCache.DefaultCredentials;

            //rs.Url = "http://<SERVER>/reportserver/reportservice2005.asmx";
            //rsExec.Url = "http://<SERVER>/reportserver/reportexecution2005.asmx";
            rs.Url = "http://programmer-pc/ReportServer_BLUE10LIVE/reportservice2005.asmx";
            rsExec.Url = "http://programmer-pc/ReportServer_BLUE10LIVE/reportservice2005.asmx";

            string historyID = null;
            string deviceInfo = null;
            string format = "EXCEL";
            Byte[] results;
            string encoding = String.Empty;
            string mimeType = String.Empty;
            string extension = String.Empty;
            RS2010.Warning[] warnings = null;
            string[] streamIDs = null;

            // Path of the Report - XLS, PDF etc.
            string fileName = @"c:\samplereport.xls";
            // Name of the report - Please note this is not the RDL file.
            string _reportName = @"/Marketing_Report";
            string _historyID = null;
            bool _forRendering = false;
            RS2010.ParameterValue[] _values = null;
            RS2010.DataSourceCredentials[] _credentials = null;
            RS2010.ParameterValue[] _parameters = null;
            //ReportParameter[] _parameters = null;

            try
            {
                //_parameters = rs.GetReportParameters(_reportName, _historyID, _forRendering, _values, _credentials);
                _parameters = rs.GetItemParameters(_reportName, _historyID, _forRendering, _values, _credentials);
                //_parameters = rs.GetReportServerConfigInfo(true);
                RS2010.E .ExecutionInfo ei = rsExec.LoadReport(_reportName, historyID);
                RS2010.ParameterValue[] parameters = new RS2010.ParameterValue[1];

                if (_parameters.Length > 0)
                {
                    //parameters[0] = new RE2005.ParameterValue();
                    //parameters[0].Label = "";
                    //parameters[0].Name  = "";
                    //parameters[0].Value = "";
                }
                rsExec.SetExecutionOptions(parameters, "en-us");// .SetExecutionParameters(parameters, "en-us");

                results = rsExec.Render(format, deviceInfo,
                          out extension, out encoding,
                          out mimeType, out warnings, out streamIDs);

                using (FileStream stream = File.OpenWrite(fileName))
                {
                    stream.Write(results, 0, results.Length);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

Currently I have SQL Reporting Services 2005 set up, with the report manager at a URL on which users can access reports. The reports are working great there.
My issue is trying to generate these reports in C# .net 4.0 code without any user interaction (such as using the report viewer on screen). I would like to generate and export a report to a PDF file in a C# .net application. The reports have required parameters so I would need to pass the parameters to the report. How can I do this?
I have been searching around online, and either I'm using the wrong keywords or there isn't much information on this. I am quite amazed at how difficult it has been to find information on this, as I would expect it to be a fairly common question. Any and all advice / help is appreciated.

string outputPath = "C:\Temp\PdfReport.pdf";
ReportViewer reportViewer = new ReportViewer();
reportViewer.ServerReport serverReport = new ServerReport();
reportViewer.ServerReport.ReportPath = @"path/to/report";
reportViewer.ServerReport.ReportServerUrl = new Uri(@"http://...");
reportViewer.ProcessingMode = ProcessingMode.Local;
reportViewer.ServerReport.ReportServerCredentials.NetworkCredentials = new System.Net.NetworkCredential(username, password, domain)
List<ReportParameter> parameters = new List<ReportParameter>();
parameters.Add(new ReportParameter("parameterName", "value"));
string mimeType;
string encoding;
string extension;
string[] streams;
Warning[] warnings;
byte[] pdfBytes= serverReport.Render("PDF", string.Empty, out mimeType, out encoding, out extension, out streams, out warnings);
// save the file
using (FileStream fs = new FileStream(outputPath, FileMode.Create))
{
    fs.Write(pdfBytes, 0, pdfBytes.Length);
    fs.Close();
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

I want to write c# code to make Export SSRS local report to pdf Without Rendering it in report viewer
How can i do that?
You can use LocalReport.Render method to obtain a Byte array that you can save using FileStream.
You could do it without any C# by using the Subscriptions feature on the Report server, this has options to output in PDF to a file location, or send via email.

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;
using Microsoft.Reporting.WinForms;
using System.IO;
namespace EmailReport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
        private void emailButton_Click(object sender, EventArgs e)
        {
            string reportFilename = ExportReport();
            ApplicationClass outlookApp = new ApplicationClass();
            MailItem mailItem = (MailItem)outlookApp.CreateItem(OlItemType.olMailItem);
            mailItem.To = "";
            mailItem.Subject = "Your Report";
            mailItem.Body = "Please find your report attached";
            mailItem.Attachments.Add(reportFilename, (int)OlAttachmentType.olByValue, 1, reportFilename);
            File.Delete(reportFilename);
            mailItem.Display(false);
        }
        private string ExportReport()
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;
            ReportParameterInfoCollection pInfo = reportViewer1.ServerReport.GetParameters();
            string filenameParams = "";
            byte[] bytes;
            if (reportViewer1.ProcessingMode == ProcessingMode.Local)
            {
               bytes = reportViewer1.LocalReport.Render("PDF", null, out mimeType,
                out encoding, out filenameExtension, out streamids, out warnings);
            }
            else
            {
               bytes = reportViewer1.ServerReport.Render("PDF", null, out mimeType,
                out encoding, out filenameExtension, out streamids, out warnings);
            }
            string filename = Path.Combine(Path.GetTempPath(), filenameParams + ".pdf");
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            { fs.Write(bytes, 0, bytes.Length); }
            return filename;
        }
        private void reportViewer1_Load(object sender, EventArgs e)
        {
        }
    }
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.IO;
using System.Web.Services.Protocols;
class Sample
{
   public static void Main()
   {
      ReportingService rs = new ReportingService();
      rs.Credentials = System.Net.CredentialCache.DefaultCredentials;
      byte[] bytes = null;
      string reportPath = "/SampleReports/Employee Sales Summary";
      string format = "PDF";
      string historyID = null;
      string devInfo = @"<DeviceInfo><Toolbar>False</Toolbar></DeviceInfo>";
      // Prepare report parameter.
      ParameterValue[] parameters = new ParameterValue[3];
      parameters[0] = new ParameterValue();
      parameters[0].Name = "EmpID";
      parameters[0].Value = "38";
      parameters[1] = new ParameterValue();
      parameters[1].Name = "ReportMonth";
      parameters[1].Value = "6"; // June
      parameters[2] = new ParameterValue();
      parameters[2].Name = "ReportYear";
      parameters[2].Value = "2004";
      DataSourceCredentials[] credentials = null;
      string showHideToggle = null;
      string encoding;
      string mimeType;
      Warning[] warnings = null;
      ParameterValue[] reportHistoryParameters = null;
      string[] streamIDs = null;
      SessionHeader sh = new SessionHeader();
      rs.SessionHeaderValue = sh;
      try
      {
         result = rs.Render(reportPath, format, historyID, devInfo, parameters, credentials,
            showHideToggle, out encoding, out mimeType, out reportHistoryParameters, out warnings,
            out streamIDs);
      }
      catch (SoapException e)
      {
         Console.WriteLine(e.Detail.OuterXml);
      }
      // Write the contents of the report to an MHTML file.
      try
      {
         FileStream stream = File.Create( "report.PDF", result.Length );
         Console.WriteLine( "File created." );
         stream.Write( bytes, 0, result.Length );
         Console.WriteLine( "Result written to the file." );
         stream.Close();
      }
      catch ( Exception e )
      {
         Console.WriteLine( e.Message );
      }
   }
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

http://msdn.microsoft.com/en-us/library/aa237438%28SQL.80%29.aspx

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Web.Services.Protocols;
using Microsoft.Reporting.WebForms;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using System.Security.Principal;

using SSRS_Report.RS2010;

namespace SSRS_Report
{
    public class SSRS_One
    {
        //<referenceName>.ReportExecutionService rsExec = new <NameSpace>.<referenceName>.ReportExecutionService();
        //rsExec.LoadReport(...);

        ///////////////////////////////////////////////////////////////////////////////////////////

        //try
        //{
        //    string urlReportServer = "http://sqlDBServer//Reportserver";
        //    rptViewer.ProcessingMode = ProcessingMode.Remote; // ProcessingMode will be Either Remote or Local
        //    rptViewer.ServerReport.ReportServerUrl = new Uri(urlReportServer); //Set the ReportServer Url
        //    rptViewer.ServerReport.ReportPath = "/ReportName"; //Passing the Report Path
        //    //Creating an ArrayList for combine the Parameters which will be passed into SSRS Report
        //    ArrayList reportParam = new ArrayList();
        //    reportParam = ReportDefaultParam();
        //    ReportParameter[] param = new ReportParameter[reportParam.Count];
        //    for (int k = 0; k < reportParam.Count; k++)
        //    {
        //        param[k] = (ReportParameter)reportParam[k];
        //    }
        //    // pass crendentitilas
        //    //rptViewer.ServerReport.ReportServerCredentials =
        //    //  new ReportServerCredentials("uName", "PassWORD", "doMain");
        //    //pass parmeters to report
        //    rptViewer.ServerReport.SetParameters(param); //Set Report Parameters
        //    rptViewer.ServerReport.Refresh();
        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////

        //SSRS_Report.System.Web.Services.ReportExecutionService rs = new SSRS_Report.System.Web.Services.ReportExecutionService();
        //rs.Url = "http://myservername.reportserver/reportexecution2005.asmx?wsdl";
        //rs.Credentials = System.Net.CredentialCache.DefaultCredentials

        ////////////////////////////////////////////////////////////////////////////////////////////

        //ReportExecutionService rs = new ReportExecutionService();
        //rs.Credentials = System.Net.CredentialCache.DefaultCredentials;
        //rs.Url = "http://myserver/reportserver/ReportExecution2005.asmx";

        //// Render arguments
        //byte[] result = null;
        //string reportPath = "/AdventureWorks Sample Reports/Employee Sales Summary";
        //string format = "MHTML";
        //string historyID = null;
        //string devInfo = @"<DeviceInfo><Toolbar>False</Toolbar></DeviceInfo>";

        //// Prepare report parameter.
        //ParameterValue[] parameters = new ParameterValue[3];
        //parameters[0] = new ParameterValue();
        //parameters[0].Name = "EmpID";
        //parameters[0].Value = "288";
        //parameters[1] = new ParameterValue();
        //parameters[1].Name = "ReportMonth";
        //parameters[1].Value = "6"; // June
        //parameters[2] = new ParameterValue();
        //parameters[2].Name = "ReportYear";
        //parameters[2].Value = "2004";

        //DataSourceCredentials[] credentials = null;
        //string showHideToggle = null;
        //string encoding;
        //string mimeType;
        //string extension;
        //Warning[] warnings = null;
        //ParameterValue[] reportHistoryParameters = null;
        //string[] streamIDs = null;
        
        //ExecutionInfo execInfo = new ExecutionInfo();
        //ExecutionHeader execHeader = new ExecutionHeader();

        //rs.ExecutionHeaderValue = execHeader;

        //execInfo = rs.LoadReport(reportPath, historyID);

        //rs.SetExecutionParameters(parameters, "en-us"); 
        //String SessionId = rs.ExecutionHeaderValue.ExecutionID;

        //Console.WriteLine("SessionID: {0}", rs.ExecutionHeaderValue.ExecutionID);


        //try
        //{
        //    result = rs.Render(format, devInfo, out extension, out encoding, out mimeType, out warnings, out streamIDs);

        //    execInfo = rs.GetExecutionInfo();

        //    Console.WriteLine("Execution date and time: {0}", execInfo.ExecutionDateTime);


        //}
        //catch (SoapException e)
        //{
        //    Console.WriteLine(e.Detail.OuterXml);
        //}
        //// Write the contents of the report to an MHTML file.
        //try
        //{
        //    FileStream stream = File.Create("report.mht", result.Length);
        //    Console.WriteLine("File created.");
        //    stream.Write(result, 0, result.Length);
        //    Console.WriteLine("Result written to the file.");
        //    stream.Close();
        //}
        //catch (Exception e)
        //{
        //    Console.WriteLine(e.Message);
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void SaveReport()
        {

            //SSRS_Report.RS2010.ReportExecutionService rs = new System.Web.Services.ReportExecutionService();
            //SSRS_Report.RS2010.ReportingService2010 svc = new SSRS_Report.RS2010.ReportingService2010();

            // The SQL 2008 endpoint contains both of these and the separate links are not needed
            //SSRS_Report.RS2010.ReportingService2010 rs;
            RS2005.ReportingService2005 rs;
            RE2005.ReportExecutionService rsExec;
            //SSRS_Report.RS2010.ReportingService2010 rsExec;

            // Create a new proxy to the web service
            //rs = new SSRS_Report.RS2010.ReportingService2010();
            //rsExec = new SSRS_Report.RS2010.ReportingService2010();
            rs = new RS2005.ReportingService2005();
            rsExec = new RE2005.ReportExecutionService();

            // Authenticate to the Web service using Windows credentials
            rs.Credentials = System.Net.CredentialCache.DefaultCredentials;
            rsExec.Credentials = System.Net.CredentialCache.DefaultCredentials;

            rs.Url = "http://localhost/reportserver$VLUE10LIVE/reportservice2005.asmx";
            rsExec.Url = "http://localhost/reportserver/reportexecution2005.asmx";
            //rs.Url = "http://programmer-pc/ReportServer_BLUE10LIVE/reportservice2005.asmx";
            //rsExec.Url = "http://programmer-pc/ReportServer_BLUE10LIVE/reportservice2005.asmx";

            string historyID = null;
            string deviceInfo = null;
            string format = "PDF";
            Byte[] results;
            string encoding = String.Empty;
            string mimeType = String.Empty;
            string extension = String.Empty;
            RS2005.Warning[] warnings = null;
            string[] streamIDs = null;

            // Path of the Report - XLS, PDF etc.
            string fileName = @"c:\samplereport.pdf";
            // Name of the report - Please note this is not the RDL file.
            string _reportName = @"/Marketing_Report";
            string _historyID = null;
            bool _forRendering = false;
            RS2005.ParameterValue[] _values = null;
            RS2005.DataSourceCredentials[] _credentials = null;
            RS2005.ParameterValue[] _parameters = null;
            //ReportParameter[] _parameters = null;

            try
            {
                _parameters = rs.GetReportParameters(_reportName, _historyID, _forRendering, _values, _credentials);
                //_parameters = rs.GetItemParameters(_reportName, _historyID, _forRendering, _values, _credentials);
                //_parameters = rs.GetReportServerConfigInfo(true);
                //RS2010.E .ExecutionInfo ei = rsExec.LoadReport(_reportName, historyID);
                RS2005.ParameterValue[] parameters = new RS2005.ParameterValue[1];
                RE2005.ExecutionInfo ei = rsExec.LoadReport(_reportName, historyID);

                if (_parameters.Length > 0)
                {
                    //parameters[0] = new RE2005.ParameterValue();
                    //parameters[0].Label = "";
                    //parameters[0].Name  = "";
                    //parameters[0].Value = "";
                }
                //rsExec.SetExecutionOptions(parameters, "en-us");// .SetExecutionParameters(parameters, "en-us");
                rsExec.SetExecutionParameters(parameters, "en-us");

                results = rsExec.Render(format, deviceInfo,
                          out extension, out encoding,
                          out mimeType, out warnings, out streamIDs);

                using (FileStream stream = File.OpenWrite(fileName))
                {
                    stream.Write(results, 0, results.Length);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}


// // // // // // // // // // // // // // // // // // //
// Calling Methods/Functions in Referenced/Reflected .dll's
// // // // // // // // // // // // // // // // // // //



// The question and answer you reference is using reflection to call the method in the managed DLL. This isn't necessary if, as you say you want to do, you simply reference your DLL. Add the reference (via the Add Reference option in Visual Studio), and you can call your method directly like so:
ExampleDLL.Program p = new ExampleDLL.Program(); // get an instance of `Program`
p.myVoid(); // call the method `myVoid`
// ------------------------------------------------------------------------
using System.Reflection;
// If you want to go the reflection route (as given by woohoo), you still need an instance of your Program class.
Assembly SampleAssembly = Assembly.LoadFrom(filename);
Type myType = SampleAssembly.GetTypes()[0];
MethodInfo Method = myType.GetMethod("myVoid");
object myInstance = Activator.CreateInstance(myType);
Method.Invoke(myInstance, null);
// Now you have an instance of Program and can call myVoid.

woohoo:
	Assembly assembly = Assembly.LoadFrom(assemblyName);
	System.Type type = assembly.GetType(typeName);
	Object o = Activator.CreateInstance(type);
	IYourType yourObj = (o as IYourType);
	// where assemblyName and typeName are strings, for example:
	string assemblyName = @"C:\foo\yourDLL.dll";
	string typeName = "YourCompany.YourProject.YourClass";
	yourObj.DoSomething(someParameter);
	// Of course, what methods you can call is defined by your interface IYourType



// // // // // // // // // // // // // // // // // // //
// 
// // // // // // // // // // // // // // // // // // //


