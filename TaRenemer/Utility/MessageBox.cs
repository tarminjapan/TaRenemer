using System;
using System.Windows.Forms;

namespace TaRenemer
{
    public static class ShowMessageBox
    {
        /// <summary>
        /// Show Error MessageBox
        /// </summary>
        public static void Error(string message, string titile = "Error")
        {
            MessageBox.Show(message, titile, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Show Error MessageBox
        /// </summary>
        public static void Error(Exception ex, string title = "Error")
        {
            MessageBox.Show(ex.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Show Exclamation MessageBox
        /// </summary>
        public static void Exclamation(string message, string title = "Exclamation")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// Show Information MessageBox
        /// </summary>
        public static void Information(string message, string title = "Information")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Show YesNo MessageBox
        /// </summary>
        public static bool YesNo(string message, string title = "Question")
        {
            var result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }
    }
}