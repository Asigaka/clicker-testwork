using System.Collections;
using UnityEngine;

public class BoosterKillAllEnemies : MonoBehaviour, IBooster
{
    //Бустер убийства всех монстров
    [SerializeField] private GameObject _destroyEffect; //Партиклы

    private bool _isActive;
    public bool IsActive { get => _isActive; set => _isActive = value; }

    private void Update()
    {
        if (IsActive)
        {
            StartCoroutine(Active());
        }
    }

    public void Activate()
    {
        StartCoroutine(Active());
    }

    private void OnMouseDown()
    {
        IsActive = true;
    }

    private IEnumerator Active()
    {
        _destroyEffect.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Instantiate(_destroyEffect);

        EnemiesSpawner.IsKillAllEnemies = true;
        yield return new WaitForSeconds(0.1f);
        IsActive = false;
        Destroy(gameObject);
    }
}
