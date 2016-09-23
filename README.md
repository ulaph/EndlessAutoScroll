# EndlessAutoScroll
## 概要
### 自動でエンドレスで動くuGUIのスクロールビュー

## 使い方
- `Assets` -> `Scene` -> `EndlessAutoScroll`がサンプルシーンなので開きます
- 使い方は主に２つあります
  - １つは`Canvas` -> `Viewport` -> `ScrollView` -> `Content`に`Prefabs`から`Node`を好きな数配置するやり方
  - もう１つは`Content`が空の状態で、`Resources/Prefabs`から`Node`をインスタンス生成するやり方です  
  生成数は`Inspector`の`Number Of Node`から変えることができます
- `ScrollSpeed`でスクロールの速さ、`IsReverse`でスクロールの回転を逆にできます

## 注意
- 実行中に`ScrollView`の大きさをいじると挙動がおかしくなります
- `ScrollView`の大きさと`Node`の数を調整する必要があります
- `Node`は最小5からです

## 参考
- [UnityのuGUIでスクロールビューを作る - テラシュールブログ](http://tsubakit1.hateblo.jp/entry/2014/12/18/040252)
- [UnityのuGUIで無限にスクロール出来るスクロールビューを作る - テラシュールブログ](http://tsubakit1.hateblo.jp/entry/2015/01/21/233000)
