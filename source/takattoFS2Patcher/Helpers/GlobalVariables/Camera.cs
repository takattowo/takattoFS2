using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace takattoFS2.Helpers.GlobalVariables
{
    [Serializable]
    public class Camera
    {
        private Camera() { }
        private static Camera _camDefault = null;
        private static Camera _cam = null;
        public static Camera CameraInstance
        {
            get
            {
                if (_cam == null)
                    _cam = new Camera();

                return _cam;
            }
        }
        public static Camera DefaultCameraInstance
        {
            get
            {
                if (_camDefault == null)
                    _camDefault = new Camera();

                return _camDefault;
            }
        }

        public float cameraMoveSpeed { get; set; } = 4;

        public float cameraLookAtSpeed { get; set; } = 4;

        public float cameraReplayFOV { get; set; } = (float)0.5;

        public string cameraAdvancedScript { get; set; }

        public List<CameraType> cameraList = new List<CameraType>();
    }

    [Serializable]
    public class CameraType
    {
        public int id { get; set; }

        public int overrideId { get; set; }

        public float fov { get; set; }

        public float posX { get; set; }

        public float posY { get; set; }

        public float posZ { get; set; }

        public float lookAtX { get; set; }

        public float lookAtY { get; set; }

        public float lookAtZ { get; set; }

        public bool ignoreAiringBall { get; set; }
        public bool absolutelyValue { get; set; }
        public string advancedScript { get; set; }
    }
}

