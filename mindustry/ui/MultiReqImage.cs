// Decompiled with JetBrains decompiler
// Type: mindustry.ui.MultiReqImage
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.scene;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui
{
  public class MultiReqImage : Stack
  {
    [Signature("Larc/struct/Seq<Lmindustry/ui/ReqImage;>;")]
    private Seq displays;
    private float time;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(22)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024act\u00240([In] ReqImage obj0) => obj0.visible = false;

    [LineNumberTable(new byte[] {159, 149, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MultiReqImage()
    {
      MultiReqImage multiReqImage = this;
      this.displays = new Seq();
    }

    [LineNumberTable(new byte[] {159, 154, 108, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(ReqImage display)
    {
      this.displays.add((object) display);
      this.add((Element) display);
    }

    [LineNumberTable(new byte[] {159, 160, 136, 154, 149, 123, 99, 137, 110, 191, 23})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void act(float delta)
    {
      base.act(delta);
      this.time += Time.delta / 60f;
      this.displays.each((Cons) new MultiReqImage.__\u003C\u003EAnon0());
      ReqImage reqImage = (ReqImage) this.displays.find((Boolf) new MultiReqImage.__\u003C\u003EAnon1());
      if (reqImage != null)
      {
        reqImage.visible = true;
      }
      else
      {
        if (this.displays.size <= 0)
          return;
        Seq displays = this.displays;
        int num = ByteCodeHelper.f2i(this.time);
        int size = this.displays.size;
        int index = size != -1 ? num % size : 0;
        ((Element) displays.get(index)).visible = true;
      }
    }

    [HideFromJava]
    static MultiReqImage() => Stack.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void get([In] object obj0) => MultiReqImage.lambda\u0024act\u00240((ReqImage) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Boolf
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public bool get([In] object obj0) => (((ReqImage) obj0).valid() ? 1 : 0) != 0;
    }
  }
}
