using System;
using UnityEngine;
using UnityEngine.UI;

public class LoadBar : MonoBehaviour
{
    public float fillSpeed = 0.5f; // Velocità di riempimento della barra di caricamento
    private Image barFill; // Riferimento all'immagine che rappresenta la barra di caricamento
    private float targetFillAmount = 0f; // Percentuale di riempimento desiderata

    void Start()
    {
        barFill = GetComponent<Image>();
    }

    void Update()
    {
        // Interpolazione verso la percentuale di riempimento desiderata
        barFill.fillAmount = Mathf.MoveTowards(barFill.fillAmount, targetFillAmount, fillSpeed * Time.deltaTime);
    }

    // Metodo per impostare la percentuale di riempimento della barra di caricamento
    public void SetFillAmount(float amount)
    {
        targetFillAmount = Mathf.Clamp01(amount);
    }
}
