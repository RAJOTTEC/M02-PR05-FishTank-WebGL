using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpatialPartitionPattern
{
    public class Enemy : Soldier
    {
        Vector3 currentTarget;
        Vector3 oldPos;
        float mapWidth;
        Grid grid;

        public Enemy(GameObject soldierObj, float mapWidth, Grid grid)
        {
            this.soldierTrans = soldierObj.transform;

            this.soldierMeshRenderer = soldierObj.GetComponent<MeshRenderer>();

            this.mapWidth = mapWidth;

            this.grid = grid;

            grid.Add(this);

            oldPos = soldierTrans.position;

            this.walkSpeed = 20f;
        }

        public override void Move()
        {
            if (Input.GetKey("w") && soldierTrans.position.x > 1f && soldierTrans.position.x < (mapWidth - 1f) && soldierTrans.position.z > 1f && soldierTrans.position.z < (mapWidth - 1f))
            {
                soldierTrans.Translate(Vector3.forward * Time.deltaTime * walkSpeed);
            }

            if(Input.GetKey("a") && soldierTrans.position.x > 1f && soldierTrans.position.x < (mapWidth - 1f) && soldierTrans.position.z > 1f && soldierTrans.position.z < (mapWidth - 1f))
            {
                soldierTrans.Rotate(0, -0.5f, 0, 0);
            }

            if (Input.GetKey("s") && soldierTrans.position.x > 1f && soldierTrans.position.x < (mapWidth - 1f) && soldierTrans.position.z > 1f && soldierTrans.position.z < (mapWidth - 1f))
            {
                soldierTrans.Translate(Vector3.back * Time.deltaTime * walkSpeed);
            }

            if (Input.GetKey("d") && soldierTrans.position.x > 1f && soldierTrans.position.x < (mapWidth - 1f) && soldierTrans.position.z > 1f && soldierTrans.position.z < (mapWidth - 1f))
            {
                soldierTrans.Rotate(0, 0.5f, 0, 0);
            }
            
            if(Input.GetKey("e") && soldierTrans.position.x > 1f && soldierTrans.position.x < (mapWidth - 1f) && soldierTrans.position.z > 1f && soldierTrans.position.z < (mapWidth - 1f))
            {
                soldierTrans.Rotate(0.5f, 0, 0, 0);
            }

            if (Input.GetKey("q") && soldierTrans.position.x > 1f && soldierTrans.position.x < (mapWidth - 1f) && soldierTrans.position.z > 1f && soldierTrans.position.z < (mapWidth - 1f))
            {
                soldierTrans.Rotate(-0.5f, 0, 0, 0);
            }

            if (soldierTrans.position.x <= 1f || soldierTrans.position.x >= (mapWidth - 1f) || soldierTrans.position.z <= 1f || soldierTrans.position.z >= (mapWidth - 1f) || soldierTrans.position.y <= 1f || soldierTrans.position.y >= mapWidth - 1f)
            {
                soldierTrans.position = new Vector3(25, 25, 25);
            }


            grid.Move(this, oldPos);

            oldPos = soldierTrans.position;
        }
    }
}