using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PadControlHelper {
    public interface IPopupListener {
        public void onPopupConfirmed(Popup popup, object data);
        public void onPopupCanceled(Popup popup);
    }
}
