using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    public ShopManager shopManager;

    public GameObject basicTowerObject;

    public GameObject smgRatObject;

    public GameObject placingPath;

    private GameObject currentTowerPlacing;

    private GameObject dummyPlacement;

    private GameObject hoverTile;

    public Camera cam;

    public LayerMask mask;
    public LayerMask towerMask;

    public bool isBuilding;


    public void Start()
    {
        
    }


    public Vector2 GetMousePosition()
    {
        return cam.ScreenToWorldPoint(Input.mousePosition);
    }

    public void GetCurrentHoverTile()
    {
        Vector2 mousePosition = GetMousePosition();

        RaycastHit2D hit = Physics2D.Raycast(mousePosition,new Vector2(0,0),0.1f, mask, -100, 100);

        if (hit.collider != null)
        {
            if (MapGenerator.mapTiles.Contains(hit.collider.gameObject))
            {
                if (!MapGenerator.pathTiles.Contains(hit.collider.gameObject))
                {
                    hoverTile = hit.collider.gameObject;
                }
            }
        }
    }

    public bool CheckForTower()
    {
        bool towerOnSlot = false;

        Vector2 mousePosition = GetMousePosition();

        RaycastHit2D hit = Physics2D.Raycast(mousePosition,new Vector2(0,0),0.1f, towerMask, -100, 100);

        if (hit.collider != null)
        {
            towerOnSlot = true;
        }

        return towerOnSlot;
    }


    public void PlaceBuilding()
    {
        if (hoverTile != null)
        {
            if (CheckForTower() == false)
            {
                if (shopManager.CanBuyTower(currentTowerPlacing) == true)
                {
                GameObject newTowerObject = Instantiate(currentTowerPlacing);
                newTowerObject.layer = LayerMask.NameToLayer("Tower");
                newTowerObject.transform.position = hoverTile.transform.position;

                EndBuilding();
                shopManager.BuyTower(currentTowerPlacing);
                }
                else
                {
                    Debug.Log("No moneys! not enough money. you poor D:");
                }

            }
        }
    }

    public void StartBuilding(GameObject towerToBuild)
    {
        isBuilding = true;

        currentTowerPlacing = towerToBuild;
        dummyPlacement = Instantiate(placingPath);

        if (dummyPlacement.GetComponent<Tower>() != null)
        {
            Destroy(dummyPlacement.GetComponent<Tower>());
        }

        if (dummyPlacement.GetComponent<BarrelRotation>() != null)
        {
            Destroy(dummyPlacement.GetComponent<BarrelRotation>());
        }
    }

    public void EndBuilding()
    {
        isBuilding = false;

        if (dummyPlacement != null)
        {
            Destroy(dummyPlacement);
        }
    }


    public void Update()
    {
        if (isBuilding == true)
        {
            if (dummyPlacement != null)
            {
                GetCurrentHoverTile();

                if (hoverTile != null)
                {
                    dummyPlacement.transform.position = hoverTile.transform.position;
                }
            }

            if (Input.GetButtonDown("Fire1"))
            {
                PlaceBuilding();
            }
        }
        
        
        //Debug.Log(GetMousePosition());
    }
}
