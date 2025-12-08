using System.Collections.Generic;
using DetectedObject;
using UnityEngine;

namespace MonitoringPanel
{
    public class MonitoringPanelController : MonoBehaviour
    {
        [SerializeField] private RectTransform _content;
        [SerializeField] private EnteryController _entryPrefab;
        
        private readonly Dictionary<Collider, EnteryController> _entries = new();
        
        public void OnObjectDetected(Collider collider, DetectedObjectData data)
        {
            if (_entries.ContainsKey(collider)) return;

            var entry = Instantiate(_entryPrefab, _content);
            entry.Construct(data);
            _entries.Add(collider, entry);
        }
        public void OnObjecExitFOV(Collider collider)
        {
            if (!_entries.TryGetValue(collider, out var entry)) return;

            Destroy(entry.gameObject);
            _entries.Remove(collider);
        }
    }
}
