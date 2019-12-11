using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using gestion_etablissement.Models;

namespace gestion_etablissement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Debut du programme");
            
            List<Enseignant>  Liste_enseignants =  new List<Enseignant>();
            Enseignant ens1= new Enseignant {nom="stroppa",prenom="yvan"};
            Enseignant ens2= new Enseignant {nom="wicker",prenom="nicolas"};

            List<Etudiant>  Liste_etudiants =  new List<Etudiant>();
            Etudiant etu1= new Etudiant {nom="Ly",prenom="aphat",date=new DateTime(1965,5,5)};
            Etudiant etu2= new Etudiant {nom="huart",prenom="sebastien",date=new DateTime(1970,5,30)};
            Etudiant etu3= new Etudiant {nom="paulo",prenom="christian",date=new DateTime(1975,1,12)};
            Etudiant etu4= new Etudiant {nom="marco",prenom="polo",date=new DateTime(1980,6,15)};
            Etudiant etu5= new Etudiant {nom="duval",prenom="henri",date=new DateTime(1966,5,25)};

            Liste_etudiants.Add(etu1);
            Liste_etudiants.Add(etu2);
            Liste_etudiants.Add(etu3);
            Liste_etudiants.Add(etu4);
            Liste_etudiants.Add(etu5);


            List<Filiere> Liste_filieres = new List<Filiere>();
            Filiere fil1=new Filiere {Designation="DEV"};
            Filiere fil2=new Filiere {Designation="NETWORK"};
            Liste_filieres.Add(fil1);
            Liste_filieres.Add(fil2);
            
            Matiere mat1=new Matiere {intitule="MATH"};
            Matiere mat2=new Matiere {intitule="INFORMATIQUE"};
            Matiere mat3=new Matiere {intitule="ANGLAIS"};
            Matiere mat4=new Matiere {intitule="RESEAU"};
            
            // affectation des etudiants à la filière 
            etu1.ajoute_filiere(fil1); 
            etu2.ajoute_filiere(fil2); 

            // on  rajoute une seule matière avec un intitulé identique 
            fil1.ajoute_matiere(mat1,10,3,"Mathématiques analyse");
            fil1.ajoute_matiere(mat1,10,3,"Géométrie");
            fil1.ajoute_matiere(mat2,16,3,"Langage Java");
            fil1.ajoute_matiere(mat2,20,5,"Langage C#");
            fil1.ajoute_matiere(mat3,20,6,"Apprentissage langue ");
            
            fil2.ajoute_matiere(mat1,12,2,"Géométrie");
            fil2.ajoute_matiere(mat4,16,3,"Routeur & switchs");
            
            // on doit avoir que 5 services associées à la filière fil1
            Console.WriteLine("Recapitulatif des filières");
            Console.WriteLine(fil1.affiche_service());
            // on doit avoir que 2services associées à la filière fil1
            Console.WriteLine(fil2.affiche_service());
            
            try {
                etu1.ajouter_note("Mathématiques analyse",new Note{note=12.3f, date=new DateTime(2019, 1, 12)});
                etu1.ajouter_note("Géométrie",new Note{note=15.3f, date=new DateTime(2019, 1, 12)});
                etu1.ajouter_note("Langage Java",new Note{note=9.3f, date=new DateTime(2019, 1, 12)});
                etu1.ajouter_note("Langage C#",new Note{note=19.3f, date=new DateTime(2019, 2, 12)});
                etu1.ajouter_note("Mathématiques analyse",new Note{note=12.3f, date=new DateTime(2019, 1, 12)});


            } catch (Exception_filiere_manquante ep ) {
                Console.WriteLine(ep.Message);
            }
            catch (Exception_matiere_inexistante emi) {
                Console.WriteLine(emi.Message);
            }

            Console.WriteLine(etu1.afficher_notes());
            // calculer la moyenne 
            var moy_etu1 = etu1.calculer_moyenne(); 
            Console.WriteLine(moy_etu1);

            try {
                etu2.ajouter_note("Géométrie",new Note{note=12.3f, date=new DateTime(2019, 1, 12)});
                // on essaye de mettre un enote à une matièere qui n'existe pas dans cette filiere 
                //etu2.ajouter_note(mat3,new Note{note=15.3f, date=new DateTime(2019, 1, 12)});
                etu2.ajouter_note("Routeur & switchs",new Note{note=9.3f, date=new DateTime(2019, 1, 12)});
                etu2.ajouter_note("Routeur & switchs",new Note{note=9.3f, date=new DateTime(2019, 2, 12)});
            } catch (Exception_filiere_manquante ep ) {
                Console.WriteLine(ep.Message);
            }
            catch (Exception_matiere_inexistante emi) {
                Console.WriteLine(emi.Message);
            }
            
            Console.WriteLine(etu2.afficher_notes());
            // calculer la moyenne 
            var moy_etu2 = etu2.calculer_moyenne(); 
            
            Console.WriteLine(moy_etu2);


            // queslques exemples d'utilisation de linq 
            var listes_=from s in Liste_etudiants
                        where s.date > new DateTime(1970,2,2)
                        select new {StudentName=s};
                        //select new { StudentName = s.nom };
            listes_.ToList().ForEach(s => Console.WriteLine(s.StudentName.nom));

            var liste_etu=from s in Liste_etudiants
                        where s.calculer_moyenne() > 12
                        select new {StudentName=s};
                        //select new { StudentName = s.nom };

            etu2.ajouter_note("Géométrie",new Note{note=15.3f, date=new DateTime(2019, 2, 12)});

            liste_etu.ToList().ForEach(s => Console.WriteLine(s.StudentName.nom));
            var moy_etu3 = etu2.calculer_moyenne(); 
            
            Console.WriteLine(moy_etu3);

            // is on souhaite recuperer la moyenne des ages des etudiants
            DateTime localDate = DateTime.Now;
            var today = DateTime.Today;
            // Calculate the age.
            
            var max_age=Liste_etudiants.Max(s=>today.Year-s.date.Year);
            var min_age=Liste_etudiants.Min(s=>today.Year-s.date.Year);
            var moy_age=Liste_etudiants.Average(s=>today.Year-s.date.Year);

            
            Console.WriteLine(max_age+ "  " + min_age+ " " + moy_age);


            // enseignant et affectation des services 
            ens1._service_affectation(fil1,"Mathématiques analyse");
            ens1._service_affectation(fil2,"Géométrie");
            ens1._service_affectation(fil2,"Routeur & switchs");
            Console.WriteLine(ens1.calcul_service());

            ens2._service_affectation(fil1,"Langage C#");
            ens2._service_affectation(fil1,"Langage Java");
            ens2._service_affectation(fil1,"Géométrie");
            Console.WriteLine(ens2.calcul_service());

            // sauvegarde des éléments 
            //Utilitaires.Utilitaires.sauve(Liste_filieres);
            
            //List<Filiere> Liste_filieres = (List<Filiere>) Utilitaires.Utilitaires.restaure();
            //foreach(Filiere fil in Liste_filieres){
            //    Console.WriteLine(fil.affiche_service());
            //}
            using (var context = new GestionContext()) {
                context.Filieres.Add(fil1);
                context.Filieres.Add(fil2);
                context.Enseignants.Add(ens1);
                context.Enseignants.Add(ens2);
                context.SaveChanges();
            }
            using (var context = new GestionContext()) {
                var Listetu = context.Etudiants
                    .ToList();
                foreach(Etudiant etu in Listetu) {
                    Console.WriteLine(etu);
                }
            }


        }
    }
}
