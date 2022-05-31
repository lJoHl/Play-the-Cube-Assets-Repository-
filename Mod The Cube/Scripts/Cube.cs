using UnityEngine;

namespace ModTheCube
{
    public class Cube : MonoBehaviour
    {
        private MeshRenderer Renderer;

        private float lowerLimit = 3;
        private float topLimit = -30;
        private float rightLimit = 4;
        private float leftLimit = -10;
        private float upLimit = 8;
        private float downLimit = -9;

        private float xRandomRotation;

        private float counter;


        private void Start()
        {
            Renderer = GetComponent<MeshRenderer>();

            transform.position = new Vector3(Random.Range(lowerLimit, topLimit), Random.Range(rightLimit, leftLimit), Random.Range(upLimit, downLimit));
            transform.localScale = Vector3.one * Random.Range(2, 7);

            xRandomRotation = Random.Range(1.0f, 10.0f) * Time.deltaTime;
        }


        private void Update()
        {
            // makes the cube rotate
            transform.Rotate(xRandomRotation, 0, xRandomRotation / 2);

            // change the color of the cube every so often
            Material material = Renderer.material;
            if (counter <= 0)
            {
                material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));

                counter = 1;
            }

            counter -= Time.deltaTime;
        }
    }
}