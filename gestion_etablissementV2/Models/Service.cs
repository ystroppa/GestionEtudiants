using System;
using System.Diagnostics.CodeAnalysis;

namespace gestion_etablissement.Models
{
   [Serializable]
 public class Service: IEquatable<Service>, IComparable<Service> {
    public int id {get; set; }
    public Filiere fil {get; set; }
    public Matiere mat{get; set; }
    public int  coef{get; set; }
    public int nb_h  {get; set; }
    public string descriptif {get; set; }
   public Enseignant affectation {get; set; }
   public int Codeid {get; set; } // identification du service  

   public bool Equals([AllowNull] Service other)
   {
      return (this.mat==other.mat && this.fil==other.fil && this.descriptif==other.descriptif);
   }
   public int CompareTo([AllowNull] Service other)
   {
      //return this.mat.intitule.CompareTo(other.mat.intitule) + 
      //this.fil.Designation.CompareTo(other.fil.Designation) + 
      return this.descriptif.CompareTo(other.descriptif);
   }

   override
   public string ToString() {
         return "Service : " + this.Codeid + "  " + this.descriptif;
   }

   }


}