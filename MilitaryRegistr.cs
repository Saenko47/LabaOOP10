using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LabaOOP10
{
    internal class MilitaryRegistr
    {
        MilitaryCard[] militaryCards;
        public MilitaryRegistr(MilitaryCard[] militaryCard)
        {
            this.militaryCards = militaryCard;
        }
        public MilitaryRegistr()
        {
            this.militaryCards = new MilitaryCard[0];
        }
        public MilitaryCard[] MilitaryCards
        {
            get { return militaryCards; }
            set { militaryCards = value; }
        }
        public MilitaryCard this[int index]
        {
            get
            {
                if (index >= 0 && index < militaryCards.Length)
                    return militaryCards[index];
                else
                    throw new IndexOutOfRangeException("Index out of range");
            }
            set
            {
                if (index >= 0 && index < militaryCards.Length)
                    militaryCards[index] = value;
                else
                    throw new IndexOutOfRangeException("Index out of range");
            }
        }
        public void ShowAllMilitaryCards()
        {
            foreach (var notSoldier in militaryCards)
            {
                Console.WriteLine(notSoldier.ToString());
            }
        }
        public void GetDemobilized()
        {
            Console.WriteLine("Input date (e.g., 2024-12-31):");
            DateTime date = DateTime.Parse(Console.ReadLine());
            foreach (var notSoldier in militaryCards)
            {
                if (date > notSoldier.DateOfDemobilization)
                {
                    Console.WriteLine($"{notSoldier.Name} has demobilize {notSoldier.DateOfDemobilization}");
                }
            }
        }
        public void SaveToFileJson(string path, MilitaryCard[] soldeirs)
        {
            string? directory = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            };
            
            string json = JsonSerializer.Serialize(soldeirs);
            File.WriteAllText(path, json);
        }
        public void LoadFromFileJson(string path)
        {
            if (!File.Exists(path)) throw new Exception("File not found");
            string json = File.ReadAllText(path);
            militaryCards = JsonSerializer.Deserialize<MilitaryCard[]>(json);
        }
        public void SaveToFileXml(string path, MilitaryCard[] soldeirs)
        {
            string? directory = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            };
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(MilitaryCard[]));
            using (StreamWriter writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, soldeirs);
            }
        }
        public void LoadFromFileXml(string path)
        {
            if (!File.Exists(path)) throw new Exception("File not found");
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(MilitaryCard[]));
            using (StreamReader reader = new StreamReader(path))
            {
                militaryCards = (MilitaryCard[])serializer.Deserialize(reader);
            }
        }
    }
}
