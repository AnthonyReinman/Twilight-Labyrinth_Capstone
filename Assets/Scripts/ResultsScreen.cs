using UnityEngine;
using UnityEngine.UI;

public class ResultsScreen : MonoBehaviour
{
    public Text timeSurvivedText;
    public Text goldEarnedText;
    public Text levelReachedText;
    public Text enemiesDefeatedText;

    private float timeSurvived;
    private int goldEarned;
    private int levelReached;
    private int enemiesDefeated;

    void Start()
    {
        // These values would typically be set during gameplay
        timeSurvived = GameManager.instance.timeSurvived;
        goldEarned = GameManager.instance.goldEarned;
        levelReached = GameManager.instance.levelReached;
        enemiesDefeated = GameManager.instance.enemiesDefeated;

        // Update the UI elements with the results
        timeSurvivedText.text = "Survived: " + FormatTime(timeSurvived);
        goldEarnedText.text = "Gold earned: " + goldEarned.ToString();
        levelReachedText.text = "Level reached: " + levelReached.ToString();
        enemiesDefeatedText.text = "Enemies defeated: " + enemiesDefeated.ToString();
    }

    private string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
