using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace generateContentForInstructionSimonov.MyUserControls
{
    public partial class ConstructContent : UserControl
    {


        public ConstructContent()
        {
            InitializeComponent();this.AllowDrop = true;
            this.DragEnter += ConstructContent_DragEnter;
            this.DragLeave += ConstructContent_DragLeave;
            this.DragDrop += ConstructContent_DragDrop;
        }

        private void ConstructContent_DragDrop(object sender, DragEventArgs e)
        {
            //Classes.MyUserControl inputControl = (Classes.MyUserControl)sender;
            //Classes.MyUserControl p = sender as Classes.MyUserControl;
            var tmp = (Classes.sendDataInDragDrop)e.Data.GetData(typeof (Classes.sendDataInDragDrop));

            //var itemForCopy = (tmp.Type.BaseTyp) tmp.ObjSend;
            Classes.MyUserControl itemForCopy = (Classes.MyUserControl)tmp.ObjSend;
            //itemForCopy.Visible = false;
            Classes.MyUserControl newObj = Clone(itemForCopy);
            newObj.moveThisObj += ObjectMyControl_newLocation;
            this.Controls.Add(newObj);

            newObj.BringToFront();
            newObj.Location = itemForCopy.Location;
            newObj.BackgroundImage = itemForCopy.BackgroundImage;
            this.Controls.Add((Control)newObj);
            newObj.Location = new Point(this.PointToClient(Cursor.Position).X, this.PointToClient(Cursor.Position).Y);




            //Classes.MyUserControl inputObj = (Classes.MyUserControl)e.Data.GetData(typeof(Classes.MyUserControl));
        }

        private void ObjectMyControl_newLocation(object sender, EventArgs e)
        {
            Classes.SenderObjForEvent objLocationPointToScreen = (Classes.SenderObjForEvent)sender;
            var eventObj = (Classes.MyUserControl)objLocationPointToScreen.ObjectEvent;
            bool childer = false;
            foreach (Control item in this.Controls)//на передний план.
            {
                if (item == eventObj)
                {
                    childer = true;
                }
            }
            if (!childer)
            {
                this.Controls.Add(eventObj);

                this.UpdateZOrder();
            }
            eventObj.BringToFront();
  

            System.Drawing.Point newLocationObj =
                new Point(x: this.PointToClient(Cursor.Position).X - objLocationPointToScreen.LocationCursorInObj.X,
                          y: this.PointToClient(Cursor.Position).Y - objLocationPointToScreen.LocationCursorInObj.Y);
            
            eventObj.Location = new Point(newLocationObj.X, newLocationObj.Y);

        }



        private void NewObj_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                var eventObj = (Classes.MyUserControl)sender;

                System.Drawing.Point newLocationObj =
                    new Point(x: this.PointToClient(Cursor.Position).X - e.X,
                              y: this.PointToClient(Cursor.Position).Y - e.Y);
                eventObj.Location = new Point(newLocationObj.X, newLocationObj.Y);
            }


        }



        private void ConstructContent_DragLeave(object sender, EventArgs e)
        {

           

            //var tmp = (Classes.sendDataInDragDrop)e.Data.GetData(typeof(Classes.sendDataInDragDrop));
            //var obj = (Control)tmp.ObjSend;
            //obj.Dispose();
        }

        T Clone<T>(T controlToClone) where T : Control
        {
            T instance = Activator.CreateInstance<T>();

            Type control = controlToClone.GetType();
            PropertyInfo[] info = control.GetProperties();
            object p = control.InvokeMember("", System.Reflection.BindingFlags.CreateInstance, null, controlToClone, null);
            foreach (PropertyInfo pi in info)
            {
                if ((pi.CanWrite) && !(pi.Name == "WindowTarget") && !(pi.Name == "Capture"))
                {
                    pi.SetValue(instance, pi.GetValue(controlToClone, null), null);
                }
            }
            return instance;
        }

        private void ConstructContent_DragEnter(object sender, DragEventArgs e)
        {
            var tmp = e;
            e.Effect = DragDropEffects.Copy;
            if (e.Data.GetDataPresent(DataFormats.Serializable))
            {
                e.Effect = DragDropEffects.Copy;
            }
            //base.OnDragEnter(e);
        }


    }
}
