using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LinkedList
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        private bool _syncingSelection = false;
        Lista l = new Lista();
        private ListBoxScrollSync scrollSync = new ListBoxScrollSync();



        public Form1()
        {

            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AllocConsole();


            listBox1.DataSource = l.ToArray();

            // Populate index list
            UpdateIndexList();
            UpDownIndex.Minimum = 0;
            UpDownIndex.Maximum = l.liczbaElementów;
            scrollSync.AttachSync(listBox1, listBox2);
        }

        private void btnPo_Click(object sender, EventArgs e)
        {
            int index = (int)UpDownIndex.Value;
            int value = (int)UpDownValue.Value;


            l.DodajPo(index, value);

            UpDownIndex.Maximum = l.liczbaElementów;

            RefreshListBoxes();
        }

        private void btnPrzed_Click_1(object sender, EventArgs e)
        {
            int index = (int)UpDownIndex.Value;
            int value = (int)UpDownValue.Value;


            l.DodajPrzed(index, value);

            UpDownIndex.Maximum = l.liczbaElementów;

            RefreshListBoxes();
        }

        private void RefreshListBoxes()
        {

            listBox1.DataSource = null;
            listBox1.DataSource = l.ToArray();

            UpdateIndexList();


        }

        private void UpdateIndexList()
        {
            listBox2.Items.Clear();
            for (int i = 0; i < l.liczbaElementów; i++)
            {
                listBox2.Items.Add(i);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_syncingSelection) return; // Prevent recursion
            _syncingSelection = true;

            if (listBox1.SelectedIndex >= 0 && listBox1.SelectedIndex < listBox2.Items.Count)
            {
                listBox2.SelectedIndex = listBox1.SelectedIndex;
            }

            _syncingSelection = false;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_syncingSelection) return; // Prevent recursion
            _syncingSelection = true;

            if (listBox2.SelectedIndex >= 0 && listBox2.SelectedIndex < listBox1.Items.Count)
            {
                listBox1.SelectedIndex = listBox2.SelectedIndex;
            }

            _syncingSelection = false;
            UpDownIndex.Value = listBox2.SelectedIndex;
        }

    }




}
