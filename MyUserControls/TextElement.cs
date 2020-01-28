using System.Drawing;

namespace generateContentForInstructionSimonov.MyUserControls
{
    public partial class TextElement : Classes.MyUserControl
    {
        public TextElement()
        {
            InitializeComponent();


            //this.BackgroundImage = MyUserControls.Resource1.img_ico_no_act_;
            ClickLocation = new Point(0, 0);
            this.Size = new Size(150, 50);

        }
    }
}
