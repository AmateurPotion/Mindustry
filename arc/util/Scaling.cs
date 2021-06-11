// Decompiled with JetBrains decompiler
// Type: arc.util.Scaling
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.util
{
  [Signature("Ljava/lang/Enum<Larc/util/Scaling;>;")]
  [Modifiers]
  [Serializable]
  public sealed class Scaling : Enum
  {
    [Modifiers]
    internal static Scaling __\u003C\u003Efit;
    [Modifiers]
    internal static Scaling __\u003C\u003Ebounded;
    [Modifiers]
    internal static Scaling __\u003C\u003Efill;
    [Modifiers]
    internal static Scaling __\u003C\u003EfillX;
    [Modifiers]
    internal static Scaling __\u003C\u003EfillY;
    [Modifiers]
    internal static Scaling __\u003C\u003Estretch;
    [Modifiers]
    internal static Scaling __\u003C\u003EstretchX;
    [Modifiers]
    internal static Scaling __\u003C\u003EstretchY;
    [Modifiers]
    internal static Scaling __\u003C\u003Enone;
    [Modifiers]
    private static Vec2 temp;
    [Modifiers]
    private static Scaling[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {6, 159, 29, 104, 103, 116, 111, 111, 165, 104, 103, 116, 111, 111, 165, 103, 111, 111, 165, 104, 111, 111, 165, 108, 109, 133, 108, 108, 130, 108, 109, 130, 109, 148, 180, 108, 172})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 apply(
      float sourceWidth,
      float sourceHeight,
      float targetWidth,
      float targetHeight)
    {
      switch (Scaling.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024Scaling[this.ordinal()])
      {
        case 1:
          float num1 = (double) (targetHeight / targetWidth) <= (double) (sourceHeight / sourceWidth) ? targetHeight / sourceHeight : targetWidth / sourceWidth;
          Scaling.temp.x = sourceWidth * num1;
          Scaling.temp.y = sourceHeight * num1;
          break;
        case 2:
          float num2 = (double) (targetHeight / targetWidth) >= (double) (sourceHeight / sourceWidth) ? targetHeight / sourceHeight : targetWidth / sourceWidth;
          Scaling.temp.x = sourceWidth * num2;
          Scaling.temp.y = sourceHeight * num2;
          break;
        case 3:
          float num3 = targetWidth / sourceWidth;
          Scaling.temp.x = sourceWidth * num3;
          Scaling.temp.y = sourceHeight * num3;
          break;
        case 4:
          float num4 = targetHeight / sourceHeight;
          Scaling.temp.x = sourceWidth * num4;
          Scaling.temp.y = sourceHeight * num4;
          break;
        case 5:
          Scaling.temp.x = targetWidth;
          Scaling.temp.y = targetHeight;
          break;
        case 6:
          Scaling.temp.x = targetWidth;
          Scaling.temp.y = sourceHeight;
          break;
        case 7:
          Scaling.temp.x = sourceWidth;
          Scaling.temp.y = targetHeight;
          break;
        case 8:
          return (double) sourceHeight > (double) targetHeight || (double) sourceWidth > (double) targetWidth ? Scaling.__\u003C\u003Efit.apply(sourceWidth, sourceHeight, targetWidth, targetHeight) : Scaling.__\u003C\u003Enone.apply(sourceWidth, sourceHeight, targetWidth, targetHeight);
        case 9:
          Scaling.temp.x = sourceWidth;
          Scaling.temp.y = sourceHeight;
          break;
      }
      return Scaling.temp;
    }

    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scaling[] values() => (Scaling[]) Scaling.\u0024VALUES.Clone();

    [Signature("()V")]
    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Scaling([In] string obj0, [In] int obj1)
      : base(obj0, obj1)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scaling valueOf(string name) => (Scaling) Enum.valueOf((Class) ClassLiteral<Scaling>.Value, name);

    [LineNumberTable(new byte[] {159, 139, 141, 208, 240, 69, 240, 69, 240, 69, 144, 240, 69, 240, 69, 144, 240, 26, 255, 53, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Scaling()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.util.Scaling"))
        return;
      Scaling.__\u003C\u003Efit = new Scaling(nameof (fit), 0);
      Scaling.__\u003C\u003Ebounded = new Scaling(nameof (bounded), 1);
      Scaling.__\u003C\u003Efill = new Scaling(nameof (fill), 2);
      Scaling.__\u003C\u003EfillX = new Scaling(nameof (fillX), 3);
      Scaling.__\u003C\u003EfillY = new Scaling(nameof (fillY), 4);
      Scaling.__\u003C\u003Estretch = new Scaling(nameof (stretch), 5);
      Scaling.__\u003C\u003EstretchX = new Scaling(nameof (stretchX), 6);
      Scaling.__\u003C\u003EstretchY = new Scaling(nameof (stretchY), 7);
      Scaling.__\u003C\u003Enone = new Scaling(nameof (none), 8);
      Scaling.\u0024VALUES = new Scaling[9]
      {
        Scaling.__\u003C\u003Efit,
        Scaling.__\u003C\u003Ebounded,
        Scaling.__\u003C\u003Efill,
        Scaling.__\u003C\u003EfillX,
        Scaling.__\u003C\u003EfillY,
        Scaling.__\u003C\u003Estretch,
        Scaling.__\u003C\u003EstretchX,
        Scaling.__\u003C\u003EstretchY,
        Scaling.__\u003C\u003Enone
      };
      Scaling.temp = new Vec2();
    }

    [Modifiers]
    public static Scaling fit
    {
      [HideFromJava] get => Scaling.__\u003C\u003Efit;
    }

    [Modifiers]
    public static Scaling bounded
    {
      [HideFromJava] get => Scaling.__\u003C\u003Ebounded;
    }

    [Modifiers]
    public static Scaling fill
    {
      [HideFromJava] get => Scaling.__\u003C\u003Efill;
    }

    [Modifiers]
    public static Scaling fillX
    {
      [HideFromJava] get => Scaling.__\u003C\u003EfillX;
    }

    [Modifiers]
    public static Scaling fillY
    {
      [HideFromJava] get => Scaling.__\u003C\u003EfillY;
    }

    [Modifiers]
    public static Scaling stretch
    {
      [HideFromJava] get => Scaling.__\u003C\u003Estretch;
    }

    [Modifiers]
    public static Scaling stretchX
    {
      [HideFromJava] get => Scaling.__\u003C\u003EstretchX;
    }

    [Modifiers]
    public static Scaling stretchY
    {
      [HideFromJava] get => Scaling.__\u003C\u003EstretchY;
    }

    [Modifiers]
    public static Scaling none
    {
      [HideFromJava] get => Scaling.__\u003C\u003Enone;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
      fit,
      bounded,
      fill,
      fillX,
      fillY,
      stretch,
      stretchX,
      stretchY,
      none,
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [SpecialName]
    internal class \u0031 : Object
    {
      [Modifiers]
      internal static int[] \u0024SwitchMap\u0024arc\u0024util\u0024Scaling;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(56)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static \u0031()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.util.Scaling$1"))
          return;
        Scaling.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024Scaling = new int[Scaling.values().Length];
        try
        {
          Scaling.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024Scaling[Scaling.__\u003C\u003Efit.ordinal()] = 1;
          goto label_6;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_6:
        try
        {
          Scaling.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024Scaling[Scaling.__\u003C\u003Efill.ordinal()] = 2;
          goto label_10;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_10:
        try
        {
          Scaling.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024Scaling[Scaling.__\u003C\u003EfillX.ordinal()] = 3;
          goto label_14;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_14:
        try
        {
          Scaling.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024Scaling[Scaling.__\u003C\u003EfillY.ordinal()] = 4;
          goto label_18;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_18:
        try
        {
          Scaling.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024Scaling[Scaling.__\u003C\u003Estretch.ordinal()] = 5;
          goto label_22;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_22:
        try
        {
          Scaling.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024Scaling[Scaling.__\u003C\u003EstretchX.ordinal()] = 6;
          goto label_26;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_26:
        try
        {
          Scaling.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024Scaling[Scaling.__\u003C\u003EstretchY.ordinal()] = 7;
          goto label_30;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_30:
        try
        {
          Scaling.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024Scaling[Scaling.__\u003C\u003Ebounded.ordinal()] = 8;
          goto label_34;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_34:
        try
        {
          Scaling.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024Scaling[Scaling.__\u003C\u003Enone.ordinal()] = 9;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
      }

      \u0031() => throw null;
    }
  }
}
