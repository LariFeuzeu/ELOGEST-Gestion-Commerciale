﻿#pragma checksum "..\..\..\Views\HistoriqueView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9272B6BBF6C51023B20276D911CC0750F4F28D22DFAD4CD6BA603606E0A8B1BB"
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
    /// HistoriqueView
    /// </summary>
    public partial class HistoriqueView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 97 "..\..\..\Views\HistoriqueView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker startDatePicker;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\Views\HistoriqueView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker endDatePicker;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\Views\HistoriqueView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PrintApprosButton;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\..\Views\HistoriqueView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FilterApprosButton;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\Views\HistoriqueView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox subscriptionList;
        
        #line default
        #line hidden
        
        
        #line 225 "..\..\..\Views\HistoriqueView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker startDatePickerAchats;
        
        #line default
        #line hidden
        
        
        #line 229 "..\..\..\Views\HistoriqueView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker endDatePickerAchats;
        
        #line default
        #line hidden
        
        
        #line 232 "..\..\..\Views\HistoriqueView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PrintVentesButton;
        
        #line default
        #line hidden
        
        
        #line 233 "..\..\..\Views\HistoriqueView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FilterVentesButton;
        
        #line default
        #line hidden
        
        
        #line 240 "..\..\..\Views\HistoriqueView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox inscriptionsList;
        
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
            System.Uri resourceLocater = new System.Uri("/GES-COM 2;component/views/historiqueview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\HistoriqueView.xaml"
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
            this.startDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 2:
            this.endDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.PrintApprosButton = ((System.Windows.Controls.Button)(target));
            
            #line 104 "..\..\..\Views\HistoriqueView.xaml"
            this.PrintApprosButton.Click += new System.Windows.RoutedEventHandler(this.PrintApprosButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.FilterApprosButton = ((System.Windows.Controls.Button)(target));
            
            #line 105 "..\..\..\Views\HistoriqueView.xaml"
            this.FilterApprosButton.Click += new System.Windows.RoutedEventHandler(this.FilterApprosButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 110 "..\..\..\Views\HistoriqueView.xaml"
            ((System.Windows.Controls.ScrollViewer)(target)).PreviewMouseWheel += new System.Windows.Input.MouseWheelEventHandler(this.ScrollViewer_PreviewMouseWheel);
            
            #line default
            #line hidden
            return;
            case 6:
            this.subscriptionList = ((System.Windows.Controls.ListBox)(target));
            return;
            case 7:
            this.startDatePickerAchats = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            this.endDatePickerAchats = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 9:
            this.PrintVentesButton = ((System.Windows.Controls.Button)(target));
            
            #line 232 "..\..\..\Views\HistoriqueView.xaml"
            this.PrintVentesButton.Click += new System.Windows.RoutedEventHandler(this.PrintInscriptionButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.FilterVentesButton = ((System.Windows.Controls.Button)(target));
            
            #line 233 "..\..\..\Views\HistoriqueView.xaml"
            this.FilterVentesButton.Click += new System.Windows.RoutedEventHandler(this.FilterVentesButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 238 "..\..\..\Views\HistoriqueView.xaml"
            ((System.Windows.Controls.ScrollViewer)(target)).PreviewMouseWheel += new System.Windows.Input.MouseWheelEventHandler(this.ScrollViewer_PreviewMouseWheel);
            
            #line default
            #line hidden
            return;
            case 12:
            this.inscriptionsList = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

