using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Reload_level : MonoBehaviour
{
    public Button Button;


    void Start()
    {
        Button btn = Button.GetComponent<Button>();
        btn.onClick.AddListener(Reload);
    }

    public void Reload ()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }

}
