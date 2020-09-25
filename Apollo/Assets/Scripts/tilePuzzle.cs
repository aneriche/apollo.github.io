using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilePuzzle : MonoBehaviour
{
     Ray ray;
     RaycastHit hit;
    // Start is called before the first frame update

    public GameObject[] tiles;
    Color[] colors = new Color[]{Color.green, Color.red};
    int totalRedTiles = 0;
    int totalGreenTiles = 0;
    void Start()
    {
        assignRandomColors();
    }

    void assignRandomColors(){
        totalRedTiles = 0;
        totalGreenTiles = 0;
        tiles = GameObject.FindGameObjectsWithTag("Tile");
        foreach(GameObject tile in tiles) {
            
            Renderer t = tile.GetComponent<Renderer>();
            int randomTileColor = Random.Range(0,2);
            if(randomTileColor == 0) totalGreenTiles++;
            else totalRedTiles++;
            t.material.color = colors[randomTileColor];
        }
        if(totalRedTiles == 0 || totalGreenTiles == 0) {
            assignRandomColors();
        }
    }

    bool isRed(){
        int redTiles = 0;
        foreach(GameObject tile in tiles) {
            Renderer t = tile.GetComponent<Renderer>();
            if(t.material.color == Color.red) {
                redTiles++;
            }
        }
        return redTiles==9?true:false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isRed()){
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                Renderer cube = hit.collider.GetComponent<Renderer>();
                //Left Click, change to red.
                if(Input.GetMouseButtonDown(0))
                {
                    if(cube.material.color == Color.red) {
                        cube.material.color = Color.green;
                    }
                    else {
                        cube.material.color = Color.red;
                    }
                }
            }
        }
        else {
            //Winning condition
        }
    }
}
