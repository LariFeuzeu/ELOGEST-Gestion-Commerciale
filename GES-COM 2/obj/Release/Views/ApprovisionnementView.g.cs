﻿#pragma checksum "..\..\..\Views\ApprovisionnementView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3566C514D7DDBCD47ED4439C3D7C3B28180F0564162D849D62AA0872FFBC65DC"
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
    /// ApprovisionnementView
    /// </summary>
    public partial class ApprovisionnementView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 86 "..\..\..\Views\ApprovisionnementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxRecher;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\Views\ApprovisionnementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listeArticle;
        
        #line default
        #line hidden
        
        
        #line 173 "..\..\..\Views\ApprovisionnementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listePanier;
        
        #line default
        #line hidden
        
        
        #line 358 "..\..\..\Views\ApprovisionnementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBoxTotal;
        
        #line default
        #line hidden
        
        
        #line 366 "..\..\..\Views\ApprovisionnementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBoxReste;
        
        #line default
        #line hidden
        
        
        #line 378 "..\..\..\Views\ApprovisionnementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxMontantVers;
        
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
            System.Uri resourceLocater = new System.Uri("/GES-COM 2;component/views/approvisionnementview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\ApprovisionnementView.xaml"
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
            this.TextBoxRecher = ((System.Windows.Controls.TextBox)(target));
            
            #line 90 "..\..\..\Views\ApprovisionnementView.xaml"
            this.TextBoxRecher.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBoxRecher_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.listeArticle = ((System.Windows.Controls.ListView)(target));
            
            #line 102 "..\..\..\Views\ApprovisionnementView.xaml"
            this.listeArticle.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.listeArticle_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 103 "..\..\..\Views\ApprovisionnementView.xaml"
            this.listeArticle.PreviewMouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.listeArticle_PreviewMouseLeftButtonUp);
            
            #line default
            #line hidden
            
            #line 104 "..\..\..\Views\ApprovisionnementView.xaml"
            this.listeArticle.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.listeArticle_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 156 "..\..\..\Views\ApprovisionnementView.xaml"
            ((System.Windows.Controls.ComboBox)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.listePanier = ((System.Windows.Controls.ListView)(target));
            
            #line 170 "..\..\..\Views\ApprovisionnementView.xaml"
            this.listePanier.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListView_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 171 "..\..\..\Views\ApprovisionnementView.xaml"
            this.listePanier.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.listePanier_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 172 "..\..\..\Views\ApprovisionnementView.xaml"
            this.listePanier.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.listePanier_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 8:
            this.TextBoxTotal = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.TextBoxReste = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.TextBoxMontantVers = ((System.Windows.Controls.TextBox)(target));
            
            #line 381 "..\..\..\Views\ApprovisionnementView.xaml"
            this.TextBoxMontantVers.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBoxMontantVers_TextChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 388 "..\..\..\Views\ApprovisionnementView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 5:
            
            #line 221 "..\..\..\Views\ApprovisionnementView.xaml"
            ((System.Windows.Controls.TextBox)(target)).LostFocus += new System.Windows.RoutedEventHandler(this.TextBox_LostFocus);
            
            #line default
            #line hidden
            break;
            case 6:
            
            #line 249 "..\..\..\Views\ApprovisionnementView.xaml"
            ((System.Windows.Controls.TextBox)(target)).LostFocus += new System.Windows.RoutedEventHandler(this.TextBox_LostFocus);
            
            #line default
            #line hidden
            break;
            case 7:
            
            #line 324 "..\..\..\Views\ApprovisionnementView.xaml"
            ((System.Windows.Controls.Image)(target)).PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Image_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

