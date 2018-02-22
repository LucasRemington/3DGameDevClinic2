using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

    public Text scoreT;
    public Image bg;
    private bool isUp = false;
    private float transition = 0.0f;

	void Start () {
        gameObject.SetActive(false);
	}

	void Update () {
		if (!isUp)
        {
            return;
        }
        transition += Time.deltaTime;
        bg.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black,transition);
	}

    public void ToggleEndMenu(float score)
    {
        gameObject.SetActive(true);
        scoreT.text = ("Final Score: " + ((int)score));
        isUp = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
