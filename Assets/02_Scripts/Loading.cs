using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    [SerializeField] private Slider slider;
    float maxTime = 3f;
    float time = 0;

    private void Update()
    {
        time += Time.deltaTime;
        slider.value = time / maxTime;

        if (slider.value == 1)
            gameObject.SetActive(false);
    }
}
