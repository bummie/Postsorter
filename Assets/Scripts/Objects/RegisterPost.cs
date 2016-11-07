using UnityEngine;
using System.Collections;

public class RegisterPost : MonoBehaviour
{
    // 0 Pakke, 1 Stor, 2 Liten, 3 Porto
    public int sortingBoxType = 0;

    public ScoreHandler score;
    public PortoHandler porto;

    void Start()
    {
        score = GameObject.FindGameObjectWithTag("ScoreHandler").GetComponent<ScoreHandler>();
        porto = GameObject.FindGameObjectWithTag("PortoHandler").GetComponent<PortoHandler>();
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
                    //Debug.Log("Jævlig bra, sorterte riktig!");
                    registerStamped(post.gameObject);
                    score.amount_Package++;

                    Destroy(post.gameObject);
                }
                else
                {
                    //Debug.Log("FEIL!");
                    Destroy(post.gameObject);
                    score.amount_Wrong++;
                }
            }
            else if (sortingBoxType == 1) // Stor
            {
                if (post.gameObject.name.Equals("brev_stort"))
                {
                    registerStamped(post.gameObject);
                    //Debug.Log("Jævlig bra, sorterte riktig!");
                    Destroy(post.gameObject);
                    score.amount_Large++;
                }
                else
                {
                    //Debug.Log("FEIL!");
                    Destroy(post.gameObject);
                    score.amount_Wrong++;
                }
            }
            else if (sortingBoxType == 2) // Liten
            {
                if (post.gameObject.name.Equals("brev_lite"))
                {
                    registerStamped(post.gameObject);
                    //Debug.Log("Jævlig bra, sorterte riktig!");
                    Destroy(post.gameObject);
                    score.amount_Small++;
                }
                else
                {
                    //Debug.Log("FEIL!");
                    Destroy(post.gameObject);
                    score.amount_Wrong++;
                }
            }
            else if (sortingBoxType == 3) // PORTO
            {
                //Debug.Log("Jævlig bra, sorterte riktig! KANSKJE DU SORTERTE PORTO YO");
                bool portoCorrect = porto.isPorto(post.gameObject);
                //Debug.Log("Porto: " + portoCorrect);
                registerStamped(post.gameObject);
                Destroy(post.gameObject);

                if (portoCorrect)
                    score.amount_Porto++;
            }
            else if (sortingBoxType == 4) // Gulv
            {
               // Debug.Log("Mistet posten på gulvet, ikke bra!");
                Destroy(post.gameObject);
                score.amount_Lost++;
            }
        }
        else if (post.gameObject.tag.Equals("garbage"))
        {
            if (sortingBoxType == 4) // Gulv
            {
                //Debug.Log("Mistet søppel på gulvet, jævlig bra!");
                Destroy(post.gameObject);
            }
            else
            {
                //Debug.Log("Fysj søppel!");
                score.amount_Garbage++;
                Destroy(post.gameObject);
            }
        }
        score.printScore();
    }

    private void registerStamped(GameObject post)
    {
        if (!post.GetComponent<PostInfo>().stamped)
            score.amount_notStamped++;

    }
}
