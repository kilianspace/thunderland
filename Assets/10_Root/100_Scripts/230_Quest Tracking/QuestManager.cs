using System.Collections.Generic;

public class QuestManager
{
    private QuestCollection _questCollection = new QuestCollection();

    // クエストを追加する
    public void AddQuest(Quest quest)
    {
        _questCollection.AddQuest(quest);
    }

    // クエストを取得する
    public Quest GetQuest(int questId)
    {
        return _questCollection.GetQuest(questId);
    }

    // クエストを開始する
    public void StartQuest(int questId)
    {
        _questCollection.StartQuest(questId);
    }

    // クエストを完了する
    public void CompleteQuest(int questId)
    {
        _questCollection.CompleteQuest(questId);
    }

    // 報酬を請求する
    public void ClaimQuestReward(int questId)
    {
        _questCollection.ClaimQuestReward(questId);
    }

    // すべてのクエスト情報を取得する
    public List<string> GetAllQuestInfos()
    {
        return _questCollection.GetAllQuestInfos();
    }
}
