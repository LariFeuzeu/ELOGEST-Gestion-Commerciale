﻿#pragma checksum "..\..\..\Views\ArticlesView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2C29E2C27790B374368C4FE6C04C3C2288D95B6F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using GES_COM_2.ViewModels;
using GES_COM_2.Views;
using RootLibrary.WPF.Localization;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace GES_COM_2.Views {
    
    
    /// <summary>
    /// ArticlesView
    /// </summary>
    public partial class ArticlesView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 86 "..\..\..\Views\ArticlesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LabelNomA;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\Views\ArticlesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LabelPrixU;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\..\Views\ArticlesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonEnregistrer;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\Views\ArticlesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonModifier;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\..\Views\ArticlesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonSupprimer;
        
        #line default
        #line hidden
        
        
        #line 152 "..\..\..\Views\ArticlesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxRecher;
        
        #line default
        #line hidden
        
        
        #line 160 "..\..\..\Views\ArticlesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listeArticle;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GES-COM 2;component/views/articlesview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\ArticlesView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.LabelNomA = ((System.Windows.Controls.TextBox)(target));
            
            #line 90 "..\..\..\Views\ArticlesView.xaml"
            this.LabelNomA.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.LabelNomA_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.LabelPrixU = ((System.Windows.Controls.TextBox)(target));
            
            #line 99 "..\..\..\Views\ArticlesView.xaml"
            this.LabelPrixU.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.LabelPrixU_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ButtonEnregistrer = ((System.Windows.Controls.Button)(target));
            
            #line 104 "..\..\..\Views\ArticlesView.xaml"
            this.ButtonEnregistrer.Click += new System.Windows.RoutedEventHandler(this.ButtonEnregistrer_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ButtonModifier = ((System.Windows.Controls.Button)(target));
            
            #line 117 "..\..\..\Views\ArticlesView.xaml"
            this.ButtonModifier.Click += new System.Windows.RoutedEventHandler(this.ButtonModifier_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ButtonSupprimer = ((System.Windows.Controls.Button)(target));
            
            #line 130 "..\..\..\Views\ArticlesView.xaml"
            this.ButtonSupprimer.Click += new System.Windows.RoutedEventHandler(this.ButtonSupprimer_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TextBoxRecher = ((System.Windows.Controls.TextBox)(target));
            
            #line 156 "..\..\..\Views\ArticlesView.xaml"
            this.TextBoxRecher.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBoxRecher_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.listeArticle = ((System.Windows.Controls.ListView)(target));
            
            #line 170 "..\..\..\Views\ArticlesView.xaml"
            this.listeArticle.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.listeArticle_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

