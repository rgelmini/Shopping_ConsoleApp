using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Shopping
{
    public static class SavingSystem
    {
        //ATTENTION
        //CHEMIN VERS BUREAU SERA DIFFERENT CHEZ VOUS
        public static void SerializeListClients(List<Client> clients)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"D:\Work\Formation IP\ShoppingClientsList.txt", FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, clients);
            stream.Close();
        }
        public static void SerializeListSeller(List<Seller> seller)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"D:\Work\Formation IP\ShoppingSellerList.txt", FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, seller);
            stream.Close();
        }
        public static void SerializeListArticle(List<Article> articles)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"D:\Work\Formation IP\ShoppingArticlesList.txt", FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, articles);
            stream.Close();
        }
        public static void SerializeListTransactions(List<Transaction> transactions)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"D:\Work\Formation IP\ShoppingTransactionsList.txt", FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, transactions);
            stream.Close();
        }
        public static void SerializeSeller(Seller seller)
        {
            string mainLocation = "D:\\Work\\Formation IP\\";
            string extension = "Seller" + seller.name + "_" + seller.surname + ".txt";
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@mainLocation+extension, FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, seller);
            stream.Close();
        }
        public static void SerializeListBuyer(List<Buyer> buyer)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"D:\Work\Formation IP\ShoppingBuyerList.txt", FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, buyer);
            stream.Close();
        }
        public static void SerializeBuyer(Buyer buyer)
        {
            string mainLocation = "D:\\Work\\Formation IP\\";
            string extension = "Buyer" + buyer.name + "_" + buyer.surname + ".txt";
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@mainLocation + extension, FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, buyer);
            stream.Close();
        }
        public static void SerializeArticle(Article article)
        {
            string mainLocation = "D:\\Work\\Formation IP\\";
            string extension = "Article" + article.name + "_" + article.numeroInstance + ".txt";
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@mainLocation + extension, FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, article);
            stream.Close();
        }

        public static List<Client> DeserializeListClient()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"D:\Work\Formation IP\ShoppingClientsList.txt", FileMode.Open, FileAccess.Read); ;

            List<Client> objnew = (List<Client>)formatter.Deserialize(stream);
            stream.Close();
            return objnew;
        }
        public static List<Seller> DeserializeListSeller()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"D:\Work\Formation IP\ShoppingSellerList.txt", FileMode.Open, FileAccess.Read); ;

            List<Seller> objnew = (List<Seller>)formatter.Deserialize(stream);
            stream.Close();
            return objnew;
        }
        public static List<Article> DeserializeListArticles()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"D:\Work\Formation IP\ShoppingArticlesList.txt", FileMode.Open, FileAccess.Read); ;

            List<Article> objnew = (List<Article>)formatter.Deserialize(stream);
            stream.Close();
            return objnew;
        }
        public static List<Transaction> DeserializeListTransactions()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"D:\Work\Formation IP\ShoppingTransactionsList.txt", FileMode.Open, FileAccess.Read); ;

            List<Transaction> objnew = (List<Transaction>)formatter.Deserialize(stream);
            stream.Close();
            return objnew;
        }
        public static Seller DeserializeSeller(string extension)
        {
            string mainLocation = "D:\\Work\\Formation IP\\";
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@mainLocation+extension, FileMode.Open, FileAccess.Read); ;

            Seller objnew = (Seller)formatter.Deserialize(stream);           
            stream.Close();
            return objnew;
        }
        public static Article DeserializeArticle(string extension)
        {
            string mainLocation = "D:\\Work\\Formation IP\\";
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@mainLocation+extension, FileMode.Open, FileAccess.Read); ;

            Article objnew = (Article)formatter.Deserialize(stream);           
            stream.Close();
            return objnew;
        }
        public static List<Buyer> DeserializeListBuyer()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"D:\Work\Formation IP\ShoppingBuyerList.txt", FileMode.Open, FileAccess.Read); ;

            List<Buyer> objnew = (List<Buyer>)formatter.Deserialize(stream);
            stream.Close();
            return objnew;
        }
        public static Buyer DeserializeBuyer(string extension)
        {
            string mainLocation = "D:\\Work\\Formation IP\\";
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@mainLocation + extension, FileMode.Open, FileAccess.Read); ;

            Buyer objnew = (Buyer)formatter.Deserialize(stream);
            stream.Close();
            return objnew;
        }
    }
}
