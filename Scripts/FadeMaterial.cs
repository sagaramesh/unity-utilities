using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach this to a GameObject with a material (standard shader, fade rendering mode) you want to fade in / out.
public class FadeMaterial : MonoBehaviour
{
    [SerializeField] private float _transitionTime = 0.5f;
    private Color _transparent = new Color(0, 0, 0, 0);

    public void Start()
    {
        // Fade from current color to transparent.
        StartCoroutine(Fade(_transparent, _transitionTime));
    }

    IEnumerator Fade(Color endValue, float duration)
    {
        float time = 0;
        Material thisMaterial = this.GetComponent<MeshRenderer>().material;
        Color startValue = thisMaterial.color;

        while (time < duration)
        {
            thisMaterial.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        thisMaterial.color = endValue;
    }
}