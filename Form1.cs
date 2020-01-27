using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace generateContentForInstructionSimonov
{
    public partial class Form1 : Form
    {

        public string TextDiagnostic1 { get { return this.TextDiagnostic1; } set { this.labelDiagnostic1.Text = value; } }

        
        public Form1()
        {
            InitializeComponent();

            imgContextComponent2.moveThisObj += ObjectMyControl_newLocation;
            imgContextComponent2.CopyThisObj += CopyElementMenu;
            textElement1.CopyThisObj += CopyElementMenu;

            textElement1.moveThisObj += ObjectMyControl_newLocation;
            this.DoubleBuffered = true;


            //Additions.GlobalCursorPosition globalCursorPosition = new Additions.GlobalCursorPosition();  //исключение неуправляемого кода.//глобальные координаты курсора
            //globalCursorPosition.newLocation += GlobalCursorPosition_newLocation;


            Sorters.Square_bond.sort_Square(this);

        }

        private void CopyElementMenu(object sender, EventArgs e) 
        {
            //Classes.MyUserControl itemForCopy = (Classes.MyUserControl)sender;
            //itemForCopy.Visible = false;
            //Classes.MyUserControl newObj = Clone(itemForCopy);
            //this.Controls.Add(newObj);
            //newObj.item_for_copy = false;
            //newObj.BringToFront();
            //newObj.Location = itemForCopy.Location;
            //newObj.moveThisObj += ObjectMyControl_newLocation;
            //newObj.BackgroundImage = itemForCopy.BackgroundImage;




            System.Drawing.Point startLocation = new Point(0, 0);
            PictureBox pictureBox = new PictureBox();
            Classes.MyUserControl itemForCopy = (Classes.MyUserControl)sender;

            this.Controls.Add(pictureBox);
            pictureBox.BringToFront();
            pictureBox.MouseMove += delegate (object obj, MouseEventArgs eventHandler)
            {

                if (MouseButtons == System.Windows.Forms.MouseButtons.Left)
                {
                    var tmp = pictureBox.PointToClient(Cursor.Position);
                    var thisPictLoct = pictureBox.Parent.PointToClient(Cursor.Position);
                    TextDiagnostic1 = startLocation + " " + thisPictLoct;
                    pictureBox.Location = new Point(
                        pictureBox.Parent.PointToClient(Cursor.Position).X + eventHandler.X+5,
                        pictureBox.Parent.PointToClient(Cursor.Position).Y + eventHandler.Y-5);
                }
            };

            pictureBox.BringToFront();
            pictureBox.Image = itemForCopy.BackgroundImage;
            pictureBox.Location = new Point(itemForCopy.Location.X + 5, itemForCopy.Location.Y - 5);
            pictureBox.Size = itemForCopy.Size;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            

            pictureBox.MouseUp += delegate (object obj, MouseEventArgs eventHandler)
             {
                 if (pictureBox.Parent == itemForCopy.Parent)
                 {
                     pictureBox.Dispose(); return;
                 }

             };
            pictureBox.MouseDown += delegate (object obj, MouseEventArgs eventHandler)
             {
                 startLocation = new Point(eventHandler.X, eventHandler.Y);
             };

            SendMessage(pictureBox.Handle, (uint)WindowMessages.WM_LBUTTONDOWN,(IntPtr) 0, (IntPtr)0);
           
            //SendMessage(Button1.Handle, (uint)WindowMessages.WM_LBUTTONUP, 0, 0);

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
            this.TopMost = true;

            System.Drawing.Point newLocationObj =
                new Point(x: this.PointToClient(Cursor.Position).X - objLocationPointToScreen.LocationCursorInObj.X,
                          y: this.PointToClient(Cursor.Position).Y - objLocationPointToScreen.LocationCursorInObj.Y);
            labelDiagnostic1.Text = newLocationObj.X + " " + newLocationObj.Y;
            eventObj.Location = new Point(newLocationObj.X, newLocationObj.Y);

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }


        [DllImport("user32", SetLastError = true)]
        public static extern IntPtr SendMessage(
                  IntPtr hWnd,
                  uint Msg,
                  IntPtr wParam,
                  IntPtr lParam);
        [Flags]
        public enum WindowMessages : uint
        {
            WM_MOUSEMOVE = 0x200,
            WM_LBUTTONDOWN = 0x201,
            WM_RBUTTONDOWN = 0x204,
            WM_MBUTTONDOWN = 0x207,
            WM_LBUTTONUP = 0x202,
            WM_RBUTTONUP = 0x205,
            WM_MBUTTONUP = 0x208,
            WM_LBUTTONDBLCLK = 0x203,
            WM_RBUTTONDBLCLK = 0x206,
            WM_MBUTTONDBLCLK = 0x209,
            WM_MOUSEWHEEL = 0x020A,
            WM_KEYDOWN = 0x100,
            WM_KEYUP = 0x101,
            WM_SYSKEYDOWN = 0x104,
            WM_SYSKEYUP = 0x105,
        }

    }
}
