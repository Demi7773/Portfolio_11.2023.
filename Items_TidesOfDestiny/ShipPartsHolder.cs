using System.Collections.Generic;
using UnityEngine;

public class ShipPartsHolder : MonoBehaviour
{
    [SerializeField] private List<MeshRenderer> shipBodyMeshList = new();
    [SerializeField] private List<MeshRenderer> shipSailsMeshList = new();
    [SerializeField] private List<MeshRenderer> shipFlagMeshList = new();


    // Lists of all Body, Sails and Flag models in pool
    [SerializeField] private List<GameObject> shipBodyList = new();
    [SerializeField] private List<GameObject> shipSailsList = new();
    [SerializeField] private List<GameObject> shipFlagList = new();



    // Public methods to activate equipped Mesh in place of previous. Index determines new Mesh
    // Add system which uses these methods in Equipment/UI screen
    public void SetShipBodyMesh(int bodyIndex)
    {
        for (int i = 0; i < shipBodyMeshList.Count; i++)
        {
            shipBodyMeshList[i].enabled = false;
        }
        shipBodyMeshList[bodyIndex].enabled = true;
    }
    public void SetShipSailsMesh(int sailsIndex)
    {
        for (int i = 0; i < shipSailsMeshList.Count; i++)
        {
            shipSailsMeshList[i].enabled = false;
        }
        shipSailsMeshList[sailsIndex].enabled = true;
    }
    public void SetShipFlagMesh(int flagIndex)
    {
        for (int i = 0; i < shipFlagMeshList.Count; i++)
        {
            shipFlagMeshList[i].enabled = false;
        }
        shipFlagMeshList[flagIndex].enabled = true;
    }



    // Public methods to activate equipped model in place of previous. Index determines new model
    // Add system which uses these methods in Equipment/UI screen
    public void SetShipBodyModel(int bodyIndex)
    {
        for (int i = 0; i < shipBodyList.Count; i++)
        {
            shipBodyList[i].SetActive(false);
        }
        shipBodyList[bodyIndex].SetActive(true);
    }
    public void SetShipSailsModel(int sailsIndex)
    {
        for (int i = 0; i < shipSailsList.Count; i++)
        {
            shipSailsList[i].SetActive(false);
        }
        shipSailsList[sailsIndex].SetActive(true);
    }
    public void SetShipFlagModel(int flagIndex)
    {
        for (int i = 0; i < shipFlagList.Count; i++)
        {
            shipFlagList[i].SetActive(false);
        }
        shipFlagList[flagIndex].SetActive(true);
    }
}
