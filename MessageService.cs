using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desklean
{
    public interface IMessageService
    {
        void ShowMessage(string message);
        void ShowExclamation(string exclamation);
        void ShowError(string error);
        DialogResult ShowConfirmMessage(string message);
    }

    public class MessageService : IMessageService
    {

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public DialogResult ShowConfirmMessage(string message)
        {
            return MessageBox.Show(message, "Message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
        }
        public void ShowExclamation(string exclamation)
        {
            MessageBox.Show(exclamation, "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void ShowError(string error)
        {
            MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
