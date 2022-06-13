using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingInGame : MonoBehaviour
{
    public GameObject settingPanel;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //settingPanel.SetActive(!settingPanel.activeInHierarchy);
            //settingPanel.GetComponent<Animator>().SetBool("Open", settingPanel.activeInHierarchy);
            
           
        }
        Cursor.visible = true;
    }
}
