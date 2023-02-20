
using System;
using System.Messaging;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

namespace Dag7_Opgave3_udskrivTil_ExelArk
{
    internal class Adapter_Og_ExelAPI
    {
        MessageQueue indqueue;

        public Adapter_Og_ExelAPI(MessageQueue indqueue)
        {
            this.indqueue = indqueue;
        }

        public void adaptFlyinformationToExel()
        {
            Console.WriteLine("Hej");

            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            Excel.Range oRng;

            try
            {
                //Start Excel og skaf Application object.
                oXL = new Excel.Application();
                oXL.Visible = true;

                //Opret nyt arbejdsark.
                oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                oSheet = (Excel._Worksheet)oWB.ActiveSheet;

                //Tilføj Kolonneoverskrifter
                oSheet.Cells[1, 1] = "FlightNo";
                oSheet.Cells[1, 2] = "ETA";

                //Format A1:D1
                oSheet.get_Range("A1", "D1").Font.Bold = true;
                oSheet.get_Range("A1", "D1").VerticalAlignment =
                Excel.XlVAlign.xlVAlignCenter;

                //henter message fra køen. 
                Message recivedMessage = indqueue.Receive();
                recivedMessage.Formatter = new XmlMessageFormatter(new Type[] { typeof(Flyinformation) });

                //Adapter ToString fra objektet til strings.  
                String message = recivedMessage.Body.ToString();
                string[] messageStringArray = message.Split(' ');
                string flyAnkomst = messageStringArray[2];
                string flyId = messageStringArray[4];


                // Opret et array med værdier - simuler
                string[,] saNames = new string[5, 2];

                saNames[0, 0] = flyId;
                saNames[0, 1] = flyAnkomst;
                

                //Udfyld med værdier (FlightNo og ETA)
                oSheet.get_Range("A2", "B6").Value2 = saNames;

                //AutoFit columns A:D.
                oRng = oSheet.get_Range("A1", "D1");
                oRng.EntireColumn.AutoFit();

                //Gør synlig
                oXL.Visible = true;
                oXL.UserControl = true;
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Fejl: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Linje: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                //MessageBox.Show(errorMessage, "Error");
            }



        }
        }
    }