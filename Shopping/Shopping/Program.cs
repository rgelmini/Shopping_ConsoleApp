using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Preparation
            Admin Admin = new Admin();
            Admin.listOfAllBuyers = new List<Buyer>();
            Admin.listOfAllSellers = new List<Seller>();
            Admin.listOfAllClients = new List<Client>();
            Admin.listOfAllTransactions = new List<Transaction>();
            Admin.listOfAllArticles = new List<Article>();

            Console.WriteLine("Bienvenu(e) dans votre application de vente en ligne");
            Console.WriteLine("Souhaitez-vous 1) Remettre l'application à zéro ou 2) Charger les données existantes ?");
            int choixUtilisateur = int.Parse(Console.ReadLine());
            switch (choixUtilisateur)
            {
                case 1:
                    Admin = Reset();
                    break;
                case 2:
                    Admin = Continue();
                    break;
                default:
                    break;
            }
            Start(Admin);
            Console.Read();
        }
        public static Admin Start(Admin Admin) {
            //Def Menu de l'app
            Console.WriteLine("**************************************************************");
            Console.WriteLine("Voulez-vous vous connecter comme 1) vendeur ou 2) acheteur?");
            Console.WriteLine("Tapez 1 pour vendeur et 2 pour acheteur");
            Console.WriteLine("Tapez le mdp pour vous enregistrer comme Administrateur");
            Console.WriteLine("Tapez 0 pour quitter l'application");
            int answer = int.Parse(Console.ReadLine());

            switch (answer)
            {
                case 1:
                    SellerSession(Admin);
                    break;
                case 2:
                    BuyerSession(Admin);
                    break;
                case 3:
                    AdminSession(Admin);
                    break;
                case 0:
                    SavingSystem.SerializeListArticle(Admin.listOfAllArticles);
                    SavingSystem.SerializeListBuyer(Admin.listOfAllBuyers);
                    SavingSystem.SerializeListSeller(Admin.listOfAllSellers);
                    SavingSystem.SerializeListClients(Admin.listOfAllClients);
                    SavingSystem.SerializeListTransactions(Admin.listOfAllTransactions);
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Choix invalide, veuillez entrer 1 ou 2 ou mdp ou 0 pour quitter");
                    break;
            }
            return Admin;

        }
        public static Admin Reset()
        {
            Admin Admin = new Admin();

            Seller seller1 = new Seller("X", "Jean", "jeanX@gmail.com", 500f);
            Seller seller2 = new Seller("Y", "Jacques", "jacquesY@yahoo.com", 500f);
            Seller seller3 = new Seller("Z", "Marie", "marieZ@outlook.com", 500f);
            Admin.listOfAllSellers.Add(seller1);
            Admin.listOfAllSellers.Add(seller2);
            Admin.listOfAllSellers.Add(seller3);

            //Construction des articles
            Article article1 = new Article("Phone", "Samsung", 199, seller1, TypeOfArticle.Technology);
            Article article2 = new Article("Banana", "Fresh", 2, seller1, TypeOfArticle.Food);
            Article article3 = new Article("Computer", "Dell", 599, seller1, TypeOfArticle.Technology);
            Article article4 = new Article("Sneakers", "Nike", 99, seller2, TypeOfArticle.Sport);
            Article article5 = new Article("Glass", "Water", 1, seller2, TypeOfArticle.Food);
            Article article6 = new Article("Screen", "Samsung", 199, seller2, TypeOfArticle.Technology);
            Article article7 = new Article("Apple", "Fresh", 2, seller3, TypeOfArticle.Food);
            Article article8 = new Article("NotePad", "Samsung", 250, seller3, TypeOfArticle.Technology);
            Article article9 = new Article("Weights", "Decathlon", 99, seller3, TypeOfArticle.Sport);
            Admin.listOfAllArticles.Add(article1);
            Admin.listOfAllArticles.Add(article2);
            Admin.listOfAllArticles.Add(article3);
            Admin.listOfAllArticles.Add(article4);
            Admin.listOfAllArticles.Add(article5);
            Admin.listOfAllArticles.Add(article6);
            Admin.listOfAllArticles.Add(article7);
            Admin.listOfAllArticles.Add(article8);
            Admin.listOfAllArticles.Add(article9);


            //Ajouts des articles aux différents vendeurs dans leur liste d'articles
            seller1.AjouterArticle(article1);
            seller1.AjouterArticle(article2);
            seller1.AjouterArticle(article3);

            seller2.AjouterArticle(article4);
            seller2.AjouterArticle(article5);
            seller2.AjouterArticle(article6);

            seller3.AjouterArticle(article7);
            seller3.AjouterArticle(article8);
            seller3.AjouterArticle(article9);

            //création acheteur
            Buyer buyer1 = new Buyer("A", "Robert", "robertA@gmail.com", 500f);
            Buyer buyer2 = new Buyer("B", "Anthony", "anthB@yahoo.com", 500f);
            Buyer buyer3 = new Buyer("C", "Julie", "juC@outlook.com", 500f);
            Admin.listOfAllBuyers.Add(buyer1);
            Admin.listOfAllBuyers.Add(buyer2);
            Admin.listOfAllBuyers.Add(buyer3);

            Admin.listOfAllClients.Add(seller1);
            Admin.listOfAllClients.Add(seller2);
            Admin.listOfAllClients.Add(seller3);
            Admin.listOfAllClients.Add(buyer1);
            Admin.listOfAllClients.Add(buyer2);
            Admin.listOfAllClients.Add(buyer3);

            SavingSystem.SerializeListSeller(Admin.listOfAllSellers);
            for (int i = 0; i < Admin.listOfAllSellers.Count; i++)
            {
                SavingSystem.SerializeSeller(Admin.listOfAllSellers[i]);
            }

            SavingSystem.SerializeListBuyer(Admin.listOfAllBuyers);
            for (int i = 0; i < Admin.listOfAllBuyers.Count; i++)
            {
                SavingSystem.SerializeBuyer(Admin.listOfAllBuyers[i]);
            }

            SavingSystem.SerializeListClients(Admin.listOfAllClients);

            return Admin;
        }
        public static Admin Continue()
        {
            Admin admin = new Admin();
            admin.listOfAllBuyers = SavingSystem.DeserializeListBuyer();
            admin.listOfAllSellers = SavingSystem.DeserializeListSeller();
            admin.listOfAllClients = SavingSystem.DeserializeListClient();
            admin.listOfAllTransactions = SavingSystem.DeserializeListTransactions();
            admin.listOfAllArticles = SavingSystem.DeserializeListArticles();
            return admin;
        }
        //Main sessions
        public static void SellerSession(Admin admin)
        {
            //Identification du vendeur
            Console.WriteLine("1-Créer un profil Vendeur");
            Console.WriteLine("2-Se connecter à un profil Vendeur");
            Console.WriteLine("3-Modifier un profil Vendeur");
            Console.WriteLine("4-Retour au Menu principal");

            int choix = int.Parse(Console.ReadLine());
            switch (choix)
            {
                case 1:
                    CreateSellerProfile(admin);
                    break;
                case 2:
                    ConnectToSellerProfile(admin);
                    break;
                case 3:
                    ModifySellerProfile(admin);
                    break;
                case 4:
                    Start(admin);
                    break;
                default:
                    Console.WriteLine("Choix invalide, veuillez entrer 1 ou 2 ou 3 ou 4");
                    break;
            }
        }
        public static void BuyerSession(Admin admin)
        {
            //Identification acheteur
            Console.WriteLine("1-Créer un profil Acheteur");
            Console.WriteLine("2-Se connecter à un profil Acheteur");
            Console.WriteLine("3-Modifier un profil Acheteur");
            Console.WriteLine("4-Se connecter comme invité");
            Console.WriteLine("5-Retour au Menu principal");


            int choix = int.Parse(Console.ReadLine());
            switch (choix)
            {
                case 1:
                    CreateBuyerProfile(admin);
                    break;
                case 2:
                    ConnectToBuyerProfile(admin);
                    break;
                case 3:
                    ModifyBuyerProfile(admin);
                    break;
                case 4:
                    ConnectAsGuest(admin);
                    break;
                case 5:
                    Start(admin);
                    break;
                default:
                    Console.WriteLine("Choix invalide, veuillez entrer 1 ou 2 ou 3 ou 4 ou 5");
                    break;
            }

        }
        public static void AdminSession(Admin admin)
        {
            //Identification acheteur
            Console.WriteLine("1-Consulter liste de tous les Acheteurs");
            Console.WriteLine("2-Consulter liste de tous les Vendeurs");
            Console.WriteLine("3-Consulter liste de tous les Articles");
            Console.WriteLine("4-Consulter liste de tous les Transactions");
            Console.WriteLine("5-Retour Menu principal");

            int choix = int.Parse(Console.ReadLine());
            switch (choix)
            {
                case 1:
                    FindAllBuyers(admin);
                    break;
                case 2:
                    FindAllSellers(admin);
                    break;
                case 3:
                    FindAllArticles(admin);
                    break;
                case 4:
                    FindAllTransactions(admin);
                    break;
                case 5:
                    Start(admin);
                    break;
                default:
                    Console.WriteLine("Choix invalide, veuillez entrer 1 ou 2 ou 3 ou 4 ou 5");
                    break;
            }
        }
        //Hub functions for each type of session for launching actions
        public static void LaunchSellerSession(Admin admin, int seller)
        {
            Seller activeSeller = new Seller();

            for (int i = 0; i < admin.listOfAllSellers.Count; i++)
            {
                if (admin.listOfAllSellers[i].numberclientInstance == seller)
                {
                    activeSeller = admin.listOfAllSellers[i];
                }
            }
            //Menu Vendeur
            Console.WriteLine("Session ouverte pour : ");
            Console.WriteLine(activeSeller.name);
            Console.WriteLine(activeSeller.surname);
            Console.WriteLine("N° Client: " + activeSeller.numberclientInstance);
            Console.WriteLine("*************************************************");
            Console.WriteLine("Menu:");
            Console.WriteLine("1-Rechercher un article par numéro de référence");
            Console.WriteLine("2-Ajouter un article");
            Console.WriteLine("3-Supprimer un article");
            Console.WriteLine("4-Modifier un article");
            Console.WriteLine("5-Afficher tous les articles");
            Console.WriteLine("6-Retour au Menu principal");

            string choixMenuUtilisateur = Console.ReadLine();
            int choixMenu = int.Parse(choixMenuUtilisateur);
            //SWITCH CASE
            switch (choixMenu)
            {
                case 1:
                    FindArticleByReference(admin, activeSeller);
                    break;
                case 2:
                    AddArticle(admin, activeSeller);
                    break;
                case 3:
                    DeleteArticle_Seller(admin, activeSeller);
                    break;
                case 4:
                    ModifyArticle(admin, activeSeller);
                    break;
                case 5:
                    DisplayAllArticles(admin, activeSeller);
                    break;
                case 6:
                    Start(admin);
                    break;
                default:
                    Console.WriteLine("Aucun choix offert par le menu sélectionné");
                    break;
            }
        }
        public static void LaunchBuyerSession(Admin admin, int buyer)
        {
            Buyer activeBuyer = new Buyer();

            for (int i = 0; i < admin.listOfAllBuyers.Count; i++)
            {
                if (admin.listOfAllBuyers[i].numberclientInstance == buyer)
                {
                    activeBuyer = admin.listOfAllBuyers[i];
                }
            }
            //Menu Vendeur
            Console.WriteLine("Session open for Buyer: ");
            Console.WriteLine(activeBuyer.name);
            Console.WriteLine(activeBuyer.surname);
            Console.WriteLine("N° Client: " + activeBuyer.numberclientInstance);
            Console.WriteLine("*************************************************");
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Consulter la liste de tous les articles du site");
            Console.WriteLine("2. Rechercher article par catégorie");
            Console.WriteLine("3. Acheter article d'un vendeur");
            Console.WriteLine("4. Retourner un article et le supprimer de la liste Acheteur");
            Console.WriteLine("5. Retourner au Menu principal");

            int choix = int.Parse(Console.ReadLine());

            switch (choix)
            {
                case 1:
                    ConsultListAllArticles(admin, activeBuyer);
                    break;
                case 2:
                    FindArticleByCategory(admin, activeBuyer);
                    break;
                case 3:
                    BuyArticle(admin, activeBuyer);
                    break;
                case 4:
                    DeleteArticle_Buyer(admin, activeBuyer);
                    break;
                case 5:
                    Start(admin);
                    break;
                default:
                    break;
            }
        }
        //Fonctions relatives au profil Vendeur
        public static int CreateSellerProfile(Admin admin)
        {
            //Création profile menu
            Console.WriteLine("Bienvenu(e) dans le formulaire d'enregistrement Vendeur");
            Console.WriteLine("Voulez-vous indiquer:");
            Console.WriteLine("Votre nom:");
            string name = Console.ReadLine();
            Console.WriteLine("Votre prénom:");
            string surname = Console.ReadLine();
            Console.WriteLine("Votre email");
            string email = Console.ReadLine();
            Console.WriteLine("Votre crédit:");
            float credit = int.Parse(Console.ReadLine());
            Seller newSeller = new Seller(name, surname, email, credit);
            SavingSystem.SerializeSeller(newSeller);
            admin.listOfAllClients.Add(newSeller);
            admin.listOfAllSellers.Add(newSeller);
            SavingSystem.SerializeListSeller(admin.listOfAllSellers);
            SavingSystem.SerializeListClients(admin.listOfAllClients);
            int numRefSeller = newSeller.numberclientInstance;
            Console.WriteLine("Merci pour votre inscription");
            Console.WriteLine("Souhaitez-vous: 1) Vérifier vos données 2) Lancer la session ?");
            Console.WriteLine("Tapez 1 pour Vérifier vos données ou 2 pour Lancer la session ?");
            int choix = int.Parse(Console.ReadLine());
            switch (choix)
            {
                case 1:
                    string extension = "Seller" + newSeller.name + "_" + newSeller.surname + ".txt";
                    Seller seller = SavingSystem.DeserializeSeller(extension);
                    Console.WriteLine("Nom: " + seller.name);
                    Console.WriteLine("Prénom: " + seller.surname);
                    Console.WriteLine("Email: " + seller.email);
                    Console.WriteLine("Crédit: " + seller.credit);
                    Console.WriteLine("Lancement de la session");
                    LaunchSellerSession(admin, numRefSeller);
                    break;
                case 2:
                    LaunchSellerSession(admin, numRefSeller);
                    break;
                default:
                    break;
            }

            return numRefSeller;

        }
        public static int ConnectToSellerProfile(Admin admin)
        {
            //Récupérer profile existant
            Console.WriteLine("Bienvenu(e)");
            Console.WriteLine("Voulez-vous indiquer:");
            Console.WriteLine("Votre nom:");
            string name = Console.ReadLine();
            Console.WriteLine("Votre prénom:");
            string surname = Console.ReadLine();

            string extension = "Seller" + name + "_" + surname + ".txt";
            Seller seller = SavingSystem.DeserializeSeller(extension);
            Console.WriteLine("Nom: " + seller.name);
            Console.WriteLine("Prénom: " + seller.surname);
            Console.WriteLine("Email: " + seller.email);
            Console.WriteLine("Crédit: " + seller.credit);
            int numRefSeller = seller.numberclientInstance;

            Console.WriteLine("*************************************");
            Console.WriteLine("Vous êtes bien enregistré!");
            Console.WriteLine("Lancement de la session");
            LaunchSellerSession(admin, numRefSeller);
            return numRefSeller;
        }
        public static int ModifySellerProfile(Admin admin)
        {
            //Création profile menu
            Console.WriteLine("Bienvenu(e) dans le formulaire de modification du profil Vendeur");
            Console.WriteLine("Voulez-vous indiquer:");
            Console.WriteLine("Votre nom:");
            string name = Console.ReadLine();
            Console.WriteLine("Votre prénom:");
            string surname = Console.ReadLine();
            string extension = "Seller" + name + "_" + surname + ".txt";
            Seller sellerToModify = SavingSystem.DeserializeSeller(extension);

            Console.WriteLine("Quel renseignement souhaitez-vous modifier?");
            Console.WriteLine("1-Nom, 2-Prénom, 3-Email, 4-Crédit ?");
            Console.WriteLine("Votre nom:");
            int choixModif = int.Parse(Console.ReadLine());
            switch (choixModif)
            {
                case 1:
                    Console.WriteLine("Veuillez entrer le nouveau nom:");
                    string newName = Console.ReadLine();
                    sellerToModify.name = newName;
                    SavingSystem.SerializeSeller(sellerToModify);
                    break;
                case 2:
                    Console.WriteLine("Veuillez entrer le nouveau prénom:");
                    string newSurname = Console.ReadLine();
                    sellerToModify.surname = newSurname;
                    SavingSystem.SerializeSeller(sellerToModify);
                    break;
                case 3:
                    Console.WriteLine("Veuillez entrer le nouvel email:");
                    string newEmail = Console.ReadLine();
                    sellerToModify.email = newEmail;
                    SavingSystem.SerializeSeller(sellerToModify);
                    break;
                case 4:
                    Console.WriteLine("Veuillez entrer le nouveau crédit:");
                    float newCredit = float.Parse(Console.ReadLine());
                    sellerToModify.credit = newCredit;
                    SavingSystem.SerializeSeller(sellerToModify);
                    break;
                default:
                    break;
            }

            admin.listOfAllClients.Add(sellerToModify);
            admin.listOfAllSellers.Add(sellerToModify);
            SavingSystem.SerializeListSeller(admin.listOfAllSellers);
            SavingSystem.SerializeListClients(admin.listOfAllClients);

            int numRefSeller = sellerToModify.numberclientInstance;

            Console.WriteLine("Merci pour votre inscription");
            Console.WriteLine("Souhaitez-vous: 1) Vérifier vos données 2) Lancer la session ?");
            Console.WriteLine("Tapez 1 pour Vérifier vos données ou 2 pour Lancer la session ?");
            int choix = int.Parse(Console.ReadLine());
            switch (choix)
            {
                case 1:
                    string extensionForDeserialization = "Seller" + sellerToModify.name + "_" + sellerToModify.surname + ".txt";
                    Seller seller = SavingSystem.DeserializeSeller(extension);
                    Console.WriteLine("Nom: " + seller.name);
                    Console.WriteLine("Prénom: " + seller.surname);
                    Console.WriteLine("Email: " + seller.email);
                    Console.WriteLine("Crédit: " + seller.credit);
                    Console.WriteLine("Lancement de la session");
                    LaunchSellerSession(admin, numRefSeller);
                    break;
                case 2:
                    LaunchSellerSession(admin, numRefSeller);
                    break;
                default:
                    break;
            }
            return numRefSeller;
        }
        //Fonctions relatives au profil Acheteur
        public static void CreateBuyerProfile(Admin admin)
        {
            //Création profile menu
            Console.WriteLine("Bienvenu(e) dans le formulaire d'enregistrement Vendeur");
            Console.WriteLine("Voulez-vous indiquer:");
            Console.WriteLine("Votre nom:");
            string name = Console.ReadLine();
            Console.WriteLine("Votre prénom:");
            string surname = Console.ReadLine();
            Console.WriteLine("Votre email");
            string email = Console.ReadLine();
            Console.WriteLine("Votre crédit:");
            float solde = int.Parse(Console.ReadLine());
            Buyer newBuyer = new Buyer(name, surname, email, solde);
            admin.listOfAllBuyers.Add(newBuyer);
            admin.listOfAllClients.Add(newBuyer);
            SavingSystem.SerializeBuyer(newBuyer);
            SavingSystem.SerializeListBuyer(admin.listOfAllBuyers);
            Console.WriteLine("Merci pour votre inscription");
            Console.WriteLine("Souhaitez-vous: 1) Vérifier vos données 2) Lancer la session ?");
            Console.WriteLine("Tapez 1 pour Vérifier vos données ou 2 pour Lancer la session ?");
            int choix = int.Parse(Console.ReadLine());
            switch (choix)
            {
                case 1:
                    string extension = "Buyer" + newBuyer.name + "_" + newBuyer.surname + ".txt";
                    Buyer buyer = SavingSystem.DeserializeBuyer(extension);
                    Console.WriteLine("Nom: " + buyer.name);
                    Console.WriteLine("Prénom: " + buyer.surname);
                    Console.WriteLine("Email: " + buyer.email);
                    Console.WriteLine("Crédit: " + buyer.solde);
                    break;
                case 2:
                    LaunchBuyerSession(admin, newBuyer.numberclientInstance);
                    break;
                default:
                    break;
            }


        }
        public static void ConnectToBuyerProfile(Admin admin)
        {
            //Récupérer profile existant
            Console.WriteLine("Bienvenu(e)");
            Console.WriteLine("Voulez-vous indiquer:");
            Console.WriteLine("Votre nom:");
            string name = Console.ReadLine();
            Console.WriteLine("Votre prénom:");
            string surname = Console.ReadLine();

            string extension = "Buyer" + name + "_" + surname + ".txt";
            Buyer buyer = SavingSystem.DeserializeBuyer(extension);
            LaunchBuyerSession(admin, buyer.numberclientInstance);
        }
        public static void ModifyBuyerProfile(Admin admin)
        {
            //Création profile menu
            Console.WriteLine("Bienvenu(e) dans le formulaire de modification du profil Acheteur");
            Console.WriteLine("Voulez-vous indiquer:");
            Console.WriteLine("Votre nom:");
            string name = Console.ReadLine();
            Console.WriteLine("Votre prénom:");
            string surname = Console.ReadLine();
            string extension = "Buyer" + name + "_" + surname + ".txt";
            Buyer buyerToModify = SavingSystem.DeserializeBuyer(extension);

            Console.WriteLine("Quel renseignement souhaitez-vous modifier?");
            Console.WriteLine("1-Nom, 2-Prénom, 3-Email, 4-Solde ?");
            Console.WriteLine("Votre nom:");
            int choixModif = int.Parse(Console.ReadLine());
            switch (choixModif)
            {
                case 1:
                    Console.WriteLine("Veuillez entrer le nouveau nom:");
                    string newName = Console.ReadLine();
                    buyerToModify.name = newName;
                    SavingSystem.SerializeBuyer(buyerToModify);
                    break;
                case 2:
                    Console.WriteLine("Veuillez entrer le nouveau prénom:");
                    string newSurname = Console.ReadLine();
                    buyerToModify.surname = newSurname;
                    SavingSystem.SerializeBuyer(buyerToModify);
                    break;
                case 3:
                    Console.WriteLine("Veuillez entrer le nouvel email:");
                    string newEmail = Console.ReadLine();
                    buyerToModify.email = newEmail;
                    SavingSystem.SerializeBuyer(buyerToModify);
                    break;
                case 4:
                    Console.WriteLine("Veuillez entrer le nouveau crédit:");
                    float newSolde = float.Parse(Console.ReadLine());
                    buyerToModify.solde = newSolde;
                    SavingSystem.SerializeBuyer(buyerToModify);
                    break;
                default:
                    break;
            }


            Console.WriteLine("Merci pour ces nouvelles informations.");
            Console.WriteLine("Souhaitez-vous: 1) Vérifier vos données 2) Lancer la session ?");
            Console.WriteLine("Tapez 1 pour Vérifier vos données ou 2 pour Lancer la session ?");
            int choix = int.Parse(Console.ReadLine());
            switch (choix)
            {
                case 1:
                    string extensionForDeserialization = "Buyer" + buyerToModify.name + "_" + buyerToModify.surname + ".txt";
                    Buyer buyer = SavingSystem.DeserializeBuyer(extension);
                    Console.WriteLine("Nom: " + buyer.name);
                    Console.WriteLine("Prénom: " + buyer.surname);
                    Console.WriteLine("Email: " + buyer.email);
                    Console.WriteLine("Crédit: " + buyer.solde);
                    break;
                case 2:
                    LaunchBuyerSession(admin, buyerToModify.numberclientInstance);
                    break;
                default:
                    break;
            }
        }
        public static void ConnectAsGuest(Admin admin)
        {
            LaunchBuyerSession(admin, -1);
        }
        //Fonctions relatives aux actions Vendeur
        public static void FindArticleByReference(Admin admin, Seller seller)
        {
            int numRefUser;
            Console.WriteLine("Numéro de référence: ");
            numRefUser = int.Parse(Console.ReadLine());
            for (int i = 0; i < admin.listOfAllArticles.Count; i++)
            {
                if (numRefUser == admin.listOfAllArticles[i].numeroInstance)
                {
                    admin.listOfAllArticles[i].Decrire();
                }
            }
            Console.WriteLine("Retourner au menu principal vendeur");
            LaunchSellerSession(admin, seller.numberclientInstance);

        }
        public static void AddArticle(Admin admin, Seller seller)
        {
            Console.WriteLine("**************AJOUT ARTICLE****************************");
            Console.WriteLine("Nom de l'article à ajouter");
            string nomItem = Console.ReadLine();
            Console.WriteLine("Description de l'article à ajouter");
            string descriptionItem = Console.ReadLine();
            Console.WriteLine("Prix de l'article à ajouter");
            float prix = float.Parse(Console.ReadLine());
            Console.WriteLine("Type de l'article à ajouter : 1-Technology, 2 - Food, 3 - Sport, 4 - Neutre");
            TypeOfArticle typeOfArticle = TypeOfArticle.Neutre;
            int answer = int.Parse(Console.ReadLine());
            switch (answer)
            {
                case 1:
                    typeOfArticle = TypeOfArticle.Technology;
                    break;
                case 2:
                    typeOfArticle = TypeOfArticle.Food;
                    break;
                case 3:
                    typeOfArticle = TypeOfArticle.Sport;
                    break;
                case 4:
                    typeOfArticle = TypeOfArticle.Neutre;
                    break;
                default:
                    break;
            }

            Article article = new Article(nomItem, descriptionItem, prix, seller, typeOfArticle);
            seller.AjouterArticle(article);
            admin.listOfAllArticles.Add(article);
            SavingSystem.SerializeSeller(seller);
            Console.WriteLine("Article ajouté!!");
            Seller deserSeller = SavingSystem.DeserializeSeller("Seller" + seller.name + "_" + seller.surname + ".txt");
            for (int i = 0; i < deserSeller.listeArticleClient.Count; i++)
            {
                deserSeller.listeArticleClient[i].Decrire();
            }
            Console.WriteLine("*************RETOUR SESSION****************************");
            LaunchSellerSession(admin, seller.numberclientInstance);
        }
        public static void DeleteArticle_Seller(Admin admin, Seller seller)
        {
            Console.WriteLine("**************SUPPRESSION ARTICLE****************************");
            Console.WriteLine("N° de Référence de l'article à supprimer");
            int numArticle = (int.Parse(Console.ReadLine()));

            for (int i = 0; i <seller.listeArticleClient.Count; i++)
            {
                if (seller.listeArticleClient[i].numeroInstance == numArticle)
                {
                    string nomItem = seller.listeArticleClient[i].name;
                    seller.listeArticleClient.Remove(seller.listeArticleClient[i]);
                    Console.WriteLine(nomItem + " a été supprimé de votre liste d'articles");
                    SavingSystem.SerializeSeller(seller);
                }
                if (admin.listOfAllArticles[i].numeroInstance == numArticle)
                {
                    admin.listOfAllArticles.Remove(admin.listOfAllArticles[i]);
                }
            }
            for (int i = 0; i < seller.listeArticleClient.Count; i++)
            {
                string nomItem = seller.listeArticleClient[i].name;
                Console.WriteLine(nomItem + " dans votre liste d'articles");

            }
            Console.WriteLine("*************RETOUR SESSION****************************");
            LaunchSellerSession(admin, seller.numberclientInstance);

        }
        public static void ModifyArticle(Admin admin, Seller seller)
        {
            Console.WriteLine("N° de Référence de l'article à modifier");
            int numArticle = int.Parse(Console.ReadLine());
            for (int i = 0; i < seller.listeArticleClient.Count; i++)
            {
                if (seller.listeArticleClient[i].numeroInstance == numArticle)
                {
                    int choixModif;
                    Console.WriteLine("***************Modifications**************");
                    Console.WriteLine("1-Modifier le nom");
                    Console.WriteLine("2-Modifier le description");
                    Console.WriteLine("3-Modifier le prix");
                    Console.WriteLine("Choix: ");
                    choixModif = int.Parse(Console.ReadLine());

                    switch (choixModif)
                    {
                        case 1:
                            Console.WriteLine("Nouveau nom de l'article: ");
                            seller.listeArticleClient[i].name = Console.ReadLine();
                            Console.WriteLine("Article avec numéro de référence " + seller.listeArticleClient[i].numeroInstance + " : nom modifié avec succès");
                            break;
                        case 2:
                            Console.WriteLine("Nouvelle description de l'article");
                            seller.listeArticleClient[i].description = Console.ReadLine();
                            Console.WriteLine("Article avec numéro de référence " + seller.listeArticleClient[i].numeroInstance + " : description modifiée avec succès");
                            break;
                        case 3:
                            Console.WriteLine("Nouveau prix de l'article");
                            seller.listeArticleClient[i].price = int.Parse(Console.ReadLine());
                            Console.WriteLine("Article avec numéro de référence " + seller.listeArticleClient[i].numeroInstance + " : prix modifié avec succès");
                            break;
                        default:
                            Console.WriteLine("Choix invalide");
                            break;
                    }

                    Console.WriteLine("************************************");
                    Console.WriteLine("Nouvelles informatons sur l'article");
                    seller.listeArticleClient[i].Decrire();
                }
            }
            SavingSystem.SerializeSeller(seller);
            Console.WriteLine("*************RETOUR SESSION****************************");
            LaunchSellerSession(admin, seller.numberclientInstance);
        }
        public static void DisplayAllArticles(Admin admin, Seller seller)
        {
            foreach (var item in seller.listeArticleClient)
            {
                item.Decrire();
                Console.WriteLine("*****************************************");
            }
            foreach (var item in admin.listOfAllArticles)
            {
                item.Decrire();
                Console.WriteLine("*****************************************");
            }
            LaunchSellerSession(admin, seller.numberclientInstance);
        }
        //Fonctions relatives aux actions Acheteur
        public static void ConsultListAllArticles(Admin admin, Buyer buyer)
        {
            for (int i = 0; i < admin.listOfAllArticles.Count; i++)
            {
                    admin.listOfAllArticles[i].Decrire();               
            }
            Console.WriteLine("Retour à la session");
            LaunchBuyerSession(admin, buyer.numberclientInstance);
        }
        public static void FindArticleByCategory(Admin admin, Buyer buyer)
        {
            //Demander à l'acheteur quelle catégorie d'articles il souhaite afficher 
            Console.WriteLine("Quelle catégorie d'articles souhaitez vous afficher");
            Console.WriteLine("Tapez 1 pour Technologie");
            Console.WriteLine("Tapez 2 pour Food");
            Console.WriteLine("Tapez 3 pour Sport");

            //Récupérer sa réponse
            int reponseCategorieArticles = int.Parse(Console.ReadLine());
            for (int i = 0; i < admin.listOfAllArticles.Count; i++)
            {
                if (reponseCategorieArticles == 1 && admin.listOfAllArticles[i].typeOfArticle == TypeOfArticle.Technology)
                {
                    admin.listOfAllArticles[i].Decrire();
                }
                if (reponseCategorieArticles == 2 && admin.listOfAllArticles[i].typeOfArticle == TypeOfArticle.Food)
                {
                    admin.listOfAllArticles[i].Decrire();
                }
                if (reponseCategorieArticles == 3 && admin.listOfAllArticles[i].typeOfArticle == TypeOfArticle.Sport)
                {
                    admin.listOfAllArticles[i].Decrire();
                }
            }
            Console.WriteLine("Retour à la session");
            LaunchBuyerSession(admin, buyer.numberclientInstance);
        }
        public static void BuyArticle(Admin admin, Buyer buyer)
        {
            Console.WriteLine("Veuillez sélectionner la catégorie d'articles que vous voulez consulter");
            Console.WriteLine("Tapez 1 pour Technologie");
            Console.WriteLine("Tapez 2 pour Food");
            Console.WriteLine("Tapez 3 pour Sport");

            int reponseCategorieArticles = int.Parse(Console.ReadLine());
            for (int i = 0; i < admin.listOfAllArticles.Count; i++)
            {
                if (reponseCategorieArticles == 1 && admin.listOfAllArticles[i].typeOfArticle == TypeOfArticle.Technology)
                {
                    admin.listOfAllArticles[i].Decrire();
                }
                if (reponseCategorieArticles == 2 && admin.listOfAllArticles[i].typeOfArticle == TypeOfArticle.Food)
                {
                    admin.listOfAllArticles[i].Decrire();
                }
                if (reponseCategorieArticles == 3 && admin.listOfAllArticles[i].typeOfArticle == TypeOfArticle.Sport)
                {
                    admin.listOfAllArticles[i].Decrire();
                }
            }

            //Demander à l'acheteur de choisir un article à achter en renseignant le numérod'article 
            Console.WriteLine("Lequel de ces articles souhaitez vous acheter?");
            Console.WriteLine("Veuillez renseigner le numéro d'article");
            int idArticleChoixAcheteur = int.Parse(Console.ReadLine());
            for (int i = 0; i < admin.listOfAllArticles.Count; i++)
            {
                if (idArticleChoixAcheteur == admin.listOfAllArticles[i].numeroInstance)
                {
                    Console.WriteLine("Vous souhaitez acheter l'article: " + admin.listOfAllArticles[i].name);
                    Console.WriteLine("La somme de : " + admin.listOfAllArticles[i].price + " sera retiré de votre solde");
                    buyer.solde = buyer.solde - admin.listOfAllArticles[i].price;

                    for (int j = 0; j < admin.listOfAllSellers.Count; j++)
                    {
                        for (int k = 0; k < admin.listOfAllSellers[j].listeArticleClient.Count; k++)
                        {
                            if (idArticleChoixAcheteur == admin.listOfAllSellers[j].listeArticleClient[k].numeroInstance)
                            {
                                Transaction transaction = new Transaction(buyer, admin.listOfAllSellers[j], admin.listOfAllSellers[j].listeArticleClient[k], admin.listOfAllSellers[j].listeArticleClient[k].price);
                                admin.listOfAllTransactions.Add(transaction);
                                buyer.listeArticleClient.Add(admin.listOfAllSellers[j].listeArticleClient[k]);
                                admin.listOfAllSellers[j].credit = admin.listOfAllSellers[j].credit + admin.listOfAllSellers[j].listeArticleClient[k].price;
                                SavingSystem.SerializeSeller(admin.listOfAllSellers[j]);
                                SavingSystem.SerializeBuyer(buyer);
                                admin.listOfAllSellers[j].listeArticleClient.Remove(admin.listOfAllSellers[j].listeArticleClient[k]);

                                for (int l = 0; l < buyer.listeArticleClient.Count; l++)
                                {
                                    Console.WriteLine("******************************");
                                    Console.WriteLine("*****Liste articles acheteur********");
                                    Console.WriteLine("Solde acheteur : " + buyer.solde);                        
                                    buyer.listeArticleClient[l].Decrire();
                                }

                                for (int m = 0; m < admin.listOfAllSellers[j].listeArticleClient.Count; m++)
                                {
                                    Console.WriteLine("******************************");
                                    Console.WriteLine("******************************");
                                    Console.WriteLine("*****Liste articles vendeur********");
                                    Console.WriteLine("Crédit vendeur : " + admin.listOfAllSellers[j].credit);
                                    admin.listOfAllSellers[j].listeArticleClient[m].Decrire();
                                }
                                for (int n = 0; n < admin.listOfAllTransactions.Count; n++)
                                {
                                    Console.WriteLine("******************************");
                                    Console.WriteLine();
                                    Console.WriteLine(admin.listOfAllTransactions[n].ToString()  +"at" + admin.listOfAllTransactions[n].timeStamp);
                                }

                            }
                        }
                    }
                    
                    
                }
            }

            SavingSystem.SerializeListTransactions(admin.listOfAllTransactions);
            SavingSystem.SerializeListArticle(admin.listOfAllArticles);
            SavingSystem.SerializeListSeller(admin.listOfAllSellers);
            SavingSystem.SerializeListBuyer(admin.listOfAllBuyers);
            SavingSystem.SerializeListClients(admin.listOfAllClients);

            Console.WriteLine("Retour à la session");
            LaunchBuyerSession(admin, buyer.numberclientInstance);
        }
        public static void DeleteArticle_Buyer(Admin admin, Buyer buyer)
        {
            Console.WriteLine("Quel article voulez vous retourner?");
            for (int i = 0; i < buyer.listeArticleClient.Count; i++)
            {
                buyer.listeArticleClient[i].Decrire();
            }

            Console.WriteLine("Indiquez le numéro d'article que vous voulez retourner");
            //Récupérer sa réponse
            int reponseUser = int.Parse(Console.ReadLine());

            for (int i = 0; i < buyer.listeArticleClient.Count; i++)
            {
                if (reponseUser == buyer.listeArticleClient[i].numeroInstance)
                {
                    Console.WriteLine("Nous retirons l'article " + buyer.listeArticleClient[i].name);
                    Console.WriteLine("Nous vous remboursons le prix de l'article");
                    buyer.solde = buyer.solde + buyer.listeArticleClient[i].price;
                    buyer.listeArticleClient.Remove(buyer.listeArticleClient[i]);
                }
            }

            Console.WriteLine("Votre solde est maintenant de: " + buyer.solde);
            Console.WriteLine("Votre liste d'articles se compose des articles suivants:");
            for (int i = 0; i < buyer.listeArticleClient.Count; i++)
            {
                buyer.listeArticleClient[i].Decrire();
            }

            SavingSystem.SerializeBuyer(buyer);
            SavingSystem.SerializeListBuyer(admin.listOfAllBuyers);
            Console.WriteLine("Retour à la session");
            LaunchBuyerSession(admin, buyer.numberclientInstance);
        }
        //Fonctions relatives au profil Admin
        public static void FindAllBuyers(Admin admin) {

            for (int i = 0; i < admin.listOfAllBuyers.Count; i++)
            {
                Console.WriteLine("Liste des acheteurs:");
                Console.WriteLine("*****************************");
                Console.WriteLine(admin.listOfAllBuyers[i].name + admin.listOfAllBuyers[i].surname + ", avec n° " + admin.listOfAllBuyers[i].numberclientInstance + ", avec " + admin.listOfAllBuyers[i].listeArticleClient.Count + " articles");
                Console.WriteLine("*****************************");
            }
            Console.WriteLine("Retour Menu Administrateur");
            AdminSession(admin);


        }
        public static void FindAllSellers(Admin admin) {

            for (int i = 0; i < admin.listOfAllSellers.Count; i++)
            {
                Console.WriteLine("Liste des vendeurs:");
                Console.WriteLine("*****************************");
                Console.WriteLine(admin.listOfAllSellers[i].name + admin.listOfAllSellers[i].surname + ", avec n° " + admin.listOfAllSellers[i].numberclientInstance + ", avec " + admin.listOfAllSellers[i].listeArticleClient.Count + " articles");
                Console.WriteLine("*****************************");
            }
            Console.WriteLine("Retour Menu Administrateur");
            AdminSession(admin);
        }
        public static void FindAllArticles(Admin admin) {

            for (int i = 0; i < admin.listOfAllArticles.Count; i++)
            {
                Console.WriteLine("Liste des articles:");
                Console.WriteLine("*****************************");
                admin.listOfAllArticles[i].Decrire();
                Console.WriteLine("*****************************");
            }
            Console.WriteLine("Retour Menu Administrateur");
            AdminSession(admin);
        }
        public static void FindAllTransactions(Admin admin)
        {

            for (int i = 0; i < admin.listOfAllTransactions.Count; i++)
            {
                Console.WriteLine("Liste des transactions:");
                Console.WriteLine("*****************************");
                Console.WriteLine(admin.listOfAllTransactions[i].ToString());
                Console.WriteLine("*****************************");
            }
            Console.WriteLine("Retour Menu Administrateur");
            AdminSession(admin);
        }
    }
}

