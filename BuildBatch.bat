@echo off
set UNITY_PATH="Unity.exeへのパス"
set PROJECT_PATH="Unityプロジェクトへのパス"

%UNITY_PATH% -batchmode -quit -projectPath %PROJECT_PATH% -executeMethod ApplicationBuild.AndroidBuild -logFile

rem 必要があればCI用にオプションをつける(今回は末尾に追加しています。)
rem set USER_NAME="Unityアカウントのユーザー名"
rem set PASSWORD="Unityアカウントのパスワード"
rem set SERIAL="Unity Proのシリアライズコード"
rem %UNITY_PATH% -batchmode -quit -projectPath %PROJECT_PATH% -executeMethod ApplicationBuild.AndroidBuild -logFile -nographics -username %USER_NAME% -password %PASSWORD% -serial %SERIAL%
