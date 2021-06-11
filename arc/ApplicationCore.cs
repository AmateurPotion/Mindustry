// Decompiled with JetBrains decompiler
// Type: arc.ApplicationCore
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.files;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc
{
  public abstract class ApplicationCore : Object, ApplicationListener
  {
    protected internal ApplicationListener[] modules;

    public abstract void setup();

    [LineNumberTable(new byte[] {159, 147, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ApplicationCore()
    {
      ApplicationCore applicationCore = this;
      this.modules = new ApplicationListener[0];
    }

    [LineNumberTable(new byte[] {159, 151, 111, 103, 117, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(ApplicationListener module)
    {
      ApplicationListener[] applicationListenerArray = new ApplicationListener[this.modules.Length + 1];
      applicationListenerArray[applicationListenerArray.Length - 1] = module;
      ByteCodeHelper.arraycopy((object) this.modules, 0, (object) applicationListenerArray, 0, this.modules.Length);
      this.modules = applicationListenerArray;
    }

    [LineNumberTable(new byte[] {159, 161, 134, 116, 38, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void init()
    {
      this.setup();
      ApplicationListener[] modules = this.modules;
      int length = modules.Length;
      for (int index = 0; index < length; ++index)
        modules[index].init();
    }

    [LineNumberTable(new byte[] {159, 170, 116, 40, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void resize(int width, int height)
    {
      ApplicationListener[] modules = this.modules;
      int length = modules.Length;
      for (int index = 0; index < length; ++index)
        modules[index].resize(width, height);
    }

    [LineNumberTable(new byte[] {159, 177, 116, 38, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      ApplicationListener[] modules = this.modules;
      int length = modules.Length;
      for (int index = 0; index < length; ++index)
        modules[index].update();
    }

    [LineNumberTable(new byte[] {159, 184, 116, 38, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void pause()
    {
      ApplicationListener[] modules = this.modules;
      int length = modules.Length;
      for (int index = 0; index < length; ++index)
        modules[index].pause();
    }

    [LineNumberTable(new byte[] {159, 191, 116, 38, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void resume()
    {
      ApplicationListener[] modules = this.modules;
      int length = modules.Length;
      for (int index = 0; index < length; ++index)
        modules[index].resume();
    }

    [LineNumberTable(new byte[] {6, 116, 38, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      ApplicationListener[] modules = this.modules;
      int length = modules.Length;
      for (int index = 0; index < length; ++index)
        modules[index].dispose();
    }

    [LineNumberTable(new byte[] {13, 116, 39, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void fileDropped(Fi file)
    {
      ApplicationListener[] modules = this.modules;
      int length = modules.Length;
      for (int index = 0; index < length; ++index)
        modules[index].fileDropped(file);
    }

    [HideFromJava]
    public virtual void exit() => ApplicationListener.\u003Cdefault\u003Eexit((ApplicationListener) this);
  }
}
