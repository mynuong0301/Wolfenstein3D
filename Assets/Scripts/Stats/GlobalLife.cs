using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalLife : MonoBehaviour
{
    public GameObject lifeDisplay;
    public static int lifeValue;
    public int maxLife = 3;
    public int internalLife;
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        lifeValue = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        internalLife = lifeValue;
        lifeDisplay.GetComponent<Text>().text = "" + lifeValue;

        if (lifeValue <= 0)
        {
            gameOverPanel.SetActive(true);
            GlobalHealth.isDead = true;
        }
    }
}
