using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private Player _player;
    [ReadOnly] public int CurrentScore;
    public int CurrentMaxScore;

    private void Start()
    {
        GameManager.Instance.UIManager.ScoreText.SetTextValue(CurrentScore.ToString() + " / " + CurrentMaxScore.ToString());
    }

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
        GameManager.Instance.UIManager.ScoreText.SetTextValue(CurrentScore.ToString() + " / " + CurrentMaxScore.ToString());
    }

    public void LevelUp()
    {
        CurrentMaxScore = Mathf.RoundToInt(CurrentMaxScore * 1.5f);
        ParticleSystem levelUp = Instantiate(_player.LevelUpParticleSystemPrefab);
        levelUp.transform.position = transform.position;
        GameManager.Instance.UIManager.PowerUpMenu.OpenMenu();
        // here give choice for new power up
    }
}
