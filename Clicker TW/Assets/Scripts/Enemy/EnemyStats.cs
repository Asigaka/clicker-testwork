using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    //Данные монстра
    [SerializeField] private int _hp = 1; //Количество ХП
    [SerializeField] private float _speed = 1.5f; //Скорость
    [SerializeField] private int _damageToEnemy = 1; //Урон монстру
    
    private static float _spawnTimeEnemies = 3f; //Скорость появления монстра
    private Difficulty _difficulty;

    //Локальные переменные
    private int _hpLocal;
    private float _speedLocal;
    private float _spawnTimeLocal;

    public int Hp { get => _hp; set => _hp = value; }
    public float Speed { get => _speed; set => _speed = value; }
    public int DamageToEnemy { get => _damageToEnemy; set => _damageToEnemy = value; }
    public static float SpawnTimeEnemies { get => _spawnTimeEnemies; set => _spawnTimeEnemies = value; }

    private void Start()
    {
        _difficulty = gameObject.AddComponent<Difficulty>();
        _hpLocal = _hp;
        _speedLocal = _speed;
        _spawnTimeLocal = _spawnTimeEnemies;
    }
    private void Update()
    {
        _hp = _difficulty.ChangeHp(_hpLocal);
        _speed = _difficulty.ChangeSpeed(_speedLocal);
        _spawnTimeEnemies = _difficulty.ChangeSpawnTime(_spawnTimeLocal);
    }
}
