using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sistema_puntuacion : MonoBehaviour
{
    [Header("Texto de notificacion de combo")]
    public Text texto_de_combo;
    public Text multiplicador;
    public Text score_text;
    public Text score_temp;

    [Header("Modificacion de combos")]

    public float puntos_distancia = 0.2f;
    int cacheposition;
    public GameObject player;
    public float score;
    int scoretemp;
    float combo = 1;
    public float tiempo_combo = 2;
    float combo_time;
    public int puntos_pared = 5;
    public int puntos_rotar = 10;


                
    public void puntospared ()
    {
        combo_time = tiempo_combo;
        scoretemp += (int) (puntos_pared * combo);
        combo += 0.1f;
    }

    public void puntosRotar()
    {
        combo_time = tiempo_combo;
        scoretemp += (int)(puntos_rotar * combo);
        combo += 0.1f;
    }

    public void addpoints ()
    {
        score += scoretemp;
    }

    private void Update()
    {
        if (player.transform.position.z != 0)
        {
            if ((int) player.transform.position.z != cacheposition)
            {
                cacheposition = (int) player.transform.position.z;
                score += puntos_distancia;
            }
        }

        if (combo_time > 0)
        {
            combo_time -= Time.deltaTime;
            if (combo_time == 0)
            {
                combo = 1;
                addpoints();
            }
        }
    }
}
