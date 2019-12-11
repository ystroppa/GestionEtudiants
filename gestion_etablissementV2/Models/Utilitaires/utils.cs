using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace gestion_etablissement.Utilitaires
{
public abstract class Utilitaires
    {
        public static Boolean  sauve(Object obj)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("myfile.dat", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, obj);
            stream.Close();
            return true;
        }
        public static object  restaure()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("myfile.dat", FileMode.Open, FileAccess.Read, 
                                            FileShare.Read);
            Object obj = formatter.Deserialize(stream);
            stream.Close();
            return obj;
        }
    }
}
