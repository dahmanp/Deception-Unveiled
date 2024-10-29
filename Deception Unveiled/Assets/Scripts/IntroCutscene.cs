using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IntroCutscene : MonoBehaviour
{
    public Image screen;
    public Sprite[] slides;
    public float slideDuration = 3f;

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
