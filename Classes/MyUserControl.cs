﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace generateContentForInstructionSimonov.Classes
{

    [Serializable]
    public class MyUserControl : UserControl
    {



        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (MouseButtons == System.Windows.Forms.MouseButtons.Left)
            {
                var tmp = ClickLocation;//PointToClient(Cursor.Position);
                if (tmp.X < 0 || tmp.Y < 0 || tmp.X > 50 || tmp.Y > 50)
                {
                    Console.WriteLine("Какая то дичь с координатами объкта в MouseMove");
                }
                MoveThisObj(new Classes.SenderObjForEvent(objectEvent: this, locationCursorInObj: tmp), e);//вызываем событие
            }
            base.OnMouseMove(e);
        }
        Classes.Interactive_menu_item _Menu_Item = new Interactive_menu_item();
        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.BringToFront();
            ClickLocation = new Point(e.X, e.Y);


            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {

                // запоминаем ссылку на элемент, который тащим
                this.AllowDrop = true;
                // начинаем перетаскивание
                if (this.Parent.GetType() == typeof(MyUserControls.PanelComponents))
                    this.DoDragDrop(new Classes.sendDataInDragDrop(objSend: this, type: this.GetType()), DragDropEffects.Copy);
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                _Menu_Item.HideMenu();

                

            }


            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _Menu_Item.HideMenu();
            //Sorters.Square_bond.sort_Square(this.Parent);
            base.OnMouseUp(e);
        }


        public interface ICloneable
        {
            object Clone();
        }




        public event EventHandler moveThisObj;

        protected double thisLocationX = 0;
        protected double thisLocationY = 0;

        protected System.Drawing.Point ClickLocation;

        protected void MoveThisObj(Classes.SenderObjForEvent senderObj, EventArgs e)
        {

            if (moveThisObj != null) moveThisObj(senderObj, e);
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

        //private bool _item_for_copy;
        //[DisplayName("Пример для копирования")]
        //public bool item_for_copy
        //{
        //    get
        //    {
        //        return _item_for_copy;
        //    }
        //    set
        //    {
        //        _item_for_copy = value;
        //    }
        //}
    }
}
