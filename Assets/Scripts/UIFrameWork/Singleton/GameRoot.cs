using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UIFramework;
using System.IO;

namespace Singleton
{
	public class GameRoot : MonoBehaviour {
        void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
