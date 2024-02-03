using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new(capacity);
        }
        public int Capacity { get; set; }
        public string Name { get; private set; }
        public List<Child> Registry { get; private set; }

        public bool AddChild(Child child)
        {
            if (Capacity > Registry.Count)
            {
                Registry.Add(child);
                return true;
            }
                return false;
            
        }

        public bool RemoveChild(string childFullName)
        {
           Child childToRemove = Registry.FirstOrDefault(c => $"{c.FirstName} {c.LastName}" == childFullName);
            if (childToRemove != null)
            {
                Registry.Remove(childToRemove);
                return true;
            }
            return false;
        }

        public int ChildrenCount => Registry.Count;

        public Child GetChild(string childFullName) =>
            Registry.Find(n => $"{n.FirstName} {n.LastName}" == childFullName);

        public string RegistryReport()
        {
           return $"Registered children in {Name}:"+
                  Environment.NewLine +
                 (string.Join(Environment.NewLine, Registry.OrderByDescending(a=>a.Age).ThenBy(l=>l.LastName).ThenBy(n=>n.FirstName)));
           
        }

    }
}
