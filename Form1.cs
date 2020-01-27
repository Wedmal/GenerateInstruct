using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace generateContentForInstructionSimonov
{
    public partial class Form1 : Form
    {

        public string TextDiagnostic1 {get {return this.TextDiagnostic1; } set     {      this.labelDiagnostic1.Text = value;    }}
        
           
       
          


        public Form1()
        {
            InitializeComponent();
            imgContextComponent1.newLocation += ImgContextComponent1_newLocation;
            TextDiagnostic1 = "блабла";
            Additions.GlobalCursorPosition globalCursorPosition = new Additions.GlobalCursorPosition();
            globalCursorPosition.newLocation += GlobalCursorPosition_newLocation;
         

        }

        private void GlobalCursorPosition_newLocation(object sender, EventArgs e)
        {
            //System.Drawing.Point tmp =(System.Drawing.Point) sender;
            //labelDiagnostic1.Text = tmp.X + " " + tmp.Y;
        }

        private void ImgContextComponent1_newLocation(object sender, EventArgs e)
        {
            TextDiagnostic1 = imgContextComponent1.thisLocationX + " " + imgContextComponent1.thisLocationY;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons == System.Windows.Forms.MouseButtons.Left)
            {
               
            }
            if (MouseButtons == System.Windows.Forms.MouseButtons.Right)
            {

            }
        }



    

    }
}
