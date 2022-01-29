using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiOverseer : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private TextMeshProUGUI TimerText;
    [SerializeField] private GameObject GameOverMenu;
    [SerializeField] private GameObject VictoryMenu;

    private float _timeLeft = 0f;
    public bool victory = false;

    private void Start()
    {
        _timeLeft = time;
        StartCoroutine(StartTimer());
    }

    private void Update()
    {
        if (_timeLeft <= 0)
            GameOverMenu.SetActive(true);
        if (victory)
        {
            VictoryMenu.SetActive(true);
            VictoryMenu.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "Victory\n" + TimerText.text;
        }
    }

    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
            _timeLeft = 0;

        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        TimerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    private IEnumerator StartTimer()
    {
        while (_timeLeft > 0 && !victory)
        {
            _timeLeft -= Time.deltaTime;
            UpdateTimeText();
            yield return null;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
