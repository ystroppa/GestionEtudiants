using System.Collections.Generic;
using System;

namespace gestion_etablissement.Models
{
[Serializable]
    public  class Filiere {
        private static int numero=0;
        public int id {get; set; }
        public string Designation{get; set;}
        public List<Etudiant> Liste_etudiants { get => liste_etudiants; set => liste_etudiants = value; }
        private  List<Etudiant> liste_etudiants= new List<Etudiant>(); 
        private List<Service> _Liste_services = new List<Service>();
         public List<Service> Liste_services { get => _Liste_services; }
        public bool ajoute_matiere(Matiere matiere, int Nb_h, int Coef, string Descipt) {
            Service service= new Service(){mat=matiere, fil=this,descriptif=Descipt};
            if (!_Liste_services.Contains(service)) {
                // on définit un nouveau service par la même occasion avec son code d'identification
                // calculer automatiquement 
                Console.WriteLine("Création du service ");
                _Liste_services.Add(new Service(){Codeid=numero, descriptif=Descipt,  
                mat=matiere, fil=this, coef=Coef, nb_h=Nb_h});
                numero++;
                Console.WriteLine("Numero :" + numero);
            }else {
                // on decide d'écraser le contenu des conditions  
                Console.WriteLine("Service déjà existant: Veuillez faire un update");

            }
            return true;
        }
        public bool update_service(int Num, int Nb_h, int Coef, string Descipt) {
            Console.WriteLine("mise à jour du service");
            Service service= new Service(){Codeid=Num};
            Service service1= _Liste_services.Find(x => x.Codeid==Num);
            service1.coef = Coef;
            service1.nb_h=Nb_h;
            service1.descriptif = Descipt;
            return true;
        }

        public string affiche_service() {
            string retour="Filiere " + this.Designation+ "\n"; 
            foreach(Service serv in _Liste_services) {
                    retour += "\t" + serv.Codeid +":"  +serv.mat.intitule + " -- " + serv.descriptif+"  " + 
                    serv.coef+" ; " + serv.nb_h+ "\n" ;
            }
            return retour;
        }


        // on affecte l matière à un enseignant 
        public bool _service_affectation(Matiere matiere, Enseignant enseignant) {
            // on vérifie si la matière fait bien partie de la filiere 
            
            // si oui 
            // on vérifie qu'elle n'est pas effectée 
            // si ok on l'affecte 
            return true;
        }

        // affihage des services et d eleurs statuts 
        public string _service_affichage() {
            return ""; 
        }
    }

}