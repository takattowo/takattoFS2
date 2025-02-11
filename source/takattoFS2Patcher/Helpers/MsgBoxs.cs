using System.Windows.Forms;

namespace takattoFS2.Helpers
{
    internal sealed class MsgBoxs
    {
        internal sealed class Warning
        {
            internal static void MaximumCharacterAllowed(int maximumChar, Form form)
            {
                var msg = StringLoader.GetText("msg_error_maximumchar", maximumChar.ToString());
                var title = StringLoader.GetText("msgtitle_error");
                Logger.Write("Replace value could not exceed " + maximumChar.ToString() + " characters.");
                MessageBoxEx.Show(form, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            internal static void FailedToCreatePath(string error)
            {
                var msg = StringLoader.GetText("msg_fail_to_create_path");
                var title = StringLoader.GetText("msgtitle_ewk");
                Logger.Write("Could not create patcher folder. Kat-code: " + error);
                MessageBoxEx.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            internal static void NoSampleSoundExist(Form form)
            {
                var msg = StringLoader.GetText("msg_no_sound_sample");
                var title = StringLoader.GetText("msgtitle_ewk");
                MessageBoxEx.Show(form, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            internal static void UIConflict(Form form)
            {
                var msg = StringLoader.GetText("msg_ui_conflict");
                var title = StringLoader.GetText("msgtitle_ewk");
                MessageBoxEx.Show(form, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            internal static void NoSoundLibExist(Form form)
            {
                var msg = StringLoader.GetText("msg_no_sound_lib");
                var title = StringLoader.GetText("msgtitle_ewk");
                Logger.Write(msg);
                MessageBoxEx.Show(form, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            internal static void IncorrectParametter(Form form)
            {
                var msg = StringLoader.GetText("msg_incorrect_parametter");
                var title = StringLoader.GetText("msgtitle_known_bug_but_lazy");
                MessageBoxEx.Show(form, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            internal static void Error(Form form, string error)
            {
                var msg = StringLoader.GetText("msg_error", error);
                var title = StringLoader.GetText("msgtitle_error");
                Logger.Write(msg);
                MessageBoxEx.Show(form, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            internal static void DownloadError(Form form)
            {
                var msg = StringLoader.GetText("msg_download_error");
                var title = StringLoader.GetText("msgtitle_error");
                Logger.Write(msg);
                MessageBoxEx.Show(form, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            internal static void Error(string error)
            {
                var msg = StringLoader.GetText("msg_error", error);
                var title = StringLoader.GetText("msgtitle_error");
                Logger.Write(msg);
                MessageBoxEx.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            internal static void UserIsOffline()
            {
                var msg = StringLoader.GetText("msg_user_offline");
                var title = StringLoader.GetText("msgtitle_no_connection");
                //MessageBoxEx.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

            }

            internal static void ServerError()
            {
                var msg = StringLoader.GetText("msg_server_failure");
                var title = StringLoader.GetText("msgtitle_error");

                MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                //MessageBoxEx.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            internal static void ServerErrorCustom()
            {
                var msg = StringLoader.GetText("msg_server_failure_custom");
                var title = StringLoader.GetText("msgtitle_error");

                MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                //MessageBoxEx.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            internal static void ProgramIsDisabled()
            {
                var msg = StringLoader.GetText("msg_program_disabled");
                var title = StringLoader.GetText("msgtitle_contact_me");
                //MessageBoxEx.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }

            internal static void FailedToFetch(Form form)
            {
                var msg = StringLoader.GetText("msg_failed_to_fetch");
                var title = StringLoader.GetText("msgtitle_oh_no");
                MessageBoxEx.Show(form, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            internal static void CloseFS2InstanceFirst()
            {
                var msg = StringLoader.GetText("msg_game_need_to_close");
                var title = StringLoader.GetText("msgtitle_future_improve");
                MessageBoxEx.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            internal static void CloseGameFirst(Form form)
            {
                var msg = StringLoader.GetText("msg_close_game_first");
                var title = StringLoader.GetText("msgtitle_random1");
                MessageBoxEx.Show(form, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            internal static void PatchFailedToUninstall(Form form, string st)
            {
                var msg = StringLoader.GetText("msg_failed_to_uninstall_patch", st);
                var title = StringLoader.GetText("msgtitle_a_bug");
                MessageBoxEx.Show(form, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            internal static void MissingField(Form form)
            {
                var msg = StringLoader.GetText("msg_field_missing");
                var title = StringLoader.GetText("msgtitle_null_value");
                MessageBoxEx.Show(form, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            internal static void InvalidValue(Form form)
            {
                var msg = StringLoader.GetText("msg_field_invalid");
                var title = StringLoader.GetText("msgtitle_check_again");
                MessageBoxEx.Show(form, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            internal static void InvalidFolder(Form form)
            {
                var msg = StringLoader.GetText("msg_folder_invalid");
                var title = StringLoader.GetText("msgtitle_try_again");
                MessageBoxEx.Show(form, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            internal static void InvalidAFKTInterval(Form form)
            {
                var msg = StringLoader.GetText("msg_invalid_afk_interval");
                var title = StringLoader.GetText("msgtitle_quote_51");
                MessageBoxEx.Show(form, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            internal static void MaximumItemsSelected(Form form, int n)
            {
                var msg = StringLoader.GetText("msg_maximum_item_reached", n);
                var title = StringLoader.GetText("msgtitle_quote_21");
                MessageBoxEx.Show(form, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            internal static void ConditionNotMatch(Form form)
            {
                var msg = StringLoader.GetText("msg_service_authorization_error");
                var title = StringLoader.GetText("msgtitle_not_authorized");
                MessageBoxEx.Show(form, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal sealed class Information
        {
            internal static void RestartRequired(Form form)
            {
                var msg = StringLoader.GetText("msg_please_restart_program_language");
                var title = StringLoader.GetText("msgtitle_quote_21");
                MessageBoxEx.Show(form, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            internal static void HasBeenCopiedToClipBoard(Form form, string st)
            {
                var msg = StringLoader.GetText("msg_has_coppied", st);
                var title = StringLoader.GetText("msgtitle_it_works");
                MessageBoxEx.Show(form, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            internal static void SettingsHasBeenImported(Form form)
            {
                var msg = StringLoader.GetText("msg_has_imported");
                var title = StringLoader.GetText("msgtitle_it_works");
                MessageBoxEx.Show(form, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            internal static void PatchHasBeenApplied(Form form, string st)
            {
                var msg = StringLoader.GetText("msg_path_has_applied", st);
                var title = StringLoader.GetText("msgtitle_no_need_to_do");
                MessageBoxEx.Show(form, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            internal static void SongHasBeenAdded(Form form, string st)
            {
                var msg = StringLoader.GetText("msg_song_has_added", st);
                var title = StringLoader.GetText("msgtitle_it_works");
                Logger.Write($"\"{st}\" has been added to Jukebox");
                MessageBoxEx.Show(form, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            internal static void SongHasBeenRemoved(Form form, string st)
            {
                var msg = StringLoader.GetText("msg_song_has_deleted", st);
                var title = StringLoader.GetText("msgtitle_it_works");
                Logger.Write($"\"{st}\" has been removed from Jukebox");
                MessageBoxEx.Show(form, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            internal static void RequiredToWork(Form form, string st)
            {
                var msg = StringLoader.GetText("msg_item_required", st);
                var title = StringLoader.GetText("msgtitle_um");
                MessageBoxEx.Show(form, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            internal static void NoItemSelected(Form form)
            {
                var msg = StringLoader.GetText("msg_no_item_selected");
                var title = StringLoader.GetText("msgtitle_random4");
                MessageBoxEx.Show(form, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            internal static void DownloadCancelled(Form form)
            {
                var msg = StringLoader.GetText("msg_download_cancelled");
                var title = StringLoader.GetText("msgtitle_error");
                MessageBoxEx.Show(form, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            internal static void Installed(Form form, string st)
            {
                var msg = StringLoader.GetText("msg_has_installed", st);
                var title = StringLoader.GetText("msgtitle_random2");
                Logger.Write($"\"{st}\" has been installed");
                MessageBoxEx.Show(form, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            internal static void Uninstalled(Form form, string st)
            {
                var msg = StringLoader.GetText("msg_has_uninstalled", st);
                var title = StringLoader.GetText("msgtitle_random2");
                MessageBoxEx.Show(form, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            internal static void NewProgramUpdate()
            {
                var msg = StringLoader.GetText("msg_patcher_has_new_version");
                var title = StringLoader.GetText("msgtitle_rawk");
                MessageBoxEx.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            internal static void NewProgramUpdateBase()
            {
                var msg = StringLoader.GetText("msg_patcher_has_new_version_og");
                var title = StringLoader.GetText("msgtitle_rawk");
                MessageBoxEx.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            internal static void AtleastOneFieldRequired(Form form)
            {
                var msg = StringLoader.GetText("msg_two_fields_needed");
                var title = StringLoader.GetText("msgtitle_quote_31");
                MessageBoxEx.Show(form, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            internal static void CleannedUp(Form form, int num)
            {
                var msg = StringLoader.GetText("msg_has_cleanned_up", num);
                if (num <= 0)
                    msg = StringLoader.GetText("msg_has_cleanned_up_but_nothing_cleanned");

                var title = StringLoader.GetText("msgtitle_processing_done");
                MessageBoxEx.Show(form, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        internal sealed class Dialog
        {
            internal static DialogResult CancelTask(Form form)
            {
                var msg = StringLoader.GetText("msgdiag_task_is_running");
                var title = StringLoader.GetText("msgtitle_question");
                return MessageBoxEx.Show(form, msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }

            internal static DialogResult WantToDiscard(Form form)
            {
                var msg = StringLoader.GetText("msgdiag_unsaved_changes");
                var title = StringLoader.GetText("msgtitle_want_to_continue");
                return MessageBoxEx.Show(form, msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }

            internal static DialogResult WantToSeeTutorial(Form form)
            {
                var msg = StringLoader.GetText("msgdiag_tutorial");
                var title = StringLoader.GetText("msgtitle_um");
                return MessageBoxEx.Show(form, msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }

            internal static DialogResult WantToResetOverridedCamSetting(Form form)
            {
                var msg = StringLoader.GetText("msgdiag_cam_tweak_override_reset");
                var title = StringLoader.GetText("msgtitle_want_to_continue");
                return MessageBoxEx.Show(form, msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }

            internal static DialogResult WantToResetAllSetting(Form form)
            {
                var msg = StringLoader.GetText("msgdiag_cam_tweak_all_reset");
                var title = StringLoader.GetText("msgtitle_want_to_continue");
                return MessageBoxEx.Show(form, msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }

            internal static DialogResult GameFolderNotFound(Form form)
            {
                var msg = StringLoader.GetText("msgdiag_game_folder_not_found");
                var title = StringLoader.GetText("msgtitle_game_folder_not_found");
                return MessageBoxEx.Show(form, msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }

            internal static DialogResult ClosePatcher(Form form, bool isCentered)
            {
                var msg = StringLoader.GetText("msgdiag_close_patcher");
                var title = StringLoader.GetText("msgtitle_random2");

                if (!isCentered)
                    return MessageBoxEx.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                return MessageBoxEx.Show(form, msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            internal static DialogResult ForceRunningBrowserLauncher(Form form)
            {
                var msg = StringLoader.GetText("msgdiag_force_game_web_launcher");
                var title = StringLoader.GetText("msgtitle_random2");
                return MessageBoxEx.Show(form, msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }

            internal static DialogResult UpdateDLC5(Form form)
            {
                var msg = StringLoader.GetText("msgdiag_tweak_character_voice_update");
                var title = StringLoader.GetText("msgtitle_random3");
                return MessageBoxEx.Show(form, msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }

            internal static DialogResult ReinstallJukebox(Form form)
            {
                var msg = StringLoader.GetText("msgdiag_tweak_jukebox_reinstall");
                var title = StringLoader.GetText("msgtitle_tweak_jukebox_reinstall");
                return MessageBoxEx.Show(form, msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }

            internal static DialogResult RemoveSongFromJukebox(Form form, string st)
            {
                var msg = StringLoader.GetText("msgdiag_tweak_jukebox_remove_song", st);
                var title = StringLoader.GetText("msgtitle_random1");
                return MessageBoxEx.Show(form, msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }

            internal static DialogResult RemoveExtension(Form form, string st)
            {
                var msg = StringLoader.GetText("msgdiag_tweak_extension_remove", st);
                var title = StringLoader.GetText("msgtitle_random1");
                return MessageBoxEx.Show(form, msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }

            internal static DialogResult CourtSwitch(Form form)
            {
                var msg = StringLoader.GetText("msgdiag_tweak_court_type_switch");
                var title = StringLoader.GetText("msgtitle_no_bully");
                return MessageBoxEx.Show(form, msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }

            internal static DialogResult Uninstall(Form form)
            {
                var msg = StringLoader.GetText("msgdiag_uninstall");
                var title = StringLoader.GetText("msgtitle_no_bully");
                return MessageBoxEx.Show(form, msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }

            internal static DialogResult Uninstall(Form form, string st)
            {
                var msg = StringLoader.GetText("msgdiag_uninstall_item", st);
                var title = StringLoader.GetText("msgtitle_random2");
                return MessageBoxEx.Show(form, msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }

            internal static DialogResult Reinstall(Form form)
            {
                var msg = StringLoader.GetText("msgdiag_reinstall_or_update");
                var title = StringLoader.GetText("msgtitle_no_bully");
                return MessageBoxEx.Show(form, msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }

            internal static DialogResult EnableLogging(Form form)
            {
                var msg = StringLoader.GetText("msgdiag_logging_disabled");
                var title = StringLoader.GetText("msgtitle_question");
                return MessageBoxEx.Show(form, msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }

            internal static DialogResult InstallStrafePatch(Form form)
            {
                var msg = StringLoader.GetText("msgdiag_install_strage");
                var title = StringLoader.GetText("msgtitle_question");
                return MessageBoxEx.Show(form, msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            internal static DialogResult EnableCustomInterface(Form form)
            {
                var msg = StringLoader.GetText("msg_tweak_custominterface_q");
                var title = StringLoader.GetText("msgtitle_um");
                return MessageBoxEx.Show(form, msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
        }     
    }
}
