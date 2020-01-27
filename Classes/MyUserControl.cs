using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace generateContentForInstructionSimonov.Classes
{
    public class MyUserControl : UserControl
    {


               
        protected void ImgContextComponent_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons == System.Windows.Forms.MouseButtons.Left && !item_for_copy)
            {
                var tmp = ClickLocation;//PointToClient(Cursor.Position);
                if (tmp.X < 0 || tmp.Y < 0 || tmp.X > 50 || tmp.Y > 50)
                {
                    Console.WriteLine("Какая то дичь с координатами объкта в MouseMove");
                }
                MoveThisObj(new Classes.SenderObjForEvent(objectEvent: this, locationCursorInObj: tmp), e);//вызываем событие
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            ClickLocation = new Point(e.X, e.Y);
            if (item_for_copy) 
            {
                CopyThisObj(this, e);
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            Control c = this.Parent.GetChildAtPoint(this.PointToClient(e.Location));
            Control d = this.Parent.GetChildAtPoint(e.Location);
            Sorters.Square_bond.sort_Square(this.Parent);
            base.OnMouseUp(e);
        }


        



        public event EventHandler moveThisObj;
        public event EventHandler CopyThisObj;

        protected double thisLocationX = 0;
        protected double thisLocationY = 0;

        protected System.Drawing.Point ClickLocation;

        protected void MoveThisObj(Classes.SenderObjForEvent senderObj, EventArgs e)
        {

            moveThisObj(senderObj, e);
        }

        private Form _form;
        [DisplayName("Форма")]
        public Form form
        {
            get
            {
                return _form;
            }
            set
            {
                _form = value;
            }
        }

        private bool _item_for_copy;
        [DisplayName("Пример для копирования")]
        public bool item_for_copy
        {
            get
            {
                return _item_for_copy;
            }
            set
            {
                _item_for_copy = value;
            }
        }
    }
}
