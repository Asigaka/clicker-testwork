using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesSpawner : MonoBehaviour, ISpawner
{
    //Класс спавна монстров
    [SerializeField] private GameObject _losePanel; //Панель, которая вызывается при поражении
    [SerializeField] private GameObject _mainPanel; //Главная панель(игровое поле)

    [SerializeField] private Text _thisGameRecordText; //Количество набранных очков за этот сеанс
    [SerializeField] private Text _RecordText; //Общий рекорд

    [SerializeField] private List<GameObject> _enemyList;  //Лист, в который будут добавляться заспауненые монстры
    [SerializeField] private GameObject _enemyObject;  //Префаб монстра

    private List<int> _saveRecord = new List<int>();

    //Проверки bool бустеров
    private static bool _isFreeze = false;
    private static bool _isKillAllEnemies = false;

    private bool _isLose = false;

    public static bool IsFreeze { get => _isFreeze; set => _isFreeze = value; }
    public static bool IsKillAllEnemies { get => _isKillAllEnemies; set => _isKillAllEnemies = value; }


    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private void Update()
    {
        //Чистим missing object в листе
        _enemyList.RemoveAll(GameObject => GameObject == null);
    }

    public IEnumerator Spawn()
    {
        while (!_isLose)
        {
            if (!IsFreeze)
            {
                yield return new WaitForSeconds(EnemyStats.SpawnTimeEnemies);

                Vector3 SpawnPosition = new Vector3();

                if (_enemyList.Count != 10)
                {
                    SpawnPosition.x = Random.Range(-2.4f, 2.4f);
                    SpawnPosition.y = Random.Range(-4.6f, 4.6f);
                    _enemyList.Add(Instantiate(_enemyObject, SpawnPosition, Quaternion.identity));
                }
                else
                {
                    Lose();
                    yield return null;
                }
            }
            else
            {
                yield return new WaitForSeconds(EnemyStats.SpawnTimeEnemies);
            }
        }
    }

    private void Lose()
    {
        _isLose = true;
        //Записываем результат

        int i = 0;
        while (PlayerPrefs.HasKey("Record" + i))
        {
            _saveRecord.Add(PlayerPrefs.GetInt("Record" + i));
            i++;
        }

        int k = 0;
        if (i == 0)
        {
            do 
            {
                _saveRecord.Add(GameSceneManager.GetTimer());
                PlayerPrefs.SetInt("Record" + i, GameSceneManager.GetTimer());
                PlayerPrefs.SetInt("Record" + i, _saveRecord[i]);
            } while (_saveRecord[k] < GameSceneManager.GetTimer());
        }

        _saveRecord = (from record in _saveRecord
                       orderby record descending
                       select record).ToList();

        _thisGameRecordText.text += GameSceneManager.GetTimer().ToString() + " секунд";
        _RecordText.text += _saveRecord[0] + " секунд";

        //Меняем активные панели
        _mainPanel.SetActive(false);
        _losePanel.SetActive(true);
    }
}
