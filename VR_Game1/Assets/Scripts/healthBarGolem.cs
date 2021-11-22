using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBarGolem : MonoBehaviour
{
    [SerializeField]
    private Image foregroundImage;

    public float updateSpeedSeconds = 0.2f;

    //public Camera cam;

    private void Awake()
    {
        GetComponentInParent<EnemyAIGolem>().OnHealthPctChanged += HandleHealthChanged;
    }

    private void HandleHealthChanged(float pct)
    {
        //foregroundImage.fillAmount = pct;
        StartCoroutine(ChangeToPct(pct));
    }

    private IEnumerator ChangeToPct(float pct)
    {
        float preChangePct = foregroundImage.fillAmount;
        float elapsed = 0f;

        while (elapsed < updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            foregroundImage.fillAmount = Mathf.Lerp(preChangePct, pct, elapsed / updateSpeedSeconds);
            yield return null;
        }

        foregroundImage.fillAmount = pct;
    }

    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }
}
