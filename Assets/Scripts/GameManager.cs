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
    
    public Population[] populations = new Population[3];

    [SerializeField]
    GameObject entityPrefab;

    SpawnArea spawnArea;

    [SerializeField]
    PopulationPanel populationPanel1;
    [SerializeField]
    PopulationPanel populationPanel2;
    [SerializeField]
    PopulationPanel populationPanel3;

    public Material material1;
    public Material material2;
    public Material material3;

    [SerializeField]
    TMP_InputField floorColor;
    [SerializeField]
    Material floorMaterial;

    [SerializeField]
    TMP_Text startBtn;

    [Header("Match Percentage")]
    public int MilitantsUndecided = 90;
    public int MilitantsClasics = 50;
    public int ClasicsUndecided = 70;
    public int ClasicsClasics = 25;

    [SerializeField]UnityEngine.UI.Slider MU;
    [SerializeField]UnityEngine.UI.Slider MC;
    [SerializeField]UnityEngine.UI.Slider CU;
    [SerializeField]UnityEngine.UI.Slider CC;

    [SerializeField]TMP_Text MUT;
    [SerializeField]TMP_Text MCT;
    [SerializeField]TMP_Text CUT;
    [SerializeField]TMP_Text CCT;

    public UnityEngine.UI.Toggle keepMajorityPercentage;

    [HideInInspector]
    public bool isRun = false;

    private void Start()
    {
        MC.value = MilitantsClasics;
        MU.value = MilitantsUndecided;
        CU.value = ClasicsUndecided;
        CC.value = ClasicsClasics;

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

        populations[0] = new Population(populationPanel1.name.text, Color.red, int.Parse(populationPanel1.count.text), float.Parse(populationPanel1.speed.text), (int)populationPanel1.militant.value);
        populations[1] = new Population(populationPanel2.name.text, Color.blue, int.Parse(populationPanel2.count.text), float.Parse(populationPanel2.speed.text), (int)populationPanel2.militant.value);
        populations[2] = new Population("Undecided", Color.gray, int.Parse(populationPanel3.count.text), float.Parse(populationPanel3.speed.text), 0);

        UpdateColor();
        UpdatePlaneColor();
        UpdateName();
    }

    public void ChangeState()
    {
        isRun = !isRun;
        if (isRun) spawnArea.UpdateEntiyStatus();
        startBtn.text = isRun ? "Pause" : "Play";
    }

    public void UpdateCount()
    {
        populations[0].count = int.Parse(populationPanel1.count.text);
        populations[1].count = int.Parse(populationPanel2.count.text);
        populations[2].count = int.Parse(populationPanel3.count.text);

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

        if (!ColorUtility.TryParseHtmlString(populationPanel3.color.text, out populations[2].color))
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

    private void Update()
    {
        populations[0].militant = (int)populationPanel1.militant.value;
        populations[1].militant = (int)populationPanel2.militant.value;

        if (isRun)
        {
            populationPanel1.count.interactable = false;
            populationPanel2.count.interactable = false;
            populationPanel3.count.interactable = false;

            populationPanel1.militant.interactable = false;
            populationPanel2.militant.interactable = false;

            populationPanel1.count.text = spawnArea.GetEntityCountByPopulation(populations[0]).ToString();
            populationPanel2.count.text = spawnArea.GetEntityCountByPopulation(populations[1]).ToString();
            populationPanel3.count.text = spawnArea.GetEntityCountByPopulation(populations[2]).ToString();

            populations[0].count = spawnArea.GetEntityCountByPopulation(populations[0]);
            populations[1].count = spawnArea.GetEntityCountByPopulation(populations[1]);
            populations[2].count = spawnArea.GetEntityCountByPopulation(populations[2]);
        }
        else
        {
            populationPanel1.count.interactable = true;
            populationPanel2.count.interactable = true;
            populationPanel3.count.interactable = true;

            populationPanel1.militant.interactable = true;
            populationPanel2.militant.interactable = true;
        }

        MilitantsClasics = (int)MC.value;
        MilitantsUndecided = (int)MU.value;
        ClasicsUndecided = (int)CU.value;
        ClasicsClasics = (int)CC.value;

        MUT.text = string.Format("M/U ({0}%) :", MU.value);
        MCT.text = string.Format("M/C ({0}%) :", MC.value);
        CUT.text = string.Format("C/U ({0}%) :", CU.value);
        CCT.text = string.Format("C/C ({0}%) :", CC.value);
    }

    public void UpdateEntityStatus()
    {
        spawnArea.UpdateEntiyStatus();
    }
}

public class Population
{
    public string name;
    public Color color;
    public int count;
    public float speed;
    public int militant;

    public Population(string name, Color color, int count, float speed, int militant)
    {
        this.name = name;
        this.color = color;
        this.count = count;
        this.speed = speed;
        this.militant = militant;
    }
}
