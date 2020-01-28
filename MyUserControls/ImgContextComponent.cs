using System.Drawing;
using System.Windows.Forms;

namespace generateContentForInstructionSimonov.MyUserControls
{
    public partial class ImgContextComponent : Classes.MyUserControl
    {


        public ImgContextComponent()
        {
            InitializeComponent();
            this.BackgroundImage = MyUserControls.Resource1.img_ico_no_act_;
            this.Size = new Size(50, 50);
            ClickLocation = new Point(0, 0);
        }



        protected override void OnMouseUp(MouseEventArgs e)
        {
            //ClickLocation = new Point(0, 0);
            base.OnMouseUp(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
        }



    }
}
