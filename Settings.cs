using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desklean
{

    class Settings
    {
       
        public int _addTime { get; set; }
        public List<string> _restrictions { get; set; }
        public string _timeType { get; set; }
        public bool _moveFolders { get; set; }
        public bool _createSubfolders { get; set; }
        public bool _moveShortcuts { get; set; }
        public bool _autorun { get; set; }
        public bool _sendNotifications { get; set; }
        public string _targetDirPath { get; set; }
        public int _timerInterval { get; set; }

        public static int AddTime { get; set; }
        public static List<string> Restrictions { get; set; }
        public static string TimeType { get; set; }
        public static bool MoveFolders { get; set; }
        public static bool CreateSubfolders { get; set; }
        public static bool MoveShortcuts { get; set; }
        public static bool Autorun { get; set; }
        public static bool SendNotifications { get; set; }
        public static string TargetDirPath { get; set; }
        public static int TimerInterval { get; set; }

        public void SetStatic()
        {
            AddTime = _addTime;
            Restrictions = _restrictions;
            TimeType = _timeType;
            MoveFolders = _moveFolders;
            CreateSubfolders = _createSubfolders;
            MoveShortcuts = _moveShortcuts;
            Autorun = _autorun;
            SendNotifications = _sendNotifications;
            TargetDirPath = _targetDirPath;
            TimerInterval = _timerInterval;
        }

        public void SetNonStatic()
        {
            _addTime = AddTime;
            _restrictions = Restrictions;
            _timeType = TimeType;
            _moveFolders = MoveFolders;
            _createSubfolders = CreateSubfolders;
            _moveShortcuts = MoveShortcuts;
            _autorun = Autorun;
            _sendNotifications = SendNotifications;
            _targetDirPath = TargetDirPath;
            _timerInterval = TimerInterval;
        }
    }
}
