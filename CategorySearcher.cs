/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    public abstract class Specification
    {
        //public static string[] getNames(Type type)
        public static T getMemberList<T>(T defaultValue, )
        { 
            Type x = defaultValue.GetType();
            
            IEnumerable<T> IEMemberList = typeof(T)
                .Assembly.GetTypes()
                .Where(v => (v.IsSubclassOf(typeof(T))) && !v.IsAbstract)
                .Select(v => (T)Activator.CreateInstance(v));
            List<string> MemberNames = new List<string>();
            foreach (T member in IEMemberList)
            {
                MemberNames.Add();
            }

            return StationNames.ToArray();
        }
        public static Station findStation(string name)
        {
            // Find the array index of the requested Station
            int stationIndex = Array.FindIndex(getStationNames(), w => w.Equals(name));
            // Create a list of the class names of the inherited Station classes
            IEnumerable<Station> StationList = typeof(Station)
               .Assembly.GetTypes()
               .Where(t => t.IsSubclassOf(typeof(Station)) && !t.IsAbstract)
               .Select(t => (Station)Activator.CreateInstance(t));
            // Use the index in the class name list to return the requested Station
            return StationList.ToArray()[stationIndex];
        }
    }
}*/
