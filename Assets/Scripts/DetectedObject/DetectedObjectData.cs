using UnityEngine;

public class DetectedObjectData
{
    public string ObjectName { get; private set; }
    public string ObjectType { get; private set; }
    public Vector3 WorldPosition { get; private set; }
    public float TimeDetected { get; private set; }

    public DetectedObjectData(Collider collider)
    {
        ObjectName = collider.gameObject.name;
        ObjectType = collider.gameObject.tag;
        WorldPosition = collider.transform.position;
        TimeDetected = Time.time;
    }
    public override string ToString()
    {
        return $"Name: {ObjectName}, Type: {ObjectType}, Position: {WorldPosition}, Detected At: {TimeDetected}";
    }
    
}
