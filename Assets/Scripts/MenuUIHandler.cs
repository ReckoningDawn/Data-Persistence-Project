using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public string playerName;

    private InputField nameField;
    public Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        nameField = GameObject.Find("NameField").GetComponent<InputField>();

        if (DataManager.Instance != null)
        {
            DataManager.Instance.loadScore();
            highScoreText.text = $"Best Score: {DataManager.Instance.highScorePlayerName} : {DataManager.Instance.highScore}";
        }
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void setName()
    {
        playerName = nameField.text;
        Debug.Log(playerName);

        if (DataManager.Instance != null)
        {
            DataManager.Instance.currentPlayerName = playerName;
        }
    }

}
