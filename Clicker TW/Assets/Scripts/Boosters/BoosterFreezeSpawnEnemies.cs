using UnityEngine;

public class BoosterFreezeSpawnEnemies : MonoBehaviour, IBooster
{
    //������ ��������� ������� ������
    [SerializeField] private GameObject _destroyEffect; //��������

    private SpriteRenderer _sprite; 
    private float _activeTime = 3f; //������������ 3 �������
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
        if (_activeTimeLocal == _activeTime) //����� ���������
        {
            _destroyEffect.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Instantiate(_destroyEffect);
        }

        _activeTime -= Time.deltaTime; //����� ������� 

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
