// Decompiled with JetBrains decompiler
// Type: rhino.SymbolKey
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino
{
  public class SymbolKey : Object, Symbol
  {
    internal static SymbolKey __\u003C\u003EITERATOR;
    internal static SymbolKey __\u003C\u003ETO_STRING_TAG;
    internal static SymbolKey __\u003C\u003ESPECIES;
    internal static SymbolKey __\u003C\u003EHAS_INSTANCE;
    internal static SymbolKey __\u003C\u003EIS_CONCAT_SPREADABLE;
    internal static SymbolKey __\u003C\u003EIS_REGEXP;
    internal static SymbolKey __\u003C\u003ETO_PRIMITIVE;
    internal static SymbolKey __\u003C\u003EMATCH;
    internal static SymbolKey __\u003C\u003EREPLACE;
    internal static SymbolKey __\u003C\u003ESEARCH;
    internal static SymbolKey __\u003C\u003ESPLIT;
    internal static SymbolKey __\u003C\u003EUNSCOPABLES;
    [Modifiers]
    private string name;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 186, 104, 142, 104, 152})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object o)
    {
      switch (o)
      {
        case SymbolKey _:
          return object.ReferenceEquals(o, (object) this);
        case NativeSymbol _:
          return object.ReferenceEquals((object) ((NativeSymbol) o).getKey(), (object) this);
        default:
          return false;
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getName() => this.name;

    [LineNumberTable(new byte[] {159, 171, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SymbolKey(string name)
    {
      SymbolKey symbolKey = this;
      this.name = name;
    }

    [LineNumberTable(new byte[] {5, 104, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => this.name == null ? "Symbol()" : new StringBuilder().append("Symbol(").append(this.name).append(')').toString();

    [LineNumberTable(39)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode() => java.lang.System.identityHashCode((object) this);

    [LineNumberTable(new byte[] {159, 139, 141, 111, 111, 111, 111, 111, 111, 111, 111, 111, 111, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static SymbolKey()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.SymbolKey"))
        return;
      SymbolKey.__\u003C\u003EITERATOR = new SymbolKey("Symbol.iterator");
      SymbolKey.__\u003C\u003ETO_STRING_TAG = new SymbolKey("Symbol.toStringTag");
      SymbolKey.__\u003C\u003ESPECIES = new SymbolKey("Symbol.species");
      SymbolKey.__\u003C\u003EHAS_INSTANCE = new SymbolKey("Symbol.hasInstance");
      SymbolKey.__\u003C\u003EIS_CONCAT_SPREADABLE = new SymbolKey("Symbol.isConcatSpreadable");
      SymbolKey.__\u003C\u003EIS_REGEXP = new SymbolKey("Symbol.isRegExp");
      SymbolKey.__\u003C\u003ETO_PRIMITIVE = new SymbolKey("Symbol.toPrimitive");
      SymbolKey.__\u003C\u003EMATCH = new SymbolKey("Symbol.match");
      SymbolKey.__\u003C\u003EREPLACE = new SymbolKey("Symbol.replace");
      SymbolKey.__\u003C\u003ESEARCH = new SymbolKey("Symbol.search");
      SymbolKey.__\u003C\u003ESPLIT = new SymbolKey("Symbol.split");
      SymbolKey.__\u003C\u003EUNSCOPABLES = new SymbolKey("Symbol.unscopables");
    }

    [Modifiers]
    public static SymbolKey ITERATOR
    {
      [HideFromJava] get => SymbolKey.__\u003C\u003EITERATOR;
    }

    [Modifiers]
    public static SymbolKey TO_STRING_TAG
    {
      [HideFromJava] get => SymbolKey.__\u003C\u003ETO_STRING_TAG;
    }

    [Modifiers]
    public static SymbolKey SPECIES
    {
      [HideFromJava] get => SymbolKey.__\u003C\u003ESPECIES;
    }

    [Modifiers]
    public static SymbolKey HAS_INSTANCE
    {
      [HideFromJava] get => SymbolKey.__\u003C\u003EHAS_INSTANCE;
    }

    [Modifiers]
    public static SymbolKey IS_CONCAT_SPREADABLE
    {
      [HideFromJava] get => SymbolKey.__\u003C\u003EIS_CONCAT_SPREADABLE;
    }

    [Modifiers]
    public static SymbolKey IS_REGEXP
    {
      [HideFromJava] get => SymbolKey.__\u003C\u003EIS_REGEXP;
    }

    [Modifiers]
    public static SymbolKey TO_PRIMITIVE
    {
      [HideFromJava] get => SymbolKey.__\u003C\u003ETO_PRIMITIVE;
    }

    [Modifiers]
    public static SymbolKey MATCH
    {
      [HideFromJava] get => SymbolKey.__\u003C\u003EMATCH;
    }

    [Modifiers]
    public static SymbolKey REPLACE
    {
      [HideFromJava] get => SymbolKey.__\u003C\u003EREPLACE;
    }

    [Modifiers]
    public static SymbolKey SEARCH
    {
      [HideFromJava] get => SymbolKey.__\u003C\u003ESEARCH;
    }

    [Modifiers]
    public static SymbolKey SPLIT
    {
      [HideFromJava] get => SymbolKey.__\u003C\u003ESPLIT;
    }

    [Modifiers]
    public static SymbolKey UNSCOPABLES
    {
      [HideFromJava] get => SymbolKey.__\u003C\u003EUNSCOPABLES;
    }
  }
}
