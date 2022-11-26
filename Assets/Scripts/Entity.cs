using UnityEngine;

public class Entity : MonoBehaviour
{
    Population pop;
    Vector3 target;

    EntityType type;

    void Update()
    {
        if (pop == GameManager.instance.populations[0]) GetComponent<Renderer>().material = GameManager.instance.material1;
        else if (pop == GameManager.instance.populations[1]) GetComponent<Renderer>().material = GameManager.instance.material2;
        else GetComponent<Renderer>().material = GameManager.instance.material3;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag) && GameManager.instance.isRun)
        {
            other.GetComponent<Entity>().Match(pop, type);
        }
    }

    public void Match(Population _pop, EntityType _type)
    {
        if (pop == _pop || _type == EntityType.Undecided || type == EntityType.Militant) return;
        if(_type == EntityType.Clasic && type == EntityType.Undecided)
        {
            if (Random.Range(0, 100) < GameManager.instance.ClasicsUndecided)
            {
                Convert(_pop);
            }
        }
        else
        {
            if(type == EntityType.Undecided)
            {
                if (Random.Range(0, 100) < GameManager.instance.MilitantsUndecided)
                {
                    Convert(_pop);
                }
            }
            else
            {
                if (Random.Range(0, 100) < GameManager.instance.MilitantsClasics)
                {
                    Convert(_pop);
                }
            }
        }
    }

    void Convert(Population _pop)
    {
        pop = _pop;
        type = EntityType.Clasic;
    }
}

public enum EntityType
{
    Undecided,
    Clasic,
    Militant
}
