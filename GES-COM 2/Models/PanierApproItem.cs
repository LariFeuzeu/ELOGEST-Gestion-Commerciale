using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GES_COM_2.Models
{
    class PanierApproItem : PanierItem
    {
        private DateTime datePeremtion;

        public DateTime DatePeremtion
        {
            get
            {
                return datePeremtion;
            }
            set
            {
                if (datePeremtion != value)
                {
                    datePeremtion = value;
                    OnPropertyChanged(nameof(DatePeremtion));
                }
            }
        }
        public int n_ligne;
        public int N_ligne
        {
            get
            {
                return n_ligne;
            }
            set
            {
                if (n_ligne != value)
                {
                    n_ligne = value;
                    OnPropertyChanged(nameof(N_ligne));
                }
            }
        }

        public int n_appro;
        public int N_Appro
        {
            get
            {
                return n_appro;
            }
            set
            {
                if (n_appro != value)
                {
                    n_appro = value;
                    OnPropertyChanged(nameof(N_Appro));
                }
            }
        }
        public int n_art;
        public int N_Art
        {
            get
            {
                return n_art;
            }
            set
            {
                if (n_art != value)
                {
                    n_art = value;
                    OnPropertyChanged(nameof(N_Art));
                }
            }
        }
        public int _quantiteapp;
        public int QuantiteApp
        {
            get
            {
                return _quantiteapp;
            }
            set
            {
                if(_quantiteapp != value) {
                    _quantiteapp = value;
                    OnPropertyChanged(nameof(QuantiteApp));
                    SousTotal = this.QuantiteApp * this.PrixU;
                    OnPropertyChanged(nameof(SousTotal));
                }
            }
        }
        public Double _prixU;
        public Double PrixU
        {
            get
            {
                return _prixU;
            }
            set
            {
                if (_prixU != value)
                {
                    _prixU = value;
                    OnPropertyChanged(nameof(PrixU));
                    SousTotal = this.QuantiteApp * this.PrixU;
                    OnPropertyChanged(nameof(SousTotal));
                }
            }
        }
        public Double _soustotal;

        public Double SousTotal
        {
            get { return _soustotal; }
            set
            {
                if (_soustotal != value)
                {
                    _soustotal = value;
                    OnPropertyChanged(nameof(SousTotal));
                }
            }
        }
        public Double _montantapp;
        public Double MontantApp
        {
            get
            {
                return _montantapp;
            }
            set
            {
                if (_montantapp != value)
                {
                    _montantapp = value;
                    OnPropertyChanged(nameof(MontantApp));
                }
            }
        }

        public PanierApproItem()
        {
          // this.datePeremtion = DateTime.Today;
        }
    }
}
