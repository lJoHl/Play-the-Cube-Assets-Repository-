using UnityEngine;
using UnityEngine.UI;

public class ModeSettings : MonoBehaviour
{
    private Cube cube;

    private GameManager gameManager;

    private Button modeButton;
    [SerializeField] private int mode;


    private void Start()
    {
        cube = GameObject.Find("Cube").GetComponent<Cube>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        modeButton = GetComponent<Button>();
        modeButton.onClick.AddListener(SetMode);
    }


    private void SetMode()
    {
        cube.GetMode(mode);
        gameManager.StartGame();
    }
}
