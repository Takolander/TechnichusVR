using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInFadeOut : MonoBehaviour
{
    
    //public new GameObject gameObject;
    public Text text;
    public void FadeOut()
    {
        StartCoroutine(FadeOutCR());
    }

    private IEnumerator FadeOutCR()
    {
        float duration = 5f; //0.5 secs
        float currentTime = 0f;
        while(currentTime < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, currentTime/duration);
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
        //gameObject.SetActive(false);
        yield break;
    }
}
