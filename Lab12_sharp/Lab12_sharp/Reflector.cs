using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Lab12_sharp
{
    public static class Reflector
    {
        public static string GetAssemblyVersion()
            => typeof(Program)
            .Assembly   // A class that represents an assembly and allows manipulation of that assembly 
            .FullName;  // Gets the display name, Version, Culture, PublicKeyToken of the assembly

        public static bool PublicConstructor(object obj)
            => Type
            .GetType(obj.ToString())
            // We need BindingFlags.Instance to get NON-STATIC methods. 
            .GetConstructors(BindingFlags.Public | BindingFlags.Instance)
            .Length != 0;   // If class have public constructor Length > 0, otherwise Length = 0.

        public static void GetPublicMethods(object obj)
            => Type
            .GetType(obj.ToString())
            // BindingFlags.DeclaredOnly - only members declared at the level of the supplied type's hierarchy should be considered. Inherited members are not considered.
            .GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
            .ToList()
            .ForEach(x => Console.WriteLine($"{x.Name} "));

        public static void GetProperty(object obj)
            => Type
            .GetType(obj.ToString())
            .GetProperties()
            .ToList()
            .ForEach(x => Console.WriteLine($"{x.Name} "));

        public static void GetFields(object obj)
            => Type
            .GetType(obj.ToString())
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .ToList()
            .ForEach(x => Console.WriteLine($"{x.Name} "));

        public static void GetInterfaces(object obj)
            => Type
            .GetType(obj.ToString())
            .GetInterfaces()
            .ToList()
            .ForEach(x => Console.WriteLine($"{x.Name} "));

        public static void GetMethodsByParam(object obj, string parametr)
           => Type
           .GetType(obj.ToString())
           .GetMethods()
           .Where(x => x.GetParameters().Any(n => n.ToString() == parametr))
           .ToList()
           .ForEach(x => Console.WriteLine($"{x.Name} "));

        public static void InvokeFromFile()
        {
            StreamReader reader = new(@"..\..\..\InvokeFile.txt");
            Type type = typeof(SimpleClass);
            string methodName = reader.ReadLine();
            List<string> paramValue = new();
            while (!reader.EndOfStream)
                paramValue.Add(reader.ReadLine());

            MethodInfo method = type.GetMethod(methodName);
            object obj = Activator.CreateInstance(type);
            // CreateInstance()- Creates an instance of the specified type using the constructor that best matches the specified 
            method.Invoke(obj, new object[] { paramValue[0], paramValue[1] });
        }

        public static object Create(string name, string type)
        {
            Type type_of_class = typeof(Plant);
            ConstructorInfo info = type_of_class.GetConstructor(new Type[] { typeof(string), typeof(string) });
            object obj = info.Invoke(new object[] { name, type });

            return obj;
        }
    }
}
