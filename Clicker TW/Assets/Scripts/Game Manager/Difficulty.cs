using UnityEngine;

public class Difficulty : MonoBehaviour
{
    //Класс повышения уровня сложности
    public int ChangeHp(int hp)  //Изменение ХП монстра через каждые 15 секунд
    {
        for (int i = 1; i < 10; i++)
            if (GameSceneManager.GetTimer() > 15 * i)
            {
                hp++;
            }
        return hp;
    }

    public float ChangeSpeed(float speed) //Изменение скорости монстра через каждые 10 секунд
    {
        for (int i = 1; i < 10; i++)
            if (GameSceneManager.GetTimer() > 10 * i)
            {
                speed += 0.2f;
            }
        return speed;
    }

    public float ChangeSpawnTime(float time)  //Изменение времени спавна монстра через каждые 30 секунд
    {
        for (int i = 1; i < 10; i++)
            if (GameSceneManager.GetTimer() > 30 * i)
            {
                if (time > 1)
                {
                    time -= 0.5f;
                }
            }
        return time;
    }
}
