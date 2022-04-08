using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
namespace Singleton
{
    public static class Singleton<T> where T : class
    {
        private static T _instance;
        static Singleton()
        {
            return;
        }

        private static void Create()
        {
            _instance = (T)Activator.CreateInstance(typeof(T), true);

            return;
        }

        /* Serve the single instance to callers	*/
        public static T Instance
        {
            get
            {
                if( _instance == null ) Create();
                return _instance;
            }
        }

        /*	Destroy	*/
        public static void Destroy()
        {

            _instance = null;

            return;
        }
    }
}
