using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Reflection;
using System.Drawing;

namespace Desklean
{



    public class MainPresenter
    {

        private static Logger logger = LogManager.GetCurrentClassLogger();

        private readonly IMainForm _mainForm;
        private readonly IMessageService _messageService;
        private readonly IFileLogic _fileLogic;
        private readonly IucSettings _ucSettings;
        private readonly IucHelp _ucHelp;
        private readonly IucHome _ucHome;

        private Timer _timer = new Timer();
        private FileSystemWatcher _fileSystemWatcher = new FileSystemWatcher();
        private BackgroundWorker _backgroundWorker = new BackgroundWorker();
        private NotifyIcon _notifyIcon = new NotifyIcon();

        Assembly _assembly;
        Stream _imageStream;


        private List<Queue> _queueList = new List<Queue>();




        private List<int> _itemsToRemove = new List<int>();



        string _format = "{0,-60}| {1,-60}| {2,-20}";

        public MainPresenter(IMainForm mainForm, IMessageService messageService, IFileLogic fileLogic, IucSettings ucSettings, IucHome ucHome, IucHelp ucHelp)
        {
            _mainForm = mainForm;
            _messageService = messageService;   
            _fileLogic = fileLogic;
            _ucSettings = ucSettings;
            _ucHelp = ucHelp;
            _ucHome = ucHome;


            _timer.Tick += _timer_Tick;

            _backgroundWorker.DoWork += _backgroundWorker_DoWork;
            _mainForm.MainFormClosing += _mainForm_MainFormClosing;
            _mainForm.MainFormLoad += _mainForm_MainFormLoad;

            _ucHome.BtnStartClick += _ucHome_BtnStartClick;
            _ucHome.BtnStopClick += _ucHome_BtnStopClick;
            _ucHome.BtnRemoveClick += _ucHome_BtnRemoveClick;
            
            _fileSystemWatcher.Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); //configura o diretorio para FSW
            _fileSystemWatcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName; //configurar o tipo de alterações
            _fileSystemWatcher.Created += FileSystemWatcher_Created; //chama um evento quando encontra novo ficheiro
            _fileSystemWatcher.Deleted += _fileSystemWatcher_Deleted; //chama um envento quando um ficheiro é apagado
            _fileSystemWatcher.Renamed += _fileSystemWatcher_Renamed; //chama um evento quando um ficheiro é renomeado

            _notifyIcon.BalloonTipClicked += _notifyIcon_BalloonTipClicked;
            _notifyIcon.Click += _notifyIcon_Click;
            _assembly = Assembly.GetExecutingAssembly();
            _imageStream = _assembly.GetManifestResourceStream("Desklean.Icon2.ico");
            _notifyIcon.Icon = new Icon(_imageStream);
            _notifyIcon.Visible = true;
            _notifyIcon.Text = "Desklean";

        }


        private void _ucHome_BtnRemoveClick(object sender, EventArgs e)
        {
            string text = _ucHome.Item;
            if (text != null)
            {
                string[] array = _fileLogic.SplitPath(text, '|');
                _itemsToRemove.Add(_queueList.FindIndex(a => a.source == array[0].Trim()));
                _ucHome.RemoveFromListbox(text);
            }
        }

        private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            logger.Trace("Backgroundworker start");
            try
            {
                logger.Trace("Start cycling list");

                foreach (Queue queue in _queueList)
                {
                    logger.Trace("Check if {0} >= {1}", DateTime.Now, queue.moveTime);
                    if (DateTime.Now >= queue.moveTime)
                    {
                        string source = queue.source;
                        if (_fileLogic.DirExists(source) || _fileLogic.FileExists(source))
                        {
                            string dest = queue.dest;
                            try
                            {
                                if (!queue.isDirectory)
                                {
                                    logger.Trace("Is file");
                                    _fileLogic.IsReadOnly(source);
                                    logger.Trace("Moving file");
                                    _fileLogic.MoveFile(source, dest);
                                    logger.Info("File {0} moved sucessfully", source);
                                }
                                else
                                {
                                    logger.Trace("Is directory");
                                    logger.Trace("Moving directory");
                                    _fileLogic.MoveDirectory(source, dest);
                                    logger.Info("Directory {0} moved sucessfully", source);
                                }
                            }
                            catch (System.IO.IOException)
                            {
                                logger.Error("Error file is open in other program");
                                DateTime moveTime = MoveTimeCalculation("Minutos", 10);
                                _queueList.Add(new Queue(queue.isDirectory, queue.source, queue.dest, moveTime));
                                logger.Trace("New item added to queue");
                            }
                        }
                        else
                        {
                            logger.Trace("File or directory {0} renamed or deleted", source);
                        }
                        
                    }
                }
                
                logger.Trace("Cycle list finished");
                

          

            logger.Trace("Removing items");

            _itemsToRemove.Sort((a, b) => -1 * a.CompareTo(b));

            foreach (int index in _itemsToRemove)
            {
                _ucHome.RemoveFromListbox(string.Format(_format, _queueList[index].source, _queueList[index].dest, _queueList[index].moveTime));
                _queueList.RemoveAt(index);
            }

            _itemsToRemove.Clear();

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + ex);
            }
        }

        private void _notifyIcon_Click(object sender, EventArgs e)
        {
            _mainForm.ShowFromTray();
        }

        private void _notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            //logger.Trace("Balloon clicked");
            //_itemsToRemove.Add(_queueList.IndexOf(_queueList.Last()));
        }

        private void _fileSystemWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            for (int i = 0; i < _queueList.Count; i++)
            {
                if (e.OldFullPath == _queueList[i].source)
                {
                    _ucHome.RemoveFromListbox(string.Format(_format, _queueList[i].source, _queueList[i].dest, _queueList[i].moveTime));
                    _queueList[i].source = e.FullPath;
                    int cont1 = _queueList[i].dest.Length;
                    int cont = e.OldName.Length;
                    cont1 = cont1 - cont;
                    _queueList[i].dest = _queueList[i].dest.Remove(cont1);
                    _queueList[i].dest += e.Name;
                    _ucHome.AddToListbox(string.Format(_format, _queueList[i].source, _queueList[i].dest, _queueList[i].moveTime));
                }
            }
        }

        private void _fileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            foreach (Queue queue in _queueList)
            {
                if (e.FullPath == queue.source)
                {
                    _itemsToRemove.Add(_queueList.IndexOf(queue));
                }
            }
        }
        private void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {

            string source = e.FullPath;
            logger.Info("{source} detected", source);
            try
            {
                string dest = Settings.TargetDirPath + "\\" + e.Name;
                double addTime = Convert.ToDouble(Settings.AddTime);
                string timeType = Settings.TimeType;
                DateTime moveTime = MoveTimeCalculation(timeType, addTime);
                bool isDirectory = _fileLogic.IsDirectory(source);
                logger.Trace("getting ext");
                string extention = _fileLogic.GetExtention(dest);
                logger.Trace("ext = "+extention);
                bool success = false;


                if (isDirectory && Settings.MoveFolders)
                {
                    success = true;
                }
                else if (!isDirectory && !IsRestriction(extention))
                {
                    if (Settings.CreateSubfolders)
                    {
                        logger.Trace("Create subfolder flag true");
                        if (!extention.Contains("C:"))
                        {
                            dest = Settings.TargetDirPath + "\\" + extention + " Files\\";
                            bool dirExists = _fileLogic.DirExists(dest);
                            logger.Trace("Check if {0} dir exists", dest);
                            if (!dirExists)
                            {
                                logger.Trace("Creating {0}", dest);
                                Directory.CreateDirectory(dest);
                            }
                            dest += e.Name;
                        }
                    }
                    success = true;
                }

                if (success == true)
                {
                    _queueList.Add(new Queue(isDirectory, source, dest, moveTime));

                    logger.Info("Queue updated {0}|{1}|{2}|{3}", isDirectory.ToString(), source, dest, moveTime);
                    _ucHome.AddToListbox(string.Format(_format, _queueList.Last().source, _queueList.Last().dest, _queueList.Last().moveTime));
                    if (Settings.SendNotifications)
                    {
                        ShowBalloonTip("Novo Ficheiro", "Novo ficheiro \" " + e.Name + " \" detetado.");
                    }
                }

            }
            catch (Exception ex)
            {
                _messageService.ShowError(ex.Message);
                logger.Error("Error {0}", ex.Message);
            }

        }
        public void ShowBalloonTip(string title, string message)
        {
            _notifyIcon.ShowBalloonTip(20, title, message, ToolTipIcon.Info);
        }
        private void _ucHome_BtnStopClick(object sender, EventArgs e)
        {
            logger.Info("Button stop click");
            Stop();
            logger.Info("Program stop");
        }
        private void _ucHome_BtnStartClick(object sender, EventArgs e)
        {
            logger.Info("Button start click");
            string curPath = Settings.TargetDirPath;

            logger.Trace("Check if target dir exists");
            if (!_fileLogic.DirExists(curPath))
            {
                try
                {
                    Directory.CreateDirectory(curPath);
                }
                catch
                {
                    logger.Error("Target {0} is invalid", curPath);
                    _messageService.ShowExclamation("Ocorreu um erro ao carregar Diretório de destino! Por favor selecione a diretória manualmente");
                    curPath = "";
                }

            }
            else
            {
                logger.Trace("Iniciar FIleSystemWatcher");
                FswStart();
                logger.Trace("Iniciar Timer");
                TimerStart();
                logger.Info("Programa iniciado");
            }

        }
        private void TimerStart()
        {
            _timer.Interval = Settings.TimerInterval * 1000;
            _timer.Enabled = true;
        }
        private void TimerStop()
        {
            _timer.Enabled = false;
        }
        private void FswStart()
        {
            _fileSystemWatcher.EnableRaisingEvents = true;
        }
        private void FswStop()
        {
            _fileSystemWatcher.EnableRaisingEvents = false;
        }
        private void BackgroundWorkerStart()
        {
            if (!_backgroundWorker.IsBusy)
                _backgroundWorker.RunWorkerAsync();
        }
        private void _timer_Tick(object sender, EventArgs e)
        {
            logger.Trace("Timer tick");
            if (_queueList.Any())
            {
                BackgroundWorkerStart();
            }
        }
        private void _mainForm_MainFormShown(object sender, EventArgs e)
        {
            if (Settings.Autorun)
            {
                _mainForm.HideToTray();
            }
        }
        private void _mainForm_MainFormLoad(object sender, EventArgs e)
        {
            logger.Info("Iniciar programa...");
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Desklean";
            logger.Trace("Ver se o caminho {path} existe", path);
            if (!_fileLogic.DirExists(path))
            {
                logger.Trace("{path} não existe", path);
                logger.Trace("Criando diretoria");
                Directory.CreateDirectory(path);
            }
            else
            {
                logger.Trace("{path} já existe", path);
            }


            string settingsPath = path + "\\DeskleanSettings.json";
            logger.Trace("Checking if {path} exists", settingsPath);
            Settings _settings = new Settings();

            if (_fileLogic.FileExists(settingsPath))
            {
                logger.Trace("{path} is exists", settingsPath);
                try
                {
                    _settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(settingsPath));
                }
                catch (Exception ex)
                {
                    _messageService.ShowError(ex.Message);
                    LoadDefaultSettings();
                }
                _settings.SetStatic();
            }
            else
            {

                logger.Trace("{path} not exists", settingsPath);
                logger.Trace("Loading default settings");
                LoadDefaultSettings();

            }
            string queuePath = path + "\\DeskleanQueue.json";

            logger.Trace("Checking if {path} exists", queuePath);
            if (_fileLogic.FileExists(queuePath))
            {
                logger.Trace("{path} is exists", queuePath);
                logger.Trace("Loading queue from file");
                string json = File.ReadAllText(queuePath);
                logger.Trace("Load queue to list");
                _queueList = JsonConvert.DeserializeObject<List<Queue>>(json);
            }
            else
            {
                logger.Trace("{path} not exists", queuePath);
            }

            logger.Trace("Check if list have data");
            if (_queueList.Any())
            {
                logger.Trace("List have data");

                for (int i = 0; i < _queueList.Count; i++)
                {

                    if (!_fileLogic.DirExists(_queueList[i].source) && !_fileLogic.FileExists(_queueList[i].source))
                    {

                        _queueList.Remove(_queueList[i]);
                        logger.Trace("Removing");
                        i--;

                    }

                }
            }

            if (!_queueList.Any())
            {
                File.Delete(queuePath);
            }
            else
            {
                foreach (Queue queue in _queueList)
                {
                    _ucHome.AddToListbox(string.Format(_format, queue.source, queue.dest, queue.moveTime));
                }
            }
            _ucHome.Start();
            logger.Info("Form loaded");
        }
        private void LoadDefaultSettings()
        {
            Settings.AddTime = 6;
            //_settings.Restrictions = "pfd".Split(new char[] { ',' }).ToList();
            Settings.TimeType = "Minutos";
            Settings.MoveFolders = true;
            Settings.CreateSubfolders = true;
            Settings.MoveShortcuts = false;
            Settings.Autorun = false;
            Settings.SendNotifications = false;
            string deskleanPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Desklean";
            if (!_fileLogic.DirExists(deskleanPath))
            {
                try
                {
                    Directory.CreateDirectory(deskleanPath);
                }
                catch
                {
                    _messageService.ShowExclamation("Ocorreu um erro ao carregar Diretório de destino! Por favor selecione a diretória manualmente");
                }

            }
            Settings.TargetDirPath = deskleanPath;
            Settings.TimerInterval = 1;
        }
        private void Stop()
        {
            FswStop();
            TimerStop();
        }
        private void _mainForm_MainFormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Stop();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Desklean\\DeskleanSettings.json";
            logger.Trace("Converting settings to JSON");
            Settings _settings = new Settings();
            _settings.SetNonStatic();
            File.WriteAllText(path, JsonConvert.SerializeObject(_settings, Formatting.Indented));
            logger.Trace("settings writed");
            if (_queueList.Any())
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Desklean\\DeskleanQueue.json";
                string json = JsonConvert.SerializeObject(_queueList, Formatting.Indented);
                File.WriteAllText(path, json);
            }

            _notifyIcon.Visible = false;
            logger.Info("Form closed");
            LogManager.Shutdown();
        }

        DateTime MoveTimeCalculation(string timeType, double addTime)
        {
            DateTime moveTime = new DateTime();
            switch (timeType)
            {
                case "Segundos":
                    moveTime = DateTime.Now.AddSeconds(addTime);
                    break;
                case "Minutos":
                    moveTime = DateTime.Now.AddMinutes(addTime);
                    break;
                case "Horas":
                    moveTime = DateTime.Now.AddHours(addTime);
                    break;
                case "Dias":
                    moveTime = DateTime.Now.AddDays(addTime);
                    break;
            }
            return moveTime;
        }


        private bool IsRestriction(string extention)
        {
            
            if (!Settings.MoveShortcuts && extention == "lnk")
            {
                return true;
            }
            else
            {
                foreach (string ext in Settings.Restrictions)
                {
                    if (ext == extention)
                    {
                       
                        return true;
                    }
                }

            }
            return false;
        }
    }
}
