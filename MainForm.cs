using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Desklean
{
    public interface IMainForm
    {
    
        void HideToTray();
        void ShowFromTray();
        event CancelEventHandler MainFormClosing;
        event EventHandler MainFormLoad;
        event EventHandler MainFormShown;
        
    }
    public partial class MainForm : Form, IMainForm
    {
        private readonly ucSettings _ucSettings;
        private readonly ucHelp _ucHelp;
        private readonly ucHome _ucHome;

        public MainForm(ucSettings settings, ucHome home, ucHelp help)
        {
            InitializeComponent();

            _ucSettings = settings;
            _ucHome = home;
            _ucHelp = help;
            
            Load += MainForm_Load;
            Shown += MainForm_Shown;
            Resize += MainForm_Resize;
            FormClosing += MainForm_FormClosing;

            pictureBox3_Click(this, EventArgs.Empty);
        }

        
        

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (!panel1.Controls.Contains(_ucSettings))
            {
                panel1.Controls.Add(_ucSettings);
                _ucSettings.Dock = DockStyle.Fill;
                
            }
            _ucSettings.BringToFront();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(_ucHome))
            {
                panel1.Controls.Add(_ucHome);
                _ucHome.Dock = DockStyle.Fill;
                
            }
            _ucHome.BringToFront();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(_ucHelp))
            {
                panel1.Controls.Add(_ucHelp);
                _ucHelp.Dock = DockStyle.Fill;
                
            }
            _ucHelp.BringToFront();
        }
        
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }
        public void HideToTray()
        {
            Hide();
        }
        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (MainFormShown != null)
            {
                MainFormShown(this, EventArgs.Empty);
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
           
            if (MainFormLoad != null)
            {
                MainFormLoad(this, EventArgs.Empty);

            }

        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (MainFormClosing != null)
            {
                MainFormClosing(this, e);
                
            }
        }
        public void ShowFromTray()
        {
            Show();
            WindowState = FormWindowState.Normal;
        }
        public event CancelEventHandler MainFormClosing;
        public event EventHandler MainFormLoad;
        public event EventHandler MainFormShown;

        private void MainForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
