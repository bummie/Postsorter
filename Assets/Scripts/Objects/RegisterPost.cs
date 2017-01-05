using UnityEngine;
using System.Collections;

public class RegisterPost : MonoBehaviour
{
    // 0 Pakke, 1 Stor, 2 Liten, 3 Porto
    public int sortingBoxType = 0;

    private ScoreHandler score;
    private PortoHandler porto;
    private AudioSource Lyd_Korrekt, Lyd_Feil, Lyd_Porto;

    void Start()
    {
        score = GameObject.FindGameObjectWithTag("ScoreHandler").GetComponent<ScoreHandler>();
        porto = GameObject.FindGameObjectWithTag("PortoHandler").GetComponent<PortoHandler>();

        //Lyder
        Lyd_Korrekt = GameObject.FindGameObjectWithTag("Lyd_Korrekt").GetComponent<AudioSource>();
        Lyd_Feil = GameObject.FindGameObjectWithTag("Lyd_Feil").GetComponent<AudioSource>();
        Lyd_Porto = GameObject.FindGameObjectWithTag("Lyd_Porto").GetComponent<AudioSource>();
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
                    score.amount_Package++;
                    sortertRiktig(post.gameObject);
                }
                else
                    sortertFeil(post.gameObject);
            }
            else if (sortingBoxType == 1) // Stor
            {
                if (post.gameObject.name.Equals("brev_stort"))
                {
                    sortertRiktig(post.gameObject);
                    score.amount_Large++;
                }
                else
                    sortertFeil(post.gameObject);
            }
            else if (sortingBoxType == 2) // Liten
            {
                if (post.gameObject.name.Equals("brev_lite"))
                {
                    sortertRiktig(post.gameObject);
                    score.amount_Small++;
                }
                else
                    sortertFeil(post.gameObject);
            }
            else if (sortingBoxType == 3) // PORTO
            {
                //Debug.Log("Jævlig bra, sorterte riktig! KANSKJE DU SORTERTE PORTO YO");
                bool portoCorrect = porto.isPorto(post.gameObject);
                //Debug.Log("Porto: " + portoCorrect);
                registerStamped(post.gameObject);
                Destroy(post.gameObject);

                if (portoCorrect)
                {
                    score.amount_Porto++;
                    playSoundPorto();
                }
                else
                {
                    score.amount_Wrong++;
                    playSoundWrong();
                }
                
            }
            else if (sortingBoxType == 4) // Gulv
            {
                // Debug.Log("Mistet posten på gulvet, ikke bra!");
                Destroy(post.gameObject);
                score.amount_Lost++;
                playSoundWrong();
            }
        }
        else if (post.gameObject.tag.Equals("garbage"))
        {
            if (sortingBoxType == 4) // Gulv
            {
                //Debug.Log("Mistet søppel på gulvet, jævlig bra!");
                Destroy(post.gameObject);
                playSoundCorrect();
            }
            else
            {
                //Debug.Log("Fysj søppel!");
                score.amount_Garbage++;
                Destroy(post.gameObject);
                playSoundWrong();
            }
        }
        //score.printScore();
    }

    private void registerStamped(GameObject post)
    {
        if (!post.GetComponent<PostInfo>().stamped)
            score.amount_notStamped++;
        else
            score.amount_Stamped++;
    }

    private void sortertFeil(GameObject post)
    {
        playSoundWrong();
        registerStamped(post);
        Destroy(post);
        score.amount_Wrong++;
    }

    private void sortertRiktig(GameObject post)
    {
        registerStamped(post);
        Destroy(post);
        playSoundCorrect();
    }

    private void playSoundCorrect()
    {
        Lyd_Korrekt.Play();
    }

    private void playSoundPorto()
    {
        Lyd_Porto.Play();
    }

    private void playSoundWrong()
    {
        Lyd_Feil.Play();
    }
}
