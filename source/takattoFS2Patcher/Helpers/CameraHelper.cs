using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using takattoFS2.Helpers.GlobalVariables;
using static takattoFS2.Helpers.GlobalVariables.Strings;

namespace takattoFS2.Helpers
{
    internal class CameraHelper
    {
        //string basic_config = "cam;override;fov;camX;camY;CamZ;lookX;lookY;lookZ;ignore_ball";
        internal static Camera cam;
        internal static Camera cam_default;

        internal static void Save()
        {
            UserSettings.CameraTweakSettingConfigs = JsonConvert.SerializeObject(cam);
            Logger.Write("Camera settings have been saved");
        }

        internal static void RenderCameraSetting()
        {
            cam = Camera.CameraInstance;
            cam_default = Camera.DefaultCameraInstance;
            if (string.IsNullOrEmpty(UserSettings.CameraTweakSettingConfigs))
            {
                CameraTweak(false);
                return;
            }
            try
            {
                //cam = (Camera)JsonConvert.DeserializeObject(UserSettings.CameraTweakSettingConfigs);
                cam = JsonConvert.DeserializeObject<Camera>(UserSettings.CameraTweakSettingConfigs);

                CameraTweak(true);
            }
            catch (Exception e) {
                Logger.Write(e.ToString());
                CameraTweak(false); 
            }
        }

        internal static void CameraTweak(bool generateDefaultOnly)
        {
            var basic_cam = new CameraType();
            basic_cam.id = 1;
            basic_cam.overrideId = 0;
            basic_cam.fov = (float)0.5;
            basic_cam.posX = 0;
            basic_cam.posY = 650;
            basic_cam.posZ = 0;
            basic_cam.lookAtX = 1000;
            basic_cam.lookAtY = 0;
            basic_cam.lookAtZ = 0;

            var high_cam = new CameraType();
            high_cam.id = 2;
            high_cam.overrideId = 0;
            high_cam.fov = (float)0.5;
            high_cam.posX = 0;
            high_cam.posY = 700;
            high_cam.posZ = 0;
            high_cam.lookAtX = 800;
            high_cam.lookAtY = 0;
            high_cam.lookAtZ = 0;

            var follow_cam = new CameraType();
            follow_cam.id = 3;
            follow_cam.overrideId = 0;
            follow_cam.fov = (float)0.5;
            follow_cam.posX = 0;
            follow_cam.posY = 500;
            follow_cam.posZ = 0;
            follow_cam.lookAtX = 800;
            follow_cam.lookAtY = 150;
            follow_cam.lookAtZ = 0;

            var side_cam = new CameraType();
            side_cam.id = 4;
            side_cam.overrideId = 0;
            side_cam.fov = (float)0.7;
            side_cam.posX = 1000;
            side_cam.posY = 530;
            side_cam.posZ = 0;
            side_cam.lookAtX = 0;
            side_cam.lookAtY = 0;
            side_cam.lookAtZ = 0;

            var sky_cam = new CameraType();
            sky_cam.id = 5;
            sky_cam.overrideId = 0;
            sky_cam.fov = (float)0.5;
            sky_cam.posX = 0;
            sky_cam.posY = 900;
            sky_cam.posZ = 0;
            sky_cam.lookAtX = 800;
            sky_cam.lookAtY = 0;
            sky_cam.lookAtZ = 0;

            //cam = Camera.CameraInstance;

            //add all above to Camera._cam.cameraList

            cam_default.cameraList.Add(basic_cam);
            cam_default.cameraList.Add(high_cam);
            cam_default.cameraList.Add(follow_cam);
            cam_default.cameraList.Add(side_cam);
            cam_default.cameraList.Add(sky_cam);

            if (generateDefaultOnly)
                return;

            cam = cam_default;
            Save();
        }
        
        internal static string BodyScript(CameraType camtype)
        {
            if (camtype.absolutelyValue)             
                return ReturnBodyScript(69);
            else if (camtype.overrideId > 0)
                return ReturnBodyScript(camtype.overrideId);
            else
                return ReturnBodyScript(camtype.id);
        }
        
        internal static void ApplyCamera()
        {
            // get cams
            var basic_cam = cam.cameraList.FirstOrDefault(x => x.id == 1);
            var high_cam = cam.cameraList.FirstOrDefault(x => x.id == 2);
            var follow_cam = cam.cameraList.FirstOrDefault(x => x.id == 3);
            var side_cam = cam.cameraList.FirstOrDefault(x => x.id == 4);
            var sky_cam = cam.cameraList.FirstOrDefault(x => x.id == 5);   

            string script = CameraScript.main_script;
            script = script.Replace("[replayFov]", cam.cameraReplayFOV.ToString().Replace(",", "."));
            script = script.Replace("[basicFov]", basic_cam.fov.ToString().Replace(",", "."));
            script = script.Replace("[highFov]", high_cam.fov.ToString().Replace(",", "."));
            script = script.Replace("[followFov]", follow_cam.fov.ToString().Replace(",", "."));
            script = script.Replace("[sideFov]", side_cam.fov.ToString().Replace(",", "."));
            script = script.Replace("[skyFov]", sky_cam.fov.ToString().Replace(",", "."));
            script = script.Replace("[backFov]", "0.5");
            script = script.Replace("[camSpeed]", cam.cameraMoveSpeed.ToString().Replace(",", "."));
            script = script.Replace("[lookSpeed]", cam.cameraLookAtSpeed.ToString().Replace(",", "."));

            string body = BodyScript(basic_cam);
            script = script.Replace("[body_basic]", ReturnAppliedBodyScript(body, basic_cam));
            script = script.Replace("[body_basic_script]", basic_cam.advancedScript);

            body = BodyScript(high_cam);
            script = script.Replace("[body_high]", ReturnAppliedBodyScript(body, high_cam));
            script = script.Replace("[body_high_script]", high_cam.advancedScript);

            body = BodyScript(follow_cam);
            script = script.Replace("[body_follow]", ReturnAppliedBodyScript(body, follow_cam));
            script = script.Replace("[body_follow_script]", follow_cam.advancedScript);

            body = BodyScript(side_cam);
            script = script.Replace("[body_side]", ReturnAppliedBodyScript(body, side_cam));
            script = script.Replace("[body_side_script]", side_cam.advancedScript);

            body = BodyScript(sky_cam);
            script = script.Replace("[body_sky]", ReturnAppliedBodyScript(body, sky_cam));
            script = script.Replace("[body_sky_script]", sky_cam.advancedScript);   
            script = script.Replace("[body_advanced_script]", cam.cameraAdvancedScript);

            // write
      
            try
            {
                Methods.MakeSureFolderExists(Methods.GetFolder(FolderName.Camera));
                KATEncryptor.ConvertBFromString(script, Methods.GetFolder(FolderName.Camera, FileName.CameraLub));

                Methods.MoveFile(Methods.GetFolder(FileName.Script),
                               Methods.GetFolder("temp_" + FileName.Script), true);

                if (File.Exists(Methods.GetFolder("temp_" + FileName.Script)))
                    Methods.WriteBytes(false, Methods.GetFolder(FileName.Script), "", FileName.CameraLub);
                else
                    throw new Exception("No backup for script.pak detected.");

                Methods.MegaHideFile(Methods.GetFolder(FolderName.Camera));

                Logger.Write("Camera tweak applied");
            }
            catch (Exception msg) { Logger.Write(msg.ToString()); }
            finally
            {
                script = null;
            }
        }

        internal static string ReturnAppliedBodyScript(string bodyscipt, CameraType _cam)
        {
            bodyscipt = bodyscipt.Replace("[camPX]", _cam.posX.ToString().Replace(",", "."));
            bodyscipt = bodyscipt.Replace("[camPY]", _cam.posY .ToString().Replace(",", "."));
            bodyscipt = bodyscipt.Replace("[camPZ]", _cam.posZ.ToString().Replace(",", "."));
            bodyscipt = bodyscipt.Replace("[camLX]", _cam.lookAtX.ToString().Replace(",", "."));
            bodyscipt = bodyscipt.Replace("[camLY]", _cam.lookAtY.ToString().Replace(",", "."));
            bodyscipt = bodyscipt.Replace("[camLZ]", _cam.lookAtZ.ToString().Replace(",", "."));

            if(!_cam.ignoreAiringBall)
            {
                bodyscipt = bodyscipt.Replace("--[[", null);
                bodyscipt = bodyscipt.Replace("--]]", null);
            }
            
            return bodyscipt;
        }

        internal static string ReturnBodyScript(int id)
        {
            switch (id)
            {
                case 1:
                    return CameraScript.body_basic;
                case 2:
                    return CameraScript.body_high;
                case 3:
                    return CameraScript.body_follow;
                case 4:
                    return CameraScript.body_side;
                case 5:
                    return CameraScript.body_sky;
                case 69:
                    return CameraScript.body_absolutely;
                default:
                    return string.Empty;
            }
         }
    }
}
