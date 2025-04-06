using System;
using System.Xml.Schema;
using System.Xml;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Remoting.Contexts;
using System.Runtime;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;


/**
 * This template file is created for ASU CSE445 Distributed SW Dev Assignment 4.
 * Please do not modify or delete any existing class/variable/method names. However, you can add more variables and functions.
 * Uploading this file directly will not pass the autograder's compilation check, resulting in a grade of 0.
 * **/


namespace ConsoleApp1
{


    public class Program
    {
        //these are the link to the files I have stored in my GitHub. The GitHub is associated to my school account and the repo is public
        public static string xmlURL = "https://yruizher.github.io/445_Assignments/Hotels.xml";
        public static string xmlErrorURL = "https://yruizher.github.io/445_Assignments/HotelsErrors.xml";
        public static string xsdURL = "https://yruizher.github.io/445_Assignments/Hotels.xsd";

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
            schema.Add(xsdUrl, xsdUrl);

            //defining the validation settings
            XmlReaderSettings hotelSettings = new XmlReaderSettings();

            //association
            hotelSettings.Schemas = schema;
            hotelSettings.ValidationType = ValidationType.Schema;

            string error = "No Errors";

            //adding event handler
            hotelSettings.ValidationEventHandler += (sender, e) =>
            {
                error = $"Validation Error: {e.Message}";
            };

            //creating XmlReader object
            using (XmlReader reader = XmlReader.Create(xmlUrl, hotelSettings))
            {
                try
                {
                    //parsing the file
                    while (reader.Read()) { }
                }
                catch (Exception ex)
                {
                    return $"Exception occurred: {ex.Message}";
                }
            }
                //return "No Error" if XML is valid.
                return error;
        }

        public static string Xml2Json(string xmlUrl)
        {

            using (WebClient client = new WebClient())
            {
                //Will use WebClient to download the xml from the url and then convert into deserializable json string
                string xml = client.DownloadString(xmlUrl);
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xml);

                string jsonString = JsonConvert.SerializeXmlNode(xmlDocument);
                JObject json = JObject.Parse(jsonString);
                string jsonText = json.ToString();
                return jsonText;
            }

            // The returned jsonText needs to be de-serializable by Newtonsoft.Json package. (JsonConvert.DeserializeXmlNode(jsonText))


        }
    }

}
