using DetectedObject;
using TMPro;
using UnityEngine;

namespace MonitoringPanel
{
    [RequireComponent(typeof(CanvasGroup))]
    public class EnteryController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _titleText;
        [SerializeField] private TMP_Text _messageText;
        
        public CanvasGroup CanvasGroup { get; private set; }

    
        public void Construct(DetectedObjectData objectData)
        {
            CanvasGroup = GetComponent<CanvasGroup>();
            
            if (objectData == null)
            {
                Debug.LogWarning("EntryController.Construct called with null objectData", this);
                return;
            }
            
            _titleText.gameObject.SetActive(!string.IsNullOrEmpty(objectData.ObjectType));
            _titleText.text = objectData.ObjectType;
            _messageText.text = objectData.InfoMessage;
        }
    }
}
