using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class mainMenuManager : MonoBehaviour
{
    [SerializeField] TMP_InputField nameInputFfield;
    [SerializeField] Button startButton;
    [SerializeField] GameObject warningWindow;



    public void Start()
    {
        startButton.onClick.AddListener(startGame);
        if(warningWindow.activeInHierarchy)
        {
            warningWindow.SetActive(false);
        }
    }

    public void startGame()
    {
        if(nameInputFfield.text != "")
        {
            PersistentData.instance.addPlayerName(nameInputFfield.text);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            warningWindow.SetActive(true);
        }
    }

    public void closeWarningWindow()
    {
        warningWindow.SetActive(false);
    }

    public void closeApplication()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
