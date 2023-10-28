using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] private GameObject _playerUI;
    [SerializeField] private GameObject _gameOverUI;


    [SerializeField] private TextMeshProUGUI _scoreTMP;
    [SerializeField] private TextMeshProUGUI _resultTMP;
    [SerializeField] private TextMeshProUGUI _nicknameTMP;

    [SerializeField] private Button _tryAgainBtn;
    [SerializeField] private Button _toMainMenuBTN;
    private Color r1, r2, b1, b2;
    void Start()
    {
        _gameOverUI.SetActive(false);
        _tryAgainBtn.onClick.AddListener(() => Restart());
        _toMainMenuBTN.onClick.AddListener(() => GoToMainMenu());

        ColorUtility.TryParseHtmlString("#d8846b", out r1);
        ColorUtility.TryParseHtmlString("#ba5843", out r2);

        ColorUtility.TryParseHtmlString("#4564ae", out b1);
        ColorUtility.TryParseHtmlString("#5882c9", out b2);
    }
    void Update()
    {
        _nicknameTMP.text = $"Nickname: {GameController.Nickname}";
        _scoreTMP.text = Math.Round(GameController.Score, 2).ToString();
        _resultTMP.text = $"Никнейм: {GameController.Nickname}\nСчёт: {GameController.Score}";

        switch(GameController.isWinning)
        {
            case false:
                _gameOverUI.SetActive(true);
                break;
        }
    }

    private void Restart()
    {
        SaveResults.Save();
        GameController.TryAgain();
        SceneManager.LoadScene("Game");
    }
    private void GoToMainMenu()
    {
        SaveResults.Save();
        GameController.Reset();
        SceneManager.LoadScene("MainMenu");
    }

}
