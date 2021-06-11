// Decompiled with JetBrains decompiler
// Type: mindustry.net.ServerGroup
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace mindustry.net
{
  public class ServerGroup : Object
  {
    public string name;
    public string[] addresses;

    [LineNumberTable(26)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual string key() => new StringBuilder().append("server-").append(!String.instancehelper_isEmpty(this.name) ? this.name : (this.addresses.Length != 0 ? this.addresses[0] : "")).toString();

    [LineNumberTable(new byte[] {159, 151, 104, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ServerGroup(string name, string[] addresses)
    {
      ServerGroup serverGroup = this;
      this.name = name;
      this.addresses = addresses;
    }

    [LineNumberTable(new byte[] {159, 156, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ServerGroup()
    {
    }

    [LineNumberTable(18)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hidden() => Core.settings.getBool(new StringBuilder().append(this.key()).append("-hidden").toString(), false);

    [LineNumberTable(new byte[] {159, 137, 130, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setHidden(bool hidden)
    {
      int num = hidden ? 1 : 0;
      Core.settings.put(new StringBuilder().append(this.key()).append("-hidden").toString(), (object) Boolean.valueOf(num != 0));
    }
  }
}
