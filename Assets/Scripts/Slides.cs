using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slides : MonoBehaviour
{
    public GameObject[] slides;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowSlides());
    }

    private IEnumerator ShowSlides()
    {
        

        // Show first slide for 4 seconds
        slides[0].SetActive(true);
        yield return new WaitForSeconds(4);
        slides[0].SetActive(false);

        // Fade in and out second slide over 2 seconds
        yield return StartCoroutine(FadeSlide(slides[1], 2));

        // Fade in and out third slide over 5 seconds
        yield return StartCoroutine(FadeSlide(slides[2], 10));
    }

    private IEnumerator FadeSlide(GameObject slide, float duration)
    {
        slide.SetActive(true);
        float halfDuration = duration / 2;
        float timer = 0;

        // Assuming the slide has a CanvasGroup or SpriteRenderer to modify the alpha
        Image slideImage = slide.GetComponent<Image>();
        if (slideImage == null)
        {
            Debug.LogError("Slide does not have a CanvasGroup component");
            yield break;
        }

        Color initialColor = slideImage.color;
        Color transparentColor = new Color(initialColor.r, initialColor.g, initialColor.b, 0);

        // Fade in
        while (timer < halfDuration)
        {
            slideImage.color = Color.Lerp(transparentColor, initialColor, timer / halfDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        // Fade out
        timer = 0; // Reset timer for fade out
        while (timer < halfDuration)
        {
            slideImage.color = Color.Lerp(initialColor, transparentColor, timer / halfDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        slide.SetActive(false);
    }
}
