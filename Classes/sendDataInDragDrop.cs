using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generateContentForInstructionSimonov.Classes
{
    public class sendDataInDragDrop
    {
        public sendDataInDragDrop(object objSend, Type type)
        {
            ObjSend = objSend;
            Type = type;
        }

        public object ObjSend { get; set; }
        public Type Type { get; set; }

    }
}
