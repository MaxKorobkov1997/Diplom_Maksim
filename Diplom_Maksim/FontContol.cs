
using diplom;

namespace Diplom_Maksim
{
    internal class FontContol
    {
        public void SetAllControlsFont(Control.ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl.Controls != null)
                    SetAllControlsFont(ctrl.Controls);

                ctrl.Font = Static.font;

            }
        }
    }
}
