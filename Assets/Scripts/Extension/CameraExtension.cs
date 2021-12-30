using UnityEngine;

namespace Extension
{
    public static class CameraExtension 
    {
        public static Vector3 GetScreenBounds(this Camera camera)
        {
            return camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, camera.transform.position.z));
        }
    }
}
