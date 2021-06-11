using UnityEngine;

public class BoosterFreezeSpawnEnemies : MonoBehaviour, IBooster
{
    //Бустер заморозки времени спавна
    [SerializeField] private GameObject _destroyEffect; //Партиклы

    private SpriteRenderer _sprite; 
    private float _activeTime = 3f; //Длительность 3 секунды
    private float _activeTimeLocal; 

    private bool _isActive;
    public bool IsActive { get => _isActive; set => _isActive = value; }

    private void Start()
    {
        _activeTimeLocal = _activeTime;
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (IsActive)
        {
            Activate();
        }
    }

    public void Activate()
    {
        if (_activeTimeLocal == _activeTime) //Спавн партиклов
        {
            _destroyEffect.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Instantiate(_destroyEffect);
        }

        _activeTime -= Time.deltaTime; //отчёт времени 

        EnemiesSpawner.IsFreeze = true; 

        _sprite.enabled = false;

        if (_activeTime <= 0f)
        {
            IsActive = false;
            EnemiesSpawner.IsFreeze = false;
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        IsActive = true;
    }
}
