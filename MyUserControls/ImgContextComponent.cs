using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace generateContentForInstructionSimonov.MyUserControls
{
    public partial class ImgContextComponent : UserControl
    {
        public event EventHandler newLocation;
  
        public double thisLocationX = 0;
        public double thisLocationY = 0;
        public ImgContextComponent()
        {
            InitializeComponent();
            this.newLocation += ImgContextComponent_newLocation;

        }


        private void ImgContextComponent_newLocation(object sender, EventArgs e)
        {
            newLocation(this.Location, e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
        }



    }
}
