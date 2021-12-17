using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;

public class PlayerPointManager : MonoBehaviour
{
    public int Points;
    public int Lives;
    public float Timer;

    public static PlayerPointManager instance;


    [SerializeField]
    TMP_Text PointsText;

    [SerializeField]
    TMP_Text Timertext;

    [SerializeField]
    TMP_Text LivesText;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

    }

    private void Update()
    {
        Timer -= Time.deltaTime;

        Timertext.text = Timer.ToString();

        //Update the UI stuff here, Points + lives are done in other functions
        PointsText.text = Points.ToString();

        LivesText.text = Lives.ToString();

        //win lose check

        //win condition is get 10 000 points
        //lose condition is lose all lives / timer runs out

        if (Points >= 10000)
        {
            SceneManager.LoadScene("Win");
        }

        if (Lives == -1 || Timer <= 0)
        {
            SceneManager.LoadScene("Lose");
        }


    }


}
