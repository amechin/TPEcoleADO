using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingEcoleDotNet.MODELS;
using System.Configuration;
using System.Data.SqlClient;

namespace TrainingEcoleDotNet.DAL
{
    public class EleveDAL
    {
        // Méthode permettant d'afficher tous les élèves de la BDD
        //**************************************************************
        public static List<Eleve> FindAll()
        {
            List<Eleve> lEleves = new List<Eleve>();

            BaseDAL db = new BaseDAL("SELECT * FROM ELEVES");
            SqlDataReader Reader = db.Sql.ExecuteReader();

            while (Reader.Read())
            {
            Eleve e = new Eleve((int)Reader["NUM_ELEVE"],
                                (string)Reader["NOM"],
                                (string)Reader["PRENOM"],
                                (DateTime)Reader["DATE_NAISSANCE"],
                                (int)Reader["POIDS"],
                                (int)Reader["ANNEE"]);
            lEleves.Add(e);
            }
            return lEleves;
        }

        // Méthode permettant de supprimer une fiche élève de la BDD
        //**************************************************************
        public static void Delete()
        {
            Console.Write("Wich student's file would you like to delete (enter Id)?:");
            int eleveId = Int32.Parse(Console.ReadLine());

            BaseDAL db = new BaseDAL("DELETE FROM ELEVES WHERE NUM_ELEVE = @idEleve");

            db.Sql.Parameters.Add("@idEleve", System.Data.SqlDbType.Int);
            db.Sql.Parameters["@idEleve"].Value = eleveId;
            db.Sql.ExecuteNonQuery();

            Console.Write("student's file deleted succesfully");
        }

        // Méthode permettant d'insérer dans la BDD une fiche élève
        //**************************************************************
        public static void Insert()
        {
            Console.WriteLine("Please provide the student's information:");
            Console.Write("\t> First name: ");
            string fName = Console.ReadLine();
            Console.Write("\t> Last name: ");
            string lName = Console.ReadLine();
            Console.Write("\t> Birth date (YYYY/MM/DD): ");
            string bdStr = Console.ReadLine();
            DateTime bd;
            while (!DateTime.TryParseExact(bdStr, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.None, out bd))
            {
                Console.WriteLine("Invalid date");
                bdStr = Console.ReadLine();
            }
            Console.Write("\t> Weight: ");
            string weight = Console.ReadLine();
            Console.Write("\t> Grade:");
            string grade = Console.ReadLine();

            BaseDAL db = new BaseDAL("INSERT INTO ELEVES VALUES (@FirstNameE, @LastNameE, @BirthdayE, @WeightE, @GradeE)");
            db.Sql.Parameters.Add("@FirstNameE", System.Data.SqlDbType.NVarChar);
            db.Sql.Parameters["@FirstNameE"].Value = fName;
            db.Sql.Parameters.Add("@LastNameE", System.Data.SqlDbType.NVarChar);
            db.Sql.Parameters["@LastNameE"].Value = lName;
            db.Sql.Parameters.Add("@BirthdayE", System.Data.SqlDbType.DateTime);
            db.Sql.Parameters["@BirthdayE"].Value = bd;
            db.Sql.Parameters.Add("@WeightE", System.Data.SqlDbType.Int);
            db.Sql.Parameters["@WeightE"].Value = weight;
            db.Sql.Parameters.Add("@GradeE", System.Data.SqlDbType.Int);
            db.Sql.Parameters["@GradeE"].Value = grade;
            db.Sql.ExecuteNonQuery();
        }

        // Méthode permettant de mettre à jour une fiche élève
        //**************************************************************
        public static void Update()
        {
            Console.Write("Wich student's file would you like to edit (enter Id)?:");
            int eleveId = Int32.Parse(Console.ReadLine());
            Console.Write("\t> First name: ");
            string fName = Console.ReadLine();
            Console.Write("\t> Last name: ");
            string lName = Console.ReadLine();
            Console.Write("\t> Birth date (YYYY/MM/DD): ");
            string bdStr = Console.ReadLine();
            DateTime bd;
            while (!DateTime.TryParseExact(bdStr, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.None, out bd))
            {
                Console.WriteLine("Invalid date");
                bdStr = Console.ReadLine();
            }
            Console.Write("\t> Weight: ");
            string weight = Console.ReadLine();
            Console.Write("\t> Grade:");
            string grade = Console.ReadLine();

            BaseDAL db = new BaseDAL("UPDATE ELEVES SET PRENOM = @FirstNameE, NOM = @LastNameE, DATE_NAISSANCE = @BirthdayE, POIDS = @WeightE, ANNEE = @GradeE WHERE NUM_ELEVE = @NumE");
            db.Sql.Parameters.Add("@FirstNameE", System.Data.SqlDbType.NVarChar);
            db.Sql.Parameters["@FirstNameE"].Value = fName;
            db.Sql.Parameters.Add("@LastNameE", System.Data.SqlDbType.NVarChar);
            db.Sql.Parameters["@LastNameE"].Value = lName;
            db.Sql.Parameters.Add("@BirthdayE", System.Data.SqlDbType.DateTime);
            db.Sql.Parameters["@BirthdayE"].Value = bd;
            db.Sql.Parameters.Add("@WeightE", System.Data.SqlDbType.Int);
            db.Sql.Parameters["@WeightE"].Value = weight;
            db.Sql.Parameters.Add("@GradeE", System.Data.SqlDbType.Int);
            db.Sql.Parameters["@GradeE"].Value = grade;
            db.Sql.Parameters.Add("@numE", System.Data.SqlDbType.Int);
            db.Sql.Parameters["@numE"].Value = eleveId;
            db.Sql.ExecuteNonQuery();
        }
    }
}
