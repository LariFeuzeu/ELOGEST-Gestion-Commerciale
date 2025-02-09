 using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;

namespace GES_COM_2.Models
{
    public class Utilisateur : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private int _idutili;
        public int Idutili
        {
            get { return _idutili; }
            set
            {
                if (_idutili != value)
                {
                    _idutili = value;
                    OnPropertyChanged(nameof(Idutili));
                }
            }
        }
        private string _libelle;
        public string Libelle
        {
            get { return _libelle; }
            set
            {
                if (_libelle != value)
                {
                    _libelle = value;
                    OnPropertyChanged(nameof(Libelle));
                }
            }
        }
        public string _nom;
        public string Nom
        {
            get { return _nom; }
            set
            {
                if (_nom != value)
                {
                    _nom = value;
                    OnPropertyChanged(nameof(Nom));
                }
            }
        }
        public string _prenom;
        public string Prenom
        {
            get { return _prenom; }
            set
            {
                if (_prenom != value)
                {
                    _prenom = value;
                    OnPropertyChanged(nameof(Prenom));
                }
            }
        }
        public string _motdepasse;
        public string Motdepasse
        {
            get { return _motdepasse; }
            set
            {
                if (_motdepasse != value)
                {
                    _motdepasse = value;
                    OnPropertyChanged(nameof(Motdepasse));
                }
            }
        }
        public string _telUT;
        public string TelUT
        {
            get { return _telUT; }
            set
            {
                if (_telUT != value)
                {
                    _telUT = value;
                    OnPropertyChanged(nameof(TelUT));
          }
         }
       }
     }
   }
