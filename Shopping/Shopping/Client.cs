using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping
{
    [Serializable]
    public class Client
    {
        //Attributs de la classe Client
        public static int numberClient;
        public int numberclientInstance;
        public string name;
        public string surname;
        public string email;
        public List<Article> listeArticleClient;

        //Constructeurs
        public Client()
        {
            numberClient = numberClient + 1;
            numberclientInstance = numberClient;
            listeArticleClient = new List<Article>();
        }

        public Client(string _nameClient, string _surnameClient, string _emailClient)
        {
            numberClient = numberClient + 1;
            numberclientInstance = numberClient;
            this.name = _nameClient;
            this.surname = _surnameClient;
            this.email = _emailClient;
            listeArticleClient = new List<Article>();
        }
    }
}
