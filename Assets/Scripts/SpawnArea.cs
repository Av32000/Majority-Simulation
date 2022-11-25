using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    [SerializeField]
    Vector3 zoneSize;
    [SerializeField]
    Transform entityParent;
    public void Spawn(int count, GameObject entityPrefab, Material material)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject go = Instantiate(entityPrefab);

            go.transform.position = new Vector3(
                Random.Range(transform.position.x - zoneSize.x / 2, transform.position.x + zoneSize.x / 2),  
                Random.Range(transform.position.y - zoneSize.y / 2, transform.position.y + zoneSize.y / 2),
                Random.Range(transform.position.z - zoneSize.z / 2, transform.position.z + zoneSize.z / 2)
                );

            go.GetComponent<Renderer>().sharedMaterial = material;

            go.transform.SetParent(entityParent);
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
}
