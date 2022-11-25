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

    [SerializeField]
    TMP_InputField floorColor;
    [SerializeField]
    Material floorMaterial;

    private void Start()
    {
        populationPanel1.count.text = "0";
        populationPanel2.count.text = "0";

        populationPanel1.color.text = "#ff0000";
        populationPanel2.color.text = "#0000FF";

        floorColor.text = "#000000";

        spawnArea = GetComponent<SpawnArea>();

        populations[0] = new Population(populationPanel1.name.text, Color.red, int.Parse(populationPanel1.count.text));
        populations[1] = new Population(populationPanel2.name.text, Color.blue, int.Parse(populationPanel2.count.text));

        UpdateColor();
        UpdatePlaneColor();
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

    public void UpdateColor()
    {
        if (!ColorUtility.TryParseHtmlString(populationPanel1.color.text, out populations[0].color))
        {
            populations[0].color = Color.red;
            populationPanel1.color.text = ColorUtility.ToHtmlStringRGB(populations[0].color);
        }

        if (!ColorUtility.TryParseHtmlString(populationPanel2.color.text, out populations[1].color))
        {
            populations[1].color = Color.blue;
            populationPanel2.color.text = ColorUtility.ToHtmlStringRGB(populations[1].color);
        }

        material1.color = populations[0].color;
        material2.color = populations[1].color;
    }

    public void UpdatePlaneColor()
    {
        Color floorColorC;
        if (!ColorUtility.TryParseHtmlString(floorColor.text, out floorColorC))
        {
            floorColorC = Color.black;
            floorColor.text = "#000000";
        }

        floorMaterial.color = floorColorC;
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
