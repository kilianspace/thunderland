using System.Collections.Generic;

public class Quest
{

    // Quest ID
    ////////////////////////////////
    private int _questId;
    public int QuestId
    {
        get { return _questId; }
        private set { _questId = value; }
    }
    ////////////////////////////////

    // Quest Title
    ////////////////////////////////
    private string _questTitle;
    public string QuestTitle
    {
        get { return _questTitle; }
        private set { _questTitle = value; }
    }
    ////////////////////////////////

    // Quest Description
    ////////////////////////////////
    private string _questDescription;
    public string QuestDescription
    {
        get { return _questDescription; }
        private set { _questDescription = value; }
    }
    ////////////////////////////////



    // クエストの報酬
    private List<string> _rewards;


    // Quest State
    ////////////////////////////////
    private QuestState _currentState;
    public enum QuestState
     {
         NotStarted, // 未開始
         Accepted,   // 受け入れ
         InProgress, // 進行中
         Completed,  // 完了
         RewardClaimed // 報酬請求済み
     }
    ////////////////////////////////



    // Quest Type
    ////////////////////////////////
    private bool _isStoryMission;
    public bool IsStoryMission
    {
        get { return _isStoryMission; }
        private set { _isStoryMission = value; }
    }

    ////////////////////////////////


    // Quest history stamps
    ////////////////////////////////
    private bool _isQuestUnlocked;
    public bool IsQuestUnlocked
    {
        get { return _isQuestUnlocked; }
        private set { _isQuestUnlocked = value; }
    }
    // Failed
    private bool _isQuestFailed;
    public bool IsQuestFailed
    {
        get { return _isQuestFailed; }
        private set { _isQuestFailed = value; }
    }
    ////////////////////////////////


    // Notes for debugging
    ////////////////////////////////
    private string _debug_notes;
    public string Debug_notes
    {
        get { return _debug_notes; }
        private set { _debug_notes = value; }
    }
    ////////////////////////////////



    // コンストラクタ
    public Quest(
        int questId,
        string questTitle,
        string questDescription,
        bool isStoryMission = false,
        bool isQuestUnlocked = false,
        bool isQuestFailed = false,
        string debugNotes = ""
    ){
        _questId = questId;
        _questTitle = questTitle;
        _questDescription = questDescription;
        _currentState = QuestState.NotStarted;
        _isStoryMission = isStoryMission;
        _isQuestUnlocked = isQuestUnlocked;
        _isQuestFailed = isQuestFailed;
        _debug_notes = debugNotes;
    }

    // クエストを開始する
    public void StartQuest()
    {
       if (_currentState == QuestState.Accepted)
       {
           _currentState = QuestState.InProgress;
           // 開始時の処理（例：目標の更新など）
       }
    }

    // クエストを完了する
    public void CompleteQuest()
    {
       if (_currentState == QuestState.InProgress)
       {
           _currentState = QuestState.Completed;
           // 完了時の処理（例：報酬の追加など）
       }
    }

    // 報酬を請求する
    public void ClaimReward()
    {
       if (_currentState == QuestState.Completed && !HasClaimedReward())
       {
           // 報酬を付与する処理
           _currentState = QuestState.RewardClaimed;
           // 報酬請求時の処理
       }
    }

    // クエストの報酬を追加する
    public void AddReward(string reward)
    {
       _rewards.Add(reward);
    }

    // 報酬が請求されたかどうかをチェックする
    public bool HasClaimedReward()
    {
       return _currentState == QuestState.RewardClaimed;
    }

    // クエストの状態を取得する
    public QuestState GetQuestState()
    {
       return _currentState;
    }

    // クエストの情報を取得する
    public string GetQuestInfo()
    {
       return $"{_questTitle}: {_questDescription} (状態: {_currentState})";
    }

}
