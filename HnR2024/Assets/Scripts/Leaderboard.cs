using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dan.Main;
using TMPro;

public class Leaderboard : MonoBehaviour
{

    [SerializeField]
    private List<TextMeshProUGUI> scores;

    [SerializeField]
    private List<TextMeshProUGUI> names;

    private string publicKey = "18ab781d84d9c2635176c137991ed5ed09027c24ea7d74685860a1525a87897c";
    // Start is called before the first frame update
    void Start()
    {
        GetLeaderboard();
    }

    private void GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(publicKey, (msg) =>
        {
            int loopLength = names.Count < msg.Length ? names.Count : msg.Length;
            for (int i = 0; i < loopLength; i++)
            {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        });
    }

    public void SetLeaderboardEntry(string username, int score)
    {
        LeaderboardCreator.UploadNewEntry(publicKey, username, score, (msg) =>
        {
            if (username.Length > 12) return;

            GetLeaderboard();
        });
    }


   
}
