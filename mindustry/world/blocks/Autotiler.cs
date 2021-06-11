// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.Autotiler
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.entities.units;
using mindustry.gen;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks
{
  public interface Autotiler
  {
    [Modifiers]
    TextureRegion botHalf(TextureRegion input);

    [LineNumberTable(new byte[] {13, 102, 103, 103, 105, 110})]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static TextureRegion \u003Cdefault\u003EbotHalf([In] Autotiler obj0, [In] TextureRegion obj1)
    {
      TextureRegion tr1 = Tmp.__\u003C\u003Etr1;
      tr1.set(obj1);
      int width = tr1.width;
      tr1.setWidth(width / 2);
      tr1.setX(tr1.getX() + width);
      return tr1;
    }

    [Modifiers]
    TextureRegion topHalf(TextureRegion input);

    [LineNumberTable(new byte[] {0, 102, 103, 110})]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static TextureRegion \u003Cdefault\u003EtopHalf([In] Autotiler obj0, [In] TextureRegion obj1)
    {
      TextureRegion tr1 = Tmp.__\u003C\u003Etr1;
      tr1.set(obj1);
      tr1.setWidth(tr1.width / 2);
      return tr1;
    }

    [Modifiers]
    int[] buildBlending(Tile tile, int rotation, BuildPlan[] directional, bool world);

    [LineNumberTable(new byte[] {159, 116, 131, 102, 100, 176, 127, 14, 127, 1, 125, 125, 112, 112, 99, 201, 132, 104, 110, 21, 232, 72, 132, 107, 108, 127, 16, 245, 61, 235, 71})]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static int[] \u003Cdefault\u003EbuildBlending(
      [In] Autotiler obj0,
      [In] Tile obj1,
      [In] int obj2,
      [In] BuildPlan[] obj3,
      [In] bool obj4)
    {
      int num1 = obj4 ? 1 : 0;
      int[] blendresult = Autotiler.AutotilerHolder.blendresult;
      blendresult[0] = 0;
      int[] numArray1 = blendresult;
      int[] numArray2 = blendresult;
      int num2 = 1;
      int index1 = 2;
      int[] numArray3 = numArray2;
      int num3 = num2;
      numArray3[index1] = num2;
      numArray1[1] = num3;
      int num4 = !obj0.blends(obj1, obj2, obj3, 2, num1 != 0) || !obj0.blends(obj1, obj2, obj3, 1, num1 != 0) || !obj0.blends(obj1, obj2, obj3, 3, num1 != 0) ? (!obj0.blends(obj1, obj2, obj3, 1, num1 != 0) || !obj0.blends(obj1, obj2, obj3, 3, num1 != 0) ? (!obj0.blends(obj1, obj2, obj3, 1, num1 != 0) || !obj0.blends(obj1, obj2, obj3, 2, num1 != 0) ? (!obj0.blends(obj1, obj2, obj3, 3, num1 != 0) || !obj0.blends(obj1, obj2, obj3, 2, num1 != 0) ? (!obj0.blends(obj1, obj2, obj3, 1, num1 != 0) ? (!obj0.blends(obj1, obj2, obj3, 3, num1 != 0) ? -1 : 5) : 4) : 3) : 2) : 1) : 0;
      obj0.transformCase(num4, blendresult);
      blendresult[3] = 0;
      for (int direction = 0; direction < 4; ++direction)
      {
        if (obj0.blends(obj1, obj2, obj3, direction, num1 != 0))
        {
          int[] numArray4 = blendresult;
          int index2 = 3;
          int[] numArray5 = numArray4;
          numArray5[index2] = numArray5[index2] | 1 << direction;
        }
      }
      blendresult[4] = 0;
      for (int direction = 0; direction < 4; ++direction)
      {
        int rotation = Mathf.mod(obj2 - direction, 4);
        if (obj0.blends(obj1, obj2, obj3, direction, num1 != 0) && obj1 != null && (obj1.nearbyBuild(rotation) != null && !obj1.nearbyBuild(rotation).block.squareSprite))
        {
          int[] numArray4 = blendresult;
          int index2 = 4;
          int[] numArray5 = numArray4;
          numArray5[index2] = numArray5[index2] | 1 << direction;
        }
      }
      return blendresult;
    }

    [Modifiers]
    bool blends(Tile tile, int rotation, [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})] BuildPlan[] directional, int direction, bool checkWorld);

    [LineNumberTable(new byte[] {159, 96, 67, 107, 104, 100, 127, 3, 162})]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003Eblends(
      [In] Autotiler obj0,
      [In] Tile obj1,
      [In] int obj2,
      [In] BuildPlan[] obj3,
      [In] int obj4,
      [In] bool obj5)
    {
      int num = obj5 ? 1 : 0;
      int index = Mathf.mod(obj2 - obj4, 4);
      if (obj3 != null && obj3[index] != null)
      {
        BuildPlan buildPlan = obj3[index];
        if (obj0.blends(obj1, obj2, buildPlan.x, buildPlan.y, buildPlan.rotation, buildPlan.block))
          return true;
      }
      return num != 0 && obj0.blends(obj1, obj2, obj4);
    }

    [Modifiers]
    void transformCase(int num, int[] bits);

    [LineNumberTable(new byte[] {101, 127, 1, 102, 102, 134, 100, 4, 226, 69, 100, 4, 194, 132})]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003EtransformCase([In] Autotiler obj0, [In] int obj1, [In] int[] obj2)
    {
      switch (obj1)
      {
        case 0:
          obj2[0] = 3;
          break;
        case 1:
          obj2[0] = 4;
          break;
        case 2:
          obj2[0] = 2;
          break;
        case 3:
          obj2[0] = 2;
          obj2[2] = -1;
          break;
        case 4:
          obj2[0] = 1;
          obj2[2] = -1;
          break;
        case 5:
          obj2[0] = 1;
          break;
      }
    }

    bool blends(Tile t, int i1, int i2, int i3, int i4, Block b);

    [Modifiers]
    bool blends(Tile tile, int rotation, int direction);

    [LineNumberTable(new byte[] {160, 83, 112})]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003Eblends([In] Autotiler obj0, [In] Tile obj1, [In] int obj2, [In] int obj3)
    {
      Building building = obj1.nearbyBuild(Mathf.mod(obj2 - obj3, 4));
      return building != null && object.ReferenceEquals((object) building.team, (object) obj1.team()) && obj0.blends(obj1, obj2, building.tileX(), building.tileY(), building.rotation, building.block);
    }

    [Modifiers]
    TextureRegion sliced(TextureRegion input, Autotiler.SliceMode mode);

    [LineNumberTable(40)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static TextureRegion \u003Cdefault\u003Esliced(
      [In] Autotiler obj0,
      [In] TextureRegion obj1,
      [In] Autotiler.SliceMode obj2)
    {
      if (object.ReferenceEquals((object) obj2, (object) Autotiler.SliceMode.__\u003C\u003Enone))
        return obj1;
      return object.ReferenceEquals((object) obj2, (object) Autotiler.SliceMode.__\u003C\u003Ebottom) ? obj0.botHalf(obj1) : obj0.topHalf(obj1);
    }

    [Modifiers]
    [Signature("(Lmindustry/entities/units/BuildPlan;Larc/util/Eachable<Lmindustry/entities/units/BuildPlan;>;)[I")]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    int[] getTiling(BuildPlan req, Eachable list);

    [LineNumberTable(new byte[] {22, 106, 134, 103, 242, 77})]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static int[] \u003Cdefault\u003EgetTiling([In] Autotiler obj0, [In] BuildPlan obj1, [In] Eachable obj2)
    {
      if (obj1.tile() == null)
        return (int[]) null;
      BuildPlan[] directionals = Autotiler.AutotilerHolder.directionals;
      Arrays.fill((object[]) directionals, (object) null);
      obj2.each((Cons) new Autotiler.__\u003C\u003EAnon1(obj1, directionals));
      return obj0.buildBlending(obj1.tile(), obj1.rotation, directionals, obj1.worldContext);
    }

    [Modifiers]
    bool facing(int x, int y, int rotation, int x2, int y2);

    [LineNumberTable(180)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003Efacing(
      [In] Autotiler obj0,
      [In] int obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] int obj5)
    {
      return Point2.equals(obj1 + Geometry.d4(obj3).x, obj2 + Geometry.d4(obj3).y, obj4, obj5);
    }

    [Modifiers]
    bool blendsArmored(
      Tile tile,
      int rotation,
      int otherx,
      int othery,
      int otherrot,
      Block otherblock);

    [LineNumberTable(new byte[] {160, 88, 127, 20, 122, 31, 48})]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003EblendsArmored(
      [In] Autotiler obj0,
      [In] Tile obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] int obj5,
      [In] Block obj6)
    {
      return Point2.equals((int) obj1.x + Geometry.d4(obj2).x, (int) obj1.y + Geometry.d4(obj2).y, obj3, obj4) || !obj6.rotatedOutput(obj3, obj4) && Edges.getFacingEdge(obj6, obj3, obj4, obj1) != null && (int) (sbyte) Edges.getFacingEdge(obj6, obj3, obj4, obj1).relativeTo(obj1) == obj2 || obj6.rotatedOutput(obj3, obj4) && Point2.equals(obj3 + Geometry.d4(obj5).x, obj4 + Geometry.d4(obj5).y, (int) obj1.x, (int) obj1.y);
    }

    [Modifiers]
    bool notLookingAt(
      Tile tile,
      int rotation,
      int otherx,
      int othery,
      int otherrot,
      Block otherblock);

    [LineNumberTable(209)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003EnotLookingAt(
      [In] Autotiler obj0,
      [In] Tile obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] int obj5,
      [In] Block obj6)
    {
      return !obj6.rotatedOutput(obj3, obj4) || !Point2.equals(obj3 + Geometry.d4(obj5).x, obj4 + Geometry.d4(obj5).y, (int) obj1.x, (int) obj1.y);
    }

    [Modifiers]
    bool lookingAtEither(
      Tile tile,
      int rotation,
      int otherx,
      int othery,
      int otherrot,
      Block otherblock);

    [LineNumberTable(new byte[] {160, 101, 127, 20, 63, 28})]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003ElookingAtEither(
      [In] Autotiler obj0,
      [In] Tile obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] int obj5,
      [In] Block obj6)
    {
      return Point2.equals((int) obj1.x + Geometry.d4(obj2).x, (int) obj1.y + Geometry.d4(obj2).y, obj3, obj4) || !obj6.rotatedOutput(obj3, obj4) || Point2.equals(obj3 + Geometry.d4(obj5).x, obj4 + Geometry.d4(obj5).y, (int) obj1.x, (int) obj1.y);
    }

    [Modifiers]
    bool lookingAt(Tile tile, int rotation, int otherx, int othery, Block otherblock);

    [LineNumberTable(new byte[] {160, 115, 108, 106, 63, 21})]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003ElookingAt(
      [In] Autotiler obj0,
      [In] Tile obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] Block obj5)
    {
      Tile facingEdge = Edges.getFacingEdge(obj5, obj3, obj4, obj1);
      return facingEdge != null && Point2.equals((int) obj1.x + Geometry.d4(obj2).x, (int) obj1.y + Geometry.d4(obj2).y, (int) facingEdge.x, (int) facingEdge.y);
    }

    class AutotilerHolder : Object
    {
      [Modifiers]
      internal static int[] blendresult;
      [Modifiers]
      internal static BuildPlan[] directionals;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(18)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public AutotilerHolder()
      {
      }

      [LineNumberTable(new byte[] {159, 138, 173, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static AutotilerHolder()
      {
        if (ByteCodeHelper.isAlreadyInited("mindustry.world.blocks.Autotiler$AutotilerHolder"))
          return;
        Autotiler.AutotilerHolder.blendresult = new int[5];
        Autotiler.AutotilerHolder.directionals = new BuildPlan[4];
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lmindustry/world/blocks/Autotiler$SliceMode;>;")]
    [Modifiers]
    [Serializable]
    sealed class SliceMode : Enum
    {
      [Modifiers]
      internal static Autotiler.SliceMode __\u003C\u003Enone;
      [Modifiers]
      internal static Autotiler.SliceMode __\u003C\u003Ebottom;
      [Modifiers]
      internal static Autotiler.SliceMode __\u003C\u003Etop;
      [Modifiers]
      private static Autotiler.SliceMode[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(26)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private SliceMode([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(26)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Autotiler.SliceMode[] values() => (Autotiler.SliceMode[]) Autotiler.SliceMode.\u0024VALUES.Clone();

      [LineNumberTable(26)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Autotiler.SliceMode valueOf(string name) => (Autotiler.SliceMode) Enum.valueOf((Class) ClassLiteral<Autotiler.SliceMode>.Value, name);

      [LineNumberTable(new byte[] {159, 136, 173, 112, 112, 240, 61})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static SliceMode()
      {
        if (ByteCodeHelper.isAlreadyInited("mindustry.world.blocks.Autotiler$SliceMode"))
          return;
        Autotiler.SliceMode.__\u003C\u003Enone = new Autotiler.SliceMode(nameof (none), 0);
        Autotiler.SliceMode.__\u003C\u003Ebottom = new Autotiler.SliceMode(nameof (bottom), 1);
        Autotiler.SliceMode.__\u003C\u003Etop = new Autotiler.SliceMode(nameof (top), 2);
        Autotiler.SliceMode.\u0024VALUES = new Autotiler.SliceMode[3]
        {
          Autotiler.SliceMode.__\u003C\u003Enone,
          Autotiler.SliceMode.__\u003C\u003Ebottom,
          Autotiler.SliceMode.__\u003C\u003Etop
        };
      }

      [Modifiers]
      public static Autotiler.SliceMode none
      {
        [HideFromJava] get => Autotiler.SliceMode.__\u003C\u003Enone;
      }

      [Modifiers]
      public static Autotiler.SliceMode bottom
      {
        [HideFromJava] get => Autotiler.SliceMode.__\u003C\u003Ebottom;
      }

      [Modifiers]
      public static Autotiler.SliceMode top
      {
        [HideFromJava] get => Autotiler.SliceMode.__\u003C\u003Etop;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        none,
        bottom,
        top,
      }
    }

    private static class __\u003C\u003EPIM
    {
      [Modifiers]
      [LineNumberTable(new byte[] {27, 146, 98, 119, 127, 1, 127, 69, 132, 228, 59, 233, 71})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static void lambda\u0024getTiling\u00240(
        [In] BuildPlan obj0,
        [In] BuildPlan[] obj1,
        [In] BuildPlan obj2)
      {
        if (obj2.breaking || object.ReferenceEquals((object) obj2, (object) obj0))
          return;
        int index1 = 0;
        Point2[] d4 = Geometry.__\u003C\u003Ed4;
        int length = d4.Length;
        for (int index2 = 0; index2 < length; ++index2)
        {
          Point2 point2 = d4[index2];
          int num1 = obj0.x + point2.x;
          int num2 = obj0.y + point2.y;
          if (num1 >= obj2.x - (obj2.block.size - 1) / 2 && num1 <= obj2.x + obj2.block.size / 2 && (num2 >= obj2.y - (obj2.block.size - 1) / 2 && num2 <= obj2.y + obj2.block.size / 2))
            obj1[index1] = obj2;
          ++index1;
        }
      }
    }

    [HideFromJava]
    static class __DefaultMethods
    {
      public static TextureRegion sliced(
        [In] Autotiler obj0,
        [In] TextureRegion obj1,
        [In] Autotiler.SliceMode obj2)
      {
        Autotiler autotiler = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(autotiler, ToString);
        return Autotiler.\u003Cdefault\u003Esliced(autotiler, obj1, obj2);
      }

      public static TextureRegion topHalf([In] Autotiler obj0, [In] TextureRegion obj1)
      {
        Autotiler autotiler = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(autotiler, ToString);
        return Autotiler.\u003Cdefault\u003EtopHalf(autotiler, obj1);
      }

      public static TextureRegion botHalf([In] Autotiler obj0, [In] TextureRegion obj1)
      {
        Autotiler autotiler = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(autotiler, ToString);
        return Autotiler.\u003Cdefault\u003EbotHalf(autotiler, obj1);
      }

      public static int[] getTiling([In] Autotiler obj0, [In] BuildPlan obj1, [In] Eachable obj2)
      {
        Autotiler autotiler = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(autotiler, ToString);
        return Autotiler.\u003Cdefault\u003EgetTiling(autotiler, obj1, obj2);
      }

      public static int[] buildBlending(
        [In] Autotiler obj0,
        [In] Tile obj1,
        [In] int obj2,
        [In] BuildPlan[] obj3,
        [In] bool obj4)
      {
        Autotiler autotiler = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(autotiler, ToString);
        return Autotiler.\u003Cdefault\u003EbuildBlending(autotiler, obj1, obj2, obj3, obj4);
      }

      public static void transformCase([In] Autotiler obj0, [In] int obj1, [In] int[] obj2)
      {
        Autotiler autotiler = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(autotiler, ToString);
        Autotiler.\u003Cdefault\u003EtransformCase(autotiler, obj1, obj2);
      }

      public static bool facing(
        [In] Autotiler obj0,
        [In] int obj1,
        [In] int obj2,
        [In] int obj3,
        [In] int obj4,
        [In] int obj5)
      {
        Autotiler autotiler = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(autotiler, ToString);
        return Autotiler.\u003Cdefault\u003Efacing(autotiler, obj1, obj2, obj3, obj4, obj5);
      }

      public static bool blends(
        [In] Autotiler obj0,
        [In] Tile obj1,
        [In] int obj2,
        [In] BuildPlan[] obj3,
        [In] int obj4,
        [In] bool obj5)
      {
        Autotiler autotiler = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(autotiler, ToString);
        return Autotiler.\u003Cdefault\u003Eblends(autotiler, obj1, obj2, obj3, obj4, obj5);
      }

      public static bool blends([In] Autotiler obj0, [In] Tile obj1, [In] int obj2, [In] int obj3)
      {
        Autotiler autotiler = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(autotiler, ToString);
        return Autotiler.\u003Cdefault\u003Eblends(autotiler, obj1, obj2, obj3);
      }

      public static bool blendsArmored(
        [In] Autotiler obj0,
        [In] Tile obj1,
        [In] int obj2,
        [In] int obj3,
        [In] int obj4,
        [In] int obj5,
        [In] Block obj6)
      {
        Autotiler autotiler = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(autotiler, ToString);
        return Autotiler.\u003Cdefault\u003EblendsArmored(autotiler, obj1, obj2, obj3, obj4, obj5, obj6);
      }

      public static bool notLookingAt(
        [In] Autotiler obj0,
        [In] Tile obj1,
        [In] int obj2,
        [In] int obj3,
        [In] int obj4,
        [In] int obj5,
        [In] Block obj6)
      {
        Autotiler autotiler = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(autotiler, ToString);
        return Autotiler.\u003Cdefault\u003EnotLookingAt(autotiler, obj1, obj2, obj3, obj4, obj5, obj6);
      }

      public static bool lookingAtEither(
        [In] Autotiler obj0,
        [In] Tile obj1,
        [In] int obj2,
        [In] int obj3,
        [In] int obj4,
        [In] int obj5,
        [In] Block obj6)
      {
        Autotiler autotiler = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(autotiler, ToString);
        return Autotiler.\u003Cdefault\u003ElookingAtEither(autotiler, obj1, obj2, obj3, obj4, obj5, obj6);
      }

      public static bool lookingAt(
        [In] Autotiler obj0,
        [In] Tile obj1,
        [In] int obj2,
        [In] int obj3,
        [In] int obj4,
        [In] Block obj5)
      {
        Autotiler autotiler = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(autotiler, ToString);
        return Autotiler.\u003Cdefault\u003ElookingAt(autotiler, obj1, obj2, obj3, obj4, obj5);
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly BuildPlan arg\u00241;
      private readonly BuildPlan[] arg\u00242;

      internal __\u003C\u003EAnon1([In] BuildPlan obj0, [In] BuildPlan[] obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => Autotiler.__\u003C\u003EPIM.lambda\u0024getTiling\u00240(this.arg\u00241, this.arg\u00242, (BuildPlan) obj0);
    }
  }
}
