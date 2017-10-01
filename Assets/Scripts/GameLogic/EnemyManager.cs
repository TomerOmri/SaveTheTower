using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private enum e_Enemys{regular,fast,big }
    private enum e_EnemysAppears { fast=3, big=4 }

    private static volatile EnemyManager instance;
    private static object syncRoot = new Object();
    //public PlayerHealth playerHealth;       // Reference to the player's heatlh.
    [SerializeField] private GameObject[] enemys;                // The enemy prefab to be spawned.
	public float spawnTime = 7f;            // How long between each spawn.
    [SerializeField] private Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    [SerializeField] private Transform goal;
    private int bigEnemyAppear = 5;
    private int FastEnemyAppear = 3;

    public static EnemyManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject("EnemyManager");
                obj.AddComponent<EnemyManager>();
            }

            return instance;
        }
    }

    public void restart()
    {
        bigEnemyAppear = (int)e_EnemysAppears.big;
        FastEnemyAppear = (int)e_EnemysAppears.fast;
    }

    void Awake()
    {
        instance = this;
    }

    void Start ()
	{
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
		enemys[(int)e_Enemys.regular].GetComponent<Enemy> ().goal = goal;
        enemys[(int)e_Enemys.fast].GetComponent<Enemy>().goal = goal;
        enemys[(int)e_Enemys.big].GetComponent<Enemy>().goal = goal;
    }


	void Spawn ()
	{
        GameObject enemy;

		// Find a random index between zero and one less than the number of spawn points.
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        if(bigEnemyAppear <= 0)
        {
            FastEnemyAppear--;
            bigEnemyAppear = (int)e_EnemysAppears.big;
            enemy = enemys[(int)e_Enemys.big];
        }
        else if(FastEnemyAppear <= 0)
        {
            bigEnemyAppear--;
            FastEnemyAppear = (int)e_EnemysAppears.fast;
            enemy = enemys[(int)e_Enemys.fast];
        }
        else
        {
            FastEnemyAppear--;
            bigEnemyAppear--;
            enemy = enemys[(int)e_Enemys.regular];
        }
		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		GameObject tempEnemy = Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}
