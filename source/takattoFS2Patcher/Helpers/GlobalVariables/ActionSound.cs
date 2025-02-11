using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace takattoFS2.Helpers.GlobalVariables
{
	internal class ActionSound
	{
        public static string default_path = @"Sound\\Action_SOUND";

        public static string body = @"
<ACTION>
  <ACTION_SOUND>
    <Sound_Name>SNSTEP</Sound_Name>
    <Sound_Path>[DEFAULT_PATH]\\ACT_STEP_01.mp3</Sound_Path>
    <Sound_Path>[DEFAULT_PATH]\\ACT_STEP_02.mp3</Sound_Path>
    <Sound_Path>[DEFAULT_PATH]\\ACT_STEP_03.mp3</Sound_Path>
  </ACTION_SOUND>
  <ACTION_SOUND>
    <Sound_Name>SNSKID</Sound_Name>
    <Sound_Path>[DEFAULT_PATH]\\ACT_SKID_01.mp3</Sound_Path>
    <Sound_Path>[DEFAULT_PATH]\\ACT_SKID_02.mp3</Sound_Path>
  </ACTION_SOUND>
  <ACTION_SOUND>
    <Sound_Name>SNCOLLISION</Sound_Name>
    <Sound_Path>[DEFAULT_PATH]\\ACT_COLLISION_01.mp3</Sound_Path>
    <Sound_Path>[DEFAULT_PATH]\\ACT_COLLISION_02.mp3</Sound_Path>
    <Sound_Path>[DEFAULT_PATH]\\ACT_COLLISION_03.mp3</Sound_Path>
  </ACTION_SOUND>
  <ACTION_SOUND>
    <Sound_Name>SNLANDING</Sound_Name>
    <Sound_Path>[DEFAULT_PATH]\\ACT_LANDING_01.mp3</Sound_Path>
    <Sound_Path>[DEFAULT_PATH]\\ACT_LANDING_02.mp3</Sound_Path>
    <Sound_Path>[DEFAULT_PATH]\\ACT_LANDING_03.mp3</Sound_Path>
  </ACTION_SOUND>
  <ACTION_SOUND>
    <Sound_Name>SNJUMP</Sound_Name>
    <Sound_Path>[DEFAULT_PATH]\\ACT_JUMP_01.mp3</Sound_Path>
    <Sound_Path>[DEFAULT_PATH]\\ACT_JUMP_02.mp3</Sound_Path>
  </ACTION_SOUND>
  <ACTION_SOUND>
    <Sound_Name>SNSTEAL</Sound_Name>
    <Sound_Path>[DEFAULT_PATH]\\ACT_STEAL_01.mp3</Sound_Path>
  </ACTION_SOUND>
  <ACTION_SOUND>
    <Sound_Name>SNBALLBOUNCE</Sound_Name>
    <Sound_Path>[DEFAULT_PATH]\\ACT_BOUNCE_01.mp3</Sound_Path>
    <Sound_Path>[DEFAULT_PATH]\\ACT_BOUNCE_02.mp3</Sound_Path>
    <Sound_Path>[DEFAULT_PATH]\\ACT_BOUNCE_03.mp3</Sound_Path>
  </ACTION_SOUND>
  <ACTION_SOUND>
    <Sound_Name>SNPASS</Sound_Name>
    <Sound_Path>[DEFAULT_PATH]\\ACT_PASS_01.mp3</Sound_Path>
    <Sound_Path>[DEFAULT_PATH]\\ACT_PASS_02.mp3</Sound_Path>
    <Sound_Path>[DEFAULT_PATH]\\ACT_PASS_03.mp3</Sound_Path>
  </ACTION_SOUND>
  <ACTION_SOUND>
    <Sound_Name>SNCATCH</Sound_Name>
	<Sound_Path>[DEFAULT_PATH]\\ACT_CATCH_01.mp3</Sound_Path>
	<Sound_Path>[DEFAULT_PATH]\\ACT_CATCH_02.mp3</Sound_Path>
	<Sound_Path>[DEFAULT_PATH]\\ACT_CATCH_03.mp3</Sound_Path>
 	<Sound_Path>[DEFAULT_PATH]\\ACT_CATCH_04.mp3</Sound_Path>
  </ACTION_SOUND>
  <ACTION_SOUND>
	  <Sound_Name>SNBLOCK</Sound_Name>
	  <Sound_Path>[DEFAULT_PATH]\\ACT_BLOCK_02.mp3</Sound_Path>
	</ACTION_SOUND>
<ACTION_SOUND>
	  <Sound_Name>SNCRIBLOCK</Sound_Name>
	  <Sound_Path>[DEFAULT_PATH]\\ACT_BLOCK_03.mp3</Sound_Path>
	</ACTION_SOUND>
  <ACTION_SOUND>
    <Sound_Name>SNBALLTOUCH</Sound_Name>
    <Sound_Path>[DEFAULT_PATH]\\ACT_BALLTOUCH_01.mp3</Sound_Path>
    <Sound_Path>[DEFAULT_PATH]\\ACT_BALLTOUCH_02.mp3</Sound_Path>
  </ACTION_SOUND>  
  <ACTION_SOUND>
    <Sound_Name>SNCROWDBOOHIGH</Sound_Name>
    <Sound_Path>[MUTE_PATH]\\CROWD_BOO_03.mp3</Sound_Path>
  </ACTION_SOUND>
  <ACTION_SOUND>
    <Sound_Name>SNCROWDBOOMIDDLE</Sound_Name>
    <Sound_Path>[MUTE_PATH]\\CROWD_BOO_02.mp3</Sound_Path>
  </ACTION_SOUND>
  <ACTION_SOUND>
    <Sound_Name>SNCROWDBOOLOW</Sound_Name>
    <Sound_Path>[MUTE_PATH]\\CROWD_BOO_01.mp3</Sound_Path>
  </ACTION_SOUND>
  <ACTION_SOUND>
    <Sound_Name>SNCROWDCHEERHIGH</Sound_Name>
    <Sound_Path>[MUTE_PATH]\\CROWD_CHEER_03.mp3</Sound_Path>
  </ACTION_SOUND>
  <ACTION_SOUND>
    <Sound_Name>SNCROWDCHEERMIDDLE</Sound_Name>
    <Sound_Path>[MUTE_PATH]\\CROWD_CHEER_02.mp3</Sound_Path>
  </ACTION_SOUND>
  <ACTION_SOUND>
    <Sound_Name>SNCROWDCHEERLOW</Sound_Name>
    <Sound_Path>[MUTE_PATH]\\CROWD_CHEER_01.mp3</Sound_Path>
  </ACTION_SOUND>
  <ACTION_SOUND>
    <Sound_Name>SNCROWDNORMAL</Sound_Name>
    <Sound_Path>[MUTE_PATH]\\CROWD_NORMAL_01.mp3</Sound_Path>
  </ACTION_SOUND>
  <ACTION_SOUND>
    <Sound_Name>SNCROWDDEF1</Sound_Name>
    <Sound_Path>[MUTE_PATH]\\CROWD_CHEER_01.mp3</Sound_Path>
  </ACTION_SOUND>
    <ACTION_SOUND>
    <Sound_Name>SNCROWDDEF2</Sound_Name>
    <Sound_Path>[MUTE_PATH]\\CROWD_DEFENCE_02.mp3</Sound_Path>
  </ACTION_SOUND>
    <ACTION_SOUND>
    <Sound_Name>SNCROWDDEFLOW</Sound_Name>
    <Sound_Path>[MUTE_PATH]\\CROWD_DEFENCE_0defer.mp3</Sound_Path>
  </ACTION_SOUND>
  <ACTION_SOUND>
    <Sound_Name>SNCROWDCOUNT10</Sound_Name>
    <Sound_Path>[MUTE_PATH]\\CROWD_COUNT01.mp3</Sound_Path>
  </ACTION_SOUND>
  <ACTION_SOUND>
    <Sound_Name>SNCROWDCOUNT9</Sound_Name>
    <Sound_Path>[MUTE_PATH]\\CROWD_COUNT02.mp3</Sound_Path>
  </ACTION_SOUND>
  <ACTION_SOUND>
    <Sound_Name>SNCROWDCOUNT8</Sound_Name>
    <Sound_Path>[MUTE_PATH]\\CROWD_COUNT03.mp3</Sound_Path>
  </ACTION_SOUND>
  <ACTION_SOUND>
    <Sound_Name>SNCROWDCOUNT7</Sound_Name>
    <Sound_Path>[MUTE_PATH]\\CROWD_COUNT04.mp3</Sound_Path>
  </ACTION_SOUND>
  <ACTION_SOUND>
    <Sound_Name>SNCROWDCOUNT6</Sound_Name>
    <Sound_Path>[MUTE_PATH]\\CROWD_COUNT05.mp3</Sound_Path>
  </ACTION_SOUND>
  <ACTION_SOUND>
    <Sound_Name>SNCROWDCOUNT5</Sound_Name>
    <Sound_Path>[MUTE_PATH]\\CROWD_COUNT06.mp3</Sound_Path>
  </ACTION_SOUND>
  <ACTION_SOUND>
    <Sound_Name>SNCROWDCOUNT4</Sound_Name>
    <Sound_Path>[MUTE_PATH]\\CROWD_COUNT07.mp3</Sound_Path>
  </ACTION_SOUND>
  <ACTION_SOUND>
    <Sound_Name>SNCROWDCOUNT3</Sound_Name>
    <Sound_Path>[MUTE_PATH]\\CROWD_COUNT08.mp3</Sound_Path>
  </ACTION_SOUND>
  <ACTION_SOUND>
    <Sound_Name>SNCROWDCOUNT2</Sound_Name>
    <Sound_Path>[MUTE_PATH]\\CROWD_COUNT09.mp3</Sound_Path>
  </ACTION_SOUND>
  <ACTION_SOUND>
    <Sound_Name>SNCROWDCOUNT1</Sound_Name>
    <Sound_Path>[MUTE_PATH]\\CROWD_COUNT10.mp3</Sound_Path>
  </ACTION_SOUND>

<!--                -->
  <ACTION_SOUND>
    <Sound_Name>SN_TY_CHEER</Sound_Name>
    <Sound_Path>[DEFAULT_PATH]\\SN_TY_CHEER_01.mp3</Sound_Path>
    <Sound_Path>[DEFAULT_PATH]\\SN_TY_CHEER_02.mp3</Sound_Path>
  </ACTION_SOUND>

  <ACTION_SOUND>
    <Sound_Name>SN_TY_CRY</Sound_Name>
    <Sound_Path>[DEFAULT_PATH]\\SN_TY_CRY_04.mp3</Sound_Path>
    <Sound_Path>[DEFAULT_PATH]\\SN_TY_CRY_05.mp3</Sound_Path>
  </ACTION_SOUND>

  <ACTION_SOUND>
    <Sound_Name>SN_TY_STEP_L</Sound_Name>
    <Sound_Path>[DEFAULT_PATH]\\SN_TY_STEP_01.mp3</Sound_Path>
  </ACTION_SOUND>
  <ACTION_SOUND>
    <Sound_Name>SN_TY_STEP_R</Sound_Name>
    <Sound_Path>[DEFAULT_PATH]\\SN_TY_STEP_02.mp3</Sound_Path>
  </ACTION_SOUND>

  <ACTION_SOUND>
    <Sound_Name>SN_TY_SLEEP</Sound_Name>
    <Sound_Path>[DEFAULT_PATH]\\SN_TY_SLEEP_04.mp3</Sound_Path>
  </ACTION_SOUND>

  <ACTION_SOUND>
    <Sound_Name>SN_TY_TALK</Sound_Name>
    <Sound_Path>[DEFAULT_PATH]\\SN_TY_TALK_01.mp3</Sound_Path>
    <Sound_Path>[DEFAULT_PATH]\\SN_TY_TALK_02.mp3</Sound_Path>
    <Sound_Path>[DEFAULT_PATH]\\SN_TY_TALK_03.mp3</Sound_Path>
    <Sound_Path>[DEFAULT_PATH]\\SN_TY_TALK_04.mp3</Sound_Path>
    <Sound_Path>[DEFAULT_PATH]\\SN_TY_TALK_05.mp3</Sound_Path>
  </ACTION_SOUND>

  <ACTION_SOUND>
    <Sound_Name>SN_TY_WALK_L</Sound_Name>
    <Sound_Path>[DEFAULT_PATH]\\SN_TY_WALK_01.mp3</Sound_Path>
  </ACTION_SOUND>
  <ACTION_SOUND>
    <Sound_Name>SN_TY_WALK_R</Sound_Name>
    <Sound_Path>[DEFAULT_PATH]\\SN_TY_WALK_02.mp3</Sound_Path>
  </ACTION_SOUND>
<!--              -->

</ACTION>";
	}


    
}