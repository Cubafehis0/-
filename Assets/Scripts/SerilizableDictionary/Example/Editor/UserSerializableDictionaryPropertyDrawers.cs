using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(TreasureidIntSerializableDictionary))]
[CustomPropertyDrawer(typeof(StringAudioClipDictionary))]
public class AnySerializableDictionaryPropertyDrawer : SerializableDictionaryPropertyDrawer {}

//[CustomPropertyDrawer(typeof(TreasureID))]
//public class AnySerializableDictionaryStoragePropertyDrawer: SerializableDictionaryStoragePropertyDrawer {}
