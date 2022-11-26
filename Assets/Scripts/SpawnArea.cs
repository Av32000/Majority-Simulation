using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    [SerializeField]
    Vector3 zoneSize;
    [SerializeField]
    Transform entityParent;
    public void Spawn(int count, GameObject entityPrefab, Material material, Population pop)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject go = Instantiate(entityPrefab);

            go.transform.position = GetRandomPosition();

            go.GetComponent<Renderer>().sharedMaterial = material;
            go.GetComponent<Entity>().SetPopulation(pop);

            go.transform.SetParent(entityParent);
        }

        UpdateEntiyStatus();
    }

    public void UpdateEntiyStatus()
    {
        int index = 0;
        for (int i = 0; i < entityParent.childCount; i++)
        {
            Entity entity = entityParent.GetChild(i).GetComponent<Entity>();

            if(entity.GetPopulation() == GameManager.instance.populations[0])
            {
                if (index < entity.GetPopulation().count * entity.GetPopulation().militant / 100) entity.SetType(EntityType.Militant);
                else entity.SetType(EntityType.Clasic);

                index++;
            }
            else
            {
                if (entity.GetPopulation().name == "Undecided") entity.SetType(EntityType.Undecided);
            }
        }
        index = 0;
        for (int i = 0; i < entityParent.childCount; i++)
        {
            Entity entity = entityParent.GetChild(i).GetComponent<Entity>();

            if (entity.GetPopulation() == GameManager.instance.populations[1])
            {
                if (index < entity.GetPopulation().count * entity.GetPopulation().militant / 100) entity.SetType(EntityType.Militant);
                else entity.SetType(EntityType.Clasic);

                index++;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, zoneSize);
    }

    public void Clear()
    {
        for (int i = 0; i < entityParent.childCount; i++)
        {
            Destroy(entityParent.GetChild(i).gameObject);
        }
    }

    public void GetMilitantCount()
    {
        int m = GetEntityCountByType(EntityType.Militant);
        int c = GetEntityCountByType(EntityType.Clasic);
        int u = GetEntityCountByType(EntityType.Undecided);

        Debug.Log(string.Format("Militant : {0}, Clasic : {1}, Undecided : {2}", m, c, u));
    }

    public int GetEntityCountByType(EntityType type)
    {
        int result = 0;
        for (int i = 0; i < entityParent.childCount; i++)
        {
            if (entityParent.GetChild(i).GetComponent<Entity>().GetEntityType() == type) result++;
        }

        return result;
    }

    public int GetEntityCountByPopulation(Population pop)
    {
        int result = 0;
        for (int i = 0; i < entityParent.childCount; i++)
        {
            if (entityParent.GetChild(i).GetComponent<Entity>().GetPopulation() == pop) result++;
        }

        return result;
    }

    public Vector3 GetRandomPosition()
    {
        return new Vector3(
                Random.Range(transform.position.x - zoneSize.x / 2, transform.position.x + zoneSize.x / 2),
                Random.Range(transform.position.y - zoneSize.y / 2, transform.position.y + zoneSize.y / 2),
                Random.Range(transform.position.z - zoneSize.z / 2, transform.position.z + zoneSize.z / 2)
                );
    }
}
