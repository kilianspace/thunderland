using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class FilePath
{
    // Monster Seed Data
    // StreamingAssets フォルダの特性
    //
	// 1.	ビルドの影響:
	// •	StreamingAssetsフォルダは、Unityプロジェクトがビルドされる際に、そのままアプリケーションのパッケージに含まれます。そのため、動的に生成されたアセットをそこに保存すると、ビルド後にアクセスすることはできません。
	// 2.	プラットフォーム依存:
	// •	StreamingAssetsのパスは、プラットフォームによって異なる場合があります。例えば、Androidでは、StreamingAssetsはAPK内に含まれるため、直接的にファイルに書き込むことはできません。iOSでも同様です。
	// 3.	読み取り専用:
	// •	StreamingAssets内のファイルは基本的に読み取り専用です。アセットを動的に作成・編集する場合、適切な手段を取る必要があります。
     public static readonly string MONSTER_SEED_DATA = Path.Combine(Application.streamingAssetsPath, "100_SeedData/CSV/monster_100.csv");




     // Stored Directory For Monster Scriptable Objects
     //	•	保存先をAssetsフォルダ内にする:
	// •	もし動的に生成したアセットをエディタやランタイムでアクセスする必要があるなら、Assets/Monsters/のような場所に保存する方が良いでしょう。これは、エディタからのアクセスも簡単で、アセットが自動的に更新されます。
      public const string MONSTER_SCRIPTABLE_OBJECTS = "Assets/ScriptableObjects/Monsters/";

}
