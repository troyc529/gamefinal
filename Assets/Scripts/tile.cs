using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using CodeMonkey.Utils;
using Photon.Pun;

public class tile : MonoBehaviour
{
    private Vector3 tilePosition;

    public int x, y;
    private float tileSize;

    public bool isWalkable;

    public int gCost;

    public int hCost;

    public int fCost;

    public tile cameFromeTile;



    private PhotonView photonView;



    private Grid parentGrid;

    private List<tile> path;

    void Awake(){
 
        photonView = this.GetComponent<PhotonView>();
        parentGrid = this.transform.parent.GetComponent<Grid>();
        isWalkable = true;
        
    }

    void OnTriggerStay2D(Collider2D col)
    {

        photonView.RPC(nameof(onTriggerRPC),RpcTarget.AllBuffered);
    

    }

     [PunRPC]
    private void onTriggerRPC(){
        isWalkable = false;
    }


    void OnTriggerExit2D(Collider2D col){
        photonView.RPC(nameof(onTriggerExitRPC),RpcTarget.AllBuffered);
        
    }

     [PunRPC]
    private void onTriggerExitRPC(){

        isWalkable = true;
    }
    public void SetColor(Color color)
    {
        var spriteRenderer = this.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = color;
        }
    }

    public void setXY(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public int getX()
    {
        return this.x;
    }
    public int getY()
    {
        return this.y;
    }

    public void setTilePosition(Vector3 tilePosition)
    {
        this.tilePosition = tilePosition;
    }

    public void setTileSize(float tileSize)
    {
        this.tileSize = tileSize;
    }

    public Vector3 getTilePosition()
    {
        return tilePosition;
    }

    public float getTileSize()
    {
        return tileSize;
    }

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }

    void OnMouseOver()
    {

       
        // path = parentGrid.gridPath(this.GetComponent<tile>());

    }


    void OnMouseExit()
    {

    //   if (path != null)
    //     {
    //         for (int i = 0; i < path.Count - 1; i++)
    //         {
    //             path[i].gameObject.GetComponent<SpriteRenderer>().enabled = false;

    //         }
    //         this.GetComponent<SpriteRenderer>().enabled = false;

    //     }
 
    }

    public List<tile> getTilePath(){
        return path;
    }

    public void PlayerMoveRPC(){
         photonView.RPC(nameof(PlayerMove), RpcTarget.All);
    }
    
    
    [PunRPC]
    private void PlayerMove(){


    }



}
