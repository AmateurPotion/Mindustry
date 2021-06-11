// Decompiled with JetBrains decompiler
// Type: mindustry.io.legacy.LegacyIO
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using mindustry.ctype;
using mindustry.ui.dialogs;
using System;
using System.Runtime.CompilerServices;

namespace mindustry.io.legacy
{
  public class LegacyIO : Object
  {
    internal static StringMap __\u003C\u003EunitMap;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LegacyIO()
    {
    }

    [Signature("()Larc/struct/Seq<Lmindustry/ui/dialogs/JoinDialog$Server;>;")]
    [LineNumberTable(new byte[] {159, 172, 166, 112, 140, 103, 132, 135, 104, 103, 109, 109, 232, 60, 255, 0, 73, 2, 98, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Seq readServers()
    {
      Seq seq = new Seq();
      Exception exception;
      try
      {
        DataInputStream dataInputStream = new DataInputStream((InputStream) new ByteArrayInputStream(Core.settings.getBytes("server-list")));
        int num = dataInputStream.readInt();
        if (num > 0)
        {
          dataInputStream.readUTF();
          for (int index = 0; index < num; ++index)
            seq.add((object) new JoinDialog.Server()
            {
              ip = dataInputStream.readUTF(),
              port = dataInputStream.readInt()
            });
          goto label_9;
        }
        else
          goto label_9;
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
          throw;
        else
          exception = (Exception) m0;
      }
      Throwable.instancehelper_printStackTrace((Exception) exception);
label_9:
      return seq;
    }

    [LineNumberTable(new byte[] {6, 112, 140, 103, 103, 103, 167, 105, 110, 104, 104, 103, 105, 104, 112, 127, 6, 231, 60, 232, 59, 255, 1, 81, 2, 98, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void readResearch()
    {
      Exception exception;
      try
      {
        DataInputStream dataInputStream = new DataInputStream((InputStream) new ByteArrayInputStream(Core.settings.getBytes("unlocks")));
        int num1 = dataInputStream.readInt();
        if (num1 <= 0)
          return;
        dataInputStream.readUTF();
        dataInputStream.readUTF();
        for (int index1 = 0; index1 < num1; ++index1)
        {
          ContentType type = ContentType.__\u003C\u003Eall[dataInputStream.readInt()];
          int num2 = dataInputStream.readInt();
          if (num2 > 0)
          {
            dataInputStream.readUTF();
            for (int index2 = 0; index2 < num2; ++index2)
            {
              string name = dataInputStream.readUTF();
              MappableContent byName = Vars.content.getByName(type, name);
              UnlockableContent unlockableContent;
              if (byName is UnlockableContent && object.ReferenceEquals((object) (unlockableContent = (UnlockableContent) byName), (object) (UnlockableContent) byName))
                unlockableContent.quietUnlock();
            }
          }
        }
        return;
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
          throw;
        else
          exception = (Exception) m0;
      }
      Log.err((Exception) exception);
    }

    [LineNumberTable(14)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static LegacyIO()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.io.legacy.LegacyIO"))
        return;
      LegacyIO.__\u003C\u003EunitMap = StringMap.of(new object[24]
      {
        (object) "titan",
        (object) "mace",
        (object) "chaos-array",
        (object) "scepter",
        (object) "eradicator",
        (object) "reign",
        (object) "eruptor",
        (object) "atrax",
        (object) "wraith",
        (object) "flare",
        (object) "ghoul",
        (object) "horizon",
        (object) "revenant",
        (object) "zenith",
        (object) "lich",
        (object) "antumbra",
        (object) "reaper",
        (object) "eclipse",
        (object) "draug",
        (object) "mono",
        (object) "phantom",
        (object) "poly",
        (object) "spirit",
        (object) "poly"
      });
    }

    [Modifiers]
    public static StringMap unitMap
    {
      [HideFromJava] get => LegacyIO.__\u003C\u003EunitMap;
    }
  }
}
