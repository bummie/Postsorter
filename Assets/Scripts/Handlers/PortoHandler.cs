using UnityEngine;
using System.Collections;

public class PortoHandler : MonoBehaviour {

    private float[] portoPris1, portoPris2, portoPris3;
    private GameObject particleObj;

	void Start ()
    {
        initPortoLister();
        particleObj = GameObject.FindGameObjectWithTag("particle_porto");
    }

    //
    // Rotetete nested ifsatansPortoSjekker
    //
    public bool isPorto(GameObject porto)
    {
        bool isPorto = false;

        if (porto.tag.Equals("post"))
        {
            float paid = porto.GetComponent<PostInfo>().paidPorto;
            float length, width, height;
            Vector3 size = porto.GetComponent<PostInfo>().size;
            if (size.x >= size.z)
            {
                length = size.x;
                width = size.z;
            }
            else
            {
                length = size.z;
                width = size.x;
            }
            height = size.y;

            float weight = porto.GetComponent<PostInfo>().weight;

            if ((size.x + size.y + size.z) > 90) // Lengde + Bredde + Høyde > 90cm
                isPorto = true;
            else if (length > 35.3f || width > 25f || height > 7f) // Pristabell 3
            {
                Debug.Log("Pristabell 3");
                if (weight <= 350f)
                {
                    if (paid >= portoPris3[0])
                        isPorto = false;
                    else
                        isPorto = true;
                }
                else if (weight > 350 && weight <= 1000)
                {
                    if (paid >= portoPris3[1])
                        isPorto = false;
                    else
                        isPorto = true;
                } else if (weight > 1000 && weight <= 2000)
                {
                    if (paid >= portoPris3[2])
                        isPorto = false;
                    else
                        isPorto = true;
                }
                else
                {
                    isPorto = true;
                }
            } else if (height > 2f && height <= 7f) // Pristabell 2
            {
                Debug.Log("Pristabell 2");

                if (weight <= 350f)
                {
                    if (paid >= portoPris2[0])
                        isPorto = false;
                    else
                        isPorto = true;
                }
                else if (weight > 350 && weight <= 1000)
                {
                    if (paid >= portoPris2[1])
                        isPorto = false;
                    else
                        isPorto = true;
                }
                else if (weight > 1000 && weight <= 2000)
                {
                    if (paid >= portoPris2[2])
                        isPorto = false;
                    else
                        isPorto = true;
                }
                else
                {
                    isPorto = true;
                }
            }
            else // Pristabell 1
            {
                Debug.Log("Pristabell 1");

                if (weight <= 20f)
                {
                    if (paid >= portoPris1[0])
                        isPorto = false;
                    else
                        isPorto = true;
                }
                else if (weight > 20f && weight <= 50)
                {
                    if (paid >= portoPris1[1])
                        isPorto = false;
                    else
                        isPorto = true;
                }
                else if (weight > 50f && weight <= 100)
                {
                    if (paid >= portoPris1[2])
                        isPorto = false;
                    else
                        isPorto = true;
                }
                else if (weight > 100f && weight <= 350)
                {
                    if (paid >= portoPris1[3])
                        isPorto = false;
                    else
                        isPorto = true;
                }
                else if (weight > 350 && weight <= 1000)
                {
                    if (paid >= portoPris1[4])
                        isPorto = false;
                    else
                        isPorto = true;
                }
                else if (weight > 1000 && weight <= 2000)
                {
                    if (paid >= portoPris1[5])
                        isPorto = false;
                    else
                        isPorto = true;
                }
                else
                {
                    isPorto = true;
                }
            }
        }
        if (isPorto)
        {
            // Spawn conffetti when porto found
            if (particleObj != null)
            {
                if (!particleObj.GetComponent<ParticleSystem>().isPlaying)
                    particleObj.GetComponent<ParticleSystem>().Play();
            }
        }
        return isPorto;
    }

    private void initPortoLister()
    {
        portoPris1 = new float[]
                       {
                        13f,
                        20f,
                        23f,
                        36f, 
                        70f,
                        110f
                       };

        portoPris2= new float[]
                       {
                        45f,
                        85f,
                        120
                       };

        portoPris3 = new float[]
                       {
                        75f,
                        115f,
                        155f
                       };
    }

    public float[] getAllPortoPrice()
    {
        float[] kombiPortoListe = new float[12];
        for (int i = 0; i < kombiPortoListe.Length; i++)
        {
            if(i < 6)
                kombiPortoListe[i] = portoPris1[i];
            else if(i < 9)
                kombiPortoListe[i] = portoPris2[i-6];
            else
                kombiPortoListe[i] = portoPris3[i-9];

        }
        return kombiPortoListe;
    }

    /*
     * 
     * eller mer enn 35,3 x 25 cm
     * Brev: Lengde inntil 60 cm.
       Lengde + bredde + tykkelse ikke over 90 cm.
< 2cm
20	 	13,-
50		20,- 	
100		23,- 	
350	    36,- 
1000	70,- 	
2000	110,- 	
 
2-7 cm.
350		45,-	
1000	85,-	
2000	120,-	
 
>7 cm.
350		75,-	
1000	115,-	
2000	155,-
     */
}
