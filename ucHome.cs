using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desklean
{
    public interface IucHome
    {
        void Start();
        void AddToListbox(string text);
        void RemoveFromListbox(string text);
        bool Working { get; set; }
        string Item { get; }
        event EventHandler BtnStartClick;
        event EventHandler BtnStopClick;
        event EventHandler BtnRemoveClick;
    }
    public partial class ucHome : UserControl, IucHome
    {
        public string Item
        {
            get
            {   if(listBox1.SelectedItem != null) {
                return listBox1.SelectedItem.ToString();
                }
                else
                {
                    return null;
                }
            }
        }

        private List<Queue> _queueList = new List<Queue>();
        public bool Working { get; set; }

        public ucHome()
        {
            InitializeComponent();
            Working = false;
            btnStart.Click += BtnStart_Click;
            removeFromlist.Click += RemoveFromlist_Click;
            
        }

        private void RemoveFromlist_Click(object sender, EventArgs e)
        {
             BtnRemoveClick(this, EventArgs.Empty);
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (Working == true)
            {
                Stop();
            }
            else
            {
                Start();
            }



        }
        public void Stop()
        {
            Working = false;
            btnStart.Image = Desklean.Properties.Resources.start;
            BtnStopClick(this, EventArgs.Empty);
        }
        public void Start()
        {
            Working = true;
            btnStart.Image = Desklean.Properties.Resources.stop;
            BtnStartClick(this, EventArgs.Empty);
        }

        public event EventHandler BtnStartClick;
        public event EventHandler BtnStopClick;
        public event EventHandler BtnRemoveClick;

        private void ucHome_Load(object sender, EventArgs e)
        {
            
        }

        public delegate void UpdateListboxDelegate();

        string _text;

        public void AddToListbox(string text)
        {
            _text = text;
            InvokeUpdateControls(AddListbox);
        }

        public void RemoveFromListbox(string text)
        {
            _text = text;
            InvokeUpdateControls(RemoveListbox);
        }

        public void InvokeUpdateControls(UpdateListboxDelegate method)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(method);
            }
            else
            {
                method();
            }
        }

        private void AddListbox()
        {
            listBox1.Items.Add(_text);
        }
        private void RemoveListbox()
        {
            listBox1.Items.Remove(_text);
        }
    }
}
