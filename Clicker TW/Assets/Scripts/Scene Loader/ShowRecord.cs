using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ShowRecord : MonoBehaviour
{
    //Класс для показа рекорда в сцене "Рекорд"
    [SerializeField] private Text _recordText;

    private List<int> _saveRecord = new List<int>();

    private void Start()
    {
        string name = "";
        int i = 0;
        while (PlayerPrefs.HasKey("Record" + i))
        {
            _saveRecord.Add(PlayerPrefs.GetInt("Record" + i));
            i++;
        }

        _saveRecord = (from record in _saveRecord
                       orderby record descending
                       select record).Take(5).ToList();

        foreach (int k in _saveRecord)
            name += $"\n{k}";

        _recordText.text += name;
    }
}
