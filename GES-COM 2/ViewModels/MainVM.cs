using GES_COM_2.Helpers;
using GES_COM_2.Models;
using GES_COM_2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GES_COM_2.ViewModels
{
    class MainVM : ViewModelBase
    {
        private object _currentView;

        public object CurrentView
        {
            get
            {
                return _currentView;
            }
            set
            {
                if (_currentView != value)
                {
                    _currentView = value;
                    OnPropertyChanged(nameof(CurrentView));
                }
            }
        }
        public ICommand AccueilCommand { get; }
        public ICommand ArticlesCommand { get; }
        public ICommand FacturationCommand { get; }
        public ICommand HistoriqueCommand { get; }
        public ICommand ClientsCommand { get; }
        public ICommand FournisseursCommand { get; }
        public ICommand ApprovisionnementsCommand { get; }
        public ICommand UtilisateursCommand { get; }

        public MainVM()
        {
            AccueilCommand = new RelayCommand(ExecuteAccueilCommand);
            ArticlesCommand = new RelayCommand(ExecuteArticlesCommand);
            ClientsCommand = new RelayCommand(ExecuteClientCommand);
            FacturationCommand = new RelayCommand(ExecuteFacturationCommand);
            HistoriqueCommand = new RelayCommand(ExecuteHistoriqueCommand);
            FournisseursCommand = new RelayCommand(ExecuteFournisseurCommand);
            ApprovisionnementsCommand = new RelayCommand(ExecuteApprovisionnementCommand);
            UtilisateursCommand = new RelayCommand(ExecuteUtilisateurCommand);
            CurrentView = new AccueiView();
        }

        private void ExecuteAccueilCommand(object obj)
        {
            CurrentView = new AccueiView();
        }
        private void ExecuteArticlesCommand(object obj)
        {
            CurrentView = new ArticlesView();
        }
        private void ExecuteHistoriqueCommand(object obj)
        {
            CurrentView = new HistoriqueView();
        }
        private void ExecuteClientCommand(object obj)
        {
            CurrentView = new UserControl1();
        }
        private void ExecuteFacturationCommand(object obj)
        {
            CurrentView = new Facturation();
        }
        private void ExecuteFournisseurCommand(object obj)
        {
            CurrentView = new DistributeurView();
        }
        private void ExecuteApprovisionnementCommand(object obj)
        {
            CurrentView = new ApprovisionnementView();
        }
        private void ExecuteUtilisateurCommand(object obj)
        {
            CurrentView = new UtilisateurView();
        }
    }
}

