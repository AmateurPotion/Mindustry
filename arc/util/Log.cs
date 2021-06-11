// Decompiled with JetBrains decompiler
// Type: arc.util.Log
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.util
{
  public class Log : Object
  {
    [Modifiers]
    private static object[] empty;
    public static bool useColors;
    public static Log.LogLevel level;
    public static Log.LogHandler logger;
    public static Log.LogFormatter formatter;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {12, 102, 103, 103, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void err(Exception th)
    {
      StringWriter stringWriter = new StringWriter();
      PrintWriter printWriter = new PrintWriter((Writer) stringWriter);
      Throwable.instancehelper_printStackTrace(th, printWriter);
      Log.err(stringWriter.toString());
    }

    [LineNumberTable(new byte[] {159, 184, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void info(string text, params object[] args) => Log.log(Log.LogLevel.__\u003C\u003Einfo, text, args);

    [LineNumberTable(new byte[] {159, 188, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void info(object @object) => Log.info(String.valueOf(@object), Log.empty);

    [LineNumberTable(new byte[] {8, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void err(string text, params object[] args) => Log.log(Log.LogLevel.__\u003C\u003Eerr, text, args);

    [LineNumberTable(new byte[] {159, 162, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void debug(string text, params object[] args) => Log.log(Log.LogLevel.__\u003C\u003Edebug, text, args);

    [LineNumberTable(new byte[] {34, 118, 63, 48, 169})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string removeColors(string text)
    {
      string[] codes = ColorCodes.__\u003C\u003Ecodes;
      int length = codes.Length;
      for (int index = 0; index < length; ++index)
      {
        string str1 = codes[index];
        string str2 = text;
        string str3 = new StringBuilder().append("&").append(str1).toString();
        object obj1 = (object) "";
        object obj2 = (object) str3;
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj2;
        CharSequence charSequence2 = charSequence1;
        object obj3 = obj1;
        charSequence1.__\u003Cref\u003E = (__Null) obj3;
        CharSequence charSequence3 = charSequence1;
        text = String.instancehelper_replace(str2, charSequence2, charSequence3);
      }
      return text;
    }

    [LineNumberTable(76)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string format(string text, params object[] args) => Log.formatColors(text, Log.useColors, args);

    [LineNumberTable(new byte[] {159, 166, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void debug(object @object) => Log.debug(String.valueOf(@object), Log.empty);

    [LineNumberTable(new byte[] {0, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void warn(string text, params object[] args) => Log.log(Log.LogLevel.__\u003C\u003Ewarn, text, args);

    [LineNumberTable(new byte[] {19, 102, 103, 103, 127, 17})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void err(string text, Exception th)
    {
      StringWriter stringWriter = new StringWriter();
      PrintWriter printWriter = new PrintWriter((Writer) stringWriter);
      Throwable.instancehelper_printStackTrace(th, printWriter);
      Log.err(new StringBuilder().append(text).append(": ").append(stringWriter.toString()).toString());
    }

    [LineNumberTable(new byte[] {159, 157, 115, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void log(Log.LogLevel level, string text, params object[] args)
    {
      if (Log.level.ordinal() > level.ordinal())
        return;
      Log.logger.log(level, Log.format(text, args));
    }

    [LineNumberTable(new byte[] {41, 110, 63, 50, 169})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string addColors(string text)
    {
      for (int index = 0; index < ColorCodes.__\u003C\u003Ecodes.Length; ++index)
      {
        string str1 = text;
        string str2 = new StringBuilder().append("&").append(ColorCodes.__\u003C\u003Ecodes[index]).toString();
        object obj1 = (object) ColorCodes.__\u003C\u003Evalues[index];
        object obj2 = (object) str2;
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj2;
        CharSequence charSequence2 = charSequence1;
        object obj3 = obj1;
        charSequence1.__\u003Cref\u003E = (__Null) obj3;
        CharSequence charSequence3 = charSequence1;
        text = String.instancehelper_replace(str1, charSequence2, charSequence3);
      }
      return text;
    }

    [LineNumberTable(80)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string formatColors(string text, bool useColors, params object[] args)
    {
      int num = useColors ? 1 : 0;
      return Log.formatter.format(text, num != 0, args);
    }

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Log()
    {
    }

    [LineNumberTable(new byte[] {159, 170, 119, 102, 112, 105, 12, 198, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void infoList(params object[] args)
    {
      if (Log.level.ordinal() > Log.LogLevel.__\u003C\u003Einfo.ordinal())
        return;
      StringBuilder stringBuilder = new StringBuilder();
      object[] objArray = args;
      int length = objArray.Length;
      for (int index = 0; index < length; ++index)
      {
        object obj = objArray[index];
        stringBuilder.append(obj);
        stringBuilder.append(" ");
      }
      Log.info((object) stringBuilder.toString());
    }

    [LineNumberTable(new byte[] {159, 180, 127, 27})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void infoTag(string tag, string text) => Log.log(Log.LogLevel.__\u003C\u003Einfo, new StringBuilder().append("[").append(tag).append("] ").append(text).toString());

    [LineNumberTable(new byte[] {4, 127, 27})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void errTag(string tag, string text) => Log.log(Log.LogLevel.__\u003C\u003Eerr, new StringBuilder().append("[").append(tag).append("] ").append(text).toString());

    [LineNumberTable(new byte[] {159, 141, 173, 139, 102, 106, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Log()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.util.Log"))
        return;
      Log.empty = new object[0];
      Log.useColors = true;
      Log.level = Log.LogLevel.__\u003C\u003Einfo;
      Log.logger = (Log.LogHandler) new Log.DefaultLogHandler();
      Log.formatter = (Log.LogFormatter) new Log.DefaultLogFormatter();
    }

    public class DefaultLogFormatter : Object, Log.LogFormatter
    {
      [LineNumberTable(109)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public DefaultLogFormatter()
      {
      }

      [LineNumberTable(new byte[] {159, 114, 66, 105})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string format(string text, bool useColors, params object[] args)
      {
        int num = useColors ? 1 : 0;
        text = Strings.format(text, args);
        return num != 0 ? Log.addColors(text) : Log.removeColors(text);
      }
    }

    public class DefaultLogHandler : Object, Log.LogHandler
    {
      [LineNumberTable(121)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public DefaultLogHandler()
      {
      }

      [LineNumberTable(new byte[] {74, 106, 116, 116, 116, 116, 255, 6, 59, 234, 70})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void log(Log.LogLevel level, string text) => java.lang.System.@out.println(Log.format(new StringBuilder().append(!object.ReferenceEquals((object) level, (object) Log.LogLevel.__\u003C\u003Edebug) ? (!object.ReferenceEquals((object) level, (object) Log.LogLevel.__\u003C\u003Einfo) ? (!object.ReferenceEquals((object) level, (object) Log.LogLevel.__\u003C\u003Ewarn) ? (!object.ReferenceEquals((object) level, (object) Log.LogLevel.__\u003C\u003Eerr) ? "" : "&lr&fb") : "&ly&fb") : "&fb") : "&lc&fb").append(text).append("&fr").toString()));
    }

    public interface LogFormatter
    {
      string format(string str, bool b, params object[] objarr);
    }

    public interface LogHandler
    {
      void log(Log.LogLevel lll, string str);
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Larc/util/Log$LogLevel;>;")]
    [Modifiers]
    [Serializable]
    public sealed class LogLevel : Enum
    {
      [Modifiers]
      internal static Log.LogLevel __\u003C\u003Edebug;
      [Modifiers]
      internal static Log.LogLevel __\u003C\u003Einfo;
      [Modifiers]
      internal static Log.LogLevel __\u003C\u003Ewarn;
      [Modifiers]
      internal static Log.LogLevel __\u003C\u003Eerr;
      [Modifiers]
      internal static Log.LogLevel __\u003C\u003Enone;
      [Modifiers]
      private static Log.LogLevel[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(97)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private LogLevel([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(97)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Log.LogLevel[] values() => (Log.LogLevel[]) Log.LogLevel.\u0024VALUES.Clone();

      [LineNumberTable(97)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Log.LogLevel valueOf(string name) => (Log.LogLevel) Enum.valueOf((Class) ClassLiteral<Log.LogLevel>.Value, name);

      [LineNumberTable(new byte[] {159, 118, 141, 112, 112, 112, 112, 240, 59})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static LogLevel()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.util.Log$LogLevel"))
          return;
        Log.LogLevel.__\u003C\u003Edebug = new Log.LogLevel(nameof (debug), 0);
        Log.LogLevel.__\u003C\u003Einfo = new Log.LogLevel(nameof (info), 1);
        Log.LogLevel.__\u003C\u003Ewarn = new Log.LogLevel(nameof (warn), 2);
        Log.LogLevel.__\u003C\u003Eerr = new Log.LogLevel(nameof (err), 3);
        Log.LogLevel.__\u003C\u003Enone = new Log.LogLevel(nameof (none), 4);
        Log.LogLevel.\u0024VALUES = new Log.LogLevel[5]
        {
          Log.LogLevel.__\u003C\u003Edebug,
          Log.LogLevel.__\u003C\u003Einfo,
          Log.LogLevel.__\u003C\u003Ewarn,
          Log.LogLevel.__\u003C\u003Eerr,
          Log.LogLevel.__\u003C\u003Enone
        };
      }

      [Modifiers]
      public static Log.LogLevel debug
      {
        [HideFromJava] get => Log.LogLevel.__\u003C\u003Edebug;
      }

      [Modifiers]
      public static Log.LogLevel info
      {
        [HideFromJava] get => Log.LogLevel.__\u003C\u003Einfo;
      }

      [Modifiers]
      public static Log.LogLevel warn
      {
        [HideFromJava] get => Log.LogLevel.__\u003C\u003Ewarn;
      }

      [Modifiers]
      public static Log.LogLevel err
      {
        [HideFromJava] get => Log.LogLevel.__\u003C\u003Eerr;
      }

      [Modifiers]
      public static Log.LogLevel none
      {
        [HideFromJava] get => Log.LogLevel.__\u003C\u003Enone;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        debug,
        info,
        warn,
        err,
        none,
      }
    }

    public class NoopLogHandler : Object, Log.LogHandler
    {
      [LineNumberTable(133)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public NoopLogHandler()
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void log(Log.LogLevel level, string text)
      {
      }
    }
  }
}
