using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour
{
    public static ScoreUpdate instance;

    public float currentScore = 0f;
    private float showScore;

    private GameObject Score_Show;
    private Text Score_Show_Text;


    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0f;
        showScore = 0f;

        Score_Show = GameObject.Find("/Table/Score/Text (Legacy)");
        Score_Show_Text = Score_Show.GetComponent<Text>();
    }

    private void Update()
    {
        showScore = Mathf.Round(currentScore * 100.0f) * 0.01f;
        Score_Show_Text.text = "Score: " + showScore.ToString();
    }
}

