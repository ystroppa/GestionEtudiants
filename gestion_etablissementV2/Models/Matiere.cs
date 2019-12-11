using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace gestion_etablissement.Models
{
[Serializable]
public  class Matiere: IComparable<Matiere> {
    public int id {get; set; }
    public string intitule {get; set; }



        public int CompareTo([AllowNull] Matiere other)
        {
           return this.intitule.CompareTo(other.intitule);
        }

    }

}