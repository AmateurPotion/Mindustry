// Decompiled with JetBrains decompiler
// Type: arc.graphics.g2d.Animation
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.math;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.lang.reflect;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics.g2d
{
  [Signature("<T:Ljava/lang/Object;>Ljava/lang/Object;")]
  public class Animation : Object
  {
    [Signature("[TT;")]
    internal object[] keyFrames;
    private float frameDuration;
    private float animationDuration;
    private int lastFrameNumber;
    private float lastStateTime;
    private Animation.PlayMode playMode;

    [Signature("([TT;)V")]
    [LineNumberTable(new byte[] {106, 103, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void setKeyFrames(params object[] keyFrames)
    {
      this.keyFrames = keyFrames;
      this.animationDuration = (float) keyFrames.Length * this.frameDuration;
    }

    [Signature("(FLarc/struct/Seq<+TT;>;)V")]
    [LineNumberTable(new byte[] {159, 174, 232, 55, 235, 74, 104, 113, 114, 111, 42, 166, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Animation(float frameDuration, Seq keyFrames)
    {
      Animation animation = this;
      this.playMode = Animation.PlayMode.__\u003C\u003Enormal;
      this.frameDuration = frameDuration;
      object[] objArray = (object[]) Array.newInstance(Object.instancehelper_getClass((object) keyFrames.items).getComponentType(), keyFrames.size);
      int index = 0;
      for (int size = keyFrames.size; index < size; ++index)
        objArray[index] = keyFrames.get(index);
      this.setKeyFrames(objArray);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPlayMode(Animation.PlayMode playMode) => this.playMode = playMode;

    [Signature("(F)TT;")]
    [LineNumberTable(new byte[] {49, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getKeyFrame(float stateTime) => this.keyFrames[this.getKeyFrameIndex(stateTime)];

    [LineNumberTable(new byte[] {58, 140, 112, 159, 22, 112, 133, 115, 133, 119, 109, 185, 116, 100, 145, 135, 130, 114, 130, 115, 204, 103, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getKeyFrameIndex(float stateTime)
    {
      if (this.keyFrames.Length == 1)
        return 0;
      int num1 = ByteCodeHelper.f2i(stateTime / this.frameDuration);
      switch (Animation.\u0031.\u0024SwitchMap\u0024arc\u0024graphics\u0024g2d\u0024Animation\u0024PlayMode[this.playMode.ordinal()])
      {
        case 1:
          num1 = Math.min(this.keyFrames.Length - 1, num1);
          break;
        case 2:
          int num2 = num1;
          int length1 = this.keyFrames.Length;
          num1 = length1 != -1 ? num2 % length1 : 0;
          break;
        case 3:
          int num3 = num1;
          int num4 = this.keyFrames.Length * 2 - 2;
          num1 = num4 != -1 ? num3 % num4 : 0;
          if (num1 >= this.keyFrames.Length)
          {
            num1 = this.keyFrames.Length - 2 - (num1 - this.keyFrames.Length);
            break;
          }
          break;
        case 4:
          num1 = ByteCodeHelper.f2i(this.lastStateTime / this.frameDuration) == num1 ? this.lastFrameNumber : Mathf.random(this.keyFrames.Length - 1);
          break;
        case 5:
          num1 = Math.max(this.keyFrames.Length - num1 - 1, 0);
          break;
        case 6:
          int num5 = num1;
          int length2 = this.keyFrames.Length;
          num1 = this.keyFrames.Length - (length2 != -1 ? num5 % length2 : 0) - 1;
          break;
      }
      this.lastFrameNumber = num1;
      this.lastStateTime = stateTime;
      return num1;
    }

    [Signature("(FLarc/struct/Seq<+TT;>;Larc/graphics/g2d/Animation$PlayMode;)V")]
    [LineNumberTable(new byte[] {159, 191, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Animation(float frameDuration, Seq keyFrames, Animation.PlayMode playMode)
      : this(frameDuration, keyFrames)
    {
      Animation animation = this;
      this.setPlayMode(playMode);
    }

    [Signature("(F[TT;)V")]
    [LineNumberTable(new byte[] {8, 232, 29, 235, 100, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Animation(float frameDuration, params object[] keyFrames)
    {
      Animation animation = this;
      this.playMode = Animation.PlayMode.__\u003C\u003Enormal;
      this.frameDuration = frameDuration;
      this.setKeyFrames(keyFrames);
    }

    [Signature("(FZ)TT;")]
    [LineNumberTable(new byte[] {159, 124, 130, 103, 127, 8, 114, 141, 109, 127, 8, 114, 141, 171, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getKeyFrame(float stateTime, bool looping)
    {
      int num = looping ? 1 : 0;
      Animation.PlayMode playMode = this.playMode;
      if (num != 0 && (object.ReferenceEquals((object) this.playMode, (object) Animation.PlayMode.__\u003C\u003Enormal) || object.ReferenceEquals((object) this.playMode, (object) Animation.PlayMode.__\u003C\u003Ereversed)))
        this.playMode = !object.ReferenceEquals((object) this.playMode, (object) Animation.PlayMode.__\u003C\u003Enormal) ? Animation.PlayMode.__\u003C\u003EloopReversed : Animation.PlayMode.__\u003C\u003Eloop;
      else if (num == 0 && !object.ReferenceEquals((object) this.playMode, (object) Animation.PlayMode.__\u003C\u003Enormal) && !object.ReferenceEquals((object) this.playMode, (object) Animation.PlayMode.__\u003C\u003Ereversed))
        this.playMode = !object.ReferenceEquals((object) this.playMode, (object) Animation.PlayMode.__\u003C\u003EloopReversed) ? Animation.PlayMode.__\u003C\u003Eloop : Animation.PlayMode.__\u003C\u003Ereversed;
      object keyFrame = this.getKeyFrame(stateTime);
      this.playMode = playMode;
      return keyFrame;
    }

    [Signature("()[TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object[] getKeyFrames() => this.keyFrames;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Animation.PlayMode getPlayMode() => this.playMode;

    [LineNumberTable(new byte[] {160, 64, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isAnimationFinished(float stateTime) => this.keyFrames.Length - 1 < ByteCodeHelper.f2i(stateTime / this.frameDuration);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getFrameDuration() => this.frameDuration;

    [LineNumberTable(new byte[] {160, 78, 104, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFrameDuration(float frameDuration)
    {
      this.frameDuration = frameDuration;
      this.animationDuration = (float) this.keyFrames.Length * frameDuration;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getAnimationDuration() => this.animationDuration;

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [SpecialName]
    internal class \u0031 : Object
    {
      [Modifiers]
      internal static int[] \u0024SwitchMap\u0024arc\u0024graphics\u0024g2d\u0024Animation\u0024PlayMode;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(111)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static \u0031()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.graphics.g2d.Animation$1"))
          return;
        Animation.\u0031.\u0024SwitchMap\u0024arc\u0024graphics\u0024g2d\u0024Animation\u0024PlayMode = new int[Animation.PlayMode.values().Length];
        try
        {
          Animation.\u0031.\u0024SwitchMap\u0024arc\u0024graphics\u0024g2d\u0024Animation\u0024PlayMode[Animation.PlayMode.__\u003C\u003Enormal.ordinal()] = 1;
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
          Animation.\u0031.\u0024SwitchMap\u0024arc\u0024graphics\u0024g2d\u0024Animation\u0024PlayMode[Animation.PlayMode.__\u003C\u003Eloop.ordinal()] = 2;
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
          Animation.\u0031.\u0024SwitchMap\u0024arc\u0024graphics\u0024g2d\u0024Animation\u0024PlayMode[Animation.PlayMode.__\u003C\u003EloopPingPong.ordinal()] = 3;
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
          Animation.\u0031.\u0024SwitchMap\u0024arc\u0024graphics\u0024g2d\u0024Animation\u0024PlayMode[Animation.PlayMode.__\u003C\u003EloopRandom.ordinal()] = 4;
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
          Animation.\u0031.\u0024SwitchMap\u0024arc\u0024graphics\u0024g2d\u0024Animation\u0024PlayMode[Animation.PlayMode.__\u003C\u003Ereversed.ordinal()] = 5;
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
          Animation.\u0031.\u0024SwitchMap\u0024arc\u0024graphics\u0024g2d\u0024Animation\u0024PlayMode[Animation.PlayMode.__\u003C\u003EloopReversed.ordinal()] = 6;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
      }

      \u0031() => throw null;
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Larc/graphics/g2d/Animation$PlayMode;>;")]
    [Modifiers]
    [Serializable]
    public sealed class PlayMode : Enum
    {
      [Modifiers]
      internal static Animation.PlayMode __\u003C\u003Enormal;
      [Modifiers]
      internal static Animation.PlayMode __\u003C\u003Ereversed;
      [Modifiers]
      internal static Animation.PlayMode __\u003C\u003Eloop;
      [Modifiers]
      internal static Animation.PlayMode __\u003C\u003EloopReversed;
      [Modifiers]
      internal static Animation.PlayMode __\u003C\u003EloopPingPong;
      [Modifiers]
      internal static Animation.PlayMode __\u003C\u003EloopRandom;
      [Modifiers]
      private static Animation.PlayMode[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(202)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Animation.PlayMode[] values() => (Animation.PlayMode[]) Animation.PlayMode.\u0024VALUES.Clone();

      [Signature("()V")]
      [LineNumberTable(202)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private PlayMode([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(202)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Animation.PlayMode valueOf(string name) => (Animation.PlayMode) Enum.valueOf((Class) ClassLiteral<Animation.PlayMode>.Value, name);

      [LineNumberTable(new byte[] {159, 92, 173, 112, 112, 112, 112, 112, 240, 58})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static PlayMode()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.graphics.g2d.Animation$PlayMode"))
          return;
        Animation.PlayMode.__\u003C\u003Enormal = new Animation.PlayMode(nameof (normal), 0);
        Animation.PlayMode.__\u003C\u003Ereversed = new Animation.PlayMode(nameof (reversed), 1);
        Animation.PlayMode.__\u003C\u003Eloop = new Animation.PlayMode(nameof (loop), 2);
        Animation.PlayMode.__\u003C\u003EloopReversed = new Animation.PlayMode(nameof (loopReversed), 3);
        Animation.PlayMode.__\u003C\u003EloopPingPong = new Animation.PlayMode(nameof (loopPingPong), 4);
        Animation.PlayMode.__\u003C\u003EloopRandom = new Animation.PlayMode(nameof (loopRandom), 5);
        Animation.PlayMode.\u0024VALUES = new Animation.PlayMode[6]
        {
          Animation.PlayMode.__\u003C\u003Enormal,
          Animation.PlayMode.__\u003C\u003Ereversed,
          Animation.PlayMode.__\u003C\u003Eloop,
          Animation.PlayMode.__\u003C\u003EloopReversed,
          Animation.PlayMode.__\u003C\u003EloopPingPong,
          Animation.PlayMode.__\u003C\u003EloopRandom
        };
      }

      [Modifiers]
      public static Animation.PlayMode normal
      {
        [HideFromJava] get => Animation.PlayMode.__\u003C\u003Enormal;
      }

      [Modifiers]
      public static Animation.PlayMode reversed
      {
        [HideFromJava] get => Animation.PlayMode.__\u003C\u003Ereversed;
      }

      [Modifiers]
      public static Animation.PlayMode loop
      {
        [HideFromJava] get => Animation.PlayMode.__\u003C\u003Eloop;
      }

      [Modifiers]
      public static Animation.PlayMode loopReversed
      {
        [HideFromJava] get => Animation.PlayMode.__\u003C\u003EloopReversed;
      }

      [Modifiers]
      public static Animation.PlayMode loopPingPong
      {
        [HideFromJava] get => Animation.PlayMode.__\u003C\u003EloopPingPong;
      }

      [Modifiers]
      public static Animation.PlayMode loopRandom
      {
        [HideFromJava] get => Animation.PlayMode.__\u003C\u003EloopRandom;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        normal,
        reversed,
        loop,
        loopReversed,
        loopPingPong,
        loopRandom,
      }
    }
  }
}
