using System;

using System.Collections.Generic;
using System.Collections.ObjectModel;



namespace gestion_etablissement.Models
{
    public class Exception_filiere_manquante : Exception
    {
        public Exception_filiere_manquante(string message) : base(message)
        {
            
        }
    }

}