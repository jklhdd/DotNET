﻿#pragma checksum "C:\Users\Long\source\repos\As1\As1\Food.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B83369DA3F04B160D0500F4A088286EC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace As1
{
    partial class Food : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Food.xaml line 31
                {
                    this.mySplitView = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 3: // Food.xaml line 34
                {
                    this.Finacial = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 4: // Food.xaml line 42
                {
                    this.FoodItem = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 5: // Food.xaml line 35
                {
                    this.btnFinancal = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnFinancal).Click += this.btnFinancal_Click;
                }
                break;
            case 6: // Food.xaml line 24
                {
                    this.btnOpen = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnOpen).Click += this.btnOpen_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
