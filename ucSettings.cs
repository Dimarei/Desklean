using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using NLog;

namespace Desklean
{
    public interface IucSettings
    {
        void SetSettings();
    }



    public partial class ucSettings : UserControl, IucSettings
    {
        private readonly IMessageService _messageService;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public ucSettings(IMessageService messageService)
        {
            InitializeComponent();
            _messageService = messageService;
            Layout += UcSettings_Layout;

        }


        private void UcSettings_Layout(object sender, LayoutEventArgs e)
        {
            SetSettings();
        }

        public void SetSettings()
        {

            numAddTime.Value = Settings.AddTime;
            listRestr.Items.Clear();
            if (Settings.Restrictions != null)
            {
                listRestr.Items.AddRange(Settings.Restrictions.ToArray());
            }

            comboTimeType.Text = Settings.TimeType;
            chkMoveFolders.Checked = Settings.MoveFolders;
            chkCreateSubfolders.Checked = Settings.CreateSubfolders;
            chkAutorun.Checked = Settings.Autorun;
            chkSendNotofications.Checked = Settings.SendNotifications;
            fldTargetDir.Text = Settings.TargetDirPath;
            numTimeInterval.Value = Settings.TimerInterval;
            chkMoveShortcuts.Checked = Settings.MoveShortcuts;

        }
        public void SaveSettings()
        {
            Settings.AddTime = Convert.ToInt32(numAddTime.Value);
            Settings.Restrictions = listRestr.Items.Cast<String>().ToList();
            Settings.TimeType = comboTimeType.Text;
            Settings.MoveFolders = chkMoveFolders.Checked;
            Settings.CreateSubfolders = chkCreateSubfolders.Checked;
            Settings.Autorun = chkAutorun.Checked;
            Settings.SendNotifications = chkSendNotofications.Checked;
            Settings.TargetDirPath = fldTargetDir.Text;
            Settings.TimerInterval = Convert.ToInt32(numTimeInterval.Value);
            Settings.MoveShortcuts = chkMoveShortcuts.Checked;
            try
            {
                if (Settings.Autorun == true)
                {
                    RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    rk.SetValue("Desklean", Application.ExecutablePath.ToString());
                    logger.Info("Autorun enabled");
                }
                else
                {
                    RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    rk.DeleteValue("Desklean", false);
                    logger.Info("Autorun disabled");
                }
            }
            catch (Exception ex)
            {
                _messageService.ShowError(ex.Message);
                logger.Error("Error {0}", ex.Message);
            }

        }

        private void btnSelectDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                fldTargetDir.Text = fbd.SelectedPath;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
            _messageService.ShowMessage("Config guardado com sucesso!");
        }
        private void tbExt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd_Click(this, EventArgs.Empty);
            }
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            var selected = listRestr.SelectedItem;
            listRestr.Items.Remove(selected);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbExt.Text != "" && tbExt.Text != null)
            {
                listRestr.Items.Add(tbExt.Text);
            } 
            tbExt.Text = null;
        }
    }
}
