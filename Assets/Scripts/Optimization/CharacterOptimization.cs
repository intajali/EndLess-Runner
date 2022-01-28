
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterOptimization : MonoBehaviour
{
    [SerializeField] private Slider sizeSlider;
    [SerializeField] private Slider colorSlider;

    [SerializeField] private Material playerMaterial;
    [SerializeField] private GameObject playerObject;

    [SerializeField] private GameObject mainPrefab;

    [SerializeField] private Button backButton;



    // Start is called before the first frame update
    void Start()
    {
        playerObject.GetComponent<PlayerController>().enabled = false;
        colorSlider.onValueChanged.RemoveAllListeners();
        colorSlider.onValueChanged.AddListener((value) => UpdateColor(value));

        sizeSlider.onValueChanged.RemoveAllListeners();
        sizeSlider.onValueChanged.AddListener((value) => UpdateSize(value));

        backButton.onClick.RemoveAllListeners();
        backButton.onClick.AddListener(OnClickBackButton);
    }

   private void UpdateColor(float value)
    {
        playerMaterial.color = Color.HSVToRGB(value, 1, 1);
    }


    private void UpdateSize(float value)
    {
        playerObject.transform.localScale = new Vector3(value, value, value);
        mainPrefab.transform.localScale = playerObject.transform.localScale;


    }

    private void OnClickBackButton()
    {
        SceneManager.LoadScene(GameConstants.GAMEPLAY_SCENE);
    }




}
