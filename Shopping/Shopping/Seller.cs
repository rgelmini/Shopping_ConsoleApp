using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping
{
    [Serializable]
    public class Seller : Client
    {
        //attributs spécifiques de la classe dérivée Seller
        public float credit;

        public Seller()
        {

        }


        public Seller(string _nameClient, string _surnameClient, string _emailClient, float _credit)
        : base(_nameClient,_surnameClient, _emailClient)
        {
            this.credit = _credit;
        }

        //méthodes spécifiques de la classe dérivée seller
        public void AjouterArticle(Article article)
        {
            this.listeArticleClient.Add(article);
        }
    }
}
