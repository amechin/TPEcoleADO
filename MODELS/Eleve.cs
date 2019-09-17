using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingEcoleDotNet.MODELS
{
    public class Eleve
    {

        private int _num;

        public int Num
        {
            get { return _num; }
            set { _num = value; }
        }

        private string _nom;

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        private string _prenom;

        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }

        private DateTime _birthDate;

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        private int _weight;

        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        private int _grade;

        public int Grade
        {
            get { return _grade; }
            set { _grade = value; }
        }

        public Eleve(){}

        public Eleve(int num, string nom, string prenom, DateTime birthDate, int weight, int grade)
        {
            Num = num;
            Nom = nom;
            Prenom = prenom;
            BirthDate = birthDate;
            Weight = weight;
            Grade = grade;
        }

        public override string ToString()
        {
            return ($"Eleve #{this.Num.ToString()}, \nNom :\t{this.Nom} \nPrénom :\t{this.Prenom} \nDate De Naissance :\t{this.BirthDate.ToString("dd/MM/yyyy")} \nPoids :\t {this.Weight.ToString()} \nClasse :\t {this.Grade.ToString()}\n");
        }


    }
}
