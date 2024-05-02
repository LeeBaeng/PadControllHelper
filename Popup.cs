using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace PadControlHelper {
    public class Popup : Form {
        protected IPopupListener listener;
        public Popup(IPopupListener listener) : base(){
            this.listener = listener;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }
    }
}
