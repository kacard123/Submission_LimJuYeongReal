using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// 게임오버 상태를 표현하고, 게임 점수와 UI를 관리하는 매니저
// 씬에는 단 하나의 게임 매니저만 존재할 수 있음
public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 싱글턴을 할당할 전역 변수 

    public bool isGameover = false; // 게임오버 상태
    public Text scoreText; // 점수를 출력할 UI 텍스트
    public GameObject gameoverUI; // 게임오버시 활성화할 UI 오브젝트
    public bool isPlay = false;
    public float gameSpeed = 1;

    private int score = 0; // 게임 점수

    public GameObject menuPanel; // 메뉴 패널 변수

    public int hpCount = 5; // 실제 사용자 생명력
    public Text hpText; // 사용자에게 보여질 생명력 UI
    public int hp;


    // 게임 시작과 동시에 싱글턴을 구성
    private void Awake()
    {
        // 싱글턴 변수 instance가 비어 있나요?
        if (instance == null)
        {
            // instance가 비어 있다면 그곳에 내 자신을 할당
            instance = this;
        }
        else
        {
            // instance에 이미 다른 GameManager 오브젝트가 
            // 할당되어 있다면...

            // 씬에 두 개 이상의 GameManager 오브젝트가
            // 존재한다는 의미 싱글턴 오브젝트는 하나만
            // 존재해야 하므로 자신의 게임 오브젝트를
            // 파괴
            Debug.Log("씬에 두 개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // 사용자에게 보여질 생명력을 실제 생명력으로 등록
        hpText.text = hpCount.ToString();

        hp = hpCount;
    }

    // 게임오버 상태에서 게임을 재시작할 수 있게 하는 처리
    void Update()
    {
        
        //if (isGameover)
        //{
           //Debug.Log(isGameover);
        //    Invoke("OnPlayerDead", 3.0f);
        //}
        //게임오버 상태에서 마우스 왼쪽 버튼을 클릭한다면...
        if (isGameover && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            // GetActiveScene : 현재 활성화되어있는 씬의 이름을 가져와라
            // SceneManager.LoadScene(0);
            // SceneManager.LoadScene("현재 씬의 이름");
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);을 
            // 쓰는 게 좋은 이유는 씬의 이름이 변경이 될 수 있기 때문이다.
            // 어떠한 변수라도 대응할 수 있도록.
        }

        Invoke("OnPlayerDead", 3.0f);
    }

    // 점수를 증가시키는 메서드
    public void AddScore(int newScore)
    {
        
        if (isGameover) return;

        // 게임오버가 아니라면
        // 점수를 증가
        score += newScore;
        scoreText.text = "Score : " + score;

    }

    // 플레이어 캐릭터가 사망 시 게임오버를 실행하는 메서드
    //public void OnPlayerDead()
    //{
    //    // 현재 상태를 게임오버 상태로 변경
    //    isGameover = true;
    //    // 게임오버 UI를 활성화
    //    gameoverUI.SetActive(true);
    //}
    public IEnumerator OnPlayerDead()
    {
        yield return new WaitForSeconds(3f);
        isGameover = true;
        gameoverUI.SetActive(true);
    }

    public void OnMenu()
    {
        menuPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OffMenu()
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public bool Crash()
    {
        // hpCount--;
        // hpText.text = hpCount.ToString();
        Debug.Log("crash");

        hpText.text = "" + --hpCount;
        if (hpCount <= 0) return true;
        return false;
    }

    public void HpText()
    {
        hpText.text = "" + hp;

    }

    public int Plus(int a, int b)
    {
        int c = a + b;
        return c;
    }

}