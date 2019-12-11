using System;

using System.Collections.Generic;
using System.Collections.ObjectModel;



namespace gestion_etablissement.Models
{
    public class Exception_matiere_inexistante : Exception
    {
        public Exception_matiere_inexistante(string message) : base(message)
        {
            
        }
    }

}