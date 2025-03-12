using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [ReadOnly]
    public int CurrentScore;
    public int CurrentMaxScore;

    public void AddScore(int score)
    {
        CurrentScore += score;

        // Check for level up
        if (CurrentScore >= CurrentMaxScore)
        {
            CurrentScore = CurrentMaxScore - CurrentScore;
            LevelUp();
        }

        GameManager.Instance.UIManager.ScoreBar.SetBarValue(CurrentScore, CurrentMaxScore);
    }

    public void LevelUp()
    {
        CurrentMaxScore = Mathf.RoundToInt(CurrentMaxScore * 1.5f);
        // here give choice for new power up
    }
}
