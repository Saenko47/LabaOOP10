namespace LabaOOP10
{
    internal class Program
    {
        static void Main(string[] args)
        {
           GenSoldier genSoldier = new GenSoldier();
            MilitaryCard[] militaryCards = GenSoldier.GenSoldiers(10);
            MilitaryRegistr militaryRegistr = new MilitaryRegistr(militaryCards);
            Console.WriteLine("Military Cards:");
            
            Console.WriteLine();
            
            militaryRegistr.SaveToFileJson("data/oeo.txt", militaryCards);
            Console.WriteLine("Data saved to file.");
            MilitaryRegistr milReg = new MilitaryRegistr();
            milReg.LoadFromFileJson("data/oeo.txt");
            milReg.ShowAllMilitaryCards();
          

        }
    }
}
