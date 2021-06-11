// Decompiled with JetBrains decompiler
// Type: mindustry.logic.LAssembler
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.logic
{
  public class LAssembler : Object
  {
    [Signature("Larc/struct/ObjectMap<Ljava/lang/String;Larc/func/Func<[Ljava/lang/String;Lmindustry/logic/LStatement;>;>;")]
    public static ObjectMap customParsers;
    public const int maxTokenLength = 36;
    private const int invalidNum = -2147483648;
    private int lastVar;
    [Signature("Larc/struct/ObjectMap<Ljava/lang/String;Lmindustry/logic/LAssembler$BVar;>;")]
    public ObjectMap vars;
    public LExecutor.LInstruction[] instructions;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {55, 110, 146, 121, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual LAssembler.BVar putVar(string name)
    {
      if (this.vars.containsKey((object) name))
        return (LAssembler.BVar) this.vars.get((object) name);
      LAssembler lassembler1 = this;
      int lastVar = lassembler1.lastVar;
      LAssembler lassembler2 = lassembler1;
      int id = lastVar;
      lassembler2.lastVar = lastVar + 1;
      LAssembler.BVar bvar = new LAssembler.BVar(id);
      this.vars.put((object) name, (object) bvar);
      return bvar;
    }

    [LineNumberTable(new byte[] {47, 104, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual LAssembler.BVar putConst(string name, object value)
    {
      LAssembler.BVar bvar = this.putVar(name);
      bvar.constant = true;
      bvar.value = value;
      return bvar;
    }

    [LineNumberTable(new byte[] {159, 164, 232, 60, 235, 70, 150, 146, 141, 141, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LAssembler()
    {
      LAssembler lassembler = this;
      this.vars = new ObjectMap();
      this.putVar("@counter").value = (object) Integer.valueOf(0);
      this.putConst("@time", (object) Integer.valueOf(0));
      this.putConst("@unit", (object) null);
      this.putConst("@this", (object) null);
      this.putConst("@tick", (object) Integer.valueOf(0));
    }

    [Signature("(Ljava/lang/String;)Larc/struct/Seq<Lmindustry/logic/LStatement;>;")]
    [LineNumberTable(55)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Seq read(string data) => LParser.parse(data);

    [LineNumberTable(new byte[] {39, 127, 4, 159, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual double parseDouble([In] string obj0)
    {
      if (String.instancehelper_startsWith(obj0, "0b"))
        return (double) Strings.parseLong(obj0, 2, 2, String.instancehelper_length(obj0), (long) int.MinValue);
      return String.instancehelper_startsWith(obj0, "0x") ? (double) Strings.parseLong(obj0, 16, 2, String.instancehelper_length(obj0), (long) int.MinValue) : Strings.parseDouble(obj0, (double) int.MinValue);
    }

    [Modifiers]
    [LineNumberTable(40)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static LExecutor.LInstruction lambda\u0024assemble\u00240(
      [In] LAssembler obj0,
      [In] LStatement obj1)
    {
      return obj1.build(obj0);
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024assemble\u00241([In] LExecutor.LInstruction obj0) => obj0 != null;

    [LineNumberTable(new byte[] {159, 178, 134, 135, 127, 22})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static LAssembler assemble(string data)
    {
      LAssembler lassembler = new LAssembler();
      Seq seq = LAssembler.read(data);
      lassembler.instructions = (LExecutor.LInstruction[]) seq.map((Func) new LAssembler.__\u003C\u003EAnon0(lassembler)).filter((Boolf) new LAssembler.__\u003C\u003EAnon1()).toArray((Class) ClassLiteral<LExecutor.LInstruction>.Value);
      return lassembler;
    }

    [Signature("(Larc/struct/Seq<Lmindustry/logic/LStatement;>;)Ljava/lang/String;")]
    [LineNumberTable(new byte[] {159, 187, 102, 123, 103, 108, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string write(Seq statements)
    {
      StringBuilder builder = new StringBuilder();
      Iterator iterator = statements.iterator();
      while (iterator.hasNext())
      {
        ((LStatement) iterator.next()).write(builder);
        builder.append("\n");
      }
      return builder.toString();
    }

    [LineNumberTable(new byte[] {11, 108, 132, 163, 168, 127, 15, 223, 71, 140, 139, 109, 173})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int var(string symbol)
    {
      int num1 = Vars.constants.get(symbol);
      if (num1 > 0)
        return -num1;
      symbol = String.instancehelper_trim(symbol);
      if (!String.instancehelper_isEmpty(symbol) && String.instancehelper_charAt(symbol, 0) == '"' && String.instancehelper_charAt(symbol, String.instancehelper_length(symbol) - 1) == '"')
      {
        string name = new StringBuilder().append("___").append(symbol).toString();
        string str1 = String.instancehelper_substring(symbol, 1, String.instancehelper_length(symbol) - 1);
        object obj1 = (object) "\n";
        object obj2 = (object) "\\n";
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj2;
        CharSequence charSequence2 = charSequence1;
        object obj3 = obj1;
        charSequence1.__\u003Cref\u003E = (__Null) obj3;
        CharSequence charSequence3 = charSequence1;
        string str2 = String.instancehelper_replace(str1, charSequence2, charSequence3);
        return this.putConst(name, (object) str2).id;
      }
      symbol = String.instancehelper_replace(symbol, ' ', '_');
      double num2 = this.parseDouble(symbol);
      return num2 == (double) int.MinValue ? this.putVar(symbol).id : this.putConst(new StringBuilder().append("___").append(num2).toString(), (object) Double.valueOf(num2)).id;
    }

    [LineNumberTable(116)]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual LAssembler.BVar getVar(string name) => (LAssembler.BVar) this.vars.get((object) name);

    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static LAssembler()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.logic.LAssembler"))
        return;
      LAssembler.customParsers = new ObjectMap();
    }

    public class BVar : Object
    {
      public int id;
      public bool constant;
      public object value;

      [LineNumberTable(new byte[] {75, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public BVar(int id)
      {
        LAssembler.BVar bvar = this;
        this.id = id;
      }

      [LineNumberTable(129)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal BVar()
      {
      }

      [LineNumberTable(133)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string toString() => new StringBuilder().append("BVar{id=").append(this.id).append(", constant=").append(this.constant).append(", value=").append(this.value).append('}').toString();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Func
    {
      private readonly LAssembler arg\u00241;

      internal __\u003C\u003EAnon0([In] LAssembler obj0) => this.arg\u00241 = obj0;

      public object get([In] object obj0) => (object) LAssembler.lambda\u0024assemble\u00240(this.arg\u00241, (LStatement) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Boolf
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public bool get([In] object obj0) => (LAssembler.lambda\u0024assemble\u00241((LExecutor.LInstruction) obj0) ? 1 : 0) != 0;
    }
  }
}
