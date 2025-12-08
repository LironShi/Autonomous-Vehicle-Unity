using UnityEngine;

namespace Camera
{
    public class BasicCameraScript : MonoBehaviour
    {
        public LayerMask detectionLayer;

        // Update is called once per frame
        void Update()
        {
            Ray ray = new Ray(transform.position, transform.forward);
            
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, detectionLayer))
            {
                Debug.Log("Hit object: " + hit.collider.gameObject.name);
            }
        }
    }
}
