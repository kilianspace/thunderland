using System.IO;
using UnityEngine;

public class LogToFile : MonoBehaviour
{
    private string logFolderPath;
    private string logFilePath;

    private void Awake()
    {
        // ログフォルダのパスを設定（Assets/Debug Logフォルダに保存）
        logFolderPath = Path.Combine(Application.dataPath, "Debug Log");

        // フォルダが存在しない場合は作成
        if (!Directory.Exists(logFolderPath))
        {
            try
            {
                Directory.CreateDirectory(logFolderPath);
                Debug.Log("Debug Logフォルダを作成しました: " + logFolderPath);
            }
            catch (System.Exception e)
            {
                Debug.LogError("Debug Logフォルダの作成に失敗しました: " + e.Message);
            }
        }

        // 実行日時をタイトルにしてログファイルのパスを設定
        logFilePath = GetNextLogFilePath();

        // ログファイルを初期化
        InitializeLogFile();

        // Unityのログメッセージを受け取るイベントを追加
        Application.logMessageReceived += LogMessage;
    }

    private void OnDestroy()
    {
        // スクリプトが破棄されるときにイベントを解除
        Application.logMessageReceived -= LogMessage;

        // ログ終了時のメッセージをファイルに追加
        LogMessage("=== Log End ===", "", LogType.Log);
    }

    private void InitializeLogFile()
    {
        // 新しいファイルを作成
        File.WriteAllText(logFilePath, "=== Log Start ===\n");
    }

    // 次のログファイルのパスを取得するメソッド
    private string GetNextLogFilePath()
    {
        string baseFileName = $"game_log_{System.DateTime.Now:yyyyMMdd_HHmmss}";
        string extension = ".txt";
        int index = 1;

        string filePath;

        // ファイル名が既に存在する場合、インデックスを追加して新しいファイル名を作成
        do
        {
            filePath = Path.Combine(logFolderPath, $"{baseFileName}_{index}{extension}");
            index++;
        } while (File.Exists(filePath));

        return filePath;
    }

    // Unityのログメッセージをファイルに追加するメソッド
    private void LogMessage(string logString, string stackTrace, LogType type)
    {
        // メッセージのフォーマットを決定
        string logEntry = $"{System.DateTime.Now:yyyy/MM/dd HH:mm:ss}: [{type}] {logString}\n";

        // ファイルに書き込み
        File.AppendAllText(logFilePath, logEntry);
    }

    private void Update()
    {
        // デモ用にフレームごとにログを書き込む
        //LogMessage("Update called", "", LogType.Log);
    }
}
