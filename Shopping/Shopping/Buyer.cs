using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping
{
    [Serializable]
    public class Buyer : Client
    {

        //Attributs
        public float solde;

        public Buyer()
        {

        }

        public Buyer(string _nameClient, string _surnameClient, string _emailClient, float _solde)
            : base(_nameClient, _surnameClient, _emailClient)
        {
            this.solde = _solde;
        }
    }
}
