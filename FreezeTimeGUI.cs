using UnityEngine;
using System.Collections;

public class FreezeTimeGUI : MonoBehaviour
{
    public GameObject obj;

    private string key = "escape";

    void Start()
    {
        obj.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(key))
            Appear();
    }

    public void Appear()
    {
        if (obj.activeSelf == false)
        {
            Time.timeScale = 0;
            obj.SetActive(true);
        }

        else
        {
            obj.SetActive(false);
            Time.timeScale = 1;
        }
    }
}