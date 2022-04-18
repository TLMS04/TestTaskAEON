using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _resultScreen;
    [SerializeField] private Text _resultText;
    // Start is called before the first frame update
    private void Start()
    {
        var result = Result.GetInstance();
        if (result.HasResult)
        {
            _resultScreen.SetActive(true);
            _resultText.text = result.ResultText;
            result.HasResult = false;
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void ShowResultScreen()
    {
        if (!_resultScreen.activeSelf)
        {
            var result = Result.GetInstance();
            _resultText.text = result.ResultText;
            _resultScreen.SetActive(true);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _resultScreen.activeSelf)
        {
            _resultScreen.SetActive(false);
        }
    }
}
