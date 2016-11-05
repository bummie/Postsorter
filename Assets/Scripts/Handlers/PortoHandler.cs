using UnityEngine;
using System.Collections;

public class PortoHandler : MonoBehaviour {

    private float[] portoPris1, portoPris2, portoPris3;

	void Start ()
    {
        initPortoLister();
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
