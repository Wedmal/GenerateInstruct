using System.Windows.Forms;

namespace generateContentForInstructionSimonov.Sorters
{
    /// <summary>
    /// Распологает компоненты квадратной сеткой. 
    /// Порядок расположения случайным образом/имя/id (пока не придумал где хранить ID для всех контролов)
    /// </summary>
    public class Square_bond
    {
        public static Control sort_Square(Control input_control)
        {


            foreach (Control item in input_control.Controls)
            {
                if (item is Classes.MyUserControl)
                {
                    var tmp = item.Parent;
                }
            }

            return input_control;
        }
    }
}
