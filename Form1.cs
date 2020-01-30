using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace generateContentForInstructionSimonov
{
    public partial class Form1 : Form
    {

        public string TextDiagnostic1 { get { return this.TextDiagnostic1; } set { this.labelDiagnostic1.Text = value; } }
        public string TextDiagnostic2 { get { return this.TextDiagnostic2; } set { this.labelDiagnostic2.Text = value; } }

        protected override void OnLoad(EventArgs e)
        {
            void sort_child_controls_and_set_cursor(Control control) 
            {
                control.Cursor = Classes.GetCursor._getCursor(image: MyUserControls.Resource1.CursorGreen1);
                foreach (Control innerControl in control.Controls)
                {
                    innerControl.Cursor = Classes.GetCursor._getCursor(image: MyUserControls.Resource1.CursorGreen1);
                    sort_child_controls_and_set_cursor(innerControl);
                }
            }
            sort_child_controls_and_set_cursor(this);


            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = false;
            worker.WorkerReportsProgress = false;

            worker.DoWork += (_s, _e) =>
            {
                TranslateScreen();
            };

            worker.RunWorkerCompleted += (_s, _e) =>
            {
                //close window
            };

            worker.RunWorkerAsync();
            base.OnLoad(e);
        }
        /// <summary>
        /// фоновый процесс в цикле:
        /// </summary>
        /// <returns></returns>
        private Task TranslateScreen()
        {
            try
            {




                List<Control> listControl = new List<Control>();
                System.Threading.Timer check_New_obj_in_Form1 = new System.Threading.Timer(_check_New_obj_in_Form1, null, 1000, 1000);

                string allControls = GetAllInnerControlsFor(this);


                string GetAllInnerControlsFor(Control control)
                {
                    StringBuilder allControlNames = new StringBuilder(control.Name);
                    foreach (Control innerControl in control.Controls)
                    {
                        if (!(innerControl is Label)) { allControlNames.AppendLine(GetAllInnerControlsFor(innerControl)); }

                        listControl.Add(innerControl);
                    }
                    return allControlNames.ToString();
                }

                void _check_New_obj_in_Form1(object state)
                {
                    this.Invoke(new Action(() => { allControls = GetAllInnerControlsFor(this); }));
                }
                while (true)
                {
                    try
                    {
                        this.Invoke(new Action(() =>
                        {
                            TextDiagnostic2 = Cursor.Position.X + " " + Cursor.Position.Y;
                            label4.Text = allControls;
                        }));
                        Thread.Sleep(50);
                    }
                    catch (Exception ex)
                    {

                    }

                }
            }
            catch (Exception ex) 
            {
                return null;
            }


            return null;
        }
     
        public Form1()
        {
            InitializeComponent();

            //imgContextComponent2.moveThisObj += ObjectMyControl_newLocation;
            //imgContextComponent2.CopyThisObj += CopyElementMenu;
            //textElement1.CopyThisObj += CopyElementMenu;




            //textElement1.moveThisObj += ObjectMyControl_newLocation;
            this.DoubleBuffered = true;

   

            //imgContextComponent2.AllowDrop = true;
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
            pictureBox.Name = "autoGeneratePB";




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
                        pictureBox.Parent.PointToClient(Cursor.Position).X - startLocation.X,
                        pictureBox.Parent.PointToClient(Cursor.Position).Y - startLocation.Y);


                    
                }
            };

            pictureBox.BringToFront();
            pictureBox.Image = itemForCopy.BackgroundImage;
            pictureBox.Location = new Point(itemForCopy.Location.X, itemForCopy.Location.Y);
            pictureBox.Size = itemForCopy.Size;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            


            pictureBox.MouseDown += delegate (object obj, MouseEventArgs eventHandler)
             {
                 startLocation = new Point(eventHandler.X, eventHandler.Y);
                
             };

            SendMessage(pictureBox.Handle, (uint)WindowMessages.WM_LBUTTONDOWN,(IntPtr) 0, (IntPtr)0);

            pictureBox.AllowDrop = true;
            pictureBox.Tag = new Point(Cursor.Position.X, Cursor.Position.Y);

  


            pictureBox.MouseUp += async delegate (object obj, MouseEventArgs eventHandler)
            {
                Point pos = Cursor.Position;
                if (this.Bounds.Contains(pos))
                    TextDiagnostic1 = FindControlAtPoint(this, this.PointToClient(pos)).Name;

                if (pictureBox.Parent == itemForCopy.Parent)
                {
                    //pictureBox.Dispose(); return;
                }

            };
            //SendMessage(Button1.Handle, (uint)WindowMessages.WM_LBUTTONUP, 0, 0);

            itemForCopy.DoDragDrop(pictureBox.Name, DragDropEffects.Copy);

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

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            List<Control> listControl = new List<Control>();
            string allControls = GetAllInnerControlsFor(this);

            string GetAllInnerControlsFor(Control control)
            {
                StringBuilder allControlNames = new StringBuilder(control.Name);
                foreach (Control innerControl in control.Controls)
                {
                    allControlNames.AppendLine(GetAllInnerControlsFor(innerControl));
                    listControl.Add(innerControl);
                }
                return allControlNames.ToString();
            }


            for (int x=-3; x<3; x++) 
            {
                for (int y = -3; y < 3; y++)
                {
                    foreach(Control item in listControl) 
                    {
                        if(item is PictureBox)//Classes.MyUserControl) 
                        {

                        }
                        System.Drawing.Point itemLoc =PointToScreen(new Point(item.Location.X + x, item.Location.Y + y)) ;
                        System.Drawing.Point CursorLocation = PointToScreen(new Point(Cursor.Position.X + x, Cursor.Position.Y + y));

                        if (this.PointToClient(item.Location) == this.PointToClient(new Point(Cursor.Position.X+x, Cursor.Position.Y+y))) 
                        {

                        }
                    }
                }
            }

            //Point pos = Cursor.Position;
            //if (this.Bounds.Contains(pos))
            //   TextDiagnostic1= FindControlAtPoint(this, this.PointToClient(pos)).Name;
           

        }
        public static Control FindControlAtPoint(Control container, Point pos)
        {
            Control child;
            foreach (Control c in container.Controls)
            {
                if (c.Visible && c.Bounds.Contains(pos))
                {
                    child = FindControlAtPoint(c, new Point(pos.X - c.Left, pos.Y - c.Top));
                    if (child == null) return c;
                    else return child;
                }
            }
            return null;
        }

        private void panel1_DragEnter_1(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void Form1_ControlAdded(object sender, ControlEventArgs e)
        {

        }
    }
}
