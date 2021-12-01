using System;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
// For work System.Runtime.Serialization.Formatters.Soap:
// Install System.Runtime.Serialization.Formatters.Soap.dll in C:\Windows\SysWOW64\, if you don't have it. 
// Choose .NET Framework x.x and add reference
using System.Runtime.Serialization.Json;
namespace Lab14_sharp
{
    static class CustomSerializer
    {
        public static void Serialize(string file, Plant plant)
        {
            string format = file.Split('.').Last();
            switch (format)
            {
                case "bin":
                    BinaryFormatter bf = new BinaryFormatter();
                    using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
                    {
                        bf.Serialize(fs, plant);
                    }
                    break;

                case "soap":
                    SoapFormatter sf = new SoapFormatter();
                    using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
                    {
                        sf.Serialize(fs, plant);
                    }
                    break;

                case "xml":
                    XmlSerializer xs = new XmlSerializer(typeof(Plant));
                    using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
                    {
                        xs.Serialize(fs, plant);
                    }
                    break;

                case "json":
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Plant));
                    using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
                    {
                        js.WriteObject(fs, plant);
                    }
                    break;
            }
        }

        public static void Deserialize(string file)
        {
            string format = file.Split('.').Last();
            switch (format)
            {
                case "bin":
                    BinaryFormatter bf = new BinaryFormatter();
                    using (FileStream fs = new FileStream(file, FileMode.Open))
                    {
                        Plant plant = (Plant)bf.Deserialize(fs);
                        Console.WriteLine($"[BIN] Deserialized plant: {plant.Name} {plant.Length}");
                    }
                    break;

                case "soap":
                    SoapFormatter sf = new SoapFormatter();
                    using (FileStream fs = new FileStream(file, FileMode.Open))
                    {
                        Plant plant = (Plant)sf.Deserialize(fs);
                        Console.WriteLine($"[SOAP] Deserialized plant: {plant.Name} {plant.Length}");
                    }
                    break;

                case "xml":
                    XmlSerializer xs = new XmlSerializer(typeof(Plant));
                    using (FileStream fs = new FileStream(file, FileMode.Open))
                    {
                        Plant plant = (Plant)xs.Deserialize(fs);
                        Console.WriteLine($"[XML] Deserialized plant: {plant.Name} {plant.Length}");
                    }
                    break;

                case "json":
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Plant));
                    using (FileStream fs = new FileStream(file, FileMode.Open))
                    {
                        Plant plant = (Plant)js.ReadObject(fs);
                        Console.WriteLine($"[JSON] Deserialized plant: {plant.Name} {plant.Length}");
                    }
                    break;
            }
        }
    }
}
