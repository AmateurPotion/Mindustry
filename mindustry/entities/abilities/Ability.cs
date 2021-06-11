// Decompiled with JetBrains decompiler
// Type: mindustry.entities.abilities.Ability
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.gen;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.abilities
{
  public abstract class Ability : Object, Cloneable.__Interface
  {
    [LineNumberTable(26)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string localized()
    {
      I18NBundle bundle = Core.bundle;
      StringBuilder stringBuilder = new StringBuilder().append("ability.");
      string simpleName = Object.instancehelper_getClass((object) this).getSimpleName();
      object obj1 = (object) "";
      object obj2 = (object) nameof (Ability);
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj2;
      CharSequence charSequence2 = charSequence1;
      object obj3 = obj1;
      charSequence1.__\u003Cref\u003E = (__Null) obj3;
      CharSequence charSequence3 = charSequence1;
      string lowerCase = String.instancehelper_toLowerCase(String.instancehelper_replace(simpleName, charSequence2, charSequence3));
      string key = stringBuilder.append(lowerCase).toString();
      return bundle.get(key);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw(Unit unit)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void displayBars(Unit unit, Table bars)
    {
    }

    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Ability()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update(Unit unit)
    {
    }

    [LineNumberTable(new byte[] {159, 155, 127, 2, 129})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Ability copy()
    {
      Ability ability;
      CloneNotSupportedException supportedException1;
      try
      {
        ability = (Ability) this.clone();
      }
      catch (CloneNotSupportedException ex)
      {
        supportedException1 = (CloneNotSupportedException) ByteCodeHelper.MapException<CloneNotSupportedException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_3;
      }
      return ability;
label_3:
      CloneNotSupportedException supportedException2 = supportedException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException("java sucks", (Exception) supportedException2);
    }

    [HideFromJava]
    public static implicit operator Cloneable([In] Ability obj0)
    {
      Cloneable cloneable;
      cloneable.__\u003Cref\u003E = (__Null) obj0;
      return cloneable;
    }
  }
}
