﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace UIFramework
{
	public class UIType {

        public string Path { get; private set; }

        public string Name { get; private set; }

        public UIType(string path)
        {
            Path = path;
            Name = path.Substring(path.LastIndexOf('/') + 1);
        }

        public override string ToString()
        {
            return string.Format("path : {0} name : {1}", Path, Name);
        }

        public static readonly UIType StartCanvas = new UIType("View/Canvas/StartCanvas");
        public static readonly UIType MusicSettingPanel = new UIType("View/Panel/MusicSettingPanel");
        public static readonly UIType GameCanvas = new UIType("View/Canvas/GameCanvas");
        public static readonly UIType ShopCanvas = new UIType("View/Canvas/ShopCanvas");
        public static readonly UIType GoodsPanel = new UIType("View/Panel/GoodsPanel");
        public static readonly UIType LosePanel = new UIType("View/Panel/LosePanel");
        public static readonly UIType WinPanel = new UIType("View/Panel/WinPanel");

    }
}
