using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviour
{
    //Класс, который пока служит для отображения прошедшего времени(Результата)
    [SerializeField] private Text _timerText;

    private float _time = 0;
    private static int _timer;

    private void Update()
    {
        _timerText.text = Timer().ToString();
    }

    public int Timer()
    {
        _time += Time.deltaTime;
        _timer = (int)_time;
        return _timer;
    }

    public static int GetTimer() => _timer;
}
