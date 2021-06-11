using UnityEngine;

public class Difficulty : MonoBehaviour
{
    //����� ��������� ������ ���������
    public int ChangeHp(int hp)  //��������� �� ������� ����� ������ 15 ������
    {
        for (int i = 1; i < 10; i++)
            if (GameSceneManager.GetTimer() > 15 * i)
            {
                hp++;
            }
        return hp;
    }

    public float ChangeSpeed(float speed) //��������� �������� ������� ����� ������ 10 ������
    {
        for (int i = 1; i < 10; i++)
            if (GameSceneManager.GetTimer() > 10 * i)
            {
                speed += 0.2f;
            }
        return speed;
    }

    public float ChangeSpawnTime(float time)  //��������� ������� ������ ������� ����� ������ 30 ������
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
