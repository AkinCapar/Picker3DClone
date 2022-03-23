using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour
{
    public static UI instance;
    public int sceneNo;
    LevelManager levelManager;

    [SerializeField] public GameObject startCanvas;
    [SerializeField] public GameObject gameCanvas;
    [SerializeField] public GameObject winCanvas;
    [SerializeField] public GameObject loseCanvas;
    [SerializeField] public GameObject gameCanvasLevelCompletionImage1;
    [SerializeField] public GameObject gameCanvasLevelCompletionImage2;
    [SerializeField] public GameObject gameCanvasLevelCompletionImage3;
    [SerializeField] public TextMeshProUGUI levelNoText;
    [SerializeField] public TextMeshProUGUI nextLevelNoText;
    [SerializeField] public TextMeshProUGUI collectedAmount1;
    [SerializeField] public TextMeshProUGUI neededAmount1;
    [SerializeField] public TextMeshProUGUI collectedAmount2;
    [SerializeField] public TextMeshProUGUI neededAmount2;
    [SerializeField] public TextMeshProUGUI collectedAmount3;
    [SerializeField] public TextMeshProUGUI neededAmount3;
    public int levelNo = 1;
    public int nextLevelNo = 2;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }


        Time.timeScale = 0;
        sceneNo = SceneManager.GetActiveScene().buildIndex;
    }

    private void Start()
    {
        levelManager = LevelManager.instance;
        levelNo = sceneNo + 1;
        nextLevelNo = levelNo + 1;
        levelNoText.text = levelNo.ToString();
        nextLevelNoText.text = nextLevelNo.ToString();
    }

    private void Update()
    {
        Debug.Log(levelManager.collectedObjectsAmount1);
        collectedAmount1.text = levelManager.collectedObjectsAmount1.ToString();
        neededAmount1.text = levelManager.neededObjectsAmount1.ToString();
        collectedAmount2.text = levelManager.collectedObjectsAmount2.ToString();
        neededAmount2.text = levelManager.neededObjectsAmount2.ToString();
        collectedAmount3.text = levelManager.collectedObjectsAmount3.ToString();
        neededAmount3.text = levelManager.neededObjectsAmount3.ToString();
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
        if (sceneNo == 9)
        {

            SceneManager.LoadScene(Random.Range(0, 9));
            levelNo++;
            nextLevelNo++;
        }

        else
        {
            SceneManager.LoadScene(sceneNo + 1);
            levelNo++;
            nextLevelNo++;

        }
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
