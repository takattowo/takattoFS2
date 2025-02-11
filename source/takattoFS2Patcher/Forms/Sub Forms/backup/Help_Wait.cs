using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using takattoFS2.Helpers;
using takattoFS2.Helpers.GlobalVariables;

namespace takattoFS2.Forms
{
    public partial class Help_Wait : Form
    {
        public Help_Wait()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Width, Screen.PrimaryScreen.WorkingArea.Height - Height - 10);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            ControlBox = false;
            MaximizeBox = false;
            MinimizeBox = false;

            Logger.Write("Game data is being revivified");
        }

        private void Help_Voice_Downloader_Load(object sender, EventArgs e)
        {
            Cursor = new Cursor(Properties.Resources.cur_1.GetHicon());
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            lb.Font = MemoryFonts.SetFont(0, lb.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            TopMost = true;

            lb.Text = StringLoader.GetText("lb_wait_restoring_data") + "\n";

            timer1.Interval = new Random().Next(10, 100);
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            RestoreGameData();
            this.Close();
        }
        
        private void RestoreGameData()
        {

            if (!Methods.IsValidFS2Path(Methods.GetGameFolder()) || Methods.IsGameRunning_Alt())
                return;

            Methods.TweakRestore();

            if (Methods.IsMCVoiceInstalled() && UserSettings.MCVoiceLanguage > 0)
                MainForm.mf.MCVoiceTweak();
            else if (Methods.IsLanguagePackInstalled() && UserSettings.GameFontSetting)
                Methods.Tweaks.StandalFontSwap();

            if (UserSettings.GameLogCleannerEnabled)
            {
                try
                {
                    File.Delete(Methods.GetFolder(Strings.FileName.Log1));
                    File.Delete(Methods.GetFolder(Strings.FileName.Log2));
                }
                catch (Exception msg) { Logger.Write(msg.Message); }
            }

           

            if (UserSettings.UITweakSetting)
            {
                try
                {
                    File.Delete(Methods.GetFolder(Strings.FolderName.UI, Strings.FileName.UILib));
                }
                catch { }
            }

            if (UserSettings.CustomInteface)
                Methods.Tweaks.InterfaceTweak(false);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //if (Methods.IsGameRunning())
            //    Methods.KillGame();

            lb.Text = lb.Text.Replace(".", "..");
            lb.Text = lb.Text.Replace("...........", ".");
        }
    }
}
