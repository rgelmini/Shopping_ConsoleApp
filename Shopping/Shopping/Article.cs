using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping
{
    public enum TypeOfArticle
    {
        Technology,
        Food,
        Sport,
        Neutre,
    }

    [Serializable]
    public class Article
    {
        //Attributs de la classe Article
        public static int numberarticle;
        public int numeroInstance;
        public string name;
        public string description;
        public float price;

        public Seller seller = new Seller("", "", "", 0);

        public TypeOfArticle typeOfArticle = TypeOfArticle.Neutre;

        //Constructeurs
        public Article()
        {
            numberarticle += 1;
            numeroInstance = numberarticle;
        }

        public Article(string _name, string _description, float _price, Seller _seller, TypeOfArticle _typeOfArticle)
        {
            numberarticle += 1;
            numeroInstance = numberarticle;
            this.name = _name;
            this.description = _description;
            this.price = _price;
            this.seller = _seller;
            this.typeOfArticle = _typeOfArticle;

        }

        //Méthode de classe
        public void Decrire()
        {
            Console.WriteLine("Article number: " + numeroInstance);
            Console.WriteLine("Article description: " + this.typeOfArticle);
            Console.WriteLine("Article name: " + this.name);
            Console.WriteLine("Article price: " + this.price);
            Console.WriteLine("Article description: " + this.description);

        }

    }
}
