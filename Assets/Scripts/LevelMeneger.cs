using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMeneger : MonoBehaviour
{
    [SerializeField] private GameObject[] Tiles;
    [SerializeField] private Material[] Materials;
    [SerializeField] private UiOverseer UiControll;

    private TileControl FirstSelectedTile;
    private int Counter; 

    void Start()
    {
        Vector3 buffer;
        for (int Iterator = 0; Iterator < Tiles.Length; Iterator++)
        {
            Tiles[Iterator].transform.Find("Pic").Find("default").GetComponent<MeshRenderer>().material = Materials[Iterator / 2];
            Tiles[Iterator].transform.GetComponent<TileControl>().MyTipe = Iterator / 2;
            Tiles[Iterator].transform.GetComponent<TileControl>().MyNumber = Iterator;
        }
        for (int Iterator = 0; Iterator < Tiles.Length; Iterator++)
        {
            buffer = Tiles[Iterator].transform.position;
            int i = Random.Range(0, Tiles.Length);
            Tiles[Iterator].transform.position = Tiles[i].transform.position;
            Tiles[i].transform.position = buffer;
        }

        Counter = Tiles.Length - 1;
    }

    private void FixedUpdate()
    {
        if (Counter <= 0)
            UiControll.victory = true;
    }

    public void SelectTile(TileControl CurrentObject)
    {
        CurrentObject.CanBeRotate = false;
        if (FirstSelectedTile == null)
        {
            FirstSelectedTile = CurrentObject;
        }
        else
        {
            if (CheckSelectedTils(FirstSelectedTile, CurrentObject))
            {
                StartCoroutine(Correct(CurrentObject));
            }
            else
            {
                StartCoroutine(UnCorrect(CurrentObject));
            }
        }
    }

    bool CheckSelectedTils(TileControl a, TileControl b)
    {
        if ((a.MyTipe == b.MyTipe) && (a.MyNumber != b.MyNumber))
            return true;
        return false;
    }

    IEnumerator Correct(TileControl CurrentObject)
    {
        NotCanRotate();
        yield return new WaitForSeconds(0.9f);

        Destroy(Tiles[FirstSelectedTile.MyNumber]);
        Destroy(Tiles[CurrentObject.MyNumber]);
        Counter = Counter - 2;
        CanRotate();
    }
    IEnumerator UnCorrect(TileControl CurrentObject)
    {
        NotCanRotate();
        yield return new WaitForSeconds(0.9f);

        CurrentObject.CanBeRotate = true;
        FirstSelectedTile.CanBeRotate = true;

        FirstSelectedTile.RotateTile();
        CurrentObject.RotateTile();
        FirstSelectedTile = null;
        CanRotate();
    }

    void CanRotate()
    {
        for (int Iterator = 0; Iterator < Tiles.Length; Iterator++)
            if(Tiles[Iterator] != null)
                Tiles[Iterator].GetComponent<TileControl>().CanBeRotate = true;
    }

    void NotCanRotate()
    {
        for (int Iterator = 0; Iterator < Tiles.Length; Iterator++)
            if (Tiles[Iterator] != null)
                Tiles[Iterator].GetComponent<TileControl>().CanBeRotate = false;
    }
}