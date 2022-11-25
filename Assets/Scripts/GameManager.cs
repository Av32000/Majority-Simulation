using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Population[] populations = new Population[2];

    [SerializeField]
    GameObject entityPrefab;

    SpawnArea spawnArea;

    [SerializeField]
    PopulationPanel populationPanel1;
    [SerializeField]
    PopulationPanel populationPanel2;

    [SerializeField]
    Material material1;
    [SerializeField]
    Material material2;

    private void Start()
    {
        populationPanel1.count.text = "0";
        populationPanel2.count.text = "0";

        spawnArea = GetComponent<SpawnArea>();

        populations[0] = new Population(populationPanel1.name.text, Color.red, int.Parse(populationPanel1.count.text));
        populations[1] = new Population(populationPanel2.name.text, Color.blue, int.Parse(populationPanel2.count.text));
    }

    public void UpdateCount()
    {
        populations[0] = new Population(populationPanel1.name.text, Color.red, int.Parse(populationPanel1.count.text));
        populations[1] = new Population(populationPanel2.name.text, Color.blue, int.Parse(populationPanel2.count.text));

        spawnArea.Clear();

        material1.color = populations[0].color;
        material2.color = populations[1].color;

        spawnArea.Spawn(populations[0].count, entityPrefab, material1);
        spawnArea.Spawn(populations[1].count, entityPrefab, material2);
    }
}

public class Population
{
    public string name;
    public Color color;
    public int count;

    public Population(string name, Color color, int count)
    {
        this.name = name;
        this.color = color;
        this.count = count;
    }
}
