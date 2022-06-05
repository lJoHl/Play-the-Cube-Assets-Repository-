using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Cube cube;

    [SerializeField] private GameObject selectModeScreen;
    [SerializeField] private GameObject gameScreen;
    [SerializeField] private GameObject mode3FinalScreen;

    [SerializeField] private TextMeshProUGUI caughtText;
    private int caught;

    [SerializeField] private TextMeshProUGUI totalCaughtText;

    [SerializeField] private TextMeshProUGUI timeText;
    private int time;

    public bool isGameActive = false;


    private void Start()
    {
        cube = GameObject.Find("Cube").GetComponent<Cube>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            ReturnToMenu();
    }


    public void StartGame()
    {
        isGameActive = true;

        selectModeScreen.SetActive(false);

        if (cube.mode == 3)
        {
            gameScreen.SetActive(true);

            caught = 0;
            time = 60;

            UpdateCaught(0);
            StartCoroutine(UpdateTime());
        }
    }


    public void UpdateCaught(int addCaught)
    {
        if (cube.mode == 3)
        {
            caught += addCaught;
            caughtText.text = $"Caught: {caught}";
        }
    }


    private IEnumerator UpdateTime()
    {
        for (int i = time; i >= 0; i--)
        {
            if (!isGameActive) break;

            timeText.text = $"Time: {i}";
            yield return new WaitForSeconds(1);

            if (i == 0)
            {
                isGameActive = false;

                gameScreen.SetActive(false);
                mode3FinalScreen.SetActive(true);

                cube.OriginalTransform();

                totalCaughtText.text = $"Caught {caught}";
            }
        }
    }


    private void ReturnToMenu()
    {
        isGameActive = false;

        selectModeScreen.SetActive(true);
        gameScreen.SetActive(false);
        mode3FinalScreen.SetActive(false);

        cube.OriginalTransform();
    }
}
