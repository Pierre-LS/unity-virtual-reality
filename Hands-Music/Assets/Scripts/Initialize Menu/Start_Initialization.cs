using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Start_Initialization : MonoBehaviour
{
    private GameObject Instructions;
    private TextMeshProUGUI Instructions_Text;
    private TypeWriterUI Instructions_Type;

    private GameObject Back;

    private GameObject left_Palm;

    private float table_Height;
    private int hidden_text_number;
    public int text_number;

    // Start is called before the first frame update
    void Start()
    {
        Instructions = GameObject.Find("/Text Canvas/Instructions");
        Instructions_Text = Instructions.GetComponent<TextMeshProUGUI>();
        Instructions_Text.text = "Welcome To\r\nVirtual Vitality";
        Instructions_Type = Instructions.GetComponent<TypeWriterUI>();
        Instructions_Type.enabled = true;

        Back = GameObject.Find("/Text Canvas/Back Button");
        Back.SetActive(false);

        left_Palm = GameObject.Find("/XR Interaction Hands Setup Variant/XR Origin (XR Rig)/Camera Offset/Left Hand/Left Hand Interaction Visual/L_Wrist/L_Palm");

        text_number = 1;
        hidden_text_number = text_number;
    }

    // Update is called once per frame
    void Update()
    {
        if (text_number != hidden_text_number)
        {
            if (text_number == 1)
            {
                Instructions_Text.text = "Welcome To\r\nVirtual Vitality";
                Back.SetActive(false);
            }

            if (text_number == 2)
            {
                Instructions_Text.text = "Please Seat\r\nAt A Table";
                if (hidden_text_number == 1)
                {
                    Back.SetActive(true);
                }
            }

            if (text_number == 3)
            {
                Instructions_Text.text = "Put Your Left Hand\r\nOn The Table\r\nAnd Click On Next\r\nWith Your Right Hand";
            }

            if (text_number == 4)
            {
                if (hidden_text_number == 3)
                {
                    table_Height = left_Palm.transform.position.y;
                    PlayerPrefs.SetFloat("table_Height", table_Height - 0.02f);
                }
                Instructions_Text.text = "Thank You Very Much\r\nEnjoy The Game";
            }

            if (text_number == 5)
            {
                SceneManager.LoadSceneAsync("Start Menu");
            }

            if (text_number > 5 || text_number < 1)
            {
                SceneManager.LoadSceneAsync("Initialization");
            }

            Instructions.SetActive(false);
            Instructions.SetActive(true);

            hidden_text_number = text_number;
        }
    }
}
