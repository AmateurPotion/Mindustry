// Decompiled with JetBrains decompiler
// Type: mindustry.type.AmmoType
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using IKVM.Attributes;
using java.lang;
using mindustry.ctype;
using mindustry.gen;
using mindustry.graphics;
using System.Runtime.CompilerServices;

namespace mindustry.type
{
  public class AmmoType : Content
  {
    public string icon;
    public Color color;
    public Color barColor;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void resupply(Unit unit)
    {
    }

    [LineNumberTable(new byte[] {159, 139, 130, 232, 60, 107, 107, 171, 127, 1, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public AmmoType(char icon, Color color)
    {
      int num = (int) icon;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      AmmoType ammoType = this;
      this.icon = "\uF838";
      this.color = Pal.ammo;
      this.barColor = Pal.ammo;
      this.icon = new StringBuilder().append((char) num).append("").toString();
      this.color = color;
    }

    [LineNumberTable(new byte[] {159, 161, 232, 55, 107, 107, 235, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public AmmoType()
    {
      AmmoType ammoType = this;
      this.icon = "\uF838";
      this.color = Pal.ammo;
      this.barColor = Pal.ammo;
    }

    [LineNumberTable(26)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override ContentType getContentType() => ContentType.__\u003C\u003Eammo;
  }
}
