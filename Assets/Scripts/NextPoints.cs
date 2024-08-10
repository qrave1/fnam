using UnityEngine;

public class NextPoints : MonoBehaviour
{
    public Transform[] NextCheckPoints;
    public int id;
    int chance;

    private void Awake()
    {
        StartChance();
    }

    void StartChance()
    {
        EnemyController.toPlayerChance = 100;
        chance = EnemyController.toPlayerChance;
    }

    void SetChance()
    {
        if (id == 1)
        {
            EnemyController.toPlayerChance = 100;
        }
        else if (id == 10 | id == 11)
        {
            EnemyController.toPlayerChance = 0;
        }
    }

    public Transform getNext()
    {
        SetChance();
        chance = EnemyController.toPlayerChance;
        int rand = Random.Range(1, 100);
        if (rand <= chance)
        {
            if (NextCheckPoints.Length > 1)
            {
                var randId = Random.Range(0, NextCheckPoints.Length);
                Debug.Log($"point id = {randId}");
                return NextCheckPoints[randId];
            }
            else
            {
                return NextCheckPoints[0];
            }
        }
        else
        {
            return NextCheckPoints[0];
        }
    }
}
