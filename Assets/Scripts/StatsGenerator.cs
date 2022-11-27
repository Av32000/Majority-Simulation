using TMPro;
using UnityEngine;

public class StatsGenerator : MonoBehaviour
{
    [SerializeField]
    TMP_Text pop1T;
    [SerializeField]
    TMP_Text pop2T;
    [SerializeField]
    TMP_Text pop3T;

    [SerializeField]
    RectTransform pop1;
    [SerializeField]
    RectTransform pop2;
    [SerializeField]
    RectTransform pop3;

    private void Update()
    {
        pop1.GetComponent<UnityEngine.UI.Image>().color = GameManager.instance.populations[0].color;
        pop2.GetComponent<UnityEngine.UI.Image>().color = GameManager.instance.populations[1].color;
        pop3.GetComponent<UnityEngine.UI.Image>().color = GameManager.instance.populations[2].color;

        pop1T.color = ReverseColor(GameManager.instance.populations[0].color);
        pop2T.color = ReverseColor(GameManager.instance.populations[1].color);
        pop3T.color = ReverseColor(GameManager.instance.populations[2].color);

        float totalCount = GameManager.instance.populations[0].count + GameManager.instance.populations[1].count + GameManager.instance.populations[2].count;

        if (totalCount > 0)
        {
            pop1.localScale = new Vector3(pop1.localScale.x, GameManager.instance.populations[0].count / totalCount, pop1.localScale.y);
            pop2.localScale = new Vector3(pop2.localScale.x, GameManager.instance.populations[1].count / totalCount, pop2.localScale.y);
            pop3.localScale = new Vector3(pop3.localScale.x, GameManager.instance.populations[2].count / totalCount, pop3.localScale.y);
        }

        pop1T.text = string.Format("{0}\n({1}%)", GameManager.instance.populations[0].count, Mathf.Round(pop1.localScale.y * 100));
        pop2T.text = string.Format("{0}\n({1}%)", GameManager.instance.populations[1].count, Mathf.Round(pop2.localScale.y * 100));
        pop3T.text = string.Format("{0}\n({1}%)", GameManager.instance.populations[2].count, Mathf.Round(pop3.localScale.y * 100));
    }

    private void ResetStats()
    {
        pop1.localScale = new Vector3(pop1.localScale.x,0,pop1.localScale.y);
        pop2.localScale = new Vector3(pop2.localScale.x,0,pop2.localScale.y);
        pop3.localScale = new Vector3(pop3.localScale.x,0,pop3.localScale.y);

        pop1T.text = "0\n(0%)";
        pop2T.text = "0\n(0%)";
        pop3T.text = "0\n(0%)";
    }

    Color ReverseColor(Color c)
    {
        return new Color(255 - c.r, 255 - c.g, 255 - c.b);
    }
}
