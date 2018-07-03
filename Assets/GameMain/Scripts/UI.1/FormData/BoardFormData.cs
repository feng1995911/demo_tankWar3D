using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GameMain
{
    public class BoardFormData
    {
        public int OwnerId
        {
            get;
            set;
        }

        public ActorType ActorType
        {
            get;
            set;
        }

        public Transform CacheTransform
        {
            get;
            set;
        }

        public float Height
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int Level
        {
            get;
            set;
        }

    }
}
