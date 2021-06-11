// Decompiled with JetBrains decompiler
// Type: arc.Core
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.assets;
using arc.audio;
using arc.graphics;
using arc.graphics.g2d;
using arc.scene;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc
{
  public class Core : Object
  {
    public static Application app;
    public static Graphics graphics;
    public static Audio audio;
    public static Input input;
    public static Files files;
    public static Settings settings;
    public static KeyBinds keybinds;
    public static Net net;
    public static I18NBundle bundle;
    public static Camera camera;
    public static Batch batch;
    public static Scene scene;
    public static AssetManager assets;
    public static TextureAtlas atlas;
    public static GL20 gl;
    public static GL20 gl20;
    public static GL30 gl30;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Core()
    {
    }

    [LineNumberTable(new byte[] {159, 137, 173, 170})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Core()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.Core"))
        return;
      Core.keybinds = new KeyBinds();
      Core.bundle = I18NBundle.createEmptyBundle();
    }
  }
}
