using UnityEngine;
using System.Collections;

public class RegisterPost : MonoBehaviour
{
    // 0 Pakke, 1 Stor, 2 Liten, 3 Porto
    public int sortingBoxType = 0;

    public ScoreHandler score;

    void Start()
    {
        score = GameObject.FindGameObjectWithTag("ScoreHandler").GetComponent<ScoreHandler>();
    }

    // When post enters the sortingbox
    void OnTriggerEnter(Collider post)
    {
        // Sjekker om det er post
        if (post.gameObject.tag.Equals("post"))
        {
            // Om sortet pakke
            if (sortingBoxType == 0)
            {
                if (post.gameObject.name.Equals("pakke"))
                {
                    Debug.Log("Jævlig bra, sorterte riktig!");
                    Destroy(post);
                    score.amount_Package++;
                }
                else
                {
                    Debug.Log("FEIL!");
                    Destroy(post);
                    score.amount_Wrong++;
                }
            }
            else if(sortingBoxType == 1) // Stor
            {
                if (post.gameObject.name.Equals("brev_stort"))
                {
                    Debug.Log("Jævlig bra, sorterte riktig!");
                    Destroy(post);
                    score.amount_Large++;
                }
                else
                {
                    Debug.Log("FEIL!");
                    Destroy(post);
                    score.amount_Wrong++;
                }
            }
            else if (sortingBoxType == 2) // Liten
            {
                if (post.gameObject.name.Equals("brev_lite"))
                {
                    Debug.Log("Jævlig bra, sorterte riktig!");
                    Destroy(post);
                    score.amount_Small++;
                }
                else
                {
                    Debug.Log("FEIL!");
                    Destroy(post);
                    score.amount_Wrong++;
                }
            }
            else if (sortingBoxType == 3) // PORTO
            {
                Debug.Log("Jævlig bra, sorterte riktig! KANSKJE DU SORTERTE PORTO YO");
                Destroy(post);
                score.amount_Porto++;
            }
            else if (sortingBoxType == 4) // Gulv
            {
                Debug.Log("Mistet posten på gulvet, ikke bra!");
                Destroy(post);
                score.amount_Lost++;
            }
        }
        //score.printScore();
    }
}
