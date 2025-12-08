using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Sensor
{
    public class BasicCameraSensor : MonoBehaviour
    {
        public float detectionRadius = 20f;
        public LayerMask detectionLayer;
        
        private static readonly int NumberOfObjectsToDetect = 20;
        private readonly Collider[] _colliders = new Collider[NumberOfObjectsToDetect];
        
        private Camera _camera;
        private Plane[] _frustumPlanes;
        
        private HashSet<Collider> _detectedCollidersCollected = new HashSet<Collider>();


        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        void Update()
        {
            _frustumPlanes = GeometryUtility.CalculateFrustumPlanes(_camera);
            
            int possibleCollidersInViewCount = Physics.OverlapSphereNonAlloc(
                _camera.transform.position,
                detectionRadius,
                _colliders,
                detectionLayer);
            
            foreach (var colliderCollected in _detectedCollidersCollected)
            {
                if (!GeometryUtility.TestPlanesAABB(_frustumPlanes, colliderCollected.bounds))
                {   
                    _detectedCollidersCollected.Remove(colliderCollected);
                    Debug.Log($"Object: {colliderCollected.name} is no longer detected.");
                }
            }

            for (int i = 0; i < possibleCollidersInViewCount; i++)
            {
                var currentCollider = _colliders[i];
                if (currentCollider == null) continue;

                if (GeometryUtility.TestPlanesAABB(_frustumPlanes, currentCollider.bounds))
                {
                    if (!_detectedCollidersCollected.Contains(currentCollider))
                    {
                        _detectedCollidersCollected.Add(currentCollider);
                        
                        DetectedObjectData currentDetectedObjectData = new DetectedObjectData(currentCollider);
                        
                        Debug.Log($"Object Detected: {currentDetectedObjectData.ToString()}");
                        
                    }
                }
            }
        }
    }
}
