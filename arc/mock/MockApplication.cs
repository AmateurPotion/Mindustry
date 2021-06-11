// Decompiled with JetBrains decompiler
// Type: arc.mock.MockApplication
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.util;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.mock
{
  [Implements(new string[] {"arc.Application"})]
  public class MockApplication : Object, Application, Disposable
  {
    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MockApplication()
    {
    }

    [Signature("()Larc/struct/Seq<Larc/ApplicationListener;>;")]
    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getListeners() => new Seq();

    [LineNumberTable(14)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Application.ApplicationType getType() => Application.ApplicationType.__\u003C\u003Eheadless;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getClipboardText() => (string) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setClipboardText(string text)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void post(Runnable runnable)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void exit()
    {
    }

    [HideFromJava]
    public virtual void dispose() => Application.\u003Cdefault\u003Edispose((Application) this);

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

    [HideFromJava]
    public virtual void addListener([In] ApplicationListener obj0) => Application.\u003Cdefault\u003EaddListener((Application) this, obj0);

    [HideFromJava]
    public virtual void removeListener([In] ApplicationListener obj0) => Application.\u003Cdefault\u003EremoveListener((Application) this, obj0);

    [HideFromJava]
    public virtual void defaultUpdate() => Application.\u003Cdefault\u003EdefaultUpdate((Application) this);

    [HideFromJava]
    public virtual bool isDesktop() => Application.\u003Cdefault\u003EisDesktop((Application) this);

    [HideFromJava]
    public virtual bool isHeadless() => Application.\u003Cdefault\u003EisHeadless((Application) this);

    [HideFromJava]
    public virtual bool isAndroid() => Application.\u003Cdefault\u003EisAndroid((Application) this);

    [HideFromJava]
    public virtual bool isIOS() => Application.\u003Cdefault\u003EisIOS((Application) this);

    [HideFromJava]
    public virtual bool isMobile() => Application.\u003Cdefault\u003EisMobile((Application) this);

    [HideFromJava]
    public virtual bool isWeb() => Application.\u003Cdefault\u003EisWeb((Application) this);

    [HideFromJava]
    public virtual int getVersion() => Application.\u003Cdefault\u003EgetVersion((Application) this);

    [HideFromJava]
    public virtual long getJavaHeap() => Application.\u003Cdefault\u003EgetJavaHeap((Application) this);

    [HideFromJava]
    public virtual long getNativeHeap() => Application.\u003Cdefault\u003EgetNativeHeap((Application) this);

    [HideFromJava]
    public virtual bool openFolder([In] string obj0) => Application.\u003Cdefault\u003EopenFolder((Application) this, obj0);

    [HideFromJava]
    public virtual bool openURI([In] string obj0) => Application.\u003Cdefault\u003EopenURI((Application) this, obj0);
  }
}
