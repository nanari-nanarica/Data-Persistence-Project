using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Functions
{
    // parent直下の子オブジェクトをforループで取得する
    public static Transform[] GetChildren(this Transform parent)
    {
        // 子オブジェクトを返却する配列作成
        var children = new Transform[parent.childCount];

        // 0～個数-1までの子を順番に配列に格納
        for (var i = 0; i < children.Length; ++i)
        {
            children[i] = parent.GetChild(i);
        }

        // 子オブジェクトが格納された配列
        return children;
    }
}
