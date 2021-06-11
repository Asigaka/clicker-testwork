using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Класс поведения монстра
    [SerializeField] private GameObject _destroyEffect; //Партиклы при убийстве 

    private int _hp;
    private Vector2 _randomVector;  //Вектор случайного движения  
    private float _waitTime = 5f;
    private float _speed;

    private bool _isTached = false; //Переменная статуса нажатия на монстра

    private EnemyStats enemyStats;

    private void Start()
    {
        enemyStats = gameObject.AddComponent<EnemyStats>();
        _hp = enemyStats.Hp;
        _speed = enemyStats.Speed;

        //Задаём изначальный вектор движения
        _randomVector.x = Random.Range(-2.4f, 2.4f);
        _randomVector.y = Random.Range(-4.6f, 4.6f);
    }

    private void Update()
    {
        //Если мы не нажали на монстра, то синхронизируем его хп со сложностью
        if (!_isTached)
        {
            _hp = enemyStats.Hp;
        }
    }

    private void FixedUpdate()
    {
        DestroyEnemy();
        Move();
    }
    private void DestroyEnemy()
    {
        if (_hp <= 0 || EnemiesSpawner.IsKillAllEnemies)
        {
            _destroyEffect.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Instantiate(_destroyEffect);
            EnemiesSpawner.IsKillAllEnemies = false;
            Destroy(gameObject);
        }
    }

    private void Move()  
    {
        transform.position = Vector2.MoveTowards(transform.position, _randomVector, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _randomVector) < 1f)
        {
            if (_waitTime <= 0)
            {
                _randomVector.x = Random.Range(-2.4f, 2.4f);
                _randomVector.y = Random.Range(-4.6f, 4.6f);
                _waitTime = 5f;
            }
            else
            {
                _waitTime -= Time.deltaTime;
            }
        }
    }

    private void OnMouseDown()
    {
        _isTached = true;
        _hp -= enemyStats.DamageToEnemy;
    }
}
