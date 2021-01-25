using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping
{
    [Serializable]
    public class Transaction
    {
        public static int numberTransaction;
        public int numTransaction;
        public DateTime timeStamp;
        public Buyer buyer;
        public Seller seller;
        public Article article;
        public float amount;


        public Transaction(Buyer _buyer, Seller _seller, Article _article, float _price)
        {
            numberTransaction = numberTransaction + 1;
            numTransaction = numberTransaction;
            timeStamp = DateTime.Now;
            this.buyer = _buyer;
            this.seller = _seller;
            this.article = _article;
            this.amount = _price;
        }

        public override string ToString()
        {
            return "Transaction n°" + numTransaction + ", entre vendeur: " + seller.name + " et acheteur: " + buyer.name + " (Article: " + article.name + ") pour un montant de " + amount + " euros"; ;
        }
    }
}
