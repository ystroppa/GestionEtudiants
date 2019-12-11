using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestion_etablissement.Models
{
    [Serializable]
public class Etudiant : Personne {
  
    private Filiere fil;
    [NotMapped]   
    private  Dictionary<Service, List<Note>> _Notes = new Dictionary<Service, List<Note>>();
    [NotMapped]
    public Dictionary<Service, List<Note>> Notes {get; set;}

    public void ajoute_filiere(Filiere Fil ) {
        fil=Fil;
        // on l'ajoute directement dans la filière 
        fil.Liste_etudiants.Add(this);
    }

    public void ajouter_note(string intitule, Note n) {
        // on peut verifier au prealable qu'il est bien affecté à une filiere 
        // et ensuite vérifier que la matière fait bien partie de la filiere 
        if (fil==null) 
            throw new Exception_filiere_manquante("Manque l'affectation de la filière à l'étudiant"+ this.nom); 
        //if (!fil.liste_matieres.ContainsKey(matiere))
        //    throw new Exception_matiere_inexistante("Matiere inexistante dans la filiere"+ matiere.intitule + "  " + fil.Designation); 

        // il faut rechercher le service en fonction de l'intitulé utilisé 
        Service service= fil.Liste_services.Find(x => x.descriptif==intitule );
        if (service ==null) {
            Console.WriteLine("L'intitulé de la matière demandé n'existe pas");
            return ;
        }
        if (!_Notes.ContainsKey(service) ) {
            Console.WriteLine("ajouter une nouvelle note");
            List<Note> Lnotes= new List<Note>(); 
            Lnotes.Add(n);
            _Notes.Add(service, Lnotes);
        } else {
            Console.WriteLine("Complete des notes pour une matiere existante");
            _Notes[service].Add(n);
        }
    }
    // on balaye la listes des notes pour effectuer l'affichage 
    public string afficher_notes() {
       string chaine="";
       foreach(Service service in _Notes.Keys) {
            chaine +="Matiere: "+ service.descriptif + " \n" ; 
            chaine +="Notes"+ " \n" ; 
            foreach (Note n in _Notes[service]) {
                chaine +="\t Note"+ n.date + "  " + n.note  +" \n" ; 
            }
        }
        return chaine;
    }
    override
    public string ToString() {
        return this.nom + "" + this.prenom;         
    } 


    public double calculer_moyenne() {
        double moyenne=0.0;
        int somme_coef=0;
        int nb_notes=0;
        float somme=0;
        foreach(Service service in _Notes.Keys) {
            // il faut retrouver la coef de la matière            
            int coef =service.coef;    
            foreach (Note n in _Notes[service]) {        
                somme +=n.note*coef; 
                nb_notes++;
                somme_coef+=coef;
            }
        }
        moyenne=somme/(somme_coef);
        return moyenne;
    }
}

}
