﻿#pragma checksum "..\..\winPassword.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E5090A115CD96E903DB34C7A395F75FB5163BADC3099334FEFD323B15C6EE238"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace dentalConnectWPF {
    
    
    /// <summary>
    /// winPassword
    /// </summary>
    public partial class winPassword : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 61 "..\..\winPassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnConfirm;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\winPassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\winPassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtError;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\winPassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\winPassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pbOriginal;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\winPassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pbNew;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\winPassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pbNew2;
        
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
            System.Uri resourceLocater = new System.Uri("/dentalConnectWPF;component/winpassword.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\winPassword.xaml"
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
            this.btnConfirm = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\winPassword.xaml"
            this.btnConfirm.Click += new System.Windows.RoutedEventHandler(this.btnConfirm_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\winPassword.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtError = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 90 "..\..\winPassword.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click_1);
            
            #line default
            #line hidden
            return;
            case 5:
            this.pbOriginal = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 6:
            this.pbNew = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 7:
            this.pbNew2 = ((System.Windows.Controls.PasswordBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

