// Decompiled with JetBrains decompiler
// Type: arc.assets.loaders.resolvers.ResolutionFileResolver
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.files;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.assets.loaders.resolvers
{
  public class ResolutionFileResolver : Object, FileHandleResolver
  {
    internal FileHandleResolver __\u003C\u003EbaseResolver;
    internal ResolutionFileResolver.Resolution[] __\u003C\u003Edescriptors;

    [LineNumberTable(new byte[] {4, 182, 100, 103, 107, 101, 127, 19, 228, 61, 235, 70, 107, 101, 127, 19, 228, 61, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ResolutionFileResolver.Resolution choose(
      params ResolutionFileResolver.Resolution[] descriptors)
    {
      int width = Core.graphics.getWidth();
      int height = Core.graphics.getHeight();
      ResolutionFileResolver.Resolution descriptor1 = descriptors[0];
      if (width < height)
      {
        int index = 0;
        for (int length = descriptors.Length; index < length; ++index)
        {
          ResolutionFileResolver.Resolution descriptor2 = descriptors[index];
          if (width >= descriptor2.__\u003C\u003EportraitWidth && descriptor2.__\u003C\u003EportraitWidth >= descriptor1.__\u003C\u003EportraitWidth && (height >= descriptor2.__\u003C\u003EportraitHeight && descriptor2.__\u003C\u003EportraitHeight >= descriptor1.__\u003C\u003EportraitHeight))
            descriptor1 = descriptors[index];
        }
      }
      else
      {
        int index = 0;
        for (int length = descriptors.Length; index < length; ++index)
        {
          ResolutionFileResolver.Resolution descriptor2 = descriptors[index];
          if (width >= descriptor2.__\u003C\u003EportraitHeight && descriptor2.__\u003C\u003EportraitHeight >= descriptor1.__\u003C\u003EportraitHeight && (height >= descriptor2.__\u003C\u003EportraitWidth && descriptor2.__\u003C\u003EportraitWidth >= descriptor1.__\u003C\u003EportraitWidth))
            descriptor1 = descriptors[index];
        }
      }
      return descriptor1;
    }

    [LineNumberTable(new byte[] {34, 102, 103, 117, 155})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual string resolve(Fi originalHandle, string suffix)
    {
      string str = "";
      Fi fi = originalHandle.parent();
      if (fi != null && !String.instancehelper_equals(fi.name(), (object) ""))
        str = new StringBuilder().append((object) fi).append("/").toString();
      return new StringBuilder().append(str).append(suffix).append("/").append(originalHandle.name()).toString();
    }

    [LineNumberTable(new byte[] {159, 189, 104, 116, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ResolutionFileResolver(
      FileHandleResolver baseResolver,
      params ResolutionFileResolver.Resolution[] descriptors)
    {
      ResolutionFileResolver resolutionFileResolver = this;
      if (descriptors.Length == 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("At least one Resolution needs to be supplied.");
      }
      this.__\u003C\u003EbaseResolver = baseResolver;
      this.__\u003C\u003Edescriptors = descriptors;
    }

    [LineNumberTable(new byte[] {26, 108, 103, 121, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Fi resolve(string fileName)
    {
      ResolutionFileResolver.Resolution resolution = ResolutionFileResolver.choose(this.__\u003C\u003Edescriptors);
      Fi fi = this.__\u003C\u003EbaseResolver.resolve(this.resolve(new Fi(fileName), resolution.__\u003C\u003Efolder));
      if (!fi.exists())
        fi = this.__\u003C\u003EbaseResolver.resolve(fileName);
      return fi;
    }

    [Modifiers]
    protected internal FileHandleResolver baseResolver
    {
      [HideFromJava] get => this.__\u003C\u003EbaseResolver;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EbaseResolver = value;
    }

    [Modifiers]
    protected internal ResolutionFileResolver.Resolution[] descriptors
    {
      [HideFromJava] get => this.__\u003C\u003Edescriptors;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Edescriptors = value;
    }

    public class Resolution : Object
    {
      internal int __\u003C\u003EportraitWidth;
      internal int __\u003C\u003EportraitHeight;
      internal string __\u003C\u003Efolder;

      [LineNumberTable(new byte[] {55, 104, 103, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Resolution(int portraitWidth, int portraitHeight, string folder)
      {
        ResolutionFileResolver.Resolution resolution = this;
        this.__\u003C\u003EportraitWidth = portraitWidth;
        this.__\u003C\u003EportraitHeight = portraitHeight;
        this.__\u003C\u003Efolder = folder;
      }

      [Modifiers]
      public int portraitWidth
      {
        [HideFromJava] get => this.__\u003C\u003EportraitWidth;
        [HideFromJava] [param: In] private set => this.__\u003C\u003EportraitWidth = value;
      }

      [Modifiers]
      public int portraitHeight
      {
        [HideFromJava] get => this.__\u003C\u003EportraitHeight;
        [HideFromJava] [param: In] private set => this.__\u003C\u003EportraitHeight = value;
      }

      [Modifiers]
      public string folder
      {
        [HideFromJava] get => this.__\u003C\u003Efolder;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Efolder = value;
      }
    }
  }
}
