using UnityEngine;
using System.Collections;

/*  Purpose of this script is to control 5 cubes based on sound
 *   written in C#
*/
public class SoundSpectrum : MonoBehaviour
{

    public GameObject cube01;
    public GameObject cube02;
    public GameObject cube03;
    public GameObject cube04;
    public GameObject cube05;

    public float juice = 20f;

    public float[] spec;

    public float specMag01;
    public float specMag02;
    public float specMag03;
    public float specMag04;
    public float specMag05;

    public float scalesmooth;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //spec = AudioListener.GetSpectrumData(64,0,FFTWindow.Hamming); // this works on audio source
        spec = AudioListener.GetOutputData(64, 0);  // this gives much  better values.

        specMag01 = spec[2] + spec[4];
        specMag02 = spec[12] + spec[14];
        specMag03 = spec[22] + spec[24];
        specMag04 = spec[32] + spec[34];
        specMag05 = spec[57] + spec[60];


        cube01.gameObject.transform.localScale = Vector3.Lerp(cube01.transform.localScale, new Vector3(1f, specMag01 * juice, 1f), (scalesmooth * Time.deltaTime));
        cube02.gameObject.transform.localScale = Vector3.Lerp(cube02.transform.localScale, new Vector3(1f, specMag02 * juice, 1f), (scalesmooth * Time.deltaTime));
        cube03.gameObject.transform.localScale = Vector3.Lerp(cube03.transform.localScale, new Vector3(1f, specMag03 * juice, 1f), (scalesmooth * Time.deltaTime));
        cube04.gameObject.transform.localScale = Vector3.Lerp(cube04.transform.localScale, new Vector3(1f, specMag04 * juice, 1f), (scalesmooth * Time.deltaTime));
        cube05.gameObject.transform.localScale = Vector3.Lerp(cube05.transform.localScale, new Vector3(1f, specMag05 * juice, 1f), (scalesmooth * Time.deltaTime));
        /*cube01.gameObject.transform.localScale = new Vector3(1f, specMag01 * juice, 1f);
        cube02.gameObject.transform.localScale = new Vector3(1f, specMag02 * juice, 1f);
        cube03.gameObject.transform.localScale = new Vector3(1f, specMag03 * juice, 1f);
        cube04.gameObject.transform.localScale = new Vector3(1f, specMag04 * juice, 1f);
        cube05.gameObject.transform.localScale = new Vector3(1f, specMag05 * juice, 1f);*/
    }
}
