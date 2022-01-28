
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private Button optimiseButton;


    private void Start()
    {
        backButton.onClick.RemoveAllListeners();
        backButton.onClick.AddListener(OnClickBackButton);

        optimiseButton.onClick.RemoveAllListeners();
        optimiseButton.onClick.AddListener(OnClickOptimiseButton);
    }


    private void OnClickBackButton()
    {
        SceneManager.LoadScene(GameConstants.MAIN_SCENE);
    }

    private void OnClickOptimiseButton()
    {
        SceneManager.LoadScene(GameConstants.OPTIMISE_SCENE);
    }
}
