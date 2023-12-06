using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    // ���� �������� ���� , ��� �������� ���� �ջ�/ �� ���� ��ȣ /�÷��̾� ��� ó�� /UI /�� ��ȯ    
    /*public bool isGameover = false;
    public Text scoreText;
    public Text sceneText;
    public GameObject gameoverUI;

    int score = 0;*/
    public bool isGameover = false;
    /*static bool isGameover = false;
    public bool Gameover {
        get => isGameover;
        set => isGameover = value;
    }*/

    static int stageNum = 0;
    static int stageScore = 0;
    static int totalScore = 0;
    static int getItemCount = 0;
    static int[] itemCount = { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };

    //public PlayerController sceneController;

    public TextMeshProUGUI stageNumber;
    public TextMeshProUGUI stageScoreText;
    public TextMeshProUGUI totalScoreText;

    public GameObject gameoverUI;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
        stageScore = 0;
        //getItemCount = 0;
    }
    void Start() {
        stageNum = 1;
        //totalScore = 0;
        //totalScore = PlayerPrefs.GetInt("TotalScore");
    }
    // Update is called once per frame
    private void FixedUpdate() {
        stageScoreText.text = "Stage Score : " + stageScore.ToString();
        totalScoreText.text = "Total Score : " + totalScore.ToString();
    }
    void Update() {
        if (isGameover && Input.GetKeyDown(KeyCode.Space)) {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        

    }

    public void AddScore(int newScore) {

        if (!isGameover) {
            stageScore += newScore;
            stageScoreText.text = "Stage Score : " + stageScore.ToString();
            totalScore += newScore;
            totalScoreText.text = "Total Score : " + totalScore.ToString();
        }
    }
    /*public void IncreaseScore() {
        getItemCount++;
        stageScore++;
        totalScore++;
    }*/

    public void OnPlayerDead() {
        isGameover = true;
        gameoverUI.SetActive(true);
        Debug.Log("�÷��̾ ����߽��ϴ�.");

        stageScore = 0;
        stageScoreText.text = "Stage Score : " + stageScore.ToString();

        totalScore = 0;
        totalScoreText.text = "Total Score : " + totalScore.ToString();

        // �ٸ� ���� �ʱ�ȭ �� �߰����� �ʱ�ȭ �۾��� ������ �� �ֽ��ϴ�.
        PlayerPrefs.SetInt("TotalScore", 0);
        // ��: ������ ���� �ʱ�ȭ
        getItemCount = 0;

        ResetGame();
    }
    /*public void OnButtonClick() {
        sceneController.LoadNextScene();
    }*/
    public void FinishPoint() {
        if(getItemCount >= itemCount[stageNum-1]) {
            stageNum++;
            //UpdateUI();
            //totalScore += stageScore;
            // ������ totalScore�� �ؽ�Ʈ�� �ݿ�
            //totalScoreText.text = "Total Score: " + totalScore;
        }
        //else {
            //totalScore -= stageScore;
       // }
        PlayerPrefs.SetInt("TotalScore", totalScore);

        SceneManager.LoadScene(0);
    }
    void UpdateUI() {
        stageNumber.text = "Stage : " + stageNum.ToString();

    }

    void ResetGame() {
        stageScore = 0;
        getItemCount = 0;
        UpdateUI();
    }

}