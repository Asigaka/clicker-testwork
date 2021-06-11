using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    //Класс для воспроизведения музыки
    [SerializeField] private string _createdTag;

    private void Awake()
    {
        GameObject obj = GameObject.FindWithTag(this._createdTag);

        if (obj != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            this.gameObject.tag = this._createdTag;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
