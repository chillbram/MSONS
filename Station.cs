using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    public abstract class Station
    {
        // The unique identifier for every station
        public abstract int stationID();
        // The name that should be displayed on screen
        public abstract string stationName();
        // If the station is located internationally
        public abstract bool isInternational();
        public abstract int distance(int sID);
        public static int getTariefeenheden(Station from, Station to)
        {
            return from.distance(to.stationID());
        }
        public static string[] getStationNames()
        {
            IEnumerable<Station> StationList = typeof(Station)
                .Assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Station)) && !t.IsAbstract)
                .Select(t => (Station)Activator.CreateInstance(t));
            List<string> StationNames = new List<string>();
            foreach (Station sta in StationList)
            {
                StationNames.Add(sta.stationName());
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

    public class UtrechtCentraal : Station
    {
        public override int stationID()
        { return 0; }
        public override string stationName()
        { return "Utrecht Centraal"; }
        public override bool isInternational()
        { return false; }

        public override int distance(int sID)
        {
            List<int> eenheden = new List<int> { 0 };

            int tariefeenheid = eenheden[sID];
            return tariefeenheid;
        }
    }
    public class Gouda : Station
    {
        public override int stationID()
        { return 1; }
        public override string stationName()
        { return "Gouda"; }
        public override bool isInternational()
        { return false; }

        public override int distance(int sID)
        {
            List<int> eenheden = new List<int> { 32, 0 };

            int tariefeenheid = eenheden[sID];
            return tariefeenheid;
        }
    }
    public class Geldermalsen : Station
    {
        public override int stationID()
        { return 2; }
        public override string stationName()
        { return "Geldermalsen"; }
        public override bool isInternational()
        { return false; }

        public override int distance(int sID)
        {
            List<int> eenheden = new List<int> { 26, 58, 0 };

            int tariefeenheid = eenheden[sID];
            return tariefeenheid;
        }
    }
    public class Hilversum : Station
    {
        public override int stationID()
        { return 3; }
        public override string stationName()
        { return "Hilversum"; }
        public override bool isInternational()
        { return false; }

        public override int distance(int sID)
        {
            List<int> eenheden = new List<int> { 18, 50, 44, 0 };

            int tariefeenheid = eenheden[sID];
            return tariefeenheid;
        }
    }
    public class Duivendrecht : Station
    {
        public override int stationID()
        { return 4; }
        public override string stationName()
        { return "Duivendrecht"; }
        public override bool isInternational()
        { return false; }

        public override int distance(int sID)
        {
            List<int> eenheden = new List<int> { 31, 54, 57, 18, 0 };

            int tariefeenheid = eenheden[sID];
            return tariefeenheid;
        }
    }
    public class Weesp : Station
    {
        public override int stationID()
        { return 5; }
        public override string stationName()
        { return "Weesp"; }
        public override bool isInternational()
        { return false; }

        public override int distance(int sID)
        {
            List<int> eenheden = new List<int> { 33, 57, 59, 15, 3, 0 };

            int tariefeenheid = eenheden[sID];
            return tariefeenheid;
        }
    }
}
