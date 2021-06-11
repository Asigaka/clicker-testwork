using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesSpawner : MonoBehaviour, ISpawner
{
    //����� ������ ��������
    [SerializeField] private GameObject _losePanel; //������, ������� ���������� ��� ���������
    [SerializeField] private GameObject _mainPanel; //������� ������(������� ����)

    [SerializeField] private Text _thisGameRecordText; //���������� ��������� ����� �� ���� �����
    [SerializeField] private Text _RecordText; //����� ������

    [SerializeField] private List<GameObject> _enemyList;  //����, � ������� ����� ����������� ����������� �������
    [SerializeField] private GameObject _enemyObject;  //������ �������

    //�������� bool ��������
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
        //������ missing object � �����
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
        //���������� ���������
        if (PlayerPrefs.GetInt("Record") < GameSceneManager.GetTimer())
        {
            PlayerPrefs.SetInt("Record", GameSceneManager.GetTimer());
        }

        _thisGameRecordText.text += GameSceneManager.GetTimer().ToString() + " ������";
        _RecordText.text += PlayerPrefs.GetInt("Record").ToString() + " ������";
        //������ �������� ������
        _mainPanel.SetActive(false);
        _losePanel.SetActive(true);
    }
}
