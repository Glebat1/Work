﻿#pragma checksum "..\..\..\PapkaAdmin\Provider11.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F60D995DF2ACB2CEAD9195CF99D2858624657CB7F789BB6E14D79A59EB0E30A1"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using ВКР_общежитие.PapkaAdmin;


namespace ВКР_общежитие.PapkaAdmin {
    
    
    /// <summary>
    /// Provider11
    /// </summary>
    public partial class Provider11 : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 17 "..\..\..\PapkaAdmin\Provider11.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Poisk;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\PapkaAdmin\Provider11.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CmbFiltr;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\PapkaAdmin\Provider11.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DG;
        
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
            System.Uri resourceLocater = new System.Uri("/ВКР общежитие;component/papkaadmin/provider11.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PapkaAdmin\Provider11.xaml"
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
            
            #line 8 "..\..\..\PapkaAdmin\Provider11.xaml"
            ((ВКР_общежитие.PapkaAdmin.Provider11)(target)).IsVisibleChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.Page_IsVisibleChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Poisk = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\..\PapkaAdmin\Provider11.xaml"
            this.Poisk.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Poisk_TextChanged_1);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CmbFiltr = ((System.Windows.Controls.ComboBox)(target));
            
            #line 20 "..\..\..\PapkaAdmin\Provider11.xaml"
            this.CmbFiltr.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CmbFiltr_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 23 "..\..\..\PapkaAdmin\Provider11.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 24 "..\..\..\PapkaAdmin\Provider11.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 25 "..\..\..\PapkaAdmin\Provider11.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click2);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 28 "..\..\..\PapkaAdmin\Provider11.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Sklad);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 29 "..\..\..\PapkaAdmin\Provider11.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Post);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 30 "..\..\..\PapkaAdmin\Provider11.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Supply);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 31 "..\..\..\PapkaAdmin\Provider11.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Zakaz);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 32 "..\..\..\PapkaAdmin\Provider11.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Exit);
            
            #line default
            #line hidden
            return;
            case 12:
            this.DG = ((System.Windows.Controls.DataGrid)(target));
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
            case 13:
            
            #line 65 "..\..\..\PapkaAdmin\Provider11.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnRed_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

