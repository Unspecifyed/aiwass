using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Speed of 100 pixles per second. bpm/6000 pixles.
public class STempo : MonoBehaviour
{
    List<GameObject> colList;
    // Start is called before the first frame update
    void Start()
    {
        float bpm = 70;

        GameObject ui = GameObject.Find("MusicUI");
        colList = new List<GameObject>();
        TempoPlacer(0, ui, colList, SpaceFinder(bpm));


    }
    float SpaceFinder(float bpm)
    {
        return 6000f / bpm;
    }

    // Update is called once per frame
    void Update()
    {
        TempoShifter(0);

    }
    void TempoShifter(int x)
    {
        if (x < colList.Count)
        {
            Vector3 xTras = colList[x].transform.position;


            xTras.x += 100 * Time.deltaTime;
            if(xTras.x>500){
                float diff=xTras.x -500;
                xTras.x=diff;
            }
            

            colList[x].transform.position = xTras;

            x++;
            TempoShifter(x);
        }

    }
    void TempoPlacer(float x, GameObject ui, List<GameObject> colList, float pSpace)
    {
        GameObject col = (GameObject)Resources.Load("TempoCol");
        Vector3 pos = new Vector3(x, 50, 0);
        GameObject current = Instantiate(col, pos, Quaternion.identity);
        current.transform.SetParent(ui.transform);
        colList.Add(current);

        x += pSpace;

        if (500> x)
        {
            TempoPlacer(x, ui, colList, pSpace);
        }

    }
}
