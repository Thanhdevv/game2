using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<int> highScoreList = new List<int>(); // Danh sách High Score
    public int maxHighScoreEntries = 5; // Số lượng thành tích cao nhất cần lưu

    public int score = 0;
    public int highscore = 0;
    public GameObject ScoreBoar;
    public GameObject ScoreDead;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI scoreDeadText;
    public TextMeshProUGUI highScoreText;

     
    private void Start()
    {
        LoadHighScoreList(); // Load danh sách High Score từ PlayerPrefs
        LoadGame(); // Load điểm số hiện tại và điểm cao nhất từ PlayerPrefs
        CheckHighScore();
        SetScoreText(); // Cập nhật điểm số hiện tại lên giao diện
        DisplayHighScore(); // Hiển thị danh sách High Score lên giao diện
    }

    private void Update()
    {
        DisplayHighScore();
    }

    public void AddScore()
    {
        score++;
        SetScoreText(); // Cập nhật điểm số hiện tại lên giao diện sau mỗi lần thêm điểm
        

    }
    public void SetScoreText()
    {
        textScore.text = "Score: " + score.ToString("n0");
    }

    // Update is called once per frame


    public void SaveGame()
    {
       /* PlayerPrefs.SetInt("KeyScore", score);
        string maHoa = Extension.Encrypt(score.ToString(), "game2");
        PlayerPrefs.SetString("diem", maHoa);*/
        PlayerPrefs.SetInt("KeyScore", score);
        PlayerPrefs.SetInt("KeyHighScore", highscore);
    }

    public void LoadGame()
    {
        /*  score = PlayerPrefs.GetInt("KeyScore");

          string getScore = PlayerPrefs.GetString("diem");
          string giaiMa = Extension.Decrypt(getScore, "game2");
          score = int.Parse(giaiMa);*/
        score = PlayerPrefs.GetInt("KeyScore");
        highscore = PlayerPrefs.GetInt("KeyHighScore");
    }
    public void CheckHighScore()
    {
        if (score > highscore)
        {
            highscore = score;
            SaveGame();
        }
        ScoreBoar.SetActive(true);
        ScoreDead.SetActive(false);

        scoreDeadText.text = "Score:" + score.ToString("n0");
        highScoreText.text = "High Score:" + highscore.ToString("n0");

        // Kiểm tra và cập nhật danh sách High Score
        UpdateHighScoreList();

    }

    void UpdateHighScoreList()
    {
        // Kiểm tra xem điểm số mới có trùng với các điểm số hiện có không
        if (!highScoreList.Contains(score))
        {
            // Nếu không trùng, thêm điểm số mới vào danh sách High Score
            highScoreList.Add(score);

            // Sắp xếp danh sách theo điểm số giảm dần
            highScoreList.Sort((x, y) => y.CompareTo(x));

            // Giữ chỉ 5 thành tích cao nhất
            if (highScoreList.Count > maxHighScoreEntries)
            {
                highScoreList.RemoveRange(maxHighScoreEntries, highScoreList.Count - maxHighScoreEntries);
            }

            // Lưu danh sách High Score
            SaveHighScoreList();
        }
    }


    void SaveHighScoreList()
    {
        for (int i = 0; i < highScoreList.Count; i++)
        {
            PlayerPrefs.SetInt("HighScore" + i, highScoreList[i]);
        }
    }

    void LoadHighScoreList()
    {
        highScoreList.Clear();
        for (int i = 0; i < maxHighScoreEntries; i++)
        {
            if (PlayerPrefs.HasKey("HighScore" + i))
            {
                highScoreList.Add(PlayerPrefs.GetInt("HighScore" + i));
            }
        }
    }

    void DisplayHighScore()
    {
        string highScoreString = "High Score:\n";

        for (int i = 0; i < highScoreList.Count; i++)
        {
            highScoreString += (i + 1) + ". " + highScoreList[i].ToString("n0") + "\n";
        }

        highScoreText.text = highScoreString;
    }

    public void HomeBnt()
    {
        SceneManager.LoadScene(1);
    }
    public void btnPlayAgain()
    {
        SceneManager.LoadScene(2);
    }
    public int getScore()
    {
        return score;
    }
    public void Truscore()
    {
        score--;
        textScore.text = "Score: " + score.ToString("n0");
    }

    public void PlayerDeath()
    {
        
        CheckHighScore();
        DisplayHighScore();

    }
}


