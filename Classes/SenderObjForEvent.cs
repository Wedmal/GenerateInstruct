using System.Drawing;

namespace generateContentForInstructionSimonov.Classes
{
    public class SenderObjForEvent
    {
        public SenderObjForEvent(object objectEvent, Point locationCursorInObj)
        {
            ObjectEvent = objectEvent;
            LocationCursorInObj = locationCursorInObj;
        }

        public object ObjectEvent { get; set; }
        public System.Drawing.Point LocationCursorInObj { get; set; }

    }
}
