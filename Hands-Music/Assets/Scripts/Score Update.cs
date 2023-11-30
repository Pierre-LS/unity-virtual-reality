using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour
{
    public static ScoreUpdate instance;

    public int currentScore = 0;

    private GameObject Score_Show;
    private Text Score_Show_Text;


    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;

        Score_Show = GameObject.Find("/Table/Score/Text (Legacy)");
        Score_Show_Text = Score_Show.GetComponent<Text>();
    }

    private void Update()
    {
        Score_Show_Text.text = "Score: " + currentScore.ToString();
    }
}

