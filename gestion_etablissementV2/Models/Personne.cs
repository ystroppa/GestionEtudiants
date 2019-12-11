using System;


namespace gestion_etablissement.Models
{
    [Serializable]
public class Personne {
    public int id {get; set; }
    public string nom {get; set; }
    public string prenom {get; set; }
    public string email {get; set; }
    public string sexe {get; set; }
    public DateTime date {get; set; }



}
}