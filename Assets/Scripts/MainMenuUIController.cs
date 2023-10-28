using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIController : MonoBehaviour
{
    [SerializeField] private GameObject _mainUI;
    [SerializeField] private GameObject _leaderboardUI;
    [SerializeField] private GameObject _inputNicknameUI;

    [SerializeField] private TextMeshProUGUI _leaderboardTmp;
    [SerializeField] private TextMeshProUGUI _incorrectNicknameTMP;
    [SerializeField] private InputField _nicknameInputField;

    [SerializeField] private Button _showNicknameUI;
    [SerializeField] private Button _goToLeaderboardBtn;
    [SerializeField] private Button _newGameBtn;
    [SerializeField] private Button _goToMainMenu;


    private void Start()
    {
        _showNicknameUI.onClick.AddListener(() => ShowNewGameUI());
        _newGameBtn.onClick.AddListener(() => { StartNewGame(); });
        _goToLeaderboardBtn.onClick.AddListener(() => { ShowLeaderboard(); });
        _goToMainMenu.onClick.AddListener(() => { GoToMainMenu(); });

        GoToMainMenu();
    }
    private void StartNewGame()
    {

        if (_nicknameInputField.text != "")
        {
            GameController.Reset();
            GameController.Nickname = _nicknameInputField.text;
            SceneManager.LoadScene("Game");
        }
        else
        {
            StartCoroutine(AlarmIncorreckNickname("Никнейм не может быть пустым"));
        }
    }
    private void ShowLeaderboard()
    {
        _mainUI.SetActive(false);
        _leaderboardUI.SetActive(true);

        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.GetString($"Nickname_{i}") != "")
                _leaderboardTmp.text += $"{PlayerPrefs.GetString($"Nickname_{i}")} - {PlayerPrefs.GetFloat($"Score_{i}")}\n";
        }
        if(_leaderboardTmp.text == "")
        {
            _leaderboardTmp.text = "Ещё никто не играл в эту игру.\nУспей стать первым!";
        }
    }
    private void GoToMainMenu()
    {
        _mainUI.SetActive(true);
        _leaderboardUI.SetActive(false);
        _inputNicknameUI.SetActive(false);
    }
    private void ShowNewGameUI()
    {
        _mainUI.SetActive(false);
        _inputNicknameUI.SetActive(true);
    }
    private IEnumerator AlarmIncorreckNickname(string text)
    {
        _incorrectNicknameTMP.text = text;
        _incorrectNicknameTMP.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        _incorrectNicknameTMP.gameObject.SetActive(false);
    }

}
