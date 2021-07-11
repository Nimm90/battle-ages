using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factory
{
    public class Spawner : IFactory
    {
        public virtual GameObject Create(GameObject prefab)
        {
            return GameObject.Instantiate(prefab);
        }

        public virtual GameObject Create(GameObject prefab, Vector3 position)
        {
            return GameObject.Instantiate(prefab, position, Quaternion.identity);
        }
    }
}