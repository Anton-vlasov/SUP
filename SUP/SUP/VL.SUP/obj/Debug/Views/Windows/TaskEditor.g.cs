#pragma checksum "..\..\..\..\Views\Windows\TaskEditor.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "777CFC2DEE9E3F0FE96CB698F56E4F3B1BB37001CBA9286E7899A3A73D3A1BB1"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using SUP.Views.Windows;
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


namespace SUP.Views.Windows {
    
    
    /// <summary>
    /// TaskEditor
    /// </summary>
    public partial class TaskEditor : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\Views\Windows\TaskEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button closeButton;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Views\Windows\TaskEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox titleBox;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Views\Windows\TaskEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox descriptionTask;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Views\Windows\TaskEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox performerBox;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\Views\Windows\TaskEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox testerBox;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\Views\Windows\TaskEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button saveButton;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\Views\Windows\TaskEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteButton;
        
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
            System.Uri resourceLocater = new System.Uri("/SUP;component/views/windows/taskeditor.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Windows\TaskEditor.xaml"
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
            
            #line 9 "..\..\..\..\Views\Windows\TaskEditor.xaml"
            ((System.Windows.Controls.Border)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.closeButton = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\..\Views\Windows\TaskEditor.xaml"
            this.closeButton.Click += new System.Windows.RoutedEventHandler(this.closeButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.titleBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.descriptionTask = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.performerBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.testerBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.saveButton = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\..\..\Views\Windows\TaskEditor.xaml"
            this.saveButton.Click += new System.Windows.RoutedEventHandler(this.saveButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.deleteButton = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\..\Views\Windows\TaskEditor.xaml"
            this.deleteButton.Click += new System.Windows.RoutedEventHandler(this.deleteButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

