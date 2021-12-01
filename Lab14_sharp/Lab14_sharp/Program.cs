using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Lab14_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Plant plant_1 = new Plant("Rose", 2.5f, 100);
            Plant plant_2 = new Plant("Chamomile", 0.5f, 5);
            Plant plant_3 = new Plant("Marigold", 0.25f, 1);
            Plant plant_4 = new Plant("Tulip", 0.3f, 9);

            CustomSerializer.Serialize(@"..\..\..\Plant.bin", plant_1);
            CustomSerializer.Serialize(@"..\..\..\Plant.soap", plant_2);
            CustomSerializer.Serialize(@"..\..\..\Plant.xml", plant_3);
            CustomSerializer.Serialize(@"..\..\..\Plant.json", plant_4);

            CustomSerializer.Deserialize(@"..\..\..\Plant.bin");
            CustomSerializer.Deserialize(@"..\..\..\Plant.soap");
            CustomSerializer.Deserialize(@"..\..\..\Plant.xml");
            CustomSerializer.Deserialize(@"..\..\..\Plant.json");


            Console.WriteLine();
            List<Plant> list = new List<Plant>() { plant_1, plant_2, plant_3, plant_4 };
            using (FileStream fs = new FileStream(@"..\..\..\List.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<Plant>));
                xs.Serialize(fs, list);
                fs.Close();
                using (FileStream fsd = new FileStream(@"..\..\..\List.xml", FileMode.Open))
                {
                    List<Plant> cars = (List<Plant>)xs.Deserialize(fsd);
                    cars.ForEach(x => Console.WriteLine($"Deserialized plant: {x.Name} {x.Length}"));
                }
            }


            Regex regex = new Regex(@"<Name>(?<N>\w+)</Name><Length>(?<L>\d+([.]\d+)?)</Length>");

            // Search by name.
            XmlDocument xmldocument = new XmlDocument();
            xmldocument.Load(@"..\..\..\List.xml");
            XmlElement xmlRoot = xmldocument.DocumentElement;
            XmlNode tulip = xmlRoot.SelectSingleNode("Plant[Name='Tulip']");
            Console.WriteLine($"\n{regex.Match(tulip.OuterXml).Groups["N"].Value} {regex.Match(tulip.OuterXml).Groups["L"].Value}m\n");

            // All nodes.



            foreach (XmlNode x in xmlRoot.SelectNodes("*"))
            {
                Console.WriteLine($"{regex.Match(x.OuterXml).Groups["N"].Value} {regex.Match(x.OuterXml).Groups["L"].Value}m");
            }



            // XDocumnet usual use with LINQ, because it is easier to use then XmlDocument.
            Console.WriteLine();
            XDocument companies = new XDocument();
            XElement root = new XElement("Companies");
            XElement company = new XElement("company");
            XAttribute companyName = new XAttribute("Name", "IBM");
            XAttribute companyCapitalization = new XAttribute("Capitalization", "$125 billions");
            company.Add(companyName, companyCapitalization);
            root.Add(company);
            companyName = new XAttribute("Name", "Apple");
            companyCapitalization = new XAttribute("Capitalization", "$2.5 trillions");
            company = new XElement("company");
            company.Add(companyName, companyCapitalization);
            root.Add(company);
            companies.Add(root);
            companies.Save(@"..\..\..\Companies.xml");


            // Find in attribute "Name" word "Apple".
            // Where return IEnumarable and after that convert to list with ToList(),
            // then iterate over this list using ForEach()
            root.Elements("company")
                .Where(i => i.Attribute("Name").Value == "Apple")
                .ToList()
                .ForEach(x => Console.WriteLine(x.Attribute("Capitalization").Value));

            //foreach (var i in root.Elements("company").Where(i => i.Attribute("Name").Value == "Apple"))
            //{
            //    Console.WriteLine(i.Attribute("Capitalization").Value);
            //}
        }
    }
}
