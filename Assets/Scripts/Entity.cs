using UnityEngine;

public class Entity : MonoBehaviour
{
    Population pop;
    Vector3 target;

    EntityType type;

    void Update()
    {
        if (!GameManager.instance.isRun || pop == null) return;

        if (target == Vector3.zero)
        {
            target = GameManager.instance.GetRandomPosition();
        }

        Vector3 dir = target - transform.position;
        transform.Translate(dir.normalized * pop.speed * 10 * Time.deltaTime, Space.World);

        if (Vector3.Distance(target, transform.position) <= 1)
        {
            target = GameManager.instance.GetRandomPosition();
        }
    }

    public void SetPopulation(Population pop)
    {
        this.pop = pop;
    }

    public void SetType(EntityType type)
    {
        this.type = type;
    }

    public EntityType GetEntityType()
    {
        return type;
    }

    public Population GetPopulation()
    {
        return pop;
    }
}

public enum EntityType
{
    Undecided,
    Clasic,
    Militant
}
