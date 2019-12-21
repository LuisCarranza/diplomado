using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public Image lifeBarImage;
    public Color fullLife;
    public Color emptyLife;
    public float animDuration;
    private float startTime;

    void Start()
    {
        lifeBarImage.color = fullLife;
        lifeBarImage.fillAmount = 1;
        startTime = Time.time;
    }

    void Update()
    {
        lifeBarImage.fillAmount = Mathf.Lerp(0, 1, (Time.time - startTime) / animDuration);
        lifeBarImage.color = Color.Lerp(emptyLife, fullLife, (Time.time - startTime) / animDuration);
    }
}
