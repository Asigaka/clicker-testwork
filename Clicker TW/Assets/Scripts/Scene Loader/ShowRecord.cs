using UnityEngine;
using UnityEngine.UI;

public class ShowRecord : MonoBehaviour
{
    //Класс для показа рекорда в сцене "Рекорд"
    [SerializeField] private Text _recordText;

    private void Start()
    {
        _recordText.text += PlayerPrefs.GetInt("Record").ToString();
    }
}
