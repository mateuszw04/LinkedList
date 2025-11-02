using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class ListBoxScrollSync
    {
        // WinAPI constants
        private const int WM_VSCROLL = 0x115;
        private const int SB_THUMBPOSITION = 4;
        private const int SB_THUMBTRACK = 5;

        // WinAPI functions
        [DllImport("user32.dll")]
        private static extern int GetScrollPos(IntPtr hWnd, int nBar);

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private bool _syncingScroll = false;

        // Sync two listboxes
        public void SyncScroll(ListBox source, ListBox target)
        {
            if (_syncingScroll) return;
            _syncingScroll = true;

            // Get the vertical scroll position of the source ListBox
            int pos = GetScrollPos(source.Handle, 1);

            // Apply that scroll position to the target ListBox
            SendMessage(target.Handle, WM_VSCROLL, SB_THUMBPOSITION + 0x10000 * pos, 0);

            _syncingScroll = false;
        }

        // Attach the sync to the ListBox controls
        public void AttachSync(ListBox listBox1, ListBox listBox2)
        {
            listBox1.MouseWheel += (s, e) => SyncScroll(listBox1, listBox2);
            listBox2.MouseWheel += (s, e) => SyncScroll(listBox2, listBox1);

            // Optional: sync scroll during selected index change
            listBox1.SelectedIndexChanged += (s, e) => SyncScroll(listBox1, listBox2);
            listBox2.SelectedIndexChanged += (s, e) => SyncScroll(listBox2, listBox1);
        }
    }
}
