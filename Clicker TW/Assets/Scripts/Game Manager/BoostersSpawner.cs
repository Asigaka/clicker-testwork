using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostersSpawner : MonoBehaviour, ISpawner
{
    //Класс спавна бустеров
    [SerializeField] private List<GameObject> _boostersList; //Лист с префабами бустеров

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        while (true)  //Неограниченный спавн бустеров
        {
            yield return new WaitForSeconds(Random.Range(6f, 20f));

            Vector3 SpawnPosition = new Vector3();

            SpawnPosition.x = Random.Range(-2.4f, 2.4f);
            SpawnPosition.y = Random.Range(-4.6f, 4.6f);
            Instantiate(_boostersList[Random.Range(0, _boostersList.Count)], SpawnPosition, Quaternion.identity);
        }
    }
}
