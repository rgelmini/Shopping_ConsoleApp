using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping
{
    [Serializable]
    public class Admin
    {
        public List<Article> listOfAllArticles;
        public List<Transaction> listOfAllTransactions;
        public List<Seller> listOfAllSellers;
        public List<Buyer> listOfAllBuyers;
        public List<Client> listOfAllClients;


        //Singleton
        public Admin()
        {
            listOfAllArticles = new List<Article>();
            listOfAllTransactions = new List<Transaction>();
            listOfAllSellers = new List<Seller>();
            listOfAllBuyers = new List<Buyer>();
            listOfAllClients = new List<Client>();
    }



        //Connsulter tous les acheteurs
        //Connsulter tous les acheteurs
        //Supprimer profil vendeur
        //Supprimer profil acheteur
        //Consulter liste des transactions
        //Consulter liste des transactions
        //
    }
}
