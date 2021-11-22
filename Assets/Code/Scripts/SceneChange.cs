using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    /// <summary>
    /// Metodo p�blico para cambiar la escena activa por otra.
    /// </summary>
    /// <param name="index">Es el n�mero de escena que nos da el build del proyecto.</param>
    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
