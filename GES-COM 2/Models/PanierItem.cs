using GES_COM_2.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GES_COM_2.Models
{
    class PanierItem : ViewModelBase
    {
        //public DoubleConverter SousTotal => Prix * Quantite;
        public class Client : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public Article _article;
        public Article Article
        {
            get { return _article; }
            set
            {
                if (_article != value)
                {
                    _article = value;
                    OnPropertyChanged(nameof(Article));
                }

            }
        }
        public int _quantite;
        public int Quantite
        {
            get { return _quantite; }
            set
            {
                if( _quantite != value)
                {
                    if (value <= Article.Qte)
                    {
                        _quantite = value;
                        OnPropertyChanged(nameof(Quantite));
                        SousTotal = this.Quantite * this.Prix;
                        OnPropertyChanged(nameof(SousTotal));
                    }
                    else
                    {
                        _quantite = Article.Qte;
                        OnPropertyChanged(nameof(Quantite));
                        SousTotal = this.Quantite * this.Prix;
                        OnPropertyChanged(nameof(SousTotal));
                    }
                }
            }
        }
        public Double _soustotal;

        public Double SousTotal
        {
            get { return _soustotal; }
            set
            {
                if(_soustotal != value)
                {
                    _soustotal = value;
                    OnPropertyChanged(nameof(SousTotal));
                }
            }
        }
        public Double _prix;
        public Double Prix
        {
            get { return _prix; }
            set
            {
                if(_prix != value)
                {
                    _prix = value;
                    OnPropertyChanged(nameof(Prix));
                    SousTotal = this.Quantite * this.Prix;
                    OnPropertyChanged(nameof(SousTotal));
                }
            }
            
        } 
       
    }
}
