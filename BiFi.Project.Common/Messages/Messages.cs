using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BiFi.Project.Common.Messages
{
    public class Messages
    {
        public static void ErrorMessage(string errorMessage)
        {
            XtraMessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void WarningMessage(string warningMessage)
        {
            XtraMessageBox.Show(warningMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult NoSelectedYesNo(string message, string title)
        {
            return XtraMessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }
        public static DialogResult YesSelectedYesNoCancel(string message, string title)
        {
            return XtraMessageBox.Show(message, title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }
        public static DialogResult DeleteMessage(string recordName)
        {
            return NoSelectedYesNo($"The selected {recordName} will be deleted, Do you want to continue?", "Deletion Confirmation");
        }
        public static DialogResult ClosingMessage()
        {
            return YesSelectedYesNoCancel("Save changes made?", "Exit Confirmation");
        }
        public static DialogResult CreateMessage()
        {
            return NoSelectedYesNo("Save changes made?", "Registration Confirmation");
        }
        public static void NoRecordType()
        {
            WarningMessage("You did not select a Record!");
        }
    }
}
