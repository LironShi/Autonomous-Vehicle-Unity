using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace RtspStreaming
{
    public class BatchAndVlcLauncher : MonoBehaviour
    {
        public string mediamtxBatch = "RunMediaMTX.bat";
        public string streamBatch   = "Runffmpeg.bat";

        public float waitAfterMediamtxSeconds = 0.5f;
        public float waitAfterStreamSeconds   = 0.5f;
        
        private Process _mediamtxBatProcess;
        private Process _streamBatProcess;

        async void Start()
        {
            string basePath = Application.streamingAssetsPath;
            string mediamtxBatPath = Path.Combine(basePath, mediamtxBatch);
            string streamBatPath   = Path.Combine(basePath, streamBatch);

            _mediamtxBatProcess = RunBatch(mediamtxBatPath);
            await Task.Delay(TimeSpan.FromSeconds(waitAfterMediamtxSeconds));

            _streamBatProcess = RunBatch(streamBatPath);
            await Task.Delay(TimeSpan.FromSeconds(waitAfterStreamSeconds));
        }
        
        void OnApplicationQuit()
        {
            KillProcessSafe(_streamBatProcess);
            KillProcessSafe(_mediamtxBatProcess);
        }

        Process RunBatch(string fullPath)
        {
            try
            {
                var processStartInfo = new ProcessStartInfo
                {
                    FileName = fullPath,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    WorkingDirectory = Path.GetDirectoryName(fullPath)
                };
                
                return Process.Start(processStartInfo);
            }
            catch (Exception e)
            {
                Debug.LogError($"[Batch] Failed to start {fullPath}: {e.Message}");
                return null;
            }
            
        }
        
        void KillProcessSafe(Process p)
        {
            try
            {
                if (p != null && !p.HasExited)
                {
                    p.Kill();
                    p.WaitForExit();
                }
            }
            catch (System.Exception e)
            {
                Debug.LogWarning($"Error killing process: {e.Message}");
            }
        }
    }
}
