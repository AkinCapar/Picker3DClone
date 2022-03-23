using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour
{
    public static UI instance;
    public int sceneNo;

    [SerializeField] public GameObject startCanvas;
    [SerializeField] public GameObject gameCanvas;
    [SerializeField] public GameObject winCanvas;
    [SerializeField] public GameObject loseCanvas;
    [SerializeField] public GameObject gameCanvasLevelCompletionImage1;
    [SerializeField] public GameObject gameCanvasLevelCompletionImage2;
    [SerializeField] public GameObject gameCanvasLevelCompletionImage3;
    [SerializeField] public TextMeshProUGUI levelNoText;
    [SerializeField] public TextMeshProUGUI nextLevelNoText;
    private int levelNo;
    private int nextLevelNo;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        Time.timeScale = 0;
        sceneNo = SceneManager.GetActiveScene().buildIndex;
    }

    private void Start()
    {
        levelNo = sceneNo + 1;
        nextLevelNo = levelNo + 1;
        levelNoText.text = levelNo.ToString();
        nextLevelNoText.text = nextLevelNo.ToString();
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        startCanvas.SetActive(false);
        gameCanvas.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(sceneNo);
    }

    public void WinGame()
    {
        winCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(sceneNo + 1);
    }

    public void ActivateGameCanvas()
    {
        gameCanvas.SetActive(true);
    }

    public void DeactivateGameCanvas()
    {
        gameCanvas.SetActive(false);
    }
}
