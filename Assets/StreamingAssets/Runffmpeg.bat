@echo off
set WIDTH=1920
set HEIGHT=1080

"C:\AutoSim\AutoSim_Data\StreamingAssets\Bin\ffmpeg\bin\ffmpeg.exe" ^
  -f gdigrab -framerate 30 -offset_x 0 -offset_y 0 -video_size %WIDTH%x%HEIGHT% -i desktop ^
  -vcodec libx264 -preset veryfast -pix_fmt yuv420p ^
  -f rtsp -rtsp_transport tcp rtsp://%ip%:8554/unity

echo Exit code: %ERRORLEVEL%
pause
