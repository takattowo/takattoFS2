using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace takattoFS2.Helpers.GlobalVariables
{
	internal class EnvSound
    {
        public static string default_path = @"Sound\\Env_SOUND";

        public static string body = @"
<ENV>
  <ENV_SOUND>
    <Sound_Name>SNENV_BOUNCE</Sound_Name>
    <Sound_Path>[DEFAULT_PATH]\\ENV_LOOSEBALL_BOUND_01.mp3</Sound_Path>
    <Sound_Path>[DEFAULT_PATH]\\ENV_LOOSEBALL_BOUND_02.mp3</Sound_Path>
    <Sound_Path>[DEFAULT_PATH]\\ENV_LOOSEBALL_BOUND_03.mp3</Sound_Path>
  </ENV_SOUND>
  <ENV_SOUND>
    <Sound_Name>SNENV_RIMBOUNCE</Sound_Name>
    <Sound_Path>[DEFAULT_PATH]\\ENV_RIM_BOUNCE_01.mp3</Sound_Path>
    <Sound_Path>[DEFAULT_PATH]\\ENV_RIM_BOUNCE_02.mp3</Sound_Path>
    <Sound_Path>[DEFAULT_PATH]\\ENV_RIM_BOUNCE_03.mp3</Sound_Path>
  </ENV_SOUND>
  <ENV_SOUND>
    <Sound_Name>SNENV_BACKBOARD</Sound_Name>
    <Sound_Path>[DEFAULT_PATH]\\ENV_RIM_BACKBOARD_01.mp3</Sound_Path>
    <Sound_Path>[DEFAULT_PATH]\\ENV_RIM_BACKBOARD_02.mp3</Sound_Path>
  </ENV_SOUND>
  <ENV_SOUND>
    <Sound_Name>SNENV_RIMTHROUGH</Sound_Name>
    <Sound_Path>[DEFAULT_PATH]\\ENV_RIM_THROUGH_01.mp3</Sound_Path>
    <Sound_Path>[DEFAULT_PATH]\\ENV_RIM_THROUGH_02.mp3</Sound_Path>
    <Sound_Path>[DEFAULT_PATH]\\ENV_RIM_THROUGH_03.mp3</Sound_Path>
  </ENV_SOUND>
  <ENV_SOUND>
    <Sound_Name>SNENV_RANDOM</Sound_Name>
    <Sound_Path>[DEFAULT_PATH]\\ENV_RANDOM_01.mp3</Sound_Path>
  </ENV_SOUND>
  <ENV_SOUND>
    <Sound_Name>SNENV_EFFECT</Sound_Name>
    <Sound_Path>[DEFAULT_PATH]\\ENV_BOUNCE_01.mp3</Sound_Path>
    <Sound_Path>[DEFAULT_PATH]\\ENV_BOUNCE_02.mp3</Sound_Path>
    <Sound_Path>[DEFAULT_PATH]\\ENV_BOUNCE_03.mp3</Sound_Path>
  </ENV_SOUND>
  <ENV_SOUND>
    <Sound_Name>SNDUNKIN</Sound_Name>
    <Sound_Path>[DEFAULT_PATH]\\ACT_DUNKIN_01.mp3</Sound_Path>
    <Sound_Path>[DEFAULT_PATH]\\ACT_DUNKIN_02.mp3</Sound_Path>
    <Sound_Path>[DEFAULT_PATH]\\ACT_DUNKIN_03.mp3</Sound_Path>
  </ENV_SOUND>
  <ENV_SOUND>
    <Sound_Name>SNDUNKOUT</Sound_Name>
    <Sound_Path>[DEFAULT_PATH]\\ACT_DUNKOUT_01.mp3</Sound_Path>
    <Sound_Path>[DEFAULT_PATH]\\ACT_DUNKOUT_02.mp3</Sound_Path>
  </ENV_SOUND>
</ENV>";
	}
  
}