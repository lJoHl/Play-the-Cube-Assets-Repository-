using UnityEngine;

public class Cube : MonoBehaviour
{
    private GameManager gameManager;

    private MeshRenderer Renderer;
    private Material material;

    private float lowerLimit = 3;
    private float topLimit = -30;
    private float rightLimit = 4;
    private float leftLimit = -10;
    private float upLimit = 8;
    private float downLimit = -9;

    private Vector3 startPosition;
    private Vector3 startScale;

    private Vector3 rotation;

    private float changeColorCounter;

    public int mode;


    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        Renderer = GetComponent<MeshRenderer>();
        material = Renderer.material;

        startPosition = transform.position;
        startScale = transform.localScale;

        rotation = RandomRotation();
    }


    private void Update()
    {
        transform.Rotate(rotation);

        if (gameManager.isGameActive)
        {
            if (changeColorCounter <= 0)
            {
                material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
                material.SetFloat("_Metallic", Random.Range(0, 1.0f));
                material.SetFloat("_Glossiness", Random.Range(0, 1.0f));

                changeColorCounter = 1;
            }

            changeColorCounter -= Time.deltaTime;
        }
    }


    public void GetMode(int mode)
    {
        this.mode = mode;
    }


    private void OnMouseDown()
    {
        if (mode == 1 | mode == 3)
            UpdateTransform();

        gameManager.UpdateCaught(1);
    }


    private void OnMouseOver()
    {
        if (mode == 2)
            UpdateTransform();
    }


    private Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(lowerLimit, topLimit), Random.Range(rightLimit, leftLimit), Random.Range(upLimit, downLimit));
    }


    private Vector3 RandomScale()
    {
        return Vector3.one * Random.Range(2, 7);
    }


    private Vector3 RandomRotation()
    {
        float xRandomRotation = Random.Range(-10.0f, 10.0f) * Time.deltaTime;

        return new Vector3(xRandomRotation, 0, xRandomRotation / 2);
    }


    private void UpdateTransform()
    {
        if (gameManager.isGameActive)
        {
            transform.position = RandomPosition();
            transform.localScale = RandomScale();
            rotation = RandomRotation();

            if (!Renderer.isVisible)
                UpdateTransform();
        }
    }


    public void OriginalTransform()
    {
        transform.position = startPosition;
        transform.localScale = startScale;
    }
}