using System.Linq;
using System.Net;
using System.Net.Sockets;
using TMPro;
using UnityEngine;

namespace RtspStreaming
{
    public class FindUrlAndDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI urlText;
        [SerializeField] private int rtspPort = 8554;
        [SerializeField] private string rtspPath = "unity";

        void Start()
        {
            string ip = GetLocalIPv4();
            string url = $"rtsp://{ip}:{rtspPort}/{rtspPath}";

            
            urlText.text = $"Stream: {url}";
        }

        string GetLocalIPv4()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            var ip = host.AddressList.FirstOrDefault(a => a.AddressFamily == AddressFamily.InterNetwork);
            return ip?.ToString();
        }
    }
}