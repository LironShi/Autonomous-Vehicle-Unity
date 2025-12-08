using UnityEngine;

namespace DetectedObject
{
    public class DetectedObjectData
    {
        public string ObjectName { get; private set; }
        public string ObjectType { get; private set; }
        public Vector3 WorldPosition { get; private set; }
        public float TimeDetected { get; private set; }
        public string InfoMessage
        {
            get
            {
                return $"Detected '{ObjectName}' at position {WorldPosition} after {TimeDetected} seconds.";
            }
        }

        public DetectedObjectData(Collider collider)
        {
            ObjectName = collider.gameObject.name;
            ObjectType = collider.gameObject.tag;
            WorldPosition = collider.transform.position;
            TimeDetected = Time.time;
        }
    }
}
