using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace generateContentForInstructionSimonov.Classes
{
    public class GetCursor
    {
        public GetCursor()
        {
        }
        public static Cursor _getCursor(Bitmap bitmap = null, Image image = null)
        {
            if (bitmap == null) { if (image != null) { bitmap = new Bitmap(image); } else { return System.Windows.Forms.Cursors.Default; }  }
            
            Icon icon = Icon.FromHandle(bitmap.GetHicon());

            Cursor cursor = new Cursor(icon.Handle);
            Cursor.Current = cursor;

            return cursor;
        }
    }
}
