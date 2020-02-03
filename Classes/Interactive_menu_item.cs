using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace generateContentForInstructionSimonov.Classes
{
    public partial class Interactive_menu_item : UserControl
    {

        public int Radius = 100;
        public List<ItemMenu> itemsMenu;
        public Interactive_menu_item()
        {
            InitializeComponent();
        }
        public void ShowMenu() 
        {
            foreach (Control item in this.Controls) 
            {
                item.Visible = true;
                item.Location = new Point(Radius, Radius);
            }
        }
        public void HideMenu() 
        {
            foreach (Control item in this.Controls)
            {
                item.Visible = false;
                item.Location = new Point(Radius, Radius);
            }

        }
        protected override void OnLoad(EventArgs e)
        {
            this.Size = new Size(Radius * 3, Radius * 3);
            if (itemsMenu.Count != 0) 
            { int id = 0;
                foreach(ItemMenu item in itemsMenu) 
                {
                    Label newcontrol = new Label();
                    this.Controls.Add(newcontrol);
                    newcontrol.Name = item.TextMenu + "_" + id;
                    newcontrol.Text = item.TextMenu;
                    newcontrol.MouseMove+= delegate (object obj, MouseEventArgs eventHandler)
                    {
                        if(SelectElement!=null) SelectElement(item, e);
                    };
                    newcontrol.Location = new Point(Radius, Radius);

                    id++;
                }
            }
            base.OnLoad(e);
        }
        public event EventHandler SelectElement;
        public class ItemMenu
        {
            public ItemMenu(string textMenu)
            {
                TextMenu = textMenu;
            }

            public event EventHandler onClick;
            public string TextMenu { get; set; }

        }
    }
}
