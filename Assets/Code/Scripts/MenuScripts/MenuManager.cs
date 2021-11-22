using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MenuManager : MonoBehaviour
{

    [Header("Paneles")]
    [SerializeField] private GameObject[] panels;

    /// <summary>
    /// Método que cierra la pestaña donde se pulsa el botón "close".
    /// </summary>
    /// <param name="index">Indica la pestaña a cerrar.</param>
    public void ClosePanel(int index)
    {
        panels[index].SetActive(false);
    }
    public void OpenPanel(int index)
    {
        panels[index].SetActive(true);
    }
}