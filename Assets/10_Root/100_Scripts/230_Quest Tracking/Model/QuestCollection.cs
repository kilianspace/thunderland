using System.Collections.Generic;

public class QuestCollection
{
    private Dictionary<int, Quest> _quests = new Dictionary<int, Quest>();

    // クエストを追加する
    public void AddQuest(Quest quest)
    {
        if (!_quests.ContainsKey(quest.QuestId))
        {
            _quests[quest.QuestId] = quest;
        }
    }

    // クエストを取得する
    public Quest GetQuest(int questId)
    {
        if (_quests.TryGetValue(questId, out Quest quest))
        {
            return quest;
        }
        return null; // クエストが見つからない場合は null を返す
    }

    // クエストを開始する
    public void StartQuest(int questId)
    {
        if (_quests.TryGetValue(questId, out Quest quest))
        {
            quest.StartQuest();
        }
    }

    // クエストを完了する
    public void CompleteQuest(int questId)
    {
        if (_quests.TryGetValue(questId, out Quest quest))
        {
            quest.CompleteQuest();
        }
    }

    // 報酬を請求する
    public void ClaimQuestReward(int questId)
    {
        if (_quests.TryGetValue(questId, out Quest quest))
        {
            quest.ClaimReward();
        }
    }

    // すべてのクエストの情報を取得する
    public List<string> GetAllQuestInfos()
    {
        List<string> questInfos = new List<string>();
        foreach (var quest in _quests.Values)
        {
            questInfos.Add(quest.GetQuestInfo());
        }
        return questInfos;
    }
}
