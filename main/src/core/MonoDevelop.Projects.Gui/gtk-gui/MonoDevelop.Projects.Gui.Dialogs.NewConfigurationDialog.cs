// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace MonoDevelop.Projects.Gui.Dialogs {
    
    internal partial class NewConfigurationDialog {
        
        private Gtk.VBox vbox77;
        
        private Gtk.Table table1;
        
        private Gtk.ComboBoxEntry comboName;
        
        private Gtk.ComboBoxEntry comboPlatform;
        
        private Gtk.Label label1;
        
        private Gtk.Label label2;
        
        private Gtk.CheckButton createChildrenCheck;
        
        private Gtk.Button cancelbutton1;
        
        private Gtk.Button okbutton1;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget MonoDevelop.Projects.Gui.Dialogs.NewConfigurationDialog
            this.Name = "MonoDevelop.Projects.Gui.Dialogs.NewConfigurationDialog";
            this.Title = MonoDevelop.Core.GettextCatalog.GetString("New Configuration");
            this.TypeHint = ((Gdk.WindowTypeHint)(1));
            // Internal child MonoDevelop.Projects.Gui.Dialogs.NewConfigurationDialog.VBox
            Gtk.VBox w1 = this.VBox;
            w1.Name = "dialog-vbox6";
            w1.BorderWidth = ((uint)(2));
            // Container child dialog-vbox6.Gtk.Box+BoxChild
            this.vbox77 = new Gtk.VBox();
            this.vbox77.Name = "vbox77";
            this.vbox77.Spacing = 6;
            this.vbox77.BorderWidth = ((uint)(7));
            // Container child vbox77.Gtk.Box+BoxChild
            this.table1 = new Gtk.Table(((uint)(2)), ((uint)(2)), false);
            this.table1.Name = "table1";
            this.table1.RowSpacing = ((uint)(6));
            this.table1.ColumnSpacing = ((uint)(6));
            // Container child table1.Gtk.Table+TableChild
            this.comboName = Gtk.ComboBoxEntry.NewText();
            this.comboName.Name = "comboName";
            this.table1.Add(this.comboName);
            Gtk.Table.TableChild w2 = ((Gtk.Table.TableChild)(this.table1[this.comboName]));
            w2.LeftAttach = ((uint)(1));
            w2.RightAttach = ((uint)(2));
            w2.XOptions = ((Gtk.AttachOptions)(4));
            w2.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.comboPlatform = Gtk.ComboBoxEntry.NewText();
            this.comboPlatform.Name = "comboPlatform";
            this.table1.Add(this.comboPlatform);
            Gtk.Table.TableChild w3 = ((Gtk.Table.TableChild)(this.table1[this.comboPlatform]));
            w3.TopAttach = ((uint)(1));
            w3.BottomAttach = ((uint)(2));
            w3.LeftAttach = ((uint)(1));
            w3.RightAttach = ((uint)(2));
            w3.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.Xalign = 0F;
            this.label1.LabelProp = MonoDevelop.Core.GettextCatalog.GetString("Name:");
            this.table1.Add(this.label1);
            Gtk.Table.TableChild w4 = ((Gtk.Table.TableChild)(this.table1[this.label1]));
            w4.XOptions = ((Gtk.AttachOptions)(4));
            w4.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.label2 = new Gtk.Label();
            this.label2.Name = "label2";
            this.label2.LabelProp = MonoDevelop.Core.GettextCatalog.GetString("Platform:");
            this.table1.Add(this.label2);
            Gtk.Table.TableChild w5 = ((Gtk.Table.TableChild)(this.table1[this.label2]));
            w5.TopAttach = ((uint)(1));
            w5.BottomAttach = ((uint)(2));
            w5.XOptions = ((Gtk.AttachOptions)(4));
            w5.YOptions = ((Gtk.AttachOptions)(4));
            this.vbox77.Add(this.table1);
            Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.vbox77[this.table1]));
            w6.Position = 0;
            w6.Expand = false;
            w6.Fill = false;
            // Container child vbox77.Gtk.Box+BoxChild
            this.createChildrenCheck = new Gtk.CheckButton();
            this.createChildrenCheck.Name = "createChildrenCheck";
            this.createChildrenCheck.Label = MonoDevelop.Core.GettextCatalog.GetString("Create configurations for all solution items");
            this.createChildrenCheck.Active = true;
            this.createChildrenCheck.DrawIndicator = true;
            this.createChildrenCheck.UseUnderline = true;
            this.vbox77.Add(this.createChildrenCheck);
            Gtk.Box.BoxChild w7 = ((Gtk.Box.BoxChild)(this.vbox77[this.createChildrenCheck]));
            w7.Position = 1;
            w7.Expand = false;
            w7.Fill = false;
            w1.Add(this.vbox77);
            Gtk.Box.BoxChild w8 = ((Gtk.Box.BoxChild)(w1[this.vbox77]));
            w8.Position = 0;
            // Internal child MonoDevelop.Projects.Gui.Dialogs.NewConfigurationDialog.ActionArea
            Gtk.HButtonBox w9 = this.ActionArea;
            w9.Name = "dialog-action_area6";
            w9.Spacing = 6;
            w9.BorderWidth = ((uint)(5));
            w9.LayoutStyle = ((Gtk.ButtonBoxStyle)(4));
            // Container child dialog-action_area6.Gtk.ButtonBox+ButtonBoxChild
            this.cancelbutton1 = new Gtk.Button();
            this.cancelbutton1.Name = "cancelbutton1";
            this.cancelbutton1.UseStock = true;
            this.cancelbutton1.UseUnderline = true;
            this.cancelbutton1.Label = "gtk-cancel";
            this.AddActionWidget(this.cancelbutton1, -6);
            // Container child dialog-action_area6.Gtk.ButtonBox+ButtonBoxChild
            this.okbutton1 = new Gtk.Button();
            this.okbutton1.Name = "okbutton1";
            this.okbutton1.UseStock = true;
            this.okbutton1.UseUnderline = true;
            this.okbutton1.Label = "gtk-ok";
            w9.Add(this.okbutton1);
            Gtk.ButtonBox.ButtonBoxChild w11 = ((Gtk.ButtonBox.ButtonBoxChild)(w9[this.okbutton1]));
            w11.Position = 1;
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 407;
            this.DefaultHeight = 187;
            this.Show();
            this.okbutton1.Clicked += new System.EventHandler(this.OnOkbutton1Clicked);
        }
    }
}