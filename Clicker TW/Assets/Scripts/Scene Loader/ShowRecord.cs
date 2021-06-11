using UnityEngine;
using UnityEngine.UI;

public class ShowRecord : MonoBehaviour
{
    //����� ��� ������ ������� � ����� "������"
    [SerializeField] private Text _recordText;

    private void Start()
    {
        _recordText.text += PlayerPrefs.GetInt("Record").ToString();
    }
}
