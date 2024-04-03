using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //EditXmlFile();
            
            ChangeAssemblyInfoVersion("c:\\MyProject",  version : "0.0.0.1");

            Console.ReadLine();
        }

        private static void ChangeAssemblyInfoVersion(string folderPath, string version)
        {
            var assemblyInfoFiles = System.IO.Directory.GetFiles(folderPath, "AssemblyInfo.cs", System.IO.SearchOption.AllDirectories);
            
            foreach (var assemblyInfoFile in assemblyInfoFiles)
            {
                var assemblyInfoContent = System.IO.File.ReadAllText(assemblyInfoFile);
                var modifiedContent = Regex.Replace(assemblyInfoContent, @"(?<=AssemblyVersion\("")\d+\.\d+\.\d+\.\d+(?=""\))", version);
                modifiedContent = Regex.Replace(assemblyInfoContent, @"(?<=AssemblyFileVersion\("")\d+\.\d+\.\d+\.\d+(?=""\))", version);
                System.IO.File.WriteAllText(assemblyInfoFile, modifiedContent);
            }
        }

        private static void EditXmlFile()
        {
            XmlDocument prvXmlDocto;
            XmlAttribute xmlAttKey;

            //open the XML file
            prvXmlDocto = new XmlDocument();
            prvXmlDocto.PreserveWhitespace = true;
            string fileName = "x.config";
            prvXmlDocto.Load(fileName);

            XmlNode xmlNodeStart = prvXmlDocto.SelectSingleNode("//c");

            XmlNode newSub = prvXmlDocto.CreateNode(XmlNodeType.Element, "add", null);
            XmlAttribute xa = prvXmlDocto.CreateAttribute("key");
            xa.Value = "Project";
            newSub.Attributes.Append(xa);
            xmlNodeStart.AppendChild(newSub);


            var buffer = new StringBuilder();
            var writer = XmlWriter.Create(fileName, new XmlWriterSettings { Indent = true });
            prvXmlDocto.Save(writer);
            writer.Close();
        }

    }
}
