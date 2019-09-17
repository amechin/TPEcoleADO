using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingEcoleDotNet.DAL;
using TrainingEcoleDotNet.MODELS;

namespace TrainingEcoleDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            int choix;
            List<Eleve> lEleve = new List<Eleve>();

            do
            {
                Console.WriteLine("MENU :");
                Console.WriteLine("1) Display the list of students");
                Console.WriteLine("2) Add a new student");
                Console.WriteLine("3) Update a student's Life");
                Console.WriteLine("4) Exit the program");
                choix = int.Parse(Console.ReadLine());

                switch (choix)
                {
                    case (1):
                        lEleve = EleveDAL.FindAll();
                        foreach (Eleve e in lEleve)
                        {
                            Console.WriteLine(e.ToString());
                        }
                        break;
                    case (2):
                        EleveDAL.Insert();
                        break;
                    case (3):
                        EleveDAL.Update();
                        break;
                    case (4):
                        System.Environment.Exit(1);
                        break;

                        break;
                    default:
                        Console.WriteLine("Invalid answer. Try again");
                        break;
                }
            }
            while (choix >= 1 && choix <= 4);
        }
    }
}
