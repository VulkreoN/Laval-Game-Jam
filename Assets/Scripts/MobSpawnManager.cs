using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float spawnDistance = 10f;
    [SerializeField] private float spawnMinInterval = 30f;
    [SerializeField] private float spawnMaxIterval = 120f;
    [SerializeField] private int maxMobs = 10;
    [SerializeField] private List<GameObject> mobsPrefab;
    [SerializeField] private GameObject mobsSpawnerPrefab;

    public List<MobSpawner> spawners = new List<MobSpawner>();
    public List<Mob> mobs = new List<Mob>();

    private float currentInterval = 0;
    private float timer = 0f;
    
    private void Spawn()
    {
        GameObject spawner = Instantiate(mobsSpawnerPrefab, transform.position, Quaternion.identity);
        MobSpawner spawner_scp = spawner.GetComponent<MobSpawner>();
        GameObject randomMob = mobsPrefab[Random.Range(0, mobsPrefab.Count)];
        spawner_scp.mobPrefab = randomMob;
        spawner_scp.player = player;
        spawner_scp.mobSpawnManager = this;
        spawners.Add(spawner_scp);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        currentInterval = Random.Range(spawnMinInterval, spawnMaxIterval);

        Spawn();
        currentInterval = Random.Range(spawnMinInterval, spawnMaxIterval);
        timer = 0;
    }

    private void SpawnMob()
    {
        if (currentInterval < timer && mobs.Count + spawners.Count < maxMobs)
        {
            Spawn();
            currentInterval = Random.Range(spawnMinInterval, spawnMaxIterval);
            timer = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SpawnMob();
        timer += Time.deltaTime;
    }
}
