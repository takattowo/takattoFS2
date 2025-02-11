using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace takattoFS2.Helpers.GlobalVariables
{
	internal class CameraScript
	{
		public static string body_absolutely = @"
	cameraPosX = [camPX]
	cameraPosY = [camPY]
	cameraPosZ = [camPZ]
	cameraLookAtX = [camLX]  
	cameraLookAtY = [camLY] 
	cameraLookAtZ = [camLZ]
";
		//expression
		//cameraPosX
		//cameraPosZ
		//cameraLookAtZ
		public static string body_basic = @"
	if charPosX >= 600 then
		cameraPosX = [camPX] - 400
	elseif charPosX < 600 then
		cameraPosX = [camPX] + charPosX - 1000
	else
		cameraPosX = [camPX] - 600 
	end	

	cameraPosY = [camPY]
	cameraPosZ = [camPZ] + charPosZ

	if cameraPosZ >= 250 then
		cameraPosZ = [camPZ] + 250
	elseif cameraPosZ <= -250 then
		cameraPosZ = [camPZ] - 250
	else
		cameraPosZ = [camPZ] + charPosZ
	end
	
	
	cameraLookAtX = [camLX]  
	cameraLookAtY = [camLY] 
	cameraLookAtZ = [camLZ] + charPosZ 
	
	--[[
	if ballPosY > 1000 then	
		cameraLookAtY = [camLY]
	elseif ballPosY >= 680 then
		cameraLookAtY = [camLY] + 300
	elseif ballPosY >= 380 then
		cameraLookAtY = [camLY] + ballPosY - 380
	elseif ballPosY < 380 then
		cameraLookAtY = [camLY]
	else
		cameraLookAtY = [camLY]
	end
	--]]

	if charPosZ >= 250 then
		cameraLookAtZ = [camLZ] + 250
		elseif charPosZ <= -250 then
		cameraLookAtZ = [camLZ] - 250
		else
		cameraLookAtZ = [camLZ] + charPosZ
	end
";
		//posX
		//posZ
		//lookZ
		//lookY
		public static string body_high = @"
	if charPosX >= 300 then
		cameraPosX = [camPX] - 600
	elseif charPosX < 300 then
		cameraPosX = [camPX] + charPosX - 900
	else
		cameraPosX = [camPX] - 600 
	end	

	cameraPosY = [camPY] 

	cameraPosZ = [camPZ] + charPosZ*0.9 

	cameraLookAtX = [camLX] 
	cameraLookAtZ = [camLZ] + charPosZ 

	
	cameraLookAtY = [camLY] + charPosX*0.125
	
	if charPosZ >= 150 then
		cameraLookAtZ = [camLZ] + 150
		elseif charPosZ <= -150 then
		cameraLookAtZ = [camLZ] - 150
		else
		cameraLookAtZ = [camLZ] + charPosZ
	end
";
		//posX
        //posZ
        //lookZ
		public static string body_follow = @"
	if charPosX >= 300 then
		cameraPosX = [camPX] - 400
	elseif charPosX < 300 then
		cameraPosX = [camPX] + charPosX - 700
	else
		cameraPosX = [camPX] + charPosX - 600
	end	

	cameraPosY = [camPY]
	cameraPosZ = [camPZ] + charPosZ*1.1
	cameraLookAtX = [camLX]
	cameraLookAtY = [camLY]
	cameraLookAtZ = [camLZ] + charPosZ*0.5
";
		//posZ
        //lookX
        //lookZ
		public static string body_side = @"
	cameraPosX = [camPX]
	cameraPosY = [camPY]
	
	if charPosZ <= -500 then
		cameraPosZ = [camPZ] + charPosZ - 800
	elseif charPosZ > -500 then
		cameraPosZ = [camPZ] - 1300
	else
		cameraPosZ = [camPZ] - 1300
	end	
	
	cameraLookAtY = [camLY]

	if charPosX >= 300 then
		cameraLookAtX= [camLX] + 700 --900
	elseif charPosX < 300 then
		cameraLookAtX = [camLX] + charPosX + 400 --600
	else
		cameraLookAtX = [camLX] + 1000
	end

	--[[
	if ballPosY >= 680 then
		cameraLookAtY = [camLY] + 300
	elseif ballPosY >= 380 then
		cameraLookAtY = [camLY] + ballPosY - 280
	elseif ballPosY < 380 then
		cameraLookAtY = [camLY] + 100
	else
		cameraLookAtY = [camLY]
	end
	--]]

	if charPosZ >= -400 then
		cameraLookAtZ = [camLZ] + 100
	elseif charPosZ < -400 then
		cameraLookAtZ = [camLZ] + charPosZ + 500
	else 
		cameraLookAtZ = [camLZ] + 100
	end
";
		//posX
        //posZ
        //lookZ
		public static string body_sky = @"
	if charPosX >= 300 then
		cameraPosX = [camPX] - 600
	elseif charPosX < 300 then
		cameraPosX = [camPX] + charPosX - 900
	else
		cameraPosX = [camPX] - 600 
	end	

	cameraPosY = [camPY]
	cameraPosZ = [camPZ] + charPosZ

	if cameraPosZ >=350 then
		cameraPosZ = [camPZ] + 350
	elseif cameraPosZ <= -350 then
		cameraPosZ = [camPZ] - 350
	else
		cameraPosZ = [camPZ] + charPosZ
	end
	cameraLookAtX = [camLX]
	cameraLookAtY = [camLY]

	cameraLookAtZ = [camLZ] + charPosZ 

	--[[
	if ballPosY >= 680 then
		cameraLookAtY = [camLY] + 300
	elseif ballPosY >= 380 then
		cameraLookAtY = [camLY] + ballPosY - 380
	elseif ballPosY < 380 then
		cameraLookAtY = [camLY]
	else
		cameraLookAtY = [camLY]
	end
	--]]

	if charPosZ >= 350 then
		cameraLookAtZ = [camLZ] + 350
	elseif charPosZ <= -350 then
		cameraLookAtZ = [camLZ] - 350
	else
		cameraLookAtZ = [camLZ] + charPosZ
	end
";

		public static string main_script = @"
-- Ä«¸Þ¶ó
function Get_Camera_Replay_FOV()
	return [replayFov]
end

function Get_Camera_Default_FOV()
	return [basicFov]
end

function Get_Camera_Parametric_FOV()
	return [highFov]
end

function Get_Camera_ParametricNear_FOV()
	return [followFov]
end

function Get_Camera_Press_FOV()
	return [sideFov]
end

function Get_Camera_Top_FOV()
	return [skyFov]
end

function Get_Camera_Back_FOV()
	return 0.5
end

function Get_Camera_Move_Velocity()
	return [camSpeed]
end

function Get_Camera_LookAt_Velocity()
	return [lookSpeed]
end

function Get_Lua_DefaultTargetCamera(charPosX, charPosY, charPosZ)
	if charPosX >= 600 then
		cameraPosX = -400
		elseif charPosX < 600 then
		cameraPosX = charPosX - 1000
		else
		cameraPosX = -600 
	end	

	cameraPosY = 650
	cameraPosZ = charPosZ
	
	cameraLookAtX = 1000 
	cameraLookAtY = 0
	cameraLookAtZ = charPosZ 

	if charPosX >= 900 then
		cameraLookAtX= 1000
		elseif charPosX >= 500 then
		cameraLookAtX = 1000
		else
		cameraLookAtX = 1000
	end

	return cameraPosX, cameraPosY, cameraPosZ, cameraLookAtX, cameraLookAtY, cameraLookAtZ
end

function Get_Lua_DefaultCamera(charPosX, charPosY, charPosZ, ballPosX, ballPosY, ballPosZ, rimPosX, rimPosY, rimPosZ)
	-- ·è
	[body_basic]

[body_basic_script]

	return cameraPosX, cameraPosY, cameraPosZ, cameraLookAtX, cameraLookAtY, cameraLookAtZ
end

function Get_Lua_ParametricCamera(charPosX, charPosY, charPosZ, ballPosX, ballPosY, ballPosZ, rimPosX, rimPosY, rimPosZ)
	-- ·è
	[body_high]

[body_high_script]

	return cameraPosX, cameraPosY, cameraPosZ, cameraLookAtX, cameraLookAtY, cameraLookAtZ
end

function Get_Lua_ParametricNearCamera(charPosX, charPosY, charPosZ, ballPosX, ballPosY, ballPosZ, rimPosX, rimPosY, rimPosZ)
	-- ·è
	[body_follow]

[body_follow_script]

	return cameraPosX, cameraPosY, cameraPosZ, cameraLookAtX, cameraLookAtY, cameraLookAtZ
end

function Get_Lua_PressCamera(charPosX, charPosY, charPosZ, ballPosX, ballPosY, ballPosZ, rimPosX, rimPosY, rimPosZ)
	-- ·è
	[body_side]

[body_side_script]

	return cameraPosX, cameraPosY, cameraPosZ, cameraLookAtX, cameraLookAtY, cameraLookAtZ
end

function Get_Lua_TopCamera(charPosX, charPosY, charPosZ, ballPosX, ballPosY, ballPosZ, rimPosX, rimPosY, rimPosZ)
	-- ·è
	[body_sky]

[body_sky_script]

	return cameraPosX, cameraPosY, cameraPosZ, cameraLookAtX, cameraLookAtY, cameraLookAtZ
end

function Get_Lua_BackCamera(charPosX, charPosY, charPosZ, ballPosX, ballPosY, ballPosZ, rimPosX, rimPosY, rimPosZ)
	return cameraPosX, cameraPosY, cameraPosZ, cameraLookAtX, cameraLookAtY, cameraLookAtZ
end

function Get_Camera_Zoomin_Param_Looseball(inCharSN)
	return 0.0, 0.0, 0.0
end

function Get_Camera_Zoomin_Param_Dunk(inCharSN)
	return 1.2, 0.4, 130.0
end

function Get_Camera_Zoomin_Param_OpenJumpShoot(inCharSN)
	return 0.0, 0.0, 0.0
end

[body_advanced_script]
";
	}
}
