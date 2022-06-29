using UnityEngine;

public class BGMManager : MonoBehaviour
{
    private Cube cube;

    private AudioSource BGMAudio;

    [SerializeField] private AudioClip menuBGM;
    [SerializeField] private AudioClip mode3BGM;
    [SerializeField] private AudioClip modes1n2BGM;


    private void Start()
    {
        cube = GameObject.Find("Cube").GetComponent<Cube>();

        BGMAudio = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if (!BGMAudio.isPlaying)
            BGMAudio.Play();


        switch (cube.mode)
        {
            case 1: case 2:
                BGMAudio.clip = modes1n2BGM;
                break;

            case 3:
                BGMAudio.clip = mode3BGM;
                break;

            default:
                BGMAudio.clip = menuBGM;
                break;
        }
    }
}