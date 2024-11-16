using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OutroCutscene : MonoBehaviour
{
    public Image screen;
    public Sprite[] slides;
    public float slideDuration = 3f;

    public GameObject exitScreen;

    private int currSlide = 0;
    public int slideAmt;

    public bool completed = false;

    void Start()
    {
        if (slides.Length > 0)
        {
            StartCoroutine(Slideshow());
        }
    }

    void Update()
    {
        if (completed)
        {
            exitScreen.SetActive(true);
        }
    }

    public void exit()
    {
        SceneManager.LoadScene("Menu");
    }

    private IEnumerator Slideshow()
    {
        for (currSlide = 0; currSlide < slideAmt; currSlide++)
        {
            screen.sprite = slides[currSlide];
            yield return new WaitForSeconds(slideDuration);
        }
        screen.enabled = false;
        completed = true;
    }
}

