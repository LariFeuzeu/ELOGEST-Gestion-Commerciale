using CrystalDecisions.ReportAppServer.ReportDefModel;
using GES_COM_2.Helpers;
using GES_COM_2.Models;
using GES_COM_2.Reports;
using GES_COM_2.Views;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.qrcode;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace GES_COM_2.ViewModels
{

    class FacturationVM : ViewModelBase
    {
        public Client client
        {
            get
            {
                return _client;
            }
            set
            {
                if(_client != value)
                {
                    _client = value;
                    OnPropertyChanged(nameof(client));}
            }
        }
        public static double TotalGlobal = 0;
        public static double MtVerse = 0;
        public static ObservableCollection<PanierItem> _panier;
        public  ObservableCollection<PanierItem> Panier
        {
            get
            {
                return _panier;
            }
            set
            {
                if(_panier != value)
                {
                    _panier = value;
                    OnPropertyChanged(nameof(Panier));

                    double total = 0;
                    foreach (PanierItem item in Panier)
                    {
                        total += item.SousTotal;
                    }

                    OnPropertyChanged(nameof(TotalGlobal));
                }
            }
        }

        private static ObservableCollection<Article> _filteredArticles = new ObservableCollection<Article>();
        public ObservableCollection<Article> FilteredArticles
        {
            get
            {
                return _filteredArticles;
            }
            set
            {
                if (_filteredArticles != value)
                {
                    _filteredArticles = value;
                    OnPropertyChanged(nameof(FilteredArticles));
                }
            }
        }
        public ObservableCollection<Article> FilterArticles(string txt)
        {
            if (string.IsNullOrEmpty(txt))
            {
                FilteredArticles = Articles;
                return FilteredArticles;
            }
            FilteredArticles = new ObservableCollection<Article>(Articles.Where(a => a.NomA.ToLower().Contains(txt.ToLower())));
            return FilteredArticles;
        }

        public ICommand ValiderCommand { get; }
        public ICommand AnnulerCommand { get; }

        public static ObservableCollection<Article> _articles = new ObservableCollection<Article>();
        //private int _totalGlobal
        private Client _client;
        

        public ObservableCollection<Article> Articles
        {
            get
            {
                return _articles;
            }
            set
            {
                if (_articles != value)
                {
                    _articles = value;
                    
                    OnPropertyChanged(nameof(Articles));
                }
             
            }
        }
        public static ObservableCollection<Article> GetArticles(int _idArt = 0)
        {
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from article", con);
            if (_idArt != 0)
            {
                cmd.CommandText = "select * from article where NArt = @id";
                cmd.Parameters.AddWithValue("@id", _idArt);
            }
            DataTable data = new DataTable();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(data);
            ObservableCollection<Article> liste = new ObservableCollection<Article>();
            foreach (DataRow item in data.Rows)
            {
                Article art = new Article()
                {
                    N_art = Convert.ToInt32(item["N_Art"].ToString()),
                    NomA = item["nomA"].ToString(),
                    PrixU = Convert.ToDouble(item["prixU"].ToString())
                };
                liste.Add(art);
            }
            con.Close();
            return liste;
        }
        public FacturationVM()
        {

            //Idclient = 1;
            Articles = GetArticles();
            client = new Client();
            Panier = new ObservableCollection<PanierItem>();
            ValiderCommand = new RelayCommand(ExecuteValiderCommand);
            AnnulerCommand = new RelayCommand(ExecuteAnnulerCommand);
            FilteredArticles = Articles;
        }

        private void ExecuteAnnulerCommand(object obj)
        {
            client = new Client();
            Panier = new ObservableCollection<PanierItem>();
        }
       // public static Client CreerClientParDefaut()
        //{
          //  Client client = new Client();
            //client.Idclient = 1; // Valeur par défaut pour l'ID du client
            //client.NomCl = ""; // Nom par défaut du client
            //client.AdresseCL = ""; // Adresse par défaut du client
            //client.TelCL = ""; // Numéro de téléphone par défaut du client
            //return client;
        //}

        private void ExecuteValiderCommand(object obj)
        {
           // Client clientParDefaut = CreerClientParDefaut();
            //clientParDefaut.NomCl = "";
            //clientParDefaut.AdresseCL = "";
            //clientParDefaut.TelCL ="";
          

            if (!Client.ClientExiste(client))
            {
                Client.SaveClient(client);
            }

            Achat achat = new Achat();
            achat.Date = DateTime.Today;
            achat.Idclient = client._idclient;
            achat.Idutili = App.idUtilisateur;
            achat.MontantTotalAc = TotalGlobal;
            achat.MontantVerse = MtVerse;
            SaveAchat(achat);
            Ligneachat ligne = new Ligneachat();
            ligne.N_achat = achat.N_achat;
            foreach (PanierItem item in Panier)
            {
                //if (item.Quantite < 1)
                //{
                //    Panier.Remove(item);
                //}
                //else
                //{
                    ligne.N_art = item.Article.N_art;
                    ligne.QuantiteLAC = item.Quantite;
                    ligne.Totaux = item.SousTotal;
                    ligne.PrixU = item.Prix;
                    SaveLigne(ligne);
                //}
               
            }
            //GenererFacture(achat);
            client = new Client();
            Panier = new ObservableCollection<PanierItem>();
            Articles = GetArticles();

            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM historiqueachats WHERE n_achat = (SELECT MAX(n_achat) FROM historiqueachats)", con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adp.Fill(data);
            BindingSource bs = new BindingSource();
            bs.DataSource = data;
            Facture rpt = new Facture();
            rpt.SetDataSource(bs.List);
            //FenetreEtats f = new FenetreEtats(rpt, bs.List);
            rpt.PrintToPrinter(1, true, 0, 0);
            //f.ShowDialog();

        }
        
        //private void GenererFacture(Achat achat)
        //{
        //    Achat ach = Achat.GetAchat(achat.N_achat).FirstOrDefault();
        //    Document document = new Document();
        //    string filePath = "factiongest" + achat.N_achat + ".pdf";
        //    PdfWriter write = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
        //    document.Open();



        //    Paragraph paragraphc = new Paragraph("Facture N*: " + achat.N_achat.ToString());
        //    iTextSharp.text.Font HEAVYFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD);
        //    paragraphc.Alignment = Element.ALIGN_LEFT;
        //    document.Add(paragraphc);

        //    string nomEntreprise = "Supermarché MEYOU";
        //    Paragraph nomEntrepriseParagraph = new Paragraph(nomEntreprise, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD));
        //    nomEntrepriseParagraph.Alignment = Element.ALIGN_CENTER;
        //    document.Add(nomEntrepriseParagraph);

        //    string slogan = "<<Votre espace de proximité>>";
        //    Paragraph sloganParagraph = new Paragraph(slogan, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, iTextSharp.text.Font.ITALIC));
        //    sloganParagraph.Alignment = Element.ALIGN_CENTER;
        //    document.Add(sloganParagraph);

        //    string logoPath = "lock.png";
        //    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoPath);
        //    logo.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
        //    logo.ScaleToFit(100f, 100f);
        //    document.Add(logo);

        //    //string nomEntreprise = "Supermarché MEYOU";
        //    //Paragraph nomEntrepriseParagraph = new Paragraph(nomEntreprise, new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD));
        //    //nomEntrepriseParagraph.Alignment = Element.ALIGN_CENTER;
        //    //document.Add(nomEntrepriseParagraph);

        //    string numeroAgrement = "Numero d'agrement: 0000-000-000";
        //    Paragraph numeroAgrementParagraph = new Paragraph(numeroAgrement, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12));
        //    numeroAgrementParagraph.Alignment = Element.ALIGN_CENTER;
        //    document.Add(numeroAgrementParagraph);

           

        //    PdfPTable table = new PdfPTable(4);
        //    table.SpacingBefore = 10f;
        //    table.SpacingAfter = 10f;

        //    document.Add(table);
        //    //document.Add(new Paragraph(achat.N_achat));
        //    table.AddCell("Nom");
        //    table.AddCell("Prix");
        //    table.AddCell("Quantité");
        //    table.AddCell("Total");
        //    document.Add(new Paragraph(""));

           




        //    List<Ligneachat> lignes = new List<Ligneachat>();
        //    lignes = Achat.GetLignes(achat.N_achat);
        //    foreach (Ligneachat item in lignes)
        //    {
        //        table.AddCell(ArticleVM.GetArticles (item.N_art).FirstOrDefault().NomA);              
        //          table.AddCell(item.PrixU.ToString());
        //          table.AddCell(item.QuantiteLAC.ToString());
        //          table.AddCell(item.Totaux.ToString());
        //        //table.AddCell(achat.MontantTotalAc.ToString());
              
        //    }
         

        //    document.Add(table);
        //    Paragraph paragraph =new Paragraph(" Le SousTotal: " + achat.MontantTotalAc.ToString());
        //    iTextSharp.text.Font boldFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.BOLD);
        //    paragraph.Font = boldFont;
        //    paragraph.Alignment = Element.ALIGN_RIGHT;
        //    document.Add(paragraph);

        //    string qrText = "brvhbvb hevhbri";
        //    BarcodeQRCode qrCode = new BarcodeQRCode(qrText, 80, 80, null);
        //    iTextSharp.text.Image qrImage = qrCode.GetImage();
        //    qrImage.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
        //    qrImage.SetAbsolutePosition(0, document.Bottom);
        //    document.Add(qrImage);

        //    //document.Add(new Paragraph(achat.MontantTotalAc.ToString()));

        //    //document.Add(new Paragraph("bbrbrb"));
        //    document.Close();

        //    // Créer une instance de la classe PrintDocument
        //    //PrintDocument printDoc = new PrintDocument();

        //    //// Spécifier l'imprimante
        //    //string printerName = "FT F-186";
        //    //printDoc.PrinterSettings.PrinterName = printerName;

        //    //// Désactiver les marges
        //    //printDoc.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);

        //    //// Gérer l'événement PrintPage pour spécifier le contenu à imprimer
        //    //printDoc.PrintPage += (sender, e) =>
        //    //{
        //    //    // Charger le fichier PDF
        //    //    using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
        //    //    {
        //    //        // Lire le contenu du fichier PDF
        //    //        byte[] bytes = new byte[fileStream.Length];
        //    //        fileStream.Read(bytes, 0, bytes.Length);

        //    //        // Dessiner le contenu du fichier PDF sur la page à imprimer
        //    //        using (MemoryStream stream = new MemoryStream(bytes))
        //    //        {
        //    //            // Calculer la zone de dessin sans marges
        //    //            RectangleF printArea = e.PageSettings.PrintableArea;
        //    //            RectangleF printRect = new RectangleF(0, 0, e.PageSettings.PrintableArea.Width, e.PageSettings.PrintableArea.Height);

        //    //            // Définir la région de dessin sans marges
        //    //            e.Graphics.SetClip(printRect);

        //    //            e.Graphics.DrawImage(System.Drawing.Image.FromStream(stream), printArea);
        //    //        }
        //    //    }
        //    //};

        //    //// Lancer l'impression
        //    //printDoc.Print();
        //}

        public static void SaveLigne(Ligneachat _ligne)
        {
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("insert into LigneAchat (N_achat,n_art,QuantiteLAc,MontantTotalLAc,PrixU) values (@nAchat,@nArt,@qte,@mt,@prixU)", con);
            cmd.Parameters.AddWithValue("@nAchat", _ligne.N_achat);
            cmd.Parameters.AddWithValue("@nArt", _ligne.N_art);
            cmd.Parameters.AddWithValue("@qte", _ligne.QuantiteLAC);
            cmd.Parameters.AddWithValue("@mt", _ligne.Totaux);
            cmd.Parameters.AddWithValue("@prixU", _ligne.PrixU);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void SaveAchat(Achat _achat)
        {
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("insert into achat (N_achat,idUtili,Idclient,Date,MontantTotalAc,mtVerse) values (@nAchat,@idU,@idCl,@date,@mt,@mtVerse)", con);
            cmd.Parameters.AddWithValue("@idU", _achat.Idutili);
            cmd.Parameters.AddWithValue("@nAchat", _achat.N_achat);
            cmd.Parameters.AddWithValue("@idCl", _achat.Idclient);
            cmd.Parameters.AddWithValue("@date", _achat.Date.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@mt", _achat.MontantTotalAc);
            cmd.Parameters.AddWithValue("@mtVerse", _achat.MontantVerse);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static int SaveClient(Client _Client)
        {
            int clientid = -1;
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("insert into Client (Idclient,NomCL,AdresseCL,TelCL) values (@Idclient,@NomCL,@AdresseCL,@TelCL)", con);
            cmd.Parameters.AddWithValue("@NomCL", _Client.NomCl);
            cmd.Parameters.AddWithValue("@Idclient", _Client.Idclient);
            cmd.Parameters.AddWithValue("@AdresseCL", _Client.AdresseCL);
            cmd.Parameters.AddWithValue("@TelCL", _Client.TelCL);
            cmd.ExecuteNonQuery();
            int clientId = (int)cmd.LastInsertedId; // Récupérer l'identifiant généré par la base de données
            con.Close();
            return clientid;
        }

        public static void EnleverDuPanier(Article _art)
        {
            foreach (PanierItem panierItem in _panier)
            {
                if (panierItem.Article == _art)
                {
                    _panier.Remove(panierItem);
                    break;
                }
            }
        }

        public static void AjouterAuPanier(Article _art)
        {
            bool trouve = false;
            foreach (PanierItem panierItem in _panier)
            {
                if (trouve)
                    break;
                if (panierItem.Article == _art)
                {
                    panierItem.Quantite++;
                    panierItem.SousTotal = panierItem.Quantite * panierItem.Prix;

                    trouve = true;
                }
            }
            if (!trouve)
            {
                PanierItem item = new PanierItem();
                item.Article = _art;
                item.Prix = _art.PrixU;
                item.Quantite = 1;
                item.SousTotal = _art.PrixU;
                _panier.Add(item);
            }

        }
    }
}    