using GES_COM_2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GES_COM_2.ViewModels
{
    class HistoriqueVM : ViewModelBase
    {
        private int _quantiteApprosAffiches;
        public int QuantiteApprosAffiches
        {
            get { return _quantiteApprosAffiches; }
            set
            {
                _quantiteApprosAffiches = value;
                OnPropertyChanged("QuantiteApprosAffiches");
            }
        }

        private double _montantTotalAppros;
        public double MontantTotalAppros
        {
            get { return _montantTotalAppros; }
            set
            {
                _montantTotalAppros = value;
                OnPropertyChanged("MontantTotalAppros");
            }
        }

        private int _quantiteAchatsAffiches;
        public int QuantiteAchatsAffiches
        {
            get { return _quantiteAchatsAffiches; }
            set
            {
                _quantiteAchatsAffiches = value;
                OnPropertyChanged("QuantiteAchatsAffiches");
            }
        }

        private double _montantTotalAchats;
        public double MontantTotalAchats
        {
            get { return _montantTotalAchats; }
            set
            {
                _montantTotalAchats = value;
                OnPropertyChanged("MontantTotalAchats");
            }
        }
        ObservableCollection<Approvisionnement> _appros;
        public ObservableCollection<Approvisionnement> Appros
        {
            get
            {
                return _appros;
            }
            set
            {
                if (_appros != value)
                {
                    _appros = value;
                    OnPropertyChanged(nameof(Appros));
                }
            }
        }
        ObservableCollection<Approvisionnement> _filteredAppros;
        public ObservableCollection<Approvisionnement> FilteredAppros
        {
            get
            {
                return _filteredAppros;
            }
            set
            {
                if (_filteredAppros != value)
                {
                    _filteredAppros = value;
                    OnPropertyChanged(nameof(FilteredAppros));
                }
            }
        }
        ObservableCollection<Achat> _achats;
        public ObservableCollection<Achat> Achats
        {
            get
            {
                return _achats;
            }
            set
            {
                if (_achats != value)
                {
                    _achats = value;
                    OnPropertyChanged(nameof(Achats));
                }
            }
        }
        ObservableCollection<Achat> _filteredAchats;

        public ObservableCollection<Achat> FilteredAchats
        {
            get
            {
                return _filteredAchats;
            }
            set
            {
                if (_filteredAchats != value)
                {
                    _filteredAchats = value;
                    OnPropertyChanged(nameof(FilteredAchats));
                }
            }
        }

        public HistoriqueVM()
        {
            Appros = Approvisionnement.GetApprovisionnement();
            Achats = Achat.GetAchat();

            FilteredAchats = Achats;
            FilteredAppros = Appros;

            QuantiteApprosAffiches = FilteredAppros.Count;
            MontantTotalAppros = FilteredAppros.Sum(a => a.MontantTotalAPP);

            QuantiteAchatsAffiches = FilteredAchats.Count;
            MontantTotalAchats = FilteredAchats.Sum(a => a.MontantTotalAc);
        }

        public void FilterApprovisionnements(DateTime startDate, DateTime endDate)
        {
            FilteredAppros = new ObservableCollection<Approvisionnement>(Appros.Where(a => a.Date >= startDate && a.Date <= endDate));
            QuantiteApprosAffiches = FilteredAppros.Count;
            MontantTotalAppros = FilteredAppros.Sum(a => a.MontantTotalAPP);
        }

        public void FilterAchats(DateTime startDate, DateTime endDate)
        {
            FilteredAchats = new ObservableCollection<Achat>(Achats.Where(a => a.Date >= startDate && a.Date <= endDate));
            QuantiteAchatsAffiches = FilteredAchats.Count;
            MontantTotalAchats = FilteredAchats.Sum(a => a.MontantTotalAc);
        }
    }
}
