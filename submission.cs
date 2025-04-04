using System;
using System.Xml.Schema;
using System.Xml;
using Newtonsoft.Json;
using System.IO;




/**
 * This template file is created for ASU CSE445 Distributed SW Dev Assignment 4.
 * Please do not modify or delete any existing class/variable/method names. However, you can add more variables and functions.
 * Uploading this file directly will not pass the autograder's compilation check, resulting in a grade of 0.
 * **/


namespace ConsoleApp1
{


    public class Program
    {
        public static string xmlURL = "https://github.com/Yruizher/445_Assignments/blob/main/Hotels.xml";
        public static string xmlErrorURL = "Your Error XML URL"; //Not made yet
        public static string xsdURL = "https://github.com/Yruizher/445_Assignments/blob/main/Hotels.xsd";

        public static void Main(string[] args)
        {
            string result = Verification(xmlURL, xsdURL);
            Console.WriteLine(result);


            result = Verification(xmlErrorURL, xsdURL);
            Console.WriteLine(result);


            result = Xml2Json(xmlURL);
            Console.WriteLine(result);
        }

        // Q2.1
        public static string Verification(string xmlUrl, string xsdUrl)
        {
          
            //making a new XmlSchemaSet class
            XmlSchemaSet schema = new XmlSchemaSet();

            //adding the scehma to collection
            schema.Add(null, xsdUrl);

            //defining the validation settings
            XmlReaderSettings hotelSettings = new XmlReaderSettings();

            //association
            hotelSettings.Schemas = schema;
            hotelSettingssettings.ValidationType = ValidationType.Schema;

            string error = "No Error";

            //adding event handler
            settings.ValidationEventHandler += ValidationEventHandler = (sender, e) =>
            {
                error = $"Validation Error: {e.Message}"; 
            }

            //creating XmlReader object
            XmlReader reader = XmlReader.Create(xmlUrl, hotelSettings);

            //parsing the file
            while (reader.Read()) { }
            
            //return "No Error" if XML is valid.
            return error;
        }

        public static string Xml2Json(string xmlUrl)
        {

            string jsonText = "Not Completed Yet";
            // The returned jsonText needs to be de-serializable by Newtonsoft.Json package. (JsonConvert.DeserializeXmlNode(jsonText))
            return jsonText;

        }
    }

}
