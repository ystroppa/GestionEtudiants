using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace gestion_etablissement.Models
{

[Serializable]
public class Enseignant : Personne {
    public string num_emp  {get; set; }
    public float cout_horaires {get; set; }
    // filiere matiere pour le nombre d'heures on ira le chercher dans la filiere  
   
    public List<Service> liste_services = new List<Service>(); 
   public void _service_affectation(Service serv ){
       if (liste_services.Contains(serv)) {
            Console.WriteLine("Service déjà existant ");
       } else {
            liste_services.Add(serv);
       }
   }

    // Affectation du service d'enseignement 
    public void _service_affectation(Filiere fil, string intitule ) {
        Service service= fil.Liste_services.Find(x => x.descriptif==intitule );
        if (service ==null) {
            Console.WriteLine("L'intitulé de la matière demandé n'existe pas");
            return ;
        }
        // on peut verifier si il y a deja une affectation 

        // si il n y en a pas on l'ajoute 
        if (service.affectation == null) {
               service.affectation=this;
               this.liste_services.Add(service);
        }else {
            Console.WriteLine("Service dajà affecté !!!!");
        }

    }
    // supprime un service de l'enseignant 
    public bool service_supprimer(Filiere fil, string intitule) {
        Service service= fil.Liste_services.Find(x => x.descriptif==intitule );
        if (service ==null) {
            Console.WriteLine("L'intitulé de la matière demandé n'existe pas");
            return false;
        }
        // si il n y en a pas on l'ajoute 
        if (service.affectation == null) {
            return false;
        }else {
            service.affectation=null;
            this.liste_services.Remove(service);
        }
        return true;
    }


    /*calcul du service de l'enseignant*/ 
    public string calcul_service(){
        //il suffit de balayer la liste des services affectés
        string chaine="Pour l'enseignant : "+ this.nom + "  " +this.prenom +" \n" ;
        foreach(Service service in liste_services) {
            chaine+= service.fil.Designation+ "  " + service.mat.intitule + "  "+
                    "  " + service.descriptif +"  "  + service.nb_h+ " \n" ;
        }
        return chaine; 
    }


}

}