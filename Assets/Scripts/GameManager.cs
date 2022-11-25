using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    
    Population[] populations = new Population[3];

    [SerializeField]
    GameObject entityPrefab;

    SpawnArea spawnArea;

    [SerializeField]
    PopulationPanel populationPanel1;
    [SerializeField]
    PopulationPanel populationPanel2;
    [SerializeField]
    PopulationPanel populationPanel3;

    [SerializeField]
    Material material1;
    [SerializeField]
    Material material2;
    [SerializeField]
    Material material3;

    [SerializeField]
    TMP_InputField floorColor;
    [SerializeField]
    Material floorMaterial;

    [SerializeField]
    TMP_Text startBtn;

    public bool isRun = false;

    private void Start()
    {
        populationPanel1.name.text = "Population 1";
        populationPanel2.name.text = "Population 2";

        populationPanel1.count.text = "0";
        populationPanel2.count.text = "0";
        populationPanel3.count.text = "0";

        populationPanel1.color.text = "#ff0000";
        populationPanel2.color.text = "#0000FF";
        populationPanel3.color.text = "#5E5E5E";

        populationPanel1.speed.text = "1";
        populationPanel2.speed.text = "1";
        populationPanel3.speed.text = "1";

        floorColor.text = "#000000";

        spawnArea = GetComponent<SpawnArea>();

        populations[0] = new Population(populationPanel1.name.text, Color.red, int.Parse(populationPanel1.count.text), float.Parse(populationPanel1.speed.text));
        populations[1] = new Population(populationPanel2.name.text, Color.blue, int.Parse(populationPanel2.count.text), float.Parse(populationPanel2.speed.text));
        populations[2] = new Population("Undecided", Color.gray, int.Parse(populationPanel3.count.text), float.Parse(populationPanel3.speed.text));

        UpdateColor();
        UpdatePlaneColor();
        UpdateName();
    }

    public void ChangeState()
    {
        isRun = !isRun;
        startBtn.text = isRun ? "Pause" : "Play";
    }

    public void UpdateCount()
    {
        populations[0] = new Population(populationPanel1.name.text, Color.red, int.Parse(populationPanel1.count.text), int.Parse(populationPanel1.speed.text));
        populations[1] = new Population(populationPanel2.name.text, Color.blue, int.Parse(populationPanel2.count.text), int.Parse(populationPanel2.speed.text));
        populations[2] = new Population("Undecided", Color.gray, int.Parse(populationPanel3.count.text), float.Parse(populationPanel3.speed.text));

        spawnArea.Clear();

        material1.color = populations[0].color;
        material2.color = populations[1].color;
        material3.color = populations[2].color;

        spawnArea.Spawn(populations[0].count, entityPrefab, material1, populations[0]);
        spawnArea.Spawn(populations[1].count, entityPrefab, material2, populations[1]);
        spawnArea.Spawn(populations[2].count, entityPrefab, material3, populations[2]);
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

        if (!ColorUtility.TryParseHtmlString(populationPanel2.color.text, out populations[2].color))
        {
            populations[2].color = Color.gray;
            populationPanel3.color.text = ColorUtility.ToHtmlStringRGB(populations[2].color);
        }

        material1.color = populations[0].color;
        material2.color = populations[1].color;
        material3.color = populations[2].color;
    }

    public void UpdateSpeed()
    {
        populations[0].speed = float.Parse(populationPanel1.speed.text);
        populations[1].speed = float.Parse(populationPanel2.speed.text);
        populations[2].speed = float.Parse(populationPanel3.speed.text);
    }

    public void UpdateName()
    {
        populationPanel1.title.text = populationPanel1.name.text;
        populationPanel2.title.text = populationPanel2.name.text;
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

    public Vector3 GetRandomPosition()
    {
        return spawnArea.GetRandomPosition();
    }
}

public class Population
{
    public string name;
    public Color color;
    public int count;
    public float speed;

    public Population(string name, Color color, int count, float speed)
    {
        this.name = name;
        this.color = color;
        this.count = count;
        this.speed = speed;
    }
}
